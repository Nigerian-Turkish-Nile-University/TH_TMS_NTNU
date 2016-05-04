namespace TMS.cixarislar
{
    partial class frmArayis
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMezun = new System.Windows.Forms.Button();
            this.btnArayis = new System.Windows.Forms.Button();
            this.rbEN = new System.Windows.Forms.RadioButton();
            this.rbTR = new System.Windows.Forms.RadioButton();
            this.rbAZ = new System.Windows.Forms.RadioButton();
            this.txtKurs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtedu_type = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttedris_il = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAtaAd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkEdit_print = new DevExpress.XtraEditors.CheckEdit();
            this.spinEdit_print = new DevExpress.XtraEditors.SpinEdit();
            this.checkEdit_mezun = new DevExpress.XtraEditors.CheckEdit();
            this.spinEdit_mezun = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_print.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_print.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_mezun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_mezun.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkEdit_mezun);
            this.groupBox1.Controls.Add(this.spinEdit_mezun);
            this.groupBox1.Controls.Add(this.checkEdit_print);
            this.groupBox1.Controls.Add(this.spinEdit_print);
            this.groupBox1.Controls.Add(this.btnMezun);
            this.groupBox1.Controls.Add(this.btnArayis);
            this.groupBox1.Controls.Add(this.rbEN);
            this.groupBox1.Controls.Add(this.rbTR);
            this.groupBox1.Controls.Add(this.rbAZ);
            this.groupBox1.Controls.Add(this.txtKurs);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtedu_type);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txttedris_il);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGender);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAtaAd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arayış çıxarışı";
            // 
            // btnMezun
            // 
            this.btnMezun.Location = new System.Drawing.Point(258, 202);
            this.btnMezun.Name = "btnMezun";
            this.btnMezun.Size = new System.Drawing.Size(85, 23);
            this.btnMezun.TabIndex = 5;
            this.btnMezun.Text = "Məzun Arayış";
            this.btnMezun.UseVisualStyleBackColor = true;
            this.btnMezun.Click += new System.EventHandler(this.btnMezun_Click);
            // 
            // btnArayis
            // 
            this.btnArayis.Location = new System.Drawing.Point(258, 173);
            this.btnArayis.Name = "btnArayis";
            this.btnArayis.Size = new System.Drawing.Size(85, 23);
            this.btnArayis.TabIndex = 5;
            this.btnArayis.Text = "Arayış ";
            this.btnArayis.UseVisualStyleBackColor = true;
            this.btnArayis.Click += new System.EventHandler(this.btnArayis_Click);
            // 
            // rbEN
            // 
            this.rbEN.AutoSize = true;
            this.rbEN.Location = new System.Drawing.Point(305, 19);
            this.rbEN.Name = "rbEN";
            this.rbEN.Size = new System.Drawing.Size(38, 18);
            this.rbEN.TabIndex = 4;
            this.rbEN.Text = "EN";
            this.rbEN.UseVisualStyleBackColor = true;
            this.rbEN.CheckedChanged += new System.EventHandler(this.rbAZ_CheckedChanged);
            // 
            // rbTR
            // 
            this.rbTR.AutoSize = true;
            this.rbTR.Location = new System.Drawing.Point(190, 19);
            this.rbTR.Name = "rbTR";
            this.rbTR.Size = new System.Drawing.Size(38, 18);
            this.rbTR.TabIndex = 4;
            this.rbTR.Text = "TR";
            this.rbTR.UseVisualStyleBackColor = true;
            this.rbTR.CheckedChanged += new System.EventHandler(this.rbAZ_CheckedChanged);
            // 
            // rbAZ
            // 
            this.rbAZ.AutoSize = true;
            this.rbAZ.Checked = true;
            this.rbAZ.Location = new System.Drawing.Point(73, 19);
            this.rbAZ.Name = "rbAZ";
            this.rbAZ.Size = new System.Drawing.Size(40, 18);
            this.rbAZ.TabIndex = 4;
            this.rbAZ.TabStop = true;
            this.rbAZ.Text = "AZ";
            this.rbAZ.UseVisualStyleBackColor = true;
            this.rbAZ.CheckedChanged += new System.EventHandler(this.rbAZ_CheckedChanged);
            // 
            // txtKurs
            // 
            this.txtKurs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKurs.Location = new System.Drawing.Point(73, 147);
            this.txtKurs.Name = "txtKurs";
            this.txtKurs.Size = new System.Drawing.Size(270, 20);
            this.txtKurs.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Kurs";
            // 
            // txtedu_type
            // 
            this.txtedu_type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtedu_type.Location = new System.Drawing.Point(73, 121);
            this.txtedu_type.Name = "txtedu_type";
            this.txtedu_type.Size = new System.Drawing.Size(270, 20);
            this.txtedu_type.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şöbə";
            // 
            // txttedris_il
            // 
            this.txttedris_il.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttedris_il.Location = new System.Drawing.Point(73, 95);
            this.txttedris_il.Name = "txttedris_il";
            this.txttedris_il.Size = new System.Drawing.Size(270, 20);
            this.txttedris_il.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tədris ili";
            // 
            // txtGender
            // 
            this.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGender.Location = new System.Drawing.Point(73, 69);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(270, 20);
            this.txtGender.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cinsiyyəti";
            // 
            // txtAtaAd
            // 
            this.txtAtaAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAtaAd.Location = new System.Drawing.Point(73, 43);
            this.txtAtaAd.Name = "txtAtaAd";
            this.txtAtaAd.Size = new System.Drawing.Size(270, 20);
            this.txtAtaAd.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ata adı";
            // 
            // checkEdit_print
            // 
            this.checkEdit_print.Location = new System.Drawing.Point(99, 174);
            this.checkEdit_print.Name = "checkEdit_print";
            this.checkEdit_print.Properties.Caption = "Print";
            this.checkEdit_print.Size = new System.Drawing.Size(46, 19);
            this.checkEdit_print.TabIndex = 130;
            this.checkEdit_print.CheckedChanged += new System.EventHandler(this.checkEdit_print_CheckedChanged);
            // 
            // spinEdit_print
            // 
            this.spinEdit_print.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_print.Enabled = false;
            this.spinEdit_print.Location = new System.Drawing.Point(152, 173);
            this.spinEdit_print.Name = "spinEdit_print";
            this.spinEdit_print.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.spinEdit_print.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEdit_print.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.spinEdit_print.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.spinEdit_print.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.spinEdit_print.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.spinEdit_print.Properties.IsFloatValue = false;
            this.spinEdit_print.Properties.Mask.EditMask = "\\d{1,9}";
            this.spinEdit_print.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEdit_print.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit_print.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.spinEdit_print.Size = new System.Drawing.Size(100, 22);
            this.spinEdit_print.TabIndex = 129;
            this.spinEdit_print.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.spinEdit_print_ButtonClick);
            // 
            // checkEdit_mezun
            // 
            this.checkEdit_mezun.Location = new System.Drawing.Point(99, 204);
            this.checkEdit_mezun.Name = "checkEdit_mezun";
            this.checkEdit_mezun.Properties.Caption = "Print";
            this.checkEdit_mezun.Size = new System.Drawing.Size(46, 19);
            this.checkEdit_mezun.TabIndex = 132;
            this.checkEdit_mezun.CheckedChanged += new System.EventHandler(this.checkEdit_mezun_CheckedChanged);
            // 
            // spinEdit_mezun
            // 
            this.spinEdit_mezun.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_mezun.Enabled = false;
            this.spinEdit_mezun.Location = new System.Drawing.Point(152, 203);
            this.spinEdit_mezun.Name = "spinEdit_mezun";
            this.spinEdit_mezun.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.spinEdit_mezun.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEdit_mezun.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.spinEdit_mezun.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.spinEdit_mezun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.spinEdit_mezun.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.spinEdit_mezun.Properties.IsFloatValue = false;
            this.spinEdit_mezun.Properties.Mask.EditMask = "\\d{1,9}";
            this.spinEdit_mezun.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEdit_mezun.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEdit_mezun.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.spinEdit_mezun.Size = new System.Drawing.Size(100, 22);
            this.spinEdit_mezun.TabIndex = 131;
            this.spinEdit_mezun.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.spinEdit_mezun_ButtonClick);
            // 
            // frmArayis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 261);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArayis";
            this.Text = "Arayış";
            this.Activated += new System.EventHandler(this.frmArayis_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmArayis_FormClosed);
            this.Load += new System.EventHandler(this.frmArayis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_print.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_print.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_mezun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_mezun.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKurs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtedu_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttedris_il;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAtaAd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbEN;
        private System.Windows.Forms.RadioButton rbTR;
        private System.Windows.Forms.RadioButton rbAZ;
        private System.Windows.Forms.Button btnMezun;
        private System.Windows.Forms.Button btnArayis;
        private DevExpress.XtraEditors.CheckEdit checkEdit_mezun;
        private DevExpress.XtraEditors.SpinEdit spinEdit_mezun;
        private DevExpress.XtraEditors.CheckEdit checkEdit_print;
        private DevExpress.XtraEditors.SpinEdit spinEdit_print;
    }
}