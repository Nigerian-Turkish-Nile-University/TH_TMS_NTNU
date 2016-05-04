namespace TelebeQeydiyyat.Selectors
{
    partial class frmSecQohum
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
            this.leQohumType = new DevExpress.XtraEditors.LookUpEdit();
            this.group_relative = new DevExpress.XtraEditors.GroupControl();
            this.browse_relative = new DevExpress.XtraEditors.ButtonEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.chbTesdiqlenib = new DevExpress.XtraEditors.CheckEdit();
            this.ErrorProvider_relatives = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.leQohumType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_relative)).BeginInit();
            this.group_relative.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browse_relative.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbTesdiqlenib.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider_relatives)).BeginInit();
            this.SuspendLayout();
            // 
            // leQohumType
            // 
            this.leQohumType.Location = new System.Drawing.Point(12, 33);
            this.leQohumType.Name = "leQohumType";
            this.leQohumType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leQohumType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "type_title"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GENDER_ID", "gender", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.leQohumType.Properties.NullText = "";
            this.leQohumType.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.leQohumType.Properties.ShowFooter = false;
            this.leQohumType.Properties.ShowHeader = false;
            this.leQohumType.Size = new System.Drawing.Size(100, 20);
            this.leQohumType.TabIndex = 19;
            this.leQohumType.EditValueChanged += new System.EventHandler(this.leQohumType_EditValueChanged);
            // 
            // group_relative
            // 
            this.group_relative.Controls.Add(this.browse_relative);
            this.group_relative.Controls.Add(this.btnCancel);
            this.group_relative.Controls.Add(this.btnOk);
            this.group_relative.Controls.Add(this.chbTesdiqlenib);
            this.group_relative.Controls.Add(this.leQohumType);
            this.group_relative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_relative.Location = new System.Drawing.Point(0, 0);
            this.group_relative.Name = "group_relative";
            this.group_relative.Size = new System.Drawing.Size(263, 130);
            this.group_relative.TabIndex = 30;
            this.group_relative.Text = "Relative, working or studying in NTNU";
            // 
            // browse_relative
            // 
            this.browse_relative.Location = new System.Drawing.Point(12, 59);
            this.browse_relative.Name = "browse_relative";
            this.browse_relative.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.browse_relative.Size = new System.Drawing.Size(239, 20);
            this.browse_relative.TabIndex = 35;
            this.browse_relative.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.browse_relative_ButtonClick);
            this.browse_relative.EditValueChanged += new System.EventHandler(this.browse_relative_EditValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(176, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(95, 95);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 33;
            this.btnOk.Text = "ADD";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chbTesdiqlenib
            // 
            this.chbTesdiqlenib.Location = new System.Drawing.Point(118, 34);
            this.chbTesdiqlenib.Name = "chbTesdiqlenib";
            this.chbTesdiqlenib.Properties.Caption = "Info is CONFIRMED";
            this.chbTesdiqlenib.Size = new System.Drawing.Size(134, 19);
            this.chbTesdiqlenib.TabIndex = 31;
            this.chbTesdiqlenib.CheckedChanged += new System.EventHandler(this.chbTesdiqlenib_CheckedChanged);
            // 
            // ErrorProvider_relatives
            // 
            this.ErrorProvider_relatives.ContainerControl = this;
            // 
            // frmSecQohum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 130);
            this.Controls.Add(this.group_relative);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSecQohum";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmSecQohum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leQohumType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_relative)).EndInit();
            this.group_relative.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browse_relative.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chbTesdiqlenib.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider_relatives)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit leQohumType;
        private DevExpress.XtraEditors.GroupControl group_relative;
        public DevExpress.XtraEditors.CheckEdit chbTesdiqlenib;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ErrorProvider_relatives;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.ButtonEdit browse_relative;
    }
}