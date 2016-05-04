namespace TMS.adaptation
{
    partial class form_adaptation
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
            this.split_adaptation = new System.Windows.Forms.SplitContainer();
            this.group_transferredCourses = new DevExpress.XtraEditors.GroupControl();
            this.button_addTransferredCourse = new DevExpress.XtraEditors.SimpleButton();
            this.button_editTransferredCourse = new DevExpress.XtraEditors.SimpleButton();
            this.grid_transferredCourses = new DevExpress.XtraGrid.GridControl();
            this.view_transferredCourses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button_removeTransferredCourse = new DevExpress.XtraEditors.SimpleButton();
            this.group_foreignCourses = new DevExpress.XtraEditors.GroupControl();
            this.button_addForeignCourse = new DevExpress.XtraEditors.SimpleButton();
            this.button_editForeignCourse = new DevExpress.XtraEditors.SimpleButton();
            this.button_removeForeignCourse = new DevExpress.XtraEditors.SimpleButton();
            this.grid_foreignCourses = new DevExpress.XtraGrid.GridControl();
            this.view_foreignCourses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.group_adaptedCourses = new DevExpress.XtraEditors.GroupControl();
            this.button_refuse = new DevExpress.XtraEditors.SimpleButton();
            this.button_adapt = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_program = new DevExpress.XtraEditors.LookUpEdit();
            this.grid_adaptedCourses = new DevExpress.XtraGrid.GridControl();
            this.view_adaptedCourses = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repository_ButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.split_adaptation)).BeginInit();
            this.split_adaptation.Panel1.SuspendLayout();
            this.split_adaptation.Panel2.SuspendLayout();
            this.split_adaptation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_transferredCourses)).BeginInit();
            this.group_transferredCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_transferredCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_transferredCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_foreignCourses)).BeginInit();
            this.group_foreignCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_foreignCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_foreignCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_adaptedCourses)).BeginInit();
            this.group_adaptedCourses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_program.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_adaptedCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_adaptedCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_ButtonEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // split_adaptation
            // 
            this.split_adaptation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_adaptation.Location = new System.Drawing.Point(0, 0);
            this.split_adaptation.Name = "split_adaptation";
            this.split_adaptation.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_adaptation.Panel1
            // 
            this.split_adaptation.Panel1.Controls.Add(this.group_transferredCourses);
            this.split_adaptation.Panel1.Controls.Add(this.group_foreignCourses);
            this.split_adaptation.Panel1MinSize = 200;
            // 
            // split_adaptation.Panel2
            // 
            this.split_adaptation.Panel2.Controls.Add(this.group_adaptedCourses);
            this.split_adaptation.Panel2MinSize = 150;
            this.split_adaptation.Size = new System.Drawing.Size(792, 753);
            this.split_adaptation.SplitterDistance = 389;
            this.split_adaptation.TabIndex = 0;
            // 
            // group_transferredCourses
            // 
            this.group_transferredCourses.AppearanceCaption.Options.UseTextOptions = true;
            this.group_transferredCourses.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.group_transferredCourses.Controls.Add(this.button_addTransferredCourse);
            this.group_transferredCourses.Controls.Add(this.button_editTransferredCourse);
            this.group_transferredCourses.Controls.Add(this.grid_transferredCourses);
            this.group_transferredCourses.Controls.Add(this.button_removeTransferredCourse);
            this.group_transferredCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_transferredCourses.Location = new System.Drawing.Point(0, 200);
            this.group_transferredCourses.Name = "group_transferredCourses";
            this.group_transferredCourses.Size = new System.Drawing.Size(792, 189);
            this.group_transferredCourses.TabIndex = 3;
            this.group_transferredCourses.Text = "TRANSFERRED COURSES";
            // 
            // button_addTransferredCourse
            // 
            this.button_addTransferredCourse.Image = global::TMS.Properties.Resources.add_16;
            this.button_addTransferredCourse.ImageIndex = 0;
            this.button_addTransferredCourse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_addTransferredCourse.Location = new System.Drawing.Point(5, 0);
            this.button_addTransferredCourse.Name = "button_addTransferredCourse";
            this.button_addTransferredCourse.Size = new System.Drawing.Size(30, 20);
            this.button_addTransferredCourse.TabIndex = 6;
            this.button_addTransferredCourse.Click += new System.EventHandler(this.button_addTransferredCourse_Click);
            // 
            // button_editTransferredCourse
            // 
            this.button_editTransferredCourse.Enabled = false;
            this.button_editTransferredCourse.Image = global::TMS.Properties.Resources.edit2;
            this.button_editTransferredCourse.ImageIndex = 1;
            this.button_editTransferredCourse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_editTransferredCourse.Location = new System.Drawing.Point(41, 0);
            this.button_editTransferredCourse.Name = "button_editTransferredCourse";
            this.button_editTransferredCourse.Size = new System.Drawing.Size(30, 20);
            this.button_editTransferredCourse.TabIndex = 7;
            this.button_editTransferredCourse.Click += new System.EventHandler(this.button_editTransferredCourse_Click);
            // 
            // grid_transferredCourses
            // 
            this.grid_transferredCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_transferredCourses.Location = new System.Drawing.Point(2, 21);
            this.grid_transferredCourses.MainView = this.view_transferredCourses;
            this.grid_transferredCourses.Name = "grid_transferredCourses";
            this.grid_transferredCourses.Size = new System.Drawing.Size(788, 166);
            this.grid_transferredCourses.TabIndex = 6;
            this.grid_transferredCourses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_transferredCourses,
            this.gridView5});
            // 
            // view_transferredCourses
            // 
            this.view_transferredCourses.GridControl = this.grid_transferredCourses;
            this.view_transferredCourses.Name = "view_transferredCourses";
            this.view_transferredCourses.OptionsBehavior.Editable = false;
            this.view_transferredCourses.OptionsCustomization.AllowColumnMoving = false;
            this.view_transferredCourses.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_transferredCourses.OptionsView.ShowGroupPanel = false;
            this.view_transferredCourses.OptionsView.ShowIndicator = false;
            this.view_transferredCourses.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.view_transferredCourses_FocusedRowChanged);
            this.view_transferredCourses.DoubleClick += new System.EventHandler(this.button_editTransferredCourse_Click);
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.grid_transferredCourses;
            this.gridView5.Name = "gridView5";
            // 
            // button_removeTransferredCourse
            // 
            this.button_removeTransferredCourse.Enabled = false;
            this.button_removeTransferredCourse.Image = global::TMS.Properties.Resources.delete_16;
            this.button_removeTransferredCourse.ImageIndex = 2;
            this.button_removeTransferredCourse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_removeTransferredCourse.Location = new System.Drawing.Point(77, 0);
            this.button_removeTransferredCourse.Name = "button_removeTransferredCourse";
            this.button_removeTransferredCourse.Size = new System.Drawing.Size(30, 20);
            this.button_removeTransferredCourse.TabIndex = 8;
            this.button_removeTransferredCourse.Click += new System.EventHandler(this.button_removeTransferredCourse_Click);
            // 
            // group_foreignCourses
            // 
            this.group_foreignCourses.AppearanceCaption.Options.UseTextOptions = true;
            this.group_foreignCourses.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.group_foreignCourses.Controls.Add(this.button_addForeignCourse);
            this.group_foreignCourses.Controls.Add(this.button_editForeignCourse);
            this.group_foreignCourses.Controls.Add(this.button_removeForeignCourse);
            this.group_foreignCourses.Controls.Add(this.grid_foreignCourses);
            this.group_foreignCourses.Dock = System.Windows.Forms.DockStyle.Top;
            this.group_foreignCourses.Location = new System.Drawing.Point(0, 0);
            this.group_foreignCourses.Name = "group_foreignCourses";
            this.group_foreignCourses.Size = new System.Drawing.Size(792, 200);
            this.group_foreignCourses.TabIndex = 0;
            this.group_foreignCourses.Text = "FOREIGN COURSES";
            // 
            // button_addForeignCourse
            // 
            this.button_addForeignCourse.Image = global::TMS.Properties.Resources.add_16;
            this.button_addForeignCourse.ImageIndex = 0;
            this.button_addForeignCourse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_addForeignCourse.Location = new System.Drawing.Point(5, 0);
            this.button_addForeignCourse.Name = "button_addForeignCourse";
            this.button_addForeignCourse.Size = new System.Drawing.Size(30, 20);
            this.button_addForeignCourse.TabIndex = 6;
            this.button_addForeignCourse.Click += new System.EventHandler(this.button_addForeignCourse_Click);
            // 
            // button_editForeignCourse
            // 
            this.button_editForeignCourse.Enabled = false;
            this.button_editForeignCourse.Image = global::TMS.Properties.Resources.edit2;
            this.button_editForeignCourse.ImageIndex = 1;
            this.button_editForeignCourse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_editForeignCourse.Location = new System.Drawing.Point(41, 0);
            this.button_editForeignCourse.Name = "button_editForeignCourse";
            this.button_editForeignCourse.Size = new System.Drawing.Size(30, 20);
            this.button_editForeignCourse.TabIndex = 7;
            this.button_editForeignCourse.Click += new System.EventHandler(this.button_editForeignCourse_Click);
            // 
            // button_removeForeignCourse
            // 
            this.button_removeForeignCourse.Enabled = false;
            this.button_removeForeignCourse.Image = global::TMS.Properties.Resources.delete_16;
            this.button_removeForeignCourse.ImageIndex = 2;
            this.button_removeForeignCourse.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_removeForeignCourse.Location = new System.Drawing.Point(77, 0);
            this.button_removeForeignCourse.Name = "button_removeForeignCourse";
            this.button_removeForeignCourse.Size = new System.Drawing.Size(30, 20);
            this.button_removeForeignCourse.TabIndex = 8;
            this.button_removeForeignCourse.Click += new System.EventHandler(this.button_removeForeignCourse_Click);
            // 
            // grid_foreignCourses
            // 
            this.grid_foreignCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_foreignCourses.Location = new System.Drawing.Point(2, 21);
            this.grid_foreignCourses.MainView = this.view_foreignCourses;
            this.grid_foreignCourses.Name = "grid_foreignCourses";
            this.grid_foreignCourses.Size = new System.Drawing.Size(788, 177);
            this.grid_foreignCourses.TabIndex = 5;
            this.grid_foreignCourses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_foreignCourses,
            this.gridView2});
            // 
            // view_foreignCourses
            // 
            this.view_foreignCourses.GridControl = this.grid_foreignCourses;
            this.view_foreignCourses.Name = "view_foreignCourses";
            this.view_foreignCourses.OptionsBehavior.Editable = false;
            this.view_foreignCourses.OptionsCustomization.AllowColumnMoving = false;
            this.view_foreignCourses.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_foreignCourses.OptionsView.ShowGroupPanel = false;
            this.view_foreignCourses.OptionsView.ShowIndicator = false;
            this.view_foreignCourses.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.view_foreignCourses_FocusedRowChanged);
            this.view_foreignCourses.DoubleClick += new System.EventHandler(this.button_editForeignCourse_Click);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grid_foreignCourses;
            this.gridView2.Name = "gridView2";
            // 
            // group_adaptedCourses
            // 
            this.group_adaptedCourses.AppearanceCaption.Options.UseTextOptions = true;
            this.group_adaptedCourses.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.group_adaptedCourses.Controls.Add(this.button_refuse);
            this.group_adaptedCourses.Controls.Add(this.button_adapt);
            this.group_adaptedCourses.Controls.Add(this.labelControl2);
            this.group_adaptedCourses.Controls.Add(this.lookUp_program);
            this.group_adaptedCourses.Controls.Add(this.grid_adaptedCourses);
            this.group_adaptedCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_adaptedCourses.Location = new System.Drawing.Point(0, 0);
            this.group_adaptedCourses.Name = "group_adaptedCourses";
            this.group_adaptedCourses.Size = new System.Drawing.Size(792, 360);
            this.group_adaptedCourses.TabIndex = 2;
            this.group_adaptedCourses.Text = "ADAPTED COURSES";
            // 
            // button_refuse
            // 
            this.button_refuse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_refuse.Enabled = false;
            this.button_refuse.Location = new System.Drawing.Point(705, 50);
            this.button_refuse.Name = "button_refuse";
            this.button_refuse.Size = new System.Drawing.Size(75, 23);
            this.button_refuse.TabIndex = 7;
            this.button_refuse.Text = "REFUSE";
            this.button_refuse.Click += new System.EventHandler(this.button_refuse_Click);
            // 
            // button_adapt
            // 
            this.button_adapt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_adapt.Enabled = false;
            this.button_adapt.Location = new System.Drawing.Point(607, 50);
            this.button_adapt.Name = "button_adapt";
            this.button_adapt.Size = new System.Drawing.Size(83, 23);
            this.button_adapt.TabIndex = 6;
            this.button_adapt.Text = "ADAPT";
            this.button_adapt.Click += new System.EventHandler(this.button_adapt_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "PROGRAM";
            // 
            // lookUp_program
            // 
            this.lookUp_program.EditValue = "";
            this.lookUp_program.Location = new System.Drawing.Point(12, 53);
            this.lookUp_program.Name = "lookUp_program";
            this.lookUp_program.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_program.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_program.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_program.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_program.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_program.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_program.Properties.NullText = "";
            this.lookUp_program.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_program.Properties.ShowFooter = false;
            this.lookUp_program.Properties.ShowHeader = false;
            this.lookUp_program.Size = new System.Drawing.Size(300, 20);
            this.lookUp_program.TabIndex = 3;
            this.lookUp_program.EditValueChanged += new System.EventHandler(this.lookUp_program_EditValueChanged);
            // 
            // grid_adaptedCourses
            // 
            this.grid_adaptedCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_adaptedCourses.Location = new System.Drawing.Point(2, 87);
            this.grid_adaptedCourses.MainView = this.view_adaptedCourses;
            this.grid_adaptedCourses.Name = "grid_adaptedCourses";
            this.grid_adaptedCourses.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repository_ButtonEdit});
            this.grid_adaptedCourses.Size = new System.Drawing.Size(788, 271);
            this.grid_adaptedCourses.TabIndex = 4;
            this.grid_adaptedCourses.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_adaptedCourses});
            // 
            // view_adaptedCourses
            // 
            this.view_adaptedCourses.GridControl = this.grid_adaptedCourses;
            this.view_adaptedCourses.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAID", null, "{0}", ((short)(2)))});
            this.view_adaptedCourses.Name = "view_adaptedCourses";
            this.view_adaptedCourses.OptionsBehavior.Editable = false;
            this.view_adaptedCourses.OptionsCustomization.AllowColumnMoving = false;
            this.view_adaptedCourses.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_adaptedCourses.OptionsView.ShowGroupPanel = false;
            this.view_adaptedCourses.OptionsView.ShowIndicator = false;
            this.view_adaptedCourses.DoubleClick += new System.EventHandler(this.view_adaptedCourses_DoubleClick);
            // 
            // repository_ButtonEdit
            // 
            this.repository_ButtonEdit.AutoHeight = false;
            this.repository_ButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repository_ButtonEdit.Name = "repository_ButtonEdit";
            // 
            // form_adaptation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(792, 753);
            this.Controls.Add(this.split_adaptation);
            this.MinimumSize = new System.Drawing.Size(250, 400);
            this.Name = "form_adaptation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COURSE ADAPTATION";
            this.Load += new System.EventHandler(this.adaptation_Load);
            this.split_adaptation.Panel1.ResumeLayout(false);
            this.split_adaptation.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_adaptation)).EndInit();
            this.split_adaptation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group_transferredCourses)).EndInit();
            this.group_transferredCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_transferredCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_transferredCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_foreignCourses)).EndInit();
            this.group_foreignCourses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_foreignCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_foreignCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_adaptedCourses)).EndInit();
            this.group_adaptedCourses.ResumeLayout(false);
            this.group_adaptedCourses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_program.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_adaptedCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_adaptedCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repository_ButtonEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split_adaptation;
        private DevExpress.XtraEditors.GroupControl group_foreignCourses;
        private DevExpress.XtraEditors.GroupControl group_adaptedCourses;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUp_program;
        private DevExpress.XtraGrid.GridControl grid_adaptedCourses;
        private DevExpress.XtraEditors.SimpleButton button_refuse;
        private DevExpress.XtraEditors.SimpleButton button_adapt;
        private DevExpress.XtraGrid.GridControl grid_foreignCourses;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton button_addForeignCourse;
        private DevExpress.XtraEditors.SimpleButton button_editForeignCourse;
        private DevExpress.XtraEditors.SimpleButton button_removeForeignCourse;
        private DevExpress.XtraEditors.GroupControl group_transferredCourses;
        private DevExpress.XtraEditors.SimpleButton button_addTransferredCourse;
        private DevExpress.XtraEditors.SimpleButton button_editTransferredCourse;
        private DevExpress.XtraGrid.GridControl grid_transferredCourses;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.SimpleButton button_removeTransferredCourse;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repository_ButtonEdit;
        public DevExpress.XtraGrid.Views.Grid.GridView view_adaptedCourses;
        public DevExpress.XtraGrid.Views.Grid.GridView view_transferredCourses;
        public DevExpress.XtraGrid.Views.Grid.GridView view_foreignCourses;
    }
}