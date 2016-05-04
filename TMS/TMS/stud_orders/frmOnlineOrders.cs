using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Oracle.DataAccess.Client;

namespace TMS.stud_orders
{
    public partial class frmOnlineOrders : DevExpress.XtraEditors.XtraForm
    {
        DB.oraConn con = DB.oraConn.DB;

        public frmOnlineOrders()
        {
            InitializeComponent();
        }

        private void frmOnlineOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            string sql = "select do.doc_order_id, do.doc_id, do.stud_id, decode(do.order_status, 1, 'Aktiv', 2, 'Hazır', 3, 'Ləğv') order_status, do.delivery_method, do.doc_lang_code, " +
                         "pb.amount||' AZN' as payment, d.title_az as doc_title, to_char(do.order_date, 'DD MON   HH24:MI') order_date from dbmaster.online_doc_orders do " +
                         "left outer join dbmaster.docs d on d.doc_id = do.doc_id left join dbmaster.payment_backref pb on pb.order_id = do.order_id and pb.terminal = do.terminal " +
                         "where do.order_status=" + (cmbStatus.SelectedIndex + 1).ToString();
            gcOrders.DataSource = con.GetDataTable(sql);
            if (gvOrders.FocusedRowHandle < 0) gcSifaris.Visible = false;
            LoadOrder();
        }

        private void gvOrders_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvOrders.FocusedRowHandle < 0) return;
            LoadOrder();
        }

        private string GetDeliveryMethodTextByCode(string dm)
        {
            if (dm == "1") return "Tələbənin özü Tədris Hissəsindən alacaq.";
            if (dm == "2") return "Email ünvanına göndəriləcək.";
            if (dm == "3") return "Zərfdə ünvanına göndəriləcək";
            return "Bilinməyən metod!";
        }

        private void LoadOrder() {
            if (gvOrders.FocusedRowHandle < 0)
            {
                gcSifaris.Visible = false;
                return;
            }
            try
            {
                string sql = "select pb.amount, do.doc_order_id, do.doc_id, do.user_email, do.stud_id, s.name || ' ' || s.surname stud_name, do.user_address, d.title_az doc_title, do.order_status, do.delivery_method, " +
                             "do.doc_lang_code from dbmaster.docs d, dbmaster.students s, dbmaster.online_doc_orders do left join dbmaster.payment_backref pb on pb.order_id = do.order_id and pb.terminal = do.terminal " +
                             "where s.stud_id = do.stud_id and do.doc_id = d.doc_id and do.doc_order_id = " + gvOrders.GetDataRow(gvOrders.FocusedRowHandle)["DOC_ORDER_ID"].ToString();

                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read())
                {
                    gcSifaris.Text = "Onlayn Sifariş № " + dr["DOC_ORDER_ID"].ToString();
                    gcSifaris.Tag = dr["DOC_ORDER_ID"].ToString();
                    //
                    if (dr["DOC_LANG_CODE"].ToString() == "AZ")
                    {
                        lblDocLang.Text = "Azərbaycanca";
                    } 
                    else if (dr["DOC_LANG_CODE"].ToString() == "EN")
                    {
                        lblDocLang.Text = "English";
                    }
                    else if (dr["DOC_LANG_CODE"].ToString() == "TR")
                    {
                        lblDocLang.Text = "Türkçe";
                    }
                    else
                    {
                        lblDocLang.Text = "yoxdur";
                    }
                    lblDeliveryMethod.Text = GetDeliveryMethodTextByCode(dr["DELIVERY_METHOD"].ToString());
                    memoUserAddr.Text = "";
                    if (dr["DELIVERY_METHOD"].ToString() == "2")
                        memoUserAddr.Text = dr["USER_EMAIL"].ToString();
                    if (dr["DELIVERY_METHOD"].ToString() == "3")
                        memoUserAddr.Text = dr["USER_ADDRESS"].ToString();

                    lblStudName.Text = dr["DOC_ID"].ToString();
                    lblDocTitle.Text = dr["DOC_TITLE"].ToString();
                    txtStudID.Text = dr["STUD_ID"].ToString();
                    lblStudName.Text = dr["STUD_NAME"].ToString();
                    if (dr["AMOUNT"].ToString() != "")
                    {
                        lblAmount.Text = Convert.ToDecimal(dr["AMOUNT"].ToString()) + " AZN";
                        lblAmount.Tag = Convert.ToDecimal(dr["AMOUNT"].ToString());
                    }
                    else
                    {
                        lblAmount.Text = "pulsuz";
                        lblAmount.Tag = "";
                    }

                    btnSifarisHazir.Tag = dr["ORDER_STATUS"].ToString();
                    if (btnSifarisHazir.Tag.ToString() == "1")
                    {
                        btnSifarisHazir.Enabled = true;
                        btnSifarisHazir.ForeColor = Color.Black;
                        btnCancelOrder.Visible = true;
                    }
                    else
                    {
                        btnCancelOrder.Visible = false;
                        btnSifarisHazir.Enabled = false;
                        btnSifarisHazir.ForeColor = Color.DarkGreen;
                    }
                    
                }
                gcSifaris.Visible = true;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Xəta baş verdi 8.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnSifarisHazir_Click(object sender, EventArgs e)
        {
            if (gvOrders.FocusedRowHandle < 0)
            {
                return;
                //gvOrders.GetDataRow(gvOrders.FocusedRowHandle)["DOC_ORDER_ID"].ToString()
            }
            if (MessageBox.Show("Sifarişin hazırlandığı qeyd olunsun?", Properties.Settings.Default.ProgramName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    OracleParameter[] prms = { 
                           con.SetParameter("pDocOrderId", OracleDbType.Int32, -1, ParameterDirection.Input, Convert.ToInt32(gcSifaris.Tag.ToString())),
                           con.SetParameter("pOrderStatus", OracleDbType.Int32, -1, ParameterDirection.Input, 2  ),
                           con.SetParameter("pReason", OracleDbType.Varchar2, -1, ParameterDirection.Input, ""  ),
                           con.SetParameter("pRes", OracleDbType.Varchar2, 9, ParameterDirection.InputOutput, "1")
                    };

                    string res = con.ExecSProcRetVal("dbmaster.pkg_gen.UpdOnlineDocOrderStud", prms, "pRes").ToString();
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xəta baş verdi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                return;
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (lblAmount.Tag.ToString() != "")
            {
                MessageBox.Show("Tələbənin ödəmə etdiyi sifarişi ləğv edə bilməzsiniz!");
                return;
            }
            string sebeb = Prompt.ShowDialog("Tələbəyə ləğv etmə səbəbini bildirin.", "Ləğv səbəbi");
            if (sebeb == "")
            {
                MessageBox.Show("Ləğv edilmənin səbəbi boşdur! Sifariş ləğv edilmədi.", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Sifarişi ləğv etmək istəyirsinizmi?", Properties.Settings.Default.ProgramName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //string sebeb = Prompt.ShowDialog("Tələbəyə ləğv etmə səbəbini bildirin.", "Ləğv səbəbi");
                //if(sebeb
                try
                {
                    OracleParameter[] prms = { 
                           con.SetParameter("pDocOrderId", OracleDbType.Int32, -1, ParameterDirection.Input, Convert.ToInt32(gcSifaris.Tag.ToString())),
                           con.SetParameter("pOrderStatus", OracleDbType.Int32, -1, ParameterDirection.Input, 3  ),
                           con.SetParameter("pReason", OracleDbType.Varchar2, -1, ParameterDirection.Input, sebeb  ),
                           con.SetParameter("pRes", OracleDbType.Varchar2, 9, ParameterDirection.InputOutput, "1")
                    };

                    string res = con.ExecSProcRetVal("dbmaster.pkg_gen.UpdOnlineDocOrderStud", prms, "pRes").ToString();
                    LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Xəta baş verdi.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                return;
            }
        }

    }
}