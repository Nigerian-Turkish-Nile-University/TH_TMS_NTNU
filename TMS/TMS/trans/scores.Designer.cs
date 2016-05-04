namespace TMS.trans
{
    partial class scores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.group_scores = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_year = new DevExpress.XtraEditors.LookUpEdit();
            this.grid_scores = new DevExpress.XtraGrid.GridControl();
            this.view_scores = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ders_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_sobe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teacher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.davam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vize_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vize_2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vize_3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.final = new DevExpress.XtraGrid.Columns.GridColumn();
            this.butunleme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ortalama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.group_scores)).BeginInit();
            this.group_scores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_scores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_scores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // group_scores
            // 
            this.group_scores.Controls.Add(this.labelControl2);
            this.group_scores.Controls.Add(this.lookUp_year);
            this.group_scores.Controls.Add(this.grid_scores);
            this.group_scores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_scores.Location = new System.Drawing.Point(0, 0);
            this.group_scores.Name = "group_scores";
            this.group_scores.Size = new System.Drawing.Size(792, 423);
            this.group_scores.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(141, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Education Year and Semester";
            // 
            // lookUp_year
            // 
            this.lookUp_year.EditValue = "";
            this.lookUp_year.Location = new System.Drawing.Point(12, 44);
            this.lookUp_year.Name = "lookUp_year";
            this.lookUp_year.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_year.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_year.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_year.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_year.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YIL", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IL", "title", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lookUp_year.Properties.NullText = "";
            this.lookUp_year.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_year.Properties.ShowFooter = false;
            this.lookUp_year.Properties.ShowHeader = false;
            this.lookUp_year.Size = new System.Drawing.Size(200, 20);
            this.lookUp_year.TabIndex = 0;
            this.lookUp_year.EditValueChanged += new System.EventHandler(this.lookUp_year_EditValueChanged);
            // 
            // grid_scores
            // 
            this.grid_scores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_scores.Location = new System.Drawing.Point(0, 81);
            this.grid_scores.MainView = this.view_scores;
            this.grid_scores.Name = "grid_scores";
            this.grid_scores.Size = new System.Drawing.Size(792, 342);
            this.grid_scores.TabIndex = 1;
            this.grid_scores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_scores,
            this.gridView4});
            // 
            // view_scores
            // 
            this.view_scores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ders_id,
            this.gridColumn_sobe,
            this.title,
            this.teacher,
            this.kredit,
            this.davam,
            this.vize_1,
            this.vize_2,
            this.vize_3,
            this.final,
            this.butunleme,
            this.ek,
            this.ortalama});
            this.view_scores.GridControl = this.grid_scores;
            this.view_scores.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAID", null, "{0}", ((short)(2)))});
            this.view_scores.Name = "view_scores";
            this.view_scores.OptionsBehavior.Editable = false;
            this.view_scores.OptionsCustomization.AllowColumnMoving = false;
            this.view_scores.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_scores.OptionsView.ShowGroupPanel = false;
            this.view_scores.OptionsView.ShowIndicator = false;
            // 
            // ders_id
            // 
            this.ders_id.AppearanceCell.Options.UseTextOptions = true;
            this.ders_id.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ders_id.AppearanceHeader.Options.UseTextOptions = true;
            this.ders_id.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ders_id.Caption = "Code";
            this.ders_id.FieldName = "DERS_KOD";
            this.ders_id.Name = "ders_id";
            this.ders_id.Visible = true;
            this.ders_id.VisibleIndex = 0;
            this.ders_id.Width = 66;
            // 
            // gridColumn_sobe
            // 
            this.gridColumn_sobe.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_sobe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_sobe.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_sobe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_sobe.Caption = "SECTION";
            this.gridColumn_sobe.FieldName = "SECTION";
            this.gridColumn_sobe.Name = "gridColumn_sobe";
            this.gridColumn_sobe.Visible = true;
            this.gridColumn_sobe.VisibleIndex = 1;
            this.gridColumn_sobe.Width = 50;
            // 
            // title
            // 
            this.title.Caption = "Title";
            this.title.FieldName = "TITLE";
            this.title.Name = "title";
            this.title.Visible = true;
            this.title.VisibleIndex = 2;
            this.title.Width = 188;
            // 
            // teacher
            // 
            this.teacher.Caption = "Teacher";
            this.teacher.FieldName = "TEACHER";
            this.teacher.Name = "teacher";
            this.teacher.Visible = true;
            this.teacher.VisibleIndex = 3;
            this.teacher.Width = 106;
            // 
            // kredit
            // 
            this.kredit.AppearanceCell.Options.UseTextOptions = true;
            this.kredit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.kredit.AppearanceHeader.Options.UseTextOptions = true;
            this.kredit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.kredit.Caption = "ECTS";
            this.kredit.FieldName = "ECTS";
            this.kredit.Name = "kredit";
            this.kredit.ToolTip = "Kredit";
            this.kredit.Visible = true;
            this.kredit.VisibleIndex = 4;
            this.kredit.Width = 34;
            // 
            // davam
            // 
            this.davam.AppearanceCell.Options.UseTextOptions = true;
            this.davam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.davam.AppearanceHeader.Options.UseTextOptions = true;
            this.davam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.davam.Caption = "Attendance";
            this.davam.FieldName = "DEV";
            this.davam.Name = "davam";
            this.davam.ToolTip = "Davamiyyət";
            this.davam.Visible = true;
            this.davam.VisibleIndex = 5;
            this.davam.Width = 34;
            // 
            // vize_1
            // 
            this.vize_1.AppearanceCell.Options.UseTextOptions = true;
            this.vize_1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vize_1.AppearanceHeader.Options.UseTextOptions = true;
            this.vize_1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vize_1.Caption = "Midterm";
            this.vize_1.FieldName = "VIZ_1";
            this.vize_1.Name = "vize_1";
            this.vize_1.ToolTip = "Semestr Daxili İmtahan";
            this.vize_1.Visible = true;
            this.vize_1.VisibleIndex = 6;
            this.vize_1.Width = 34;
            // 
            // vize_2
            // 
            this.vize_2.AppearanceCell.Options.UseTextOptions = true;
            this.vize_2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vize_2.AppearanceHeader.Options.UseTextOptions = true;
            this.vize_2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vize_2.Caption = "CMA";
            this.vize_2.FieldName = "VIZ_2";
            this.vize_2.Name = "vize_2";
            this.vize_2.ToolTip = "Compulsory midterm activity";
            this.vize_2.Visible = true;
            this.vize_2.VisibleIndex = 7;
            this.vize_2.Width = 34;
            // 
            // vize_3
            // 
            this.vize_3.AppearanceCell.Options.UseTextOptions = true;
            this.vize_3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vize_3.AppearanceHeader.Options.UseTextOptions = true;
            this.vize_3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vize_3.Caption = "VMA";
            this.vize_3.FieldName = "VIZ_3";
            this.vize_3.Name = "vize_3";
            this.vize_3.ToolTip = "Voluntary midterm acitvity";
            this.vize_3.Visible = true;
            this.vize_3.VisibleIndex = 8;
            this.vize_3.Width = 34;
            // 
            // final
            // 
            this.final.AppearanceCell.Options.UseTextOptions = true;
            this.final.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.final.AppearanceHeader.Options.UseTextOptions = true;
            this.final.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.final.Caption = "Final";
            this.final.FieldName = "FIN";
            this.final.Name = "final";
            this.final.ToolTip = "Semestr Sonu İmtahanı";
            this.final.Visible = true;
            this.final.VisibleIndex = 9;
            this.final.Width = 34;
            // 
            // butunleme
            // 
            this.butunleme.AppearanceCell.Options.UseTextOptions = true;
            this.butunleme.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.butunleme.AppearanceHeader.Options.UseTextOptions = true;
            this.butunleme.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.butunleme.Caption = "FE";
            this.butunleme.FieldName = "BUT";
            this.butunleme.Name = "butunleme";
            this.butunleme.ToolTip = "Final extra(Bütünleme)";
            this.butunleme.Visible = true;
            this.butunleme.VisibleIndex = 10;
            this.butunleme.Width = 34;
            // 
            // ek
            // 
            this.ek.AppearanceCell.Options.UseTextOptions = true;
            this.ek.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ek.AppearanceHeader.Options.UseTextOptions = true;
            this.ek.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ek.Caption = "EE";
            this.ek.FieldName = "EK";
            this.ek.Name = "ek";
            this.ek.ToolTip = "Extra exam(EK)";
            this.ek.Visible = true;
            this.ek.VisibleIndex = 11;
            this.ek.Width = 34;
            // 
            // ortalama
            // 
            this.ortalama.AppearanceCell.Options.UseTextOptions = true;
            this.ortalama.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ortalama.AppearanceHeader.Options.UseTextOptions = true;
            this.ortalama.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ortalama.Caption = "AVG";
            this.ortalama.FieldName = "ORT";
            this.ortalama.Name = "ortalama";
            this.ortalama.ToolTip = "Average";
            this.ortalama.Visible = true;
            this.ortalama.VisibleIndex = 12;
            this.ortalama.Width = 110;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grid_scores;
            this.gridView4.Name = "gridView4";
            // 
            // scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 423);
            this.Controls.Add(this.group_scores);
            this.Name = "scores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student`s Scores";
            this.Activated += new System.EventHandler(this.scores_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.scores_FormClosed);
            this.Load += new System.EventHandler(this.scores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_scores)).EndInit();
            this.group_scores.ResumeLayout(false);
            this.group_scores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_scores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_scores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl group_scores;
        private DevExpress.XtraGrid.GridControl grid_scores;
        private DevExpress.XtraGrid.Views.Grid.GridView view_scores;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUp_year;
        private DevExpress.XtraGrid.Columns.GridColumn ders_id;
        private DevExpress.XtraGrid.Columns.GridColumn title;
        private DevExpress.XtraGrid.Columns.GridColumn kredit;
        private DevExpress.XtraGrid.Columns.GridColumn davam;
        private DevExpress.XtraGrid.Columns.GridColumn vize_1;
        private DevExpress.XtraGrid.Columns.GridColumn vize_2;
        private DevExpress.XtraGrid.Columns.GridColumn vize_3;
        private DevExpress.XtraGrid.Columns.GridColumn final;
        private DevExpress.XtraGrid.Columns.GridColumn butunleme;
        private DevExpress.XtraGrid.Columns.GridColumn ek;
        private DevExpress.XtraGrid.Columns.GridColumn ortalama;
        private DevExpress.XtraGrid.Columns.GridColumn teacher;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_sobe;
    }
}