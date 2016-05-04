namespace TMS.advisor
{
    partial class danisman
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
            this.group_danisman = new DevExpress.XtraEditors.GroupControl();
            this.label_year_sem = new DevExpress.XtraEditors.LabelControl();
            this.grid_danisman = new DevExpress.XtraGrid.GridControl();
            this.view_danisman = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button_delete = new DevExpress.XtraEditors.SimpleButton();
            this.button_add_change = new DevExpress.XtraEditors.SimpleButton();
            this.label_student = new DevExpress.XtraEditors.LabelControl();
            this.browse_student = new DevExpress.XtraEditors.ButtonEdit();
            this.label_danisman = new DevExpress.XtraEditors.LabelControl();
            this.browse_employee = new DevExpress.XtraEditors.ButtonEdit();
            this.radio_danisman = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.group_danisman)).BeginInit();
            this.group_danisman.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_danisman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_danisman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_student.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_employee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio_danisman.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // group_danisman
            // 
            this.group_danisman.Controls.Add(this.label_year_sem);
            this.group_danisman.Controls.Add(this.grid_danisman);
            this.group_danisman.Controls.Add(this.button_delete);
            this.group_danisman.Controls.Add(this.button_add_change);
            this.group_danisman.Controls.Add(this.label_student);
            this.group_danisman.Controls.Add(this.browse_student);
            this.group_danisman.Controls.Add(this.label_danisman);
            this.group_danisman.Controls.Add(this.browse_employee);
            this.group_danisman.Controls.Add(this.radio_danisman);
            this.group_danisman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_danisman.Location = new System.Drawing.Point(0, 0);
            this.group_danisman.Name = "group_danisman";
            this.group_danisman.Size = new System.Drawing.Size(392, 573);
            this.group_danisman.TabIndex = 0;
            // 
            // label_year_sem
            // 
            this.label_year_sem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label_year_sem.Location = new System.Drawing.Point(12, 116);
            this.label_year_sem.Name = "label_year_sem";
            this.label_year_sem.Size = new System.Drawing.Size(92, 13);
            this.label_year_sem.TabIndex = 36;
            this.label_year_sem.Text = "Year - Semester";
            // 
            // grid_danisman
            // 
            this.grid_danisman.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_danisman.Location = new System.Drawing.Point(2, 147);
            this.grid_danisman.MainView = this.view_danisman;
            this.grid_danisman.Name = "grid_danisman";
            this.grid_danisman.Size = new System.Drawing.Size(388, 424);
            this.grid_danisman.TabIndex = 35;
            this.grid_danisman.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_danisman});
            // 
            // view_danisman
            // 
            this.view_danisman.GridControl = this.grid_danisman;
            this.view_danisman.Name = "view_danisman";
            this.view_danisman.OptionsBehavior.Editable = false;
            this.view_danisman.OptionsView.ShowFooter = true;
            this.view_danisman.OptionsView.ShowGroupPanel = false;
            this.view_danisman.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.view_danisman_FocusedRowChanged);
            this.view_danisman.RowCountChanged += new System.EventHandler(this.view_danisman_RowCountChanged);
            // 
            // button_delete
            // 
            this.button_delete.Enabled = false;
            this.button_delete.Location = new System.Drawing.Point(305, 106);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 34;
            this.button_delete.Text = "Delete";
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_add_change
            // 
            this.button_add_change.Location = new System.Drawing.Point(224, 106);
            this.button_add_change.Name = "button_add_change";
            this.button_add_change.Size = new System.Drawing.Size(75, 23);
            this.button_add_change.TabIndex = 33;
            this.button_add_change.Text = "Change";
            this.button_add_change.Click += new System.EventHandler(this.button_add_change_Click);
            // 
            // label_student
            // 
            this.label_student.Location = new System.Drawing.Point(15, 54);
            this.label_student.Name = "label_student";
            this.label_student.Size = new System.Drawing.Size(43, 13);
            this.label_student.TabIndex = 32;
            this.label_student.Text = "Students";
            // 
            // browse_student
            // 
            this.browse_student.Enabled = false;
            this.browse_student.Location = new System.Drawing.Point(64, 51);
            this.browse_student.Name = "browse_student";
            this.browse_student.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.browse_student.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.browse_student.Properties.Appearance.Options.UseBackColor = true;
            this.browse_student.Properties.Appearance.Options.UseForeColor = true;
            this.browse_student.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.browse_student.Properties.ReadOnly = true;
            this.browse_student.Size = new System.Drawing.Size(316, 20);
            this.browse_student.TabIndex = 31;
            this.browse_student.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.browse_student_ButtonClick);
            // 
            // label_danisman
            // 
            this.label_danisman.Location = new System.Drawing.Point(7, 28);
            this.label_danisman.Name = "label_danisman";
            this.label_danisman.Size = new System.Drawing.Size(51, 13);
            this.label_danisman.TabIndex = 30;
            this.label_danisman.Text = "Supervisor";
            // 
            // browse_employee
            // 
            this.browse_employee.Location = new System.Drawing.Point(64, 25);
            this.browse_employee.Name = "browse_employee";
            this.browse_employee.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.browse_employee.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.browse_employee.Properties.Appearance.Options.UseBackColor = true;
            this.browse_employee.Properties.Appearance.Options.UseForeColor = true;
            this.browse_employee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.browse_employee.Properties.ReadOnly = true;
            this.browse_employee.Size = new System.Drawing.Size(316, 20);
            this.browse_employee.TabIndex = 29;
            this.browse_employee.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.browse_employee_ButtonClick);
            // 
            // radio_danisman
            // 
            this.radio_danisman.EditValue = ((short)(1));
            this.radio_danisman.Location = new System.Drawing.Point(12, 77);
            this.radio_danisman.Name = "radio_danisman";
            this.radio_danisman.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "BULK"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Selected Student")});
            this.radio_danisman.Size = new System.Drawing.Size(368, 23);
            this.radio_danisman.TabIndex = 0;
            this.radio_danisman.SelectedIndexChanged += new System.EventHandler(this.radio_danisman_SelectedIndexChanged);
            // 
            // danisman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(392, 573);
            this.Controls.Add(this.group_danisman);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "danisman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisor Assignment";
            this.Activated += new System.EventHandler(this.danisman_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.danisman_FormClosed);
            this.Load += new System.EventHandler(this.danisman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_danisman)).EndInit();
            this.group_danisman.ResumeLayout(false);
            this.group_danisman.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_danisman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_danisman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_student.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_employee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radio_danisman.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl group_danisman;
        private DevExpress.XtraGrid.GridControl grid_danisman;
        private DevExpress.XtraGrid.Views.Grid.GridView view_danisman;
        private DevExpress.XtraEditors.SimpleButton button_delete;
        private DevExpress.XtraEditors.SimpleButton button_add_change;
        private DevExpress.XtraEditors.LabelControl label_student;
        private DevExpress.XtraEditors.ButtonEdit browse_student;
        private DevExpress.XtraEditors.LabelControl label_danisman;
        private DevExpress.XtraEditors.ButtonEdit browse_employee;
        private DevExpress.XtraEditors.RadioGroup radio_danisman;
        private DevExpress.XtraEditors.LabelControl label_year_sem;


    }
}