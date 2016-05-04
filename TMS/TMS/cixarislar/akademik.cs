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
    public partial class akademik : Form
    {
        General.functions f = new General.functions();
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        string studid = "";
        
        public akademik()
        {
            InitializeComponent();
        }

        public akademik(string _studid)
        {
            InitializeComponent();
            studid = _studid;
        }

        private void button_akademik_Click(object sender, EventArgs e)
        {
            try
            {
                // Call this before loading your report 
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_print.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;

                FastReport.Report diplom_elave = new FastReport.Report(); DataTable dt = new DataTable();
                diplom_elave.Load(Properties.Settings.Default.CurProgDir + "/reports/akademik.frx");
                diplom_elave.SetParameterValue("info.full_name", edit_fullname_az.Text);                
                diplom_elave.SetParameterValue("info.birth_date", edit_birthdate_az.Text);                
                diplom_elave.SetParameterValue("info.istiqamet", edit_istiqamet_az.Text);
                diplom_elave.SetParameterValue("info.attestat", edit_attestat_az.Text);                
                diplom_elave.SetParameterValue("info.entry_year", edit_entryyear_az.Text);
                diplom_elave.SetParameterValue("info.1", edit_qeydiyyatno_az.Text);
                diplom_elave.SetParameterValue("info.2", edit_givendate_az.Text);
                diplom_elave.SetParameterValue("info.3", edit_info3_az.Text);
                diplom_elave.SetParameterValue("info.4", edit_info4_az.Text);
                diplom_elave.SetParameterValue("info.5", edit_enddate_az.Text);
                diplom_elave.SetParameterValue("info.6", edit_duration_az.Text);
                diplom_elave.SetParameterValue("info.7", edit_ixtisas_az.Text);

                string str_SQL = "select * from(select row_number() over (order by NLSSORT(t.D_AD_AZ, 'NLS_SORT=AZERBAIJANI')) as rn, t.* from v_diplom_arasi t where t.stud_id = :stud_id) where rn > 0 and rn <= 72";
                OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, studid) };
                dt = con.GetDataTable(str_SQL, prms); int count = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        diplom_elave.SetParameterValue("qiymet." + (i + 1), dt.Rows[i]["BAS_AZ"].ToString());
                        diplom_elave.SetParameterValue("umumi." + (i + 1), dt.Rows[i]["UMUMI"].ToString());
                        diplom_elave.SetParameterValue("title." + (i + 1), dt.Rows[i]["D_AD_AZ"].ToString());
                        diplom_elave.SetParameterValue("auditoriya." + (i + 1), dt.Rows[i]["AUDOT"].ToString());
                    }
                    str_SQL = "select * from(select row_number() over (order by NLSSORT(t.D_AD_AZ, 'NLS_SORT=AZERBAIJANI')) as rn, t.* from v_diplom_arasi t where t.stud_id = '" + studid + "') where rn > 72 and rn <= 104";
                    dt = con.GetDataTable(str_SQL);
                    if (dt.Rows.Count > 0)
                    {
                        count = dt.Rows.Count + 75;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            diplom_elave.SetParameterValue("qiymet." + (i + 73), dt.Rows[i]["BAS_AZ"].ToString());
                            diplom_elave.SetParameterValue("umumi." + (i + 73), dt.Rows[i]["UMUMI"].ToString());
                            diplom_elave.SetParameterValue("title." + (i + 73), dt.Rows[i]["D_AD_AZ"].ToString());
                            diplom_elave.SetParameterValue("auditoriya." + (i + 73), dt.Rows[i]["AUDOT"].ToString());
                        }
                    }
                    else count = count + 2;
                    diplom_elave.SetParameterValue("title." + count, "<b><i><u>SƏNƏDİN SONU</u></i></b>");  
                } 
                diplom_elave.Show(); diplom_elave.Dispose();
                if (checkEdit_print.Checked && MessageBox.Show("AKADEMİK ARAYIŞ, printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    str_SQL = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 14 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                              "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 14, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(str_SQL);

                    str_SQL = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 14 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                    OracleDataReader dr = con.execSQL(str_SQL);
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void akademik_Load(object sender, EventArgs e)
        {
            string str_SQL = "select * from v_diplomarasi_bilgi t where t.stud_id = :stud_id";
            OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, studid) };
            OracleDataReader dr = con.execSQL(str_SQL, prms);
            if (dr.Read())
            {
                edit_fullname_az.Text = String.Format("{0} {1}", dr["FULLNAME"], dr["PARENT_INFO_NAME"]);                
                edit_birthdate_az.Text = dr["BDATE"].ToString();
                edit_attestat_az.Text = dr["ATTESTAT"].ToString();                
                edit_entryyear_az.Text = dr["ENT_DATE"].ToString();
                edit_istiqamet_az.Text = String.Format("{0} / {1}", dr["ISTIQAMET"], dr["IXTISAS"]);
                edit_ixtisas_az.Text = dr["IXTISAS"].ToString();
            }
            dr.Close();

            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 14 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();

            dr = con.execSQL(str_SQL); bool ok = dr.Read();
            spinEdit_print.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_print.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
            spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);
        }

        private void akademik_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void akademik_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "TƏLƏBƏ MƏLUMAT SİSTEMİ";
        }

        private void checkEdit_print_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit_print.Enabled = checkEdit_print.Checked;
        }

        private void spinEdit_print_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string str_SQL = string.Empty;
            if (MessageBox.Show(si.StudID + " nömrəli tələbə üçün, printerdən çıxarılan AKADEMİK ARAYIŞ sayısını dəyişmək istədiyinizdən əminsiniz?", "SAYI DƏYİŞDİRMƏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (e.Button.Index)
                {
                    case 1: spinEdit_print.Value++; break;
                    case 2: spinEdit_print.Value--; break;
                    default: break;
                }
                spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
                spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_print.Value + " where dc.doc_id = 14 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
        }
    }
}
