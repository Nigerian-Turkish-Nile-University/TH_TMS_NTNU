namespace TMS.cixarislar
{
    partial class journal
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.group_courses = new DevExpress.XtraEditors.GroupControl();
            this.button_journal_all = new DevExpress.XtraEditors.SimpleButton();
            this.button_courses = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_semester = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUp_year = new DevExpress.XtraEditors.LookUpEdit();
            this.browse_employee = new DevExpress.XtraEditors.ButtonEdit();
            this.grid_courses = new DevExpress.XtraGrid.GridControl();
            this.view_courses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.group_students = new DevExpress.XtraEditors.GroupControl();
            this.button_journal = new DevExpress.XtraEditors.SimpleButton();
            this.check_attendance = new DevExpress.XtraEditors.CheckEdit();
            this.grid_students = new DevExpress.XtraGrid.GridControl();
            this.view_students = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repository_CheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.folderBrowser_Journal = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_courses)).BeginInit();
            this.group_courses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_semester.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_employee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_courses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_courses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_students)).BeginInit();
            this.group_students.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_attendance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_CheckEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.group_courses);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.group_students);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(692, 672);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 5;
            // 
            // group_courses
            // 
            this.group_courses.Controls.Add(this.button_journal_all);
            this.group_courses.Controls.Add(this.button_courses);
            this.group_courses.Controls.Add(this.labelControl3);
            this.group_courses.Controls.Add(this.labelControl2);
            this.group_courses.Controls.Add(this.labelControl1);
            this.group_courses.Controls.Add(this.lookUp_semester);
            this.group_courses.Controls.Add(this.lookUp_year);
            this.group_courses.Controls.Add(this.browse_employee);
            this.group_courses.Controls.Add(this.grid_courses);
            this.group_courses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_courses.Location = new System.Drawing.Point(0, 0);
            this.group_courses.Name = "group_courses";
            this.group_courses.Size = new System.Drawing.Size(692, 285);
            this.group_courses.TabIndex = 1;
            this.group_courses.Text = "YEAR, SEMESTER AND CLASS FILTER";
            // 
            // button_journal_all
            // 
            this.button_journal_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_journal_all.Enabled = false;
            this.button_journal_all.Location = new System.Drawing.Point(555, 44);
            this.button_journal_all.Name = "button_journal_all";
            this.button_journal_all.Size = new System.Drawing.Size(125, 20);
            this.button_journal_all.TabIndex = 40;
            this.button_journal_all.Text = "Prepare all journals";
            this.button_journal_all.Click += new System.EventHandler(this.button_journal_all_Click);
            // 
            // button_courses
            // 
            this.button_courses.Location = new System.Drawing.Point(473, 44);
            this.button_courses.Name = "button_courses";
            this.button_courses.Size = new System.Drawing.Size(70, 20);
            this.button_courses.TabIndex = 39;
            this.button_courses.Text = "Show";
            this.button_courses.Click += new System.EventHandler(this.button_courses_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(111, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Semester";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "EduYear";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(217, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Teacher";
            // 
            // lookUp_semester
            // 
            this.lookUp_semester.EditValue = "";
            this.lookUp_semester.Location = new System.Drawing.Point(111, 44);
            this.lookUp_semester.Name = "lookUp_semester";
            this.lookUp_semester.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_semester.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_semester.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_semester.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_semester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_semester.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("V", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("D", "title")});
            this.lookUp_semester.Properties.NullText = "";
            this.lookUp_semester.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_semester.Properties.ShowFooter = false;
            this.lookUp_semester.Properties.ShowHeader = false;
            this.lookUp_semester.Size = new System.Drawing.Size(100, 20);
            this.lookUp_semester.TabIndex = 33;
            // 
            // lookUp_year
            // 
            this.lookUp_year.EditValue = "";
            this.lookUp_year.Location = new System.Drawing.Point(5, 44);
            this.lookUp_year.Name = "lookUp_year";
            this.lookUp_year.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_year.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_year.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_year.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_year.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YEAR_CONF_YIL", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IL", "title", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lookUp_year.Properties.NullText = "";
            this.lookUp_year.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_year.Properties.ShowFooter = false;
            this.lookUp_year.Properties.ShowHeader = false;
            this.lookUp_year.Size = new System.Drawing.Size(100, 20);
            this.lookUp_year.TabIndex = 32;
            // 
            // browse_employee
            // 
            this.browse_employee.EditValue = "";
            this.browse_employee.Location = new System.Drawing.Point(217, 44);
            this.browse_employee.Name = "browse_employee";
            this.browse_employee.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.browse_employee.Properties.Appearance.Options.UseBackColor = true;
            this.browse_employee.Properties.Appearance.Options.UseTextOptions = true;
            this.browse_employee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.browse_employee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)});
            this.browse_employee.Properties.ReadOnly = true;
            this.browse_employee.Size = new System.Drawing.Size(250, 20);
            this.browse_employee.TabIndex = 24;
            this.browse_employee.Tag = "";
            this.browse_employee.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.browse_employee_ButtonClick);
            // 
            // grid_courses
            // 
            this.grid_courses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_courses.Location = new System.Drawing.Point(2, 81);
            this.grid_courses.MainView = this.view_courses;
            this.grid_courses.Name = "grid_courses";
            this.grid_courses.Size = new System.Drawing.Size(688, 205);
            this.grid_courses.TabIndex = 23;
            this.grid_courses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_courses,
            this.gridView4});
            // 
            // view_courses
            // 
            this.view_courses.GridControl = this.grid_courses;
            this.view_courses.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAID", null, "{0}", ((short)(2)))});
            this.view_courses.Name = "view_courses";
            this.view_courses.OptionsBehavior.Editable = false;
            this.view_courses.OptionsCustomization.AllowColumnMoving = false;
            this.view_courses.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_courses.OptionsView.ShowGroupPanel = false;
            this.view_courses.OptionsView.ShowIndicator = false;
            this.view_courses.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.view_courses_FocusedRowChanged);
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grid_courses;
            this.gridView4.Name = "gridView4";
            // 
            // group_students
            // 
            this.group_students.AppearanceCaption.Options.UseTextOptions = true;
            this.group_students.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.group_students.Controls.Add(this.button_journal);
            this.group_students.Controls.Add(this.check_attendance);
            this.group_students.Controls.Add(this.grid_students);
            this.group_students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_students.Location = new System.Drawing.Point(0, 0);
            this.group_students.Name = "group_students";
            this.group_students.Size = new System.Drawing.Size(692, 383);
            this.group_students.TabIndex = 0;
            this.group_students.Text = "Student List";
            // 
            // button_journal
            // 
            this.button_journal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_journal.Location = new System.Drawing.Point(489, 21);
            this.button_journal.Name = "button_journal";
            this.button_journal.Size = new System.Drawing.Size(198, 23);
            this.button_journal.TabIndex = 39;
            this.button_journal.Text = "Prepare journal for selected SECTION";
            this.button_journal.Click += new System.EventHandler(this.button_journal_Click);
            // 
            // check_attendance
            // 
            this.check_attendance.Location = new System.Drawing.Point(12, 25);
            this.check_attendance.Name = "check_attendance";
            this.check_attendance.Properties.Caption = "Show Students who not have to attend the course";
            this.check_attendance.Properties.ReadOnly = true;
            this.check_attendance.Size = new System.Drawing.Size(272, 19);
            this.check_attendance.TabIndex = 24;
            this.check_attendance.CheckedChanged += new System.EventHandler(this.check_attendance_CheckedChanged);
            // 
            // grid_students
            // 
            this.grid_students.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_students.Location = new System.Drawing.Point(2, 56);
            this.grid_students.MainView = this.view_students;
            this.grid_students.Name = "grid_students";
            this.grid_students.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repository_CheckEdit});
            this.grid_students.Size = new System.Drawing.Size(688, 325);
            this.grid_students.TabIndex = 23;
            this.grid_students.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_students});
            // 
            // view_students
            // 
            this.view_students.GridControl = this.grid_students;
            this.view_students.Name = "view_students";
            this.view_students.OptionsBehavior.Editable = false;
            this.view_students.OptionsCustomization.AllowColumnMoving = false;
            this.view_students.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_students.OptionsSelection.MultiSelect = true;
            this.view_students.OptionsView.ShowAutoFilterRow = true;
            this.view_students.OptionsView.ShowFooter = true;
            this.view_students.OptionsView.ShowGroupPanel = false;
            this.view_students.OptionsView.ShowIndicator = false;
            this.view_students.RowCountChanged += new System.EventHandler(this.view_students_RowCountChanged);
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
            // journal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 672);
            this.Controls.Add(this.splitContainer1);
            this.Name = "journal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journals - Student List";
            this.Activated += new System.EventHandler(this.journal_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.journal_FormClosed);
            this.Load += new System.EventHandler(this.journal_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group_courses)).EndInit();
            this.group_courses.ResumeLayout(false);
            this.group_courses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_semester.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_employee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_courses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_courses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_students)).EndInit();
            this.group_students.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.check_attendance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_CheckEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.GroupControl group_courses;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUp_semester;
        private DevExpress.XtraEditors.LookUpEdit lookUp_year;
        private DevExpress.XtraEditors.ButtonEdit browse_employee;
        private DevExpress.XtraGrid.GridControl grid_courses;
        private DevExpress.XtraGrid.Views.Grid.GridView view_courses;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.GroupControl group_students;
        private DevExpress.XtraGrid.GridControl grid_students;
        private DevExpress.XtraGrid.Views.Grid.GridView view_students;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repository_CheckEdit;
        private DevExpress.XtraEditors.SimpleButton button_courses;
        private DevExpress.XtraEditors.CheckEdit check_attendance;
        private DevExpress.XtraEditors.SimpleButton button_journal;
        private DevExpress.XtraEditors.SimpleButton button_journal_all;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser_Journal;

    }
}