using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using DB;
using Globals;
namespace TMS.cixarislar
{
    public partial class frmArayis : Form
    {
        int tehmuddeti;
        string oldstud_id = "", lang = "az";
        
        oraConn con = oraConn.DB;
        FastReport.Report rArayis;
        FastReport.Report rArayisMezun;        
        SelStudInfo si = new SelStudInfo();
        string afac = "", adep = "", ISTIQAMET = "", edu_level;        
        General.functions f = new General.functions();
        public frmArayis()
        {
            InitializeComponent();
        }

        private void frmArayis_Load(object sender, EventArgs e)
        {
            LoadArayisInfo();
            string str_SQL = string.Empty;
            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 16 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();

            OracleDataReader dr = con.execSQL(str_SQL); bool ok = dr.Read();
            spinEdit_print.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_print.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
            spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);

            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 17 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();

            dr = con.execSQL(str_SQL); ok = dr.Read();
            spinEdit_mezun.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_mezun.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_mezun.Properties.Buttons[1].Enabled = (spinEdit_mezun.Value < spinEdit_mezun.Properties.MaxValue);
            spinEdit_mezun.Properties.Buttons[2].Enabled = (spinEdit_mezun.Value > spinEdit_mezun.Properties.MinValue);
        }

        private void LoadArayisInfo()
        {
            if (si.StudID.Length != 9) return;
            try
            {
                string sql = "select dp.istiqamet_" + lang + " as ISTIQAMET, P.PARENT_INFO_NAME as ATA_AD, i.gender_id GENDER, dp.edu_type_id, dp.haz_var, " +
                             "dp.edu_level, dp.edu_lang, i.pay_as_foregner, i.country_id, (select d.title_" + lang + " from " +
                             "dbmaster.departments d where d.dep_code = dp.dep_code_f and d.son = 1) as fac, dp.title_" + lang + " AS DEP, u.year, l.interface_lang_title_az, " +
                             "l.interface_lang_title_tr, l.interface_lang_title_en, to_char(i.year)||'-'||to_char(i.year + 1) as TEDRIS_QEBUL "+
                             "from dbmaster.students s left outer join dbmaster.stud_info i on i.stud_id = s.stud_id " +
                             "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                             "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                             "left join dbmaster.parent_info p on p.parent_type_id = 1 and p.stud_id = s.stud_id "+
                             "left join dbmaster.interface_lang l on l.interface_lang_id = 575 "+
                             "left join studinfoman.stud_action_used u on u.stud_id = s.stud_id and u.son = 1 and u.is_active = 1 and u.action_id = 8 "+
                             "where dp.prog_type = 'M' and s.stud_id = :stud_id";

                OracleParameter[] prms = { 
                           con.SetParameter("stud_id", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID)
                                         };
                OracleDataReader dr = con.execSQL(sql, prms);
                if (dr.Read())
                {
                    string kurs = "", gender = "";
                    afac = dr["FAC"].ToString(); adep = dr["DEP"].ToString(); kurs = si.Kurs.ToString();

                    string hazTitle = rbAZ.Checked ? dr["INTERFACE_LANG_TITLE_AZ"].ToString() : (rbTR.Checked ? dr["INTERFACE_LANG_TITLE_TR"].ToString() : dr["INTERFACE_LANG_TITLE_EN"].ToString());
                    /*
                    if (dr["EDU_LEVEL"].ToString() == "B")
                    {
                        if (dr["TQDK"].ToString() == "0")
                        {
                            if (si.Kurs == 0)
                            {
                                kurs = hazTitle;
                            }
                            else
                            {
                                kurs = si.Kurs.ToString();
                            }
                        }
                        else
                        {
                            //TQDK ise
                            if (dr["HAZ_VAR"].ToString() == "1" || int.Parse(si.year) < 2010)
                            {
                                kurs = (si.Kurs + 1).ToString();
                            }
                            else
                            {
                                kurs = si.Kurs.ToString();
                            }
                        }
                        if (kurs == "6")
                        {
                            kurs = "5";
                        }
                    }
                    else */
                    kurs = si.Kurs.ToString();

                    if (rbAZ.Checked)
                    {
                        kurs = kurs + "-" + f.getCiCu(kurs);
                        if (dr["GENDER"].ToString() == "2") gender = "oğluna"; else gender = "qızına";
                        if (dr["EDU_LEVEL"].ToString() == "B") afac = afac + " fakultəsi"; else afac = afac + " şöbəsi";                        
                    }
                    
                    if (rbTR.Checked) 
                    {
                        if (dr["GENDER"].ToString() == "2") gender = "oğlu"; else gender = "kızı";
                        if (kurs.Length == 1) kurs = kurs + ".";                                                
                    }

                    if (rbEN.Checked) gender = "";                    

                    txtKurs.Text = kurs;
                    txtGender.Text = gender;
                    txtAtaAd.Text = dr["ATA_AD"].ToString();                    
                    txttedris_il.Text = dr["TEDRIS_QEBUL"].ToString();                    
                    txtedu_type.Text =  (dr["EDU_TYPE_ID"].ToString() == "1") ? "əyani" : "qiyabi";  
                    
                    ISTIQAMET = dr["ISTIQAMET"].ToString();                    
                    
                    if (dr["YEAR"].ToString().Length > 0) tehmuddeti = Convert.ToInt32(dr["YEAR"]);
                    else
                    {
                        if (dr["EDU_LEVEL"].ToString() == "B") tehmuddeti = f.GetCfgActVal("CARI_IL_SEM")[0] + (5 - si.Kurs);
                        else tehmuddeti = f.GetCfgActVal("CARI_IL_SEM")[0] + (2 - si.Kurs);                        
                    }
                }
                if (!dr.IsClosed) dr.Close();
            }
            catch (Exception oe) { MessageBox.Show(oe.Message); }
        }

        private void btnArayis_Click(object sender, EventArgs e)
        {
            if (si.StudID.Length != 9) 
            {
                MessageBox.Show("Tələbə seçin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((oldstud_id != "") && oldstud_id != si.StudID)
            {
                MessageBox.Show("Yeni tələbə seçdiyiniz üçün məlumat dəyişəcək", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadArayisInfo();
            }

            try
            {
                string filename = "", status = string.Empty;
                string TedrisMudir = "", today = "", sql = string.Empty, vezife = string.Empty;
                sql = "select (select i.interface_lang_title_" + lang + " from dbmaster.interface_lang i where i.interface_lang_id = decode(dp.edu_level, 'B', 463, 365)) as vezife, " +
                      "decode(dp.edu_level, 'B', (select dbmaster.getempfullname(eg.emp_id, '" + lang + "') from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id " +
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = '20130' and eg.gorev_id = 25 and eg.esas_gorev = 1), " +
                      "(select dbmaster.getempfullname(eg.emp_id, '" + lang + "') from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id " +
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = 'F_GRAD_ST' and eg.gorev_id = 25 and eg.esas_gorev = 1) ) as mudir, " +
                      "to_char(sysdate, 'dd.mm.YYYY') as today, s.status from dbmaster.students s left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id " +
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' " +
                      "where  dp.prog_type = 'M' and s.stud_id ='" + si.StudID + "'";

                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read()) 
                {
                    status = dr["STATUS"].ToString();                    
                    TedrisMudir = dr["MUDIR"].ToString();
                    vezife = dr["VEZIFE"].ToString();
                    today = dr["TODAY"].ToString(); 
                }
                dr.Close();
                if ((status!= "1") && (MessageBox.Show("Tələbənin statusu OXUYUR DEYİL!\nDavam etmək istədiyinizdən əminsiniz", "DİQQƏT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)) return;
                
                if (rbAZ.Checked) filename = "reports/arayis_az.frx";
                else if (rbTR.Checked) filename = "reports/arayis_tr.frx";
                else if (rbEN.Checked) filename = "reports/arayis_en.frx";

                // Call this before loading your report 
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_print.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;
                
                rArayis = new FastReport.Report();
                rArayis.Load(filename);
                
                if (rbEN.Checked) rArayis.SetParameterValue("stud_id", si.StudID);
                rArayis.SetParameterValue("Fullname", si.SName + " " + si.SSName);
                rArayis.SetParameterValue("ata_ad", txtAtaAd.Text);
                if (!rbEN.Checked) rArayis.SetParameterValue("gender", txtGender.Text);
                rArayis.SetParameterValue("tedris_il", txttedris_il.Text);
                rArayis.SetParameterValue("fac", afac);
                rArayis.SetParameterValue("dep", adep);
                if (rbAZ.Checked) rArayis.SetParameterValue("edu_type", txtedu_type.Text);
                rArayis.SetParameterValue("kurs", txtKurs.Text);
                rArayis.SetParameterValue("mudir", TedrisMudir);
                rArayis.SetParameterValue("vezife", vezife);
                rArayis.SetParameterValue("today", today);
                rArayis.Show(); oldstud_id = si.StudID;
                if (checkEdit_print.Checked && MessageBox.Show(btnArayis.Text + ", printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 16 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                          "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 16, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(sql);

                    sql = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 16 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                    dr = con.execSQL(sql);
                    if (dr.Read())
                    {
                        OracleParameter[] prm = { con.SetParameter("sdid", OracleDbType.Int32, 9, ParameterDirection.Input, dr["SD_ID"]) };
                        con.ExecSProcRetVal("DOCS_PRINT_LOG", prm);
                    }
                    dr.Close();
                    spinEdit_print.Value++; spinEdit_print.Properties.MaxValue++;
                    spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
                    spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);
                }
            }
            catch (Exception) { }
        }

        private void rbAZ_CheckedChanged(object sender, EventArgs e)
        {
            lang = rbAZ.Checked ? "az" : rbTR.Checked ? "tr" : rbEN.Checked ? "en" : "az";
            LoadArayisInfo();
        }

        private void btnMezun_Click(object sender, EventArgs e)
        {            
            if (si.StudID.Length != 9)
            {
                MessageBox.Show("Tələbə seçin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((oldstud_id != "") && oldstud_id != si.StudID)
            {
                MessageBox.Show("Yeni tələbə seçdiyiniz üçün məlumat dəyişəcək", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadArayisInfo();
            }

            try
            {
                string TedrisMudir = "", today = "", sql = string.Empty, vezife = string.Empty, status = string.Empty;
                sql = "select (select i.interface_lang_title_" + lang + " from dbmaster.interface_lang i  where i.interface_lang_id =  decode(dp.edu_level, 'B', 329, 'M', 330, 369)) as EDU_LEVEL," +
                      "(select i.interface_lang_title_" + lang + " from dbmaster.interface_lang i where i.interface_lang_id = decode(dp.edu_level, 'B', 463, 365)) as vezife, " +
                      "decode(dp.edu_level, 'B', (select dbmaster.getempfullname(eg.emp_id, '" + lang + "') from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id " +
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = '20130' and eg.gorev_id = 25 and eg.esas_gorev = 1), " +
                      "(select dbmaster.getempfullname(eg.emp_id, '" + lang + "') from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id " +
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = 'F_GRAD_ST' and eg.gorev_id = 25 and eg.esas_gorev = 1) ) as mudir," +
                      "to_char(sysdate, 'dd.mm.YYYY') as today, s.status from dbmaster.students s left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id " +
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' " +
                      "where  dp.prog_type = 'M' and s.stud_id ='" + si.StudID + "'";

                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read())
                {                    
                    today = dr["TODAY"].ToString();
                    status = dr["STATUS"].ToString();
                    vezife = dr["VEZIFE"].ToString();
                    TedrisMudir = dr["MUDIR"].ToString();
                    edu_level = dr["EDU_LEVEL"].ToString();
                }
                dr.Close();
                if ((status != "1") && (MessageBox.Show("Tələbənin statusu OXUYUR DEYİL!\nDavam etmək istıdiyinizdən əminsiniz", "DİQQƏT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)) return;
                
                // Call this before loading your report 
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_mezun.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;

                rArayisMezun = new FastReport.Report();
                rArayisMezun.Load("reports/arayis_mezun.frx");
                rArayisMezun.SetParameterValue("Fullname", si.SName + " " + si.SSName + " " + txtAtaAd.Text + " " + txtGender.Text);
                rArayisMezun.SetParameterValue("teh_mud", tehmuddeti.ToString() + "-" + (tehmuddeti+1).ToString());
                rArayisMezun.SetParameterValue("fac", afac);
                rArayisMezun.SetParameterValue("dep", adep);
                rArayisMezun.SetParameterValue("ISTIQAMET", ISTIQAMET); 
                rArayisMezun.SetParameterValue("edu_type", txtedu_type.Text);
                rArayisMezun.SetParameterValue("edu_level", edu_level.ToLower());
                rArayisMezun.SetParameterValue("mudir", TedrisMudir);
                rArayisMezun.SetParameterValue("vezife", vezife);
                rArayisMezun.SetParameterValue("today", today);
                rArayisMezun.Show(); oldstud_id = si.StudID;
                if (checkEdit_mezun.Checked && MessageBox.Show(btnMezun.Text + ", printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 17 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                          "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 17, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(sql);

                    sql = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 17 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                    dr = con.execSQL(sql);
                    if (dr.Read())
                    {
                        OracleParameter[] prm = { con.SetParameter("sdid", OracleDbType.Int32, 9, ParameterDirection.Input, dr["SD_ID"]) };
                        con.ExecSProcRetVal("DOCS_PRINT_LOG", prm);
                    }
                    dr.Close();
                    spinEdit_mezun.Value++; spinEdit_mezun.Properties.MaxValue++;
                    spinEdit_mezun.Properties.Buttons[1].Enabled = (spinEdit_mezun.Value < spinEdit_mezun.Properties.MaxValue);
                    spinEdit_mezun.Properties.Buttons[2].Enabled = (spinEdit_mezun.Value > spinEdit_mezun.Properties.MinValue);
                }
            }
            catch (OracleException oe) { MessageBox.Show(oe.Message); }
        }

        private void frmArayis_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void frmArayis_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "TƏLƏBƏ MƏLUMAT SİSTEMİ";
        }

        private void checkEdit_print_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit_print.Enabled = checkEdit_print.Checked;
        }

        private void checkEdit_mezun_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit_mezun.Enabled = checkEdit_mezun.Checked;
        }

        private void spinEdit_print_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string str_SQL = string.Empty;
            if (MessageBox.Show(si.StudID + " nömrəli tələbə üçün, printerdən çıxarılan " + btnArayis.Text + " sayısını dəyişmək istədiyinizdən əminsiniz?", "SAYI DƏYİŞDİRMƏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (e.Button.Index)
                {
                    case 1: spinEdit_print.Value++; break;
                    case 2: spinEdit_print.Value--; break;
                    default: break;
                }
                spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
                spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_print.Value + " where dc.doc_id = 16 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
        }

        private void spinEdit_mezun_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string str_SQL = string.Empty;
            if (MessageBox.Show(si.StudID + " nömrəli tələbə üçün, printerdən çıxarılan " + btnMezun.Text + " sayısını dəyişmək istədiyinizdən əminsiniz?", "SAYI DƏYİŞDİRMƏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (e.Button.Index)
                {
                    case 1: spinEdit_mezun.Value++; break;
                    case 2: spinEdit_mezun.Value--; break;
                    default: break;
                }
                spinEdit_mezun.Properties.Buttons[1].Enabled = (spinEdit_mezun.Value < spinEdit_mezun.Properties.MaxValue);
                spinEdit_mezun.Properties.Buttons[2].Enabled = (spinEdit_mezun.Value > spinEdit_mezun.Properties.MinValue);

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_mezun.Value + " where dc.doc_id = 16 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
        }
    }
}
