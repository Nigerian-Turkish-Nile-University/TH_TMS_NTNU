using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DB;
using Oracle.DataAccess.Client;
using TMS.Properties;

namespace TMS.adaptation
{
    public partial class form_mufsq : DevExpress.XtraEditors.XtraForm
    {
        private int id = 0;
        oraConn con = oraConn.DB;

        public form_mufsq(int _id = 0)
        {
            id = _id;            
            InitializeComponent();
        }

        private void form_mufsq_Load(object sender, EventArgs e)
        {
            string progCode, progYear, str_SQL = string.Empty;
            lookUp_SQ.EditValue = 0;

            if (id > 0)
            {
                try
                {
                    form_adaptation f = this.Owner as form_adaptation;
                    progCode = f.view_adaptedCourses.GetRowCellValue((f.view_adaptedCourses.GetSelectedRows()[0]), "PROG_CODE").ToString();
                    progYear = f.view_adaptedCourses.GetRowCellValue((f.view_adaptedCourses.GetSelectedRows()[0]), "PROG_YEAR").ToString();
                    lookUp_SQ.EditValue = Convert.ToDecimal(f.view_adaptedCourses.GetRowCellValue((f.view_adaptedCourses.GetSelectedRows()[0]), "MUF_SQ_ID") == DBNull.Value ? 0 : f.view_adaptedCourses.GetRowCellValue((f.view_adaptedCourses.GetSelectedRows()[0]), "MUF_SQ_ID"));
                    
                    str_SQL = "select 0 as id, ' Select' as title from dual union select sq.muf_sq_id, '( '||sq.period_no||' ) '||sq.ps_ders_kod||' - '||sq.title_en from dbmaster.mufredat_sq sq " +
                              "where sq.prog_code = " + progCode + " and sq.year = " + progYear + " order by 2";
                    con.load_lookUp(lookUp_SQ, str_SQL, "TITLE", "ID");
                    lookUp_SQ.Focus();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void lookUp_SQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void button_changeMufSQ_Click(object sender, EventArgs e)
        {
            string pRes = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();

            lst.Add(con.SetParameter("pId", OracleDbType.Int16, -1, ParameterDirection.Input, id));
            lst.Add(con.SetParameter("pMufSQ", OracleDbType.Int16, -1, ParameterDirection.Input, lookUp_SQ.EditValue));
            lst.Add(con.SetParameter("pEmpId", OracleDbType.Int16, 5, ParameterDirection.Input, Settings.Default.UserID));
            lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 10, ParameterDirection.InputOutput, 0));

            try
            {
                pRes = con.ExecSProcRetVal("dbmaster.pkg_adaptation.ChangeAdaptedMufSQ", lst.ToArray(), "pRes").ToString();
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }
    }
}