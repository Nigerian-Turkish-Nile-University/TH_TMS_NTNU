using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DB;
using Oracle.DataAccess.Client;
using Globals;
using DevExpress.XtraEditors.Controls;

namespace TMS.trans
{
    public partial class frmTrans : Form
    {
        string lan = "az";
        FastReport.Report rTrans;
        oraConn con = oraConn.DB;
        SelStudInfo si = new SelStudInfo();
        BindingSource bind = new BindingSource();
        General.functions f = new General.functions();

        public frmTrans()
        {            
            InitializeComponent();
        }

        private void btnTRANS_Click(object sender, EventArgs e)
        {
            /*
            string str_SQL = string.Empty, header = string.Empty;
            try
            {
                if (si.StudID.Length != 9)
                {
                    MessageBox.Show("Tələbə seçin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rbAZ.Checked) lan = "az";
                else if (rbTR.Checked) lan = "tr";
                else if (rbEN.Checked) lan = "en";


                DataTable dt = new DataTable();
                OracleParameter[] prms = { con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID) };
                str_SQL = "select t.ders_kod, d.title_" + lan + " as title, d.k_teor + d.k_prat as credit, d.k_ects, " +
                          "decode(t.grading_type, 'PNP', 0, case when t.year >= 2013 then d.k_ects else d.k_teor + d.k_prat end) as ects, " +
                          "t.year, t.term, t.year || t.term as ilsem, t.son, t.kecdi, " +
                          "case when t.son = 0 and t.prog_code=19901 then '* #' when t.son = 0 and t.section is NULL and t.prog_code!=19901 then '* §' when t.son = 0 then '*' " +
                          "when t.son = 1 and t.prog_code=19901 then '#' when t.son = 1 and t.section is NULL  and t.prog_code!=19901 then '§' else NULL end as stars, " +
                          "t.grading_type, t.prog_code, t.qiymet_herf, decode(qh.type, 2, t.qiymet_herf, decode(t.grading_type, 'PNP', NULL, qh.title_" + lan + ")) as qiymetHerf_Title, " +
                          "decode(t.grading_type, 'PNP', qh.title_" + lan + ", case when t.qiymet_yuz < 0 or t.qiymet_yuz is NULL then 0 else t.qiymet_yuz end) as ort_title, " +
                          "case when t.qiymet_yuz < 0 or t.qiymet_yuz is NULL then 0 else t.qiymet_yuz end as ort from view_trans t " +
                          "left outer join dbmaster.ders d on d.ders_kod = t.ders_kod and d.year = t.year left outer join dbmaster.qiymet_herf qh on qh.qiymet_herf = t.qiymet_herf " +
                          "where stud_id = :stud_id order by t.year, t.term, t.ders_kod";

                dt = con.GetDataTable(str_SQL, prms);

                // Call this before loading your report 
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_print.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;

                rTrans = new FastReport.Report();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrans));
                rTrans.ReportResourceString = resources.GetString("rTrans.ReportResourceString");
                rTrans.RegisterData(dt, "Table");
                rTrans.GetDataSource("Table").Enabled = true;
                rTrans.Load(Properties.Settings.Default.CurProgDir + "\\reports\\transcript.frx");

                /////////////////////////////////////////////////////////////////////////////////////////////
                string sql = "select l.interface_lang_id as id,l.interface_lang_title_" + lan + " as title from dbmaster.interface_lang l " +
                             "where l.interface_lang_id in (2, 3, 4, 7, 46, 47, 48, 49, 166, 195, 197, 212, 308, 365, 367, 371, 372, 373, 374, 375, 376, 377, 378, 379, 463, 568, 573,574,575, 577, 578, 579, 580, 581) order by id";
                OracleDataReader dr = con.execSQL(sql);

                while (dr.Read())
                {
                    switch (Convert.ToInt32(dr["ID"]))
                    {
                        case 2: rTrans.SetParameterValue("tfac", dr["TITLE"].ToString()); break;
                        case 3: rTrans.SetParameterValue("tdep", dr["TITLE"].ToString()); break;
                        case 4: rTrans.SetParameterValue("tstud_id", dr["TITLE"].ToString()); break;
                        case 579: rTrans.SetParameterValue("tBirthDate", dr["TITLE"].ToString()); break;
                        case 46: rTrans.SetParameterValue("tfathername", dr["TITLE"].ToString()); break;
                        case 577: rTrans.SetParameterValue("tEntryYear", dr["TITLE"].ToString()); break;
                        case 48: rTrans.SetParameterValue("tEduLevel", dr["TITLE"].ToString()); break;
                        case 49: rTrans.SetParameterValue("tEduLang", dr["TITLE"].ToString()); break;
                        case 166: rTrans.SetParameterValue("tfullname", dr["TITLE"].ToString()); break;
                        case 195: rTrans.SetParameterValue("tDersKod", dr["TITLE"].ToString()); break;
                        case 197: rTrans.SetParameterValue("tders_ad", dr["TITLE"].ToString()); break;
                        case 212: rTrans.SetParameterValue("tqiymet", dr["TITLE"].ToString()); break;
                        case 308: rTrans.SetParameterValue("tCredit", dr["TITLE"].ToString()); break;
                        case 365: { if (!(si.eduLevel == "B" || si.eduLevel == "M")) rTrans.SetParameterValue("tmudir", dr["TITLE"].ToString()); } break;
                        case 367: header = dr["TITLE"].ToString(); break;
                        case 578: rTrans.SetParameterValue("tGradDate", dr["TITLE"].ToString()); break;
                        case 372: rTrans.SetParameterValue("header", dr["TITLE"].ToString() + "\n" + header); break;
                        case 373: rTrans.SetParameterValue("tLetterGrade", dr["TITLE"].ToString()); break;
                        case 374: rTrans.SetParameterValue("tGivenDate", dr["TITLE"].ToString()); break;
                        case 375: rTrans.SetParameterValue("tTotalCredit", dr["TITLE"].ToString()); break;
                        case 376: rTrans.SetParameterValue("tSPA", dr["TITLE"].ToString()); break;
                        case 377: rTrans.SetParameterValue("tGPA", dr["TITLE"].ToString()); break;
                        case 378: rTrans.SetParameterValue("tTermEcts", dr["TITLE"].ToString()); break;
                        case 379: rTrans.SetParameterValue("tFooter", dr["TITLE"].ToString()); break;
                        case 463: { if (si.eduLevel == "B" || si.eduLevel == "M") rTrans.SetParameterValue("tmudir", dr["TITLE"].ToString()); } break;
                        case 568: rTrans.SetParameterValue("tects", dr["TITLE"].ToString()); break;
                        case 580: rTrans.SetParameterValue("tnation", dr["TITLE"].ToString()); break;
                        case 581: rTrans.SetParameterValue("tgender", dr["TITLE"].ToString()); break;
                    }
                }

                if (!dr.IsClosed) dr.Close();
                /////////////////////////////////////////////////////////////////////////////////////////////
                string fullName = string.Empty;
                sql = "select case when dp.edu_level in('B', 'M') then GetDepChief('20130', '" + lan + "', 216) else GetDepChief('F_GRAD_DOC', '" + lan + "') end as tmudir, " +
                      "s.stud_id, s.name, s.surname, s.class as kurs, s.status, i.tqdk_imt_istirak as tqdk, dp.haz_var, to_char(i.birth_date, 'dd.mm.YYYY') as bdate, " +
                      "nvl((select f.title_" + lan + " from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.year = i.year), " +
                      "(select f.title_" + lan + " from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.son = 1)) as fac, nvl(s.name_en, s.name) ||' '|| nvl(s.surname_en, s.surname) as fullname, " +
                      "(select p.parent_info_name from dbmaster.parent_info p where p.stud_id = s.stud_id and p.parent_type_id = 1) as ata, " +
                      "dp.title_" + lan + " as dep, i.country_id as olke, to_char(sysdate, 'dd.mm.YYYY') as today, dp.edu_level, dp.edu_lang, " +
                      "(select el.title_" + lan + " from dbmaster.edu_levels el where el.level_code = dp.edu_level) as level_title, to_char(u.action_date, 'dd.mm.YYYY') as grad_date, " +
                      "(select l.lang_name_" + lan + " from dbmaster.language l where l.lang_code = dp.edu_lang) as edulang_title," +
                      "decode(s.type, 'Q', decode('" + lan + "', 'az','Bu sənəd '||to_char(i.birth_date, 'DD.MM.YYYY')||' tarixində anadan olmuş '||s.name||' '||s.surname||' adlı tələbəyə verilir ondan ötrü ki, o həqiqətən, '" +
                      "||to_char(qonaq_gelib.action_date, 'DD.MM.YYYY')||' - '||to_char(qonaq_gedib.action_date, 'DD.MM.YYYY')||' tarixləri arasında Qafqaz Universitetində qonaq tələbə olaraq oxumuşdur.' ," +
                      "'This is to certify that '||s.name||' '||s.surname||', born '||to_char(i.birth_date, 'DD.MM.YYYY')||', has been an exchange student at Qafqaz University durung '||" +
                      "to_char(qonaq_gelib.action_date, 'DD.MM.YYYY')||' to '||to_char(qonaq_gedib.action_date, 'DD.MM.YYYY')||'.'), null) as description " +
                      "from dbmaster.students s  left outer join dbmaster.stud_info i on i.stud_id = s.stud_id " +
                      "left outer join stud_action_used u on u.stud_id = s.stud_id and u.action_id = 8 and u.is_active = 1 " +
                      "left outer join stud_action_used qonaq_gelib on qonaq_gelib.stud_id = s.stud_id and qonaq_gelib.action_id in(18, 27) and qonaq_gelib.is_active = 1 " +
                      "left outer join stud_action_used qonaq_gedib on qonaq_gedib.stud_id = s.stud_id and qonaq_gedib.action_id in(21, 28) and qonaq_gedib.is_active = 1 " +
                      "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id " +
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' " +
                      "where  dp.prog_type = 'M'  and s.stud_id = '" + si.StudID + "'";

                dr = con.execSQL(sql);

                if (dr.Read())
                {
                    fullName = (lan == "en") ? dr["FULLNAME"].ToString() : (lan == "az") ? dr["surname"].ToString() + " " + dr["name"].ToString() : dr["name"].ToString() + " " + dr["surname"].ToString();

                    rTrans.SetParameterValue("stud_id", si.StudID);
                    rTrans.SetParameterValue("fullname", fullName);
                    rTrans.SetParameterValue("fac", dr["fac"].ToString());
                    rTrans.SetParameterValue("dep", dr["dep"].ToString());
                    rTrans.SetParameterValue("today", dr["today"].ToString());
                    rTrans.SetParameterValue("mudir", dr["tmudir"].ToString());
                    rTrans.SetParameterValue("fathername", dr["ata"].ToString());
                    rTrans.SetParameterValue("birthDate", dr["bdate"].ToString());
                    rTrans.SetParameterValue("eduLang", dr["edulang_title"].ToString());
                    rTrans.SetParameterValue("gradDate", dr["grad_date"].ToString());
                    rTrans.SetParameterValue("eduLevel", dr["level_title"].ToString());
                    rTrans.SetParameterValue("entryYear", si.year + " - " + (int.Parse(si.year) + 1));
                    rTrans.SetParameterValue("description", dr["description"].ToString());
                }
                dr.Close(); rTrans.Show();
                if (checkEdit_print.Checked && MessageBox.Show("Would you like system to count this document as PRINTED?", "PRINT APPROVAL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 13 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                          "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 13, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(sql);

                    sql = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 13 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                    dr = con.execSQL(sql);
                    if (dr.Read())
                    {
                        OracleParameter[] prm = { con.SetParameter("sdid", OracleDbType.Int32, 9, ParameterDirection.Input, dr["SD_ID"]) };
                        con.ExecSProcRetVal("DOCS_PRINT_LOG", prm);
                    }
                    dr.Close();
                    spinEdit_transkript.Value++; spinEdit_transkript.Properties.MaxValue++;
                    spinEdit_transkript.Properties.Buttons[1].Enabled = (spinEdit_transkript.Value < spinEdit_transkript.Properties.MaxValue);
                    spinEdit_transkript.Properties.Buttons[2].Enabled = (spinEdit_transkript.Value > spinEdit_transkript.Properties.MinValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           */
            string str_SQL = string.Empty;
            try
            {
                if (si.StudID.Length != 9)
                {
                    MessageBox.Show("No Student was selected..! Please, select a student first.", "MISSING DATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rbAZ.Checked) lan = "az";
                else if (rbTR.Checked) lan = "tr";
                else if (rbEN.Checked) lan = "en";
                

                DataTable dt = new DataTable();
                OracleParameter[] prms = {
                                             con.SetParameter("stud_id", OracleDbType.Char, 9, ParameterDirection.Input, si.StudID),
                                             con.SetParameter("lang", OracleDbType.Varchar2, 5, ParameterDirection.Input,lan)
                                         };
                str_SQL = check_unlocked.Checked ? "select * from table(transcript(:stud_id,:lang))" : "select * from table(stud_trans(:stud_id,:lang))";
                dt = con.GetDataTable(str_SQL, prms);

                // Call this before loading your report 
                FastReport.EnvironmentSettings fsetting = new FastReport.EnvironmentSettings();
                if (checkEdit_print.Checked) fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.All;
                else fsetting.PreviewSettings.Buttons = FastReport.PreviewButtons.Close | FastReport.PreviewButtons.Edit | FastReport.PreviewButtons.Email |
                                                        FastReport.PreviewButtons.Find | FastReport.PreviewButtons.Navigator | FastReport.PreviewButtons.Open |
                                                        FastReport.PreviewButtons.Outline | FastReport.PreviewButtons.PageSetup | FastReport.PreviewButtons.Save |
                                                        FastReport.PreviewButtons.Watermark | FastReport.PreviewButtons.Zoom;
                
                rTrans = new FastReport.Report();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrans));
                rTrans.ReportResourceString = resources.GetString("rTrans.ReportResourceString");
                rTrans.RegisterData(dt, "Table");
                rTrans.GetDataSource("Table").Enabled = true;
                rTrans.Load(Properties.Settings.Default.CurProgDir + "\\reports\\Transcript1.frx");               
                
                /////////////////////////////////////////////////////////////////////////////////////////////
                string sql = "select l.interface_lang_id as id,l.interface_lang_title_" + lan + " as title from dbmaster.interface_lang l " +
                             "where l.interface_lang_id in (2,3,4,46,68,197,200,223,354,365,366,367,382,483,463,568,573,574,575, 577, 578, 579, 580, 581, 582,190,583,584,585,586,587,588)";
                OracleDataReader dr = con.execSQL(sql);
                
                string kurs = "", hazirliq = "";
                while (dr.Read())
                {
                    switch (Convert.ToInt32(dr["ID"]))
                    {
                        case 2: rTrans.SetParameterValue("tfac", dr["TITLE"].ToString()); break;
                        case 3: rTrans.SetParameterValue("tdep", dr["TITLE"].ToString()); break;
                        case 4: rTrans.SetParameterValue("tstud_id", dr["TITLE"].ToString()); break;                        
                        case 46: rTrans.SetParameterValue("tfathername", dr["TITLE"].ToString()); break;
                        case 577: rTrans.SetParameterValue("tentrydate", dr["TITLE"].ToString()); break;
                        case 578: rTrans.SetParameterValue("tgraddate", dr["TITLE"].ToString()); break;
                        case 197: rTrans.SetParameterValue("tders_ad", dr["TITLE"].ToString()); break;
                        case 200: rTrans.SetParameterValue("tsaat", dr["TITLE"].ToString()); break;
                       
                        case 223: rTrans.SetParameterValue("tfullname", dr["TITLE"].ToString()); break;
                        case 354: { if (si.DepID.Substring(0, 2) == "11" && int.Parse(si.year) <= 2010) rTrans.SetParameterValue("desc_100", dr["TITLE"].ToString()); } break;
                        case 365: { if (si.DepID.Substring(0, 2) == "11") rTrans.SetParameterValue("tmudir", dr["TITLE"].ToString()); } break;
                        case 366: { if (si.DepID.Substring(0, 2) != "11" && int.Parse(si.year) > 2010) rTrans.SetParameterValue("desc_100", dr["TITLE"].ToString()); } break;
                        case 367: rTrans.SetParameterValue("header", dr["TITLE"].ToString()); break;
                        case 382: rTrans.SetParameterValue("tders_il", dr["TITLE"].ToString()); break;
                        case 463: rTrans.SetParameterValue("tmudir", dr["TITLE"].ToString());  break;
                        case 483: { if (si.DepID.Substring(0, 2) != "11" && int.Parse(si.year) <= 2010) rTrans.SetParameterValue("desc_100", dr["TITLE"].ToString()); } break; 
                        case 568: rTrans.SetParameterValue("tects", dr["TITLE"].ToString()); break;
                        case 573: rTrans.SetParameterValue("note", dr["TITLE"].ToString()); break;
                        case 574: kurs = dr["TITLE"].ToString(); break;
                        case 575: hazirliq = dr["TITLE"].ToString(); break;
                        case 579: rTrans.SetParameterValue("tbirthdate", dr["TITLE"].ToString()); break;
                        case 580: rTrans.SetParameterValue("tnation", dr["TITLE"].ToString()); break;
                        case 581: rTrans.SetParameterValue("tgender", dr["TITLE"].ToString()); break;
                        case 582: rTrans.SetParameterValue("tders_code", dr["TITLE"].ToString()); break;


                        case 583: rTrans.SetParameterValue("tak_kredi_cam", dr["TITLE"].ToString()); break;
                        case 584: rTrans.SetParameterValue("ttotal_score", dr["TITLE"].ToString()); break;
                        case 190: rTrans.SetParameterValue("tsem_gpa", dr["TITLE"].ToString()); break;
                        case 585: rTrans.SetParameterValue("ttotal_credit_taken", dr["TITLE"].ToString()); break;
                        case 586: rTrans.SetParameterValue("ttotal_score_earned", dr["TITLE"].ToString()); break;
                        case 587: rTrans.SetParameterValue("ttotal_credit_earned", dr["TITLE"].ToString()); break;

                        case 588: rTrans.SetParameterValue("tqiymet", dr["TITLE"].ToString()); break;
                    }                     
                }

                if (!dr.IsClosed) dr.Close();
                /////////////////////////////////////////////////////////////////////////////////////////////
                
                sql = "select decode(dp.edu_level, 'B', tedris_mudir, (select dbmaster.getempfullname(eg.emp_id, '" + lan + "') " +
                      "from dbmaster.emp_gorev eg left outer join dbmaster.employee e on e.emp_id = eg.emp_id "+
                      "where e.state = 1 and eg.status = 1 and eg.dep_code = 'F_GRAD_ST' and eg.gorev_id = 25 and eg.esas_gorev = 1)) as tmudir, " +
                      "s.stud_id, s.name, s.surname, s.class as kurs, s.status, dp.haz_var, "+                      
                      "nvl((select f.title_" + lan + " from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.year = i.year), " +
                      "(select f.title_" + lan + " from dbmaster.departments f where f.dep_code = dp.dep_code_f and f.son = 1)) as fac, " +
                      "(select p.parent_info_name from dbmaster.parent_info p where p.stud_id = s.stud_id and p.parent_type_id = 1) as ata, "+
                      "dp.title_" + lan + " as dep, i.country_id as olke, to_char(sysdate, 'dd.mm.YYYY') as today, dp.edu_level, dp.edu_lang as lang_code, " +
                       "to_char(i.birth_date, 'DD.MM.YYYY') as birth_date , "+
                       "(select c.title_" + lan + " from dbmaster.country c where c.id = i.nationality_id) as nation, " +
                       "(select g.gender_title_" + lan + " from dbmaster.gender g  where g.gender_id = i.gender_id) as gender, " +
                       "to_char(i.entrance_date, 'DD.MM.YYYY') as entrydate, "+
                       "(select to_char(su.action_date, 'DD.MM.YYYY') from STUD_ACTION_USED su "+
                       " where action_id = 8 and su.stud_id = s.stud_id) as graddate " +
                      "from dbmaster.students s  left outer join dbmaster.stud_info i on i.stud_id = s.stud_id "+
                      "left join dbmaster.stud_prog sp on sp.stud_id = s.stud_id "+
                      "left join dbmaster.dep_programs dp on dp.prog_code = sp.prog_code and dp.year = sp.prog_year and dp.prog_type = 'M' "+
                      //"left join dbmaster.ders_al sp on sp.stud_id = s.stud_id " +
                      "where  dp.prog_type = 'M'  and s.stud_id = '" + si.StudID + "'";
                    
                dr = con.execSQL(sql);
                if (dr.Read())
                {
                    
                    kurs = si.Kurs.ToString();
                    
                    rTrans.SetParameterValue("stud_id", si.StudID);
                    rTrans.SetParameterValue("fullname", dr["name"].ToString() + " " + dr["surname"].ToString());
                    rTrans.SetParameterValue("fathername", dr["ata"].ToString());
                    rTrans.SetParameterValue("fac", dr["fac"].ToString());
                    rTrans.SetParameterValue("dep", dr["dep"].ToString());
                    rTrans.SetParameterValue("kurs", kurs);
                    rTrans.SetParameterValue("mudir", dr["tmudir"].ToString());
                    rTrans.SetParameterValue("today", dr["today"].ToString());

                    rTrans.SetParameterValue("birthdate", dr["birth_date"].ToString());
                    rTrans.SetParameterValue("nation", dr["nation"].ToString());
                    rTrans.SetParameterValue("gender", dr["gender"].ToString());
                    rTrans.SetParameterValue("entrydate", dr["entrydate"].ToString());
                    rTrans.SetParameterValue("graddate", dr["graddate"].ToString());
                }

     

                dr.Close(); rTrans.Show();
                if (checkEdit_print.Checked && MessageBox.Show("Would you like system to count this document as PRINTED?", "PRINT APPROVAL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sql = "merge into dbmaster.docs_count dc using dual on (dc.doc_id = 13 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")" +
                          "when matched then update set dc.print_count = dc.print_count + 1 when not matched then insert(dc.stud_id, dc.doc_id, dc.year, dc.term) values ('" + si.StudID + "', 13, " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + ", " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString() + ")";
                    con.execSQL(sql);

                    sql = "select dc.sd_id from dbmaster.docs_count dc where dc.doc_id = 13 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                    dr = con.execSQL(sql);
                    if (dr.Read())
                    {
                        OracleParameter[] prm = { con.SetParameter("sdid", OracleDbType.Int32, 9, ParameterDirection.Input, dr["SD_ID"]) };
                        con.ExecSProcRetVal("DOCS_PRINT_LOG", prm);
                    }
                    dr.Close();
                    spinEdit_transkript.Value++; spinEdit_transkript.Properties.MaxValue++;
                    spinEdit_transkript.Properties.Buttons[1].Enabled = (spinEdit_transkript.Value < spinEdit_transkript.Properties.MaxValue);
                    spinEdit_transkript.Properties.Buttons[2].Enabled = (spinEdit_transkript.Value > spinEdit_transkript.Properties.MinValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTrans_Load(object sender, EventArgs e)
        {
            string str_SQL = string.Empty; rbAZ.Select();
            str_SQL = "select dc.print_count, (select count(*) from dbmaster.docs_print dp where dp.sd_id = dc.sd_id) as log_count from dbmaster.docs_count dc where dc.doc_id = 13 " +
                      "and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                      
            OracleDataReader dr = con.execSQL(str_SQL); bool ok = dr.Read();
            spinEdit_transkript.Value = ok ? Convert.ToInt32(dr["PRINT_COUNT"]) : 0;
            spinEdit_transkript.Properties.MaxValue = ok ? Convert.ToInt32(dr["LOG_COUNT"]) : 0; dr.Close();
            spinEdit_transkript.Properties.Buttons[1].Enabled = (spinEdit_transkript.Value < spinEdit_transkript.Properties.MaxValue);
            spinEdit_transkript.Properties.Buttons[2].Enabled = (spinEdit_transkript.Value > spinEdit_transkript.Properties.MinValue);
        }

        private void frmTrans_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void frmTrans_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }

        private void spinEdit_transkript_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            string str_SQL = string.Empty;
            if (MessageBox.Show("Are you sure CHANGING printed transcript count for student number : " + si.StudID + "?", "CHANGE PRINT COUNT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (e.Button.Index)
                {
                    case 1: spinEdit_transkript.Value++; break;
                    case 2: spinEdit_transkript.Value--; break;
                    default: break;
                }
                spinEdit_transkript.Properties.Buttons[1].Enabled = (spinEdit_transkript.Value < spinEdit_transkript.Properties.MaxValue);
                spinEdit_transkript.Properties.Buttons[2].Enabled = (spinEdit_transkript.Value > spinEdit_transkript.Properties.MinValue);

                str_SQL = "update dbmaster.docs_count dc set dc.print_count = " + spinEdit_transkript.Value + " where dc.doc_id = 13 and dc.stud_id = '" + si.StudID + "' and dc.year = " + f.GetCfgActVal("CARI_IL_SEM")[0].ToString() + " and dc.term = " + f.GetCfgActVal("CARI_IL_SEM")[1].ToString();
                con.execSQL(str_SQL);
            }
        }

        private void checkEdit_print_CheckedChanged(object sender, EventArgs e)
        {
            spinEdit_transkript.Enabled = checkEdit_print.Checked;
        }
    }
}
