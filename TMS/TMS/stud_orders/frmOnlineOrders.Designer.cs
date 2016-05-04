namespace TMS.stud_orders
{
    partial class frmOnlineOrders
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
            this.gcOrders = new DevExpress.XtraGrid.GridControl();
            this.gvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvOrdersColDocOrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOrdersColDocId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOrdersColStudId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOrdersColAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOrdersColOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOrdersColOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOrdersColOrderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcSifaris = new DevExpress.XtraEditors.GroupControl();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.txtStudID = new DevExpress.XtraEditors.TextEdit();
            this.memoUserAddr = new DevExpress.XtraEditors.MemoExEdit();
            this.btnSifarisHazir = new DevExpress.XtraEditors.SimpleButton();
            this.lblDocTitle = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblDocLang = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblDeliveryMethod = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblAmount = new DevExpress.XtraEditors.LabelControl();
            this.lblStudName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSifaris)).BeginInit();
            this.gcSifaris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoUserAddr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcOrders
            // 
            this.gcOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcOrders.Location = new System.Drawing.Point(3, 181);
            this.gcOrders.MainView = this.gvOrders;
            this.gcOrders.Name = "gcOrders";
            this.gcOrders.Size = new System.Drawing.Size(633, 310);
            this.gcOrders.TabIndex = 0;
            this.gcOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOrders});
            // 
            // gvOrders
            // 
            this.gvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvOrdersColDocOrderId,
            this.gvOrdersColDocId,
            this.gvOrdersColStudId,
            this.gvOrdersColAmount,
            this.gvOrdersColOrder,
            this.gvOrdersColOrderDate,
            this.gvOrdersColOrderStatus});
            this.gvOrders.GridControl = this.gcOrders;
            this.gvOrders.Name = "gvOrders";
            this.gvOrders.OptionsBehavior.Editable = false;
            this.gvOrders.OptionsBehavior.ReadOnly = true;
            this.gvOrders.OptionsView.ShowGroupPanel = false;
            this.gvOrders.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvOrders_FocusedRowChanged);
            // 
            // gvOrdersColDocOrderId
            // 
            this.gvOrdersColDocOrderId.Caption = "DOC_ORDER_ID";
            this.gvOrdersColDocOrderId.FieldName = "DOC_ORDER_ID";
            this.gvOrdersColDocOrderId.Name = "gvOrdersColDocOrderId";
            // 
            // gvOrdersColDocId
            // 
            this.gvOrdersColDocId.AppearanceCell.Options.UseTextOptions = true;
            this.gvOrdersColDocId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvOrdersColDocId.Caption = "DOC_ID";
            this.gvOrdersColDocId.FieldName = "DOC_ID";
            this.gvOrdersColDocId.Name = "gvOrdersColDocId";
            this.gvOrdersColDocId.OptionsColumn.FixedWidth = true;
            this.gvOrdersColDocId.Width = 50;
            // 
            // gvOrdersColStudId
            // 
            this.gvOrdersColStudId.AppearanceCell.Options.UseTextOptions = true;
            this.gvOrdersColStudId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvOrdersColStudId.Caption = "Student №";
            this.gvOrdersColStudId.FieldName = "STUD_ID";
            this.gvOrdersColStudId.Name = "gvOrdersColStudId";
            this.gvOrdersColStudId.OptionsColumn.FixedWidth = true;
            this.gvOrdersColStudId.Visible = true;
            this.gvOrdersColStudId.VisibleIndex = 0;
            this.gvOrdersColStudId.Width = 65;
            // 
            // gvOrdersColAmount
            // 
            this.gvOrdersColAmount.AppearanceCell.Options.UseTextOptions = true;
            this.gvOrdersColAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvOrdersColAmount.Caption = "Amount";
            this.gvOrdersColAmount.FieldName = "PAYMENT";
            this.gvOrdersColAmount.Name = "gvOrdersColAmount";
            this.gvOrdersColAmount.OptionsColumn.FixedWidth = true;
            this.gvOrdersColAmount.Visible = true;
            this.gvOrdersColAmount.VisibleIndex = 1;
            this.gvOrdersColAmount.Width = 70;
            // 
            // gvOrdersColOrder
            // 
            this.gvOrdersColOrder.Caption = "Document";
            this.gvOrdersColOrder.FieldName = "DOC_TITLE";
            this.gvOrdersColOrder.Name = "gvOrdersColOrder";
            this.gvOrdersColOrder.Visible = true;
            this.gvOrdersColOrder.VisibleIndex = 2;
            this.gvOrdersColOrder.Width = 260;
            // 
            // gvOrdersColOrderDate
            // 
            this.gvOrdersColOrderDate.AppearanceCell.Options.UseTextOptions = true;
            this.gvOrdersColOrderDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvOrdersColOrderDate.Caption = "Date";
            this.gvOrdersColOrderDate.FieldName = "ORDER_DATE";
            this.gvOrdersColOrderDate.Name = "gvOrdersColOrderDate";
            this.gvOrdersColOrderDate.OptionsColumn.FixedWidth = true;
            this.gvOrdersColOrderDate.Visible = true;
            this.gvOrdersColOrderDate.VisibleIndex = 3;
            this.gvOrdersColOrderDate.Width = 100;
            // 
            // gvOrdersColOrderStatus
            // 
            this.gvOrdersColOrderStatus.AppearanceCell.Options.UseTextOptions = true;
            this.gvOrdersColOrderStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvOrdersColOrderStatus.Caption = "STATUS";
            this.gvOrdersColOrderStatus.FieldName = "ORDER_STATUS";
            this.gvOrdersColOrderStatus.Name = "gvOrdersColOrderStatus";
            this.gvOrdersColOrderStatus.Visible = true;
            this.gvOrdersColOrderStatus.VisibleIndex = 4;
            this.gvOrdersColOrderStatus.Width = 120;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.EditValue = "Aktiv sifarişlər";
            this.cmbStatus.Location = new System.Drawing.Point(534, 158);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStatus.Properties.Items.AddRange(new object[] {
            "Aktiv sifarişlər",
            "Hazırlananlar",
            "Ləğv olunanlar"});
            this.cmbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbStatus.Size = new System.Drawing.Size(100, 20);
            this.cmbStatus.TabIndex = 2;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // gcSifaris
            // 
            this.gcSifaris.Controls.Add(this.btnCancelOrder);
            this.gcSifaris.Controls.Add(this.txtStudID);
            this.gcSifaris.Controls.Add(this.memoUserAddr);
            this.gcSifaris.Controls.Add(this.btnSifarisHazir);
            this.gcSifaris.Controls.Add(this.lblDocTitle);
            this.gcSifaris.Controls.Add(this.labelControl2);
            this.gcSifaris.Controls.Add(this.labelControl3);
            this.gcSifaris.Controls.Add(this.lblDocLang);
            this.gcSifaris.Controls.Add(this.labelControl4);
            this.gcSifaris.Controls.Add(this.lblDeliveryMethod);
            this.gcSifaris.Controls.Add(this.labelControl5);
            this.gcSifaris.Controls.Add(this.labelControl1);
            this.gcSifaris.Controls.Add(this.lblAmount);
            this.gcSifaris.Controls.Add(this.lblStudName);
            this.gcSifaris.Location = new System.Drawing.Point(8, 8);
            this.gcSifaris.Name = "gcSifaris";
            this.gcSifaris.ShowCaption = false;
            this.gcSifaris.Size = new System.Drawing.Size(625, 145);
            this.gcSifaris.TabIndex = 3;
            this.gcSifaris.Text = "Onlayn Sifariş";
            this.gcSifaris.Visible = false;
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.BackColor = System.Drawing.Color.Red;
            this.btnCancelOrder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelOrder.ForeColor = System.Drawing.Color.White;
            this.btnCancelOrder.Location = new System.Drawing.Point(526, 4);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(71, 26);
            this.btnCancelOrder.TabIndex = 6;
            this.btnCancelOrder.Text = "Reject";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // txtStudID
            // 
            this.txtStudID.EditValue = "";
            this.txtStudID.Location = new System.Drawing.Point(123, 58);
            this.txtStudID.Name = "txtStudID";
            this.txtStudID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtStudID.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtStudID.Properties.Appearance.Options.UseFont = true;
            this.txtStudID.Properties.Appearance.Options.UseForeColor = true;
            this.txtStudID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtStudID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtStudID.Properties.ReadOnly = true;
            this.txtStudID.Size = new System.Drawing.Size(94, 22);
            this.txtStudID.TabIndex = 5;
            this.txtStudID.TabStop = false;
            // 
            // memoUserAddr
            // 
            this.memoUserAddr.Location = new System.Drawing.Point(123, 111);
            this.memoUserAddr.Name = "memoUserAddr";
            this.memoUserAddr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.memoUserAddr.Size = new System.Drawing.Size(35, 20);
            this.memoUserAddr.TabIndex = 3;
            // 
            // btnSifarisHazir
            // 
            this.btnSifarisHazir.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSifarisHazir.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSifarisHazir.Appearance.Options.UseFont = true;
            this.btnSifarisHazir.Appearance.Options.UseForeColor = true;
            this.btnSifarisHazir.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.btnSifarisHazir.Location = new System.Drawing.Point(444, 73);
            this.btnSifarisHazir.Name = "btnSifarisHazir";
            this.btnSifarisHazir.Size = new System.Drawing.Size(162, 48);
            this.btnSifarisHazir.TabIndex = 1;
            this.btnSifarisHazir.Text = "Order is Ready";
            this.btnSifarisHazir.Click += new System.EventHandler(this.btnSifarisHazir_Click);
            // 
            // lblDocTitle
            // 
            this.lblDocTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblDocTitle.Location = new System.Drawing.Point(123, 10);
            this.lblDocTitle.Name = "lblDocTitle";
            this.lblDocTitle.Size = new System.Drawing.Size(36, 16);
            this.lblDocTitle.TabIndex = 0;
            this.lblDocTitle.Text = "Sened";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.Location = new System.Drawing.Point(9, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(113, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Ordered document: ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Location = new System.Drawing.Point(61, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Language: ";
            // 
            // lblDocLang
            // 
            this.lblDocLang.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocLang.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblDocLang.Location = new System.Drawing.Point(123, 34);
            this.lblDocLang.Name = "lblDocLang";
            this.lblDocLang.Size = new System.Drawing.Size(14, 16);
            this.lblDocLang.TabIndex = 0;
            this.lblDocLang.Text = "Az";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl4.Location = new System.Drawing.Point(464, 42);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Paid amount: ";
            // 
            // lblDeliveryMethod
            // 
            this.lblDeliveryMethod.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryMethod.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblDeliveryMethod.Location = new System.Drawing.Point(123, 89);
            this.lblDeliveryMethod.Name = "lblDeliveryMethod";
            this.lblDeliveryMethod.Size = new System.Drawing.Size(78, 16);
            this.lblDeliveryMethod.TabIndex = 0;
            this.lblDeliveryMethod.Text = "Alınma üsulu:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl5.Location = new System.Drawing.Point(49, 90);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(68, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "How to get:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Location = new System.Drawing.Point(64, 62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Student: ";
            // 
            // lblAmount
            // 
            this.lblAmount.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblAmount.Location = new System.Drawing.Point(546, 41);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(37, 16);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Kimse";
            // 
            // lblStudName
            // 
            this.lblStudName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblStudName.Location = new System.Drawing.Point(232, 60);
            this.lblStudName.Name = "lblStudName";
            this.lblStudName.Size = new System.Drawing.Size(34, 16);
            this.lblStudName.TabIndex = 0;
            this.lblStudName.Text = "Kimse";
            // 
            // frmOnlineOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 495);
            this.Controls.Add(this.gcSifaris);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.gcOrders);
            this.MinimumSize = new System.Drawing.Size(508, 406);
            this.Name = "frmOnlineOrders";
            this.Text = "Online document orders";
            this.Load += new System.EventHandler(this.frmOnlineOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSifaris)).EndInit();
            this.gcSifaris.ResumeLayout(false);
            this.gcSifaris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoUserAddr.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOrders;
        private DevExpress.XtraGrid.Columns.GridColumn gvOrdersColDocOrderId;
        private DevExpress.XtraGrid.Columns.GridColumn gvOrdersColDocId;
        private DevExpress.XtraGrid.Columns.GridColumn gvOrdersColStudId;
        private DevExpress.XtraGrid.Columns.GridColumn gvOrdersColAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gvOrdersColOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gvOrdersColOrderDate;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStatus;
        private DevExpress.XtraEditors.GroupControl gcSifaris;
        private DevExpress.XtraEditors.SimpleButton btnSifarisHazir;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblDocLang;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblDeliveryMethod;
        private DevExpress.XtraEditors.MemoExEdit memoUserAddr;
        private DevExpress.XtraGrid.Columns.GridColumn gvOrdersColOrderStatus;
        private DevExpress.XtraEditors.LabelControl lblDocTitle;
        private DevExpress.XtraEditors.TextEdit txtStudID;
        private DevExpress.XtraEditors.LabelControl lblStudName;
        private DevExpress.XtraEditors.LabelControl lblAmount;
        private System.Windows.Forms.Button btnCancelOrder;
    }
}