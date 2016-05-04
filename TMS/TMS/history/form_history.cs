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

namespace TMS.history
{
    public partial class form_history : DevExpress.XtraEditors.XtraForm
    {
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        public form_history()
        {
            InitializeComponent();
        }

        private void form_history_Load(object sender, EventArgs e)
        {
            string str_SQL = "";
            group_history.Text = si.StudID + " - " + si.SName + " " + si.SSName;            
            str_SQL = "select h.year, h.term, dp.title_en||' - '||dp.edu_lang as ixtisas, h.class, "+
                      "dbmaster.getempfullname(h.stud_rehber) as rəhbər, h.edu_year, h.fee_year, h.is_dovlet_sif as DS, h.is_prez_teq as PT from dbmaster.STUD_INFO_HIST h " +
                      "left outer join dbmaster.dep_programs dp on dp.prog_code = h.prog_code and dp.year = h.edu_year and dp.prog_type = 'M' " +
                      "left outer join dbmaster.employee e on e.emp_id = h.stud_rehber where dp.prog_type = 'M' and h.stud_id = '" + si.StudID + "' order by h.year, h.term";
            grid_history.DataSource = con.GetDataTable(str_SQL);
            view_history.BestFitColumns();
        }

        private void form_history_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void form_history_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }
    }
}