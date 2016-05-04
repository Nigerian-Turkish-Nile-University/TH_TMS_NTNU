namespace TMS.StudSearch
{
    partial class frmStudSEARCH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudSEARCH));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedCombo_class = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.checkedCombo_departments = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.txtSTUD_ID = new DevExpress.XtraEditors.TextEdit();
            this.image_stud = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combo_status = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEduTypeID = new System.Windows.Forms.ComboBox();
            this.cmbStudEduLevel = new System.Windows.Forms.ComboBox();
            this.txtATA_AD = new System.Windows.Forms.TextBox();
            this.txtSURNAME = new System.Windows.Forms.TextBox();
            this.txtNAME = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSTATUS = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar_images = new DevExpress.XtraEditors.ProgressBarControl();
            this.dgvSTUD_MAIN = new System.Windows.Forms.DataGridView();
            this.btnSEC = new System.Windows.Forms.Button();
            this.btnLegvEt = new System.Windows.Forms.Button();
            this.button_images = new DevExpress.XtraEditors.SimpleButton();
            this.folderBrowser_images = new System.Windows.Forms.FolderBrowserDialog();
            this.timer_images = new System.Windows.Forms.Timer(this.components);
            this.STUD_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colclass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qerar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDU_YEAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROG_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_class.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_departments.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTUD_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_stud)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar_images.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTUD_MAIN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkedCombo_class);
            this.groupBox1.Controls.Add(this.checkedCombo_departments);
            this.groupBox1.Controls.Add(this.txtSTUD_ID);
            this.groupBox1.Controls.Add(this.image_stud);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.combo_status);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbEduTypeID);
            this.groupBox1.Controls.Add(this.cmbStudEduLevel);
            this.groupBox1.Controls.Add(this.txtATA_AD);
            this.groupBox1.Controls.Add(this.txtSURNAME);
            this.groupBox1.Controls.Add(this.txtNAME);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbSTATUS);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // checkedCombo_class
            // 
            this.checkedCombo_class.EditValue = "";
            this.checkedCombo_class.Location = new System.Drawing.Point(346, 19);
            this.checkedCombo_class.Name = "checkedCombo_class";
            this.checkedCombo_class.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_class.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("0", "PREPARATION CLASS"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("1", "1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("2", "2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("3", "3"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("4", "4"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5", "5")});
            this.checkedCombo_class.Properties.NullText = "All Classes";
            this.checkedCombo_class.Properties.NullValuePrompt = "All Classes";
            this.checkedCombo_class.Properties.NullValuePromptShowForEmptyValue = true;
            this.checkedCombo_class.Properties.PopupFormMinSize = new System.Drawing.Size(156, 125);
            this.checkedCombo_class.Properties.PopupFormSize = new System.Drawing.Size(125, 130);
            this.checkedCombo_class.Size = new System.Drawing.Size(156, 20);
            this.checkedCombo_class.TabIndex = 27;
            this.checkedCombo_class.EditValueChanged += new System.EventHandler(this.checkedCombo_class_EditValueChanged);
            // 
            // checkedCombo_departments
            // 
            this.checkedCombo_departments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedCombo_departments.EditValue = "";
            this.checkedCombo_departments.Location = new System.Drawing.Point(67, 129);
            this.checkedCombo_departments.Name = "checkedCombo_departments";
            this.checkedCombo_departments.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedCombo_departments.Properties.DropDownRows = 20;
            this.checkedCombo_departments.Properties.NullText = "All Departments";
            this.checkedCombo_departments.Properties.NullValuePrompt = "All Departments";
            this.checkedCombo_departments.Properties.PopupFormMinSize = new System.Drawing.Size(435, 200);
            this.checkedCombo_departments.Size = new System.Drawing.Size(435, 20);
            this.checkedCombo_departments.TabIndex = 26;
            this.checkedCombo_departments.Popup += new System.EventHandler(this.OnPopup);
            this.checkedCombo_departments.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.checkedCombo_departments_CloseUp);
            this.checkedCombo_departments.EditValueChanged += new System.EventHandler(this.checkedCombo_departments_EditValueChanged);
            this.checkedCombo_departments.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.checkedCombo_departments_CustomDisplayText);
            this.checkedCombo_departments.Resize += new System.EventHandler(this.checkedCombo_departments_Resize);
            // 
            // txtSTUD_ID
            // 
            this.txtSTUD_ID.Location = new System.Drawing.Point(67, 19);
            this.txtSTUD_ID.Name = "txtSTUD_ID";
            this.txtSTUD_ID.Properties.Mask.EditMask = "\\d{1,9}";
            this.txtSTUD_ID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSTUD_ID.Size = new System.Drawing.Size(180, 20);
            this.txtSTUD_ID.TabIndex = 0;
            this.txtSTUD_ID.EditValueChanged += new System.EventHandler(this.txtSTUD_ID_EditValueChanged);
            this.txtSTUD_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSTUD_ID_KeyDown);
            // 
            // image_stud
            // 
            this.image_stud.Image = global::TMS.Properties.Resources.no_foto;
            this.image_stud.InitialImage = null;
            this.image_stud.Location = new System.Drawing.Point(515, 19);
            this.image_stud.Name = "image_stud";
            this.image_stud.Size = new System.Drawing.Size(98, 130);
            this.image_stud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_stud.TabIndex = 25;
            this.image_stud.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(302, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 14);
            this.label11.TabIndex = 24;
            this.label11.Text = "Status";
            // 
            // combo_status
            // 
            this.combo_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_status.FormattingEnabled = true;
            this.combo_status.Location = new System.Drawing.Point(346, 45);
            this.combo_status.Name = "combo_status";
            this.combo_status.Size = new System.Drawing.Size(156, 22);
            this.combo_status.TabIndex = 5;
            this.combo_status.SelectionChangeCommitted += new System.EventHandler(this.combo_status_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 14);
            this.label7.TabIndex = 22;
            this.label7.Text = "Type / Level";
            // 
            // cmbEduTypeID
            // 
            this.cmbEduTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEduTypeID.FormattingEnabled = true;
            this.cmbEduTypeID.Location = new System.Drawing.Point(346, 101);
            this.cmbEduTypeID.Name = "cmbEduTypeID";
            this.cmbEduTypeID.Size = new System.Drawing.Size(75, 22);
            this.cmbEduTypeID.TabIndex = 7;
            this.cmbEduTypeID.SelectionChangeCommitted += new System.EventHandler(this.combo_status_SelectionChangeCommitted);
            // 
            // cmbStudEduLevel
            // 
            this.cmbStudEduLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudEduLevel.FormattingEnabled = true;
            this.cmbStudEduLevel.Location = new System.Drawing.Point(427, 101);
            this.cmbStudEduLevel.Name = "cmbStudEduLevel";
            this.cmbStudEduLevel.Size = new System.Drawing.Size(75, 22);
            this.cmbStudEduLevel.TabIndex = 8;
            this.cmbStudEduLevel.SelectionChangeCommitted += new System.EventHandler(this.cmbStudEduLevel_SelectionChangeCommitted);
            // 
            // txtATA_AD
            // 
            this.txtATA_AD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtATA_AD.Location = new System.Drawing.Point(67, 103);
            this.txtATA_AD.Name = "txtATA_AD";
            this.txtATA_AD.Size = new System.Drawing.Size(180, 20);
            this.txtATA_AD.TabIndex = 3;
            this.txtATA_AD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNAME_KeyDown);
            // 
            // txtSURNAME
            // 
            this.txtSURNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSURNAME.Location = new System.Drawing.Point(67, 75);
            this.txtSURNAME.Name = "txtSURNAME";
            this.txtSURNAME.Size = new System.Drawing.Size(180, 20);
            this.txtSURNAME.TabIndex = 2;
            this.txtSURNAME.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNAME_KeyDown);
            // 
            // txtNAME
            // 
            this.txtNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNAME.Location = new System.Drawing.Point(67, 47);
            this.txtNAME.Name = "txtNAME";
            this.txtNAME.Size = new System.Drawing.Size(180, 20);
            this.txtNAME.TabIndex = 1;
            this.txtNAME.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNAME_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "Father";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Surname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "Student №";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "Decision";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Class";
            // 
            // cmbSTATUS
            // 
            this.cmbSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSTATUS.FormattingEnabled = true;
            this.cmbSTATUS.Location = new System.Drawing.Point(346, 73);
            this.cmbSTATUS.Name = "cmbSTATUS";
            this.cmbSTATUS.Size = new System.Drawing.Size(156, 22);
            this.cmbSTATUS.TabIndex = 6;
            this.cmbSTATUS.SelectionChangeCommitted += new System.EventHandler(this.combo_status_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 14);
            this.label10.TabIndex = 18;
            this.label10.Text = "Department";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar_images);
            this.groupBox2.Controls.Add(this.dgvSTUD_MAIN);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 194);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Student List";
            // 
            // progressBar_images
            // 
            this.progressBar_images.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar_images.Location = new System.Drawing.Point(3, 173);
            this.progressBar_images.Name = "progressBar_images";
            this.progressBar_images.Properties.PercentView = false;
            this.progressBar_images.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.progressBar_images.Properties.ShowTitle = true;
            this.progressBar_images.Properties.Step = 1;
            this.progressBar_images.Size = new System.Drawing.Size(614, 18);
            this.progressBar_images.TabIndex = 1;
            this.progressBar_images.Visible = false;
            // 
            // dgvSTUD_MAIN
            // 
            this.dgvSTUD_MAIN.AllowUserToAddRows = false;
            this.dgvSTUD_MAIN.AllowUserToDeleteRows = false;
            this.dgvSTUD_MAIN.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSTUD_MAIN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSTUD_MAIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSTUD_MAIN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STUD_ID,
            this.name,
            this.surname,
            this.colclass,
            this.STATUS,
            this.qerar,
            this.EDU_YEAR,
            this.PROG_CODE});
            this.dgvSTUD_MAIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSTUD_MAIN.Location = new System.Drawing.Point(3, 16);
            this.dgvSTUD_MAIN.MultiSelect = false;
            this.dgvSTUD_MAIN.Name = "dgvSTUD_MAIN";
            this.dgvSTUD_MAIN.ReadOnly = true;
            this.dgvSTUD_MAIN.RowHeadersWidth = 10;
            this.dgvSTUD_MAIN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSTUD_MAIN.Size = new System.Drawing.Size(614, 175);
            this.dgvSTUD_MAIN.TabIndex = 0;
            this.dgvSTUD_MAIN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSTUD_MAIN_CellDoubleClick);
            this.dgvSTUD_MAIN.SelectionChanged += new System.EventHandler(this.dgvSTUD_MAIN_SelectionChanged);
            this.dgvSTUD_MAIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSTUD_MAIN_KeyDown);
            // 
            // btnSEC
            // 
            this.btnSEC.Enabled = false;
            this.btnSEC.Location = new System.Drawing.Point(476, 389);
            this.btnSEC.Name = "btnSEC";
            this.btnSEC.Size = new System.Drawing.Size(75, 23);
            this.btnSEC.TabIndex = 2;
            this.btnSEC.Text = "OK";
            this.btnSEC.UseVisualStyleBackColor = true;
            this.btnSEC.Click += new System.EventHandler(this.btnSEC_Click);
            // 
            // btnLegvEt
            // 
            this.btnLegvEt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLegvEt.Location = new System.Drawing.Point(557, 389);
            this.btnLegvEt.Name = "btnLegvEt";
            this.btnLegvEt.Size = new System.Drawing.Size(75, 23);
            this.btnLegvEt.TabIndex = 3;
            this.btnLegvEt.Text = "Cancel";
            this.btnLegvEt.UseVisualStyleBackColor = true;
            this.btnLegvEt.Click += new System.EventHandler(this.btnLegvEt_Click);
            // 
            // button_images
            // 
            this.button_images.Enabled = false;
            this.button_images.Location = new System.Drawing.Point(12, 389);
            this.button_images.Name = "button_images";
            this.button_images.Size = new System.Drawing.Size(118, 23);
            this.button_images.TabIndex = 4;
            this.button_images.Text = "Save photos to HDD";
            this.button_images.Visible = false;
            this.button_images.Click += new System.EventHandler(this.button_images_Click);
            // 
            // timer_images
            // 
            this.timer_images.Interval = 50;
            this.timer_images.Tick += new System.EventHandler(this.timer_images_Tick);
            // 
            // STUD_ID
            // 
            this.STUD_ID.DataPropertyName = "STUD_ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.STUD_ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.STUD_ID.HeaderText = "Stud №";
            this.STUD_ID.Name = "STUD_ID";
            this.STUD_ID.ReadOnly = true;
            this.STUD_ID.Width = 80;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // surname
            // 
            this.surname.DataPropertyName = "surname";
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            this.surname.Width = 110;
            // 
            // colclass
            // 
            this.colclass.DataPropertyName = "class";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colclass.DefaultCellStyle = dataGridViewCellStyle3;
            this.colclass.HeaderText = "Class";
            this.colclass.Name = "colclass";
            this.colclass.ReadOnly = true;
            this.colclass.Width = 45;
            // 
            // STATUS
            // 
            this.STATUS.DataPropertyName = "STATUS";
            this.STATUS.HeaderText = "STATUS";
            this.STATUS.Name = "STATUS";
            this.STATUS.ReadOnly = true;
            this.STATUS.Width = 80;
            // 
            // qerar
            // 
            this.qerar.DataPropertyName = "QERAR";
            this.qerar.HeaderText = "Decision";
            this.qerar.Name = "qerar";
            this.qerar.ReadOnly = true;
            this.qerar.Width = 110;
            // 
            // EDU_YEAR
            // 
            this.EDU_YEAR.DataPropertyName = "prog_year";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EDU_YEAR.DefaultCellStyle = dataGridViewCellStyle4;
            this.EDU_YEAR.HeaderText = "CurriculumYear";
            this.EDU_YEAR.Name = "EDU_YEAR";
            this.EDU_YEAR.ReadOnly = true;
            this.EDU_YEAR.Visible = false;
            // 
            // PROG_CODE
            // 
            this.PROG_CODE.DataPropertyName = "PROG_CODE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PROG_CODE.DefaultCellStyle = dataGridViewCellStyle5;
            this.PROG_CODE.HeaderText = "PROG_CODE";
            this.PROG_CODE.Name = "PROG_CODE";
            this.PROG_CODE.ReadOnly = true;
            this.PROG_CODE.Width = 75;
            // 
            // frmStudSEARCH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 426);
            this.Controls.Add(this.button_images);
            this.Controls.Add(this.btnLegvEt);
            this.Controls.Add(this.btnSEC);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(598, 456);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 600);
            this.MinimizeBox = false;
            this.Name = "frmStudSEARCH";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Student";
            this.Load += new System.EventHandler(this.frmStudSEARCH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_class.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedCombo_departments.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTUD_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_stud)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar_images.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSTUD_MAIN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSTATUS;
        private System.Windows.Forms.TextBox txtSURNAME;
        private System.Windows.Forms.TextBox txtNAME;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtATA_AD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStudEduLevel;
        private System.Windows.Forms.ComboBox cmbEduTypeID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSEC;
        private System.Windows.Forms.Button btnLegvEt;
        public System.Windows.Forms.DataGridView dgvSTUD_MAIN;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox combo_status;
        public System.Windows.Forms.PictureBox image_stud;
        private DevExpress.XtraEditors.TextEdit txtSTUD_ID;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser_images;
        private System.Windows.Forms.Timer timer_images;
        public DevExpress.XtraEditors.SimpleButton button_images;
        public DevExpress.XtraEditors.ProgressBarControl progressBar_images;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_departments;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedCombo_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUD_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colclass;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn qerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDU_YEAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROG_CODE;
    }
}