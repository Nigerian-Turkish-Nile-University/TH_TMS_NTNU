using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Globals;
using DB;
using Oracle.DataAccess.Client;
using TMS.Properties;

namespace TMS.adaptation
{
    public partial class form_adaptation : DevExpress.XtraEditors.XtraForm
    {
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;        
        public form_adaptation()
        {
            InitializeComponent();
        }

        private void adaptation_Load(object sender, EventArgs e)
        {
            string str_SQL = "";
            LoadForeignCourses();
            LoadTransferredCourses();
            lookUp_program.EditValue = 0;
            str_SQL = "select sp.prog_code||sp.prog_year as id, dp.prog_code||' : '||dp.title_en||decode(dp.edu_lang, NULL, '',' - '||dp.edu_lang) as title from dbmaster.stud_prog sp " +
                      "left outer join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year where sp.stud_id = '" + si.StudID + "' union select '0', 'Seçin' from dual";
            con.load_lookUp(lookUp_program, str_SQL, "TITLE", "ID");            
            
        }

        private void LoadForeignCourses()
        {
            string str_SQL = "";
            str_SQL = "select d.fc_id, d.ders_kod, d.ders_title, d.ders_credit, d.ders_ects, d.qiymet_yuz, d.qiymet_herf, o.ocaq_title, d.year, d.term, d.univ_id " +
                      "from dbmaster.adap_ders d left outer join dbmaster.tedris_ocaq o on o.tedris_o_id = d.univ_id where d.stud_id = '" + si.StudID + "' order by d.fc_id";
            grid_foreignCourses.DataSource = con.GetDataTable(str_SQL);
            view_foreignCourses.BestFitColumns();
            view_foreignCourses.Columns["UNIV_ID"].Visible = false;
            view_foreignCourses.Columns["FC_ID"].AppearanceCell.ForeColor = Color.Red;
            view_foreignCourses.Columns["FC_ID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void LoadTransferredCourses()
        {
            string str_SQL = "";
            str_SQL = "select da.id, da.fc_id, da.ders_kod, d.title_en as title, d.k_qu, d.k_ects, da.qiymet_yuz, da.qiymet_herf, da.grading_type, da.transfer_type, da.year, da.description " +
                      "from dbmaster.adap_ders_al da left outer join dbmaster.ders d on d.ders_kod = da.ders_kod and d.year = da.year where da.stud_id = '" + si.StudID + "' order by da.fc_id";
            grid_transferredCourses.DataSource = con.GetDataTable(str_SQL);            
            view_transferredCourses.BestFitColumns();            
            view_transferredCourses.Columns["ID"].Visible = false;
            view_transferredCourses.Columns["YEAR"].Visible = false;
            view_transferredCourses.Columns["DESCRIPTION"].Visible = false;
            view_transferredCourses.Columns["FC_ID"].AppearanceCell.ForeColor = Color.Red;
            view_transferredCourses.Columns["FC_ID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void lookUp_program_EditValueChanged(object sender, EventArgs e)
        {
            string str_SQL = "";                      
            if (lookUp_program.EditValue.ToString() == "0") grid_adaptedCourses.DataSource = null;
            else
            {

                str_SQL = "select ar.ders_kod, d.title_en as title, d.k_qu, d.k_ects, ar.ref_type, ar.muf_sq_id, ar.prog_code, " +
                          "ar.prog_year, (select m.ders_kod from dbmaster.mufredat m where m.muf_id = ar.muf_id) as muf_ders_kod, ar.id, " +
                          "(select sq.ps_ders_kod from dbmaster.mufredat_sq sq where sq.muf_sq_id = ar.muf_sq_id) as SQ_KOD, ar.is_active " +
                          "from dbmaster.adap_ders_al_ref ar left outer join dbmaster.ders d on d.ders_kod = ar.ders_kod and d.year = ar.year " +
                          "where ar.stud_id = '" + si.StudID + "' and ar.prog_code||ar.prog_year = " + lookUp_program.EditValue + " order by d.year, d.term, d.ders_kod";
                grid_adaptedCourses.DataSource = con.GetDataTable(str_SQL);                
                view_adaptedCourses.Columns["ID"].Visible = false;
                view_adaptedCourses.Columns["MUF_SQ_ID"].Visible = false;
                view_adaptedCourses.Columns["PROG_CODE"].Visible = false;
                view_adaptedCourses.Columns["PROG_YEAR"].Visible = false;                
                view_adaptedCourses.BestFitColumns();
            }
            button_refuse.Enabled = view_adaptedCourses.RowCount > 0;
            button_adapt.Enabled = lookUp_program.EditValue.ToString() != "0"; 
        }

        private void view_adaptedCourses_DoubleClick(object sender, EventArgs e)
        {
            string id = string.Empty;
            if (view_adaptedCourses.RowCount == 0) return;
            if (view_adaptedCourses.GetRowCellValue((view_adaptedCourses.GetSelectedRows()[0]), "REF_TYPE").ToString() == "E")
            {
                id = view_adaptedCourses.GetRowCellValue((view_adaptedCourses.GetSelectedRows()[0]), "ID").ToString();

                form_mufsq sq = new form_mufsq(int.Parse(id)); sq.Owner = this;
                sq.group_electiveCourse.Text = view_adaptedCourses.GetRowCellValue((view_adaptedCourses.GetSelectedRows()[0]), "DERS_KOD").ToString() + " - " +
                                               view_adaptedCourses.GetRowCellValue((view_adaptedCourses.GetSelectedRows()[0]), "TITLE").ToString();
                if (sq.ShowDialog() == DialogResult.OK) lookUp_program_EditValueChanged(sender, e);
            }
        }

        private void button_refuse_Click(object sender, EventArgs e)
        {
            string pRes = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();

            lst.Add(con.SetParameter("pStudId", OracleDbType.Char, -1, ParameterDirection.Input, si.StudID));
            lst.Add(con.SetParameter("pProgCode", OracleDbType.Varchar2, 5, ParameterDirection.Input, lookUp_program.EditValue.ToString().Substring(0, 5)));
            lst.Add(con.SetParameter("pProgYear", OracleDbType.Int16, 4, ParameterDirection.Input, lookUp_program.EditValue.ToString().Substring(5, 4)));
            lst.Add(con.SetParameter("pEmpId", OracleDbType.Int16, 5, ParameterDirection.Input, Settings.Default.UserID));
            lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 10, ParameterDirection.InputOutput, 0));

            if (MessageBox.Show("Are you sure REFUSE adapted courses?", "REFUSE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            try
            {
                pRes = con.ExecSProcRetVal("dbmaster.pkg_adaptation.RefuseStudCoursesfromProg", lst.ToArray(), "pRes").ToString();
                lookUp_program_EditValueChanged(sender, e);
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void button_adapt_Click(object sender, EventArgs e)
        {
            string pRes = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();

            lst.Add(con.SetParameter("pStudId", OracleDbType.Char, -1, ParameterDirection.Input, si.StudID));
            lst.Add(con.SetParameter("pProgCode", OracleDbType.Varchar2, 5, ParameterDirection.Input, lookUp_program.EditValue.ToString().Substring(0, 5)));
            lst.Add(con.SetParameter("pProgYear", OracleDbType.Int16, 4, ParameterDirection.Input, lookUp_program.EditValue.ToString().Substring(5, 4)));
            lst.Add(con.SetParameter("pEmpId", OracleDbType.Int16, 5, ParameterDirection.Input, Settings.Default.UserID));
            lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 10, ParameterDirection.InputOutput, 0));

            if (MessageBox.Show("Are you sure ADAPT to the selected program?", "ADAPTATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            try
            {
                pRes = con.ExecSProcRetVal("dbmaster.pkg_adaptation.AdaptStudCoursestoProg", lst.ToArray(), "pRes").ToString();
                MessageBox.Show("Adapted course count : " + pRes, "ADAPTATION");
                lookUp_program_EditValueChanged(sender, e);
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void button_addForeignCourse_Click(object sender, EventArgs e)
        {
            foreign_course fc = new foreign_course(); fc.Owner = this; fc.group_foreignCourse.Text = "New data";
            if (fc.ShowDialog() == DialogResult.OK) LoadForeignCourses();
        }

        private void button_editForeignCourse_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            if (view_foreignCourses.SelectedRowsCount > 0)
            {
                id = view_foreignCourses.GetRowCellValue((view_foreignCourses.GetSelectedRows()[0]), "FC_ID").ToString();
                foreign_course fc = new foreign_course(int.Parse(id));
                fc.Owner = this; fc.group_foreignCourse.Text = "Edit data";
                if (fc.ShowDialog() == DialogResult.OK) LoadForeignCourses();
            }
        }

        private void view_foreignCourses_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            button_editForeignCourse.Enabled = (e.FocusedRowHandle >= 0);
            button_removeForeignCourse.Enabled = (e.FocusedRowHandle >= 0);
        }

        private void button_removeForeignCourse_Click(object sender, EventArgs e)
        {
            List<OracleParameter> lst = new List<OracleParameter>();
            string pRes, id = string.Empty, msg = string.Empty;
            try
            {
                msg = "Are you sure deleting data?";
                id = view_foreignCourses.GetRowCellValue((view_foreignCourses.GetSelectedRows()[0]), "FC_ID").ToString();
                if ((MessageBox.Show(msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    lst.Add(con.SetParameter("pId", OracleDbType.Int32, 20, ParameterDirection.Input, id));
                    lst.Add(con.SetParameter("pEmpId", OracleDbType.Int16, 5, ParameterDirection.Input, Settings.Default.UserID));
                    lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 10, ParameterDirection.InputOutput, 0));

                    try
                    {
                        pRes = con.ExecSProcRetVal("dbmaster.pkg_adaptation.DeleteForeignCourse", lst.ToArray(), "pRes").ToString();
                        LoadForeignCourses();
                    }
                    catch (OracleException oex) { MessageBox.Show(oex.Message); }
                }   
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void button_addTransferredCourse_Click(object sender, EventArgs e)
        {
            transfer_course tc = new transfer_course(); tc.Owner = this; 
            tc.group_transferCourse.Text = "New Data";
            if (tc.ShowDialog() == DialogResult.OK) LoadTransferredCourses(); 
        }

        private void view_transferredCourses_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            button_editTransferredCourse.Enabled = (e.FocusedRowHandle >= 0);
            button_removeTransferredCourse.Enabled = (e.FocusedRowHandle >= 0);
        }

        private void button_editTransferredCourse_Click(object sender, EventArgs e)
        {
            string id = string.Empty;
            if (view_transferredCourses.SelectedRowsCount > 0)
            {
                id = view_transferredCourses.GetRowCellValue((view_transferredCourses.GetSelectedRows()[0]), "ID").ToString();
                transfer_course tc = new transfer_course(int.Parse(id));
                tc.Owner = this; tc.group_transferCourse.Text = "Edit data";
                if (tc.ShowDialog() == DialogResult.OK) LoadTransferredCourses();
            }
        }

        private void button_removeTransferredCourse_Click(object sender, EventArgs e)
        {
            List<OracleParameter> lst = new List<OracleParameter>();
            string pRes, id = string.Empty, msg = string.Empty;
            try
            {
                msg = "Are you sure deleting data?";
                id = view_transferredCourses.GetRowCellValue((view_transferredCourses.GetSelectedRows()[0]), "ID").ToString();
                if ((MessageBox.Show(msg, "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    lst.Add(con.SetParameter("pId", OracleDbType.Int32, 20, ParameterDirection.Input, id));
                    lst.Add(con.SetParameter("pEmpId", OracleDbType.Int16, 5, ParameterDirection.Input, Settings.Default.UserID));
                    lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 10, ParameterDirection.InputOutput, 0));

                    try
                    {
                        pRes = con.ExecSProcRetVal("dbmaster.pkg_adaptation.DeleteTransferredCourse", lst.ToArray(), "pRes").ToString();
                        LoadTransferredCourses();
                    }
                    catch (OracleException oex) { MessageBox.Show(oex.Message); }
                }
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }
    }
}