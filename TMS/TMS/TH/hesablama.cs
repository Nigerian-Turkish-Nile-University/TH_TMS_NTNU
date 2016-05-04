using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DB;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors.Controls;
using Oracle.DataAccess.Client;

namespace TMS.TH
{
    public partial class hesablama : DevExpress.XtraEditors.XtraForm
    {
        string faculties = "", departments = "", text = string.Empty;
        General.functions f = new General.functions();        
        bool needItemCheck = true;
        oraConn con = oraConn.DB;
        bool CheckAll = false;

        public hesablama()
        {
            InitializeComponent();
            con.RepairConn();
        }

        private void hesablama_Load(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            str_SQL = "select lpad(' ', 5 * (level - 1))||decode(d.prog_code, NULL, '', d.prog_code||' - '||d.edu_lang||' : ')||d.title as title, level||d.prog_code||nvl(d.dep_code_f, d.dep_code) as id " +
                      "from view_departments d start with d.dep_code_f is NULL connect by prior d.dep_code = d.dep_code_f ORDER SIBLINGS BY d.prog_code";
            con.load_checkedCombo(checkedCombo_departments, str_SQL, "TITLE", "ID");

            str_SQL = "select distinct i.year from dbmaster.stud_info i where exists (select s.stud_id from dbmaster.students s where s.status = 1 and s.stud_id = i.stud_id) order by i.year desc";
            con.load_checkedCombo(checkedCombo_years, str_SQL, "YEAR", "YEAR");            
        }

        private void checkedCombo_departments_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {                     
            CheckedListBoxControl listBoxControl = GetListBox(sender);
            CheckAll = (listBoxControl.Items[0].CheckState == CheckState.Checked);
            listBoxControl.ItemCheck -= OnItemCheck;                   
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
                UpdateMyGroups(listBox, "1" + grItem.Value.ToString().Substring(6));
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

        private List<CheckedListBoxItem> GetGroupItems(object val, CheckedListBoxItemCollection items)
        {
            List<CheckedListBoxItem> grItems = new List<CheckedListBoxItem>();
            for (int i = 1; i < items.Count; i++)
            {
                if (!items[i].Enabled || items[i].Value.ToString().Substring(0, 1) == "1") continue;
                if (items[i].Value.ToString().Substring(6) == val.ToString().Substring(1)) grItems.Add(items[i]);
            }
            return grItems;
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

        CheckState ItemsCheckStyle(object val, CheckedListBoxItemCollection items)
        {            
            List<CheckedListBoxItem> grItems = GetGroupItems(val, items);
            int count = grItems.FindAll(c => c.CheckState == CheckState.Checked).Count;
            return count == grItems.Count ? CheckState.Checked : count == 0 ? CheckState.Unchecked : CheckState.Indeterminate;
        }

        private void checkedCombo_departments_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (CheckAll || e.Value.ToString().Length == 0) e.DisplayText = "All Departments"; else e.DisplayText = text; 
        }

        private void checkedCombo_departments_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string parent = "", id = "";
                faculties = "'%'"; departments = "'%'"; text = string.Empty;
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
            }
            catch { }            
        }

        private void OnPopup(object sender, EventArgs e)
        {
            CheckedListBoxControl listBoxControl = GetListBox(sender);
            listBoxControl.ItemCheck += OnItemCheck;
        }

        private void checkedCombo_departments_Resize(object sender, EventArgs e)
        {
            checkedCombo_departments.Properties.PopupFormSize = checkedCombo_departments.Properties.PopupFormMinSize = new Size(checkedCombo_departments.Size.Width, 200);            
        }

        private void checkedCombo_years_Resize(object sender, EventArgs e)
        {
            checkedCombo_years.Properties.PopupFormSize = checkedCombo_years.Properties.PopupFormMinSize = new Size(checkedCombo_years.Size.Width, 200);
        }

        private void button_show_Click(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            str_SQL = "select s.stud_id, s.name, s.surname, (select ss.title_en from dbmaster.stud_status ss where ss.status_id = s.status) as status, "+
                      "(select a.title_en from stud_action a where a.stud_action_id = u.action_id) as decision from dbmaster.students s left outer join dbmaster.stud_info i on i.stud_id = s.stud_id "+
                      "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' "+
                      "left outer join stud_action_used u on u.stud_id = s.stud_id and u.son = 1 where dp.prog_type = 'M' and s.status = 1 ";
            if (checkedCombo_years.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and i.year in (" + checkedCombo_years.EditValue.ToString() + ") ";
            if (checkedCombo_departments.EditValue.ToString().Length > 0) str_SQL = str_SQL + " and (dp.prog_code in (" + departments + ") or dp.dep_code_f in (" + faculties + ")) ";            
            if (!check_calculated.Checked) str_SQL = str_SQL + " and not exists(select p.stud_id from stud_payments p where p.stud_id = s.stud_id and p.payment_year = " + f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString() +
                                                               " and p.payment_sem = " + f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString() + ") ";
            grid_students.DataSource = con.GetDataTable(str_SQL);            
            view_students.Columns["STUD_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;            
            view_students.Columns["STUD_ID"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            button_calculate.Enabled = view_students.RowCount > 0; progressBar_calculated.Position = 0;
            view_students.OptionsCustomization.AllowSort = view_students.OptionsView.ShowAutoFilterRow = true;
            view_students.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
            button_show.Enabled = check_calculated.Enabled = checkedCombo_departments.Enabled = checkedCombo_years.Enabled = true;
        }

        private void view_students_RowCountChanged(object sender, EventArgs e)
        {
            button_calculate.Enabled = view_students.RowCount > 0;
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure, CALCULATING " + f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString() + " - " + f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString() +
                         " tuition FEES for sudents in the list?";
            if (MessageBox.Show(msg, "FEE CALCULATIONS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button_calculate.Enabled = button_show.Enabled = false;              
                check_calculated.Enabled = checkedCombo_departments.Enabled = checkedCombo_years.Enabled = false;
                view_students.OptionsCustomization.AllowSort = view_students.OptionsView.ShowAutoFilterRow = false;
                view_students.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
                progressBar_calculated.Position = 0; progressBar_calculated.Properties.Maximum = view_students.RowCount; timer_calculate.Enabled = true;                                
            }
        }

        private void timer_calculate_Tick(object sender, EventArgs e)
        {
            int i = progressBar_calculated.Position;
            if (i >= progressBar_calculated.Properties.Maximum)
            {
                timer_calculate.Stop(); 
                progressBar_calculated.Tag = progressBar_calculated.Position; 
                button_show.Enabled = true; button_show.PerformClick();
                progressBar_calculated.Position = Convert.ToInt32(progressBar_calculated.Tag);
            }
            else
            {
                string student = "", pRes = string.Empty;
                List<OracleParameter> lst = new List<OracleParameter>();
                student = view_students.GetRowCellValue(i, "STUD_ID").ToString();
                lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, student));
                lst.Add(con.SetParameter("pYear", OracleDbType.Int16, 4, ParameterDirection.Input, f.GetCfgActVal("TEHSIL_HAQQI")[0]));
                lst.Add(con.SetParameter("pSem", OracleDbType.Int16, 1, ParameterDirection.Input, f.GetCfgActVal("TEHSIL_HAQQI")[1]));
                lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 18, ParameterDirection.InputOutput, -1));

                try
                {
                    pRes = con.ExecSProcRetVal("TH_DISCOUNTED_STUDENTS", lst.ToArray(), "pRes").ToString(); 
                    progressBar_calculated.Position++;
                }
                catch (OracleException oex) { timer_calculate.Stop(); MessageBox.Show(oex.Message); button_show.Enabled = true; button_show.PerformClick(); }
                
            }                        
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            timer_calculate.Stop(); button_show.Enabled = true; button_show.PerformClick();
        }

        private void checkedCombo_years_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (e.Value.ToString().Length == 0) e.DisplayText = "All Years";
        }
    }
}