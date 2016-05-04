namespace TMS.TH
{
    partial class hesablama
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
            this.components = new System.ComponentModel.Container();
            this.group_students = new DevExpress.XtraEditors.GroupControl();
            this.button_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar_calculated = new DevExpress.XtraEditors.ProgressBarControl();
            this.grid_students = new DevExpress.XtraGrid.GridControl();
            this.view_students = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button_calculate = new DevExpress.XtraEditors.SimpleButton();
            this.button_show = new DevExpress.XtraEditors.SimpleButton();
            this.checkedCombo_years = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.check_calculated = new DevExpress.XtraEditors.CheckEdit();
            this.checkedCombo_departments = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.timer_calculate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.group_students)).BeginInit();
            this.group_students.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar_calculated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_students)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_years.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_calculated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_departments.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // group_students
            // 
            this.group_students.Controls.Add(this.button_cancel);
            this.group_students.Controls.Add(this.progressBar_calculated);
            this.group_students.Controls.Add(this.grid_students);
            this.group_students.Controls.Add(this.button_calculate);
            this.group_students.Controls.Add(this.button_show);
            this.group_students.Controls.Add(this.checkedCombo_years);
            this.group_students.Controls.Add(this.check_calculated);
            this.group_students.Controls.Add(this.checkedCombo_departments);
            this.group_students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_students.Location = new System.Drawing.Point(0, 0);
            this.group_students.Name = "group_students";
            this.group_students.Size = new System.Drawing.Size(572, 473);
            this.group_students.TabIndex = 29;
            this.group_students.Text = "Department and Entry Year FILTER";
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(428, 438);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(130, 23);
            this.button_cancel.TabIndex = 37;
            this.button_cancel.Text = "STOP";
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // progressBar_calculated
            // 
            this.progressBar_calculated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_calculated.Location = new System.Drawing.Point(12, 90);
            this.progressBar_calculated.Name = "progressBar_calculated";
            this.progressBar_calculated.Properties.PercentView = false;
            this.progressBar_calculated.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.progressBar_calculated.Properties.ShowTitle = true;
            this.progressBar_calculated.Properties.Step = 1;
            this.progressBar_calculated.Size = new System.Drawing.Size(546, 18);
            this.progressBar_calculated.TabIndex = 36;
            // 
            // grid_students
            // 
            this.grid_students.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_students.Location = new System.Drawing.Point(0, 114);
            this.grid_students.MainView = this.view_students;
            this.grid_students.Name = "grid_students";
            this.grid_students.Size = new System.Drawing.Size(572, 309);
            this.grid_students.TabIndex = 35;
            this.grid_students.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_students});
            // 
            // view_students
            // 
            this.view_students.GridControl = this.grid_students;
            this.view_students.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAID", null, "{0}", ((short)(2)))});
            this.view_students.Name = "view_students";
            this.view_students.OptionsBehavior.Editable = false;
            this.view_students.OptionsCustomization.AllowColumnMoving = false;
            this.view_students.OptionsCustomization.AllowFilter = false;
            this.view_students.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_students.OptionsView.ShowAutoFilterRow = true;
            this.view_students.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.view_students.OptionsView.ShowFooter = true;
            this.view_students.OptionsView.ShowGroupPanel = false;
            this.view_students.OptionsView.ShowIndicator = false;
            this.view_students.RowCountChanged += new System.EventHandler(this.view_students_RowCountChanged);
            // 
            // button_calculate
            // 
            this.button_calculate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_calculate.Enabled = false;
            this.button_calculate.Location = new System.Drawing.Point(14, 438);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(408, 23);
            this.button_calculate.TabIndex = 34;
            this.button_calculate.Text = "CALCULATE";
            this.button_calculate.Click += new System.EventHandler(this.button_calculate_Click);
            // 
            // button_show
            // 
            this.button_show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_show.Location = new System.Drawing.Point(428, 61);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(130, 23);
            this.button_show.TabIndex = 32;
            this.button_show.Text = "SHOW";
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            // 
            // checkedCombo_years
            // 
            this.checkedCombo_years.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedCombo_years.EditValue = "";
            this.checkedCombo_years.Location = new System.Drawing.Point(428, 35);
            this.checkedCombo_years.Name = "checkedCombo_years";
            this.checkedCombo_years.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_years.Properties.NullText = "Bütün İllər";
            this.checkedCombo_years.Properties.NullValuePrompt = "Bütün İllər";
            this.checkedCombo_years.Properties.NullValuePromptShowForEmptyValue = true;
            this.checkedCombo_years.Properties.PopupFormMinSize = new System.Drawing.Size(130, 130);
            this.checkedCombo_years.Properties.PopupFormSize = new System.Drawing.Size(130, 130);
            this.checkedCombo_years.Size = new System.Drawing.Size(130, 20);
            this.checkedCombo_years.TabIndex = 31;
            this.checkedCombo_years.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.checkedCombo_years_CustomDisplayText);
            this.checkedCombo_years.Resize += new System.EventHandler(this.checkedCombo_years_Resize);
            // 
            // check_calculated
            // 
            this.check_calculated.Location = new System.Drawing.Point(12, 61);
            this.check_calculated.Name = "check_calculated";
            this.check_calculated.Properties.Caption = "SHOW PREVIOUSLY CALCULATED RECORDS. In this case, they will ReCalculated.";
            this.check_calculated.Size = new System.Drawing.Size(413, 19);
            this.check_calculated.TabIndex = 29;
            // 
            // checkedCombo_departments
            // 
            this.checkedCombo_departments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedCombo_departments.EditValue = "";
            this.checkedCombo_departments.Location = new System.Drawing.Point(12, 35);
            this.checkedCombo_departments.Name = "checkedCombo_departments";
            this.checkedCombo_departments.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_departments.Properties.DropDownRows = 20;
            this.checkedCombo_departments.Properties.NullText = "Bütün bölmələr";
            this.checkedCombo_departments.Properties.NullValuePrompt = "Bütün bölmələr";
            this.checkedCombo_departments.Properties.PopupFormMinSize = new System.Drawing.Size(410, 200);
            this.checkedCombo_departments.Size = new System.Drawing.Size(410, 20);
            this.checkedCombo_departments.TabIndex = 25;
            this.checkedCombo_departments.Popup += new System.EventHandler(this.OnPopup);
            this.checkedCombo_departments.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.checkedCombo_departments_CloseUp);
            this.checkedCombo_departments.EditValueChanged += new System.EventHandler(this.checkedCombo_departments_EditValueChanged);
            this.checkedCombo_departments.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.checkedCombo_departments_CustomDisplayText);
            this.checkedCombo_departments.Resize += new System.EventHandler(this.checkedCombo_departments_Resize);
            // 
            // timer_calculate
            // 
            this.timer_calculate.Interval = 50;
            this.timer_calculate.Tick += new System.EventHandler(this.timer_calculate_Tick);
            // 
            // hesablama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 473);
            this.Controls.Add(this.group_students);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "hesablama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Fee Calculations";
            this.Load += new System.EventHandler(this.hesablama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_students)).EndInit();
            this.group_students.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar_calculated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_students)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_years.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_calculated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_departments.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl group_students;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_departments;
        private DevExpress.XtraEditors.CheckEdit check_calculated;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_years;
        private DevExpress.XtraEditors.SimpleButton button_show;
        private DevExpress.XtraGrid.GridControl grid_students;
        private DevExpress.XtraGrid.Views.Grid.GridView view_students;
        private DevExpress.XtraEditors.SimpleButton button_calculate;
        public DevExpress.XtraEditors.ProgressBarControl progressBar_calculated;
        private System.Windows.Forms.Timer timer_calculate;
        private DevExpress.XtraEditors.SimpleButton button_cancel;
    }
}