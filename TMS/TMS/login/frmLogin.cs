using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using DB;
using Oracle.DataAccess.Client;
using System.IO;
using Globals;
using TMS.Properties;

namespace TMS.login
{
    public partial class frmLogin : Form
    {
        private oraConn con = oraConn.DB;        
        private loginUserInfo lui = new loginUserInfo();              

        public frmLogin()
        {
            InitializeComponent();            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (edthname.Text.Trim() == "")
            {
                MessageBox.Show("Username is missing", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (edtpsw.Text.Trim() == "")
            {
                MessageBox.Show("Password is missing", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool isLogin = false;
                string sql = "select e.emp_id as emp_no, e.name, e.sname, eg.dep_code as dep, ai.acc_level, (select count(*) from dbmaster.emp_acc_info eai where eai.emp_id=e.emp_id and eai.acc_id = 4) as say " +
                             "from dbmaster.employee e left outer join dbmaster.acc_info ai on ai.acc_id=4 left outer join dbmaster.emp_gorev eg on eg.emp_id = e.emp_id and eg.esas_gorev = 1 and eg.status = 1 " +
                             "where e.hname =:login and e.passw = dbmaster.md5(:psw)"; 
                OracleParameter[] prms = 
                { 
                    con.SetParameter("login", OracleDbType.Varchar2, 20, ParameterDirection.Input, edthname.Text.Trim()),
                    con.SetParameter("psw", OracleDbType.Varchar2, 40,ParameterDirection.Input, edtpsw.Text.Trim())                  
                };               
                OracleDataReader dr = con.execSQL(sql, prms);
                if (dr.Read())
                {                    
                    if (dr["acc_level"].ToString() == "2" || Convert.ToInt16(dr["say"]) == 1)
                    {                        
                        lui.EmpID = Convert.ToInt32(dr["emp_no"]);
                        lui.EmpName = dr["name"].ToString();
                        lui.EmpSName = dr["sname"].ToString();
                        lui.extra_field = dr["dep"].ToString();
                        Settings.Default.UserName = edthname.Text.Trim();
                        Settings.Default.UserID = dr["EMP_NO"].ToString();
                        Settings.Default.UserPWD = General.functions.getMd5Hash(edtpsw.Text.Trim());
                        Settings.Default.UserFullName = dr["NAME"].ToString() + " " + dr["SNAME"].ToString();                        
                        isLogin = true;
                        Close();
                    }
                    else
                    {
                        dr.Close();
                        isLogin = false;
                        MessageBox.Show("You don't have permission to use this program..!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        edthname.Text = "";
                        edtpsw.Text = "";
                        return;
                    }
                }
                dr.Close();
                if (!isLogin) MessageBox.Show("Username or password is invalid..!", "INVALID DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edtpsw.Text = "";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void edthname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender,e);
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void edtpsw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e);
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lui.EmpID <= 0)
            {
                Application.Exit();
            }
            else Dispose();            
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {            
            if (Properties.Settings.Default.UserName != "")
            {
                edthname.Text = Properties.Settings.Default.UserName;
                edtpsw.Focus();
            } 
            else edthname.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Caramel";
            if (!VersionControl()) this.Dispose();
        }

        private bool VersionControl()
        {
            //MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); this.Text = this.Text + " " + version;
            string sql = "select v.status, vc.description, vc.version from dbmaster.version_control v left outer join dbmaster.version_control vc on vc.acc_id = v.acc_id and vc.status = 1 " +
                         " where v.acc_id = " + Settings.Default.ModId.ToString() + " and v.version = '" + version + "'";
            try
            {
                OracleDataReader dr = con.execSQL(sql); //MessageBox.Show(dr.FieldCount + " - " + dr.GetName(dr.FieldCount - 1) + " - " + dr.GetFieldType(0) + " - " + dr.GetDataTypeName(0));  
                if (dr.Read())
                {
                    string msgText = "";
                    switch (Convert.ToInt32(dr["STATUS"]))
                    {
                        case 0: //Passivdir, Eger mesaj varsa, mesaji cixar, yoxdursa default mesaj ver
                        {                            
                            msgText = "This (" + version + ") version of program is fall out of use.\nPlease, get new version..!\n\n";
                            if (dr["DESCRIPTION"].ToString().Trim().Length > 0) msgText += "NEW VERSION - " + dr["VERSION"].ToString() + " : " + dr["DESCRIPTION"].ToString();
                            MessageBox.Show(msgText, Settings.Default.ProgramName + " - " + version, MessageBoxButtons.OK, MessageBoxIcon.Error);                            
                            return false;
                        }
                        case 1: return true; //Aktivdir                       
                        case 2: ///Versiya kohnedir, ancaq istifadə oluna bilər.
                        {
                            msgText = "This (" + version + ") version of program obselete.\nWe recommend you to get new version..!\n\n";
                            if (dr["DESCRIPTION"].ToString().Trim().Length > 0) msgText += "NEW VERSION - " + dr["VERSION"].ToString() + " : " + dr["DESCRIPTION"].ToString();
                            MessageBox.Show(msgText, Settings.Default.ProgramName + " - " + version, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        default:
                        {
                            MessageBox.Show("Version of program couldn't be checked, state (" + dr["STATUS"].ToString() + ") of version is missing..!", Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return true;
                        }
                    }                    
                }
                else
                {
                    MessageBox.Show("This version " + version + " of program, not released for use yet.", Settings.Default.ProgramName + " - Version info is missing.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Version check ERROR: " + ex.Message, Settings.Default.ProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            return false;
        }
    }
}
