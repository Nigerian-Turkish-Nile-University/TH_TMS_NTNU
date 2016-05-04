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
    public partial class magistr : Form
    {
        General.functions f = new General.functions();
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        string studid = "";
        public magistr()
        {
            InitializeComponent();
        }
        public magistr(string _studid)
        {
            InitializeComponent();
            studid = _studid;
        }

        private void magistr_Load(object sender, EventArgs e)
        {
            pages_SelectedPageChanged(sender, null);
            string str_SQL = "select * from view_master_diploma t where t.stud_id = :stud_id";
            OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, studid) };
            OracleDataReader dr = con.execSQL(str_SQL, prms);
            if (dr.Read())
            {   
                edit_parentname_az.Text = String.Format("{0} {1}", dr["PARENT_INFO_NAME"].ToString(), (dr["GENDER_ID"].ToString() == "1") ? "qızı" : "oğlu");
                edit_info6_az.Text = edit_derece5_az.Text = edit_info_33.Text = edit_ixtisas_az.Text = edit_ixtisas_en.Text = dr["IXTISAS"].ToString();
                edit_diplom_az.Text = edit_diplom_en.Text = dr["DIPLOM_NO"].ToString() + ", " + dr["DIPLOM_DATE"].ToString();                
                edit_graduate_date_az.Text = edit_info4_en.Text = dr["GRAD_DATE"].ToString();
                edit_fullname_az.Text = edit_fullname_en.Text = dr["FULLNAME"].ToString();
                edit_birthdate_az.Text = edit_birthdate_en.Text = dr["BDATE"].ToString();
                edit_info16_az.Text = edit_info_20.Text = dr["THESIS_SCORE"].ToString();
                edit_entrydate_az.Text = edit_entrydate_en.Text = dr["YEAR"].ToString();                
                edit_info3_az.Text = edit_info_3.Text = dr["GRADUATED_DEP"].ToString();
                edit_istiqamet_az.Text = edit_derece2_az.Text = edit_info_9.Text = dr["ISTIQAMET"].ToString();
                edit_duration_az.Text = edit_info_7.Text = dr["DURATION"].ToString();                
                edit_info12_az.Text = edit_info_16.Text = dr["THESIS"].ToString();       

                edit_parentname_en.Text = dr["PARENT_INFO_NAME"].ToString();                 
                edit_info_8.Text = edit_istiqamet_az.Text;                          
            }
            dr.Close();
            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 20 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();

            dr = con.execSQL(str_SQL); bool ok = dr.Read();
            spinEdit_print.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_print.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
            spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);
        }

        private void button_magistr_az_Click(object sender, EventArgs e)
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
                diplom_elave.Load(Properties.Settings.Default.CurProgDir + "/reports/magistr_az.frx");
                diplom_elave.SetParameterValue("info.full_name", edit_fullname_az.Text);
                diplom_elave.SetParameterValue("info.parent_name", edit_parentname_az.Text);
                diplom_elave.SetParameterValue("info.diplom", edit_diplom_az.Text);
                diplom_elave.SetParameterValue("info.diplomno", edit_diplomno_az.Text);
                diplom_elave.SetParameterValue("info.department", edit_derece2_az.Text);
                diplom_elave.SetParameterValue("info.istiqamet", edit_istiqamet_az.Text);
                diplom_elave.SetParameterValue("info.birth_date", edit_birthdate_az.Text);                
                diplom_elave.SetParameterValue("info.entry_date", edit_entrydate_az.Text);
                diplom_elave.SetParameterValue("info.graduate_date", edit_graduate_date_az.Text);
                diplom_elave.SetParameterValue("info.universityname", edit_universityname_az.Text);
                diplom_elave.SetParameterValue("info.universityname2", edit_universityname2_az.Text);
                diplom_elave.SetParameterValue("info.university1", edit_university1_az.Text);
                diplom_elave.SetParameterValue("info.university2", edit_university2_az.Text);
                diplom_elave.SetParameterValue("info.university4", edit_university4_az.Text);
                diplom_elave.SetParameterValue("info.university5", edit_university5_az.Text);
                diplom_elave.SetParameterValue("info.university6", edit_university6_az.Text);                
                diplom_elave.SetParameterValue("info.duration", edit_duration_az.Text);
                diplom_elave.SetParameterValue("info.ixtisas", edit_ixtisas_az.Text);
                diplom_elave.SetParameterValue("info.qeydiyyatno1", edit_qeydiyyatno1_az.Text);
                diplom_elave.SetParameterValue("info.qeydiyyatno2", edit_qeydiyyatno2_az.Text);
                diplom_elave.SetParameterValue("info.givendate", edit_givendate_az.Text);
                diplom_elave.SetParameterValue("info.qerar", edit_qerar_az.Text);
                diplom_elave.SetParameterValue("info.tarix", edit_tarix_az.Text);
                diplom_elave.SetParameterValue("info.sifr", edit_sifr_az.Text);
                diplom_elave.SetParameterValue("info.derece1", edit_derece1_az.Text);
                diplom_elave.SetParameterValue("info.derece2", edit_derece2_az.Text);
                diplom_elave.SetParameterValue("info.derece3", edit_derece3_az.Text);
                diplom_elave.SetParameterValue("info.derece4", edit_derece4_az.Text);
                diplom_elave.SetParameterValue("info.derece5", edit_derece5_az.Text);
                diplom_elave.SetParameterValue("info.derece6", edit_derece6_az.Text);

                diplom_elave.SetParameterValue("info.1", edit_info1_az.Text);
                //diplom_elave.SetParameterValue("info.2", edit_ixtisas_az.Text);
                diplom_elave.SetParameterValue("info.3", edit_info3_az.Text);
                diplom_elave.SetParameterValue("info.4", edit_info4_az.Text);
                diplom_elave.SetParameterValue("info.5", edit_info5_az.Text);
                diplom_elave.SetParameterValue("info.6", edit_info6_az.Text);
                diplom_elave.SetParameterValue("info.7", edit_info7_az.Text);
                diplom_elave.SetParameterValue("info.8", edit_info8_az.Text);
                diplom_elave.SetParameterValue("info.9", edit_info9_az.Text);
                diplom_elave.SetParameterValue("info.10", edit_info10_az.Text);
                diplom_elave.SetParameterValue("info.11", edit_info11_az.Text);
                diplom_elave.SetParameterValue("info.12", edit_info12_az.Text);
                diplom_elave.SetParameterValue("info.13", edit_info13_az.Text);
                diplom_elave.SetParameterValue("info.14", edit_info14_az.Text);
                diplom_elave.SetParameterValue("info.15", edit_info15_az.Text);
                diplom_elave.SetParameterValue("info.16", edit_info16_az.Text);
                diplom_elave.SetParameterValue("info.17", edit_info17_az.Text);

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
                    else count = count + 1;
                    diplom_elave.SetParameterValue("title." + count, "<b><u>SƏNƏDİN SONU</u></b>");
                }
                diplom_elave.Show(); diplom_elave.Dispose();
                if (checkEdit_print.Checked && MessageBox.Show(this.Text + ", printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    str_SQL = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 20 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                              "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 20, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(str_SQL);

                    str_SQL = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 20 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
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

        private void button_bakalavr_en_Click(object sender, EventArgs e)
        {
            try
            {
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_print.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;
                
                FastReport.Report diplom_elave = new FastReport.Report(); DataTable dt = new DataTable();
                diplom_elave.Load(Properties.Settings.Default.CurProgDir + "/reports/magistr_en.frx");
                diplom_elave.SetParameterValue("info.full_name", edit_fullname_en.Text);
                diplom_elave.SetParameterValue("info.parent_name", edit_parentname_en.Text);                
                diplom_elave.SetParameterValue("info.birth_date", edit_birthdate_en.Text);
                diplom_elave.SetParameterValue("info.diplom", edit_diplom_en.Text);                
                diplom_elave.SetParameterValue("info.entry_year", edit_entrydate_en.Text);
                diplom_elave.SetParameterValue("info.ixtisas", edit_ixtisas_en.Text);

                diplom_elave.SetParameterValue("info.1", edit_info1_en.Text);                
                diplom_elave.SetParameterValue("info.2", edit_info4_en.Text);
                diplom_elave.SetParameterValue("info.3", edit_info_3.Text);
                diplom_elave.SetParameterValue("info.4", edit_info_4.Text);
                diplom_elave.SetParameterValue("info.5", edit_info_5.Text);
                diplom_elave.SetParameterValue("info.6", edit_info_6.Text);
                diplom_elave.SetParameterValue("info.7", edit_info_7.Text);
                diplom_elave.SetParameterValue("info.8", edit_info_8.Text);
                diplom_elave.SetParameterValue("info.9", edit_info_9.Text);
                diplom_elave.SetParameterValue("info.10", edit_info_10.Text);
                diplom_elave.SetParameterValue("info.11", edit_info_11.Text);
                diplom_elave.SetParameterValue("info.12", edit_info_12.Text);
                diplom_elave.SetParameterValue("info.13", edit_info_13.Text);
                diplom_elave.SetParameterValue("info.14", edit_info_14.Text);
                diplom_elave.SetParameterValue("info.15", edit_info_15.Text);
                diplom_elave.SetParameterValue("info.16", edit_info_16.Text);
                diplom_elave.SetParameterValue("info.17", edit_info_17.Text);
                diplom_elave.SetParameterValue("info.18", edit_info_18.Text);
                diplom_elave.SetParameterValue("info.19", edit_info_19.Text);
                diplom_elave.SetParameterValue("info.20", edit_info_20.Text);
                diplom_elave.SetParameterValue("info.21", edit_info_21.Text);
                diplom_elave.SetParameterValue("info.22", edit_info_22.Text);
                diplom_elave.SetParameterValue("info.23", edit_info_23.Text);
                diplom_elave.SetParameterValue("info.24", edit_info_24.Text);
                diplom_elave.SetParameterValue("info.25", edit_info_25.Text);
                diplom_elave.SetParameterValue("info.26", edit_info_26.Text);
                diplom_elave.SetParameterValue("info.27", edit_info_27.Text);
                diplom_elave.SetParameterValue("info.28", edit_info_28.Text);
                diplom_elave.SetParameterValue("info.29", edit_info_29.Text);
                diplom_elave.SetParameterValue("info.30", edit_info_30.Text);
                diplom_elave.SetParameterValue("info.31", edit_info_31.Text);
                diplom_elave.SetParameterValue("info.32", edit_info_32.Text);
                diplom_elave.SetParameterValue("info.33", edit_info_33.Text);
                diplom_elave.SetParameterValue("info.34", edit_info_34.Text);

                string str_SQL = "select * from(select row_number() over (order by NLSSORT(t.D_AD_EN, 'NLS_SORT=AZERBAIJANI')) as rn, t.* from v_diplom_arasi t where t.stud_id = :stud_id) where rn > 0 and rn <= 72";
                OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, studid) };
                dt = con.GetDataTable(str_SQL, prms); int count = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        diplom_elave.SetParameterValue("qiymet." + (i + 1), dt.Rows[i]["BAS_EN"].ToString());
                        diplom_elave.SetParameterValue("umumi." + (i + 1), dt.Rows[i]["UMUMI"].ToString());
                        diplom_elave.SetParameterValue("title." + (i + 1), dt.Rows[i]["D_AD_EN"].ToString());
                        diplom_elave.SetParameterValue("auditoriya." + (i + 1), dt.Rows[i]["AUDOT"].ToString());
                    }
                    str_SQL = "select * from(select row_number() over (order by NLSSORT(t.D_AD_EN, 'NLS_SORT=AZERBAIJANI')) as rn, t.* from v_diplom_arasi t where t.stud_id = '" + studid + "') where rn > 72 and rn <= 104";
                    dt = con.GetDataTable(str_SQL);
                    if (dt.Rows.Count > 0)
                    {
                        count = dt.Rows.Count + 75;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            diplom_elave.SetParameterValue("qiymet." + (i + 73), dt.Rows[i]["BAS_EN"].ToString());
                            diplom_elave.SetParameterValue("umumi." + (i + 73), dt.Rows[i]["UMUMI"].ToString());
                            diplom_elave.SetParameterValue("title." + (i + 73), dt.Rows[i]["D_AD_EN"].ToString());
                            diplom_elave.SetParameterValue("auditoriya." + (i + 73), dt.Rows[i]["AUDOT"].ToString());
                        }
                    }
                    else count = count + 1;
                    diplom_elave.SetParameterValue("title." + count, "<b><u>END OF DOCUMENT</u></b>");
                }
                diplom_elave.Show(); diplom_elave.Dispose();
                if (checkEdit_print.Checked && MessageBox.Show(this.Text + ", printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    str_SQL = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 20 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                              "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 20, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(str_SQL);

                    str_SQL = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 20 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
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

        private void pages_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            string str_SQL = "";
            if (pages.SelectedTabPageIndex < 2)
            {
                grid_courses.DataSource = null; view_courses.Columns.Clear(); button_excel.Parent = pages.SelectedTabPage;
                str_SQL = "select t.d_ad_" + pages.SelectedTabPage.Text + " as DƏRS, t.umumi, t.audot as auditoriya, t.bas_" + pages.SelectedTabPage.Text +
                          " as yekun from v_diplom_arasi t where t.stud_id = " + studid + " order by NLSSORT(t.D_AD_" + pages.SelectedTabPage.Text + ", 'NLS_SORT=AZERBAIJANI')";
                grid_courses.DataSource = con.GetDataTable(str_SQL);
            }
            button_excel.Enabled = (view_courses.RowCount > 0);
            checkEdit_print.Parent = pages.SelectedTabPage;
            spinEdit_print.Parent = pages.SelectedTabPage;
        }

        private void button_excel_Click(object sender, EventArgs e)
        {
            saveFile_excel.Filter = "Excel files (*.xls)|*.xls";
            if (saveFile_excel.ShowDialog() == DialogResult.OK) view_courses.ExportToExcelOld(saveFile_excel.FileName);
        }

        private void magistr_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void magistr_FormClosed(object sender, FormClosedEventArgs e)
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
            if (MessageBox.Show(si.StudID + " nömrəli tələbə üçün, printerdən çıxarılan " + this.Text + " sayısını dəyişmək istədiyinizdən əminsiniz?", "SAYI DƏYİŞDİRMƏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (e.Button.Index)
                {
                    case 1: spinEdit_print.Value++; break;
                    case 2: spinEdit_print.Value--; break;
                    default: break;
                }
                spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
                spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_print.Value + " where dc.doc_id = 20 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
        }
    }
}
