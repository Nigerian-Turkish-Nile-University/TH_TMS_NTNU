namespace TMS.trans
{
    partial class frmTrans
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrans));
            this.rbAZ = new System.Windows.Forms.RadioButton();
            this.rbEN = new System.Windows.Forms.RadioButton();
            this.rbTR = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.check_unlocked = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit_print = new DevExpress.XtraEditors.CheckEdit();
            this.spinEdit_transkript = new DevExpress.XtraEditors.SpinEdit();
            this.btnTRANS = new System.Windows.Forms.Button();
            this.report1 = new FastReport.Report();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_unlocked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_print.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_transkript.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbAZ
            // 
            this.rbAZ.AutoSize = true;
            this.rbAZ.Checked = true;
            this.rbAZ.Location = new System.Drawing.Point(20, 19);
            this.rbAZ.Name = "rbAZ";
            this.rbAZ.Size = new System.Drawing.Size(40, 18);
            this.rbAZ.TabIndex = 0;
            this.rbAZ.TabStop = true;
            this.rbAZ.Text = "NG";
            this.rbAZ.UseVisualStyleBackColor = true;
            // 
            // rbEN
            // 
            this.rbEN.AutoSize = true;
            this.rbEN.Location = new System.Drawing.Point(110, 19);
            this.rbEN.Name = "rbEN";
            this.rbEN.Size = new System.Drawing.Size(38, 18);
            this.rbEN.TabIndex = 0;
            this.rbEN.Text = "EN";
            this.rbEN.UseVisualStyleBackColor = true;
            // 
            // rbTR
            // 
            this.rbTR.AutoSize = true;
            this.rbTR.Location = new System.Drawing.Point(66, 19);
            this.rbTR.Name = "rbTR";
            this.rbTR.Size = new System.Drawing.Size(38, 18);
            this.rbTR.TabIndex = 0;
            this.rbTR.Text = "TR";
            this.rbTR.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.check_unlocked);
            this.groupBox1.Controls.Add(this.checkEdit_print);
            this.groupBox1.Controls.Add(this.spinEdit_transkript);
            this.groupBox1.Controls.Add(this.btnTRANS);
            this.groupBox1.Controls.Add(this.rbTR);
            this.groupBox1.Controls.Add(this.rbAZ);
            this.groupBox1.Controls.Add(this.rbEN);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 133);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // check_unlocked
            // 
            this.check_unlocked.Location = new System.Drawing.Point(80, 83);
            this.check_unlocked.Name = "check_unlocked";
            this.check_unlocked.Properties.Caption = "Unlocked";
            this.check_unlocked.Size = new System.Drawing.Size(68, 19);
            this.check_unlocked.TabIndex = 3;
            this.check_unlocked.CheckedChanged += new System.EventHandler(this.checkEdit_print_CheckedChanged);
            // 
            // checkEdit_print
            // 
            this.checkEdit_print.Location = new System.Drawing.Point(18, 83);
            this.checkEdit_print.Name = "checkEdit_print";
            this.checkEdit_print.Properties.Caption = "Print";
            this.checkEdit_print.Size = new System.Drawing.Size(56, 19);
            this.checkEdit_print.TabIndex = 3;
            this.checkEdit_print.CheckedChanged += new System.EventHandler(this.checkEdit_print_CheckedChanged);
            // 
            // spinEdit_transkript
            // 
            this.spinEdit_transkript.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spinEdit_transkript.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_transkript.Enabled = false;
            this.spinEdit_transkript.Location = new System.Drawing.Point(3, 108);
            this.spinEdit_transkript.Name = "spinEdit_transkript";
            this.spinEdit_transkript.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.spinEdit_transkript.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEdit_transkript.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.spinEdit_transkript.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.spinEdit_transkript.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.spinEdit_transkript.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.spinEdit_transkript.Properties.IsFloatValue = false;
            this.spinEdit_transkript.Properties.Mask.EditMask = "\\d{1,9}";
            this.spinEdit_transkript.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEdit_transkript.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit_transkript.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.spinEdit_transkript.Size = new System.Drawing.Size(161, 22);
            this.spinEdit_transkript.TabIndex = 2;
            this.spinEdit_transkript.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.spinEdit_transkript_ButtonClick);
            // 
            // btnTRANS
            // 
            this.btnTRANS.Location = new System.Drawing.Point(37, 54);
            this.btnTRANS.Name = "btnTRANS";
            this.btnTRANS.Size = new System.Drawing.Size(100, 23);
            this.btnTRANS.TabIndex = 1;
            this.btnTRANS.Text = "Transcript";
            this.btnTRANS.UseVisualStyleBackColor = true;
            this.btnTRANS.Click += new System.EventHandler(this.btnTRANS_Click);
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // frmTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 157);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transcript";
            this.Activated += new System.EventHandler(this.frmTrans_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTrans_FormClosed);
            this.Load += new System.EventHandler(this.frmTrans_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_unlocked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_print.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_transkript.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAZ;
        private System.Windows.Forms.RadioButton rbEN;
        private System.Windows.Forms.RadioButton rbTR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTRANS;
        private FastReport.Report report1;
        private DevExpress.XtraEditors.SpinEdit spinEdit_transkript;
        private DevExpress.XtraEditors.CheckEdit checkEdit_print;
        private DevExpress.XtraEditors.CheckEdit check_unlocked;
    }
}