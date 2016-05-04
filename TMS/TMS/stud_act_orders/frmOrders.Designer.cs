namespace TMS.stud_act_orders
{
    partial class frmOrders
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
            this.gbData = new System.Windows.Forms.GroupBox();
            this.ckHamisi = new System.Windows.Forms.CheckBox();
            this.lQalanSinvolSayi = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dtpDecDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDecContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrderType = new System.Windows.Forms.TextBox();
            this.txtDecSbj = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDecNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gcDecision = new DevExpress.XtraGrid.GridControl();
            this.gvDecision = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDECISION_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcACTION_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSTUD_ACTION_TITLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDECISION_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDECISION_SUBJECT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDECISION_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDECISION_CONTENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOper = new System.Windows.Forms.Button();
            this.Btnsec = new System.Windows.Forms.Button();
            this.rbAdd = new System.Windows.Forms.RadioButton();
            this.rbChange = new System.Windows.Forms.RadioButton();
            this.rbDel = new System.Windows.Forms.RadioButton();
            this.gbData.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDecision)).BeginInit();
            this.SuspendLayout();
            // 
            // gbData
            // 
            this.gbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbData.Controls.Add(this.ckHamisi);
            this.gbData.Controls.Add(this.lQalanSinvolSayi);
            this.gbData.Controls.Add(this.progressBar1);
            this.gbData.Controls.Add(this.dtpDecDate);
            this.gbData.Controls.Add(this.label1);
            this.gbData.Controls.Add(this.label2);
            this.gbData.Controls.Add(this.txtDecContent);
            this.gbData.Controls.Add(this.label3);
            this.gbData.Controls.Add(this.txtOrderType);
            this.gbData.Controls.Add(this.txtDecSbj);
            this.gbData.Controls.Add(this.label4);
            this.gbData.Controls.Add(this.txtDecNo);
            this.gbData.Location = new System.Drawing.Point(12, 12);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(568, 255);
            this.gbData.TabIndex = 21;
            this.gbData.TabStop = false;
            // 
            // ckHamisi
            // 
            this.ckHamisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckHamisi.AutoSize = true;
            this.ckHamisi.Location = new System.Drawing.Point(431, 21);
            this.ckHamisi.Name = "ckHamisi";
            this.ckHamisi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckHamisi.Size = new System.Drawing.Size(72, 18);
            this.ckHamisi.TabIndex = 4;
            this.ckHamisi.Text = "decisions";
            this.ckHamisi.UseVisualStyleBackColor = true;
            this.ckHamisi.CheckedChanged += new System.EventHandler(this.ckHamisi_CheckedChanged);
            // 
            // lQalanSinvolSayi
            // 
            this.lQalanSinvolSayi.AutoSize = true;
            this.lQalanSinvolSayi.Location = new System.Drawing.Point(43, 224);
            this.lQalanSinvolSayi.Name = "lQalanSinvolSayi";
            this.lQalanSinvolSayi.Size = new System.Drawing.Size(85, 14);
            this.lQalanSinvolSayi.TabIndex = 34;
            this.lQalanSinvolSayi.Text = "Max. char: 2000";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(134, 224);
            this.progressBar1.Maximum = 2000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(372, 18);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 33;
            // 
            // dtpDecDate
            // 
            this.dtpDecDate.CustomFormat = "d-MM-yyyy";
            this.dtpDecDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDecDate.Location = new System.Drawing.Point(134, 19);
            this.dtpDecDate.Name = "dtpDecDate";
            this.dtpDecDate.Size = new System.Drawing.Size(154, 20);
            this.dtpDecDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 27;
            this.label1.Text = "Decision №";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "Subject";
            // 
            // txtDecContent
            // 
            this.txtDecContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDecContent.Location = new System.Drawing.Point(134, 125);
            this.txtDecContent.MaxLength = 2000;
            this.txtDecContent.Multiline = true;
            this.txtDecContent.Name = "txtDecContent";
            this.txtDecContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDecContent.Size = new System.Drawing.Size(372, 97);
            this.txtDecContent.TabIndex = 3;
            this.txtDecContent.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "Order Type";
            // 
            // txtOrderType
            // 
            this.txtOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderType.Location = new System.Drawing.Point(134, 97);
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.ReadOnly = true;
            this.txtOrderType.Size = new System.Drawing.Size(372, 20);
            this.txtOrderType.TabIndex = 28;
            this.txtOrderType.Tag = "0";
            // 
            // txtDecSbj
            // 
            this.txtDecSbj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecSbj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDecSbj.Location = new System.Drawing.Point(134, 71);
            this.txtDecSbj.Name = "txtDecSbj";
            this.txtDecSbj.Size = new System.Drawing.Size(372, 20);
            this.txtDecSbj.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "Decision Date";
            // 
            // txtDecNo
            // 
            this.txtDecNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDecNo.Location = new System.Drawing.Point(134, 45);
            this.txtDecNo.Name = "txtDecNo";
            this.txtDecNo.Size = new System.Drawing.Size(372, 20);
            this.txtDecNo.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.gcDecision);
            this.groupBox2.Location = new System.Drawing.Point(12, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 257);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // gcDecision
            // 
            this.gcDecision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDecision.Location = new System.Drawing.Point(3, 16);
            this.gcDecision.MainView = this.gvDecision;
            this.gcDecision.Name = "gcDecision";
            this.gcDecision.Size = new System.Drawing.Size(562, 238);
            this.gcDecision.TabIndex = 0;
            this.gcDecision.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDecision});
            // 
            // gvDecision
            // 
            this.gvDecision.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDecision.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvDecision.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDECISION_ID,
            this.gcACTION_ID,
            this.gcSTUD_ACTION_TITLE,
            this.gcDECISION_NO,
            this.gcDECISION_SUBJECT,
            this.gcDECISION_DATE,
            this.gcDECISION_CONTENT});
            this.gvDecision.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvDecision.GridControl = this.gcDecision;
            this.gvDecision.Name = "gvDecision";
            this.gvDecision.OptionsBehavior.Editable = false;
            this.gvDecision.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gvDecision.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gvDecision.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gvDecision.OptionsView.ShowAutoFilterRow = true;
            this.gvDecision.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDecision_FocusedRowChanged);
            this.gvDecision.DoubleClick += new System.EventHandler(this.gvDecision_DoubleClick);
            // 
            // gcDECISION_ID
            // 
            this.gcDECISION_ID.Caption = "DECISION_ID";
            this.gcDECISION_ID.FieldName = "DECISION_ID";
            this.gcDECISION_ID.Name = "gcDECISION_ID";
            this.gcDECISION_ID.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // gcACTION_ID
            // 
            this.gcACTION_ID.Caption = "ACTION_ID";
            this.gcACTION_ID.FieldName = "ACTION_ID";
            this.gcACTION_ID.Name = "gcACTION_ID";
            this.gcACTION_ID.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            // 
            // gcSTUD_ACTION_TITLE
            // 
            this.gcSTUD_ACTION_TITLE.Caption = "Order Type";
            this.gcSTUD_ACTION_TITLE.FieldName = "STUD_ACTION_TITLE";
            this.gcSTUD_ACTION_TITLE.Name = "gcSTUD_ACTION_TITLE";
            this.gcSTUD_ACTION_TITLE.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcSTUD_ACTION_TITLE.Visible = true;
            this.gcSTUD_ACTION_TITLE.VisibleIndex = 0;
            // 
            // gcDECISION_NO
            // 
            this.gcDECISION_NO.Caption = "Decision №";
            this.gcDECISION_NO.FieldName = "DECISION_NO";
            this.gcDECISION_NO.Name = "gcDECISION_NO";
            this.gcDECISION_NO.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcDECISION_NO.Visible = true;
            this.gcDECISION_NO.VisibleIndex = 1;
            // 
            // gcDECISION_SUBJECT
            // 
            this.gcDECISION_SUBJECT.Caption = "SUBJECT";
            this.gcDECISION_SUBJECT.FieldName = "DECISION_SUBJECT";
            this.gcDECISION_SUBJECT.Name = "gcDECISION_SUBJECT";
            this.gcDECISION_SUBJECT.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcDECISION_SUBJECT.Visible = true;
            this.gcDECISION_SUBJECT.VisibleIndex = 2;
            // 
            // gcDECISION_DATE
            // 
            this.gcDECISION_DATE.Caption = "DATE";
            this.gcDECISION_DATE.DisplayFormat.FormatString = "d-MM-yyyy";
            this.gcDECISION_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcDECISION_DATE.FieldName = "DECISION_DATE";
            this.gcDECISION_DATE.Name = "gcDECISION_DATE";
            this.gcDECISION_DATE.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gcDECISION_DATE.Visible = true;
            this.gcDECISION_DATE.VisibleIndex = 3;
            // 
            // gcDECISION_CONTENT
            // 
            this.gcDECISION_CONTENT.Caption = "CONTENT";
            this.gcDECISION_CONTENT.FieldName = "DECISION_CONTENT";
            this.gcDECISION_CONTENT.Name = "gcDECISION_CONTENT";
            this.gcDECISION_CONTENT.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gcDECISION_CONTENT.Visible = true;
            this.gcDECISION_CONTENT.VisibleIndex = 4;
            // 
            // btnOper
            // 
            this.btnOper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOper.Location = new System.Drawing.Point(425, 536);
            this.btnOper.Name = "btnOper";
            this.btnOper.Size = new System.Drawing.Size(75, 25);
            this.btnOper.TabIndex = 24;
            this.btnOper.Text = "ADD";
            this.btnOper.UseVisualStyleBackColor = true;
            this.btnOper.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Btnsec
            // 
            this.Btnsec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btnsec.Location = new System.Drawing.Point(506, 536);
            this.Btnsec.Name = "Btnsec";
            this.Btnsec.Size = new System.Drawing.Size(75, 25);
            this.Btnsec.TabIndex = 25;
            this.Btnsec.Text = "OK";
            this.Btnsec.UseVisualStyleBackColor = true;
            this.Btnsec.Click += new System.EventHandler(this.Btnsec_Click);
            // 
            // rbAdd
            // 
            this.rbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbAdd.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAdd.AutoSize = true;
            this.rbAdd.Checked = true;
            this.rbAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbAdd.Location = new System.Drawing.Point(12, 542);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(54, 19);
            this.rbAdd.TabIndex = 35;
            this.rbAdd.TabStop = true;
            this.rbAdd.Text = "New";
            this.rbAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAdd.UseVisualStyleBackColor = true;
            this.rbAdd.CheckedChanged += new System.EventHandler(this.rbAdd_CheckedChanged);
            // 
            // rbChange
            // 
            this.rbChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbChange.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbChange.AutoSize = true;
            this.rbChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbChange.Location = new System.Drawing.Point(71, 542);
            this.rbChange.Name = "rbChange";
            this.rbChange.Size = new System.Drawing.Size(68, 19);
            this.rbChange.TabIndex = 35;
            this.rbChange.Text = "Change";
            this.rbChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbChange.UseVisualStyleBackColor = true;
            this.rbChange.CheckedChanged += new System.EventHandler(this.rdChange_CheckedChanged);
            // 
            // rbDel
            // 
            this.rbDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbDel.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDel.AutoSize = true;
            this.rbDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbDel.Location = new System.Drawing.Point(147, 542);
            this.rbDel.Name = "rbDel";
            this.rbDel.Size = new System.Drawing.Size(61, 19);
            this.rbDel.TabIndex = 35;
            this.rbDel.Text = "Delete";
            this.rbDel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDel.UseVisualStyleBackColor = true;
            this.rbDel.CheckedChanged += new System.EventHandler(this.rbDel_CheckedChanged);
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 573);
            this.Controls.Add(this.rbDel);
            this.Controls.Add(this.Btnsec);
            this.Controls.Add(this.rbChange);
            this.Controls.Add(this.btnOper);
            this.Controls.Add(this.rbAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbData);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Decisions";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDecision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.Label lQalanSinvolSayi;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DateTimePicker dtpDecDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDecContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDecSbj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDecNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOper;
        private System.Windows.Forms.Button Btnsec;
        public System.Windows.Forms.TextBox txtOrderType;
        private System.Windows.Forms.RadioButton rbDel;
        private System.Windows.Forms.RadioButton rbChange;
        private System.Windows.Forms.RadioButton rbAdd;
        private System.Windows.Forms.CheckBox ckHamisi;
        private DevExpress.XtraGrid.Columns.GridColumn gcDECISION_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gcACTION_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gcSTUD_ACTION_TITLE;
        private DevExpress.XtraGrid.Columns.GridColumn gcDECISION_NO;
        private DevExpress.XtraGrid.Columns.GridColumn gcDECISION_SUBJECT;
        private DevExpress.XtraGrid.Columns.GridColumn gcDECISION_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn gcDECISION_CONTENT;
        public DevExpress.XtraGrid.Views.Grid.GridView gvDecision;
        private DevExpress.XtraGrid.GridControl gcDecision;
    }
}