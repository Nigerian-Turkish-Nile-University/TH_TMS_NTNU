namespace TMS.ekders
{
    partial class ekDers_mevacib
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_year = new DevExpress.XtraEditors.LookUpEdit();
            this.group_employee = new DevExpress.XtraEditors.GroupControl();
            this.button_excel = new DevExpress.XtraEditors.SimpleButton();
            this.combo_status = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combo_month = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.grid_employee = new DevExpress.XtraGrid.GridControl();
            this.view_employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer_ekDers = new System.Windows.Forms.SplitContainer();
            this.group_mevacib = new DevExpress.XtraEditors.GroupControl();
            this.label_mevacib = new DevExpress.XtraEditors.LabelControl();
            this.label_teacher = new DevExpress.XtraEditors.LabelControl();
            this.button_confirm = new DevExpress.XtraEditors.SimpleButton();
            this.button_reject = new DevExpress.XtraEditors.SimpleButton();
            this.group_courses = new DevExpress.XtraEditors.GroupControl();
            this.grid_courses = new DevExpress.XtraGrid.GridControl();
            this.view_courses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repository_CheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.folderBrowser_Journal = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFile_excel = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_employee)).BeginInit();
            this.group_employee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo_status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_month.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ekDers)).BeginInit();
            this.splitContainer_ekDers.Panel1.SuspendLayout();
            this.splitContainer_ekDers.Panel2.SuspendLayout();
            this.splitContainer_ekDers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_mevacib)).BeginInit();
            this.group_mevacib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_courses)).BeginInit();
            this.group_courses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_courses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_courses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_CheckEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(26, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "YEAR";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(217, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Status";
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YEAR", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YEAR", "title", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lookUp_year.Properties.NullText = "";
            this.lookUp_year.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_year.Properties.ShowFooter = false;
            this.lookUp_year.Properties.ShowHeader = false;
            this.lookUp_year.Size = new System.Drawing.Size(93, 20);
            this.lookUp_year.TabIndex = 32;
            this.lookUp_year.EditValueChanged += new System.EventHandler(this.lookUp_year_EditValueChanged);
            // 
            // group_employee
            // 
            this.group_employee.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.group_employee.AppearanceCaption.Options.UseFont = true;
            this.group_employee.AppearanceCaption.Options.UseTextOptions = true;
            this.group_employee.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.group_employee.Controls.Add(this.button_excel);
            this.group_employee.Controls.Add(this.combo_status);
            this.group_employee.Controls.Add(this.combo_month);
            this.group_employee.Controls.Add(this.labelControl3);
            this.group_employee.Controls.Add(this.labelControl2);
            this.group_employee.Controls.Add(this.labelControl1);
            this.group_employee.Controls.Add(this.lookUp_year);
            this.group_employee.Controls.Add(this.grid_employee);
            this.group_employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_employee.Location = new System.Drawing.Point(0, 0);
            this.group_employee.Name = "group_employee";
            this.group_employee.Size = new System.Drawing.Size(740, 304);
            this.group_employee.TabIndex = 1;
            this.group_employee.Text = "TEACHERS";
            // 
            // button_excel
            // 
            this.button_excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_excel.Enabled = false;
            this.button_excel.Location = new System.Drawing.Point(603, 41);
            this.button_excel.Name = "button_excel";
            this.button_excel.Size = new System.Drawing.Size(125, 23);
            this.button_excel.TabIndex = 42;
            this.button_excel.Text = "EXCEL";
            this.button_excel.Click += new System.EventHandler(this.button_excel_Click);
            // 
            // combo_status
            // 
            this.combo_status.EditValue = "Supervisor approved";
            this.combo_status.Location = new System.Drawing.Point(217, 44);
            this.combo_status.Name = "combo_status";
            this.combo_status.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_status.Properties.Items.AddRange(new object[] {
            "Teacher approved",
            "Supervisor approved",
            "Supervisor rejected",
            "Accounting approved",
            "Accounting rejected"});
            this.combo_status.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.combo_status.Size = new System.Drawing.Size(150, 20);
            this.combo_status.TabIndex = 40;
            this.combo_status.SelectedIndexChanged += new System.EventHandler(this.lookUp_year_EditValueChanged);
            // 
            // combo_month
            // 
            this.combo_month.Location = new System.Drawing.Point(111, 44);
            this.combo_month.Name = "combo_month";
            this.combo_month.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_month.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.combo_month.Size = new System.Drawing.Size(100, 20);
            this.combo_month.TabIndex = 40;
            this.combo_month.SelectedIndexChanged += new System.EventHandler(this.lookUp_year_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(111, 24);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 36;
            this.labelControl3.Text = "MONTH";
            // 
            // grid_employee
            // 
            this.grid_employee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_employee.Location = new System.Drawing.Point(2, 81);
            this.grid_employee.MainView = this.view_employee;
            this.grid_employee.Name = "grid_employee";
            this.grid_employee.Size = new System.Drawing.Size(736, 213);
            this.grid_employee.TabIndex = 23;
            this.grid_employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_employee,
            this.gridView4});
            // 
            // view_employee
            // 
            this.view_employee.GridControl = this.grid_employee;
            this.view_employee.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAID", null, "{0}", ((short)(2)))});
            this.view_employee.IndicatorWidth = 10;
            this.view_employee.Name = "view_employee";
            this.view_employee.OptionsBehavior.Editable = false;
            this.view_employee.OptionsCustomization.AllowColumnMoving = false;
            this.view_employee.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_employee.OptionsSelection.MultiSelect = true;
            this.view_employee.OptionsView.ShowGroupPanel = false;
            this.view_employee.OptionsView.ShowIndicator = false;
            this.view_employee.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.view_employee_CustomDrawCell);
            this.view_employee.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.view_employee_SelectionChanged);
            this.view_employee.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.view_employee_FocusedRowChanged);
            this.view_employee.RowCountChanged += new System.EventHandler(this.view_employee_RowCountChanged);
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grid_employee;
            this.gridView4.Name = "gridView4";
            // 
            // splitContainer_ekDers
            // 
            this.splitContainer_ekDers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_ekDers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_ekDers.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_ekDers.Name = "splitContainer_ekDers";
            this.splitContainer_ekDers.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_ekDers.Panel1
            // 
            this.splitContainer_ekDers.Panel1.Controls.Add(this.group_employee);
            this.splitContainer_ekDers.Panel1MinSize = 200;
            // 
            // splitContainer_ekDers.Panel2
            // 
            this.splitContainer_ekDers.Panel2.Controls.Add(this.group_mevacib);
            this.splitContainer_ekDers.Panel2.Controls.Add(this.label_teacher);
            this.splitContainer_ekDers.Panel2.Controls.Add(this.button_confirm);
            this.splitContainer_ekDers.Panel2.Controls.Add(this.button_reject);
            this.splitContainer_ekDers.Panel2.Controls.Add(this.group_courses);
            this.splitContainer_ekDers.Panel2MinSize = 100;
            this.splitContainer_ekDers.Size = new System.Drawing.Size(742, 723);
            this.splitContainer_ekDers.SplitterDistance = 306;
            this.splitContainer_ekDers.TabIndex = 6;
            // 
            // group_mevacib
            // 
            this.group_mevacib.Controls.Add(this.label_mevacib);
            this.group_mevacib.Location = new System.Drawing.Point(14, 46);
            this.group_mevacib.Name = "group_mevacib";
            this.group_mevacib.Size = new System.Drawing.Size(206, 148);
            this.group_mevacib.TabIndex = 41;
            this.group_mevacib.Text = "HESABLANMIŞ MƏVACİB";
            // 
            // label_mevacib
            // 
            this.label_mevacib.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_mevacib.Location = new System.Drawing.Point(90, 65);
            this.label_mevacib.Name = "label_mevacib";
            this.label_mevacib.Size = new System.Drawing.Size(43, 25);
            this.label_mevacib.TabIndex = 0;
            this.label_mevacib.Text = "AZN";
            // 
            // label_teacher
            // 
            this.label_teacher.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_teacher.Appearance.ForeColor = System.Drawing.Color.Red;
            this.label_teacher.Location = new System.Drawing.Point(14, 21);
            this.label_teacher.Name = "label_teacher";
            this.label_teacher.Size = new System.Drawing.Size(66, 19);
            this.label_teacher.TabIndex = 40;
            this.label_teacher.Text = "Teacher";
            // 
            // button_confirm
            // 
            this.button_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_confirm.Enabled = false;
            this.button_confirm.Location = new System.Drawing.Point(14, 377);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(100, 23);
            this.button_confirm.TabIndex = 39;
            this.button_confirm.Text = "APPROVE";
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_reject
            // 
            this.button_reject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_reject.Enabled = false;
            this.button_reject.Location = new System.Drawing.Point(120, 377);
            this.button_reject.Name = "button_reject";
            this.button_reject.Size = new System.Drawing.Size(100, 23);
            this.button_reject.TabIndex = 39;
            this.button_reject.Text = "REJECT";
            this.button_reject.Click += new System.EventHandler(this.button_reject_Click);
            // 
            // group_courses
            // 
            this.group_courses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_courses.AppearanceCaption.Options.UseTextOptions = true;
            this.group_courses.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.group_courses.Controls.Add(this.grid_courses);
            this.group_courses.Location = new System.Drawing.Point(236, 0);
            this.group_courses.Name = "group_courses";
            this.group_courses.Size = new System.Drawing.Size(505, 412);
            this.group_courses.TabIndex = 0;
            this.group_courses.Text = "COURSE LIST";
            // 
            // grid_courses
            // 
            this.grid_courses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_courses.Location = new System.Drawing.Point(2, 21);
            this.grid_courses.MainView = this.view_courses;
            this.grid_courses.Name = "grid_courses";
            this.grid_courses.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repository_CheckEdit});
            this.grid_courses.Size = new System.Drawing.Size(501, 389);
            this.grid_courses.TabIndex = 23;
            this.grid_courses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_courses});
            // 
            // view_courses
            // 
            this.view_courses.GridControl = this.grid_courses;
            this.view_courses.Name = "view_courses";
            this.view_courses.OptionsBehavior.Editable = false;
            this.view_courses.OptionsCustomization.AllowColumnMoving = false;
            this.view_courses.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_courses.OptionsSelection.MultiSelect = true;
            this.view_courses.OptionsView.ShowGroupPanel = false;
            this.view_courses.OptionsView.ShowIndicator = false;
            // 
            // repository_CheckEdit
            // 
            this.repository_CheckEdit.AutoHeight = false;
            this.repository_CheckEdit.Name = "repository_CheckEdit";
            this.repository_CheckEdit.ValueChecked = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repository_CheckEdit.ValueUnchecked = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ekDers_mevacib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 723);
            this.Controls.Add(this.splitContainer_ekDers);
            this.MinimumSize = new System.Drawing.Size(525, 27);
            this.Name = "ekDers_mevacib";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extra Course Payments";
            this.Load += new System.EventHandler(this.ekDers_mevacib_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_employee)).EndInit();
            this.group_employee.ResumeLayout(false);
            this.group_employee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo_status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_month.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.splitContainer_ekDers.Panel1.ResumeLayout(false);
            this.splitContainer_ekDers.Panel2.ResumeLayout(false);
            this.splitContainer_ekDers.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ekDers)).EndInit();
            this.splitContainer_ekDers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group_mevacib)).EndInit();
            this.group_mevacib.ResumeLayout(false);
            this.group_mevacib.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_courses)).EndInit();
            this.group_courses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_courses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_courses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_CheckEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUp_year;
        private DevExpress.XtraEditors.GroupControl group_employee;
        private DevExpress.XtraGrid.GridControl grid_employee;
        private DevExpress.XtraGrid.Views.Grid.GridView view_employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private System.Windows.Forms.SplitContainer splitContainer_ekDers;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser_Journal;
        private DevExpress.XtraEditors.ComboBoxEdit combo_month;
        private DevExpress.XtraEditors.ComboBoxEdit combo_status;
        private DevExpress.XtraEditors.SimpleButton button_excel;
        private System.Windows.Forms.SaveFileDialog saveFile_excel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton button_confirm;
        private DevExpress.XtraEditors.SimpleButton button_reject;
        private DevExpress.XtraEditors.GroupControl group_courses;
        private DevExpress.XtraGrid.GridControl grid_courses;
        private DevExpress.XtraGrid.Views.Grid.GridView view_courses;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repository_CheckEdit;
        private DevExpress.XtraEditors.LabelControl label_teacher;
        private DevExpress.XtraEditors.GroupControl group_mevacib;
        private DevExpress.XtraEditors.LabelControl label_mevacib;
    }
}