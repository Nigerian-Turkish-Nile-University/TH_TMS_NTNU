using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Globals;

namespace TelebeQeydiyyat.Selectors
{
    public partial class frmSecQohum : Form
    {
        DB.oraConn con = DB.oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        private int disctype = 0;
        public int QohumTypeId = -1; // ata, baci, qardas
        public enum _formMod { New, Edit };
        public _formMod formMod = _formMod.New;

        public frmSecQohum(int _type)
        {
            InitializeComponent();
            disctype = _type;
        }

        private void frmSecQohum_Load(object sender, EventArgs e)
        {
            LoadLookUpQohumTypes();
            if (QohumTypeId >= 0) leQohumType.EditValue = Convert.ToDecimal(QohumTypeId); else browse_relative.Enabled = false;
            leQohumType.Enabled = (formMod == _formMod.New);

            if (formMod == _formMod.New)
            {
                this.Text = "Add new relative";
                btnOk.Text = "ADD";
            }
            else
            {
                this.Text = "Change";
                btnOk.Text = "Change";
                btnOk.Enabled = false;
            }

            switch (disctype)
            {
                case 70: group_relative.Text = "Relative Studying in NTNU"; break;
                case 72: group_relative.Text = "Relative Working in NTNU"; break;
                default: break;
            }
        }

        private void LoadLookUpQohumTypes()
        {
            string sql = "select t.parent_type_id id, t.title_en title, t.gender_id, t.weight from dbmaster.parent_type t union select 0, 'Özü', NULL, 0 from dual order by weight";
            leQohumType.Properties.DisplayMember = "TITLE";
            leQohumType.Properties.ValueMember = "ID";
            DataTable dt = con.GetDataTable(sql);
            leQohumType.Properties.DataSource = dt;            
        }        

        private void leQohumType_EditValueChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
            chbTesdiqlenib.Visible = (leQohumType.EditValue.ToString() != "0");
            browse_relative.Enabled = Convert.ToDecimal(leQohumType.EditValue) >= 0;
        }

        private void chbTesdiqlenib_CheckedChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ErrorProvider_relatives.ClearErrors();
            if (browse_relative.Tag == null || browse_relative.Tag.ToString() == "") ErrorProvider_relatives.SetError(browse_relative, "No relative selected");
            if (leQohumType.EditValue == null) ErrorProvider_relatives.SetError(leQohumType, "Relative type not selected");
            if (ErrorProvider_relatives.GetControlsWithError().Count > 0) return;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void browse_relative_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string StudID = "", EmpID = "";
            switch (disctype)
            {
                case 70: TMS.StudSearch.frmStudSEARCH stud = new TMS.StudSearch.frmStudSEARCH();
                         if (stud.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                         {
                            QohumTypeId = 0; browse_relative.Tag = browse_relative.Text = "";
                            StudID = stud.dgvSTUD_MAIN.SelectedRows[0].Cells["STUD_ID"].Value.ToString();
                            if (si.StudID == StudID) MessageBox.Show("The same Student with the same ID (" + StudID + ") can't be assigned as relative. Please, change your selection.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else try
                            {
                                string sql = "select si.gender_id from dbmaster.stud_info si where si.stud_id = :stud_id";
                                OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, StudID) };
                                OracleDataReader dr = con.execSQL(sql, prms);
                                if (dr.Read())
                                {
                                    if ((dr["GENDER_ID"].ToString() == leQohumType.GetColumnValue("GENDER_ID").ToString()) || (leQohumType.GetColumnValue("GENDER_ID").ToString() == ""))
                                    {
                                        browse_relative.Tag = StudID; 
                                        browse_relative.Text = String.Format("{0} {1}", stud.dgvSTUD_MAIN.SelectedRows[0].Cells["NAME"].Value, stud.dgvSTUD_MAIN.SelectedRows[0].Cells["SURNAME"].Value);
                                    }
                                    else
                                    {
                                        sql = "Relative type " + leQohumType.Text + " and the gender of Student - " + StudID + " is incompatable. Please, change your selection.";
                                        MessageBox.Show(sql, "GENDER INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Warning); StudID = string.Empty;
                                    }
                                }
                                dr.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + ex.StackTrace, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (StudID == "") return;
                         }
                break;
                case 72: findemp.frmFindEmp emp = new findemp.frmFindEmp();
                         if (emp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                         {
                            QohumTypeId = 0; browse_relative.Tag = browse_relative.Text = "";                
                            EmpID = emp.dgEmployee.SelectedRows[0].Cells["EMP_ID"].Value.ToString();

                            try
                            {
                                string sql = "select ei.sex_type_id gender_id from dbmaster.employee_info ei where ei.emp_id = :emp_id";
                                OracleParameter[] prms = { con.SetParameter("emp_id", OracleDbType.Char, 9, ParameterDirection.Input, EmpID) };
                                OracleDataReader dr = con.execSQL(sql, prms);
                                if (dr.Read())
                                {
                                    if ((dr["GENDER_ID"].ToString() == leQohumType.GetColumnValue("GENDER_ID").ToString()) || (leQohumType.GetColumnValue("GENDER_ID").ToString() == ""))
                                    {
                                        browse_relative.Tag = EmpID;
                                        browse_relative.Text = String.Format("{0} {1}", emp.dgEmployee.SelectedRows[0].Cells["NAME"].Value, emp.dgEmployee.SelectedRows[0].Cells["SNAME"].Value);
                                    }
                                    else
                                    {
                                        sql = "Relative type " + leQohumType.Text + " and the gender of Employee " + EmpID + " is INCOMPATABLE. Please, change your selection.";
                                        MessageBox.Show(sql, "GENDER INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Warning); EmpID = string.Empty;
                                    }
                                }
                                dr.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message + ex.StackTrace, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (EmpID == "") return;
                         }
                break;
                default : break;
            }
        }

        private void browse_relative_EditValueChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
        }
    }
}
