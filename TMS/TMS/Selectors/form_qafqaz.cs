using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DB;
using Globals;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraTreeList.Nodes;
using Oracle.DataAccess.Client;

namespace TMS.Selectors
{
    public partial class form_qafqaz : Form
    {
        private int id = 0;
        oraConn con = oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();
        ConditionValidationRule notSelectedValidationRule = new ConditionValidationRule();

        public form_qafqaz(int _id = 0)
        {
            id = _id;
            InitializeComponent();
        }

        private void form_qafqaz_Load(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            lookUp_edulevel.EditValue = "";
            group_university.Text = "Qafqaz Universiteti";
            if (id > 0)
            {
                TH.frmTH f = this.Owner as TH.frmTH;                
                TreeListNode node = f.tlStudMezUni.Selection[0];
                lookUp_edulevel.EditValue = node[f.tlStudMezUniColEduLevelId].ToString();                
                group_university.Text = node[f.tlStudMezUniColValue].ToString();
                textEdit_ixtisas.Text = node.Nodes[0][f.tlStudMezUniColValue].ToString();
                txtDiplomNo.Text = node.Nodes[1][f.tlStudMezUniColValue].ToString();
                if (node.Nodes[2][f.tlStudMezUniColValue].ToString() == "") dtDiplomVerTarix.EditValue = null;
                else
                {
                    DateTime dt;
                    DateTime.TryParseExact(node.Nodes[2][f.tlStudMezUniColValue].ToString(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out dt);
                    dtDiplomVerTarix.DateTime = dt;
                }
                txtQeydiyyatNo.Text = node.Nodes[3][f.tlStudMezUniColValue].ToString();
                chbFerqlenme.Checked = node.Nodes[4][f.tlStudMezUniColValue] != null && node.Nodes[4][f.tlStudMezUniColValue].ToString() == "Fərqlənmə";                
            }

            str_SQL = "select t.level_code as id, t.title_az as title from dbmaster.edu_levels t";
            con.load_lookUp(lookUp_edulevel, str_SQL, "TITLE", "ID");

            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            notEmptyValidationRule.ErrorText = "Məlumat girilməyib";

            notSelectedValidationRule.ConditionOperator = ConditionOperator.NotEquals;
            notSelectedValidationRule.Value1 = 0; notSelectedValidationRule.ErrorText = "Məlumat seçilməyib";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;
            List<OracleParameter> lst = new List<OracleParameter>();            
            dxValidationProvider_university.SetValidationRule(textEdit_ixtisas, notEmptyValidationRule);
            dxValidationProvider_university.SetValidationRule(lookUp_edulevel, notSelectedValidationRule);

            dxValidationProvider_university.Validate();

            if (dxValidationProvider_university.GetInvalidControls().Count > 0) MessageBox.Show("Xahiş olunur məlumatları əksiksiz doldurasınız..!", "Əksik Məlumat");
            else
            {
                if (id > 0) str_SQL = "update dbmaster.stud_mezun_uni u set u.level_code = :edulevel, u.ixtisas_ad = :ixtisas, u.diplom_no = :diplomNo, u.diplom_ver_tarix = :diplomDate, " +
                                      "u.diplom_qeyd_no = :qeydNo, u.diplom_ferqlenme = :ferqlenme where u.mez_uni_id =  " + id;
                else str_SQL = "insert into dbmaster.stud_mezun_uni(stud_id, uni_id, level_code, ixtisas_ad, diplom_no, diplom_ver_tarix, diplom_qeyd_no, diplom_ferqlenme) " +
                               "values('" + si.StudID + "', 3709, :edulevel, :ixtisas, :diplomNo, :diplomDate, :qeydNo, :ferqlenme)";
                                
                lst.Add(con.SetParameter("edulevel", OracleDbType.Varchar2, 3, ParameterDirection.Input, lookUp_edulevel.EditValue));
                lst.Add(con.SetParameter("ixtisas", OracleDbType.Varchar2, 200, ParameterDirection.Input, textEdit_ixtisas.Text));
                lst.Add(con.SetParameter("diplomNo", OracleDbType.Varchar2, 30, ParameterDirection.Input, txtDiplomNo.Text));
                lst.Add(con.SetParameter("diplomDate", OracleDbType.Date, 25, ParameterDirection.Input, dtDiplomVerTarix.EditValue));
                lst.Add(con.SetParameter("qeydNo", OracleDbType.Varchar2, 30, ParameterDirection.Input, txtQeydiyyatNo.Text));
                lst.Add(con.SetParameter("ferqlenme", OracleDbType.Int16, 1, ParameterDirection.Input, chbFerqlenme.Checked ? 1 : 0));

                try
                {
                    con.execSQL(str_SQL, lst);
                    DialogResult = DialogResult.OK;
                }
                catch (OracleException oex) { MessageBox.Show(oex.Message); }
            }
        }
    }
}
