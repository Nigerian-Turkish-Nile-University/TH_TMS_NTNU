namespace TMS.TH
{
    partial class THStatistics
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
            this.Pages = new DevExpress.XtraTab.XtraTabControl();
            this.paid = new DevExpress.XtraTab.XtraTabPage();
            this.label_sem = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_semester = new DevExpress.XtraEditors.LookUpEdit();
            this.button_show_paid = new DevExpress.XtraEditors.SimpleButton();
            this.date_end = new DevExpress.XtraEditors.DateEdit();
            this.date_begin = new DevExpress.XtraEditors.DateEdit();
            this.label_end = new DevExpress.XtraEditors.LabelControl();
            this.label_begin = new DevExpress.XtraEditors.LabelControl();
            this.label_year = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_year = new DevExpress.XtraEditors.LookUpEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.button_not_calculated = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.check_permitted = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spin_amount = new DevExpress.XtraEditors.SpinEdit();
            this.spin_percent = new DevExpress.XtraEditors.SpinEdit();
            this.button_debt = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.button_discounts = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.checkedCombo_discounts = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.checkedCombo_decision = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.button_payment_percent = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_status = new DevExpress.XtraEditors.LookUpEdit();
            this.group_filter = new DevExpress.XtraEditors.GroupControl();
            this.button_excel = new DevExpress.XtraEditors.SimpleButton();
            this.checkedCombo_departments = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.checkedCombo_class = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.grid_thstatistics = new DevExpress.XtraGrid.GridControl();
            this.view_thstatistics = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.saveFile_excel = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Pages)).BeginInit();
            this.Pages.SuspendLayout();
            this.paid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_semester.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_end.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_end.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_begin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_begin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_permitted.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_amount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_percent.Properties)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_discounts.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_decision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_status.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_filter)).BeginInit();
            this.group_filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_departments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_class.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_thstatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_thstatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // Pages
            // 
            this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Pages.Location = new System.Drawing.Point(12, 12);
            this.Pages.Name = "Pages";
            this.Pages.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Pages.SelectedTabPage = this.paid;
            this.Pages.Size = new System.Drawing.Size(768, 113);
            this.Pages.TabIndex = 19;
            this.Pages.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.paid,
            this.xtraTabPage2,
            this.xtraTabPage1,
            this.xtraTabPage4,
            this.xtraTabPage3});
            this.Pages.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.Pages_SelectedPageChanged);
            // 
            // paid
            // 
            this.paid.Controls.Add(this.label_sem);
            this.paid.Controls.Add(this.lookUp_semester);
            this.paid.Controls.Add(this.button_show_paid);
            this.paid.Controls.Add(this.date_end);
            this.paid.Controls.Add(this.date_begin);
            this.paid.Controls.Add(this.label_end);
            this.paid.Controls.Add(this.label_begin);
            this.paid.Controls.Add(this.label_year);
            this.paid.Controls.Add(this.lookUp_year);
            this.paid.Name = "paid";
            this.paid.Size = new System.Drawing.Size(762, 85);
            this.paid.Text = "PAID";
            // 
            // label_sem
            // 
            this.label_sem.Location = new System.Drawing.Point(119, 12);
            this.label_sem.Name = "label_sem";
            this.label_sem.Size = new System.Drawing.Size(45, 13);
            this.label_sem.TabIndex = 41;
            this.label_sem.Text = "Semester";
            // 
            // lookUp_semester
            // 
            this.lookUp_semester.EditValue = "";
            this.lookUp_semester.Location = new System.Drawing.Point(119, 31);
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
            this.lookUp_semester.TabIndex = 40;
            // 
            // button_show_paid
            // 
            this.button_show_paid.Location = new System.Drawing.Point(455, 31);
            this.button_show_paid.Name = "button_show_paid";
            this.button_show_paid.Size = new System.Drawing.Size(75, 20);
            this.button_show_paid.TabIndex = 16;
            this.button_show_paid.Text = "Show";
            this.button_show_paid.Click += new System.EventHandler(this.button_show_paid_Click);
            // 
            // date_end
            // 
            this.date_end.EditValue = new System.DateTime(2010, 12, 16, 10, 1, 47, 0);
            this.date_end.Location = new System.Drawing.Point(340, 31);
            this.date_end.Name = "date_end";
            this.date_end.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_end.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.date_end.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_end.Properties.EditFormat.FormatString = "d.MM.yyyy";
            this.date_end.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_end.Properties.Mask.EditMask = "dd.MM.yyyy";
            this.date_end.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.date_end.Size = new System.Drawing.Size(100, 20);
            this.date_end.TabIndex = 14;
            // 
            // date_begin
            // 
            this.date_begin.EditValue = new System.DateTime(2010, 8, 1, 0, 0, 0, 0);
            this.date_begin.Location = new System.Drawing.Point(234, 31);
            this.date_begin.Name = "date_begin";
            this.date_begin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_begin.Properties.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.date_begin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_begin.Properties.EditFormat.FormatString = "dd.MM.yyyy";
            this.date_begin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.date_begin.Properties.Mask.EditMask = "dd.MM.yyyy";
            this.date_begin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.date_begin.Size = new System.Drawing.Size(100, 20);
            this.date_begin.TabIndex = 13;
            // 
            // label_end
            // 
            this.label_end.Location = new System.Drawing.Point(340, 12);
            this.label_end.Name = "label_end";
            this.label_end.Size = new System.Drawing.Size(43, 13);
            this.label_end.TabIndex = 10;
            this.label_end.Text = "End date";
            // 
            // label_begin
            // 
            this.label_begin.Location = new System.Drawing.Point(234, 12);
            this.label_begin.Name = "label_begin";
            this.label_begin.Size = new System.Drawing.Size(49, 13);
            this.label_begin.TabIndex = 8;
            this.label_begin.Text = "Start date";
            // 
            // label_year
            // 
            this.label_year.Location = new System.Drawing.Point(13, 12);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(40, 13);
            this.label_year.TabIndex = 6;
            this.label_year.Text = "EduYear";
            // 
            // lookUp_year
            // 
            this.lookUp_year.EditValue = "";
            this.lookUp_year.Location = new System.Drawing.Point(13, 31);
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
            this.lookUp_year.TabIndex = 5;
            this.lookUp_year.EditValueChanged += new System.EventHandler(this.lookUp_year_EditValueChanged);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.button_not_calculated);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(762, 85);
            this.xtraTabPage2.Text = "NOT CALCULATED";
            // 
            // button_not_calculated
            // 
            this.button_not_calculated.Location = new System.Drawing.Point(455, 31);
            this.button_not_calculated.Name = "button_not_calculated";
            this.button_not_calculated.Size = new System.Drawing.Size(75, 20);
            this.button_not_calculated.TabIndex = 17;
            this.button_not_calculated.Text = "Show";
            this.button_not_calculated.Click += new System.EventHandler(this.button_not_calculated_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.check_permitted);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.spin_amount);
            this.xtraTabPage1.Controls.Add(this.spin_percent);
            this.xtraTabPage1.Controls.Add(this.button_debt);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(762, 85);
            this.xtraTabPage1.Text = "DEBT";
            // 
            // check_permitted
            // 
            this.check_permitted.Location = new System.Drawing.Point(13, 57);
            this.check_permitted.Name = "check_permitted";
            this.check_permitted.Properties.Caption = "Hide permission granted Students";
            this.check_permitted.Size = new System.Drawing.Size(215, 19);
            this.check_permitted.TabIndex = 23;
            this.check_permitted.CheckedChanged += new System.EventHandler(this.button_debt_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(355, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(121, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Ignored Amount (NAIRA)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(234, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Percent must PAID (%)";
            // 
            // spin_amount
            // 
            this.spin_amount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spin_amount.Location = new System.Drawing.Point(355, 31);
            this.spin_amount.Name = "spin_amount";
            this.spin_amount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spin_amount.Size = new System.Drawing.Size(100, 20);
            this.spin_amount.TabIndex = 20;
            // 
            // spin_percent
            // 
            this.spin_percent.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spin_percent.Location = new System.Drawing.Point(234, 31);
            this.spin_percent.Name = "spin_percent";
            this.spin_percent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spin_percent.Size = new System.Drawing.Size(100, 20);
            this.spin_percent.TabIndex = 19;
            // 
            // button_debt
            // 
            this.button_debt.Location = new System.Drawing.Point(470, 31);
            this.button_debt.Name = "button_debt";
            this.button_debt.Size = new System.Drawing.Size(75, 20);
            this.button_debt.TabIndex = 18;
            this.button_debt.Text = "Show";
            this.button_debt.Click += new System.EventHandler(this.button_debt_Click);
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.button_discounts);
            this.xtraTabPage4.Controls.Add(this.labelControl4);
            this.xtraTabPage4.Controls.Add(this.checkedCombo_discounts);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(762, 85);
            this.xtraTabPage4.Text = "DISCOUNTS";
            // 
            // button_discounts
            // 
            this.button_discounts.Location = new System.Drawing.Point(455, 31);
            this.button_discounts.Name = "button_discounts";
            this.button_discounts.Size = new System.Drawing.Size(75, 20);
            this.button_discounts.TabIndex = 27;
            this.button_discounts.Text = "Show";
            this.button_discounts.Click += new System.EventHandler(this.button_discounts_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(234, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Discount Type";
            // 
            // checkedCombo_discounts
            // 
            this.checkedCombo_discounts.EditValue = "";
            this.checkedCombo_discounts.Location = new System.Drawing.Point(234, 31);
            this.checkedCombo_discounts.Name = "checkedCombo_discounts";
            this.checkedCombo_discounts.Properties.Appearance.Options.UseTextOptions = true;
            this.checkedCombo_discounts.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkedCombo_discounts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_discounts.Properties.NullText = "DISCOUNTS";
            this.checkedCombo_discounts.Properties.NullValuePrompt = "DISCOUNTS";
            this.checkedCombo_discounts.Properties.NullValuePromptShowForEmptyValue = true;
            this.checkedCombo_discounts.Properties.PopupFormMinSize = new System.Drawing.Size(215, 0);
            this.checkedCombo_discounts.Size = new System.Drawing.Size(215, 20);
            this.checkedCombo_discounts.TabIndex = 25;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.checkedCombo_decision);
            this.xtraTabPage3.Controls.Add(this.button_payment_percent);
            this.xtraTabPage3.Controls.Add(this.labelControl3);
            this.xtraTabPage3.Controls.Add(this.lookUp_status);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(762, 85);
            this.xtraTabPage3.Text = "PAYMENT PERCENTAGE";
            // 
            // checkedCombo_decision
            // 
            this.checkedCombo_decision.EditValue = "";
            this.checkedCombo_decision.Location = new System.Drawing.Point(13, 57);
            this.checkedCombo_decision.Name = "checkedCombo_decision";
            this.checkedCombo_decision.Properties.Appearance.Options.UseTextOptions = true;
            this.checkedCombo_decision.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.checkedCombo_decision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_decision.Properties.NullText = "DECISIONS";
            this.checkedCombo_decision.Properties.NullValuePrompt = "DECISIONS";
            this.checkedCombo_decision.Properties.NullValuePromptShowForEmptyValue = true;
            this.checkedCombo_decision.Properties.PopupFormMinSize = new System.Drawing.Size(215, 0);
            this.checkedCombo_decision.Size = new System.Drawing.Size(321, 20);
            this.checkedCombo_decision.TabIndex = 24;
            // 
            // button_payment_percent
            // 
            this.button_payment_percent.Location = new System.Drawing.Point(455, 31);
            this.button_payment_percent.Name = "button_payment_percent";
            this.button_payment_percent.Size = new System.Drawing.Size(75, 20);
            this.button_payment_percent.TabIndex = 19;
            this.button_payment_percent.Text = "Show";
            this.button_payment_percent.Click += new System.EventHandler(this.button_payment_percent_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(234, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Status";
            // 
            // lookUp_status
            // 
            this.lookUp_status.EditValue = "";
            this.lookUp_status.Location = new System.Drawing.Point(234, 31);
            this.lookUp_status.Name = "lookUp_status";
            this.lookUp_status.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_status.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_status.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_status.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_status.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_status.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("STATUS_ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lookUp_status.Properties.NullText = "";
            this.lookUp_status.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_status.Properties.ShowFooter = false;
            this.lookUp_status.Properties.ShowHeader = false;
            this.lookUp_status.Size = new System.Drawing.Size(100, 20);
            this.lookUp_status.TabIndex = 7;
            // 
            // group_filter
            // 
            this.group_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_filter.Controls.Add(this.button_excel);
            this.group_filter.Controls.Add(this.checkedCombo_departments);
            this.group_filter.Controls.Add(this.checkedCombo_class);
            this.group_filter.Controls.Add(this.grid_thstatistics);
            this.group_filter.Location = new System.Drawing.Point(0, 131);
            this.group_filter.Name = "group_filter";
            this.group_filter.Size = new System.Drawing.Size(792, 442);
            this.group_filter.TabIndex = 20;
            this.group_filter.Text = "Filter";
            // 
            // button_excel
            // 
            this.button_excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_excel.Enabled = false;
            this.button_excel.Location = new System.Drawing.Point(705, 32);
            this.button_excel.Name = "button_excel";
            this.button_excel.Size = new System.Drawing.Size(75, 23);
            this.button_excel.TabIndex = 25;
            this.button_excel.Text = "Excel";
            this.button_excel.Click += new System.EventHandler(this.button_excel_Click);
            // 
            // checkedCombo_departments
            // 
            this.checkedCombo_departments.EditValue = "";
            this.checkedCombo_departments.Location = new System.Drawing.Point(12, 35);
            this.checkedCombo_departments.Name = "checkedCombo_departments";
            this.checkedCombo_departments.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_departments.Properties.DropDownRows = 20;
            this.checkedCombo_departments.Properties.NullText = "All Departments";
            this.checkedCombo_departments.Properties.NullValuePrompt = "All Departments";
            this.checkedCombo_departments.Properties.NullValuePromptShowForEmptyValue = true;
            this.checkedCombo_departments.Properties.PopupFormMinSize = new System.Drawing.Size(400, 0);
            this.checkedCombo_departments.Size = new System.Drawing.Size(400, 20);
            this.checkedCombo_departments.TabIndex = 24;
            this.checkedCombo_departments.Popup += new System.EventHandler(this.OnPopup);
            this.checkedCombo_departments.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.OnCloseUp);
            this.checkedCombo_departments.EditValueChanged += new System.EventHandler(this.checkedCombo_departments_EditValueChanged);
            this.checkedCombo_departments.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.checkedCombo_departments_CustomDisplayText);
            // 
            // checkedCombo_class
            // 
            this.checkedCombo_class.EditValue = "";
            this.checkedCombo_class.Location = new System.Drawing.Point(418, 35);
            this.checkedCombo_class.Name = "checkedCombo_class";
            this.checkedCombo_class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_class.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("1", "1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("2", "2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("3", "3"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("4", "4"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5", "5")});
            this.checkedCombo_class.Properties.NullText = "All Classes";
            this.checkedCombo_class.Properties.NullValuePrompt = "All Classes";
            this.checkedCombo_class.Properties.NullValuePromptShowForEmptyValue = true;
            this.checkedCombo_class.Properties.PopupFormMinSize = new System.Drawing.Size(125, 125);
            this.checkedCombo_class.Properties.PopupFormSize = new System.Drawing.Size(125, 130);
            this.checkedCombo_class.Size = new System.Drawing.Size(125, 20);
            this.checkedCombo_class.TabIndex = 23;
            this.checkedCombo_class.EditValueChanged += new System.EventHandler(this.checkedCombo_class_EditValueChanged);
            // 
            // grid_thstatistics
            // 
            this.grid_thstatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_thstatistics.Location = new System.Drawing.Point(2, 72);
            this.grid_thstatistics.MainView = this.view_thstatistics;
            this.grid_thstatistics.Name = "grid_thstatistics";
            this.grid_thstatistics.Size = new System.Drawing.Size(788, 368);
            this.grid_thstatistics.TabIndex = 20;
            this.grid_thstatistics.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_thstatistics});
            this.grid_thstatistics.DoubleClick += new System.EventHandler(this.grid_thstatistics_DoubleClick);
            // 
            // view_thstatistics
            // 
            this.view_thstatistics.GridControl = this.grid_thstatistics;
            this.view_thstatistics.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAID", null, "{0}", ((short)(2)))});
            this.view_thstatistics.Name = "view_thstatistics";
            this.view_thstatistics.OptionsBehavior.Editable = false;
            this.view_thstatistics.OptionsCustomization.AllowColumnMoving = false;
            this.view_thstatistics.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_thstatistics.OptionsView.ShowAutoFilterRow = true;
            this.view_thstatistics.OptionsView.ShowFooter = true;
            this.view_thstatistics.OptionsView.ShowGroupPanel = false;
            this.view_thstatistics.OptionsView.ShowIndicator = false;
            // 
            // THStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.group_filter);
            this.Controls.Add(this.Pages);
            this.Name = "THStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounting Reports";
            this.Activated += new System.EventHandler(this.THStatistics_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.THStatistics_FormClosed);
            this.Load += new System.EventHandler(this.THStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pages)).EndInit();
            this.Pages.ResumeLayout(false);
            this.paid.ResumeLayout(false);
            this.paid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_semester.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_end.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_end.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_begin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_begin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_permitted.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_amount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_percent.Properties)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_discounts.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_decision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_status.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_filter)).EndInit();
            this.group_filter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_departments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_class.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_thstatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_thstatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl Pages;
        private DevExpress.XtraTab.XtraTabPage paid;
        private DevExpress.XtraEditors.SimpleButton button_show_paid;
        private DevExpress.XtraEditors.DateEdit date_end;
        private DevExpress.XtraEditors.DateEdit date_begin;
        private DevExpress.XtraEditors.LabelControl label_end;
        private DevExpress.XtraEditors.LabelControl label_begin;
        private DevExpress.XtraEditors.LabelControl label_year;
        private DevExpress.XtraEditors.LookUpEdit lookUp_year;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.GroupControl group_filter;
        private DevExpress.XtraGrid.GridControl grid_thstatistics;
        private DevExpress.XtraGrid.Views.Grid.GridView view_thstatistics;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_class;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_departments;
        private DevExpress.XtraEditors.SimpleButton button_excel;
        private System.Windows.Forms.SaveFileDialog saveFile_excel;
        private DevExpress.XtraEditors.SimpleButton button_not_calculated;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton button_debt;
        private DevExpress.XtraEditors.SpinEdit spin_amount;
        private DevExpress.XtraEditors.SpinEdit spin_percent;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit check_permitted;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUp_status;
        private DevExpress.XtraEditors.SimpleButton button_payment_percent;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_decision;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_discounts;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton button_discounts;
        private DevExpress.XtraEditors.LabelControl label_sem;
        private DevExpress.XtraEditors.LookUpEdit lookUp_semester;
    }
}