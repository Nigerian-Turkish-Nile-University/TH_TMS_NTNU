namespace TMS.Selectors
{
    partial class form_CAG
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
            this.dxValidationProvider_CAG = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.group_CAG = new DevExpress.XtraEditors.GroupControl();
            this.lookUp_company = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUp_type = new DevExpress.XtraEditors.LookUpEdit();
            this.check_confirm = new DevExpress.XtraEditors.CheckEdit();
            this.button_save = new DevExpress.XtraEditors.SimpleButton();
            this.button_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label_company = new DevExpress.XtraEditors.LabelControl();
            this.label_namsname = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_surname = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_name = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider_CAG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_CAG)).BeginInit();
            this.group_CAG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_company.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_confirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_surname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // group_CAG
            // 
            this.group_CAG.Controls.Add(this.lookUp_company);
            this.group_CAG.Controls.Add(this.lookUp_type);
            this.group_CAG.Controls.Add(this.check_confirm);
            this.group_CAG.Controls.Add(this.button_save);
            this.group_CAG.Controls.Add(this.button_cancel);
            this.group_CAG.Controls.Add(this.labelControl1);
            this.group_CAG.Controls.Add(this.label_company);
            this.group_CAG.Controls.Add(this.label_namsname);
            this.group_CAG.Controls.Add(this.textEdit_surname);
            this.group_CAG.Controls.Add(this.textEdit_name);
            this.group_CAG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_CAG.Location = new System.Drawing.Point(0, 0);
            this.group_CAG.Name = "group_CAG";
            this.group_CAG.Size = new System.Drawing.Size(356, 155);
            this.group_CAG.TabIndex = 0;
            this.group_CAG.Text = "Relatives, working in Partner Companies";
            // 
            // lookUp_company
            // 
            this.lookUp_company.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lookUp_company.EditValue = "";
            this.lookUp_company.Location = new System.Drawing.Point(88, 59);
            this.lookUp_company.Name = "lookUp_company";
            this.lookUp_company.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lookUp_company.Properties.Appearance.Options.UseFont = true;
            this.lookUp_company.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.lookUp_company.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_company.Properties.NullText = "";
            this.lookUp_company.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_company.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lookUp_company.Properties.ShowFooter = false;
            this.lookUp_company.Properties.ShowHeader = false;
            this.lookUp_company.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUp_company.Size = new System.Drawing.Size(256, 20);
            this.lookUp_company.TabIndex = 2;
            this.lookUp_company.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookUp_company_ButtonClick);
            this.lookUp_company.Validating += new System.ComponentModel.CancelEventHandler(this.edit_name_Validating);
            // 
            // lookUp_type
            // 
            this.lookUp_type.Location = new System.Drawing.Point(88, 85);
            this.lookUp_type.Name = "lookUp_type";
            this.lookUp_type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_type.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "type_title"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GENDER_ID", "gender", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lookUp_type.Properties.NullText = "";
            this.lookUp_type.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_type.Properties.ShowFooter = false;
            this.lookUp_type.Properties.ShowHeader = false;
            this.lookUp_type.Size = new System.Drawing.Size(110, 20);
            this.lookUp_type.TabIndex = 3;
            this.lookUp_type.Validating += new System.ComponentModel.CancelEventHandler(this.edit_name_Validating);
            // 
            // check_confirm
            // 
            this.check_confirm.Location = new System.Drawing.Point(217, 86);
            this.check_confirm.Name = "check_confirm";
            this.check_confirm.Properties.Caption = "Info is CONFIRMED";
            this.check_confirm.Size = new System.Drawing.Size(127, 19);
            this.check_confirm.TabIndex = 4;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(188, 120);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "ADD";
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(269, 120);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "Cancel";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 89);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 81;
            this.labelControl1.Text = "TYPE:";
            // 
            // label_company
            // 
            this.label_company.Location = new System.Drawing.Point(12, 62);
            this.label_company.Name = "label_company";
            this.label_company.Size = new System.Drawing.Size(49, 13);
            this.label_company.TabIndex = 81;
            this.label_company.Text = "Company:";
            // 
            // label_namsname
            // 
            this.label_namsname.Location = new System.Drawing.Point(12, 36);
            this.label_namsname.Name = "label_namsname";
            this.label_namsname.Size = new System.Drawing.Size(71, 13);
            this.label_namsname.TabIndex = 78;
            this.label_namsname.Text = "Name, SName:";
            // 
            // textEdit_surname
            // 
            this.textEdit_surname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_surname.Location = new System.Drawing.Point(219, 33);
            this.textEdit_surname.Name = "textEdit_surname";
            this.textEdit_surname.Properties.MaxLength = 20;
            this.textEdit_surname.Size = new System.Drawing.Size(125, 20);
            this.textEdit_surname.TabIndex = 1;
            this.textEdit_surname.Validating += new System.ComponentModel.CancelEventHandler(this.edit_name_Validating);
            // 
            // textEdit_name
            // 
            this.textEdit_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit_name.Location = new System.Drawing.Point(88, 33);
            this.textEdit_name.Name = "textEdit_name";
            this.textEdit_name.Properties.MaxLength = 20;
            this.textEdit_name.Size = new System.Drawing.Size(125, 20);
            this.textEdit_name.TabIndex = 0;
            this.textEdit_name.Validating += new System.ComponentModel.CancelEventHandler(this.edit_name_Validating);
            // 
            // form_CAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 155);
            this.Controls.Add(this.group_CAG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_CAG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.form_CAG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider_CAG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_CAG)).EndInit();
            this.group_CAG.ResumeLayout(false);
            this.group_CAG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_company.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check_confirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_surname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_name.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider_CAG;
        private DevExpress.XtraEditors.GroupControl group_CAG;
        private DevExpress.XtraEditors.SimpleButton button_save;
        private DevExpress.XtraEditors.SimpleButton button_cancel;
        private DevExpress.XtraEditors.LabelControl label_company;
        private DevExpress.XtraEditors.LabelControl label_namsname;
        public DevExpress.XtraEditors.CheckEdit check_confirm;
        public DevExpress.XtraEditors.LookUpEdit lookUp_type;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit textEdit_surname;
        public DevExpress.XtraEditors.TextEdit textEdit_name;
        public DevExpress.XtraEditors.LookUpEdit lookUp_company;
    }
}