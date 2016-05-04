using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DB;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using Globals;

namespace TMS.TH
{
    public partial class THStatistics : Form
    {
        string faculties = "", departments = "", text = string.Empty;
        General.functions f = new General.functions();
        BindingSource bind = new BindingSource();        
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        bool CheckAll = false;        
        
        public THStatistics()
        {
            InitializeComponent();
        }

        private void Pages_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            label_sem.Parent = label_year.Parent = Pages.SelectedTabPage;
            lookUp_semester.Parent = lookUp_year.Parent = Pages.SelectedTabPage;
                        
            grid_thstatistics.DataSource = null;
            view_thstatistics.Columns.Clear();
            button_excel.Enabled = (view_thstatistics.RowCount > 0);
        }

        private void THStatistics_Load(object sender, EventArgs e)
        {
            string str_SQL = "", year = string.Empty, sem = string.Empty;
            sem = f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString();
            year = f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString();            
            date_begin.DateTime = Convert.ToDateTime("08/01/" + year); date_end.DateTime = DateTime.Today;
                        
            str_SQL = "select (level + 2006) as year, (level + 2006)||'-'||to_char(level + 2007) as il from dual connect by level <= (" + year + " - 2006) order by 1 desc";
            con.load_lookUp(lookUp_year, str_SQL, "IL", "YEAR"); lookUp_year.EditValue = Decimal.Parse(year);
                        
            str_SQL = "select level||'. Semester' as d, level as v from dual connect by level <= 2";
            con.load_lookUp(lookUp_semester, str_SQL, "D", "V"); lookUp_semester.EditValue = Decimal.Parse(sem);

            str_SQL = "(select 2||dp.prog_code||dp.dep_code_f as id, dp.dep_code_f ,  '     ' || dp.prog_code||' - '||dp.edu_lang||' : '||dp.title_en as title " +
                      "from dbmaster.departments f left join dbmaster.dep_programs dp on dp.dep_code_f = f.dep_code and dp.son = 1 " +
                      "where  f.type = 'F' and f.son = 1) union( select 1||f.dep_code as id,  f.dep_code, f.dep_code||' - '||f.title_en as title " +
                      "from dbmaster.departments f where  f.type = 'F' and f.son = 1) order by 2,1";
            con.load_checkedCombo(checkedCombo_departments, str_SQL, "TITLE", "ID"); //checkedCombo_departments.Text = "Bütün bölmələr";

            str_SQL = "select t.status_id, t.title_en as title from dbmaster.stud_status t";
            con.load_lookUp(lookUp_status, str_SQL, "TITLE", "STATUS_ID"); lookUp_status.EditValue = 1;

            str_SQL = "select s.stud_action_id, s.title_en as stud_action_title from stud_action s where s.is_active = 1 order by s.stud_action_title";
            con.load_checkedCombo(checkedCombo_decision, str_SQL, "STUD_ACTION_TITLE", "STUD_ACTION_ID");

            str_SQL = "select t.discount_type_id as id, t.discount_type_title as title from discount_type t where dis_level = 0 order by t.discount_type_title";
            con.load_checkedCombo(checkedCombo_discounts, str_SQL, "TITLE", "ID");
                         
            //CultureInfo provider = CultureInfo.InvariantCulture; ,"dd.MM.yyyy", CultureInfo.InvariantCulture           
        }

        private void lookUp_year_EditValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(lookUp_year.EditValue.ToString());
            date_begin.DateTime = Convert.ToDateTime("08/01/" + lookUp_year.EditValue.ToString());
        }

        private void checkedCombo_departments_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string parent = "", id = "";
                faculties = "'%'"; departments = "'%'"; ; text = string.Empty;
                if (checkedCombo_departments.EditValue.ToString().Length > 0)
                {
                    foreach (string str in checkedCombo_departments.EditValue.ToString().Split(','))
                    {
                        id = str.Trim();
                        if (id.Substring(0, 1) == "1")
                        {
                            faculties = faculties + ",'" + id.Substring(1, id.Length - 1) + "'";
                            parent = id.Substring(1, id.Length - 1);
                            text = text + id.Substring(1, id.Length - 1) + ", ";
                        }
                        else
                        {
                            if (id.Substring(6, id.Length - 6).ToString() != parent)
                            {
                                departments = departments + ", " + id.Substring(1, 5);
                            }

                            text = text + id.Substring(1, 5) + ", ";
                        }
                       
                    }
                    if (text.Length > 0) text = text.Substring(0, text.Length - 2); // Son vergülü sil.
                }
                checkedCombo_class_EditValueChanged(sender, e);
            }
            catch { }    
        }

        private void checkedCombo_class_EditValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(Pages.SelectedTabPageIndex.ToString());
            switch (Pages.SelectedTabPageIndex)
            {
                case 0: button_show_paid.PerformClick(); break;
                case 1: button_not_calculated.PerformClick(); break;
                case 2: button_debt.PerformClick(); break;
                case 3: button_discounts.PerformClick(); break;
                case 4: button_payment_percent.PerformClick(); break;
            }                      
        }

        private void OnPopup(object sender, EventArgs e)
        {
            CheckedListBoxControl listBoxControl = GetListBox(sender);
            listBoxControl.ItemCheck += OnItemCheck;           
        }

        private static CheckedListBoxControl GetListBox(object sender)
        {
            PopupContainerForm form = (sender as IPopupControl).PopupWindow as PopupContainerForm;
            CheckedListBoxControl listBoxControl = null;
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is PopupContainerControl)
                {
                    foreach (Control c in (ctrl as PopupContainerControl).Controls)
                    {
                        if (c is CheckedListBoxControl)
                        {
                            listBoxControl = c as CheckedListBoxControl;
                            break;
                        }
                    }
                    break;
                }
            }
            return listBoxControl;
        }

        bool needItemCheck = true;

        void OnItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (!needItemCheck) return;
            CheckedListBoxControl listBox = sender as CheckedListBoxControl;
            if (e.Index == 0) return;
            CheckedListBoxItem grItem = listBox.Items[e.Index];

            if (grItem.Value.ToString().Substring(0, 1) == "1")
            {
                needItemCheck = false;
                UpdateGroupItems(e.State, listBox, grItem);
                needItemCheck = true;
                return;
            }
            else
            {
                needItemCheck = false;
                UpdateMyGroups(listBox, grItem.Value.ToString().Substring(1, 5));
                needItemCheck = true;
            }
        }

        private void UpdateGroupItems(CheckState state, CheckedListBoxControl listBox, CheckedListBoxItem grItem)
        {
            List<CheckedListBoxItem> grItems = GetGroupItems(grItem.Value, listBox.Items);
            foreach (CheckedListBoxItem item in grItems)
            {
                if (item.CheckState != state) item.CheckState = state;
            }
        }

        void UpdateMyGroups(CheckedListBoxControl listBox, string id)
        {
            for (int i = 1; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i].Value.ToString() == id)
                {
                    CheckedListBoxItem gr = listBox.Items[i];
                    gr.CheckState = ItemsCheckStyle(gr.Value, listBox.Items);
                }
            }            
        }

        private List<CheckedListBoxItem> GetGroupItems(object val, CheckedListBoxItemCollection items)
        {
            List<CheckedListBoxItem> grItems = new List<CheckedListBoxItem>();
            for (int i = 1; i < items.Count; i++)
            {
                if (!items[i].Enabled || items[i].Value.ToString().Substring(0, 1) == "1") continue;
                if (items[i].Value.ToString().Substring(6, items[i].Value.ToString().Length - 6) == val.ToString().Substring(1, val.ToString().Length - 1)) grItems.Add(items[i]);
            }
            return grItems;
        }

        CheckState ItemsCheckStyle(object val, CheckedListBoxItemCollection items)
        {
            //if (items.Count < 4) return CheckState.Unchecked;
            List<CheckedListBoxItem> grItems = GetGroupItems(val, items);
            int count = grItems.FindAll(c => c.CheckState == CheckState.Checked).Count;
            return count == grItems.Count ? CheckState.Checked : count == 0 ? CheckState.Unchecked : CheckState.Indeterminate;
        }

        private void OnCloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {            
            CheckedListBoxControl listBoxControl = GetListBox(sender);
            CheckAll = (listBoxControl.Items[0].CheckState == CheckState.Checked);
            listBoxControl.ItemCheck -= OnItemCheck;           
        }

        private void checkedCombo_departments_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (CheckAll) e.DisplayText = "Bütün Bölmələr"; else e.DisplayText = text;
        }

        private void button_excel_Click(object sender, EventArgs e)
        {
            saveFile_excel.DefaultExt = "xls";
            saveFile_excel.Filter = "Excel files (*.xls)|*.xls";            
            if (saveFile_excel.ShowDialog() == DialogResult.OK) view_thstatistics.ExportToExcelOld(saveFile_excel.FileName);                       
            //MessageBox.Show(checkedCombo_departments.EditValue.ToString() + " - " + CheckAll.ToString());
        }

        private void button_show_paid_Click(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            str_SQL = "select to_char(p.payment_date, 'dd.mm.yyyy') as payment_date, p.stud_id, st.name, st.surname, " +
                      "(select f.title_en from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.son = 1) as faculty, "+
                      "dp.title_en || ' - ' || dp.edu_lang as department, st.class, s.title_en as status,"+
                      "(select a.stud_action_title from stud_action a where a.stud_action_id = u.action_id) as decision, "+
                      "decode(p.payment_code, 101, 'BANK', 'NORMAL') as type, p.payment_amount "+
                      "from stud_payments p left outer join dbmaster.students st on st.stud_id = p.stud_id "+
                      "left join dbmaster.stud_prog sp on sp.stud_id = st.stud_id "+
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' "+
                      "left outer join dbmaster.stud_status s on s.status_id = st.status "+
                      "left outer join stud_action_used u on u.stud_id = p.stud_id and u.son = 1 "+
                      "where dp.prog_type = 'M' and exists(select pc.payment_code_id from payment_code pc where pc.payment_code_id = p.payment_code and pc.is_payment = 1) " +
                      "and trunc(p.payment_date) between to_date('" + date_begin.Text + "','dd.mm.yyyy') and to_date('" + date_end.Text + "','dd.mm.yyyy') " +
                      "and p.payment_year = " + lookUp_year.EditValue.ToString() + " and p.payment_sem = " + lookUp_semester.EditValue.ToString();
            if (checkedCombo_class.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (st.class in (" + checkedCombo_class.EditValue.ToString() + "))";
            if (checkedCombo_departments.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (dp.prog_code in (" + departments + ") or dp.dep_code_f in (" + faculties + "))";            
            str_SQL = str_SQL + " order by p.payment_date";
            bind.DataSource = con.GetDataTable(str_SQL); 
            grid_thstatistics.DataSource = bind;
            button_excel.Enabled = (view_thstatistics.RowCount > 0);
            view_thstatistics.Columns["PAYMENT_DATE"].SummaryItem.DisplayFormat = "Sayı : {0}";
            view_thstatistics.Columns["PAYMENT_AMOUNT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["PAYMENT_DATE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        }

        private void button_not_calculated_Click(object sender, EventArgs e)
        {            
            string str_SQL = "select st.stud_id, st.name, st.surname, dp.title_en||decode(dp.edu_lang,'EN',' (EN)','') as department, st.class, s.title_en as status, "+
                            "(select a.stud_action_title from stud_action a where a.stud_action_id = u.action_id) as decision "+
                            "from dbmaster.students st left join dbmaster.stud_prog sp on sp.stud_id = st.stud_id "+
                            "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' "+
                            "left outer join dbmaster.stud_status s on s.status_id = st.status "+
                            "left outer join dbmaster.stud_info i on i.stud_id = st.stud_id "+
                            "left outer join stud_action_used u on u.stud_id = st.stud_id and u.son = 1 "+
                            "where dp.prog_type = 'M' and  i.year <= " + lookUp_year.EditValue.ToString() + " and st.status = 1 and not exists " +
                            "(select p.stud_id from stud_payments p where  p.payment_year = " + lookUp_year.EditValue.ToString() +
                            " and p.payment_sem = " + lookUp_semester.EditValue.ToString() + " and p.payment_code = 400 and p.stud_id = st.stud_id)";
            
            if (checkedCombo_class.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (st.class in (" + checkedCombo_class.EditValue.ToString() + "))";
            if (checkedCombo_departments.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (dp.prog_code in (" + departments + ") or dp.dep_code_f in (" + faculties + "))";
            str_SQL = str_SQL + " order by st.class, dp.prog_code";
            bind.DataSource = con.GetDataTable(str_SQL);
            grid_thstatistics.DataSource = bind;
            button_excel.Enabled = (view_thstatistics.RowCount > 0);
            view_thstatistics.Columns["STUD_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;                       
        }

        private void button_debt_Click(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            str_SQL = "select sp.stud_id, m.name, m.surname, (select c.title_en from dbmaster.country c where c.id = i.country_id) as COUNTRY,"+
                      "(select f.title_en from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.son = 1) as faculty,"+
                      "dp.title_en ||' - '|| dp.edu_lang as department, m.class, (select s.title_en from dbmaster.stud_status s where s.status_id = m.status) as status, " +
                      "sp.payment_amount as FEE, nvl(p.payment_remainder, sp.payment_amount + sp.payment_remainder) as DEBT, " +
                      "nvl(p.payment_remainder, sp.payment_amount + sp.payment_remainder) - ((sp.payment_amount * " + spin_percent.Value.ToString() + ") / 100) as MUST_PAY "+
                      "from stud_payments sp "+
                      "left outer join stud_payments p on p.stud_id = sp.stud_id and p.payment_year = sp.payment_year and p.payment_sem = sp.payment_sem and p.payment_active = 1 "+
                      "left outer join dbmaster.students m on m.stud_id = sp.stud_id  left join dbmaster.stud_prog sp on sp.stud_id = m.stud_id "+
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M'  "+
                      "left outer join dbmaster.stud_info i on i.stud_id = sp.stud_id where  dp.prog_type = 'M' and sp.payment_code = 400 "+
                      "and sp.payment_year = " + lookUp_year.EditValue.ToString() + " and sp.payment_sem = " + lookUp_semester.EditValue.ToString() + " and " +
                      "nvl(p.payment_remainder, sp.payment_amount + sp.payment_remainder) > ((sp.payment_amount * " + spin_percent.Value.ToString() + ") / 100) + " + spin_amount.Value.ToString();

            if (checkedCombo_class.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (m.class in (" + checkedCombo_class.EditValue.ToString() + "))";
            if (checkedCombo_departments.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and  (dp.prog_code in (" + departments + ") or dp.dep_code_f in (" + faculties + "))";
            if (check_permitted.Checked) str_SQL = str_SQL + " and not exists (select t.stud_id from th_stud_acc t where t.end_date >= sysdate and t.stud_id = p.stud_id)";
            str_SQL = str_SQL + " and i.dovlet_sifarisli = 0 order by dp.prog_code, MUST_PAY desc"; 
            bind.DataSource = con.GetDataTable(str_SQL);
            grid_thstatistics.DataSource = bind;
            button_excel.Enabled = (view_thstatistics.RowCount > 0);
            view_thstatistics.Columns["FEE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["DEBT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //view_thstatistics.Columns["DÖVREDƏN"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["MUST_PAY"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["STUD_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        }

        private void grid_thstatistics_DoubleClick(object sender, EventArgs e)
        {
            //if (view_thstatistics.RowCount > 0) MessageBox.Show(view_thstatistics.RowCount.ToString());
        }

        private void button_payment_percent_Click(object sender, EventArgs e)
        {
            string str_SQL = "select (select e.title_en from dbmaster.edu_levels e where e.level_code = dp.edu_level) as EDU_LEVEL, s.class, sum(decode(si.gender_id, 1, 1, 0)) as FEMALE," +
                             "sum(decode(si.gender_id, 2, 1, 0)) as MALE, count(*) as SUM, sum(decode(p.stud_id, NULL, 0, 1)) as CALCULATED, sum(decode(p.stud_id, NULL, 1, 0)) " +
                             "as NOT_CALCULATED, sum(nvl(sp.payment_remainder, p.payment_amount + p.payment_remainder)) as DEBT, sum(pm.payment_amount) as PAID, " +
                             "sum(sp.payment_remainder) as REMAINDER, to_char((sum(pm.payment_amount) / sum(nvl(sp.payment_remainder, p.payment_amount + p.payment_remainder))) * 100, '99.99') as PERCENTAGE " +
                             "from dbmaster.students s left outer join stud_payments p on p.stud_id = s.stud_id and p.payment_year =" + lookUp_year.EditValue.ToString() + " and p.payment_sem =  "
                             + lookUp_semester.EditValue.ToString() +" and p.payment_code = 400 " +
                             "left outer join stud_payments sp on sp.stud_id = s.stud_id and sp.payment_active = 1 and sp.payment_year = p.payment_year and sp.payment_sem = p.payment_sem " +
                             "left outer join stud_payments pm on pm.stud_id = s.stud_id and exists(select pc.payment_code_id from payment_code pc where pc.payment_code_id = pm.payment_code " +
                             "and pc.is_payment = 1) and pm.payment_year = p.payment_year and pm.payment_sem = p.payment_sem " +
                             "left outer join stud_action_used u on u.stud_id = s.stud_id and u.is_active = 1 and u.son = 1 " +
                             "left outer join dbmaster.stud_info si on si.stud_id = s.stud_id left join dbmaster.stud_prog stp on stp.stud_id = s.stud_id " +
                             "left join dbmaster.dep_programs dp on dp.prog_code = stp.prog_code and dp.year = stp.prog_year and dp.prog_type = 'M' " +
                             "where dp.prog_type = 'M'  and s.status = 1 ";

            if (checkedCombo_decision.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and u.action_id in (" + checkedCombo_decision.EditValue.ToString() + ")";
            if (checkedCombo_class.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (s.class in (" + checkedCombo_class.EditValue.ToString() + "))";
            if (checkedCombo_departments.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (dp.prog_code in (" + departments + ") or dp.dep_code_f in (" + faculties + "))";
            str_SQL = str_SQL + " group by dp.edu_level, s.class order by dp.edu_level"; 
                       
            bind.DataSource = con.GetDataTable(str_SQL);
            grid_thstatistics.DataSource = bind;
            button_excel.Enabled = (view_thstatistics.RowCount > 0);
            view_thstatistics.Columns["SUM"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["FEMALE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["MALE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["CALCULATED"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["NOT_CALCULATED"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["DEBT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["PAID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["REMAINDER"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        }

        private void button_discounts_Click(object sender, EventArgs e)
        {            
            string str_SQL = "select ds.stud_id, s.name, s.surname, (select c.title_en from dbmaster.country c where c.id = t.country_id) as COUNTRY, "+
                      "(select f.title_en from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.son = 1) as faculty, "+
                      "dp.title_en||' - '||dp.edu_lang as department, s.class, ss.title_en as status, " +
                      "(select a.stud_action_title from stud_action a where a.stud_action_id = u.action_id) as decision, dt.discount_type_title as type, t.fee, "+
                      "decode(ds.discounts_id, 581, (select sum(cd.amount / 2) from custom_discount cd where cd.stud_id = ds.stud_id and "+
                      "cd.custom_discount_year = decode(cd.disc_apply_reccur, 1, cd.custom_discount_year, ds.discount_year)), 1485,  "+
                      "(select cf.amount from campus_fee cf where cf.stud_id = ds.stud_id and cf.fee_year = ds.discount_year and cf.fee_sem = ds.discount_sem), "+
                      "t.fee * d.discounts_amount / 100) as amount, d.discounts_amount as PERCENTAGE "+
                      "from discounted_students ds left outer join discounts d on d.discounts_id = ds.discounts_id "+
                      "left outer join (select ds.list_id, ds.stud_id, ds.discount_year, ds.discount_sem, case when i.fee_year < 2007 then df.fee + (df.fee * 15 / 100) else df.fee end fee, i.country_id from discounted_students ds "+
                      "                  left outer join discounts d on d.discounts_id = ds.discounts_id "+
                      "                  left outer join dep_fee df on df.dep_fee_id = d.discountstype left outer join dbmaster.stud_info i on i.stud_id = ds.stud_id "+
                      "                  where d.d_type_id = 1) t on t.stud_id = ds.stud_id and t.discount_year = ds.discount_year and t.discount_sem = ds.discount_sem "+
                      "left outer join discount_type dt on dt.discount_type_id = d.discountstype "+
                      "left outer join dbmaster.students s on s.stud_id = ds.stud_id "+
                      "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                      "left outer join dbmaster.stud_status ss on ss.status_id = s.status "+
                      "left outer join stud_action_used u on u.stud_id = ds.stud_id and u.is_active = 1 and u.son = 1 "+
                      "where dp.prog_type = 'M' and d.d_type_id = 2 and ds.discount_year = " + lookUp_year.EditValue.ToString() + 
                      " and ds.discount_sem = " + lookUp_semester.EditValue.ToString();
        
            if (checkedCombo_discounts.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and d.discountstype in (" + checkedCombo_discounts.EditValue.ToString() + ")";
            if (checkedCombo_class.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (s.class in (" + checkedCombo_class.EditValue.ToString() + "))";
            if (checkedCombo_departments.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (dp.prog_code in (" + departments + ") or dp.dep_code_f in (" + faculties + "))";
            str_SQL = str_SQL + " order by dp.prog_code, s.class";

            bind.DataSource = con.GetDataTable(str_SQL);
            grid_thstatistics.DataSource = bind;
            button_excel.Enabled = (view_thstatistics.RowCount > 0);
            view_thstatistics.Columns["FEE"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["AMOUNT"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view_thstatistics.Columns["STUD_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        }

        private void THStatistics_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void THStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }
    }
}
