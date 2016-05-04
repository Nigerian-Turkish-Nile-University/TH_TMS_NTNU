namespace TMS.adaptation
{
    partial class form_mufsq
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
            this.group_electiveCourse = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_SQ = new DevExpress.XtraEditors.LookUpEdit();
            this.button_changeMufSQ = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.group_electiveCourse)).BeginInit();
            this.group_electiveCourse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_SQ.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // group_electiveCourse
            // 
            this.group_electiveCourse.Controls.Add(this.labelControl2);
            this.group_electiveCourse.Controls.Add(this.lookUp_SQ);
            this.group_electiveCourse.Controls.Add(this.button_changeMufSQ);
            this.group_electiveCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_electiveCourse.Location = new System.Drawing.Point(0, 0);
            this.group_electiveCourse.Name = "group_electiveCourse";
            this.group_electiveCourse.Size = new System.Drawing.Size(415, 82);
            this.group_electiveCourse.TabIndex = 1;
            this.group_electiveCourse.Text = "Elective Course";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(12, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "ELECTIVE GROUP ";
            // 
            // lookUp_SQ
            // 
            this.lookUp_SQ.EditValue = "";
            this.lookUp_SQ.Location = new System.Drawing.Point(12, 46);
            this.lookUp_SQ.Name = "lookUp_SQ";
            this.lookUp_SQ.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_SQ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_SQ.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_SQ.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_SQ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_SQ.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_SQ.Properties.NullText = "";
            this.lookUp_SQ.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_SQ.Properties.ShowFooter = false;
            this.lookUp_SQ.Properties.ShowHeader = false;
            this.lookUp_SQ.Size = new System.Drawing.Size(300, 20);
            this.lookUp_SQ.TabIndex = 0;
            this.lookUp_SQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUp_SQ_KeyDown);
            // 
            // button_changeMufSQ
            // 
            this.button_changeMufSQ.Location = new System.Drawing.Point(328, 46);
            this.button_changeMufSQ.Name = "button_changeMufSQ";
            this.button_changeMufSQ.Size = new System.Drawing.Size(75, 20);
            this.button_changeMufSQ.TabIndex = 1;
            this.button_changeMufSQ.Text = "CHANGE";
            this.button_changeMufSQ.Click += new System.EventHandler(this.button_changeMufSQ_Click);
            this.button_changeMufSQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUp_SQ_KeyDown);
            // 
            // form_mufsq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 82);
            this.Controls.Add(this.group_electiveCourse);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_mufsq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Elective Group";
            this.Load += new System.EventHandler(this.form_mufsq_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lookUp_SQ_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.group_electiveCourse)).EndInit();
            this.group_electiveCourse.ResumeLayout(false);
            this.group_electiveCourse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_SQ.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton button_changeMufSQ;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUp_SQ;
        public DevExpress.XtraEditors.GroupControl group_electiveCourse;

    }
}