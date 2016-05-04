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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Win;
namespace TMS.StudSearch
{
    public partial class frmStudSEARCH : Form
    {
        bool CheckAll = false;
        public string emp = null;
        oraConn con = oraConn.DB;
        bool needItemCheck = true;
        SelStudInfo si = new SelStudInfo();
        General.functions f = new General.functions();
        string faculties = "", departments = "", text = string.Empty;
        
        public frmStudSEARCH()
        {
            InitializeComponent();            
        }

        private void frmStudSEARCH_Load(object sender, EventArgs e)
        {
            LoadForm(); 
        }

        private void LoadForm()
        {
            string str_SQL = string.Empty;
            try
            {
                string sql = "select 0 as id, ' ALL' as title from dual union " +
                             "select s.stud_action_id, s.title_en from stud_action s where s.is_active = 1 order by 2";
                con.load_ComboBox(cmbSTATUS, sql, "title", "id"); cmbSTATUS.SelectedIndex = 0;

                sql = "select 0 as id, ' ALL' as title from dual union select t.status_id, t.title_en from dbmaster.stud_status t";
                con.load_ComboBox(combo_status, sql, "title", "id"); combo_status.SelectedIndex = 0;


                sql = "select 0 as id, ' ALL' as title from dual union select t.education_type_id, t.title_en from dbmaster.education_type t";
                con.load_ComboBox(cmbEduTypeID, sql, "title", "id"); cmbEduTypeID.SelectedIndex = 0;

                sql = "select '0' as id, ' ALL'  as title, 0 from dual union select el.level_code as id, el.title_en as title, el.weight from dbmaster.edu_levels el order by 3";
                con.load_ComboBox(cmbStudEduLevel, sql, "title", "id");

                str_SQL = "select lpad(' ', 5 * (level - 1))||decode(d.prog_code, NULL, '', d.prog_code||' - '||d.edu_lang||' : ')||d.title as title, level||d.prog_code||nvl(d.dep_code_f, d.dep_code) as id " +
                          "from view_departments d start with d.dep_code_f is NULL connect by prior d.dep_code = d.dep_code_f ORDER SIBLINGS BY d.prog_code";
                con.load_checkedCombo(checkedCombo_departments, str_SQL, "TITLE", "ID");
            }
            catch (ArgumentOutOfRangeException e) {
            }
        }

        private void filter_stud()
        {
            string sb = string.Empty;
            try
            {
                sb = "select s.stud_id, s.name, s.surname, dp.prog_code, s.class, (select ss.title_en from dbmaster.stud_status ss where ss.status_id = s.status) as status, " +
                     "(select sa.title_en from stud_action sa where sa.stud_action_id = a.action_id) as qerar, sp.prog_year, dp.edu_level from dbmaster.students s " +
                     "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id left join stud_action_used a on a.stud_id = s.stud_id and a.is_active = 1 and a.son = 1 " +
                     "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' " +                            
                     "left join dbmaster.parent_info p on p.parent_type_id = 1 and p.stud_id = s.stud_id where dp.prog_type = 'M' ";
                
                if (txtSTUD_ID.Text.Trim() != "") sb += " and s.stud_id like '" + txtSTUD_ID.Text.Trim() + "%'";
                if (txtNAME.Text.Trim() != "") sb += " and lower(s.name) like '" + txtNAME.Text.Replace("'", "''").ToLower() + "%'";
                if (txtSURNAME.Text.Trim() != "") sb += " and lower(s.surname) like '" + txtSURNAME.Text.Replace("'", "''").ToLower() + "%'";
                if (txtATA_AD.Text.Trim() != "") sb += " and lower(p.parent_info_name) like '" + txtATA_AD.Text.Replace("'", "''").ToLower() + "%'";
                
                if (checkedCombo_class.EditValue.ToString().Length > 0) sb += " and (s.class in (" + checkedCombo_class.EditValue.ToString() + "))";
                
                if (Convert.ToInt16(cmbSTATUS.SelectedValue) > 0) sb += " and a.action_id = " + cmbSTATUS.SelectedValue.ToString();
                
                if (Convert.ToInt16(combo_status.SelectedValue) > 0) sb += " and s.status = " + combo_status.SelectedValue.ToString();

                if (Convert.ToInt16(cmbEduTypeID.SelectedValue) > 0) sb += " and dp.edu_type_id = " + cmbEduTypeID.SelectedValue.ToString();

                if (cmbStudEduLevel.SelectedValue.ToString().Trim() != "0") sb += " and dp.edu_level = '" + cmbStudEduLevel.SelectedValue.ToString() + "' ";

                if (checkedCombo_departments.EditValue.ToString().Length > 0) sb += " and (dp.prog_code in (" + departments + ") or dp.dep_code_f in (" + faculties + ")) ";

                //Rəhbər`ə tələbələr vermək üçün 
                if (emp != null)
                {
                    sb += " and not exists (select h.stud_id from dbmaster.stud_info_hist h where h.stud_id = s.stud_id and h.year = " + f.GetCfgActVal("DAN_IL_SEM")[0].ToString();
                    sb += " and h.term = " + f.GetCfgActVal("DAN_IL_SEM")[1].ToString() + " and h.stud_rehber = " + emp + ")"; //(cari il ve donemde(DAN_IL_SEM) üzerinde olmayanlar)
                }                
                
                dgvSTUD_MAIN.DataSource = con.GetDataTable(sb); 
                if (dgvSTUD_MAIN.RowCount == 0) image_stud.Image = TMS.Properties.Resources.no_foto; else dgvSTUD_MAIN.Focus();
                btnSEC.Enabled = button_images.Enabled = dgvSTUD_MAIN.RowCount > 0;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }       

        private void btnSEC_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSTUD_MAIN.SelectedRows.Count > 0)
                {                    
                    if (timer_images.Enabled)
                    {
                        if (MessageBox.Show("Are you sure to STOP exporting student photos?", "Export Photos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) timer_images.Stop();
                    }
                    DialogResult = DialogResult.OK;                    
                }
            }
            catch (Exception) { MessageBox.Show("Error occured!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }        

        private void dgvSTUD_MAIN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSEC.PerformClick();
        }       

        private void dgvSTUD_MAIN_SelectionChanged(object sender, EventArgs e)
        {            
            try
            {
                string sql = "SELECT FOTO from dbmaster.stud_FOTO WHERE length(foto) > 0 and stud_id = '" + dgvSTUD_MAIN.SelectedRows[0].Cells["stud_id"].Value.ToString() + "'";
                OracleDataReader dr = con.execSQL(sql);
                if (dr.Read())
                {
                    byte[] byteData = (byte[])(dr["foto"]);
                    if (byteData.Length > 0)
                    {
                        // Open a stream for the image and write the bytes into it
                        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteData, true);
                        stream.Write(byteData, 0, byteData.Length);
                        // Create a bitmap from the stream
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
                        image_stud.Image = bmp;
                        // Close the stream
                        stream.Close();
                    }
                    else image_stud.Image = TMS.Properties.Resources.no_foto;
                }
                else image_stud.Image = TMS.Properties.Resources.no_foto;
                dr.Close();
            }
            catch (Exception) { }
        }

        private void button_images_Click(object sender, EventArgs e)
        {                
            if (folderBrowser_images.ShowDialog() == DialogResult.OK) 
            {                
                progressBar_images.Position = 0; progressBar_images.Properties.Maximum = dgvSTUD_MAIN.RowCount; timer_images.Enabled = true;
            }
        }

        private void btnLegvEt_Click(object sender, EventArgs e)
        {
            timer_images.Stop();            
        }

        private void dgvSTUD_MAIN_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.KeyCode == Keys.Enter);
            if (e.KeyCode == Keys.Enter) btnSEC.PerformClick();            
        }

        private void txtSTUD_ID_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.KeyCode == Keys.Escape) this.Close(); else if (e.KeyCode == Keys.Enter) filter_stud();
        }

        private void txtNAME_KeyDown(object sender, KeyEventArgs e)
        {
            if ((sender as TextBox).Text.Trim().Length == 0) (sender as TextBox).Text = (sender as TextBox).Text.Trim();
            if (e.KeyCode == Keys.Escape) this.Close(); else if (e.KeyCode == Keys.Enter) filter_stud();                         
        }

        private void checkedCombo_departments_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            CheckedListBoxControl listBoxControl = GetListBox(sender);
            CheckAll = (listBoxControl.Items[0].CheckState == CheckState.Checked);
            listBoxControl.ItemCheck -= OnItemCheck;
        }

        void OnItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (!needItemCheck) return;
            CheckedListBoxControl listBox = sender as CheckedListBoxControl;
            if (e.Index == 0) return;
            CheckedListBoxItem grItem = listBox.Items[e.Index];

            if (grItem.Value.ToString().Substring(0, 1) == "1") // Level 1 seçilibsə, demeli qrupdu. Qrupun altındakıları da seç...
            {
                needItemCheck = false;
                UpdateGroupItems(e.State, listBox, grItem);
                needItemCheck = true;
                return;
            }
            else // Deyilse, demeli leaf(item)`dir. Seçilen item`in qrupunu tap, ona göre işarele...
            {
                needItemCheck = false;
                UpdateMyGroups(listBox, "1" + grItem.Value.ToString().Substring(6)); // Seçilen item`dan fakulteni götür ve fakulte ID oluşduraraq parametr olaraq ver.
                needItemCheck = true;
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

        CheckState ItemsCheckStyle(object val, CheckedListBoxItemCollection items)
        {
            List<CheckedListBoxItem> grItems = GetGroupItems(val, items);
            int count = grItems.FindAll(c => c.CheckState == CheckState.Checked).Count;
            return count == grItems.Count ? CheckState.Checked : count == 0 ? CheckState.Unchecked : CheckState.Indeterminate;
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

        private void UpdateGroupItems(CheckState state, CheckedListBoxControl listBox, CheckedListBoxItem grItem)
        {
            List<CheckedListBoxItem> grItems = GetGroupItems(grItem.Value, listBox.Items);
            foreach (CheckedListBoxItem item in grItems)
            {
                if (item.CheckState != state) item.CheckState = state;
            }
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
                            faculties = faculties + ",'" + id.Substring(1, id.Length - 1)+"'";
                            parent = id.Substring(1, id.Length - 1);
                            text = text + id.Substring(1, id.Length - 1) + ", ";
                        }
                        else
                        {
                            if (id.Substring(6, id.Length-6).ToString() != parent)
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

        private void OnPopup(object sender, EventArgs e)
        {
            CheckedListBoxControl listBoxControl = GetListBox(sender);
            listBoxControl.ItemCheck += OnItemCheck;
        }

        private void checkedCombo_departments_Resize(object sender, EventArgs e)
        {
            checkedCombo_departments.Properties.PopupFormSize = checkedCombo_departments.Properties.PopupFormMinSize = new Size(checkedCombo_departments.Size.Width, 200);
        }

        private void checkedCombo_class_EditValueChanged(object sender, EventArgs e)
        {
            filter_stud();
        }

        private void combo_status_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            if (Convert.ToInt16((sender as System.Windows.Forms.ComboBox).SelectedValue) >= 0) filter_stud();     
        }

        private void txtSTUD_ID_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSTUD_ID.Text.Trim().Length == 9) filter_stud();            
        }

        private void timer_images_Tick(object sender, EventArgs e)
        {
            int i = progressBar_images.Position;
            if (i >= progressBar_images.Properties.Maximum) timer_images.Stop();
            else try
                {
                    string str_SQL = "SELECT FOTO from dbmaster.stud_FOTO WHERE length(foto) > 0 and stud_id = " + dgvSTUD_MAIN.Rows[i].Cells["stud_id"].Value.ToString();
                    OracleDataReader dr = con.execSQL(str_SQL);
                    if (dr.Read())
                    {
                        byte[] byteData = (byte[])(dr["foto"]);
                        if (byteData.Length > 0)
                        {
                            // Open a stream for the image and write the bytes into it
                            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteData, true);
                            stream.Write(byteData, 0, byteData.Length);
                            // Create a bitmap from the stream
                            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
                            bmp.Save(folderBrowser_images.SelectedPath + "/" + dgvSTUD_MAIN.Rows[i].Cells["STUD_ID"].Value.ToString() + "_" + dgvSTUD_MAIN.Rows[i].Cells["NAME"].Value.ToString() + "_" + dgvSTUD_MAIN.Rows[i].Cells["SURNAME"].Value.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            // Close the stream
                            stream.Close();
                        }
                        else TMS.Properties.Resources.no_foto.Save(folderBrowser_images.SelectedPath + "/" + dgvSTUD_MAIN.Rows[i].Cells["STUD_ID"].Value.ToString() + "_" + dgvSTUD_MAIN.Rows[i].Cells["NAME"].Value.ToString() + "_" + dgvSTUD_MAIN.Rows[i].Cells["SURNAME"].Value.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else TMS.Properties.Resources.no_foto.Save(folderBrowser_images.SelectedPath + "/" + dgvSTUD_MAIN.Rows[i].Cells["STUD_ID"].Value.ToString() + "_" + dgvSTUD_MAIN.Rows[i].Cells["NAME"].Value.ToString() + "_" + dgvSTUD_MAIN.Rows[i].Cells["SURNAME"].Value.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    dr.Close(); progressBar_images.Position++;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            button_images.Enabled = (i >= progressBar_images.Properties.Maximum);
        }

        private void cmbStudEduLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter_stud();
        }
    }
}