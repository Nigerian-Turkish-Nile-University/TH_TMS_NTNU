using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DB;
using Globals;
using Oracle.DataAccess.Client;
namespace TMS.stud_act_orders
{
    public partial class frmOrders : Form
    {
        oraConn con = oraConn.DB;
        Globals.loginUserInfo lui = new loginUserInfo();
        int ActionID = 0;
        public int DecID = 0;
        string SelectedActionTitle = "";
        public OperMode DecOperMode = OperMode.New;
        public frmOrders()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            loadDecision(0); //ckHamisi.Visible = false;
            getDecisionType(); ControlOper();
            if (DecOperMode == OperMode.View)
            {
                rbAdd.Enabled = rbDel.Enabled = ckHamisi.Enabled = false;
                rbChange.Enabled = true;
                rbChange.Select();
                Btnsec.Text = "Close";
            }
            ckHamisi.Text = txtOrderType.Text + " " + ckHamisi.Text;
        }

        private void ControlOper()
        {
            btnOper.Enabled = !((rbDel.Checked || rbChange.Checked) && gvDecision.SelectedRowsCount <= 0);
        }

        private void getDecisionType()
        {
            SelectedActionTitle = txtOrderType.Text;
            if (txtOrderType.Tag.ToString() != "")
                ActionID = Convert.ToInt32(txtOrderType.Tag);
        }   
        private void loadDecision(int act_id)
        {
            try
            {
                string cond = "";
                if (act_id > 0) cond = "and d.action_id = " + act_id; else cond = "and d.decision_id = " + DecID;

                string sql = "select d.decision_id, d.action_id, a.title_en as stud_action_title, d.decision_no, d.decision_subject, d.decision_content, d.decision_date " +
                             "from stud_decision d, stud_action a where d.action_id = a.stud_action_id " + cond + " order by d.decision_id desc";              
                gcDecision.DataSource = con.GetDataTable(sql);
            }
            catch (Exception e) { MessageBox.Show(e.Message, "Load Decision", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = txtDecContent.Text.Length; btnOper.Enabled = true;
            lQalanSinvolSayi.Text = "Characters left: " + (2000 - txtDecContent.Text.Length).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbDel.Checked) delDecison();
            else
            {
                if (rbAdd.Checked) insUpdStudDecison(1);
                else if (rbChange.Checked) insUpdStudDecison(2);
            }             
        }

        private void insUpdStudDecison(int oper)
        {            
            try
            {

                if ((oper == 1) && MessageBox.Show("Are you sure adding new data?", btnOper.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                else if ((oper == 2) && MessageBox.Show("Are you sure changing data?", btnOper.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                
                
                if ((oper == 2) && (gvDecision.SelectedRowsCount == 1))                    
                    DecID = Convert.ToInt32(gvDecision.GetRowCellValue(gvDecision.GetSelectedRows()[0], "DECISION_ID").ToString());

                if (oper == 2 && DecID == 0)
                {
                    MessageBox.Show("Decision is Missing", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (oper == 1 && ActionID == 0)
                {
                    MessageBox.Show("Order type is MISSING", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtDecSbj.Text == "")
                {
                    MessageBox.Show("Subject is Missing", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtDecNo.Text == "")
                {
                    MessageBox.Show("Document № is Missing", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                OracleParameter[] prms = 
                { 
                    con.SetParameter("pDECISION_ID", OracleDbType.Int32, 9,ParameterDirection.Input, DecID),                        
                    con.SetParameter("pACTION_ID", OracleDbType.Int16, 9,ParameterDirection.Input, ActionID),                        
                    con.SetParameter("pDECISION_DATE", OracleDbType.Date, 10,ParameterDirection.Input, dtpDecDate.Value),                    
                    con.SetParameter("pDECISION_SUBJECT", OracleDbType.Varchar2, 255,ParameterDirection.Input, txtDecSbj.Text),                        
                    con.SetParameter("pDECISION_CONTENT", OracleDbType.Varchar2, 2000,ParameterDirection.Input, txtDecContent.Text),                        
                    con.SetParameter("pDECISION_NO", OracleDbType.Varchar2, 100,ParameterDirection.Input, txtDecNo.Text),                        
                    con.SetParameter("pEMP_ID", OracleDbType.Int16, 4,ParameterDirection.Input, lui.EmpID),                    
                    con.SetParameter("OPER", OracleDbType.Int16, 4,ParameterDirection.Input, oper),
                    con.SetParameter("MSG_ID", OracleDbType.Int32, 4,ParameterDirection.Output, 0)                    
                };
                DecID = Convert.ToInt32(con.ExecSProcRetVal("ins_upd_stud_decision", prms, "MSG_ID").ToString());
                if ((DecID > 0) && (oper == 1)) //Qerar insert veya update oldusa, sadece o qerarı göstər...
                {
                    ckHamisi.Checked = false;
                    ckHamisi_CheckedChanged(null, null);
                }
                else
                {
                    btnOper.Enabled = false;
                    loadDecision(ckHamisi.Checked ? Convert.ToInt16(txtOrderType.Tag) : 0);
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "insUpdStudDecison", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void delDecison()
        {
            try
            {
                if (MessageBox.Show("Are you sure deleting data?", btnOper.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
               

                if (gvDecision.SelectedRowsCount == 1)
                    DecID = Convert.ToInt32(gvDecision.GetRowCellValue(gvDecision.GetSelectedRows()[0], "DECISION_ID").ToString());

                OracleParameter[] prms = { 
                    con.SetParameter("pDECISION_ID", OracleDbType.Int32, 9, ParameterDirection.Input, DecID),                                        
                    con.SetParameter("MSG_ID", OracleDbType.Int32, 4,ParameterDirection.Output, 0)                    
                    };
                int val = Convert.ToInt32(con.ExecSProcRetVal("dep_stud_decision", prms, "MSG_ID").ToString());
                if (val > 0)
                {
                    loadDecision(ckHamisi.Checked ? Convert.ToInt16(txtOrderType.Tag) : 0);
                    if (gvDecision.RowCount > 0) gvDecisionChange(); else txtDecNo.Text = txtDecSbj.Text = txtDecContent.Text = string.Empty;                    
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "delDecison", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
   

        private void rbAdd_CheckedChanged(object sender, EventArgs e)
        {
            btnOper.Text = "Add";
            txtDecContent.Text = txtDecNo.Text = txtDecSbj.Text = "";
            dtpDecDate.Value = DateTime.Now;
            txtOrderType.Text = SelectedActionTitle;
        }

        private void rdChange_CheckedChanged(object sender, EventArgs e)
        {
            btnOper.Text = "Change";           
            gvDecisionChange();
        }

        private void rbDel_CheckedChanged(object sender, EventArgs e)
        {            
            btnOper.Text = "Delete";            
            gvDecisionChange();
        }


        private void ckHamisi_CheckedChanged(object sender, EventArgs e)
        {            
            loadDecision(ckHamisi.Checked ? Convert.ToInt16(txtOrderType.Tag) : 0);
        }

        private void Btnsec_Click(object sender, EventArgs e)
        {
            try
            {
                if ((gvDecision.SelectedRowsCount == 1) && (gvDecision.GetRowCellValue(gvDecision.GetSelectedRows()[0], "DECISION_ID").ToString() != ""))
                    DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void dgvDecision_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Btnsec.PerformClick();
        }

        private void gvDecision_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gvDecisionChange();
        }

        private void gvDecisionChange()
        {
            try
            {
                ControlOper();
                txtDecNo.Enabled = txtDecSbj.Enabled = txtDecContent.Enabled = !rbDel.Checked;
                if ((DecOperMode == OperMode.View || rbChange.Checked || rbDel.Checked) && (gvDecision.SelectedRowsCount > 0))
                {
                    int SelRow = gvDecision.GetSelectedRows()[0];

                    txtOrderType.Text = gvDecision.GetRowCellValue(SelRow, "STUD_ACTION_TITLE").ToString();
                    txtDecNo.Text = gvDecision.GetRowCellValue(SelRow, "DECISION_NO").ToString();
                    txtDecSbj.Text = gvDecision.GetRowCellValue(SelRow, "DECISION_SUBJECT").ToString();
                    txtDecContent.Text = gvDecision.GetRowCellValue(SelRow, "DECISION_CONTENT").ToString();
                    if (gvDecision.GetRowCellValue(SelRow, "DECISION_DATE").ToString() != "")
                        dtpDecDate.Value = Convert.ToDateTime(gvDecision.GetRowCellValue(SelRow, "DECISION_DATE").ToString());
                }
            }
            catch (Exception) { }
        }

        private void gvDecision_DoubleClick(object sender, EventArgs e)
        {
            try 
            { 
                if(gvDecision.SelectedRowsCount > 0) Btnsec.PerformClick();
            }
            catch(Exception){}
        }
    }
}
