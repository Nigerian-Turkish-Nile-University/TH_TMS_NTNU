using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using DB;
using Oracle.DataAccess.Client;

namespace TMS.advisor
{
    public partial class danisman : Form
    {
        string[] students;
        oraConn con = oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        General.functions f = new General.functions();       
        
        public danisman()
        {
            InitializeComponent();
        }

        private void danisman_Load(object sender, EventArgs e)
        {
            if (si.StudID.Length == 9) radio_danisman.SelectedIndex = 1;
            else
            { 
                radio_danisman.SelectedIndex = 0;
                radio_danisman.Properties.Items[1].Enabled = false;
            }
            radio_danisman_SelectedIndexChanged(sender, e);
        }

        private void radio_danisman_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_SQL = "";
            grid_danisman.DataSource = null; view_danisman.Columns.Clear();
            group_danisman.Text = radio_danisman.Properties.Items[radio_danisman.SelectedIndex].Description;            
            if (radio_danisman.SelectedIndex == 0)
            {                
                button_add_change.Enabled = true;
                button_add_change.Text = "ADD";                
                browse_student.Text = ""; browse_student.Tag = 0;                         
                browse_student.Enabled = ((browse_employee.Tag != null) && (browse_employee.Tag.ToString().Length > 0));
                label_year_sem.Text = f.GetCfgActVal("DAN_IL_SEM")[0].ToString() + " - " + f.GetCfgActVal("DAN_IL_SEM")[1].ToString();                
                if (browse_employee.Tag != null)
                {
                    str_SQL = "select h.stud_id, s.name||' '||s.surname as student, dp.prog_code as dep_id, s.class " +
                              "from dbmaster.stud_info_hist h left outer join dbmaster.students s on s.stud_id = h.stud_id "+
                              "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type='M' " +
                              "where dp.prog_type='M' and h.year = " + f.GetCfgActVal("DAN_IL_SEM")[0].ToString() + " and h.term = " + f.GetCfgActVal("DAN_IL_SEM")[1].ToString() + " and h.stud_rehber= " + browse_employee.Tag.ToString();
                
                    grid_danisman.DataSource = con.GetDataTable(str_SQL);                    
                    view_danisman.BestFitColumns();
                    view_danisman.Columns["STUD_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    view_danisman.Columns["CLASS"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    view_danisman.Columns["DEP_ID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }
            else
            {
                label_year_sem.Text = "";
                button_add_change.Text = "Change";
                browse_student.Text = si.SName + " " + si.SSName;
                browse_employee.Tag = null; browse_employee.Text = "";                                
                browse_student.Tag = 0; browse_student.Enabled = false;                

                str_SQL = "select h.year, h.term as donem, h.class, decode(h.stud_rehber, NULL, 'N/A', e.name||' '||e.sname) as employee, e.emp_id "+
                          "from dbmaster.stud_info_hist h left outer join dbmaster.employee e on e.emp_id = h.stud_rehber "+
                          "where h.stud_id = '" + si.StudID + "' and h.year||h.term <=  " + f.GetCfgActVal("DAN_IL_SEM")[0].ToString() + f.GetCfgActVal("DAN_IL_SEM")[1].ToString() + " order by h.year, h.term";
                grid_danisman.DataSource = con.GetDataTable(str_SQL);                 
                view_danisman.BestFitColumns();
                view_danisman.Columns["EMP_ID"].Visible = false;
                view_danisman.Columns["YEAR"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                view_danisman.Columns["DONEM"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                view_danisman.Columns["CLASS"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;                
                button_add_change.Enabled = (view_danisman.RowCount > 0);
            }
        }

        private void view_danisman_RowCountChanged(object sender, EventArgs e)
        {
            button_delete.Enabled = view_danisman.RowCount > 0;
        }

        private void button_add_change_Click(object sender, EventArgs e)
        {            
            string year = "", sem = "";            
            if (radio_danisman.SelectedIndex == 0)
            {
                if ((browse_employee.Tag != null) && (Convert.ToInt16(browse_student.Tag) > 0))
                {
                    if (MessageBox.Show("Are you sure adding new data?", "ADD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (string student in students)
                        {
                            OracleParameter[] prms = 
                            { 
                                con.SetParameter("StudID", OracleDbType.Char, 9, ParameterDirection.Input, student),
                                con.SetParameter("pyear", OracleDbType.Int16, 4, ParameterDirection.Input, f.GetCfgActVal("DAN_IL_SEM")[0]),
                                con.SetParameter("psemester", OracleDbType.Int16, 1, ParameterDirection.Input, f.GetCfgActVal("DAN_IL_SEM")[1]),
                                con.SetParameter("empID", OracleDbType.Int32, 5, ParameterDirection.Input, Convert.ToInt32(browse_employee.Tag.ToString()))
                            };
                            try { con.ExecSProcRetVal("dbmaster.update_stud_danisman", prms); }
                            catch (OracleException oe) { MessageBox.Show(oe.Message); }
                        }
                        radio_danisman_SelectedIndexChanged(sender, e);
                    }
                }
                else
                {
                    browse_student.Text = "";
                    MessageBox.Show("Please, fill all required fields..!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if ((browse_employee.Tag != null) && (browse_employee.Tag.ToString() != view_danisman.GetRowCellValue((view_danisman.GetSelectedRows()[0]), "EMP_ID").ToString()))
                {
                    if (MessageBox.Show("Are you sure changing data?", "CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        year = view_danisman.GetRowCellValue((view_danisman.GetSelectedRows()[0]), "YEAR").ToString();
                        sem = view_danisman.GetRowCellValue((view_danisman.GetSelectedRows()[0]), "DONEM").ToString();
                        OracleParameter[] prms = 
                        { 
                            con.SetParameter("StudID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID),
                            con.SetParameter("pyear", OracleDbType.Int16, 4, ParameterDirection.Input, Convert.ToInt16(year)),
                            con.SetParameter("psemester", OracleDbType.Int16, 1, ParameterDirection.Input, Convert.ToInt16(sem)),
                            con.SetParameter("empID", OracleDbType.Int32, 5, ParameterDirection.Input, Convert.ToInt32(browse_employee.Tag.ToString()))
                        };
                        try 
                        {
                            con.ExecSProcRetVal("dbmaster.update_stud_danisman", prms);
                            if (year == f.GetCfgActVal("DAN_IL_SEM")[0].ToString() && sem == f.GetCfgActVal("DAN_IL_SEM")[1].ToString())
                            {
                                TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
                                mf.txtDanisman.Text = browse_employee.Text;
                            }
                        }
                        catch (OracleException oe) { MessageBox.Show(oe.Message); }                       
                        radio_danisman_SelectedIndexChanged(sender, e);
                    }
                }
                else MessageBox.Show("Please, fill all required fields..!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void view_danisman_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (view_danisman.SelectedRowsCount > 0)
                {
                    if (radio_danisman.SelectedIndex == 0)
                    {
                        browse_student.Tag = 0;
                        browse_student.Text = view_danisman.GetRowCellValue((view_danisman.GetSelectedRows()[0]), "STUDENT").ToString();
                    }
                    else
                    {
                        if (Convert.IsDBNull(view_danisman.GetRowCellValue(e.FocusedRowHandle, "EMP_ID")) || view_danisman.GetRowCellValue(e.FocusedRowHandle, "EMP_ID").ToString().Length < 5)
                        {
                            browse_employee.Text = "";
                            browse_employee.Tag = null;
                        }
                        else
                        {
                            browse_employee.Tag = view_danisman.GetRowCellValue(e.FocusedRowHandle, "EMP_ID").ToString();
                            browse_employee.Text = view_danisman.GetRowCellValue(e.FocusedRowHandle, "EMPLOYEE").ToString();                            
                        }
                        label_year_sem.Text = view_danisman.GetRowCellValue(e.FocusedRowHandle, "YEAR").ToString() + " - " + view_danisman.GetRowCellValue(e.FocusedRowHandle, "DONEM").ToString();
                    }
                }
            }
            catch (Exception) 
            { 
                //MessageBox.Show(ex.Message);            
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string year = "", sem = "";
            if (MessageBox.Show("Are you sure deleting data?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (radio_danisman.SelectedIndex == 0)
                {
                    //MessageBox.Show(f.GetCfgActVal("DAN_IL_SEM")[0].ToString() + " - " + f.GetCfgActVal("DAN_IL_SEM")[1].ToString());
                    OracleParameter[] prms = 
                    { 
                        con.SetParameter("StudID", OracleDbType.Char, 9, ParameterDirection.Input, view_danisman.GetRowCellValue((view_danisman.GetSelectedRows()[0]), "STUD_ID").ToString()),
                        con.SetParameter("pyear", OracleDbType.Int16, 4, ParameterDirection.Input, f.GetCfgActVal("DAN_IL_SEM")[0]),
                        con.SetParameter("psemester", OracleDbType.Int16, 1, ParameterDirection.Input, f.GetCfgActVal("DAN_IL_SEM")[1]),
                        con.SetParameter("empID", OracleDbType.Int32, 5, ParameterDirection.Input, null)
                    };
                    try { con.ExecSProcRetVal("dbmaster.update_stud_danisman", prms); }
                    catch (OracleException oe) { MessageBox.Show(oe.Message); }
                }
                else
                {
                    year = view_danisman.GetRowCellValue((view_danisman.GetSelectedRows()[0]), "YEAR").ToString();
                    sem = view_danisman.GetRowCellValue((view_danisman.GetSelectedRows()[0]), "DONEM").ToString();
                    OracleParameter[] prms = 
                    { 
                        con.SetParameter("StudID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID),
                        con.SetParameter("pyear", OracleDbType.Int16, 4, ParameterDirection.Input, Convert.ToInt16(year)),
                        con.SetParameter("psemester", OracleDbType.Int16, 1, ParameterDirection.Input, Convert.ToInt16(sem)),                        
                        con.SetParameter("empID", OracleDbType.Int32, 5, ParameterDirection.Input, null)
                    };
                    try 
                    {
                        con.ExecSProcRetVal("dbmaster.update_stud_danisman", prms);
                        if (year == f.GetCfgActVal("DAN_IL_SEM")[0].ToString() && sem == f.GetCfgActVal("DAN_IL_SEM")[1].ToString())
                        {
                            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
                            mf.txtDanisman.Text = "N/A";
                        }
                    }
                    catch (OracleException oe) { MessageBox.Show(oe.Message); }
                }
                radio_danisman_SelectedIndexChanged(sender, e);
            }
        }

        private void browse_student_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {            
            if (e.Button.Index == 0)
            {
                StudSearch.frmStudSEARCH stud = new TMS.StudSearch.frmStudSEARCH();
                stud.dgvSTUD_MAIN.MultiSelect = true; stud.emp = browse_employee.Tag.ToString();
                if ((stud.ShowDialog() == DialogResult.OK) && (stud.dgvSTUD_MAIN.SelectedRows.Count > 0))
                {
                    students = new string[stud.dgvSTUD_MAIN.SelectedRows.Count];
                    browse_student.Text = ""; browse_student.Tag = students.Length;
                    for (int i = 0; i < stud.dgvSTUD_MAIN.SelectedRows.Count; i++)
                    {
                        students[i] = stud.dgvSTUD_MAIN.SelectedRows[i].Cells["STUD_ID"].Value.ToString();
                        browse_student.Text = browse_student.Text + students[i]; if (i != (stud.dgvSTUD_MAIN.SelectedRows.Count - 1)) browse_student.Text = browse_student.Text + ", ";
                    }
                    //MessageBox.Show(students.Length.ToString()); foreach (string student in students) MessageBox.Show(student);
                }
            }
        }

        private void danisman_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void browse_employee_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) try
            {
                findemp.frmFindEmp emp = new findemp.frmFindEmp(7); // Danışman görəvinə görə süz(filter)...                
                if (emp.ShowDialog() == DialogResult.OK)
                {
                    browse_employee.Tag = emp.dgEmployee.SelectedRows[0].Cells["EMP_ID"].Value.ToString();
                    browse_employee.Text = String.Format("{0} {1}", emp.dgEmployee.SelectedRows[0].Cells["NAME"].Value, emp.dgEmployee.SelectedRows[0].Cells["SNAME"].Value);
                    if (radio_danisman.SelectedIndex == 0) radio_danisman_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void danisman_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }     
    }
}
