using System;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Globals;
using DB;
using System.Globalization;

namespace TMS.cixarislar
{
    public partial class fip : Form
    {
        General.functions f = new General.functions();
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        string studid = "";

        public fip()
        {
            InitializeComponent();
        }

        public fip(string _studid)
        {
            InitializeComponent();
            studid = _studid;
        }

        private void fip_Load(object sender, EventArgs e)
        {
            string str_SQL = "select * from dbmaster.view_fip_info t where t.stud_id = :stud_id";
            OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, studid) };
            OracleDataReader dr = con.execSQL(str_SQL, prms);
            if (dr.Read())
            {   
                edit_sobe.Text = dr["FAKULTE"].ToString();
                edit_imza_mudir.Text = dr["MUDIR"].ToString();
                edit_istiqamet.Text = dr["ISTIQAMET"].ToString();
                edit_bolme_rehberi.Text = dr["BOLME_MUDIRI"].ToString();
                edit_imza_telebe.Text = String.Format("{0} {1}", dr["NAME"], dr["SURNAME"]);
                edit_edu_years.Text = dr["YEAR"].ToString() + " - " + dr["END_YEAR"].ToString();
                edit_department.Text = edit_ixtisas.Text = edit_bolme.Text = dr["IXTISAS"].ToString();
                edit_fullname.Text = String.Format("{0} {1} {2} {3}", dr["NAME"], dr["ATA"], (dr["GENDER_ID"].ToString() == "1") ? "qızı" : "oğlu", dr["SURNAME"]);
            }
            dr.Close();

            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 21 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();

            dr = con.execSQL(str_SQL); bool ok = dr.Read();
            spinEdit_print.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_print.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
            spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);
        }

        private void checkEdit_print_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit_print.Enabled = checkEdit_print.Checked;
        }

        private void spinEdit_print_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string str_SQL = string.Empty;
            if (MessageBox.Show(si.StudID + " nömrəli tələbə üçün, printerdən çıxarılan FƏRDİ İŞ PLANI sayısını dəyişmək istədiyinizdən əminsiniz?", "SAYI DƏYİŞDİRMƏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (e.Button.Index)
                {
                    case 1: spinEdit_print.Value++; break;
                    case 2: spinEdit_print.Value--; break;
                    default: break;
                }
                spinEdit_print.Properties.Buttons[1].Enabled = (spinEdit_print.Value < spinEdit_print.Properties.MaxValue);
                spinEdit_print.Properties.Buttons[2].Enabled = (spinEdit_print.Value > spinEdit_print.Properties.MinValue);

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_print.Value + " where dc.doc_id = 21 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
        }

        private void button_fip_magistr_Click(object sender, EventArgs e)
        {
            string str_SQL = "";
            object Missing = System.Reflection.Missing.Value;
            try
            {
                Word.Document doc = new Word.Document();
                Word.Application app = new Word.Application();

                try
                {
                    object oTemplate = Properties.Settings.Default.CurProgDir + "\\fip.doc"; 
                    doc = app.Documents.Add(ref oTemplate, ref Missing, ref Missing, ref Missing);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.Settings.Default.CurProgDir + "\\reports\\fip.dot faylı açıla bilmədi. Faylın yerində olduğunu dəqiqləşdirin..! " + ex.Message.ToString());
                }

                app.Visible = true;
                bookmark(doc, edit_bolme_rehberi.Text, "bolme_rehberi");
                bookmark(doc, date_today.DateTime.Day.ToString(), "today_day");
                bookmark(doc, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date_today.DateTime.Month), "today_month");
                bookmark(doc, date_today.DateTime.Year.ToString(), "today_year");
                bookmark(doc, edit_fullname.Text, "student_fullname");
                bookmark(doc, edit_department.Text, "department");
                bookmark(doc, edit_supervisor.Text, "supervisor");                
                bookmark(doc, edit_edu_years.Text, "edu_years");
                bookmark(doc, edit_department.Text, "department");
                bookmark(doc, edit_istiqamet.Text, "istiqamet");
                bookmark(doc, edit_department.Text, "department");
                bookmark(doc, edit_ixtisas.Text, "ixtisas");
                bookmark(doc, edit_thesis.Text, "thesis");                
                bookmark(doc, edit_bolme.Text, "bolme", "insert");
                bookmark(doc, edit_protokol.Text, "protokol");
                bookmark(doc, date_protokol.DateTime.Day.ToString(), "protokol_date_day");
                bookmark(doc, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(date_protokol.DateTime.Month), "protokol_date_month");
                bookmark(doc, date_today.DateTime.Year.ToString(), "protokol_date_year");
                bookmark(doc, edit_muddet.Text, "muddet");
                bookmark(doc, edit_imza_telebe.Text, "imza_telebe");
                bookmark(doc, edit_imza_rehber.Text, "imza_rehber");
                bookmark(doc, edit_imza_mudir.Text, "imza_mudir");
                bookmark(doc, edit_bolme.Text, "bolum_ad");
                bookmark(doc, edit_supervisor.Text, "ett_rehber");
                bookmark(doc, edit_supervisor.Text, "ept_rehber");                

                str_SQL = "select m.period_no as term, d.ders_kod as ders_id, d.title_az as ders, da.qiymet_yuz as ort from dbmaster.ders_al_ref dr "+
                          "left join dbmaster.ders_al da on da.stud_id = dr.stud_id and da.ders_kod = dr.ders_kod and "+
                          "da.year = dr.year and da.term = dr.term  and da.section = dr.section left outer join dbmaster.mufredat m  on m.muf_id = dr.raw_muf_id "+
                          "left outer join dbmaster.ders d on d.ders_kod = m.ders_kod and d.year = m.year "+
                          "where m.period_no <= 4 and dr.son = 1 and dr.stud_id = '" + si.StudID + "' order by term";

                DataTable courses = new DataTable(); courses = con.GetDataTable(str_SQL);

                int term = 0, k = 1;
                Word.Tables tables = doc.Tables; 
                for (int j = 0; j < courses.Rows.Count; j++)
                {
                    if (term == Convert.ToInt16(courses.Rows[j]["TERM"])) { k++; tables[Convert.ToInt16(courses.Rows[j]["TERM"]) * 2].Rows.Add(ref Missing); }                    
                    else 
                    {
                        if (term > 0 && k > 1) tables[term * 2].Cell(3, 1).Merge(tables[term * 2].Cell(k + 3, 1)); // Merge ele
                        k = 1;                                                
                    }                    
                    tables[Convert.ToInt16(courses.Rows[j]["TERM"]) * 2].Cell(k + 3, 2).Range.Text = k.ToString() + " - " + courses.Rows[j]["DERS"].ToString();
                    tables[Convert.ToInt16(courses.Rows[j]["TERM"]) * 2].Cell(k + 3, 4).Range.Text = courses.Rows[j]["ORT"].ToString();
                    term = Convert.ToInt16(courses.Rows[j]["TERM"]); 
                }
                tables[term * 2].Cell(3, 1).Merge(tables[term * 2].Cell(k + 3, 1)); // Sonuncunu da merge ele     
                bookmark(doc, edit_bolme.Text, "break_1", "delete"); bookmark(doc, edit_bolme.Text, "break_2", "delete"); bookmark(doc, edit_bolme.Text, "break_3", "delete");
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);

                if (checkEdit_print.Checked && MessageBox.Show("FƏRDİ İŞ PLANI, printerdən çap edilmiş sayılsınmı?", "ÇIXARIŞ TƏSTİQİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    str_SQL = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 21 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                              "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 21, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(str_SQL);

                    str_SQL = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 21 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show("Sistemdə MS Word proqramının yüklü olduğunu dəqiqləşdirin..! " + ex.Message.ToString());
            }
        }
        
        private void bookmark(Word.Document bm_doc, string bm_text, string bm_name, string bm_type = "replace")
        {
            object bookmarkName = (object)bm_name; 
            Word.Range rng = bm_doc.Bookmarks.get_Item(ref bookmarkName).Range;
            switch (bm_type)
            {
                case "insert"   : rng.Text = bm_text; break;
                case "replace"  : rng.SetRange(bm_doc.Bookmarks.get_Item(ref bookmarkName).Start, bm_doc.Bookmarks.get_Item(ref bookmarkName).Start + bm_text.Length); rng.Text = bm_text; break;
                case "delete"   : rng.Delete(); break;
                default         : break;
            }
        }
    }
}
