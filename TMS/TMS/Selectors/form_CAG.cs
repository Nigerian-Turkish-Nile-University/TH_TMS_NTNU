using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraTreeList.Nodes;
using DB;
using Oracle.DataAccess.Client;
using Globals;

namespace TMS.Selectors
{
    public partial class form_CAG : Form
    {
        private int id = 0;
        oraConn con = oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
        ConditionValidationRule notSelectedValidationRule = new ConditionValidationRule();

        public form_CAG(int _id = 0)
        {
            id = _id;
            InitializeComponent();
        }

        private void form_CAG_Load(object sender, EventArgs e)
        {
            string str_SQL = string.Empty; 
            if (id == 0) lookUp_company.EditValue = 0;
            str_SQL = "select t.parent_type_id id, t.title_en title, t.gender_id, t.weight from dbmaster.parent_type t union select 0, 'Özü', NULL, 0 from dual order by weight";            
            con.load_lookUp(lookUp_type, str_SQL, "TITLE", "ID");

            str_SQL = "select t.title_id as id, trim(t.title) as title from dbmaster.addable_titles t where t.type = 3 and t.lang_code = 'AZ' " +
                      "union select 0, ' '||i.interface_lang_title_en from dbmaster.interface_lang i where i.interface_lang_id = 225 order by 2";
            con.load_lookUp(lookUp_company, str_SQL, "TITLE", "ID"); 

            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "No data entered";

            notSelectedValidationRule.ConditionOperator = ConditionOperator.NotEquals;
            notSelectedValidationRule.Value1 = 0; notSelectedValidationRule.ErrorText = "No data selected";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();
            dxValidationProvider_CAG.SetValidationRule(lookUp_type, notEmptyValidationRule);
            dxValidationProvider_CAG.SetValidationRule(textEdit_name, notEmptyValidationRule);            
            dxValidationProvider_CAG.SetValidationRule(textEdit_surname, notEmptyValidationRule);
            dxValidationProvider_CAG.SetValidationRule(lookUp_company, notSelectedValidationRule);

            dxValidationProvider_CAG.Validate();

            if (dxValidationProvider_CAG.GetInvalidControls().Count > 0) MessageBox.Show("Please, fill all required fields..!", "MISSING DATA");
            else
            {
                if (id > 0) str_SQL = "update partner_disc_info pd set rel_type_id = :rtID, company_id = :company, name = :name, surname = :sname, approved = :approved where pd.info_id = " + id;
                else str_SQL = "insert into partner_disc_info(stud_id, rel_type_id, company_id, name, surname, approved) values('" + si.StudID + "', :rtID, :company, :name, :sname, :approved)";

                lst.Add(con.SetParameter("rtID", OracleDbType.Int16, 2, ParameterDirection.Input, lookUp_type.EditValue.ToString() == "0" ? null: lookUp_type.EditValue));
                lst.Add(con.SetParameter("company", OracleDbType.Int32, 10, ParameterDirection.Input, lookUp_company.EditValue));                
                lst.Add(con.SetParameter("name", OracleDbType.Varchar2, 30, ParameterDirection.Input, textEdit_name.Text));
                lst.Add(con.SetParameter("sname", OracleDbType.Varchar2, 30, ParameterDirection.Input, textEdit_surname.Text.Trim()));
                lst.Add(con.SetParameter("approved", OracleDbType.Varchar2, 50, ParameterDirection.Input, check_confirm.Checked ? 1 : 0));
                
                try
                {
                    con.execSQL(str_SQL, lst.ToArray()); DialogResult = DialogResult.OK;
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
        }

        private void edit_name_Validating(object sender, CancelEventArgs e)
        {
            dxValidationProvider_CAG.Validate();
        }

        private void lookUp_company_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int result = 0;
            string msg = string.Empty;

            if (e.Button.Index == 1)
            {
                msg = String.Format("Are you sure adding \"{1}\" into {0} list?", label_company.Text, lookUp_company.Text);
                if (lookUp_company.Text.Trim() != "" && lookUp_company.Text.Trim() != lookUp_company.GetColumnValue("TITLE").ToString().Trim())
                {
                    if ((MessageBox.Show(msg, label_company.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {
                        result = InsAddableTitle(3, lookUp_company.Text.Trim(), "AZ");
                        if (result > 0)
                        {
                            msg = "select t.title_id as id, trim(t.title) as title from dbmaster.addable_titles t where t.type = 3 and t.lang_code = 'AZ' " +
                                  "union select 0, ' '||i.interface_lang_title_en from dbmaster.interface_lang i where i.interface_lang_id = 225 order by 2";
                            con.load_lookUp(lookUp_company, msg, "TITLE", "ID");
                            lookUp_company.EditValue = Convert.ToDecimal(result);
                        }
                    }
                }
            }
        }

        private int InsAddableTitle(Int32 pAddableTypeId, string pAddableTitle, string pLangCode = null, string pRelId = null, string pParentID = null, Int16 pRes = 0)
        {
            if (pAddableTypeId <= 0 && pAddableTitle.Trim() == "") return 0;
            try
            {
                OracleParameter[] prms = { 
                           con.SetParameter("pAddableTypeId", OracleDbType.Int32, -1, ParameterDirection.Input, pAddableTypeId),
                           con.SetParameter("pAddableTitle", OracleDbType.Varchar2, -1, ParameterDirection.Input, pAddableTitle),
                           con.SetParameter("pRes", OracleDbType.Int16, -1, ParameterDirection.InputOutput, pRes),
                           con.SetParameter("pLangCode", OracleDbType.Char, -1, ParameterDirection.InputOutput, pLangCode),
                           con.SetParameter("pParentID", OracleDbType.Int32, -1, ParameterDirection.InputOutput, pParentID),
                           con.SetParameter("pRelId", OracleDbType.Int32, -1, ParameterDirection.InputOutput, pRelId),
                    };
                int res = Convert.ToInt32(con.ExecSProcRetVal("dbmaster.pkg_telebe_prog.InsAddableTitle", prms, "pRes").ToString());
                return res;
            }
            catch (OracleException oex)
            {
                MessageBox.Show(oex.Message);
                return oex.Number;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
