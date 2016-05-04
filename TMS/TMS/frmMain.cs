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
using DB;
using TMS.Properties;

namespace TMS
{
    public partial class frmMain : Form
    {
        General.functions f = new General.functions();
        loginUserInfo lui = new loginUserInfo();
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        String stud_fee_year;
        
        public frmMain()
        {
            string Lang = "en-US";   // Swiss German
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Lang);
            InitializeComponent();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            SetLogVal(int.Parse(Settings.Default.UserID));            
            menu_bolum_TH.Enabled = EnableDisableAcc(lui.EmpID, 43);
            menu_hesablama.Enabled = EnableDisableAcc(lui.EmpID, 39);
            menu_toplu_odeme.Enabled = EnableDisableAcc(lui.EmpID, 23);
            MenuItem_adaptation.Enabled = EnableDisableAcc(lui.EmpID, 78);
            MenuItem_ekdersMevacib.Enabled = EnableDisableAcc(lui.EmpID, 79);
        }

        public Boolean EnableDisableAcc(int EmpId, int componentID)
        {
            Boolean b = false;
            string sql = "select ai.acc_id, ai.acc_level, decode(ei.emp_id, NULL, 0, 1) icaze from dbmaster.acc_info ai " +
                         "left outer join dbmaster.emp_acc_info ei on ei.acc_id = ai.acc_id and ei.emp_id = " + EmpId.ToString() + " where ai.acc_id = " + componentID.ToString();
            OracleDataReader dr = con.execSQL(sql);
            if (dr.Read()) b = dr["ACC_LEVEL"].ToString() == "2" || dr["ICAZE"].ToString() == "1";
            dr.Close();            
            return b;
        }

        private void studSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                
                StudSearch.frmStudSEARCH frm = new TMS.StudSearch.frmStudSEARCH();
                frm.progressBar_images.Visible = frm.button_images.Visible = EnableDisableAcc(lui.EmpID, 22); frm.dgvSTUD_MAIN.MultiSelect = false;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (si.StudID != frm.dgvSTUD_MAIN.SelectedRows[0].Cells["stud_id"].Value.ToString()) 
                     foreach (Form chform in this.MdiChildren) if(chform.Tag != null) chform.Close();
                    si.SName = frm.dgvSTUD_MAIN.SelectedRows[0].Cells["NAME"].Value.ToString();
                    si.SSName = frm.dgvSTUD_MAIN.SelectedRows[0].Cells["surname"].Value.ToString();
                    si.StudID = frm.dgvSTUD_MAIN.SelectedRows[0].Cells["stud_id"].Value.ToString();
                    si.Kurs = Convert.ToInt16(frm.dgvSTUD_MAIN.SelectedRows[0].Cells["colclass"].Value.ToString());
                    si.DepID = frm.dgvSTUD_MAIN.SelectedRows[0].Cells["prog_code"].Value.ToString();
                    si.edu_year = edit_edu_year.Text = frm.dgvSTUD_MAIN.SelectedRows[0].Cells["edu_year"].Value.ToString();
                    si.eduLevel = frm.dgvSTUD_MAIN.SelectedRows[0].Cells["EDU_LEVEL"].Value.ToString();
                    label_activeForm.Text = si.StudID + " - " + si.SName + " " + si.SSName;                    
                    LoadStudInfo();
                }
            }
            catch (Exception) { }
        }

        public void LoadStudInfo()
        {            
            try
            {
                if (si.StudID.Length != 9) return;
                string year = f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), sem = f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString();
                label_TH.Text = year + " - " + sem + ". semestr FEE"; label_borc.Text = sem + ". semestr BALANCE"; label_odenen.Text = sem + ". semestr PAID";
                string sb = "select s.stud_id, s.name || ' ' || s.surname AS fullname, p.parent_info_name, el.title_en edu_level_title, "+
                            " et.title_en as education_type_title, sa.title_en as status_title, " +
                            "(select f.title_en from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.son = 1) as FAC, " +
                            "dp.title_en as dep, dp.edu_lang as lang_code, dp.prog_code as dep_id, s.status, " +
                            "(select s.title_en from stud_action s where s.stud_action_id = a.action_id) as qerar,"+
                            "dp.edu_level as edu_level_id, SF.FOTO, nvl(dbmaster.getempfullname(s.emp_id,'en'), 'N/A') as DANISMAN, " +
                            "AK_MEZUNIYYET_YOXLA(s.stud_id) as AK_MEZUNIYYET, si.fee_year, si.year, si.dovlet_sifarisli, "+
                            "dp.period_count as ntm, (select count(*) + 1 from stud_payments sp left outer join discounted_students ds on "+
                            "ds.stud_id = sp.stud_id and ds.discount_year = sp.payment_year and ds.discount_sem = sp.payment_sem and ds.is_active = 1 and ds.priority = 1 "+
                            "where (sp.is_manual = 1 or ds.discounts_id is not NULL) and sp.payment_code = 400 and sp.stud_id = s.stud_id and sp.payment_year||sp.payment_sem < " + year + sem + ") as muddet, " +                            
                            "(select count(*) from stud_action_used u where u.stud_id = s.stud_id and u.is_active = 1 and u.action_id = 11) as fail_count "+
                            "from dbmaster.students s left join  dbmaster.stud_info si on si.stud_id = s.stud_id left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                            "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                            "left join  dbmaster.stud_foto sf on sf.stud_id = s.stud_id left join  dbmaster.parent_info p on p.parent_type_id = 1 and p.stud_id = s.stud_id "+
                            "left join  dbmaster.edu_levels el on el.level_code = dp.edu_level left join  dbmaster.education_type et on et.education_type_id = dp.edu_type_id "+
                            "left join stud_action_used a on a.stud_id = s.stud_id and a.is_active = 1 and a.son = 1 left join  dbmaster.stud_status sa on sa.status_id = s.status "+
                            "where  dp.prog_type = 'M' and s.stud_id = '" + si.StudID + "'";
                
                OracleDataReader dr = con.execSQL(sb);
                if (dr.Read())
                {
                    txtAkMezuniyyet.Visible = false;
                    if (dr["AK_MEZUNIYYET"].ToString() == "1")
                    {
                        txtAkMezuniyyet.Visible = true;
                        txtAkMezuniyyet.Text = "Deferring date has expired";
                        MessageBox.Show("Deferring date of a Student has already expired", "Deferring date has expired", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {   
                        if (dr["STATUS"].ToString() == "1" && dr["NTM"].ToString() != "" && (Convert.ToInt16(dr["MUDDET"]) > Convert.ToInt16(dr["NTM"])))
                        {                            
                            txtAkMezuniyyet.Visible = true;
                            txtAkMezuniyyet.Text = "Normative education period expired";
                            if (Convert.ToInt16(dr["MUDDET"]) > (Convert.ToInt16(dr["NTM"]) + Convert.ToInt16(dr["FAIL_COUNT"])*2))
                                MessageBox.Show("Normative education period expired.\nIn order to continue education, you have to add FAIL order for Student.", "Normative education period", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    txtStud_id.Text = si.StudID;
                    si.year = dr["YEAR"].ToString();
                    txtStudAction.Tag = dr["STATUS"];                    
                    si.Fac = txtFac.Text = dr["FAC"].ToString();
                    txtFullname.Text = dr["FULLNAME"].ToString();
                    textBox_depID.Text = dr["DEP_ID"].ToString();
                    txtEduLevel.Tag = dr["EDU_LEVEL_ID"].ToString();
                    txtAtaAd.Text = dr["PARENT_INFO_NAME"].ToString();
                    txtStudAction.Text = dr["STATUS_TITLE"].ToString();
                    txtEduLevel.Text = dr["EDU_LEVEL_TITLE"].ToString();                    
                    txtEduType.Text = dr["EDUCATION_TYPE_TITLE"].ToString();
                    si.Danisman = txtDanisman.Text = dr["DANISMAN"].ToString();
                    edit_fee_year.Text = stud_fee_year = dr["FEE_YEAR"].ToString();
                    txtClass.Text = si.Kurs == 0 ? "HAZIRLIQ" : si.Kurs.ToString();
                    si.Dep = txtDep.Text = dr["DEP"].ToString() + " - " + dr["LANG_CODE"].ToString();                    
                    if (dr["QERAR"].ToString().Length > 0) txtStudAction.Text = txtStudAction.Text + " (" + dr["QERAR"].ToString() + ")"; 
                    if (dr["FOTO"].ToString() != "")
                    {
                        GenFunc foto = new GenFunc();
                        byte[] b = (byte[])dr["FOTO"];
                        foto.LoadImg(ref empImg, b);
                    }
                    else empImg.Image = TMS.Properties.Resources.no_foto;                                        
                }
                dr.Close();
                TH_REFRESH(si.StudID, year, sem);
            }
            catch (Exception ex) { MessageBox.Show("ERROR : " + ex.Message); }
        }

        public void TH_REFRESH(string pStud_ID, string pYear, string pSem) 
        {
            string str_SQL = string.Empty;            
            str_SQL = "select sp.payment_amount, nvl((sp.payment_amount + sp.payment_remainder) - p.payment_remainder, 0) as payment, h.fee_year, " +
                      "decode(h.is_dovlet_sif, 1, 'DS', nvl(p.payment_remainder, sp.payment_amount + sp.payment_remainder)) as remainder from stud_payments sp " +
                      "left outer join stud_payments p on p.stud_id = sp.stud_id and p.payment_year = sp.payment_year and p.payment_sem = sp.payment_sem and p.payment_active = 1 " +
                      "left outer join dbmaster.stud_info_hist h on h.stud_id = sp.stud_id and h.year = sp.payment_year and h.term = sp.payment_sem " +
                      "where sp.payment_code = 400 and sp.stud_id = '" + pStud_ID + "' and sp.payment_year = " + pYear + " and sp.payment_sem = " + pSem;

            txtTH.Text = txtThOde.Text = txtThBorc.Text = "N/A";
            OracleDataReader dr = con.execSQL(str_SQL);
            if (dr.Read())
            {
                edit_fee_year.Text = dr["FEE_YEAR"].ToString() == string.Empty ? stud_fee_year : dr["FEE_YEAR"].ToString();
                txtTH.Text = (dr["PAYMENT_AMOUNT"].ToString() == string.Empty) ? "N/A" : dr["PAYMENT_AMOUNT"].ToString();
                txtThBorc.Text = (dr["REMAINDER"].ToString() == string.Empty) ? "N/A" : dr["REMAINDER"].ToString(); 
                txtThOde.Text = (dr["PAYMENT"].ToString() == string.Empty) ? "N/A" : dr["PAYMENT"].ToString();
            }
            dr.Close();
        }

        private void SetLogVal(int empid)
        {            
            try
            {
                OracleParameter[] prms = { con.SetParameter("empid", OracleDbType.Int32, 9,ParameterDirection.Input, empid) };
                con.ExecSProcRetVal("LOG_USER_INFO", prms);
            }
            catch (Exception) { }
        }

        private void forma10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(cixarislar.frmForma10)) && si.isSelectStud())
            {
                cixarislar.frmForma10 frm = new TMS.cixarislar.frmForma10();
                frm.MdiParent = this; frm.Tag = si.StudID;
                frm.Show();
            }
        }

        private void arayisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(cixarislar.frmArayis)) && si.isSelectStud())
            {
                cixarislar.frmArayis frm = new TMS.cixarislar.frmArayis();
                frm.MdiParent = this; frm.Tag = si.StudID;
                frm.Show(); 
            }
        }

        private void müqaviləToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (si.isSelectStud())
            {
                try
                {
                    string sql = "select m.*, to_char(sysdate,'dd.mm.YYYY') as today, dbmaster.to_word(m.teh_haqq) as th_title from dbmaster.v_muqavile m where m.stud_id=:stud_id";
                    OracleParameter[] prms = { 
                           con.SetParameter("stud_id", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID)
                                         };
                    OracleDataReader dr = con.execSQL(sql, prms);
                    if (dr.Read())
                    {
                        FastReport.Report rMuqBak = new FastReport.Report();
                        if (txtEduLevel.Tag.ToString() == "1") rMuqBak.Load(Properties.Settings.Default.CurProgDir + "/reports/muqavile.frx");
                        else rMuqBak.Load(Properties.Settings.Default.CurProgDir + "/reports/muqavile_magistr.frx");

                        rMuqBak.SetParameterValue("stud_id", si.StudID);
                        rMuqBak.SetParameterValue("Fullname", dr["fullname"].ToString());
                        rMuqBak.SetParameterValue("passport", dr["passport_no"].ToString());
                        rMuqBak.SetParameterValue("adres", dr["unvan"].ToString());
                        rMuqBak.SetParameterValue("ata_ad", dr["val_fullname"].ToString());
                        rMuqBak.SetParameterValue("th", dr["teh_haqq"].ToString());
                        rMuqBak.SetParameterValue("th_title", dr["th_title"].ToString());
                        rMuqBak.SetParameterValue("dep", dr["bolum"].ToString());
                        rMuqBak.SetParameterValue("today", dr["today"].ToString());
                        rMuqBak.Show(); rMuqBak.Dispose();
                    }
                    if (!dr.IsClosed) dr.Close();
                }
                catch (Exception) { }
            }            
        }
        
        private bool isActive(Type typ)
        {
            bool found = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typ)
                {
                    f.Activate();
                    found = true;
                }
            }
            return found;
        }

        private void transkriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(trans.frmTrans)) && si.isSelectStud())
            {
                trans.frmTrans frm = new TMS.trans.frmTrans();
                frm.MdiParent = this; frm.Tag = si.StudID;              
                frm.Show();               
            }
        }

        private void parolVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (si.isSelectStud() && MessageBox.Show("Are you sure changing PASSWORD of " + si.StudID + " " + si.SName + " " + si.SSName, "CHANGE PASSWORD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OracleParameter[] prms = 
                    { 
                       con.SetParameter("studid", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID),
                       con.SetParameter("psw", OracleDbType.Varchar2, 32, ParameterDirection.Output,32)
                    };
                    string psw = con.ExecSProcRetVal("prSET_STUD_PSW", prms, "psw").ToString();

                    string msg = String.Format("\nStudent No: \t {0}\n", si.StudID);
                    msg += String.Format("\nName: \t\t {0}\n", si.SName);
                    msg += String.Format("\nSurname: \t\t {0}\n", si.SSName);
                    msg += String.Format("\nPASSWORD: \t\t {0}\n", psw);

                    MessageBox.Show(msg, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);                 
                }
            }
            catch (Exception) { MessageBox.Show("Error Occurred !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void odemeVeBaxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.TH.frmTH)) && si.isSelectStud())
            {               
                TH.frmTH frm = new TMS.TH.frmTH();
                frm.MdiParent = this; frm.Tag = si.StudID;
                frm.check_permissions.Enabled = EnableDisableAcc(int.Parse(Settings.Default.UserID), 8);
                frm.Show();
            }
        }

        public void qerarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.stud_orders.frmStudAction)))
            {
                stud_orders.frmStudAction frm = new TMS.stud_orders.frmStudAction();
                frm.MdiParent = this; frm.Tag = si.StudID;
                frm.Show(); 
            }           
        }        

        private void çıxışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupControl1_DoubleClick(object sender, EventArgs e)
        {           
            studSearchToolStripMenuItem_Click(sender, e);
        }

        private void pnlShow_DoubleClick_1(object sender, EventArgs e)
        {
            studSearchToolStripMenuItem_Click(sender, e);
        }       

        private void studCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.studCard.frmStudCard)) && si.isSelectStud())
            {
                if (Convert.ToInt16(txtStudAction.Tag) > 1) MessageBox.Show("Student ID is not active..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    studCard.frmStudCard frm = new TMS.studCard.frmStudCard();
                    frm.MdiParent = this; frm.Tag = si.StudID;
                    frm.Show();
                }
            }            
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (!isActive(typeof(TMS.TH.odeme)))
            {
                TH.odeme frm = new TMS.TH.odeme();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menu_diplom_bakalavr_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.cixarislar.diplom)) && si.isSelectStud())
            {
                cixarislar.diplom frm = new TMS.cixarislar.diplom(si.StudID);
                frm.MdiParent = this; frm.Tag = si.StudID;
                frm.Show();
            }
        }        

        private void menu_akademik_arayis_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.cixarislar.akademik)) && si.isSelectStud())
            {
                cixarislar.akademik frm = new TMS.cixarislar.akademik(si.StudID);
                frm.MdiParent = this; frm.Tag = si.StudID;
                frm.Show();
            }
        }

        private void menu_thstatistics_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.TH.THStatistics)))
            {
                TH.THStatistics frm = new TMS.TH.THStatistics();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void menu_diplom_magistr_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.cixarislar.magistr)) && si.isSelectStud())
            {
                cixarislar.magistr frm = new TMS.cixarislar.magistr(si.StudID);
                frm.MdiParent = this; frm.Tag = si.StudID;
                frm.Show();
            }
        }           
        
        private void menu_advisor_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.advisor.danisman)))
            {
                TMS.advisor.danisman d = new TMS.advisor.danisman();
                d.MdiParent = this; d.Tag = si.StudID;                
                d.Show();                
            }
        }

        private void menu_scores_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.trans.scores)) && si.isSelectStud())
            {                     
                string str_SQL = "select max(dr.year||dr.term) as il from dbmaster.ders_al_ref dr where dr.son = 1 and dr.stud_id = '" + si.StudID + "'";
                OracleDataReader dr = con.execSQL(str_SQL);
                if (dr.Read() && dr["il"].ToString().Length > 0)
                {
                    TMS.trans.scores frm = new TMS.trans.scores(); frm.MdiParent = this;
                    frm.max_year = dr["il"].ToString(); frm.Tag = si.StudID;             
                    frm.Show();
                }
                else MessageBox.Show("The Student didn't take any course..!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dr.Close();                
            }            
        }

        private void menu_hesabat_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(reports.statistics.reports)))
            {
                reports.statistics.reports reports = new reports.statistics.reports(Settings.Default.UserName, Settings.Default.UserPWD);
                if (!reports.IsDisposed)
                {
                    reports.MdiParent = this; reports.Show();
                    label_activeForm.Text = reports.Text;
                    button_up.PerformClick();
                }
            } 
        }

        private void menu_history_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.history.form_history)) && si.isSelectStud())
            {   
                TMS.history.form_history h = new TMS.history.form_history(); 
                h.MdiParent = this; h.Tag = si.StudID; h.Show();
            }
        }

        private void menu_hesablama_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.TH.hesablama)))
            {
                TH.hesablama frm = new TMS.TH.hesablama(); frm.Text = frm.Text + " : " + f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString() + " - " + f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString();
                frm.MdiParent = this; frm.Show();
            }
        }

        public void TH_DISCOUNTED_STUDENTS(string students, bool isManual, decimal amount = 0)
        {
            int year = 0, sem = 0;
            string cfg_key = string.Empty, pRes = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();

            if ((si.year == f.GetCfgActVal("STUD_REG_IL")[0].ToString()) && (si.year != f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString())) cfg_key = "STUD_REG_IL"; else cfg_key = "TEHSIL_HAQQI";
            year = Convert.ToInt16(f.GetCfgActVal(cfg_key)[0]); sem = Convert.ToInt16(f.GetCfgActVal(cfg_key)[1]);

            lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, -1, ParameterDirection.Input, students));
            lst.Add(con.SetParameter("pYear", OracleDbType.Int16, 4, ParameterDirection.Input, year));
            lst.Add(con.SetParameter("pSem", OracleDbType.Int16, 1, ParameterDirection.Input, sem));
            lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 18, ParameterDirection.InputOutput, isManual ? amount : -1));

            try
            {
                pRes = con.ExecSProcRetVal("TH_DISCOUNTED_STUDENTS", lst.ToArray(), "pRes").ToString();                
                if (students.Length == 9) switch (pRes)
                {
                    case "30": MessageBox.Show("The Student is deferred.\nSo, If student has any debd or payments, system will carry them into current semester.\nOTHERWISE, NO CALCULATION WILL TAKE PLACE..! ", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Warning); break;
                    case "31": MessageBox.Show("The status of Student is not active.\nSo, If student has any debt or payments, system will transfer them into current semester.\nOTHERWISE, NO CALCULATION WILL TAKE PLACE..! ", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Warning); break;
                    default: break;
                }
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        public void TH_STUD_FEE(string student)
        {
            int year = 0, sem = 0;
            string cfg_key = string.Empty, pRes = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();

            if ((si.year == f.GetCfgActVal("STUD_REG_IL")[0].ToString()) && (si.year != f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString())) cfg_key = "STUD_REG_IL"; else cfg_key = "TEHSIL_HAQQI";
            year = Convert.ToInt16(f.GetCfgActVal(cfg_key)[0]); sem = Convert.ToInt16(f.GetCfgActVal(cfg_key)[1]);

            lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, -1, ParameterDirection.Input, student));
            lst.Add(con.SetParameter("pYear", OracleDbType.Int16, 4, ParameterDirection.Input, year));
            lst.Add(con.SetParameter("pSem", OracleDbType.Int16, 1, ParameterDirection.Input, sem));

            try
            {
                con.ExecSProcRetVal("TH_STUD_FEE", lst.ToArray());
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void btmTopBottom_Click(object sender, EventArgs e)
        {
            if (panel2.Dock == DockStyle.Top)
            {
                panel2.Dock = DockStyle.Bottom;
                btmTopBottom.Image = Properties.Resources.m_arr_u;
                toolTip_TMS.SetToolTip(btmTopBottom, "Locate to top");
            }
            else
            {
                panel2.Dock = DockStyle.Top;
                btmTopBottom.Image = Properties.Resources.m_arr_d;
                toolTip_TMS.SetToolTip(btmTopBottom, "Locate to bottom");
            }
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            pnlShow.Visible = true;
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            pnlShow.Visible = false;
        }

        private void menu_bolum_TH_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(Maliyye_TH.frmTopluHesablamalar)))
            {
                Maliyye_TH.frmTopluHesablamalar bolum_TH = new Maliyye_TH.frmTopluHesablamalar(Settings.Default.UserName, Settings.Default.UserPWD);
                if (!bolum_TH.IsDisposed)
                {
                    bolum_TH.MdiParent = this; bolum_TH.Show();
                    label_activeForm.Text = bolum_TH.Text;                    
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string version, year = f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), sem = f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString();
            label_TH.Text = year + " - " + sem + ". semestr FEE"; label_borc.Text = sem + ". semestr BALANCE"; label_odenen.Text = sem + ". semestr PAID";

            Properties.Settings.Default.CurProgDir = System.IO.Directory.GetCurrentDirectory();
            version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); this.Text = this.Text + " - " + version;
            //timer_repair.Start();
            AlertOnlineOrder();
        }

        private void menu_fip_magistr_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.cixarislar.fip)) && si.isSelectStud())
            {
                cixarislar.fip fip = new TMS.cixarislar.fip(si.StudID);
                fip.MdiParent = this; fip.Tag = si.StudID; fip.group_fip.Text = menu_fip_magistr.Text;
                fip.Show(); 
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {            
            Settings.Default.UserID = Settings.Default.UserPWD = Settings.Default.UserFullName = null;
            Properties.Settings.Default.Save();
        }
        /*
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME) ShowMe();
            base.WndProc(ref m);
        }*/

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;            
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }
        //int i = 0;
        private void timer_repair_Tick(object sender, EventArgs e)
        {
            //if (!con.IsConAlive() && !con.RepairConn())
            
            //con.RepairConn(); label_activeForm.Text = (i++).ToString(); 
        }

        private void menu_journal_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.cixarislar.journal)))
            {
                cixarislar.journal frm = new TMS.cixarislar.journal();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void onlaynSifarişlərToolStripMenuItem_Click(object sender, EventArgs e)
        {     
            if (!isActive(typeof(stud_orders.frmOnlineOrders)))
            {
                stud_orders.frmOnlineOrders frm = new stud_orders.frmOnlineOrders();
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void tmrOnlineOrders_Tick(object sender, EventArgs e)
        {
            AlertOnlineOrder();
        }

        private void AlertOnlineOrder()
        {
            pbOnlineOrderAlert.Visible = GetActiveOnlineOrderCount() > 0;
        }

        private Int32 GetActiveOnlineOrderCount()
        {
            int say = 0;
            // Mühasebede görsenmemesi için
            if (lui.extra_field != "18100") try
            {
                string sql = "select count(*) say from dbmaster.online_doc_orders do where do.order_status=1";

                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read())
                {
                    say = Convert.ToInt32(dr["SAY"].ToString());
                }
                dr.Close();
                return say;
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }

        private void pbOnlineOrderAlert_Click(object sender, EventArgs e)
        {
            onlaynSifarişlərToolStripMenuItem_Click(sender, e);
        }

        private void MenuItem_adaptation_Click(object sender, EventArgs e)
        {            
            if (!isActive(typeof(adaptation.form_adaptation)) && si.isSelectStud())
            {   
                adaptation.form_adaptation adap = new TMS.adaptation.form_adaptation();
                adap.MdiParent = this; adap.Tag = si.StudID;
                adap.Show();
            }
        }

        private void MenuItem_ekdersMevacib_Click(object sender, EventArgs e)
        {
            if (!isActive(typeof(TMS.ekders.ekDers_mevacib)))
            {
                ekders.ekDers_mevacib frm = new TMS.ekders.ekDers_mevacib();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}