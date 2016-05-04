using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using DB;
using Globals;
namespace TMS.studCard
{
    public partial class frmStudCard : Form
    {
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        string card = "";
        public frmStudCard()
        {
            InitializeComponent();
        }

        private void frmStudCard_Load(object sender, EventArgs e)
        {
            string str_SQL;
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            image_stud.Image = mf.empImg.Image;
            label_class.Text = mf.txtClass.Text;
            label_dep.Text = mf.txtDep.Text;
            label_fullname.Text = mf.txtFullname.Text;
            label_parent.Text = mf.txtAtaAd.Text;
            label_studID.Text = mf.txtStud_id.Text;
            str_SQL = "select c.*, extract(day from (sysdate - c.print_date)) as gun from dbmaster.stud_cards c where c.son = 1 and c.stud_id = '" + si.StudID + "'";
            OracleDataReader dr = con.execSQL(str_SQL);
            if (dr.Read())
            {                
                button_print.Enabled = true;
                card = dr["CARD_NO"].ToString();
                group_card.Text = group_card.Text + " - " + card;
                button_preview.Enabled = (Convert.ToInt16(dr["GUN"].ToString()) >= 10);                             
            }
            else
            {
                button_print.Enabled = false;
                button_preview.Enabled = true;
                group_card.Text = "No card printed for selected Student...";
            }
            dr.Close();            
        }

        private void button_preview_Click(object sender, EventArgs e)
        {
            string str_SQL = ""; card = "";
            try
            {
                OracleParameter[] prms = 
                { 
                    con.SetParameter("STUDID", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID),                                                    
                    con.SetParameter("CARDID", OracleDbType.Char, 6, ParameterDirection.Output, "")                    
                };
                card = con.ExecSProcRetVal("dbmaster.print_stud_card", prms, "CARDID").ToString();                
                if (card.Length > 0)
                {
                    group_card.Text = "Number of LAST Printet CARD: " + card;
                    button_preview.Enabled = false;
                    button_print.Enabled = true;
                    
                    str_SQL = "select * from dbmaster.v_telebebilet v where v.stud_id = '" + si.StudID + "'";
                    DataTable dt = new DataTable(); dt = con.GetDataTable(str_SQL);

                    // Call this before loading your report 
                    /*FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                    fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                       FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                       FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                       FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;*/

                    FastReport.Report rStudCard = new FastReport.Report();
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudCard));
                    rStudCard.ReportResourceString = resources.GetString("rStudCard.ReportResourceString");
                    DataRow dr = dt.Rows[0];
                    rStudCard.RegisterData(dt, "Table");
                    rStudCard.GetDataSource("Table").Enabled = true;
                    rStudCard.Load(Properties.Settings.Default.CurProgDir + "/reports/student_card.frx");
                    rStudCard.SetParameterValue("card_id", card);
                    rStudCard.SetParameterValue("barcode", dr["STUD_ID"]);
                    rStudCard.Show();
                    rStudCard.Dispose();
                }
            }
            catch (OracleException oe) { MessageBox.Show(oe.Message); }                                   
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            FastReport.Report rStudCard = new FastReport.Report();
            string sql = "select * from dbmaster.v_telebebilet v where v.stud_id = :stud_id";
            OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID) };
            rStudCard.RegisterData(con.GetDataTable(sql, prms), "Table");
            rStudCard.GetDataSource("Table").Enabled = true;
            rStudCard.Load(Properties.Settings.Default.CurProgDir + "/reports/student_card.frx");
            rStudCard.SetParameterValue("card_id", card);
            //rStudCard.SetParameterValue("barcode", dr["STUD_ID"]);
            rStudCard.Show();
            rStudCard.Dispose();
        }

        private void frmStudCard_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }     
    }
}
