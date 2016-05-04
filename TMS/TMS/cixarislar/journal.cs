using System;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DB;
using Globals;

namespace TMS.cixarislar
{
    public partial class journal : Form
    {
        General.functions f = new General.functions();
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        public journal()
        {
            InitializeComponent();
        }

        private void journal_Load(object sender, EventArgs e)
        {            
            string str_SQL = "";
            lookUp_year.EditValue = f.GetCfgActVal("DERS_QEYDIYYAT")[0].ToString();
            str_SQL = "select (level + 1993) as year, (level + 1993)||'-'||to_char(level + 1994) as il from dual connect by level <= (" + f.GetCfgActVal("DERS_QEYDIYYAT")[0].ToString() + " - 1993) order by 1 desc";
            con.load_lookUp(lookUp_year, str_SQL, "IL", "YEAR");

            lookUp_semester.EditValue = f.GetCfgActVal("DERS_QEYDIYYAT")[1].ToString();
            str_SQL = "select level||decode(level, 3, '. Summer School', '. Semester') as d, level as v from dual connect by level <= 3";
            con.load_lookUp(lookUp_semester, str_SQL, "D", "V");
        }

        private void button_courses_Click(object sender, EventArgs e)
        {
            string str_SQL = "";
            str_SQL = "select ds.ders_sobe_id, ds.ders_kod, d.title_en as title, d.k_teor || '+' || d.k_prat as kredit, d.k_ects, ds.section, dbmaster.getempfullname(ds.emp_id) as müəllim, " +
                      "ds.year, ds.term, ds.emp_id from dbmaster.ders_sobe ds left outer join dbmaster.ders d on d.ders_kod = ds.ders_kod and d.year = ds.year " +
                      "where ds.year = " + lookUp_year.EditValue.ToString() + " and ds.term = " + lookUp_semester.EditValue.ToString();
            if (browse_employee.Tag.ToString() != "") str_SQL = str_SQL + " and ds.emp_id = " + browse_employee.Tag.ToString(); //else str_SQL = str_SQL + " and ds.emp_id is NULL";
            str_SQL = str_SQL + " order by ds.ders_kod, ds.section";          
            grid_courses.DataSource = con.GetDataTable(str_SQL); view_courses.BestFitColumns();
            view_courses.Columns["EMP_ID"].Visible = false;
            view_courses.Columns["DERS_SOBE_ID"].Visible = false; 
            button_journal_all.Enabled = (view_courses.RowCount > 0);                       
            check_attendance.Properties.ReadOnly = (view_courses.RowCount == 0);            
            view_courses.Columns["SECTION"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view_courses.Columns["K_ECTS"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view_courses.Columns["KREDIT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void lookUp_class_EditValueChanged(object sender, EventArgs e)
        {
            button_courses.Enabled = (browse_employee.Tag.ToString().Length > 0);
        }

        private void check_attendance_CheckedChanged(object sender, EventArgs e)
        {
            string str_SQL = "";
            str_SQL = "select a.stud_id, s.name, s.surname, dp.title_en ||' - '|| dp.edu_lang as bölüm, s.class, case when exists(select * from dbmaster.ders_al_repeat r " + 
                      "where r.stud_id = dr.stud_id and r.prog_code = sp.prog_code and r.prog_year = sp.prog_year and r.new_ders_kod = dr.ders_kod and r.new_year = dr.year and r.new_term = dr.term) " +
                      "then 'TƏKRAR' else 'İLK' end as ALMA_DURUM from dbmaster.ders_al_ref dr left outer join dbmaster.students s on s.stud_id = dr.stud_id " +
                      "left outer join dbmaster.stud_prog sp on sp.stud_id = s.stud_id left outer join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' " +
                      "left outer join dbmaster.ders_al a on a.stud_id = dr.stud_id and a.ders_kod = dr.ders_kod and a.year = dr.year and a.term = dr.term and a.section = dr.section " +
                      "where dp.prog_type = 'M' and dr.son = 1 and ((dr.ders_kod = '" + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "DERS_KOD").ToString() + "' and " +
                      "dr.year = " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "YEAR").ToString() + " and " + 
                      "dr.term = " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "TERM").ToString() + " and " +
                      "dr.section = " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "SECTION").ToString() +
                      ") or a.lab_sobe_id = " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "DERS_SOBE_ID").ToString() + ")";
            if (!check_attendance.Checked) str_SQL = str_SQL + " and a.is_davam = 1 ";
            str_SQL = str_SQL + " order by dp.prog_code, s.name, s.surname";            

            grid_students.DataSource = con.GetDataTable(str_SQL);
             
            view_students.BestFitColumns();
            view_students.Columns["ALMA_DURUM"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view_students.Columns["ALMA_DURUM"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view_students.Columns["CLASS"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;            
        }

        private void view_courses_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (view_courses.SelectedRowsCount > 0)
            {
                check_attendance_CheckedChanged(sender, e);
                group_students.Text = view_courses.GetRowCellValue(e.FocusedRowHandle, "DERS_KOD").ToString() +
                                      " : " + view_courses.GetRowCellValue(e.FocusedRowHandle, "TITLE").ToString() +
                                      " [ " + view_courses.GetRowCellValue(e.FocusedRowHandle, "SECTION").ToString() + " ]";
            }
            else
            {
                grid_students.DataSource = null;
                group_students.Text = "STUDENT LIST";
            }
        }

        private void button_journal_Click(object sender, EventArgs e)
        {
            string str_students = "";
            object Missing = System.Reflection.Missing.Value;
            try
            {
                Word.Application app = new Word.Application();
                Word.Document doc = new Word.Document();
                
                try
                {                                       
                    object oTemplate = Properties.Settings.Default.CurProgDir + "\\journal.doc";
                    doc = app.Documents.Add(ref oTemplate, ref Missing, ref Missing, ref Missing);                                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Properties.Settings.Default.CurProgDir + "\\journal.doc" + " file couldn't be opened . Check the file exists..!" + ex.Message.ToString());
                }
                
                app.Visible = true;
                object bookmarkName = (object)"ders_ad";                
                Word.Range rng = doc.Bookmarks.get_Item(ref bookmarkName).Range;
                rng.Text = view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "TITLE").ToString() +
                           " ( " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "DERS_KOD").ToString() + "." + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "SECTION").ToString() + " ) "; 

                str_students = "select a.stud_id, s.name, s.surname, dp.title_en ||' - '|| dp.edu_lang as bölüm, s.class, case when exists(select * from dbmaster.ders_al_repeat r " +
                      "where r.stud_id = dr.stud_id and r.prog_code = sp.prog_code and r.prog_year = sp.prog_year and r.new_ders_kod = dr.ders_kod and r.new_year = dr.year and r.new_term = dr.term) " +
                      "then 'TƏKRAR' else 'İLK' end as ALMA_DURUM, dp.prog_code from dbmaster.ders_al_ref dr left outer join dbmaster.students s on s.stud_id = dr.stud_id " +
                      "left outer join dbmaster.stud_prog sp on sp.stud_id = s.stud_id left outer join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' " +
                      "left outer join dbmaster.ders_al a on a.stud_id = dr.stud_id and a.ders_kod = dr.ders_kod and a.year = dr.year and a.term = dr.term and a.section = dr.section " +
                      "where dp.prog_type = 'M' and dr.son = 1 and dr.ders_kod = '" + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "DERS_KOD").ToString() + "' and " +
                      "dr.year = " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "YEAR").ToString() + " and " +
                      "dr.term = " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "TERM").ToString() + " and " +
                      "dr.section = " + view_courses.GetRowCellValue((view_courses.GetSelectedRows()[0]), "SECTION").ToString();
                if (!check_attendance.Checked) str_students = str_students + " and a.is_davam = 1 ";
                str_students = str_students + " order by dp.prog_code, s.name, s.surname"; 
                DataTable students = con.GetDataTable(str_students);

                Word.Table table = doc.Tables[1];
                for (int j = 0; j < students.Rows.Count; j++)
                {
                    DataRow student = students.Rows[j];
                    if (j >= 40) 
                    {
                        table.Rows.Add(ref Missing);
                        table.Cell(4 + j, 1).Range.Text = (j+1).ToString();
                    }
                    table.Cell(4 + j, 2).Range.Text = student["PROG_CODE"].ToString();
                    table.Cell(4 + j, 3).Range.Text = student["STUD_ID"].ToString();
                    table.Cell(4 + j, 4).Range.Text = student["NAME"].ToString() + " " + student["SURNAME"].ToString();
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MS Word not responding..! " + ex.Message.ToString());
            }            
        }

        private void view_students_RowCountChanged(object sender, EventArgs e)
        {
            //button_journal.Enabled = view_students.RowCount > 0;          
        }

        private void button_journal_all_Click(object sender, EventArgs e)
        {              
            string courseTitle = string.Empty, str_students = string.Empty;
            object Missing = System.Reflection.Missing.Value;
            if (folderBrowser_Journal.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                Word.Application app = new Word.Application();                
                for (int i = 0; i < view_courses.RowCount; i++)  
                {
                    Word.Document doc = new Word.Document();
                    DataRow course = view_courses.GetDataRow(i);
                    object oTemplate = Properties.Settings.Default.CurProgDir + "\\journal.doc";
                    try
                    {
                        courseTitle = course["TITLE"].ToString();
                        courseTitle = courseTitle.Replace(":", "-"); 
                        courseTitle = courseTitle.Replace("/", " ");
                        doc = app.Documents.Add(ref oTemplate, ref Missing, ref Missing, ref Missing);                        
                        object fileToSave = folderBrowser_Journal.SelectedPath + "\\" + course["DERS_KOD"] + "." + course["SECTION"] + "_" + courseTitle + "_" + course["MÜƏLLIM"] + ".doc";                        
                        doc.SaveAs(ref fileToSave,
                             ref Missing, ref Missing, ref Missing, ref Missing,
                             ref Missing, ref Missing, ref Missing, ref Missing,
                             ref Missing, ref Missing, ref Missing, ref Missing,
                             ref Missing, ref Missing, ref Missing); //MessageBox.Show(fileToSave.ToString());                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Properties.Settings.Default.CurProgDir + "\\journal.doc" + " file couldn't be opened . Check the file exists..!" + ex.Message.ToString());
                    }
                    app.Visible = true;
                    object bookmarkName = (object)"ders_ad";
                    Word.Range rng = doc.Bookmarks.get_Item(ref bookmarkName).Range;                    
                    rng.Text = course["TITLE"].ToString() + " ( " + course["DERS_KOD"].ToString() + "." + course["SECTION"].ToString() + " ) ";

                    str_students = "select a.stud_id, s.name, s.surname, dp.prog_code from dbmaster.ders_al_ref dr left outer join dbmaster.students s on s.stud_id = dr.stud_id " +
                                   "left outer join dbmaster.stud_prog sp on sp.stud_id = s.stud_id left outer join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' " +
                                   "left outer join dbmaster.ders_al a on a.stud_id = dr.stud_id and a.ders_kod = dr.ders_kod and a.year = dr.year and a.term = dr.term and a.section = dr.section " +
                                   "where dp.prog_type = 'M' and a.is_davam = 1 and dr.son = 1 " +
                                   "and ((dr.ders_kod = '" + course["DERS_KOD"] + "' and dr.year = " + course["YEAR"] + " and dr.term = " + course["TERM"] + " and dr.section = " + course["SECTION"] + ") " +
                                   "or a.lab_sobe_id = " + course["DERS_SOBE_ID"] + ")";
                    str_students = str_students + " order by dp.prog_code, s.name, s.surname"; 
                    DataTable students = new DataTable();
                    students = con.GetDataTable(str_students);

                    Word.Table table = doc.Tables[1];
                    for (int j = 0; j < students.Rows.Count; j++)
                    {
                        DataRow student = students.Rows[j];
                        if (j >= 40)
                        {
                            table.Rows.Add(ref Missing);
                            table.Cell(4 + j, 1).Range.Text = (j+1).ToString();
                        }
                        table.Cell(4 + j, 2).Range.Text = student["PROG_CODE"].ToString();
                        table.Cell(4 + j, 3).Range.Text = student["STUD_ID"].ToString();
                        table.Cell(4 + j, 4).Range.Text = student["NAME"].ToString() + " " + student["SURNAME"].ToString();
                    }
                    ((Microsoft.Office.Interop.Word._Document)doc).Close(ref Missing, ref Missing, ref Missing);                    
                }
                ((Microsoft.Office.Interop.Word._Application)app).Quit(ref Missing, ref Missing, ref Missing);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MS Word error : " + ex.Message.ToString());
            }
        }

        private void journal_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void journal_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }

        private void browse_employee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1) browse_employee.Tag = browse_employee.Text = string.Empty;      
            else try
                {
                    findemp.frmFindEmp emp = new findemp.frmFindEmp();
                    if (emp.ShowDialog() == DialogResult.OK)
                    {
                        browse_employee.Tag = emp.dgEmployee.SelectedRows[0].Cells["EMP_ID"].Value.ToString();
                        browse_employee.Text = String.Format("{0} {1}", emp.dgEmployee.SelectedRows[0].Cells["NAME"].Value, emp.dgEmployee.SelectedRows[0].Cells["SNAME"].Value);                        
                    }
                }
                catch (Exception) { }
        }   
    }
}
