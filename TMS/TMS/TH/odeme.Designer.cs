namespace TMS.TH
{
    partial class odeme
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
            this.openDialog_payments = new System.Windows.Forms.OpenFileDialog();
            this.group_odeme = new DevExpress.XtraEditors.GroupControl();
            this.check_pCode = new DevExpress.XtraEditors.CheckEdit();
            this.richText_error = new System.Windows.Forms.RichTextBox();
            this.browse_excel = new DevExpress.XtraEditors.ButtonEdit();
            this.button_import = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.group_odeme)).BeginInit();
            this.group_odeme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_pCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_excel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // openDialog_payments
            // 
            this.openDialog_payments.FileName = "openFileDialog1";
            // 
            // group_odeme
            // 
            this.group_odeme.Controls.Add(this.check_pCode);
            this.group_odeme.Controls.Add(this.richText_error);
            this.group_odeme.Controls.Add(this.browse_excel);
            this.group_odeme.Controls.Add(this.button_import);
            this.group_odeme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_odeme.Location = new System.Drawing.Point(0, 0);
            this.group_odeme.Name = "group_odeme";
            this.group_odeme.Size = new System.Drawing.Size(492, 273);
            this.group_odeme.TabIndex = 2;
            this.group_odeme.Text = "Get excel file";
            // 
            // check_pCode
            // 
            this.check_pCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.check_pCode.Location = new System.Drawing.Point(3, 249);
            this.check_pCode.Name = "check_pCode";
            this.check_pCode.Properties.Caption = "Import as BANK Payments";
            this.check_pCode.Size = new System.Drawing.Size(178, 19);
            this.check_pCode.TabIndex = 4;
            // 
            // richText_error
            // 
            this.richText_error.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richText_error.BackColor = System.Drawing.SystemColors.Window;
            this.richText_error.Location = new System.Drawing.Point(5, 51);
            this.richText_error.Name = "richText_error";
            this.richText_error.ReadOnly = true;
            this.richText_error.Size = new System.Drawing.Size(482, 188);
            this.richText_error.TabIndex = 3;
            this.richText_error.Text = "";
            // 
            // browse_excel
            // 
            this.browse_excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.browse_excel.Location = new System.Drawing.Point(5, 25);
            this.browse_excel.Name = "browse_excel";
            this.browse_excel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.browse_excel.Properties.ReadOnly = true;
            this.browse_excel.Size = new System.Drawing.Size(482, 20);
            this.browse_excel.TabIndex = 2;
            this.browse_excel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.browse_excel_ButtonClick);
            // 
            // button_import
            // 
            this.button_import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_import.Enabled = false;
            this.button_import.Location = new System.Drawing.Point(387, 245);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(100, 23);
            this.button_import.TabIndex = 1;
            this.button_import.Text = "Import";
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // odeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 273);
            this.Controls.Add(this.group_odeme);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "odeme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Payments";
            this.Activated += new System.EventHandler(this.odeme_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.odeme_FormClosed);            
            ((System.ComponentModel.ISupportInitialize)(this.group_odeme)).EndInit();
            this.group_odeme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.check_pCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browse_excel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openDialog_payments;
        private DevExpress.XtraEditors.GroupControl group_odeme;
        private DevExpress.XtraEditors.ButtonEdit browse_excel;
        private DevExpress.XtraEditors.SimpleButton button_import;
        private System.Windows.Forms.RichTextBox richText_error;
        private DevExpress.XtraEditors.CheckEdit check_pCode;
    }
}