using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Globals;
using DB;
using Oracle.DataAccess.Client;
using TMS.Properties;

namespace TMS.adaptation
{
    public partial class transfer_course : DevExpress.XtraEditors.XtraForm
    {
        private int id = 0;
        oraConn con = oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
        ConditionValidationRule notSelectedValidationRule = new ConditionValidationRule();
        public transfer_course(int _id = 0)
        {
            id = _id;
            InitializeComponent();
        }

        private void transfer_course_Load(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;

            lookUp_ourCourse.EditValue = 0;
            lookUp_gradingType.EditValue = 0;
            lookUp_gradeLetter.EditValue = 0;
            lookUp_transferType.EditValue = 0;
            lookUp_foreignCourse.EditValue = 0;

            if (id > 0)
            {
                try
                {
                    lookUp_foreignCourse.Enabled = false;
                    form_adaptation f = this.Owner as form_adaptation;

                    memo_desc.Text = f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "DESCRIPTION").ToString();                    
                    lookUp_transferType.EditValue = f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "TRANSFER_TYPE");
                    lookUp_ourCourse.EditValue = f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "DERS_KOD").ToString();
                    lookUp_gradeLetter.EditValue = f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "QIYMET_HERF").ToString();
                    lookUp_gradingType.EditValue = f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "GRADING_TYPE").ToString();                    
                    lookUp_foreignCourse.EditValue = Convert.ToDecimal(f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "FC_ID") == DBNull.Value ? 0 : f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "FC_ID"));
                    spinEdit_grade.Value = Convert.ToDecimal(f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "QIYMET_YUZ") == DBNull.Value ? 0 : f.view_transferredCourses.GetRowCellValue((f.view_transferredCourses.GetSelectedRows()[0]), "QIYMET_YUZ"));                    
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            
            check_foreignCourses_CheckedChanged(sender, e);
            
            str_SQL = "select '0' as id, ' Select' as title from dual union select t.key, t.title_en from dbmaster.transfer_types t order by 2";
            con.load_lookUp(lookUp_transferType, str_SQL, "TITLE", "ID");
            
            str_SQL = "select '0' as id, ' Select' as title from dual union select t.key, t.title_en from dbmaster.grading_types t order by 2";
            con.load_lookUp(lookUp_gradingType, str_SQL, "TITLE", "ID");

            str_SQL = "select '0' as id, ' Select' as title from dual union select i.qiymet_herf, i.qiymet_herf||' ( '||i.qiymet_alt||' - '||i.qiymet_ust||' )' from dbmaster.qiymet_info i " +
                      "where i.edu_level = '" + si.eduLevel + "' and i.year = (select max(qi.year) from dbmaster.qiymet_info qi) order by 2";
            con.load_lookUp(lookUp_gradeLetter, str_SQL, "TITLE", "ID"); 

            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "No Data Entered";

            notSelectedValidationRule.ConditionOperator = ConditionOperator.NotEquals;
            notSelectedValidationRule.Value1 = 0; notSelectedValidationRule.ErrorText = "No Data Selected";
        }

        private void lookUp_foreignCourse_EditValueChanged(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            str_SQL = "select '0' as id, ' Select' as title from dual union select d.ders_kod, d.ders_kod||' - '||d.title_en||' [ '||d.k_teor||'+'||(d.k_prat + d.k_lab)||' ]' from dbmaster.ders d " +
                      "where d.year = (select a.year from dbmaster.adap_ders a where a.fc_id = " + lookUp_foreignCourse.EditValue + ")" +
                      "and not exists(select a.ders_kod from dbmaster.adap_ders_al a where a.fc_id = " + lookUp_foreignCourse.EditValue + " and a.ders_kod = d.ders_kod) order by 2";
            con.load_lookUp(lookUp_ourCourse, str_SQL, "TITLE", "ID");
        }

        private void lookUp_foreignCourse_Validating(object sender, CancelEventArgs e)
        {
            dxValidationProvider_transferredCourses.Validate();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string pRes, str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            dxValidationProvider_transferredCourses.SetValidationRule(spinEdit_grade, notSelectedValidationRule);            
            dxValidationProvider_transferredCourses.SetValidationRule(lookUp_ourCourse, notSelectedValidationRule);
            dxValidationProvider_transferredCourses.SetValidationRule(lookUp_gradeLetter, notSelectedValidationRule);
            dxValidationProvider_transferredCourses.SetValidationRule(lookUp_gradingType, notSelectedValidationRule);
            dxValidationProvider_transferredCourses.SetValidationRule(lookUp_transferType, notSelectedValidationRule);
            dxValidationProvider_transferredCourses.SetValidationRule(lookUp_foreignCourse, notSelectedValidationRule);

            dxValidationProvider_transferredCourses.Validate();

            if (dxValidationProvider_transferredCourses.GetInvalidControls().Count > 0) MessageBox.Show("Please, fill all the fields..!", "Missing Data");
            else
            {
                lst.Add(con.SetParameter("pStudId", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID));
                lst.Add(con.SetParameter("pDersCode", OracleDbType.Varchar2, 10, ParameterDirection.Input, lookUp_ourCourse.EditValue));
                lst.Add(con.SetParameter("pGrade", OracleDbType.Decimal, 3, ParameterDirection.Input, spinEdit_grade.Value));
                lst.Add(con.SetParameter("pGradeLetter", OracleDbType.Varchar2, 2, ParameterDirection.Input, lookUp_gradeLetter.EditValue));
                lst.Add(con.SetParameter("pGradingType", OracleDbType.Varchar2, 3, ParameterDirection.Input, lookUp_gradingType.EditValue));
                lst.Add(con.SetParameter("pTransferType", OracleDbType.Varchar2, 15, ParameterDirection.Input, lookUp_transferType.EditValue));
                lst.Add(con.SetParameter("pFcId", OracleDbType.Int32, 20, ParameterDirection.Input, lookUp_foreignCourse.EditValue));
                lst.Add(con.SetParameter("pDesc", OracleDbType.Varchar2, 250, ParameterDirection.Input, memo_desc.Text));
                lst.Add(con.SetParameter("pEmpId", OracleDbType.Int16, 5, ParameterDirection.Input, Settings.Default.UserID));
                lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 10, ParameterDirection.InputOutput, id));

                try
                {
                    pRes = con.ExecSProcRetVal("dbmaster.pkg_adaptation.InsUpdTransferredCourse", lst.ToArray(), "pRes").ToString();
                    DialogResult = DialogResult.OK;
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
        }

        private void check_foreignCourses_CheckedChanged(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            lookUp_foreignCourse.EditValue = Convert.ToDecimal(0);
            str_SQL = "select 0 as id, ' Select' as title from dual union select d.fc_id, d.fc_id||'. [ '||d.year||' - '||d.term||' ] '||decode(d.ders_kod, NULL, d.ders_title, d.ders_kod||' - '||d.ders_title ) " +
                      "from dbmaster.adap_ders d where d.stud_id = " + si.StudID; 
            if (!check_foreignCourses.Checked) str_SQL = str_SQL + " and not exists(select a.fc_id from dbmaster.adap_ders_al a where a.fc_id = d.fc_id)";
            str_SQL = str_SQL + " order by 2";
            con.load_lookUp(lookUp_foreignCourse, str_SQL, "TITLE", "ID");
        }
    }
}