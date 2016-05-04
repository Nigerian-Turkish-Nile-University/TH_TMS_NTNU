using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DB;
using Oracle.DataAccess.Client;
using System.Runtime.InteropServices;
using Globals;

namespace TMS.TH
{
    public partial class odeme : Form
    {
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        public odeme()
        {
            InitializeComponent();
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            Boolean ok; Decimal amount = 0;
            string Path = browse_excel.Text;
            string msg = check_pCode.Checked ? "BANK" : "NORMAL";
            string stud_ID = "", pay_date = "", pRes = string.Empty;
            
            // initialize the Excel Application class            
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // create the workbook object by opening  the excel file.
            Workbook workBook = app.Workbooks.Open(Path, 0, true, 5, "", "", true,
            XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        
            // Get The Active Worksheet Using Sheet Name Or Active Sheet
            //Worksheet worksheet = (Worksheet)sheets.get_Item(1);
            Worksheet workSheet = (Worksheet)workBook.ActiveSheet;
            
            // This row,column index should be changed as per your need. That is which cell in the excel you are interesting to read.
            object rowIndex = 0; object colIndex1 = 1; object colIndex2 = 2;
            int index = 1, imported = 1;
            DateTime excelDateTime = new DateTime(0);
            if (MessageBox.Show("Are you sure to import payments as " + msg + " payment?", "IMPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            try
            {
                richText_error.Clear(); 
                check_pCode.Enabled = false; 
                button_import.Enabled = false;
                do
                {
                    ok = true; amount = 0; stud_ID = ""; pay_date = "";
                    for (int i = 1; i <= 3; i++) if (((Range)workSheet.Cells[index, i]).Value2 == null) ok = false;
                    if (((Range)workSheet.Cells[index, 1]).Value2 != null)
                    {
                        stud_ID = ((Range)workSheet.Cells[index, 1]).Value2.ToString().PadLeft(9, '0');
                        if (((Range)workSheet.Cells[index, 2]).Value2 != null) amount = Convert.ToDecimal(((Range)workSheet.Cells[index, 2]).Value2);
                        if (((Range)workSheet.Cells[index, 3]).Value2 != null) pay_date = ((Range)workSheet.Cells[index, 3]).Text.ToString();
                        //if (((Range)workSheet.Cells[index, 3]).Value2 != null) excelDateTime = Convert.ToDateTime(((Range)workSheet.Cells[index, 3]).Text.ToString()
                        if (!ok) richText_error.AppendText(stud_ID + " - " + amount.ToString() + " - " + pay_date.ToString() + " : Invalid data..!" + Environment.NewLine);
                    }
                    else { MessageBox.Show("Failure in Excel file. Please, the correctness of records in the file..!"); return; }
                    //MessageBox.Show(stud_ID + " - " + pay_date.ToString() + " - " + amount.ToString());

                    if (ok)
                    {   
                        List<OracleParameter> lst = new List<OracleParameter>();
                        lst.Add(con.SetParameter("pStud_ID", OracleDbType.Char, 9, ParameterDirection.Input, stud_ID));
                        lst.Add(con.SetParameter("pDate", OracleDbType.Varchar2, 10, ParameterDirection.Input, pay_date));
                        lst.Add(con.SetParameter("pAmout", OracleDbType.Decimal, 8, ParameterDirection.Input, amount));
                        lst.Add(con.SetParameter("pRes", OracleDbType.Int16, 3, ParameterDirection.InputOutput, check_pCode.Checked ? 101 : 100)); 
                        // Normalda, Bankdan olan ödemeler excel file ile import olur, code = 101. Deyilse code = 100
                        try
                        {
                            pRes = con.ExecSProcRetVal("TH_STUD_PAYMENT", lst.ToArray(), "pRes").ToString(); //MessageBox.Show(pRes);
                            if (pRes == "0") group_odeme.Text = "Importer record count is : " + (imported++);                            
                        }
                        catch (OracleException oex) { MessageBox.Show(oex.Message); }
                        switch (pRes)
                        {
                            case "1": richText_error.AppendText(stud_ID + " - " + amount.ToString() + " - " + pay_date.ToString() + " : Calculated Fee is MISSING for selected Student..!" + Environment.NewLine); break;
                            case "5": richText_error.AppendText(stud_ID + " - " + amount.ToString() + " - " + pay_date.ToString() + " : PAID amount is greater then DEBT..!" + Environment.NewLine); break;
                            default: richText_error.AppendText(stud_ID + " - " + amount.ToString() + " - " + pay_date.ToString() + " : OK" + Environment.NewLine); break;
                        }
                    }                                    
                    index++;
                } while (((Range)workSheet.Cells[index, 1]).Value2 != null); //MessageBox.Show(index + " - " + imported);
                if (index == imported) MessageBox.Show("All records SUCCESSIFULLY IMPORTED..!"); else MessageBox.Show("Import ended with Warnings..!");
                workBook.Close(true, Type.Missing, false); app.Quit(); Marshal.ReleaseComObject(workSheet);                
            }
            catch (Exception ex) { app.Quit(); MessageBox.Show(ex.Message); }
            check_pCode.Enabled = true;
        }

        private void browse_excel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            group_odeme.Text = "Get Excel File";
            this.openDialog_payments.FileName = "*.xls";
            if (this.openDialog_payments.ShowDialog() == DialogResult.OK)
            {
                browse_excel.Text = openDialog_payments.FileName;
                richText_error.Clear();
            }
            else browse_excel.Text = "";
            button_import.Enabled = (browse_excel.Text.Length > 0);
        }

        private void odeme_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void odeme_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }
    }
}
