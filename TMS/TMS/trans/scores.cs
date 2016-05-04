using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Globals;
using DB;
using Oracle.DataAccess.Client;

namespace TMS.trans
{
    public partial class scores : DevExpress.XtraEditors.XtraForm
    {
        General.functions f = new General.functions();
        SelStudInfo si = new SelStudInfo();
        oraConn con = oraConn.DB;
        public string max_year;
        public scores()
        {
            InitializeComponent();
        }

        private void scores_Load(object sender, EventArgs e)
        {            
            string str_SQL = "";            
            lookUp_year.EditValue = max_year;
            group_scores.Text = si.StudID + " - " + si.SName + " " + si.SSName;
            str_SQL = "select distinct dr.year || dr.term as yil, '(' || dr.year || ' - ' || to_char(dr.year + 1) || ')   ' || dr.term || '. semestr' as il from dbmaster.view_ders_al_ref dr " +
                      "where dr.son = 1 and dr.stud_id = '" + si.StudID + "' order by dr.year||dr.term desc";                
            con.load_lookUp(lookUp_year, str_SQL, "IL", "YIL");
            lookUp_year.Focus();             
        }

        private void lookUp_year_EditValueChanged(object sender, EventArgs e)
        {
            string str_SQL = "";
            str_SQL = "select a.ders_kod , ds.section, d.title_en as title, dbmaster.getempfullname(ds.emp_id) as teacher, d.k_ects as ects, a.qaib_say as dev," +
                      "(select sum(sq.qiymet)/count(*) from dbmaster.stud_qiymet sq, dbmaster.sobe_assessments sa, dbmaster.sobe_assess_types sat "+
                      "where sq.sa_id = sa.sa_id and sat.sat_id = sa.sat_id and sat.ders_kod =a.ders_kod and sat.year = a.year and sat.term = a.term "+
                      "and sat.section = a.section and sat.at_code= 'MT'and  sq.stud_id = a.stud_id) as viz_1, "+
                      "(select sum(sq.qiymet)/count(*) from dbmaster.stud_qiymet sq, dbmaster.sobe_assessments sa, dbmaster.sobe_assess_types sat "+
                      "where sq.sa_id = sa.sa_id and sat.sat_id = sa.sat_id and sat.ders_kod =a.ders_kod and sat.year = a.year and sat.term = a.term "+
                      "and sat.section = a.section and sat.at_code= 'MSDF'and  sq.stud_id = a.stud_id) as viz_2, "+
                      "(select sum(sq.qiymet)/count(*) from dbmaster.stud_qiymet sq, dbmaster.sobe_assessments sa, dbmaster.sobe_assess_types sat "+
                      "where sq.sa_id = sa.sa_id and sat.sat_id = sa.sat_id and sat.ders_kod =a.ders_kod and sat.year = a.year and sat.term = a.term "+
                      "and sat.section = a.section and sat.at_code= 'IBSDF'and  sq.stud_id = a.stud_id) as viz_3, "+
                      "(select sq.qiymet from dbmaster.stud_qiymet sq, dbmaster.sobe_assessments sa, dbmaster.sobe_assess_types sat "+
                      "where sq.sa_id = sa.sa_id and sat.sat_id = sa.sat_id and sat.ders_kod =a.ders_kod and sat.year = a.year and sat.term = a.term "+
                      "and sat.section = a.section and sat.at_code= 'FIN'and  sq.stud_id = a.stud_id) as fin, "+
                      "(select sq.qiymet from dbmaster.stud_qiymet sq, dbmaster.sobe_assessments sa, dbmaster.sobe_assess_types sat "+
                      "where sq.sa_id = sa.sa_id and sat.sat_id = sa.sat_id and sat.ders_kod =a.ders_kod and sat.year = a.year and sat.term = a.term "+
                      "and sat.section = a.section and sat.at_code= 'BUT'and  sq.stud_id = a.stud_id) as but, "+
                      "(select sq.qiymet from dbmaster.stud_qiymet sq, dbmaster.sobe_assessments sa, dbmaster.sobe_assess_types sat "+
                      "where sq.sa_id = sa.sa_id and sat.sat_id = sa.sat_id and sat.ders_kod =a.ders_kod and sat.year = a.year and sat.term = a.term "+
                      "and sat.section = a.section and sat.at_code= 'EK' and sq.stud_id = a.stud_id) as ek,"+
                      "a.qiymet_yuz as ort "+                
                      "from dbmaster.view_ders_al a left outer join dbmaster.ders d on d.ders_kod = a.ders_kod and d.year = a.year " +
                      "left outer join dbmaster.ders_sobe ds on ds.ders_kod = a.ders_kod and ds.year = a.year and ds.term = a.term and ds.section = a.section " + 
                      "where a.stud_id = '" + si.StudID + "' and a.year||a.term =" + lookUp_year.EditValue.ToString();
            grid_scores.DataSource = con.GetDataTable(str_SQL);
            view_scores.BestFitColumns();
        }

        private void scores_Activated(object sender, EventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = this.Text;
        }

        private void scores_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMS.frmMain mf = (TMS.frmMain)this.MdiParent;
            mf.label_activeForm.Text = (si.StudID.Length > 0) ? si.StudID + " - " + si.SName + " " + si.SSName : "STUDENT INFORMATION SYSTEM";
        }
    }
}