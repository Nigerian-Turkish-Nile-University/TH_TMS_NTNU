using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DB;
using Oracle.DataAccess.Client;
using TMS.Properties;
using Globals;

namespace TMS.adaptation
{
    public partial class foreign_course : DevExpress.XtraEditors.XtraForm
    {
        private int id = 0;
        oraConn con = oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        General.functions cfg = new General.functions();
        ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
        ConditionValidationRule notSelectedValidationRule = new ConditionValidationRule();

        public foreign_course(int _id = 0)
        {
            id = _id;
            InitializeComponent();
        }

        private void foreign_course_Load(object sender, EventArgs e)
        {
            string str_SQL = "";
            lookUp_year.EditValue = 0;
            lookUp_semester.EditValue = 0;
            lookUp_university.EditValue = 0;
            if (id > 0)
            {
                try
                {
                    form_adaptation f = this.Owner as form_adaptation;

                    lookUp_year.EditValue = f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "YEAR");
                    lookUp_semester.EditValue = f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "TERM");    
                    lookUp_university.EditValue = f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "UNIV_ID");                    
                    edit_dersCode.Text = f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "DERS_KOD").ToString();
                    edit_dersTitle.Text = f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "DERS_TITLE").ToString();
                    edit_gradeLetter.Text = f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "QIYMET_HERF").ToString();
                    spin_ects.Value = Convert.ToDecimal(f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "DERS_ECTS") == DBNull.Value ? 0 : f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "DERS_ECTS"));
                    spin_credit.Value = Convert.ToDecimal(f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "DERS_CREDIT") == DBNull.Value ? 0 : f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "DERS_CREDIT"));
                    spinEdit_grade.Value = Convert.ToDecimal(f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "QIYMET_YUZ") == DBNull.Value ? 0 : f.view_foreignCourses.GetRowCellValue((f.view_foreignCourses.GetSelectedRows()[0]), "QIYMET_YUZ"));                                        
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            str_SQL = "select (level + 1993) as year, (level + 1993)||'-'||to_char(level + 1994) as il from dual connect by level <= (" + cfg.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " - 1993) " +
                      "union select 0, 'Seçin' from dual order by 2 desc";
            con.load_lookUp(lookUp_year, str_SQL, "IL", "YEAR");
                        
            str_SQL = "select level||decode(level, 3, '. Summer School', '. Semester') as d, level as v from dual connect by level <= 3 union select 'Seçin', 0 from dual order by 2";
            con.load_lookUp(lookUp_semester, str_SQL, "D", "V");
                        
            str_SQL = "select 0 as id, ' Seçin' as title from dual union select t.tedris_o_id, t.ocaq_title from dbmaster.tedris_ocaq t where t.tedris_o_type = 5 order by 2";
            con.load_lookUp(lookUp_university, str_SQL, "TITLE", "ID");

            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "No Data Entered";

            notSelectedValidationRule.ConditionOperator = ConditionOperator.NotEquals;
            notSelectedValidationRule.Value1 = 0; notSelectedValidationRule.ErrorText = "No Data Selected";
        }

        private void lookUp_year_Validating(object sender, CancelEventArgs e)
        {
            dxValidationProvider_foreignCourses.Validate();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string pRes, str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            dxValidationProvider_foreignCourses.SetValidationRule(edit_dersTitle, notEmptyValidationRule);
            dxValidationProvider_foreignCourses.SetValidationRule(lookUp_year, notSelectedValidationRule);
            dxValidationProvider_foreignCourses.SetValidationRule(lookUp_semester, notSelectedValidationRule);
            dxValidationProvider_foreignCourses.SetValidationRule(lookUp_university, notSelectedValidationRule);
            

            dxValidationProvider_foreignCourses.Validate();

            if (dxValidationProvider_foreignCourses.GetInvalidControls().Count > 0) MessageBox.Show("Please, fill all the fields..!", "Missing Data");
            else
            {
                lst.Add(con.SetParameter("pStudId", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID));
                lst.Add(con.SetParameter("pYear", OracleDbType.Int16, 4, ParameterDirection.Input, lookUp_year.EditValue));
                lst.Add(con.SetParameter("pTerm", OracleDbType.Int16, 1, ParameterDirection.Input, lookUp_semester.EditValue));                
                lst.Add(con.SetParameter("pDersCode", OracleDbType.Varchar2, 10, ParameterDirection.Input, edit_dersCode.Text.Trim()));
                lst.Add(con.SetParameter("pDersTitle", OracleDbType.Varchar2, 100, ParameterDirection.Input, edit_dersTitle.Text.Trim()));
                lst.Add(con.SetParameter("pCredit", OracleDbType.Decimal, 2, ParameterDirection.Input, spin_credit.Value));
                lst.Add(con.SetParameter("pEcts", OracleDbType.Decimal, 3, ParameterDirection.Input, spin_ects.Value));
                lst.Add(con.SetParameter("pGrade", OracleDbType.Decimal, 3, ParameterDirection.Input, spinEdit_grade.Value));
                lst.Add(con.SetParameter("pGradeLetter", OracleDbType.Varchar2, 2, ParameterDirection.Input, edit_gradeLetter.Text));
                lst.Add(con.SetParameter("pUnivId", OracleDbType.Int32, 20, ParameterDirection.Input, lookUp_university.EditValue));
                lst.Add(con.SetParameter("pEmpId", OracleDbType.Int16, 5, ParameterDirection.Input, Settings.Default.UserID));
                lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 10, ParameterDirection.InputOutput, id));

                try
                {
                    pRes = con.ExecSProcRetVal("dbmaster.pkg_adaptation.InsUpdForeignCourse", lst.ToArray(), "pRes").ToString();
                    DialogResult = DialogResult.OK;
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
        }
    }
}