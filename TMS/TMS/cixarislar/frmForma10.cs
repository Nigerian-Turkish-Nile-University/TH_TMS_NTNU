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
    public partial class frmForma10 : Form
    {
        string oldstud_id = "";
        oraConn con = oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        General.functions f = new General.functions();
        private FastReport.Report rForma10;
        //private FastReport.Report rArayisHk;
        public frmForma10()
        {
            InitializeComponent();
        }

        private void frmForma10_Load(object sender, EventArgs e)
        {
            getForma10_data();
            string str_SQL = string.Empty;
            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 19 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();

            OracleDataReader dr = con.execSQL(str_SQL); bool ok = dr.Read();
            spinEdit_print.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_print.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
            spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);

            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 18 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();

            dr = con.execSQL(str_SQL); ok = dr.Read();
            spinEdit_forma10.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_forma10.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_forma10.Properties.Buttons[1].Enabled = (spinEdit_forma10.Value < spinEdit_forma10.Properties.MaxValue);
            spinEdit_forma10.Properties.Buttons[2].Enabled = (spinEdit_forma10.Value > spinEdit_forma10.Properties.MinValue);
        }

        private void getForma10_data()
        {
            if (si.StudID.Length != 9) return;
            string str_SQL = string.Empty;
            try
            {
                str_SQL = "select v.*, dp.title_az as dep, (select count(*) from stud_action_used u where u.stud_id = v.stud_id and u.is_active = 1 and u.action_id in (2,11)) as elave, i.year, s.status, " +                          " " +
                          "nvl((select case when to_char(au.action_date, 'yyyy') - to_char(u.action_date, 'yyyy') > 0 then to_char(au.action_date, 'yyyy') - to_char(u.action_date, 'yyyy') else 0 end " +                          
                          "from stud_action_used u left outer join stud_action_used au on au.stud_id = u.stud_id and au.is_active = 1 and au.action_id = 6 where exists "+
                          "(select * from stud_action a where a.stud_action_id = u.action_id and a.status_id = 2) and u.stud_id = v.stud_id), 0) as lost_years, dp.period_count, " +
                          "dp.period_count as ntm from v_forma10 v left join dbmaster.students s on s.stud_id = v.stud_id " +
                          "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                          "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                          "left outer join dbmaster.stud_info i on i.stud_id = v.stud_id "+
                          "where dp.prog_type = 'M' and v.stud_id = :stud_id";

                OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID) };
                OracleDataReader dr = con.execSQL(str_SQL, prms);
                if (dr.Read())
                {
                    txtbdate.Text = dr["TEVELLUD"].ToString();
                    txtAtaAd.Text = dr["ATA_AD"].ToString();
                    txtetn_year.Text = dr["DAXIL_OL_IL"].ToString();
                    edit_ixtisas.Text = dr["DEP"].ToString();
                    txtherbi_kom.Text = dr["ESGER_SOBE"].ToString();
                    if (dr["STATUS"].ToString() == "1") txtteh_mud.Text = ((Convert.ToInt16(f.GetCfgActVal("CARI_IL_SEM")[0]) + 1) + ((Convert.ToInt16(dr["PERIOD_COUNT"]) / 2) - si.Kurs)).ToString();
                    else txtteh_mud.Text = (Convert.ToInt16(dr["YEAR"]) + (Convert.ToInt16(dr["NTM"]) / 2) + Convert.ToInt16(dr["ELAVE"]) + Convert.ToInt16(dr["LOST_YEARS"])).ToString();                    
                }
                if (!dr.IsClosed) dr.Close();
            }
            catch (Exception) { }
        }

        private void btnForma10Print_Click(object sender, EventArgs e)
        {
            if (si.StudID.Length != 9)
            {
                MessageBox.Show("Tələbə seçin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((oldstud_id != "") && oldstud_id != si.StudID)
            {
                MessageBox.Show("Yeni tələbə seçdiyiniz üçün məlumat dəyişəcək", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getForma10_data();
            }

            try
            {
                string TedrisMudir = "", date = "", vezife = string.Empty, kurs = string.Empty, status = string.Empty;
                string sql = "SELECT TEDRIS_MUDIR AS TEDHIS, to_char(sysdate,'dd.mm.YYYY') as today FROM DUAL";

                sql = "select (select l.interface_lang_title_az from dbmaster.interface_lang l where l.interface_lang_id = 575) as hazirliq, dp.haz_var, " +  
                      "(select i.interface_lang_title_az from dbmaster.interface_lang i where i.interface_lang_id = decode(dp.edu_level, 'B', 463, 365)) as vezife, " +
                      "decode(dp.edu_level, 'B', tedris_mudir, (select dbmaster.getempfullname(eg.emp_id) from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id " +
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = 'F_GRAD_ST' and eg.gorev_id = 25 and eg.esas_gorev = 1) ) as TEDHIS, " +
                      "to_char(sysdate, 'dd.mm.YYYY') as today, s.status,dp.edu_level, dp.edu_lang as lang_code, si.country_id from dbmaster.students s left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id " +
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' " +                  
                      "left outer join dbmaster.stud_info si on si.stud_id = s.stud_id where  dp.prog_type = 'M' and s.stud_id = '" + si.StudID + "'";

                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read())
                {
                    TedrisMudir = dr["TEDHIS"].ToString();
                    status = dr["STATUS"].ToString();
                    vezife = dr["VEZIFE"].ToString();
                    date = dr["today"].ToString();                    
                    /*if (dr["EDU_LEVEL"].ToString() == "B" && (dr["COUNTRY_ID"].ToString() == "169" || dr["LANG_CODE"].ToString() == "AZ"))
                        kurs = (dr["COUNTRY_ID"].ToString() == "169") ? (si.Kurs == 1) ? dr["HAZIRLIQ"].ToString() : (si.Kurs - 1).ToString() : ((int.Parse(si.year) >= 2010) && (si.DepID != "10402")) ? (si.Kurs - 1).ToString() : si.Kurs.ToString();
                    else kurs = si.Kurs.ToString(); */

                    /*if (dr["EDU_LEVEL"].ToString() == "B")
                    {
                        if (dr["TQDK"].ToString() == "0")
                        {
                            if (si.Kurs == 0)
                            {
                                kurs = dr["HAZIRLIQ"].ToString();
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

                    kurs =  (dr["COUNTRY_ID"].ToString() == "169") && (si.Kurs == 1) ? kurs : kurs + "-" + f.getCiCu(kurs);
                }
                dr.Close();
                if ((status != "1") && (MessageBox.Show("Tələbənin statusu OXUYUR DEYİL!\nDavam etmək istıdiyinizdən əminsiniz", "DİQQƏT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)) return;
                
                // Call this before loading your report 
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_forma10.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;
                
                rForma10 = new FastReport.Report();
                rForma10.Load("reports/forma10.frx");
                rForma10.SetParameterValue("Fullname", si.SName + " " + si.SSName + " " + txtAtaAd.Text);
                rForma10.SetParameterValue("bdate", txtbdate.Text + "-" + f.getCiCu(txtbdate.Text));
                rForma10.SetParameterValue("etn_year", txtetn_year.Text + "-" + f.getCiCu(txtetn_year.Text));
                rForma10.SetParameterValue("dep", edit_ixtisas.Text);
                rForma10.SetParameterValue("kurs", kurs);
                rForma10.SetParameterValue("teh_mud", txtteh_mud.Text);
                rForma10.SetParameterValue("herbi_kom", txtherbi_kom.Text);
                rForma10.SetParameterValue("mudir", TedrisMudir);
                rForma10.SetParameterValue("vezife", vezife);
                rForma10.SetParameterValue("today", date);
                rForma10.Show(); oldstud_id = si.StudID;
                if (checkEdit_forma10.Checked && MessageBox.Show(btnForma10Print.Text + ", printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 18 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                          "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 18, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(sql);

                    sql = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 18 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                    dr = con.execSQL(sql);
                    if (dr.Read())
                    {
                        OracleParameter[] prm = { con.SetParameter("sdid", OracleDbType.Int32, 9, ParameterDirection.Input, dr["SD_ID"]) };
                        con.ExecSProcRetVal("DOCS_PRINT_LOG", prm);
                    }
                    dr.Close();
                    spinEdit_forma10.Value++; spinEdit_forma10.Properties.MaxValue++;
                    spinEdit_forma10.Properties.Buttons[1].Enabled = (spinEdit_forma10.Value < spinEdit_forma10.Properties.MaxValue);
                    spinEdit_forma10.Properties.Buttons[2].Enabled = (spinEdit_forma10.Value > spinEdit_forma10.Properties.MinValue);
                }
            }
            catch (Exception) { }
        }

        private void btnArayis_Click(object sender, EventArgs e)
        {
            if (si.StudID.Length != 9)
            {
                MessageBox.Show("Tələbə seçin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Call this before loading your report 
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_print.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;

                string vezife = string.Empty, sql = string.Empty;
                sql = "select (select i.interface_lang_title_az from dbmaster.interface_lang i where i.interface_lang_id =decode(dp.edu_level, 'B', 463, 365)) as vezife,"+
                      "decode(dp.edu_level, 'B', (select dbmaster.getempfullname(eg.emp_id) from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id "+
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = '20130' and eg.gorev_id = 25 and eg.esas_gorev = 1),"+
                      "(select trim((select d.degree_title_az from dbmaster.degree d where d.degree_id = e.degree_id) ||' '|| e.name ||' '|| e.sname) "+
                      "from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id "+
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = 'F_GRAD_ST' and eg.gorev_id = 25 and eg.esas_gorev = 1) )as TEDHIS, " +
                      "to_char(sysdate, 'dd.mm.YYYY') as today, to_char(u.action_date, 'dd.mm.YYYY') as act_date, sd.decision_no "+
                      "from  dbmaster.students s left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                      "left outer join stud_action_used u on u.stud_id = s.stud_id and u.is_active = 1 and u.action_id in(5, 16) "+
                      "left outer join stud_decision sd on sd.decision_id = u.decision_id where dp.prog_type = 'M' and s.stud_id = '" + si.StudID + "'";

                OracleDataReader dr = con.execSQL(sql);
                rForma10 = new FastReport.Report(); rForma10.Load("reports/ARAYIS_HK.frx");
                if (dr.Read())
                {   
                    rForma10.SetParameterValue("Fullname", si.SSName + " " + si.SName + " " + txtAtaAd.Text); 
                    rForma10.SetParameterValue("bdate", txtbdate.Text + "-" + f.getCiCu(txtbdate.Text));
                    rForma10.SetParameterValue("etn_year", txtetn_year.Text + "-" + f.getCiCu(txtetn_year.Text));
                    rForma10.SetParameterValue("fac", si.Fac); 
                    rForma10.SetParameterValue("dep", edit_ixtisas.Text);
                    rForma10.SetParameterValue("entry_year", txtetn_year.Text);
                    rForma10.SetParameterValue("herbi_kom", txtherbi_kom.Text);
                    rForma10.SetParameterValue("today", dr["today"].ToString());
                    rForma10.SetParameterValue("mudir", dr["TEDHIS"].ToString());
                    rForma10.SetParameterValue("vezife", dr["VEZIFE"].ToString());                    
                    rForma10.SetParameterValue("action_date", dr["act_date"].ToString());
                    rForma10.SetParameterValue("decision_no", dr["decision_no"].ToString());
                }
                dr.Close(); rForma10.Show();

                if (checkEdit_print.Checked && MessageBox.Show(btnArayis.Text + ", printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 19 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                          "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 19, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(sql);

                    sql = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 19 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
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

        private void frmForma10_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void frmForma10_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "TƏLƏBƏ MƏLUMAT SİSTEMİ";
        }

        private void checkEdit_print_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit_print.Enabled = checkEdit_print.Checked;
        }

        private void checkEdit_forma10_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit_forma10.Enabled = checkEdit_forma10.Checked;
        }

        private void spinEdit_forma10_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string str_SQL = string.Empty;
            if (MessageBox.Show(si.StudID + " nömrəli tələbə üçün, printerdən çıxarılan " + btnForma10Print.Text + " sayısını dəyişmək istədiyinizdən əminsiniz?", "SAYI DƏYİŞDİRMƏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (e.Button.Index)
                {
                    case 1: spinEdit_forma10.Value++; break;
                    case 2: spinEdit_forma10.Value--; break;
                    default: break;
                }
                spinEdit_forma10.Properties.Buttons[1].Enabled = (spinEdit_forma10.Value < spinEdit_forma10.Properties.MaxValue);
                spinEdit_forma10.Properties.Buttons[2].Enabled = (spinEdit_forma10.Value > spinEdit_forma10.Properties.MinValue);

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_forma10.Value + " where dc.doc_id = 18 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
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

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_print.Value + " where dc.doc_id = 19 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
        }
    }
}
