using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DB;
using Oracle.DataAccess.Client;

namespace findemp
{
    public partial class frmFindEmp : Form
    {
        private int type = 0;
        private oraConn con = oraConn.DB;
        private BindingSource b = new BindingSource();
        public frmFindEmp()
        {
            InitializeComponent();
        }

        public frmFindEmp(int _type)
        {
            InitializeComponent();
            type = _type;
        }

        private void frmFindEmp_Load(object sender, EventArgs e)
        {
            string str_SQL = "select emp_id, name, sname, e.hname from dbmaster.employee e where e.state = 1 ";
            if (type == 7) str_SQL = str_SQL + "and exists (select eg.emp_id from dbmaster.emp_gorev eg where eg.emp_id = e.emp_id and eg.gorev_id = 7 and eg.status = 1) ";
            str_SQL = str_SQL + " order by e.name, e.sname";
            
            b.DataSource = con.GetDataTable(str_SQL);
            dgEmployee.DataSource = b;            
            dgEmployee.Columns["hname"].HeaderText = "Username";            
        }

        private void btnsec_Click(object sender, EventArgs e)
        {
            if (dgEmployee.SelectedRows.Count == 1) DialogResult = DialogResult.OK;
            else MessageBox.Show("Please, select data..!", "No Data Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }
        
        private void filter() 
        {  
            b.Filter = " name like '" + edtname.Text.Replace("'", "''").Trim() + "%'";
            b.Filter = b.Filter + " and sname like '" + edtsname.Text.Replace("'", "''").Trim() + "%'";
            b.Filter = b.Filter + " and hname like '" + edthname.Text.Replace("'", "''").Trim() + "%'";
            if (dgEmployee.RowCount == 0) image_employee.Image = TMS.Properties.Resources.no_foto;
            btnsec.Enabled = (dgEmployee.RowCount > 0);
        }

        private void edtsname_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void edtname_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void edthname_TextChanged(object sender, EventArgs e)
        {
            filter();            
        }
        
        private void dgEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnsec_Click(sender, e);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
     
        private void edtname_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter) btnsec.PerformClick();
            if (e.KeyCode == Keys.Escape) this.Close();  
        }       

        private void dgEmployee_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT FOTO from dbmaster.emp_FOTO WHERE length(foto) > 0 and emp_id = " + dgEmployee.SelectedRows[0].Cells["emp_id"].Value.ToString();
                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read())
                {
                    byte[] byteData = (byte[])(dr["foto"]);
                    if (byteData.Length > 0)
                    {
                        // Open a stream for the image and write the bytes into it
                        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteData, true);
                        stream.Write(byteData, 0, byteData.Length);
                        // Create a bitmap from the stream
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
                        image_employee.Image = bmp;
                        // Close the stream
                        stream.Close();
                    }
                    else image_employee.Image = TMS.Properties.Resources.no_foto;
                }
                else image_employee.Image = TMS.Properties.Resources.no_foto;
                dr.Close();
            } 
            catch (Exception ) 
            { 
                //MessageBox.Show(ex.Message); 
            }
        }
      
    }
}