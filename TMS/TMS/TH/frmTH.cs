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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
namespace TMS.TH
{
    public partial class frmTH : Form
    {
        loginUserInfo lui = new loginUserInfo();
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        bool available = false;
        int i = -1;

        readonly BindingSource bind = new BindingSource();
        General.functions f = new General.functions();        

        public enum _formMod { New, Edit };
        public _formMod formMod = _formMod.New;

        public frmTH()
        {
            InitializeComponent();
        }

        private void frmTH_Load(object sender, EventArgs e)
        {            
            if (si.isSelectStud()) LoadStudTH();            
        }

        private void LoadStudTH()
        {
            string str_SQL = string.Empty;
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            try
            {
                if (si.StudID.Length != 9) return; 
                str_SQL = "select sp.payment_year, sp.payment_sem, (select nvl(sum(cf.amount),0) from campus_fee cf where cf.stud_id = sp.stud_id and cf.fee_year = sp.payment_year and cf.fee_sem = sp.payment_sem) as campus_fee, " +
                          "(sp.payment_amount - (select nvl(sum(cf.amount),0) from campus_fee cf where cf.stud_id = sp.stud_id and cf.fee_year = sp.payment_year and cf.fee_sem = sp.payment_sem)) as TH, " +
                          "sp.payment_remainder, (sp.payment_amount + sp.payment_remainder) as borc, nvl((sp.payment_amount + sp.payment_remainder) - p.payment_remainder, 0) as odeme, " +
                          "h.is_dovlet_sif as ds, nvl(p.payment_remainder, sp.payment_amount + sp.payment_remainder) as qaliq, " +
                          "decode(sp.is_manual, 0, 'AUTO', 'MANUAL') as tip from stud_payments sp left outer join dbmaster.stud_info_hist h on h.stud_id = sp.stud_id and h.year = sp.payment_year and h.term = sp.payment_sem " +                          
                          "left outer join stud_payments p on p.stud_id = sp.stud_id and p.payment_year = sp.payment_year and p.payment_sem = sp.payment_sem and p.payment_active = 1 " +
                          "where sp.stud_id = '" + si.StudID + "' and sp.payment_code = 400 order by sp.payment_year, sp.payment_sem";

                dgvTH.DataSource = con.GetDataTable(str_SQL);
                if (i < 0) i = (dgvTH.RowCount - 1);
            }
            catch (OracleException ex) 
            {
                if (ex.Number == 1422) MessageBox.Show("More than 1 Fee was calculated in the same semester. System, can't decide which to show.", "FEE PROBLEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show(ex.Message); 
            }
            if (dgvTH.RowCount > 0) dgvTH.CurrentCell = dgvTH.Rows[i].Cells[0];
            cmbDiscountType.Enabled = mf.EnableDisableAcc(lui.EmpID, 41);
            btnOde.Enabled = mf.EnableDisableAcc(lui.EmpID, 40);
        }

        private void LoadStudOde()
        {
            try
            {
                string str_SQL = string.Empty;
                if ((si.StudID.Length != 9) || (dgvTH.SelectedRows.Count <= 0)) return;
                //ckIsManualTH.Checked = dgvTH.SelectedRows[0].Cells["IS_MANUAL"].Value.ToString() == "MANUAL";
                int year = Convert.ToInt16(dgvTH.SelectedRows[0].Cells["payment_year"].Value), sem = Convert.ToInt16(dgvTH.SelectedRows[0].Cells["Semestr"].Value);
                
                str_SQL = "select to_char(sp.payment_date, 'dd.mm.yyyy') as payment_date, sp.payment_year, sp.payment_sem, sp.payment_amount, sp.payment_remainder, pc.payment_code_title , " +
                          "dbmaster.to_word(substr(to_char(abs(sp.payment_amount), '99999.99'), 1, instr(to_char(abs(sp.payment_amount), '99999.99'), '.') - 1)) as manat, " +
                          "dbmaster.to_word(substr(to_char(abs(sp.payment_amount), '99999.99'), instr(to_char(abs(sp.payment_amount), '99999.99'),'.') + 1)) as qepik, " +
                          "sp.payment_id from stud_payments sp left outer join payment_code pc on pc.payment_code_id = sp.payment_code " +
                          "where pc.is_payment = 1 and sp.payment_year = :year and sp.payment_sem = :sem and sp.stud_id = :stud_id order by sp.payment_date, sp.payment_id";

                OracleParameter[] prms = 
                { 
                    con.SetParameter("sem", OracleDbType.Int16, 4,ParameterDirection.Input, sem),
                    con.SetParameter("year", OracleDbType.Int16, 4,ParameterDirection.Input, year),
                    con.SetParameter("stud_id", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID)                           
                };
                dgvStudOde.DataSource = con.GetDataTable(str_SQL, prms);
                btnPrint.Enabled = dgvStudOde.RowCount > 0;
            }
            catch (Exception ) {  }
        }

        private void dgvTH_SelectionChanged(object sender, EventArgs e)
        {
            LoadStudOde();
        }

        private void chIsManualTH_CheckedChanged(object sender, EventArgs e)
        {
            nudManualTH.Visible = lManualTH.Visible = ckIsManualTH.Checked;
        }

        private void btnTHhesabla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ReCalculating the FEE?", "FEE CALCULATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
                mf.TH_DISCOUNTED_STUDENTS(si.StudID, ckIsManualTH.Checked, nudManualTH.Value); 

                if (dgvTH.SelectedRows.Count == 1) LoadStudOde(); LoadStudTH();
                mf.TH_REFRESH(si.StudID, f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
            }
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            string msg = string.Empty, title = string.Empty;

            if (rbYeni.Checked) { msg = "Are you sure to add PAYMENT?"; title = "PAYMENT"; }
            if (rbSil.Checked) { msg = "Last payment will be deleted. \nAre you sure deleting last PAYMENT?"; title = "Delete"; }
            if (MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TH_STUD_PAYMENT(rbSil.Checked);
            }
            mf.TH_REFRESH(si.StudID, f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
            if (dgvStudOde.RowCount > 0) dgvStudOde.Rows[(dgvStudOde.RowCount - 1)].Selected = true;
        }

        private void TH_STUD_PAYMENT(bool isRemove)
        {
            string pRes = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();

            lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID));
            lst.Add(con.SetParameter("pDate", OracleDbType.Varchar2, 10, ParameterDirection.Input, dtpOdemeTarix.Text));
            lst.Add(con.SetParameter("pAmout", OracleDbType.Decimal, 8, ParameterDirection.Input, nudOdeme.Value));
            lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 2, ParameterDirection.InputOutput, isRemove ? -1 : 100));

            try
            {
                pRes = con.ExecSProcRetVal("TH_STUD_PAYMENT", lst.ToArray(), "pRes").ToString(); //MessageBox.Show(pRes);
                if (pRes == "1") MessageBox.Show("FEE not Calculated for the current Year - Semester..! ", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else { LoadStudTH(); LoadStudOde(); }
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }                        
        }

        private void rbYeni_CheckedChanged(object sender, EventArgs e)
        {
            btnOde.Text = "Add";
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            btnOde.Enabled = mf.EnableDisableAcc(lui.EmpID, 40);
        }

        private void rbSil_CheckedChanged(object sender, EventArgs e)
        {
            btnOde.Text = "Remove";
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            btnOde.Enabled = mf.EnableDisableAcc(lui.EmpID, 40) && dgvStudOde.RowCount > 0;
        }

        private void btnEndirimAdd_Click(object sender, EventArgs e)
        {
            if (dgvTH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Discount can't be added unless FEE calculated for the current semester.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbDiscountType.SelectedValue.ToString() != "0" && (MessageBox.Show("Are you sure to add?", "Discount - Extra Fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (tabControl_TH.SelectedIndex == 2) TH_CAMPUS_FEE(Convert.ToInt32(cmbDiscountType.SelectedValue)); // Əlavələr tabındadırsa, TH_CAMPUS_FEE şeklinde elave ele...
                else // Deyilse bax, özel endirimdirse TH_CUSTOM_DISCOUNT, deyilse normal endirim(TH_DISCOUNT_ADD) kimi əlavə et. 
                {
                    if (cmbDiscountType.SelectedValue.ToString() == "581") TH_CUSTOM_DISCOUNT();
                    else TH_DISCOUNT_ADD(cmbDiscountType.SelectedValue.ToString());
                }
                TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
                LoadStudTH(); LoadDiscountStudList(); LoadStudOde();
                cmbDiscountType_SelectionChangeCommitted(sender, e);                 
                mf.TH_REFRESH(si.StudID, f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
            }       
        }

        private void TH_CUSTOM_DISCOUNT()
        {
            if (nudOzelEndirim.Value > 0)
            {
                string pRes = string.Empty;
                List<OracleParameter> lst = new List<OracleParameter>();

                lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID));                
                lst.Add(con.SetParameter("pAmount", OracleDbType.Decimal, 8, ParameterDirection.Input, nudOzelEndirim.Value));
                lst.Add(con.SetParameter("pRecur", OracleDbType.Int16, 1, ParameterDirection.Input, ckOzelEndirim.Checked ? 1 : 0));
                lst.Add(con.SetParameter("pRes", OracleDbType.Int16, 2, ParameterDirection.InputOutput, 0));

                try
                {
                    pRes = con.ExecSProcRetVal("TH_CUSTOM_DISCOUNT", lst.ToArray(), "pRes").ToString(); //MessageBox.Show(pRes);
                    if (pRes == "1") MessageBox.Show("Cari ildə eyni tip özəl endirim mövcuddur", "Əməliyyat baş tutmadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else { LoadStudTH(); LoadStudOde(); LoadDiscountStudList(); }
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
            else MessageBox.Show("Amount of Special Discount is Missing!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TH_CAMPUS_FEE(int discount)
        {
            if (nudYataqxanaPul.Value > 0)
            {
                string pRes = string.Empty;
                List<OracleParameter> lst = new List<OracleParameter>();

                lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID));
                lst.Add(con.SetParameter("pAmount", OracleDbType.Decimal, 8, ParameterDirection.Input, nudYataqxanaPul.Value));                
                lst.Add(con.SetParameter("pRes", OracleDbType.Int16, 5, ParameterDirection.InputOutput, discount));

                try
                {
                    pRes = con.ExecSProcRetVal("TH_CAMPUS_FEE", lst.ToArray(), "pRes").ToString(); //MessageBox.Show(pRes);
                    if (pRes == "1") MessageBox.Show(cmbDiscountType.Text + " already exists in current semester", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else { LoadStudTH(); LoadStudOde(); LoadDiscountStudList(); }
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
            else MessageBox.Show("Amount of " + cmbDiscountType.Text + " is missing..!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);        
        }
        
        private void TH_DISCOUNT_ADD(string discount)
        {
            if (discount != "0")
            {
                int year = 0, sem = 0;
                TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
                string pRes = string.Empty, cfg_key = string.Empty;
                List<OracleParameter> lst = new List<OracleParameter>();
                
                if ((si.year == f.GetCfgActVal("STUD_REG_IL")[0].ToString()) && (si.year != f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString())) cfg_key = "STUD_REG_IL"; else cfg_key = "TEHSIL_HAQQI";
                year = Convert.ToInt16(f.GetCfgActVal(cfg_key)[0]); sem = Convert.ToInt16(f.GetCfgActVal(cfg_key)[1]);

                lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID));
                lst.Add(con.SetParameter("pDiscount", OracleDbType.Int16, 5, ParameterDirection.Input, discount));
                lst.Add(con.SetParameter("pYear", OracleDbType.Int16, 4, ParameterDirection.Input, year));
                lst.Add(con.SetParameter("pSem", OracleDbType.Int16, 1, ParameterDirection.Input, sem));
                lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 18, ParameterDirection.InputOutput, 0));

                try
                {
                    pRes = con.ExecSProcRetVal("TH_DISCOUNT_ADD", lst.ToArray(), "pRes").ToString(); //MessageBox.Show(pRes);                    
                    switch (pRes)
                    {
                        case "0"    : mf.TH_STUD_FEE(si.StudID); if (dgvTH.SelectedRows.Count == 1) LoadStudOde(); LoadStudTH(); break;
                        case "20"   : MessageBox.Show("Discount is already exists!", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "58"   : MessageBox.Show("Only one discount can be added in the same semester!", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "71"   : MessageBox.Show("System, couldn't find any relative working in one of PARTNER Companies", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "200"  : MessageBox.Show("Bu endirim üçün tələbə, bakalavr və 2007 sonrası LİSEY mezunu olmalı.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "288"  : MessageBox.Show("System, couldn't find any relative working at NTNU", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "289"  : MessageBox.Show("System, couldn't find any brother or sister studying at NTNU.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "290"  : MessageBox.Show("Bu endirim üçün tələbə, bakalavr və 2008 öncesi LİSEY mezunu olmalı.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "291"  : MessageBox.Show("Bu endirim üçün tələbə, bakalavr və 2004 sonrası ARAZ mezunu olmalı.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "293"  : MessageBox.Show("Bu endirim üçün tələbə Qafqaz Universitetini ilk 5 tercihdə yazmalı, bakalavr və 2010 sonrası ARAZ vəya LİSEY mezunu olmalı.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "941"  : MessageBox.Show("Student is not immigrant.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "1256" : MessageBox.Show("Bu endirim üçün tələbə, magistr və Qafqaz Universiteti məzunu olmalı.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        case "1381" : MessageBox.Show("Bu endirim üçün tələbə, bakalavr və 2005 öncəsi ARAZ mezunu olmalı.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                        default     : MessageBox.Show("There is NOT any RULE for discount, " + cmbDiscountType.Text, "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    }
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
            else MessageBox.Show("Discount type is Missing..!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LoadDiscountStudList()
        {
            try
            {
                string str_SQL = string.Empty;
                if ((si.StudID.Length != 9) || (dgvTH.SelectedRows.Count <= 0)) return;   
                int year = Convert.ToInt16(dgvTH.SelectedRows[0].Cells["payment_year"].Value), sem = Convert.ToInt16(dgvTH.SelectedRows[0].Cells["Semestr"].Value);
                str_SQL = "select ds.discounts_id, ds.discount_year, ds.discount_sem, decode(d.d_type_id, 2, dt.discount_type_title, (select t.filter||' - '||t.discount_type_title from discount_type t where t.discount_type_id = df.discount_type_id)) as discount_title, ds.disc_amount, " +
                          "case when ds.discounts_id = 581 then  decode(ds.disc_amount, NULL, (select '[ ' || sum(cd.amount) / 2 || ' AZN ]' from custom_discount cd " +
                          "where cd.stud_id = ds.stud_id and (cd.custom_discount_year = ds.discount_year or (cd.disc_apply_reccur = 1 and cd.custom_discount_year <= ds.discount_year and ds.discount_year||ds.discount_sem < 20122))), '[ ' || ds.disc_amount || ' AZN ]') " +
                          "when dt.is_discount = 0 then (select '[ ' || cf.amount || ' AZN ]' from campus_fee cf where cf.stud_id = ds.stud_id and cf.fee_year = ds.discount_year and cf.fee_sem = ds.discount_sem and cf.discount_id = ds.discounts_id) " +
                          "else to_char(d.discounts_amount) end discounts_amount, decode(ds.discounts_id, 581, (select wm_concat(cd.disc_apply_reccur) from custom_discount cd where cd.stud_id = ds.stud_id and cd.custom_discount_year = ds.discount_year), '') as davamli, " +
                          "ds.is_active from discounted_students ds left outer join discounts d on d.discounts_id = ds.discounts_id left outer join discount_type dt on dt.discount_type_id = d.discountstype left outer join dep_fee df on df.dep_fee_id = d.discountstype " +
                          "where ds.stud_id = :stud_id and ds.discount_year = :year and ds.discount_sem = :sem";                    

                OracleParameter[] prms = 
                { 
                    con.SetParameter("sem", OracleDbType.Int16, 4,ParameterDirection.Input, sem),
                    con.SetParameter("year", OracleDbType.Int16, 4,ParameterDirection.Input, year),
                    con.SetParameter("stud_id", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID)                           
                };                
                dgvDiscountStudList.DataSource = con.GetDataTable(str_SQL, prms);
                dgvDiscountStudList.Columns["disc_amount"].DisplayIndex = 4;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        private void LoadTelebeRelativeInfo(int type)
        {
            string str_SQL = string.Empty;
            Image img = TMS.Properties.Resources.no_foto;
            if (si.StudID.Length == 9) try
            {
                OracleDataReader dr = null;
                switch (type)
                {
                    case 71     : tree_relative_partners.ClearNodes();
                                  str_SQL = "select pd.info_id, nvl(pd.rel_type_id, 0) as rtID, nvl(pt.title_en, 'him/her self') as pt_Title, pd.approved, pd.company_id, a.title as company, pd.name, pd.surname " +
                                            "from partner_disc_info pd left outer join dbmaster.parent_type pt on pt.parent_type_id = pd.rel_type_id left outer join dbmaster.addable_titles a on a.title_id = pd.company_id " +
                                            "where pd.stud_id = :studID";
                    break;
                    case 288    : tree_relative_employee.ClearNodes();
                    str_SQL = "select r.rel_id, r.rel_type_id, pt.title_en, r.tesdiqlenib, r.relative_emp_id, dbmaster.getempfullname(r.relative_emp_id, 'az') qohum_ad, " +
                                            "(select ei.sex_type_id from dbmaster.employee_info ei where ei.emp_id = r.relative_emp_id) gender_id from dbmaster.stud_relative r " +
                                            "left join dbmaster.parent_type pt on pt.parent_type_id = r.rel_type_id where r.relative_emp_id is not NULL and r.stud_id = :studID " +
                                            "UNION select i.id, 0, 'Özü', 0, i.emp_id, (select e.name || ' ' || e.sname from dbmaster.employee e where e.emp_id = i.emp_id), " +
                                            "(select ei.sex_type_id from dbmaster.employee_info ei where ei.emp_id = i.emp_id) from dbmaster.stud_emp_identity i where i.emp_id is not NULL and " +
                                            "i.identity_id = (select se.identity_id from dbmaster.stud_emp_identity se where se.stud_id = :studID)";
                    break;
                    case 289     : tree_relative_students.ClearNodes();
                                   str_SQL = "select r.rel_id, r.rel_type_id, pt.title_en, r.tesdiqlenib, r.relative_stud_id, " +
                                             "(select s.name || ' ' || s.surname from dbmaster.students s where s.stud_id = r.relative_stud_id) as qohum_ad, " +
                                             "(select si.gender_id from dbmaster.stud_info si where si.stud_id = r.relative_stud_id) gender_id from dbmaster.stud_relative r " +
                                             "left join dbmaster.parent_type pt on pt.parent_type_id = r.rel_type_id where r.relative_stud_id is not NULL and r.stud_id = :studID " +
                                             "UNION select i.id, 0, 'Özü', 0, i.stud_id, (select st.name || ' ' || st.surname from dbmaster.students st where st.stud_id = i.stud_id), " +
                                             "(select si.gender_id from dbmaster.stud_info si where si.stud_id = i.stud_id) from dbmaster.stud_emp_identity i where i.stud_id is not NULL and " +
                                             "i.stud_id != :studID and i.identity_id = (select se.identity_id from dbmaster.stud_emp_identity se where se.stud_id = :studID)";
                    break;
                    default: str_SQL = string.Empty; break;
                }
                
                OracleParameter[] prms = { con.SetParameter("studID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID) };
                if (str_SQL.Length > 0)  dr = con.execSQL(str_SQL, prms);                
                while (dr.Read())
                {
                    TreeListNode node = null;
                    switch (type)
                    {
                        case 71     : tree_relative_partners.BeginUnboundLoad();
                                      node = tree_relative_partners.AppendNode(new object[] { Convert.ToInt32(dr["INFO_ID"]), "İşçi", dr["PT_TITLE"].ToString(), dr["NAME"].ToString(), dr["SURNAME"].ToString(), dr["COMPANY"].ToString(), Convert.ToInt32(dr["RTID"]), dr["COMPANY_ID"].ToString(), Convert.ToInt16(dr["APPROVED"]) }, null);
                                      tree_relative_partners.EndUnboundLoad();
                        break;
                        case 288    : img = con.GetImageBySql("select ef.foto from dbmaster.emp_foto ef where ef.emp_id = " + dr["RELATIVE_EMP_ID"].ToString());
                                      node = AppendCustomNodeQohum(tree_relative_employee, Convert.ToInt32(dr["REL_ID"]), "İşçi", dr["QOHUM_AD"].ToString(), dr["REL_TYPE_ID"].ToString() == "" ? 0 : Convert.ToInt32(dr["REL_TYPE_ID"]), dr["title_en"].ToString(), dr["RELATIVE_EMP_ID"].ToString(), img, Convert.ToInt16(dr["TESDIQLENIB"]));                                                                            
                        break;
                        case 289: img = con.GetImageBySql("select f.foto from dbmaster.stud_foto f where f.stud_id = " + dr["RELATIVE_STUD_ID"].ToString());
                                      node = AppendCustomNodeQohum(tree_relative_students, Convert.ToInt32(dr["REL_ID"]), "Tələbə", dr["QOHUM_AD"].ToString(), dr["REL_TYPE_ID"].ToString() == "" ? 0 : Convert.ToInt32(dr["REL_TYPE_ID"]), dr["title_en"].ToString(), dr["RELATIVE_STUD_ID"].ToString(), img, Convert.ToInt16(dr["TESDIQLENIB"]));                                       
                        break;
                        default: break;
                    }
                    node.ImageIndex = node.SelectImageIndex = 0; node.TreeList.BestFitColumns();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeListNode AppendCustomNodeQohum(TreeList tl, int PrimaryID, string personTypeTitle, string personFullname, int relTypeId, string relTypeTitle, string personID, Image photo, int tesdiqlenib)
        {
            tl.BeginUnboundLoad();
            TreeListNode n = tl.AppendNode(new object[] { PrimaryID, personTypeTitle, personID, personFullname, relTypeId, relTypeTitle, photo, tesdiqlenib }, null);
            tl.EndUnboundLoad();
            return n;
        }

        private void btnEndirimDelete_Click(object sender, EventArgs e)
        {
            int discount, year, sem;
            string cfg_key = string.Empty;
            if ((si.year == f.GetCfgActVal("STUD_REG_IL")[0].ToString()) && (si.year != f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString())) cfg_key = "STUD_REG_IL"; else cfg_key = "TEHSIL_HAQQI";            
            year = f.GetCfgActVal(cfg_key)[0]; sem = f.GetCfgActVal(cfg_key)[1];           
           
            if ((dgvDiscountStudList.Rows.Count > 0) && year == Convert.ToInt32(dgvDiscountStudList.SelectedRows[0].Cells["discount_year"].Value) && sem == Convert.ToInt32(dgvDiscountStudList.SelectedRows[0].Cells["discount_sem"].Value))
            {
                discount = Convert.ToInt32(dgvDiscountStudList.SelectedRows[0].Cells["discounts_id"].Value);
                if (MessageBox.Show("Are you sure removing discount?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
                    TH_DISCOUNT_REMOVE(si.StudID, discount, year, sem);                    
                    LoadStudTH(); LoadDiscountStudList(); LoadStudOde();
                    cmbDiscountType_SelectionChangeCommitted(sender, e);                    
                    mf.TH_REFRESH(si.StudID, year.ToString(), sem.ToString());
                }
            }
            else MessageBox.Show("Only Discounts of current semester can be deleted.", "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TH_DISCOUNT_REMOVE(string pStud_ID, int pDiscount, int pYear, int pSem) 
        {
            List<OracleParameter> lst = new List<OracleParameter>();
            lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, pStud_ID));
            lst.Add(con.SetParameter("pDiscount", OracleDbType.Int16, 5, ParameterDirection.Input, pDiscount));
            lst.Add(con.SetParameter("pYear", OracleDbType.Int16, 4, ParameterDirection.Input, pYear));
            lst.Add(con.SetParameter("pSem", OracleDbType.Int16, 1, ParameterDirection.Input, pSem));           

            try
            {
                con.ExecSProcRetVal("TH_DISCOUNT_REMOVE", lst.ToArray());                
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }             
        }

        private void txtIcazeHaqq_TextChanged(object sender, EventArgs e)
        {
            pbTHicaze.Value = txtIcazeHaqq.Text.Length;
            lqalansimvolsayi.Text = "characters left: " + (500 - txtIcazeHaqq.Text.Length).ToString();
        }

        private void btnAccTHEmp_Click(object sender, EventArgs e)
        {
            if (si.isSelectStud() && MessageBox.Show("Are you sure adding permission?", "Permission for Exam", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                int emp1 = 0, emp2 = 0;
                int acc1 = 0, acc2 = 0;
                try
                {
                    if (ckTHacc1.Checked) { emp1 = lui.EmpID; acc1 = (ckTHacc1.Checked ? 1 : 0); }
                    if (ckTHacc2.Checked) { emp2 = lui.EmpID; acc2 = (ckTHacc2.Checked ? 1 : 0); }

                    OracleParameter[] prms = { 
                    con.SetParameter("PEMP_ID1", OracleDbType.Int32, 10,ParameterDirection.Input, emp1),
                    con.SetParameter("PEMP_ID2", OracleDbType.Int32, 10,ParameterDirection.Input, emp2),
                    con.SetParameter("PSTUD_ID", OracleDbType.Char, 9,ParameterDirection.Input, si.StudID),
                    con.SetParameter("PACC1", OracleDbType.Int16, 1,ParameterDirection.Input, acc1),
                    con.SetParameter("PACC2", OracleDbType.Int16, 1,ParameterDirection.Input, acc2),
                    con.SetParameter("PSTART_DATE", OracleDbType.Date, 10,ParameterDirection.Input, dtpStartDate.Value),
                    con.SetParameter("PEND_DATE", OracleDbType.Date, 10,ParameterDirection.Input, dtpEndDate.Value),
                    con.SetParameter("PACIQLAMA", OracleDbType.Varchar2, 500,ParameterDirection.Input, txtIcazeHaqq.Text),                    
                    };
                    con.ExecSProcRetVal("prThStudAcc", prms);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                check_permissions.Checked = false;
                tabControl_TH_SelectedIndexChanged(sender, e);                
            }
        }

        private void dgvTH_Click(object sender, EventArgs e)
        {
            i = dgvTH.CurrentRow.Index; //MessageBox.Show(i.ToString());
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (si.isSelectStud())
            {
                try
                {   
                    if (dgvStudOde.SelectedRows.Count > 0)
                    {
                        TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
                        string word_amount = dgvStudOde.SelectedRows[0].Cells["manat"].Value.ToString() + " Naira ";
                        if (dgvStudOde.SelectedRows[0].Cells["qepik"].Value.ToString().Length > 0) word_amount = word_amount + dgvStudOde.SelectedRows[0].Cells["qepik"].Value.ToString() + " kobo";
                        FastReport.Report thodeme = new FastReport.Report();
                        thodeme.Load(Properties.Settings.Default.CurProgDir + "/reports/thodeme.frx");
                        thodeme.SetParameterValue("stud_id", si.StudID);
                        thodeme.SetParameterValue("word_amount", word_amount);
                        thodeme.SetParameterValue("student", si.SName + " " + si.SSName + " " + mf.txtAtaAd.Text);
                        thodeme.SetParameterValue("edu_year", dgvStudOde.SelectedRows[0].Cells["DERSIL"].Value.ToString());
                        thodeme.SetParameterValue("amount", dgvStudOde.SelectedRows[0].Cells["PAYMENT_AMOUNT"].Value.ToString());
                        thodeme.SetParameterValue("payment_date", dgvStudOde.SelectedRows[0].Cells["payment_date"].Value.ToString());
                        thodeme.Show(); thodeme.Dispose();
                    }
                    else MessageBox.Show("No PAYMENT selected for printing..!");                    
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnQerarlar_Click(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.qerarToolStripMenuItem_Click(sender, e);
        }

        private void view_permisions_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //MessageBox.Show(view_permissions.GetRowCellValue((view_permissions.GetSelectedRows()[0]), "START_DATE").ToString());
            if ((view_permissions.RowCount > 0) && (!check_permissions.Checked))
            {
                try
                {
                    ckTHacc1.Checked = (view_permissions.GetRowCellValue(e.FocusedRowHandle, "ACC1").ToString() == "1");
                    ckTHacc2.Checked = (view_permissions.GetRowCellValue(e.FocusedRowHandle, "ACC2").ToString() == "1");
                    if (view_permissions.GetRowCellValue(view_permissions.GetSelectedRows()[0], "START_DATE").ToString() != "") dtpStartDate.Value = Convert.ToDateTime(view_permissions.GetRowCellValue(view_permissions.GetSelectedRows()[0], "START_DATE").ToString());
                    if (view_permissions.GetRowCellValue(view_permissions.GetSelectedRows()[0], "END_DATE").ToString() != "") dtpEndDate.Value = Convert.ToDateTime(view_permissions.GetRowCellValue(view_permissions.GetSelectedRows()[0], "END_DATE").ToString());
                    txtIcazeHaqq.Text = view_permissions.GetRowCellValue(e.FocusedRowHandle, "ACIQLAMA").ToString();
                    pbTHicaze.Value = txtIcazeHaqq.Text.Length;                    
                }
                catch (Exception) { }
            }
        }

        private void check_permissions_CheckedChanged(object sender, EventArgs e)
        {
            txtIcazeHaqq.Enabled = check_permissions.Checked;
            ckTHacc1.Enabled = check_permissions.Checked;
            ckTHacc2.Enabled = check_permissions.Checked;
            dtpStartDate.Enabled = check_permissions.Checked;
            dtpEndDate.Enabled = check_permissions.Checked;
            btnAccTHEmp.Enabled = check_permissions.Checked;
            if (check_permissions.Checked)
            {
                string sql = "select t.acc1,t.acc2,t.start_date,t.end_date,t.aciqlama from th_stud_acc t ";
                sql += "where t.stud_id = '" + si.StudID + "' and t.end_date > sysdate";
                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read())
                {
                    ckTHacc1.Checked = (dr["acc1"].ToString() == "1");
                    ckTHacc2.Checked = (dr["acc2"].ToString() == "1");
                    if (dr["start_date"].ToString() != "") dtpStartDate.Value = Convert.ToDateTime(dr["start_date"].ToString());
                    if (dr["end_date"].ToString() != "") dtpEndDate.Value = Convert.ToDateTime(dr["end_date"].ToString());
                    txtIcazeHaqq.Text = dr["aciqlama"].ToString();                    
                }
                else
                {
                    ckTHacc1.Checked = false;
                    ckTHacc2.Checked = false;
                    txtIcazeHaqq.Text = "";
                }
                pbTHicaze.Value = txtIcazeHaqq.Text.Length;
                if (!dr.IsClosed) dr.Close();
            }
        }

        //INSERT UPDATE TELEBE QOHUM
        private Int32 InsUpdStudQohum(int pRelId, string pStudId, string pRelStudId, int pRelEmpId, int pRelTypeId, int pTesdiqlenib)
        {
            try
            {
                OracleParameter[] prms = { 
                           con.SetParameter("pRelId", OracleDbType.Int32, 10, ParameterDirection.Input, pRelId),
                           con.SetParameter("pStudId", OracleDbType.Char, 9, ParameterDirection.Input, pStudId),
                           con.SetParameter("pRelStudId", OracleDbType.Char, 9, ParameterDirection.Input, pRelStudId),
                           con.SetParameter("pRelEmpId", OracleDbType.Int32, 5, ParameterDirection.Input, pRelEmpId),
                           con.SetParameter("pRelTypeId", OracleDbType.Int16, 2, ParameterDirection.Input, pRelTypeId),
                           con.SetParameter("pTesdiqlenib", OracleDbType.Int16, 1, ParameterDirection.Input, pTesdiqlenib),
                           con.SetParameter("pRes", OracleDbType.Int32, 2, ParameterDirection.InputOutput, 0)
                    };

                Int32 res = Convert.ToInt32(con.ExecSProcRetVal("dbmaster.pkg_telebe_prog.InsUpdStudRelative", prms, "pRes").ToString());

                if (res > 0) return res;                
                else if (res <= 0)
                {
                    MessageBox.Show("Error Occurred", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
            catch (OracleException oe)
            {
                if (oe.Number == 1) return -1; else return 0;
            }
            return 0;
        }

        //INSERT IDENTITY
        private Int32 InsIdentity(string pIdentity)
        {
            string student, employee, pId;
            string str_SQL = string.Empty, pRes = string.Empty;            
            List<OracleParameter> lst = new List<OracleParameter>();
            student = pIdentity.Length == 9 ? pIdentity : null; employee = pIdentity.Length == 5 ? pIdentity : null;
            
            try
            {
                lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID));
                lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 18, ParameterDirection.InputOutput, 0)); 
                pRes = con.ExecSProcRetVal("dbmaster.GetIdentityID", lst.ToArray(), "pRes").ToString();

                if (pRes == "0") MessageBox.Show("There is no Student with such ID : " + si.StudID, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    lst.Clear();                    
                    lst.Add(con.SetParameter("pStudID", OracleDbType.Char, 9, ParameterDirection.Input, student));
                    lst.Add(con.SetParameter("pEmpID", OracleDbType.Int16, 5, ParameterDirection.Input, employee));
                    lst.Add(con.SetParameter("pIdentity", OracleDbType.Int32, 9, ParameterDirection.Input, pRes));
                    lst.Add(con.SetParameter("pRes", OracleDbType.Varchar2, 9, ParameterDirection.InputOutput, 0));
                    pId = con.ExecSProcRetVal("dbmaster.pkg_telebe_prog.InsIdentity", lst.ToArray(), "pRes").ToString();
                    return Convert.ToInt32(pId);
                }
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
            return 0;
        }

        //UPDATE IDENTITY
        private void UpdIdentity(string pId, string pIdentity)
        {
            string student, employee, str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            student = pIdentity.Length == 9 ? pIdentity : null; employee = pIdentity.Length == 5 ? pIdentity : null;
            try
            {
                lst.Add(con.SetParameter("pId", OracleDbType.Int32, 9, ParameterDirection.Input, pId));
                lst.Add(con.SetParameter("pStudID", OracleDbType.Char, 9, ParameterDirection.Input, student));
                lst.Add(con.SetParameter("pEmpID", OracleDbType.Int16, 5, ParameterDirection.Input, employee));
                lst.Add(con.SetParameter("pRes", OracleDbType.Varchar2, 9, ParameterDirection.InputOutput, 0));
                con.ExecSProcRetVal("dbmaster.pkg_telebe_prog.UpdIdentity", lst.ToArray(), "pRes").ToString();                
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        //DELETE TELEBE QOHUM
        private void DelStudQohum(int pRelId)
        {
            try
            {
                OracleParameter[] prms = 
                { 
                           con.SetParameter("pRelId", OracleDbType.Int32, 10, ParameterDirection.Input, pRelId),
                           con.SetParameter("pRes", OracleDbType.Int32, 3, ParameterDirection.InputOutput, 0)
                };
                con.ExecSProcRetVal("dbmaster.pkg_telebe_prog.DelStudRelative", prms);
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message, "Error Occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }            
        }

        //DELETE IDENTITY
        private void DelIdentity(string pId)
        {
            string str_SQL = string.Empty;
            try
            {
                str_SQL = "delete from dbmaster.stud_emp_identity i where i.id = " + pId;
                con.execSQL(str_SQL);
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private Boolean Check_available(string id, string disc_type, string year, string sem)
        {
            available = false;
            string str_SQL = string.Empty;
            try
            {
                switch (disc_type)
                {
                    case "71"   : str_SQL = "select decode(count(*), 0, 0, 1) as available from partner_disc_info pd " +
                                            "left outer join discount_relative ds on nvl(ds.rel_type_id, 0) = nvl(pd.rel_type_id, 0) and ds.discounts_id = 71 " +
                                            "where ds.affect_th = 1 and pd.approved = 1 and pd.stud_id = " + id;
                    break; // ÇAĞ - 20%
                    case "75"   : str_SQL = "select decode(count(*), 0 , 0 , 1) as available from dbmaster.students s "+
                                            "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                                            "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                                            "where dp.prog_type = 'M'  and dp.edu_level = 'B' and s.class = 1 and s.status = 1 and dp.edu_lang = 'AZ' and s.stud_id = " + id;
                    break; // Dil tədrisinə görə əlavə
                    case "200"  : str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.students s "+
                                            "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                                            "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                                            "left outer join dbmaster.stud_info i on i.stud_id = s.stud_id "+
                                            "left outer join dbmaster.tedris_ocaq t on t.tedris_o_id = i.school_id "+
                                            "where dp.prog_type = 'M'  and dp.edu_level = 'B' and t.tedris_o_type = 4 and i.year >= 2008  and s.stud_id = " + id;
                    break; // Litsey - 10%
                    case "288"  : str_SQL = "SELECT decode(sum(t.sayi), 0, 0, 1) as available FROM " +
                                            "((select count(*) as sayi from dbmaster.stud_emp_identity i where exists(select e.emp_id from dbmaster.employee e where e.emp_id = i.emp_id and e.state = 1) " +
                                            "and i.identity_id = (select se.identity_id from dbmaster.stud_emp_identity se where se.stud_id = '" + id + "')) UNION " +
                                            "(select count(*) from dbmaster.stud_relative r left outer join dbmaster.employee e on e.emp_id = r.relative_emp_id " +
                                            "left outer join discount_relative ds on ds.rel_type_id = r.rel_type_id and ds.discounts_id = 288 " +
                                            "where e.state = 1 and ds.affect_th = 1 and r.tesdiqlenib = 1 and r.stud_id = '" + id + "')) t";
                    break; // Personal - 20%
                    case "289": str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.stud_relative r left outer join dbmaster.students s on s.stud_id = r.relative_stud_id " +
                                          "left outer join discount_relative ds on ds.rel_type_id = r.rel_type_id and ds.discounts_id = 289 " +
                                          "where s.status = 1 and ds.affect_th = 1 and r.tesdiqlenib = 1 and r.stud_id = " + id;
                    break; // Qardaş - 10%
                    case "290"  : str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.students s "+
                                            "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                                            "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                                            "left outer join dbmaster.stud_info i on i.stud_id = s.stud_id "+
                                            "left outer join dbmaster.tedris_ocaq t on t.tedris_o_id = i.school_id "+
                                            "where dp.prog_type = 'M' and dp.edu_level = 'B' and t.tedris_o_type = 4 and i.year < 2008  and s.stud_id = " + id;
                    break; // Litsey - 20%
                    case "291": str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.students s " +
                                          "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id " +
                                          "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' " +
                                          "left outer join dbmaster.stud_info i on i.stud_id = s.stud_id " +
                                          "left outer join dbmaster.tedris_ocaq t on t.tedris_o_id = i.kurs_id " +
                                          "where dp.prog_type = 'M' and dp.edu_level = 'B' and t.tedris_o_type = 6 and i.year > 2004 and s.stud_id = " + id;
                    break; // ARAZ - 10%
                    case "293"  : str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.students s "+
                                            "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                                            "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                                            "left outer join dbmaster.stud_info i on i.stud_id = s.stud_id "+
                                            "left outer join dbmaster.tedris_ocaq k on k.tedris_o_id = i.kurs_id "+
                                            "left outer join dbmaster.tedris_ocaq m on m.tedris_o_id = i.school_id "+
                                            "where (m.tedris_o_type = 4 or k.tedris_o_type = 6) and "+
                                            "(select count(*) from table(dbmaster.split(',', i.TQDK_IXTISAS_SECIMLER)) where title<=i.tqdk_qebul_sira having count(*)=i.tqdk_qebul_sira) is not NULL "+
                                            "and dp.prog_type = 'M'  and dp.edu_level = 'B'and i.year >= 2011 and  s.stud_id = " + id;
                    break; // İlk tərcih endirimi - 5%
                    case "941": str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.family_status fs where fs.status_id = 1 and fs.stud_id = " + id;
                    break; // Qaçqin - 10%
                    case "1256": str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.stud_mezun_uni u "+
                                           "left outer join dbmaster.students s on s.stud_id = u.stud_id "+
                                           "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                                           "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                                           "where dp.prog_type = 'M'  and dp.edu_level = 'M' and u.level_code = 'B' and u.uni_id = 3709 and u.stud_id = " + id;
                    break; // Qafqaz - 10%
                    case "1381": str_SQL = "select decode(count(*), 0, 0, 1) as available from dbmaster.students s " +
                                           "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id " +
                                           "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' " +
                                           "left outer join dbmaster.stud_info i on i.stud_id = s.stud_id " +
                                           "left outer join dbmaster.tedris_ocaq t on t.tedris_o_id = i.kurs_id " +
                                           "where dp.prog_type = 'M'  and dp.edu_level = 'B' and t.tedris_o_type = 6 and i.year <= 2004 and s.stud_id = " + id;
                    break; // ARAZ - 20%                   
                    default     : str_SQL = "select decode(count(*), 0, 1, 0) as available from discounted_students ds " + //Bu telebede, seçilen disc_type varsa DİSABLE elə...
                                            "where ds.stud_id = '" + id + "' and ds.discounts_id = " + disc_type + " and ds.discount_year = " + year + " and ds.discount_sem = " + sem;
                    break;
                }
                OracleDataReader dr = con.execSQL(str_SQL); if (dr.Read()) available = dr["AVAILABLE"].ToString() == "1"; dr.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return available;
        }

        private void frmTH_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void frmTH_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }

        private void cmbDiscountType_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            string str_SQL = string.Empty;
            label_discount.Text = cmbDiscountType.Text;
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            TabControl_discounts.Visible = pnlYataqxana.Visible = cmbDiscountType.SelectedValue.ToString() != "0";                        
            btnEndirimAdd.Enabled = (Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString()) &&
                                    (cmbDiscountType.SelectedValue.ToString() != "0") && mf.EnableDisableAcc(lui.EmpID, 41));   

            if (tabControl_TH.SelectedIndex == 1) for (int i = 0; i < TabControl_discounts.TabPages.Count(); i++) TabControl_discounts.TabPages[i].PageVisible = false;        
            switch (cmbDiscountType.SelectedValue.ToString())
            {
                case "71"   : Page_71.PageVisible = true; LoadTelebeRelativeInfo(71); break; // CAĞ
                case "76"   : Page_73.PageVisible = true; LoadDiscInfo(73); break; // Lisey ardıcıl endrimini Lisey tabına yönlendir  
                case "77"   : Page_74.PageVisible = true; LoadDiscInfo(74); break; // ARAZ ardıcıl endrimini ARAZ tabına yönlendir
                case "200"  : Page_73.PageVisible = true; LoadDiscInfo(73); break;
                case "288"  : Page_72.PageVisible = true; LoadTelebeRelativeInfo(288); break;
                case "289"  : Page_70.PageVisible = true; LoadTelebeRelativeInfo(289); break;
                case "290"  : Page_73.PageVisible = true; LoadDiscInfo(73); break; // Lisey tabı
                case "291"  : Page_74.PageVisible = true; LoadDiscInfo(74); break; // ARAZ tabı
                case "293"  : Page_68.PageVisible = true; LoadDiscInfo(68); break;
                case "581"  : Page_204.PageVisible = true; LoadDiscInfo(204); break;
                case "941"  : Page_206.PageVisible = true; LoadDiscInfo(206); break;
                case "1256" : Page_252.PageVisible = true; LoadDiscInfo(252); break;
                case "1381" : Page_74.PageVisible = true; LoadDiscInfo(74); break;
                case "1485" : break;
                case "2802" : break;
                default: break;
            }            
            if ((cmbDiscountType.SelectedValue.ToString() != "0") && (tabControl_TH.SelectedIndex == 1)) TabControl_discounts.SelectedTabPage.Text = cmbDiscountType.Text;            
        }

        private void LoadDiscInfo(int disctype)
        {   
            switch (disctype)
            {
                case 68 : string str_SQL = "select i.school_id, i.kurs_id, i.tqdk_qebul_sira, i.tqdk_ixtisas_secimler from dbmaster.stud_info i where i.stud_id = " + si.StudID;
                          OracleDataReader dr = con.execSQL(str_SQL); 
                          if (dr.Read())
                          {
                              //TQDK QEBUL SIRASI
                              if (dr["TQDK_QEBUL_SIRA"].ToString() == "") txtTqdkQebulSiraQu.Value = 0;
                              else txtTqdkQebulSiraQu.Value = Convert.ToDecimal(dr["TQDK_QEBUL_SIRA"]);
                              LoadTelebeTqdkIxtisaSecimSira(dr["TQDK_IXTISAS_SECIMLER"].ToString()); // LOAD TQDK_IXTISAS_SEICIMLER
                              button_change_68.Enabled = false;
                          }
                          dr.Close();
                break;
                case 73: dr = con.execSQL("select i.school_id from dbmaster.stud_info i where i.stud_id = " + si.StudID);
                          lookUp_litsey.EditValue = (dr.Read() && dr["SCHOOL_ID"].ToString() != "") ? Convert.ToDecimal(dr["SCHOOL_ID"]) : 0; dr.Close();
                          str_SQL = "select t.tedris_o_id as id, t.ocaq_title as title from dbmaster.tedris_ocaq t " +
                                    "where t.tedris_o_type = 4 or t.tedris_o_id = (select i.school_id from dbmaster.stud_info i where i.stud_id = '" + si.StudID + "') " +
                                    "union select 0, ' '||i.interface_lang_title_en from dbmaster.interface_lang i where i.interface_lang_id = 225 order by title";
                          if (lookUp_litsey.Properties.DataSource == null) con.load_lookUp(lookUp_litsey, str_SQL, "TITLE", "ID");
                          button_change_73.Enabled = false;    
                break;
                case 74: dr = con.execSQL("select i.kurs_id from dbmaster.stud_info i where i.stud_id = " + si.StudID);
                              lookUp_kurs.EditValue = (dr.Read() && dr["KURS_ID"].ToString() != "") ? Convert.ToDecimal(dr["KURS_ID"]) : 0; dr.Close();
                              str_SQL = "select t.tedris_o_id as id, t.ocaq_title as title from dbmaster.tedris_ocaq t where t.tedris_o_type in (6,7) union " +
                                        "select 0, ' '||i.interface_lang_title_en from dbmaster.interface_lang i where i.interface_lang_id = 225 order by title";
                            con.load_lookUp(lookUp_kurs, str_SQL, "TITLE", "ID");
                            button_change_74.Enabled = false;
                break;
                case 204: str_SQL = "select nvl(sum(cd.amount), 0) as amount, wm_concat(cd.disc_apply_reccur) as recur from custom_discount cd " +
                                    "where cd.stud_id = '" + si.StudID + "' and cd.custom_discount_year = " + dgvTH.SelectedRows[0].Cells["payment_year"].Value;
                str_SQL = "select case when dp.edu_level = 'B' and dp.edu_lang = 'AZ' and i.year < 2010 then dp.period_count + 2 else dp.period_count end ntm, " +
                          "(select count(*) + 1 from stud_payments sp left outer join discounted_students ds on ds.stud_id = sp.stud_id and ds.discount_year = sp.payment_year " +
                          "and ds.discount_sem = sp.payment_sem and ds.is_active = 1 and ds.priority = 1 where (sp.is_manual = 1 or ds.discounts_id is not NULL) and sp.payment_code = 400 " +
                          "and sp.stud_id = s.stud_id and sp.payment_year || sp.payment_sem < " + f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString() + f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString() + ") as muddet, " +
                          "(select nvl(sum(cd.amount), 0) from custom_discount cd where cd.stud_id = s.stud_id and cd.custom_discount_year = " + dgvTH.SelectedRows[0].Cells["PAYMENT_YEAR"].Value + ") as amount, " +
                          "(select nvl(sum(cd.disc_apply_reccur), 0) from custom_discount cd where cd.stud_id = s.stud_id and cd.custom_discount_year = " + dgvTH.SelectedRows[0].Cells["PAYMENT_YEAR"].Value + ") as recur " +
                          "from dbmaster.students s left outer join dbmaster.stud_info i on i.stud_id = s.stud_id left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                          "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' where  dp.prog_type = 'M' and s.stud_id = " + si.StudID;
                          dr = con.execSQL(str_SQL);
                          if (dr.Read())
                          {
                              ckOzelEndirim.Enabled = (dr["AMOUNT"].ToString() == "0") && (Convert.ToInt16(dr["MUDDET"]) <= Convert.ToInt16(dr["NTM"]));
                              ckOzelEndirim.Checked = (dr["RECUR"].ToString() == "1");
                              nudOzelEndirim.Value = Convert.ToDecimal(dr["AMOUNT"]);                              
                              nudOzelEndirim.Enabled = nudOzelEndirim.Value == 0;                              
                          }
                          dr.Close();     
                break;
                case 206: dr = con.execSQL("select decode(count(*), 0, 0, 1) as is_qacqin from dbmaster.family_status fs where fs.status_id = 1 and fs.stud_id = " + si.StudID);
                          check_fstatus.Checked = (dr.Read() && dr["IS_QACQIN"].ToString() == "1"); dr.Close();                        
                break;
                case 252: LoadTelebeMezunUni(); break;
                default : break;
            }                                
        }

        private void tabControl_TH_SelectedIndexChanged(object sender, EventArgs e)
        {   
            string str_SQL = string.Empty;
            switch (tabControl_TH.SelectedIndex)
            {
                case 1: groupBox_discountTypes.Parent = split_discounts.Panel1; group_discounts.Parent = split_discounts.Panel2;    
                        str_SQL = "select * from (select d.discounts_id as id, dt.title_en||' - '||d.discounts_amount||' %'||' - '||d.discounts_year as title from discounts d " +
                                  "left outer join discount_type dt on d.discountstype = dt.discount_type_id where d.d_type_id = 2 and dt.is_discount = 1 and dt.is_active = 1 " +                                   
                                  "UNION " +
                                  "select 0, ' '||i.interface_lang_title_en from dbmaster.interface_lang i where i.interface_lang_id = 225) t order by t.title";
                        con.load_ComboBox(cmbDiscountType, str_SQL, "title", "id"); 
                        cmbDiscountType_SelectionChangeCommitted(sender, e); 
                        LoadDiscountStudList();
                break;
                case 2: groupBox_discountTypes.Parent = split_extraFee.Panel1; group_discounts.Parent = split_extraFee.Panel2; 
                        str_SQL = "select * from (select d.discounts_id as id, dt.discount_type_title||' - '||d.discounts_amount||' %'||' - '||d.discounts_year as title from discounts d " +
                                  "left outer join discount_type dt on d.discountstype = dt.discount_type_id where d.d_type_id = 2 and dt.is_discount = 0 UNION " +
                                  "select 0, ' '||i.interface_lang_title_en from dbmaster.interface_lang i where i.interface_lang_id = 225) t order by t.title";
                        con.load_ComboBox(cmbDiscountType, str_SQL, "title", "id"); 
                        cmbDiscountType_SelectionChangeCommitted(sender, e); 
                        LoadDiscountStudList();
                break;
                case 3: if (check_permissions.Checked)
                        {
                            str_SQL = "select t.acc1,t.acc2,t.start_date,t.end_date,t.aciqlama from th_stud_acc t " +
                                      "where t.stud_id = '" + si.StudID + "' and t.end_date > sysdate";
                            OracleDataReader dr = con.execSQL(str_SQL);
                            if (dr.Read())
                            {
                                ckTHacc1.Checked = (dr["acc1"].ToString() == "1");
                                ckTHacc2.Checked = (dr["acc2"].ToString() == "1");
                                if (dr["start_date"].ToString() != "") dtpStartDate.Value = Convert.ToDateTime(dr["start_date"].ToString());
                                if (dr["end_date"].ToString() != "") dtpEndDate.Value = Convert.ToDateTime(dr["end_date"].ToString());
                                txtIcazeHaqq.Text = dr["aciqlama"].ToString();
                                pbTHicaze.Value = txtIcazeHaqq.Text.Length;
                            }
                            dr.Close();
                            view_permissions.OptionsView.ColumnAutoWidth = true;
                            view_permissions.OptionsView.RowAutoHeight = true;
                            view_permissions.LayoutChanged();
                        }
                        else
                        {
                            str_SQL = "select t.start_date, t.end_date, (select e1.name||' '||e1.sname from dbmaster.employee e1 where e1.emp_id = t.emp_id1) as emp1, " +
                                      "t.acc1, (select e2.name||' '||e2.sname from dbmaster.employee e2 where e2.emp_id = t.emp_id2) as emp2, t.acc2, t.aciqlama " +
                                      "from th_stud_acc t where stud_id = '" + si.StudID + "' order by t.th_acc_id desc";
                            bind.DataSource = con.GetDataTable(str_SQL);
                            grid_permissions.DataSource = bind;
                        }
                break;
                default: break;
            }       
        }

        private void button_CAGadd_Click(object sender, EventArgs e)
        {
            TMS.Selectors.form_CAG cag = new Selectors.form_CAG(); cag.Owner = this; cag.Text = "New data";
            if (cag.ShowDialog() == DialogResult.OK) LoadTelebeRelativeInfo(71); // CAG`da işleyen qohumları LOAD elə ki, yeni əlavə etdiyimiz də görsənsin...                       
        }

        private void button_CAGedit_Click(object sender, EventArgs e)
        {
            TreeListNode node = tree_relative_partners.Selection[0];            
            TMS.Selectors.form_CAG cag = new Selectors.form_CAG(Convert.ToInt32(node[treeColumn_ID]));

            cag.Owner = this; cag.Text = "Change Data";
            cag.textEdit_name.Text = node[treeColumn_name].ToString();            
            cag.textEdit_surname.Text = node[treeColumn_sname].ToString();            
            cag.lookUp_type.EditValue = Convert.ToDecimal(node[treeColumn_rtID]);
            cag.check_confirm.Checked = node[treeColumn_approved].ToString() == "1";
            cag.lookUp_company.EditValue = Convert.ToDecimal(node[treeColumn_companyID]);            
            
            if (cag.ShowDialog() == DialogResult.OK) LoadTelebeRelativeInfo(71); // CAG`da işleyen qohumları LOAD elə ki, dəyişdiyimizdə görsənsin... 
        }

        private void button_CAGremove_Click(object sender, EventArgs e)
        {
            TreeListNode node = tree_relative_partners.Selection[0];
            string str_SQL = string.Empty, msg = string.Empty;
            try
            {
                msg = "Are you sure deleting data?";
                str_SQL = "delete from partner_disc_info t where t.info_id = " + node[treeColumn_ID].ToString();
                if ((MessageBox.Show(msg, "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    con.execSQL(str_SQL);
                    LoadTelebeRelativeInfo(71);
                }
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void button_relemp_add_Click(object sender, EventArgs e)
        {
            TelebeQeydiyyat.Selectors.frmSecQohum frm = new TelebeQeydiyyat.Selectors.frmSecQohum(72);
            frm.formMod = TelebeQeydiyyat.Selectors.frmSecQohum._formMod.New;

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Int32 id = 0; // QOHUM TİPİ OLARAQ TƏLƏBƏNİN ÖZÜ SEÇİLİBSƏ, IDENTİTY`Ə ƏLAVƏ EDİLİR YOXSA RELATIVES`Ə...             
                id = (frm.leQohumType.EditValue.ToString() == "0") ? InsIdentity(frm.browse_relative.Tag.ToString()) :
                InsUpdStudQohum(0, si.StudID, "", Convert.ToInt32(frm.browse_relative.Tag), Convert.ToInt16(frm.leQohumType.EditValue), frm.chbTesdiqlenib.Checked ? 1 : 0);
                if (id > 0)
                {
                    Image img = con.GetImageBySql("select f.foto from dbmaster.emp_foto f where f.emp_id = " + frm.browse_relative.Tag.ToString());
                    TreeListNode n = AppendCustomNodeQohum(tree_relative_employee, id, "İşçi", frm.browse_relative.Text, Convert.ToInt32(frm.leQohumType.EditValue), frm.leQohumType.Text, frm.browse_relative.Tag.ToString(), img, frm.chbTesdiqlenib.Checked ? 1 : 0);
                    n.ImageIndex = n.SelectImageIndex = 0; n.TreeList.BestFitColumns();
                }
                else
                {
                    if (frm.leQohumType.EditValue.ToString() == "0")
                        MessageBox.Show(frm.browse_relative.Tag.ToString() + " : " + frm.browse_relative.Text + ", ALREADY USED IN OTHER IDENTITY. \nSame person can't be used in different identities..!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (id < 0) MessageBox.Show("Same data already exists..!", "DATA ALREADY EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else MessageBox.Show(frm.browse_relative.Text + ", couldn't be added to relative list. Check your selections and try again..!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button_relemp_edit_Click(object sender, EventArgs e)
        {
            if (tree_relative_employee.Selection.Count != 1) return;
            TreeListNode node = tree_relative_employee.Selection[0];
            TelebeQeydiyyat.Selectors.frmSecQohum frm = new TelebeQeydiyyat.Selectors.frmSecQohum(72);

            frm.QohumTypeId = Convert.ToInt16(node[treeColumn_ertID]);
            frm.browse_relative.Tag = node[treeColumn_empID].ToString();
            frm.browse_relative.Text = node[treeColumn_employee].ToString();            
            frm.formMod = TelebeQeydiyyat.Selectors.frmSecQohum._formMod.Edit;
            frm.chbTesdiqlenib.Checked = node[treeColumn_eapproved].ToString() == "1";

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                /// QOHUM TİPİ OLARAQ TƏLƏBƏNİN ÖZÜ SEÇİLİBSƏ, IDENTİTY UPDATE EDİLİR YOXSA RELATIVES...  
                if (frm.leQohumType.EditValue.ToString() == "0") UpdIdentity(node[treeColumn_eID].ToString(), frm.browse_relative.Tag.ToString()); else 
                InsUpdStudQohum(Convert.ToInt32(node[treeColumn_eID]), si.StudID, "", Convert.ToInt32(frm.browse_relative.Tag), Convert.ToInt16(frm.leQohumType.EditValue), frm.chbTesdiqlenib.Checked ? 1 : 0);
                btnEndirimAdd.Enabled = Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
                if (node[treeColumn_empID].ToString() != frm.browse_relative.Tag.ToString())
                {
                    Image img = con.GetImageBySql("select f.foto from dbmaster.emp_foto f where f.emp_id= " + frm.browse_relative.Tag.ToString());
                    node[treeColumn_ephoto] = img;
                }
                node[treeColumn_ePT] = "İşçi";
                node[treeColumn_ertTitle] = frm.leQohumType.Text;
                node[treeColumn_empID] = frm.browse_relative.Tag;
                node[treeColumn_ertID] = frm.leQohumType.EditValue;
                node[treeColumn_employee] = frm.browse_relative.Text;
                node[treeColumn_eapproved] = frm.chbTesdiqlenib.Checked ? 1 : 0;
                node.TreeList.BestFitColumns();
            }
        }

        private void button_relstud_add_Click(object sender, EventArgs e)
        {
            TelebeQeydiyyat.Selectors.frmSecQohum frm = new TelebeQeydiyyat.Selectors.frmSecQohum(70);
            frm.formMod = TelebeQeydiyyat.Selectors.frmSecQohum._formMod.New;
            
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Int32 id = 0; // QOHUM TİPİ OLARAQ TƏLƏBƏNİN ÖZÜ SEÇİLİBSƏ, IDENTİTY`Ə ƏLAVƏ EDİLİR YOXSA RELATIVES`Ə...             
                id = (frm.leQohumType.EditValue.ToString() == "0") ? InsIdentity(frm.browse_relative.Tag.ToString()) :
                InsUpdStudQohum(0, si.StudID, frm.browse_relative.Tag.ToString(), 0, Convert.ToInt16(frm.leQohumType.EditValue), frm.chbTesdiqlenib.Checked ? 1 : 0);
                if (id > 0)
                {
                    Image img = con.GetImageBySql("select f.foto from dbmaster.stud_foto f where f.stud_id = " + frm.browse_relative.Tag.ToString());                    
                    TreeListNode n = AppendCustomNodeQohum(tree_relative_students, id, "Tələbə", frm.browse_relative.Text, Convert.ToInt32(frm.leQohumType.EditValue), frm.leQohumType.Text, frm.browse_relative.Tag.ToString(), img, frm.chbTesdiqlenib.Checked ? 1 : 0);
                    n.ImageIndex = n.SelectImageIndex = 0;
                    n.TreeList.BestFitColumns();
                }
                else
                {
                    if (frm.leQohumType.EditValue.ToString() == "0")
                        MessageBox.Show(frm.browse_relative.Tag.ToString() + " : " + frm.browse_relative.Text + ", ALREADY USED IN OTHER IDENTITY. \nSame person can't be used in different identities..!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (id < 0) MessageBox.Show("Same data already exists..!", "DATA ALREADY EXISTS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else MessageBox.Show(frm.browse_relative.Text + ", couldn't be added to relative list. Check your selections and try again..!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);                        
                    }
                }
            }
        }

        private void button_relstud_edit_Click(object sender, EventArgs e)
        {
            if (tree_relative_students.Selection.Count != 1) return;
            TreeListNode node = tree_relative_students.Selection[0];
            TelebeQeydiyyat.Selectors.frmSecQohum frm = new TelebeQeydiyyat.Selectors.frmSecQohum(70);

            frm.QohumTypeId = Convert.ToInt16(node[treeColumn_srtID]);
            frm.browse_relative.Tag = node[treeColumn_studID].ToString();
            frm.browse_relative.Text = node[treeColumn_student].ToString();            
            frm.formMod = TelebeQeydiyyat.Selectors.frmSecQohum._formMod.Edit;
            frm.chbTesdiqlenib.Checked = node[treeColumn_sapproved].ToString() == "1";
            
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                /// QOHUM TİPİ OLARAQ TƏLƏBƏNİN ÖZÜ SEÇİLİBSƏ, IDENTİTY UPDATE EDİLİR YOXSA RELATIVES...  
                if (frm.leQohumType.EditValue.ToString() == "0") UpdIdentity(node[treeColumn_sID].ToString(), frm.browse_relative.Tag.ToString()); else
                InsUpdStudQohum(Convert.ToInt32(node[treeColumn_sID]), si.StudID, frm.browse_relative.Tag.ToString(), 0, Convert.ToInt16(frm.leQohumType.EditValue), frm.chbTesdiqlenib.Checked ? 1 : 0);
                btnEndirimAdd.Enabled = Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
                if (node[treeColumn_studID].ToString() != frm.browse_relative.Tag.ToString())
                {
                    node[treeColumn_sphoto] = con.GetImageBySql("select f.foto from dbmaster.stud_foto f where f.stud_id= " + frm.browse_relative.Tag.ToString());
                }
                node[treeColumn_sPT] = "Tələbə";
                node[treeColumn_srtTitle] = frm.leQohumType.Text;
                node[treeColumn_studID] = frm.browse_relative.Tag;
                node[treeColumn_srtID] = frm.leQohumType.EditValue;
                node[treeColumn_student] = frm.browse_relative.Text;
                node[treeColumn_sapproved] = frm.chbTesdiqlenib.Checked ? 1 : 0;
                node.TreeList.BestFitColumns();
            }
        }

        private void button_relstud_remove_Click(object sender, EventArgs e)
        {            
            string msg = "Are you sure deleting " + tree_relative_students.Selection[0][treeColumn_studID] + " - " + tree_relative_students.Selection[0][treeColumn_student] + " from relative list?";
            if (tree_relative_students.Selection.Count == 1 && MessageBox.Show(msg, "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tree_relative_students.Selection[0][treeColumn_srtID].ToString() == "0") DelIdentity(tree_relative_students.Selection[0][treeColumn_sID].ToString());
                else DelStudQohum(Convert.ToInt32(tree_relative_students.Selection[0][treeColumn_sID]));
                tree_relative_students.Nodes.Remove(tree_relative_students.Selection[0]);           
            }
        }

        private void tree_relative_students_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {            
            button_relstud_edit.Enabled = button_relstud_remove.Enabled = (sender as TreeList).Selection.Count == 1;
            btnEndirimAdd.Enabled = Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
        }

        private void tree_relative_employee_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            button_relemp_edit.Enabled = button_relemp_remove.Enabled = (sender as TreeList).Selection.Count == 1;
            btnEndirimAdd.Enabled = Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
        }

        private void button_relemp_remove_Click(object sender, EventArgs e)
        {   
            string msg = "Are you sure deleting " + tree_relative_employee.Selection[0][treeColumn_empID] + " - " + tree_relative_employee.Selection[0][treeColumn_employee] + " from relative list?";
            if (tree_relative_employee.Selection.Count == 1 && MessageBox.Show(msg, "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tree_relative_employee.Selection[0][treeColumn_ertID].ToString() == "0") DelIdentity(tree_relative_employee.Selection[0][treeColumn_eID].ToString());
                else DelStudQohum(Convert.ToInt32(tree_relative_employee.Selection[0][treeColumn_eID]));
                tree_relative_employee.Nodes.Remove(tree_relative_employee.Selection[0]);                
            }
        }

        private void tree_relative_partners_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            button_CAGedit.Enabled = button_CAGremove.Enabled = (sender as TreeList).Selection.Count == 1;
            btnEndirimAdd.Enabled = Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
        }

        private string GetTqdkIxtisasSecimlerDelimitedString()
        {
            string res = "";
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in clbIxtisasSeimSiraQu.Items)
            {
                if (item.CheckState == CheckState.Checked) res += res == "" ? item.Value.ToString() : "," + item.Value.ToString();
            }
            return res;
        }

        private void button_change_68_Click(object sender, EventArgs e)
        {
            string msg, str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            if (txtTqdkQebulSiraQu.Value > 0 && txtTqdkQebulSiraQu.Value <= 5 && clbIxtisasSeimSiraQu.Items[Convert.ToInt16(txtTqdkQebulSiraQu.Value) - 1].CheckState == CheckState.Unchecked)
            {
                dxErrorProvider_68.SetError(txtTqdkQebulSiraQu, "Admitted choise not exists in NTNU choises!");
                txtTqdkQebulSiraQu.Focus(); //TQDK İXTİSAS SEÇİM SIRA
                return;
            }
            else             
            {
                dxErrorProvider_68.SetError(txtTqdkQebulSiraQu, null);
                msg = "Are you sure changing admitted choise and NTNU choises?";
                str_SQL = "update dbmaster.stud_info i set i.tqdk_qebul_sira = :sira, i.tqdk_ixtisas_secimler = :secimler where i.stud_id = " + si.StudID;
                
                lst.Add(con.SetParameter("sira", OracleDbType.Int16, 2, ParameterDirection.Input, txtTqdkQebulSiraQu.Value));
                lst.Add(con.SetParameter("secimler", OracleDbType.Varchar2, 50, ParameterDirection.Input, GetTqdkIxtisasSecimlerDelimitedString()));

                if (MessageBox.Show(msg, "CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) try
                {
                    con.execSQL(str_SQL, lst.ToArray()); button_change_68.Enabled = false;
                    btnEndirimAdd.Enabled = (Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString()) &&
                                            (cmbDiscountType.SelectedValue.ToString() != "0") && (lui.extra_field == "18100" || lui.EmpID == 11820));
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
        }

        private void LoadTelebeTqdkIxtisaSecimSira(string pSecimler)
        {            
            if (pSecimler == "") return;

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in clbIxtisasSeimSiraQu.Items) item.CheckState = CheckState.Unchecked;

            try
            {
                string sql = "select title from table(dbmaster.split(',', :secimler))";
                OracleParameter[] prms = { 
                                             con.SetParameter("secimler", OracleDbType.Varchar2, -1, ParameterDirection.Input, pSecimler)
                                 };
                OracleDataReader dr = con.execSQL(sql, prms);
                while (dr.Read())
                {
                    clbIxtisasSeimSiraQu.Items[Convert.ToInt16(dr["TITLE"].ToString()) - 1].CheckState = CheckState.Checked;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error occurred when loading NTNU choises.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clbIxtisasSeimSiraQu_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            button_change_68.Enabled = true;
        }

        private void txtTqdkQebulSiraQu_EditValueChanged(object sender, EventArgs e)
        {
            button_change_68.Enabled = true;
        }

        private void lookUp_litsey_EditValueChanged(object sender, EventArgs e)
        {
            button_change_73.Enabled = true;
        }

        private void button_change_73_Click(object sender, EventArgs e)
        {
            string msg, str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            str_SQL = "update dbmaster.stud_info i set i.school_id = :school where i.stud_id = " + si.StudID;
            lst.Add(con.SetParameter("school", OracleDbType.Int32, 10, ParameterDirection.Input, lookUp_litsey.EditValue.ToString() == "0" ? null : lookUp_litsey.EditValue));

            msg = lookUp_litsey.EditValue.ToString() == "0" ? "Are you sure deleting graduated high School?" : "Are you sure changing graduated high school to '" + lookUp_litsey.Text + "'?";
            if (MessageBox.Show(msg, "CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            try
            {
                con.execSQL(str_SQL, lst.ToArray()); button_change_73.Enabled = false;
                btnEndirimAdd.Enabled = (Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString()) &&
                                        (cmbDiscountType.SelectedValue.ToString() != "0") && (lui.extra_field == "18100" || lui.EmpID == 11820));
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void lookUp_kurs_EditValueChanged(object sender, EventArgs e)
        {
            button_change_74.Enabled = true;
        }

        private void button_change_74_Click(object sender, EventArgs e)
        {
            string msg, str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            str_SQL = "update dbmaster.stud_info i set i.kurs_id = :kurs where i.stud_id = " + si.StudID;
            lst.Add(con.SetParameter("kurs", OracleDbType.Int32, 10, ParameterDirection.Input, lookUp_kurs.EditValue.ToString() == "0" ? null : lookUp_kurs.EditValue));

            msg = lookUp_kurs.EditValue.ToString() == "0" ? "Are you sure deleting Preperation Center?" : "Are you sure changing Preperation Center to '" + lookUp_kurs.Text + "'?";
            if (MessageBox.Show(msg, "CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) try
            {
                con.execSQL(str_SQL, lst.ToArray()); button_change_74.Enabled = false;
                btnEndirimAdd.Enabled = (Check_available(si.StudID, "74", f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString()) &&
                                        (cmbDiscountType.SelectedValue.ToString() != "0") && (lui.extra_field == "18100" || lui.EmpID == 11820));
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void check_fstatus_Click(object sender, EventArgs e)
        {            
            string str_SQL = string.Empty;
            CheckState state = check_fstatus.CheckState; check_fstatus.Checked = !check_fstatus.Checked;
            string msg = check_fstatus.Checked ? "Are you sure to confirm immigrant status of Student?" : "Are you sure to cancel immigrant status of Student?";
            if (MessageBox.Show(msg, "CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OracleDataReader dr = con.execSQL("select decode(count(*), 0, 0, 1) as is_qacqin from dbmaster.family_status fs where fs.status_id = 1 and fs.stud_id = " + si.StudID);
                if (dr.Read())
                {
                    str_SQL = (dr["IS_QACQIN"].ToString() == "0" && check_fstatus.Checked) ? "insert into dbmaster.family_status(stud_id, status_id) values('" + si.StudID + "', 1)" :
                              (dr["IS_QACQIN"].ToString() == "1" && !check_fstatus.Checked) ? "delete dbmaster.family_status fs where fs.stud_id = '" + si.StudID + "' and fs.status_id = 1" : "";
                    
                    if (str_SQL.Length == 0) check_fstatus.Checked = dr["IS_QACQIN"].ToString() == "1";
                    else try { con.execSQL(str_SQL); } catch (OracleException oex) { MessageBox.Show(oex.Message); }
                }
                dr.Close();
                btnEndirimAdd.Enabled = Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
            }
            else check_fstatus.CheckState = state;
        }

        private void tlStudMezUni_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            TreeList tl = sender as TreeList;
            btnRemStudMezUni.Enabled = btnDeyisStudMezUni.Enabled = tl.Selection.Count == 1;
            btnEndirimAdd.Enabled = Check_available(si.StudID, cmbDiscountType.SelectedValue.ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
        }

        //LOAD STUD MEZUN OLDUGU UNIVERSITETLER
        private void LoadTelebeMezunUni()
        {            
            tlStudMezUni.ClearNodes();
            try
            {
                string sql = "select u.mez_uni_id, u.uni_id, u.level_code, l.title_en level_title, t.ocaq_title uni_title, u.ixtisas_ad, u.diplom_no, to_char(u.diplom_ver_tarix, 'DD.MM.YYYY') diplom_ver_tarix, " +
                             "u.diplom_qeyd_no, u.diplom_ferqlenme from dbmaster.stud_mezun_uni u left join dbmaster.tedris_ocaq t on t.tedris_o_id=u.uni_id left join dbmaster.edu_levels l on l.level_code = u.level_code where u.stud_id=:studID";
                OracleParameter[] prms = { con.SetParameter("studID", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID) };
                OracleDataReader dr = con.execSQL(sql, prms);
                while (dr.Read())
                {
                    TreeListNode n = AppendCustomNodeUni(tlStudMezUni, Convert.ToInt32(dr["MEZ_UNI_ID"]), dr["LEVEL_CODE"].ToString(), Convert.ToInt32(dr["UNI_ID"]), dr["LEVEL_TITLE"].ToString(), dr["UNI_TITLE"].ToString(), dr["IXTISAS_AD"].ToString(), dr["DIPLOM_NO"].ToString(), dr["DIPLOM_VER_TARIX"].ToString(), dr["DIPLOM_QEYD_NO"].ToString(), dr["DIPLOM_FERQLENME"] != null && dr["DIPLOM_FERQLENME"].ToString() == "1");
                    n.TreeList.BestFitColumns();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Special Error Code - 32.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TreeListNode AppendCustomNodeUni(TreeList tl, int mezUniID, string EduLevel, int UniId, string DegreeTitle, string UniTitle, string Ixtisas, string DiplomNo, string DiplomVerDate, string DiplomQeydNo, bool DiplomFerqlenme)
        {
            tl.BeginUnboundLoad();
            TreeListNode n = tl.AppendNode(new object[] { mezUniID, EduLevel, UniId, DegreeTitle, UniTitle }, null);
            TreeListNode nc1 = tl.AppendNode(new object[] { 0, 0, 0, "İxtisas", Ixtisas }, n);
            TreeListNode nc2 = tl.AppendNode(new object[] { 0, 0, 0, "Diplomun seriya və №si", DiplomNo }, n);
            TreeListNode nc3 = tl.AppendNode(new object[] { 0, 0, 0, "Diplomun verilmə tarixi", DiplomVerDate }, n);
            TreeListNode nc4 = tl.AppendNode(new object[] { 0, 0, 0, "Qeydiyyat nömrəsi", DiplomQeydNo }, n);
            TreeListNode nc5 = tl.AppendNode(new object[] { 0, 0, 0, "Fərqlənmə", DiplomFerqlenme ? "Fərqlənmə" : "Adi" }, n);

            n.ImageIndex = n.SelectImageIndex = 0;
            nc1.ImageIndex = nc1.SelectImageIndex = 1;
            nc2.ImageIndex = nc2.SelectImageIndex = 2;
            nc3.ImageIndex = nc3.SelectImageIndex = 3;
            tl.EndUnboundLoad();
            return n;
        }

        private void btnAddStudMezUni_Click(object sender, EventArgs e)
        {
            TMS.Selectors.form_qafqaz qafqaz = new Selectors.form_qafqaz(); qafqaz.Owner = this; qafqaz.Text = "New data";
            if (qafqaz.ShowDialog() == DialogResult.OK) LoadDiscInfo(252);
        }

        private void btnDeyisStudMezUni_Click(object sender, EventArgs e)
        {
            TreeListNode node = tlStudMezUni.Selection[0];
            if (!node.HasChildren) node = node.ParentNode;
            Int32 id = Convert.ToInt32(node[tlStudMezUniColID]);
            TMS.Selectors.form_qafqaz qafqaz = new Selectors.form_qafqaz(id); qafqaz.Owner = this; qafqaz.Text = "Change data";
            if (qafqaz.ShowDialog() == DialogResult.OK) LoadDiscInfo(252);
        }

        private void btnRemStudMezUni_Click(object sender, EventArgs e)
        {
            TreeListNode node = tlStudMezUni.Selection[0];
            string str_SQL = string.Empty, msg = "Are you sure deleting data?";
            str_SQL = "delete dbmaster.stud_mezun_uni u where u.mez_uni_id = " + node[tlStudMezUniColID].ToString();
            if ((MessageBox.Show(msg, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) try
            { con.execSQL(str_SQL); LoadDiscInfo(252); } catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void dgvDiscountStudList_SelectionChanged(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            btnEndirimDelete.Enabled = (dgvDiscountStudList.SelectedRows.Count > 0) && mf.EnableDisableAcc(lui.EmpID, 41);
        }
    }
}
