using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using DB;
using Globals;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace TMS.stud_orders
{
    public partial class frmStudAction : Form
    {        
        oraConn con = oraConn.DB;
        loginUserInfo lui = new loginUserInfo();
        Globals.SelStudInfo si = new SelStudInfo();
        General.functions f = new General.functions();
        public frmStudAction()
        {
            InitializeComponent();
        }       

        private void rbTek_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTek.Checked)
            {
                isToplu(false);
                LoadStudActionUsed();                
                rbGorunus.PerformClick();
            }
        }

        private void isToplu(bool b)
        {            
            checkedList_students.Enabled = label_students.Enabled = browse_students.Enabled = b;
        }

        private void rbCox_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCox.Checked)
            {
                isToplu(true);
                LoadStudActionUsed();                
                rbGorunus.PerformClick();  
            }
        }

        private void LoadStudActionUsed() 
        {
            string sql = string.Empty;
            try
            {                
                string sql_cond = "";
                gcAKMEZ_DATE.Visible = false;
                radioGroup_mezuniyyet.Visible = false;
                gridColumn_eduLevel.Visible = !rbTek.Checked;
                if (rbTek.Checked && si.StudID.Length != 9)
                {
                    gcActionUsed.DataSource = null;
                    group_buttons.Enabled = false;
                    return;
                }
                group_buttons.Enabled = !radio_mezuniyyet.Checked;                
                
                gcSTUD_ID.VisibleIndex = 0;
                gcFULLNAME.VisibleIndex = 1;
                
                gcFULLNAME.Visible = true;
                gcSTUD_ID.Visible = true;
                string stud_fullname = "u.stud_id, s.name||' '||s.surname as fullname, ";

                string sql_combo = "select level||decode(level, 3, '. Summer School', '. Semester') as d, level as v from dual connect by level <= 3";
                lookUp_semester.EditValue = f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.load_lookUp(lookUp_semester, sql_combo, "D", "V");

                if (rbTek.Checked)
                {
                    stud_fullname = "";
                    sql_cond = "and  u.stud_id = '" + si.StudID + "'";
                    sql_combo = "select (level + 1993) as year, (level + 1993)||'-'||to_char(level + 1994) as il from dual where (level + 1993) >= " + si.year + " connect by level <= (" + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " - 1993)";
                    gcFULLNAME.Visible = false;
                    gcSTUD_ID.Visible = false;

                    gcSTUD_ID.VisibleIndex = -1;
                    gcFULLNAME.VisibleIndex = -1;
                } else
                {
                    sql_combo = "select (level + 1993) as year, (level + 1993)||'-'||to_char(level + 1994) as il from dual connect by level <= (" + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " - 1993)";
                    if (radio_mezuniyyet.Checked)
                    {
                        sql_cond = "and u.action_id = 2 and u.son = 1 ";
                        if (radioGroup_mezuniyyet.EditValue.ToString() == "1") sql_cond = sql_cond + "and not exists(select m.stud_id from stud_ak_mezuniyyet m where trunc(m.end_date) > trunc(sysdate) and m.stud_id = u.stud_id)";
                        //label_olddep_text.Visible = false;
                        radioGroup_mezuniyyet.Visible = true;                        
                        gcAKMEZ_DATE.Visible = true;                        
                    }   
                }
                
                lookUp_year.EditValue = f.GetCfgActVal("CARI_IL_SEM")[0].ToString();
                con.load_lookUp(lookUp_year, sql_combo, "IL", "YEAR");
                                
                sql = "select a.status_id, u.act_used_id, u.action_id, a.title_en as stud_action_title, d.decision_no, d.decision_date, u.action_date, to_char(u.year) || '-' || to_char(u.year + 1) as ders_il, " +
                      "u.stud_class, u.decision_id, u.year, u.sem, dp.edu_level, (select t.end_date from stud_ak_mezuniyyet t where t.act_used_id = u.act_used_id) as AKMEZ_DATE, " + stud_fullname +
                      "dc.prog_code as NEWDEP, dc.prog_year, (select dp.title_en from dbmaster.dep_programs dp where dp.prog_code = dc.old_prog_code and dp.son = 1) as OLDDEP from stud_action_used u " +
                      "left join stud_action a on u.action_id = a.stud_action_id left join stud_decision d on u.decision_id = d.decision_id left outer join dbmaster.students s on s.stud_id = u.stud_id " +
                      "left outer join stud_dep_change dc on dc.act_used_id = u.act_used_id left outer join dbmaster.stud_prog sp on sp.stud_id = u.stud_id " +
                      "left outer join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.son = 1 and dp.prog_type = 'M' " +
                      "where dp.prog_type = 'M' and u.is_active = 1 " + sql_cond + " order by u.action_date desc";
                gcActionUsed.DataSource = con.GetDataTable(sql);
                if (gvActionUsed.RowCount > 0) gvActionChange();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }            
        }

        private void LoadPrograms()
        {
            string str_SQL; //" + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + "
            str_SQL = "select dp.prog_code dep_id, dp.prog_code || ' - ' || dp.title_en as title, nvl(dp.dep_code_f, dp.dep_code) dep_code, dp.haz_var is_haz, " +
                      "decode(dp.edu_level, 'B', 1, 'M', 2, 'DR', 4) edu_level_id, dp.edu_lang lang_code, d.dep_code as parent_id, d.title_en as parent_title " +
                      "from dbmaster.dep_programs dp, dbmaster.departments d where d.son = 1 and nvl(dp.dep_code_f, dp.dep_code)=d.dep_code and dp.son = 1 " +
                      "and (d.type = 'A' or d.type='F') and d.dep_code != 'DEP_DTK' order by dp.dep_code, dp.prog_code";

            gleDepartment.Properties.ValueMember = "DEP_ID";
            gleDepartment.Properties.DisplayMember = "TITLE";
            gvDepartments.Columns["PARENT_ID"].GroupIndex = 0;
            gleDepartment.Properties.DataSource = con.GetDataTable(str_SQL);
            gleDepartment.Properties.PopupFormMinSize = new Size(gleDepartment.Width, 0);
            gleDepartment.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            str_SQL = "select distinct dp.year from dbmaster.dep_programs dp order by dp.year desc";
            con.load_lookUp(lookUp_progYear, str_SQL, "YEAR", "YEAR");
        }
        
        private void LoadStudStatus()
        {
            string sql = "select 0 as STATUS_ID, '' as TITLE from dual";
            sql += " union";
            sql += " SELECT STATUS_ID,title_en as title FROM dbmaster.STUD_STATUS";
            sql += " order by STATUS_ID";
            con.load_ComboBox(cmbStatus, sql, "TITLE", "STATUS_ID");            
        }

        private void LoadStudAction(string status_id)
        {
            if (status_id == "" || status_id == "0")
            {
                cmbStudAction.DataSource = null;                
                cmbStudAction.Items.Add(0);
                cmbStudAction.Items.Clear();
                return;
            }
            string sql = string.Empty;            
            sql = "SELECT S.STUD_ACTION_ID, S.title_en as STUD_ACTION_TITLE FROM STUD_ACTION S " +
                  "WHERE S.STATUS_ID = " + status_id + " and s.is_active=1 union select 0, ' ' from dual order by STUD_ACTION_TITLE";
            con.load_ComboBox(cmbStudAction, sql, "STUD_ACTION_TITLE", "STUD_ACTION_ID");
        }

        private void btnCatUnv_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cmbStudAction.SelectedValue.ToString() != "") && (Convert.ToInt32(cmbStudAction.SelectedValue.ToString()) > 0))
                {
                    stud_act_orders.frmOrders frm = new TMS.stud_act_orders.frmOrders();
                    frm.txtOrderType.Tag = cmbStudAction.SelectedValue.ToString();
                    frm.txtOrderType.Text = cmbStudAction.Text;
                    if (browse_decision.Tag.ToString() != "")
                        frm.DecID = Convert.ToInt32(browse_decision.Tag.ToString());
                    if (frm.ShowDialog() == DialogResult.OK)
                    {                       
                        if (frm.gvDecision.SelectedRowsCount > 0)
                        {
                            browse_decision.Tag = frm.gvDecision.GetRowCellValue(frm.gvDecision.GetSelectedRows()[0], "DECISION_ID").ToString();
                            browse_decision.Text = frm.gvDecision.GetRowCellValue(frm.gvDecision.GetSelectedRows()[0], "DECISION_NO").ToString();
                        }
                    }
                    else
                    {
                        browse_decision.Tag = 0;
                        browse_decision.Text = "";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void rbAdd_CheckedChanged(object sender, EventArgs e)
        {
            label_olddep_text.Visible = label_old_dep.Visible = lBolum.Visible = gleDepartment.Visible = lookUp_progYear.Visible = !rbAdd.Checked;
            btnOper.Text = "ADD";
            btnOper.Visible = true;
            btnOper.Enabled = true;
            gbData.Enabled = true;             
            Yeni();
        }

        private void Yeni()
        {
            dtpTarix.Value = DateTime.Now;
            lookUp_progYear.EditValue = null;
            date_mezuniyyet_end.EditValue = null;
            lookUp_year.EditValue = Convert.ToDecimal(f.GetCfgActVal("CARI_IL_SEM")[0].ToString());             
            lookUp_semester.EditValue = Convert.ToDecimal(f.GetCfgActVal("CARI_IL_SEM")[1].ToString());
            if (lui.extra_field == "18100") // Mühasibatlıqdırsa
            {
                cmbStatus.SelectedValue = 1; cmbStatus.Enabled = false;
                LoadStudAction(cmbStatus.SelectedValue.ToString());
                cmbStudAction.SelectedValue = 1; cmbStudAction.Enabled = false;                
                lAkMezEndDate.Visible = date_mezuniyyet_end.Visible = false;
                browse_decision.Enabled = true;
            }
            else cmbStatus.SelectedValue = 0;
            
            browse_decision.Text = "";
            browse_decision.Tag = 0;            
            gleDepartment.Text = "";
            gleDepartment.EditValue = "";
        }     

        private void rbDel_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_change.Checked)
            {
                gvActionChange();
                gbData.Enabled = false;
                btnOper.Visible = true;
                btnOper.Enabled = ((gvActionUsed.RowCount > 0) && (gvActionUsed.GetSelectedRows()[0].ToString() != "-999997"));
                btnOper.Text = radio_change.Text;
            }
        }

        private string GetCheckedStudents()
        {
            string students = checkedList_students.CheckedItemsCount > 0 ? checkedList_students.CheckedItems[0].ToString() : string.Empty;
            for (int i = 1; i <= checkedList_students.CheckedItems.Count - 1; i++) students = students + "," + checkedList_students.CheckedItems[i].ToString();            
            return students;           
        }

        private void btnOper_Click(object sender, EventArgs e)
        {            
            if (rbAdd.Checked) insStudActUsed();
            else if (radio_change.Checked)
            {
                //delStudActUsed();
                if (gvActionUsed.GetSelectedRows()[0].ToString() == "-999997") return;
                try
                {
                    if ((gvActionUsed.SelectedRowsCount > 0) && (gvActionUsed.GetRowCellValue(gvActionUsed.GetSelectedRows()[0], "DECISION_ID").ToString() != ""))
                    {
                        stud_act_orders.frmOrders frm = new TMS.stud_act_orders.frmOrders();
                        frm.DecID = Convert.ToInt32(gvActionUsed.GetRowCellValue(gvActionUsed.GetSelectedRows()[0], "DECISION_ID").ToString());
                        frm.DecOperMode = OperMode.View;
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void delStudActUsed()
        {
            try
            {
                if (gvActionUsed.GetRowCellValue(gvActionUsed.GetSelectedRows()[0], "ACT_USED_ID").ToString() == "")
                    return;
                if (MessageBox.Show("Are you sure deleting data?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                OracleParameter[] prms = {                     
                    con.SetParameter("PACT_USED_ID", OracleDbType.Int32, 10,ParameterDirection.Input, Convert.ToInt32(gvActionUsed.GetRowCellValue(gvActionUsed.GetSelectedRows()[0], "ACT_USED_ID").ToString()))                
                    };
                con.ExecSProcRetVal("DEL_STUD_ACT_USED", prms);
                LoadStudActionUsed();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void insStudActUsed()
        {
            int apply_all;
            string stud_id = "", str_SQL = string.Empty, progCode = string.Empty;                        
                        
            try 
            {   
                stud_id = GetCheckedStudents();
                List<OracleParameter> lst = new List<OracleParameter>();
                if ((rbTek.Checked && (si.StudID.Length != 9)) || (rbCox.Checked && (stud_id == "")))
                {
                    MessageBox.Show("Student ID is MISSING!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    return;
                }

                if (rbTek.Checked) stud_id = si.StudID;

                apply_all = (check_apply_all.Checked) ? 1 : 0;

                /*
                int check_year
                check_year = (lookUp_semester.EditValue.ToString() == "1") ? Convert.ToInt16(lookUp_year.EditValue) : Convert.ToInt16(lookUp_year.EditValue) + 1;
                if (dtpTarix.Value.Year != check_year)
                {
                    MessageBox.Show("Əmrin tətbiq tarixi, seçilmiş il və semestrə uyğun deyil.", "Tarix uyğunsuzluğu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }*/

                str_SQL = "select ac.event_year, decode(ac.event_sem, 3, 2, ac.event_sem) as event_sem from dbmaster.academic_calendar ac where ac.event_id = 33 and :pDate between ac.event_start and ac.event_stop";                
                lst.Add(con.SetParameter("pDate", OracleDbType.Date, 10, ParameterDirection.Input, dtpTarix.Value));
                OracleDataReader dr = con.execSQL(str_SQL, lst);
                if (dr.Read())
                {
                    if (dr["EVENT_YEAR"].ToString() != lookUp_year.EditValue.ToString() || dr["EVENT_SEM"].ToString() != lookUp_semester.EditValue.ToString())
                    {
                        MessageBox.Show("Order Apply date is not COMPATIBLE with selected semester.", "DATE INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // ACADEMIC CALENDAR`dakı ilsem`e uyğun il ve semestr seçilməyibsə xəta ver - çıx...
                    }
                    dr.Close();
                }
                else
                { 
                    if (!(Convert.ToInt16(lookUp_year.EditValue) == dtpTarix.Value.Year || (Convert.ToInt16(lookUp_year.EditValue) + 1) == dtpTarix.Value.Year))
                    {
                        MessageBox.Show("Order Apply date is not COMPATIBLE with selected semester.", "DATE INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Seçilmiş tarixin ili, seçilmiş tədris ili ilə uyğun gəlmirsə, xəta ver - çıx...                   
                    }
                }

                if ((cmbStatus.SelectedIndex <= 0) || (cmbStatus.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Status is Missing!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((cmbStudAction.SelectedIndex <= 0) || (cmbStudAction.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Order type is Missing!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (((browse_decision.Tag.ToString() == "0") || (browse_decision.Tag.ToString() == "")) && (cmbStudAction.SelectedValue.ToString() != "23"))
                {
                    MessageBox.Show("Decision is Missing!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((cmbStudAction.SelectedValue.ToString() == "3") || (cmbStudAction.SelectedValue.ToString() == "15"))
                {
                    if (gleDepartment.EditValue == null || lookUp_progYear.EditValue == null) 
                    {
                        MessageBox.Show("Program or Year is MISSING!", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else try
                    {   
                        DataRowView drv = gleDepartment.GetSelectedDataRow() as DataRowView;
                        progCode = Convert.ToInt16(drv["DEP_ID"].ToString()) > 0 ? drv["DEP_ID"].ToString() : "";
                        if (si.DepID == progCode)
                        {
                            MessageBox.Show("Selected Program and Year can't be same with old value.", "DATA INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error);                            
                            return;
                        }
                        else
                        {
                            str_SQL = "select d.dep_code as source_code, dp.dep_code as dest_code from dbmaster.dep_programs dp , dbmaster.dep_programs d " +
                                      "where dp.prog_code = " + progCode + " and dp.year = " + lookUp_progYear.EditValue.ToString() + " and d.prog_code = " + si.DepID + " and d.year = " + si.edu_year;

                            OracleDataReader odr = con.execSQL(str_SQL);
                            if (odr.Read() && (odr["SOURCE_CODE"].ToString().Trim() + odr["DEST_CODE"].ToString().Trim()).Length > 0)
                            {
                                if (cmbStudAction.SelectedValue.ToString() == "3")
                                {
                                    if (odr["SOURCE_CODE"].ToString() == odr["DEST_CODE"].ToString())
                                    {
                                        MessageBox.Show("Change DEPARTMENT order CAN'T be applied to PROGRAMS.\nChoose, CHANGE SECTION order for this operation.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        odr.Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    if (odr["SOURCE_CODE"].ToString() != odr["DEST_CODE"].ToString())
                                    {
                                        MessageBox.Show("Changing SECTION can be performed only between PROGRAMS inside department.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        odr.Close();
                                        return;
                                    }
                                }                                
                            }
                            else
                            {
                                MessageBox.Show(lookUp_progYear.EditValue.ToString() + ". ildə, " + progCode + " kodlu proqram mövcud deyil.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            odr.Close();
                        }                
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (cmbStudAction.SelectedValue.ToString() == "2") 
                {
                    if ((date_mezuniyyet_end.Text.Length == 0) || (date_mezuniyyet_end.DateTime <= dtpTarix.Value))
                    {
                        MessageBox.Show("Ending date of REFER ORDER is Missing or Incorrect..!", "REFER ORDER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        str_SQL = "select count(*) as rec_count from dbmaster.ders_al a where a.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and a.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + " and a.stud_id = " + si.StudID;
                        dr = con.execSQL(str_SQL);
                        if (dr.Read() && Convert.ToInt16(dr["REC_COUNT"]) > 0)
                        {
                            if (MessageBox.Show("There are " + dr["REC_COUNT"].ToString() + " courses registered for the student in the current semester.\nAre you sure to continue?", "COURSES ARE TAKEN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                        }
                        else if (MessageBox.Show("All courses of the student registered for current semester will automatically deleted.\nAre you sure to continue?", "ADD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                        dr.Close();
                    }
                } else if (MessageBox.Show("Are you sure adding data?", "ADD", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }
            catch (Exception e) { MessageBox.Show(e.Message); return; }

            try // ora exception
            {                
                OracleParameter[] prms = 
                {                     
                    con.SetParameter("pACTION_ID", OracleDbType.Int16, 10,ParameterDirection.Input, Convert.ToInt16(cmbStudAction.SelectedValue)),
                    con.SetParameter("pSTUD_ID", OracleDbType.Char, 9000, ParameterDirection.Input, stud_id),       
                    con.SetParameter("pACTION_DATE", OracleDbType.Date, 10, ParameterDirection.Input, dtpTarix.Value),                                                            
                    con.SetParameter("pDECISION_ID", OracleDbType.Int32, 10, ParameterDirection.Input, Convert.ToInt32(browse_decision.Tag == "" ? 0 : browse_decision.Tag)),                                                            
                    con.SetParameter("pDEP_ID", OracleDbType.Char, 9, ParameterDirection.Input, progCode),                                        
                    con.SetParameter("AK_MEZ_END_DATE", OracleDbType.Date, 10, ParameterDirection.Input, date_mezuniyyet_end.DateTime),                                                            
                    con.SetParameter("MSG_ID", OracleDbType.Int32, 4, ParameterDirection.Output, 0),
                    con.SetParameter("IL", OracleDbType.Int16, 4, ParameterDirection.Input, Convert.ToInt16(lookUp_year.EditValue)),
                    con.SetParameter("SEMESTR", OracleDbType.Int16, 1, ParameterDirection.Input, Convert.ToInt16(lookUp_semester.EditValue)),
                    con.SetParameter("APPLY_ALL", OracleDbType.Int16, 1, ParameterDirection.Input, apply_all),                                        
                    con.SetParameter("pEduYear", OracleDbType.Int16, 4, ParameterDirection.Input, Convert.ToInt16(lookUp_progYear.EditValue))
                };
                string val = con.ExecSProcRetVal("INS_STUD_ACT_USED", prms, "MSG_ID").ToString(); //MessageBox.Show(val);
                LoadStudActionUsed(); rbGorunus.Select();
                                
                str_SQL = "select a.require_calc from stud_action a where a.stud_action_id = " + cmbStudAction.SelectedValue; 
                OracleDataReader dr = con.execSQL(str_SQL);
                if (dr.Read())
                {                    
                    if (dr["REQUIRE_CALC"].ToString() == "1" && MessageBox.Show("Fee could be changed after " + cmbStudAction.Text + " order.\nDo you want to ReCalculate?", "ReCalculate Fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TMS.frmMain mf = (TMS.frmMain)this.MdiParent; mf.TH_DISCOUNTED_STUDENTS(stud_id, false); // AUTO hesabla. MANUAL = false;                       
                        mf.TH_REFRESH(si.StudID, f.GetCfgActVal("TEHSIL_HAQQI")[0].ToString(), f.GetCfgActVal("TEHSIL_HAQQI")[1].ToString());
                    }
                }
                dr.Close();
            }
            catch (OracleException oe) 
            {                
                switch (oe.Number)
                {
                    case 20002: MessageBox.Show("Other orders CAN'T be applied before ending defer..! Please, apply END DEFER order first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 20003: MessageBox.Show("Change DEPARTMENT order CAN'T be applied to PROGRAMS.\nChoose, CHANGE SECTION order for this operation.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error); break;                    
                    case 20011: MessageBox.Show("System couldn't change Fee Year when applying FAIL ORDER.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 20012: MessageBox.Show("Student type is INCOMPATABLE with NEW REGISTRATION order.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 20013: MessageBox.Show("END REFER order can't be applied unless there is no REFER order...!", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 20015: MessageBox.Show("Changing SECTION can be performed only between PROGRAMS inside department.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 20018: MessageBox.Show("VISITING STUDENT REGISTRATION order can be applied only to guest Students.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    case 20023: MessageBox.Show("Program Year can be changed only in active semester.", "INCOMPATIBILITY", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                    default: MessageBox.Show("OPERATION COULDN'T BE PERFORMED.\n Message: " + oe.Message, "UNSUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                }                
            }            
        }

        private void rbGorunus_CheckedChanged(object sender, EventArgs e)
        {
            btnOper.Visible = false;
            gvActionChange();
            gbData.Enabled = false;
        }    

        private void gvActionUsed_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gvActionChange();
            if ((e.FocusedRowHandle.ToString() == "-999997") && radio_change.Checked)
            {
                btnOper.Enabled = false;
                label_old_dep.Text = string.Empty;
                label_olddep_text.Visible = false;
            }
        }

        private void gvActionChange()
        {
            try
            {
                ControlOperBtn(); //(rbGorunus.Checked || radio_change.Checked) && (gvActionUsed.SelectedRowsCount > 0)
                if (rbAdd.Checked || gvActionUsed.SelectedRowsCount == 0) label_old_dep.Visible = label_olddep_text.Visible = false; 
                else
                {
                    int SelRow = gvActionUsed.GetSelectedRows()[0];
                    lookUp_year.EditValue = Convert.ToDecimal(gvActionUsed.GetRowCellValue(SelRow, "YEAR").ToString());
                    lookUp_semester.EditValue = Convert.ToDecimal(gvActionUsed.GetRowCellValue(SelRow, "SEM").ToString());
                    
                    if (gvActionUsed.GetRowCellValue(SelRow, "ACTION_DATE").ToString() != "")
                        dtpTarix.Value = Convert.ToDateTime(gvActionUsed.GetRowCellValue(SelRow, "ACTION_DATE").ToString());
                    if (gvActionUsed.GetRowCellValue(SelRow, "STATUS_ID").ToString() != "")
                        cmbStatus.SelectedValue = Convert.ToInt16(gvActionUsed.GetRowCellValue(SelRow, "STATUS_ID").ToString());

                    if (gvActionUsed.GetRowCellValue(SelRow, "ACTION_ID").ToString() != "")
                    {
                        date_mezuniyyet_end.Visible = lAkMezEndDate.Visible = (gvActionUsed.GetRowCellValue(SelRow, "ACTION_ID").ToString() == "2");
                        cmbStudAction.SelectedValue = Convert.ToInt16(gvActionUsed.GetRowCellValue(SelRow, "ACTION_ID").ToString());
                        if (gvActionUsed.GetRowCellValue(SelRow, "ACTION_ID").ToString() == "2")
                        {
                            date_mezuniyyet_end.Visible = lAkMezEndDate.Visible = true;
                            if (gvActionUsed.GetRowCellValue(SelRow, "AKMEZ_DATE").ToString() == "") date_mezuniyyet_end.EditValue = null;
                            else date_mezuniyyet_end.DateTime = Convert.ToDateTime(gvActionUsed.GetRowCellValue(SelRow, "AKMEZ_DATE"));
                        }
                        
                        if (gvActionUsed.GetRowCellValue(SelRow, "ACTION_ID").ToString() == "3" || gvActionUsed.GetRowCellValue(SelRow, "ACTION_ID").ToString() == "15")
                        {
                            gleDepartment.Visible = lookUp_progYear.Visible = lBolum.Visible = label_olddep_text.Visible = true;
                            label_old_dep.Text = gvActionUsed.GetRowCellValue(SelRow, "OLDDEP").ToString();
                            gleDepartment.EditValue = gvActionUsed.GetRowCellValue(SelRow, "NEWDEP").ToString();
                            lookUp_progYear.EditValue = gvActionUsed.GetRowCellValue(SelRow, "PROG_YEAR");
                        }
                        else 
                        { 
                            label_old_dep.Text = string.Empty;
                            gleDepartment.Visible = lookUp_progYear.Visible = lBolum.Visible = label_olddep_text.Visible = false;
                        } 
                    }
                    else label_olddep_text.Visible = false;
                    if (gvActionUsed.GetRowCellValue(SelRow, "DECISION_ID").ToString() != "") browse_decision.Tag = Convert.ToInt32(gvActionUsed.GetRowCellValue(SelRow, "DECISION_ID").ToString());
                    browse_decision.Text = gvActionUsed.GetRowCellValue(SelRow, "DECISION_NO").ToString();               
                }
            }
            catch (Exception) { }
        }

        private void ControlOperBtn()
        {
            btnOper.Enabled = (((radio_change.Checked) && (gvActionUsed.SelectedRowsCount > 0)) || rbAdd.Checked) ;
        }

        private void qerarGosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvActionUsed.GetSelectedRows()[0].ToString() == "-999997") return;
            try
            {
                if ((gvActionUsed.SelectedRowsCount > 0) && (gvActionUsed.GetRowCellValue(gvActionUsed.GetSelectedRows()[0], "DECISION_ID").ToString() != ""))
                {
                    stud_act_orders.frmOrders frm = new TMS.stud_act_orders.frmOrders();
                    frm.DecID = Convert.ToInt32(gvActionUsed.GetRowCellValue(gvActionUsed.GetSelectedRows()[0], "DECISION_ID").ToString());
                    frm.DecOperMode = OperMode.View;
                    frm.ShowDialog();                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "XƏTA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gvActionUsed_RowCountChanged(object sender, EventArgs e)
        {
            button_excel.Enabled = gvActionUsed.RowCount > 0;
            label_olddep_text.Visible = gvActionUsed.RowCount > 0;
            label_old_dep.Visible = gvActionUsed.RowCount > 0;
            gvActionUsed.Columns["STUD_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
        }

        private void button_excel_Click(object sender, EventArgs e)
        {
            saveFile_excel.DefaultExt = "xls";
            saveFile_excel.Filter = "Excel files (*.xls)|*.xls";
            if (saveFile_excel.ShowDialog() == DialogResult.OK) gvActionUsed.ExportToExcelOld(saveFile_excel.FileName); 
        }

        private void radioGroup_mezuniyyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudActionUsed();
        }

        private void radio_mezuniyyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_mezuniyyet.Checked)
            {
                group_buttons.Enabled = true;
                rbGorunus.PerformClick();
                LoadStudActionUsed();                
            }            
        }

        private void browse_decision_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if ((cmbStudAction.SelectedValue.ToString() != "") && (Convert.ToInt32(cmbStudAction.SelectedValue.ToString()) > 0))
                {
                    stud_act_orders.frmOrders frm = new TMS.stud_act_orders.frmOrders();
                    frm.txtOrderType.Tag = cmbStudAction.SelectedValue.ToString();
                    frm.txtOrderType.Text = cmbStudAction.Text;
                    if (browse_decision.Tag.ToString() != "") frm.DecID = Convert.ToInt32(browse_decision.Tag.ToString());
                    if (frm.ShowDialog() == DialogResult.OK)
                    {                        
                        if (frm.gvDecision.SelectedRowsCount > 0)
                        {
                            browse_decision.Tag = frm.gvDecision.GetRowCellValue(frm.gvDecision.GetSelectedRows()[0], "DECISION_ID").ToString();
                            browse_decision.Text = frm.gvDecision.GetRowCellValue(frm.gvDecision.GetSelectedRows()[0], "DECISION_NO").ToString();
                        }
                    }
                    else
                    {
                        browse_decision.Tag = 0;
                        browse_decision.Text = "";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void frmStudAction_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void frmStudAction_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }

        private void cmbStudAction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string str_SQL = string.Empty;

            if (("#6#11#23#".IndexOf("#" + cmbStudAction.SelectedValue.ToString() + "#") >= 0) && rbTek.Checked)
            {                
                gleDepartment.EditValue = si.DepID;                
                lookUp_progYear.EditValue = Convert.ToInt16(si.edu_year);
            }
            
            gleDepartment.Enabled = (cmbStudAction.SelectedValue.ToString() == "3") || (cmbStudAction.SelectedValue.ToString() == "15");
            lBolum.Visible = gleDepartment.Visible = lookUp_progYear.Visible = (cmbStudAction.SelectedValue.ToString() == "3") || (cmbStudAction.SelectedValue.ToString() == "15") ||
                                                     (("#6#11#23#".IndexOf("#" + cmbStudAction.SelectedValue.ToString() + "#") >= 0) && rbTek.Checked);
                                                    
            check_apply_all.Enabled = ((cmbStudAction.SelectedValue.ToString() != "1") && ("3611".IndexOf(cmbStudAction.SelectedValue.ToString()) >= 0));
            browse_decision.Enabled = ((cmbStudAction.SelectedValue.ToString() != "") && (Convert.ToInt32(cmbStudAction.SelectedValue.ToString()) > 0));
            label4.Text = (cmbStudAction.SelectedValue.ToString() == "2") ? "Start date" : "Order Apply date";
            lAkMezEndDate.Visible = date_mezuniyyet_end.Visible = (cmbStudAction.SelectedValue.ToString() == "2");
            browse_decision.Tag = browse_decision.Text = string.Empty;
        }

        private void frmStudAction_Load(object sender, EventArgs e)
        {
            LoadPrograms();
            if (si.StudID.Length > 0)
            {
                rbTek.Enabled = true;
                rbTek.Checked = true;                
            }
            else radio_mezuniyyet.Checked = true;            
            LoadStudStatus();            
            LoadStudActionUsed();
            gvActionUsed.Focus();
        }

        private void cmbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedValue.ToString() != "") LoadStudAction(cmbStatus.SelectedValue.ToString());
        }

        private void browse_students_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index) 
            {
                case 0 : StudSearch.frmStudSEARCH s = new TMS.StudSearch.frmStudSEARCH(); s.dgvSTUD_MAIN.MultiSelect = true;
                         if ((s.ShowDialog() == DialogResult.OK) && (s.dgvSTUD_MAIN.SelectedRows.Count > 0))
                         {
                            browse_students.EditValue = ""; 
                            browse_students.Tag = s.dgvSTUD_MAIN.SelectedRows.Count;
                            for (int i = 0; i < s.dgvSTUD_MAIN.SelectedRows.Count; i++)
                            {                        
                                browse_students.EditValue = browse_students.EditValue + s.dgvSTUD_MAIN.SelectedRows[i].Cells["STUD_ID"].Value.ToString();
                                if (i != (s.dgvSTUD_MAIN.SelectedRows.Count - 1)) browse_students.EditValue = browse_students.EditValue + ", ";
                            }                    
                         }
                break;
                case 1: browse_students.EditValue = string.Empty; break;
                default: break;
            }            
        }

        private void browse_students_EditValueChanged(object sender, EventArgs e)
        {
            button_add.Enabled = browse_students.EditValue.ToString() != "";
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string stud_ID = string.Empty;
            foreach (string student in browse_students.EditValue.ToString().Split(','))
            {
                stud_ID = student.Trim();
                if (checkedList_students.FindString(stud_ID) < 0) checkedList_students.Items.Add(stud_ID, stud_ID, CheckState.Checked, true);
            }
            button_remove.Enabled = checkedList_students.ItemCount > 0;
            browse_students.EditValue = string.Empty;
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            checkedList_students.Items.Remove(checkedList_students.SelectedItem);            
            button_remove.Enabled = checkedList_students.ItemCount > 0;
        }

        private void gvDepartments_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridGroupRowInfo info = e.Info as GridGroupRowInfo; 
            if (info == null) return;
            if (info.Column.FieldName == "PARENT_ID")
            {
                info.GroupText = gleDepartment.Properties.View.GetRowCellValue(gleDepartment.Properties.View.GetChildRowHandle(info.RowHandle, 0), "PARENT_TITLE").ToString();
            }
        }
        
        private void lookUp_progYear_Validating(object sender, CancelEventArgs e)
        {
            if (("#6#11#".IndexOf("#" + cmbStudAction.SelectedValue.ToString() + "#") >= 0) && (lookUp_progYear.EditValue.ToString() != si.edu_year))
                e.Cancel = (MessageBox.Show("Are you sure changing student's program Year?", "CHANGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);            
        }
    }
}
