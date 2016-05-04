using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;
using DB;
using Oracle.DataAccess.Client;
using Microsoft.VisualBasic;


namespace TMS.ekders
{
    public partial class ekDers_mevacib : DevExpress.XtraEditors.XtraForm
    {        
        General.functions f = new General.functions();
        oraConn con = oraConn.DB;
        public ekDers_mevacib()
        {
            InitializeComponent();
        }

        private void ekDers_mevacib_Load(object sender, EventArgs e)
        {
            string str_SQL = "";
            lookUp_year.EditValue = f.GetCfgActVal("CARI_IL_SEM")[0].ToString();
            str_SQL = "select distinct t.year from dbmaster.ekders_tesdiq t where t.is_active = 1 order by t.year desc";
            con.load_lookUp(lookUp_year, str_SQL, "YEAR", "YEAR");
                        
            for (int i = 0; i < 12; i++) combo_month.Properties.Items.Add(DateTimeFormatInfo.CurrentInfo.MonthNames[i]);
            combo_month.SelectedIndex = DateTime.Now.Month - 2;            
        }

        private void view_employee_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {            
            if (e.Column.FieldName == "SIRA") e.DisplayText = (e.RowHandle + 1).ToString();            
        }

        private void view_employee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string str_SQL = "";
            grid_courses.DataSource = null;
            label_teacher.Text = label_mevacib.Text = string.Empty;
            if (view_employee.SelectedRowsCount == 1 || e.FocusedRowHandle == 0)
            {                
                label_mevacib.Text = view_employee.GetRowCellValue(e.FocusedRowHandle, "MAAS").ToString();
                label_teacher.Text = view_employee.GetRowCellValue(e.FocusedRowHandle, "MÜƏLLİM").ToString(); label_mevacib.Text = label_mevacib.Text.Length > 0 ? label_mevacib.Text + " AZN" : "";
                str_SQL = "select (select decode(ds.type, 'N', d.k_teor + d.k_prat, d.k_lab) from dbmaster.ders d where d.ders_kod = ds.ders_kod and d.year = ds.year) as SAAT, " +
                          "ed.ders_yuku as YÜK, decode(ed.ders_type, 'N', 'Normal dərs', 'M', 'Manual əlavə edilən',  'T', 'Tez danışmanlığı') as DƏRS_TİPİ, " +
                          "decode(ed.ders_sobe_id, NULL, ed.title, ds.ders_kod||'.'||ds.section||' - '||(select d.title_az from dbmaster.ders d where d.ders_kod = ds.ders_kod and d.year = ds.year)) as DƏRS " +
                          "from dbmaster.ekders_dersler ed left outer join dbmaster.ders_sobe ds on ds.ders_sobe_id = ed.ders_sobe_id " +
                          "where ed.tesdiq_id = " + view_employee.GetRowCellValue(e.FocusedRowHandle, "TESDIQ_ID").ToString() + " order by ed.ders_sobe_id";
                grid_courses.DataSource = con.GetDataTable(str_SQL);
                view_courses.BestFitColumns();
            }
            else label_teacher.Text = label_mevacib.Text = string.Empty;
        }

        private void view_employee_RowCountChanged(object sender, EventArgs e)
        {
            button_excel.Enabled = (view_employee.RowCount > 0);
        }

        private void button_excel_Click(object sender, EventArgs e)
        {            
            saveFile_excel.FileName = "ElaveDersCixaris_" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "_" + DateTime.Now.Hour + "." + DateTime.Now.Minute;            
            saveFile_excel.Filter = "Excel files (*.xls)|*.xls";
            if (saveFile_excel.ShowDialog() == DialogResult.OK) 
            { 
                view_employee.ExportToExcelOld(saveFile_excel.FileName);
                if (MessageBox.Show("Would you like to open excel file?", "Open", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(saveFile_excel.FileName);
                }
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            string pRes = string.Empty, empList = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            if (view_employee.SelectedRowsCount > 0) foreach (int rowHandle in view_employee.GetSelectedRows())
            {
                if (view_employee.GetDataRow(rowHandle)["MAAS"] == DBNull.Value)
                {
                    string teacherName = view_employee.GetDataRow(rowHandle)["MÜƏLLİM"].ToString();
                    MessageBox.Show("Not Calculated extra course payments, can't be APPROVED!", "WARNING - " + teacherName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                empList = empList + view_employee.GetDataRow(rowHandle)["TESDIQ_ID"].ToString() + ",";
            }
            else return;
            if (empList.Length > 0) empList = empList.Substring(0, empList.Length - 1); // Son vergülü sil.            
            
            lst.Add(con.SetParameter("pTesdiqIdStr", OracleDbType.Varchar2, -1, ParameterDirection.Input, empList));            
            lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 1000, ParameterDirection.InputOutput, 0));

            if (MessageBox.Show("Are you sure to approve extra course payments for the selected teachers?", "APPROVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            try
            {
                pRes = con.ExecSProcRetVal("dbmaster.pkg_ekders.ConfirmMidRequestsByFin", lst.ToArray(), "pRes").ToString();
                if (int.Parse(pRes) > 0) lookUp_year_EditValueChanged(sender, null);
                //MessageBox.Show("Təsdiqlənən rekord sayısı : " + pRes, "SONUC");
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void button_reject_Click(object sender, EventArgs e)
        {
            string pRes, note = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();            

            PromptMessage:
            note = Interaction.InputBox(view_employee.GetRowCellValue((view_employee.GetSelectedRows()[0]), "MÜƏLLİM").ToString() + " üçün hesablanmış ƏLAVƏ DƏRS MƏVACİBİ`ni LƏĞV ETMƏK istədiyinizdən əminsiniz?\n\nLƏĞV ETMƏ SƏBƏBİ :", "LƏĞV", " ");
            if (note != "") if (note.Trim() == "") goto PromptMessage;
            else try
            {
                lst.Add(con.SetParameter("pTesdiqId", OracleDbType.Int32, 10, ParameterDirection.Input, view_employee.GetRowCellValue((view_employee.GetSelectedRows()[0]), "TESDIQ_ID")));
                lst.Add(con.SetParameter("pNote", OracleDbType.Varchar2, 300, ParameterDirection.Input, note));
                lst.Add(con.SetParameter("pAction", OracleDbType.Int32, 1, ParameterDirection.Input, 0));
                lst.Add(con.SetParameter("pRes", OracleDbType.Decimal, 1000, ParameterDirection.InputOutput, 0));

                pRes = con.ExecSProcRetVal("dbmaster.pkg_ekders.ConfirmOrCancelByFin", lst.ToArray(), "pRes").ToString();
                if (int.Parse(pRes) > 0) lookUp_year_EditValueChanged(sender, null);
            }
            catch (OracleException oex) { MessageBox.Show(oex.Message); }
        }

        private void view_employee_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {            
            button_reject.Enabled = (view_employee.SelectedRowsCount == 1 && combo_status.SelectedIndex == 1);             
        }

        private void lookUp_year_EditValueChanged(object sender, EventArgs e)
        {
            string str_SQL = "";
            label_teacher.Text = label_mevacib.Text = string.Empty;
            grid_employee.DataSource = grid_courses.DataSource = null; 
            str_SQL = "select NULL as Sıra, t.tesdiq_id, e.name||' '||e.sname as MÜƏLLİM, " +
                      "(select sum(ds.ders_saat) from dbmaster.ekders_dersler ed left outer join dbmaster.ekders_derssaat ds on ds.ek_dersler_id = ed.ek_dersler_id where ed.tesdiq_id = t.tesdiq_id) as saat, " +
                      "t.maas, decode(t.type, 'A', 'AUTO', 'M', 'MANUAL', t.type) as TƏSDİQ, (select s.title_az from dbmaster.status s where s.status_id = e.status) as TİP, " +
                      "(select stat.title_az from dbmaster.stat where stat.stat_id = e.stat_id) as ŞTAT, (select st.title_az from dbmaster.state st where st.state_id = e.state) as İŞ_VƏZİYYƏTİ, " +
                      "(select g.gorev_ad_az from dbmaster.gorev g where g.gorev_id = eg.gorev_id) as ƏSAS_VƏZİFƏ, " +
                      "(select d.title_az from dbmaster.departments d where d.dep_code = eg.dep_code and d.son = 1) as İŞLƏDİYİ_ŞÖBƏ from dbmaster.ekders_tesdiq t " +
                      "left outer join dbmaster.employee e on e.emp_id = t.emp_id left outer join dbmaster.emp_gorev eg on eg.emp_id = t.emp_id and eg.esas_gorev = 1 and eg.status = 1 " +
                      "where t.is_active = 1 and t.status = " + (combo_status.SelectedIndex + 1) + " and t.year = " + lookUp_year.EditValue + 
                      " and t.month = " + (combo_month.SelectedIndex + 1) + " order by e.name, e.sname";
            grid_employee.DataSource = con.GetDataTable(str_SQL);
            view_employee.Columns["TESDIQ_ID"].Visible = false;
            view_employee.Columns["MAAS"].AppearanceCell.ForeColor = Color.Red;
            view_employee.Columns["TİP"].MinWidth = view_employee.Columns["TİP"].MaxWidth = 60;
            view_employee.Columns["SIRA"].MinWidth = view_employee.Columns["SIRA"].MaxWidth = 35; 
            view_employee.Columns["SAAT"].MinWidth = view_employee.Columns["SAAT"].MaxWidth = 40; 
            view_employee.Columns["MAAS"].MinWidth = view_employee.Columns["MAAS"].MaxWidth = 50;            
            view_employee.Columns["TƏSDİQ"].MinWidth = view_employee.Columns["TƏSDİQ"].MaxWidth = 60;            
            view_employee.Columns["MÜƏLLİM"].MinWidth = view_employee.Columns["MÜƏLLİM"].MaxWidth = 150;                                     
            view_employee.Columns["SIRA"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view_employee.Columns["SAAT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view_employee.Columns["MAAS"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view_employee.Columns["TƏSDİQ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            
            if (view_employee.RowCount > 0)
            {
                label_teacher.Text = view_employee.GetRowCellValue(0, "MÜƏLLİM").ToString();
                button_confirm.Enabled = button_reject.Enabled = combo_status.SelectedIndex == 1;
                str_SQL = "select (select decode(ds.type, 'N', d.k_teor + d.k_prat, d.k_lab) from dbmaster.ders d where d.ders_kod = ds.ders_kod and d.year = ds.year) as SAAT, " +                          
                          "ed.ders_yuku as YÜK, decode(ed.ders_type, 'N', 'Normal dərs', 'M', 'Manual əlavə edilən',  'T', 'Tez danışmanlığı') as DƏRS_TİPİ, " +
                          "decode(ed.ders_sobe_id, NULL, ed.title, ds.ders_kod||'.'||ds.section||' - '||(select d.title_az from dbmaster.ders d where d.ders_kod = ds.ders_kod and d.year = ds.year)) as DƏRS " +
                          "from dbmaster.ekders_dersler ed left outer join dbmaster.ders_sobe ds on ds.ders_sobe_id = ed.ders_sobe_id " +
                          "where ed.tesdiq_id = " + view_employee.GetRowCellValue(0, "TESDIQ_ID").ToString() + " order by ed.ders_sobe_id";
                grid_courses.DataSource = con.GetDataTable(str_SQL);
                view_courses.Columns["YÜK"].MinWidth = view_courses.Columns["YÜK"].MaxWidth = 50;
                view_courses.Columns["SAAT"].MinWidth = view_courses.Columns["SAAT"].MaxWidth = 50;                
                view_courses.Columns["DƏRS_TİPİ"].MinWidth = view_courses.Columns["DƏRS_TİPİ"].MaxWidth = 120;
            }
            else button_confirm.Enabled = button_reject.Enabled = false;            
        }
    }
}