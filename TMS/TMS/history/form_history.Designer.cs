namespace TMS.history
{
    partial class form_history
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
            this.group_history = new DevExpress.XtraEditors.GroupControl();
            this.grid_history = new DevExpress.XtraGrid.GridControl();
            this.view_history = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.group_history)).BeginInit();
            this.group_history.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_history)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_history)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // group_history
            // 
            this.group_history.Controls.Add(this.grid_history);
            this.group_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_history.Location = new System.Drawing.Point(0, 0);
            this.group_history.Name = "group_history";
            this.group_history.Size = new System.Drawing.Size(692, 373);
            this.group_history.TabIndex = 1;
            // 
            // grid_history
            // 
            this.grid_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_history.Location = new System.Drawing.Point(2, 21);
            this.grid_history.MainView = this.view_history;
            this.grid_history.Name = "grid_history";
            this.grid_history.Size = new System.Drawing.Size(688, 350);
            this.grid_history.TabIndex = 1;
            this.grid_history.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_history,
            this.gridView4});
            // 
            // view_history
            // 
            this.view_history.GridControl = this.grid_history;
            this.view_history.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAID", null, "{0}", ((short)(2)))});
            this.view_history.Name = "view_history";
            this.view_history.OptionsBehavior.Editable = false;
            this.view_history.OptionsCustomization.AllowColumnMoving = false;
            this.view_history.OptionsFilter.UseNewCustomFilterDialog = true;
            this.view_history.OptionsView.ShowGroupPanel = false;
            this.view_history.OptionsView.ShowIndicator = false;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grid_history;
            this.gridView4.Name = "gridView4";
            // 
            // form_history
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 373);
            this.Controls.Add(this.group_history);
            this.Name = "form_history";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academic History";
            this.Activated += new System.EventHandler(this.form_history_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_history_FormClosed);
            this.Load += new System.EventHandler(this.form_history_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_history)).EndInit();
            this.group_history.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_history)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_history)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl group_history;
        private DevExpress.XtraGrid.GridControl grid_history;
        private DevExpress.XtraGrid.Views.Grid.GridView view_history;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
    }
}