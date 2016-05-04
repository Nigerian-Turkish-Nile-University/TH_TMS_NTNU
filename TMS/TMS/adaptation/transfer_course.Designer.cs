namespace TMS.adaptation
{
    partial class transfer_course
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
            this.group_transferCourse = new DevExpress.XtraEditors.GroupControl();
            this.check_foreignCourses = new DevExpress.XtraEditors.CheckEdit();
            this.memo_desc = new DevExpress.XtraEditors.MemoExEdit();
            this.spinEdit_grade = new DevExpress.XtraEditors.SpinEdit();
            this.button_save = new DevExpress.XtraEditors.SimpleButton();
            this.button_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_gradeLetter = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_gradingType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_transferType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_ourCourse = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_foreignCourse = new DevExpress.XtraEditors.LookUpEdit();
            this.dxValidationProvider_transferredCourses = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.group_transferCourse)).BeginInit();
            this.group_transferCourse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_foreignCourses.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memo_desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_grade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_gradeLetter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_gradingType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_transferType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_ourCourse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_foreignCourse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider_transferredCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // group_transferCourse
            // 
            this.group_transferCourse.Controls.Add(this.check_foreignCourses);
            this.group_transferCourse.Controls.Add(this.memo_desc);
            this.group_transferCourse.Controls.Add(this.spinEdit_grade);
            this.group_transferCourse.Controls.Add(this.button_save);
            this.group_transferCourse.Controls.Add(this.button_cancel);
            this.group_transferCourse.Controls.Add(this.labelControl5);
            this.group_transferCourse.Controls.Add(this.labelControl6);
            this.group_transferCourse.Controls.Add(this.lookUp_gradeLetter);
            this.group_transferCourse.Controls.Add(this.labelControl4);
            this.group_transferCourse.Controls.Add(this.lookUp_gradingType);
            this.group_transferCourse.Controls.Add(this.labelControl3);
            this.group_transferCourse.Controls.Add(this.lookUp_transferType);
            this.group_transferCourse.Controls.Add(this.labelControl1);
            this.group_transferCourse.Controls.Add(this.lookUp_ourCourse);
            this.group_transferCourse.Controls.Add(this.labelControl8);
            this.group_transferCourse.Controls.Add(this.labelControl2);
            this.group_transferCourse.Controls.Add(this.lookUp_foreignCourse);
            this.group_transferCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_transferCourse.Location = new System.Drawing.Point(0, 0);
            this.group_transferCourse.Name = "group_transferCourse";
            this.group_transferCourse.Size = new System.Drawing.Size(681, 170);
            this.group_transferCourse.TabIndex = 10;
            // 
            // check_foreignCourses
            // 
            this.check_foreignCourses.Location = new System.Drawing.Point(10, 139);
            this.check_foreignCourses.Name = "check_foreignCourses";
            this.check_foreignCourses.Properties.Caption = "SHOW ALL FOREIGN COURSES.";
            this.check_foreignCourses.Size = new System.Drawing.Size(230, 19);
            this.check_foreignCourses.TabIndex = 22;
            this.check_foreignCourses.CheckedChanged += new System.EventHandler(this.check_foreignCourses_CheckedChanged);
            // 
            // memo_desc
            // 
            this.memo_desc.Location = new System.Drawing.Point(510, 97);
            this.memo_desc.Name = "memo_desc";
            this.memo_desc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.memo_desc.Properties.MaxLength = 250;
            this.memo_desc.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.memo_desc.Properties.PopupFormSize = new System.Drawing.Size(297, 0);
            this.memo_desc.Size = new System.Drawing.Size(159, 20);
            this.memo_desc.TabIndex = 6;
            // 
            // spinEdit_grade
            // 
            this.spinEdit_grade.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_grade.Location = new System.Drawing.Point(424, 97);
            this.spinEdit_grade.Name = "spinEdit_grade";
            this.spinEdit_grade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_grade.Properties.IsFloatValue = false;
            this.spinEdit_grade.Properties.Mask.EditMask = "N00";
            this.spinEdit_grade.Properties.MaxLength = 3;
            this.spinEdit_grade.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEdit_grade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.spinEdit_grade.Size = new System.Drawing.Size(80, 20);
            this.spinEdit_grade.TabIndex = 5;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(510, 135);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "ADD";
            this.button_save.ToolTip = "Nəzərə alın ki, bu məlumat daxil edildiyi andan etibarən QİYMƏT CƏDVƏLİ və TRANSK" +
                "RİPT kimi bir çöx yerdə görsənəcək.";
            this.button_save.ToolTipTitle = "DİQQƏT";
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(594, 135);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "Cancel";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(424, 78);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(29, 13);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Grade";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(318, 78);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(61, 13);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "Letter Grade";
            // 
            // lookUp_gradeLetter
            // 
            this.lookUp_gradeLetter.EditValue = "";
            this.lookUp_gradeLetter.Location = new System.Drawing.Point(318, 97);
            this.lookUp_gradeLetter.Name = "lookUp_gradeLetter";
            this.lookUp_gradeLetter.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_gradeLetter.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_gradeLetter.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_gradeLetter.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_gradeLetter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_gradeLetter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_gradeLetter.Properties.NullText = "";
            this.lookUp_gradeLetter.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_gradeLetter.Properties.ShowFooter = false;
            this.lookUp_gradeLetter.Properties.ShowHeader = false;
            this.lookUp_gradeLetter.Size = new System.Drawing.Size(100, 20);
            this.lookUp_gradeLetter.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(168, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Grading type";
            // 
            // lookUp_gradingType
            // 
            this.lookUp_gradingType.EditValue = "";
            this.lookUp_gradingType.Location = new System.Drawing.Point(168, 97);
            this.lookUp_gradingType.Name = "lookUp_gradingType";
            this.lookUp_gradingType.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_gradingType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_gradingType.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_gradingType.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_gradingType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_gradingType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_gradingType.Properties.NullText = "";
            this.lookUp_gradingType.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_gradingType.Properties.ShowFooter = false;
            this.lookUp_gradingType.Properties.ShowHeader = false;
            this.lookUp_gradingType.Size = new System.Drawing.Size(144, 20);
            this.lookUp_gradingType.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(12, 78);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(87, 13);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "TRANSFER TYPE";
            // 
            // lookUp_transferType
            // 
            this.lookUp_transferType.EditValue = "";
            this.lookUp_transferType.Location = new System.Drawing.Point(12, 97);
            this.lookUp_transferType.Name = "lookUp_transferType";
            this.lookUp_transferType.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_transferType.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_transferType.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_transferType.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_transferType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_transferType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_transferType.Properties.NullText = "";
            this.lookUp_transferType.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_transferType.Properties.ShowFooter = false;
            this.lookUp_transferType.Properties.ShowHeader = false;
            this.lookUp_transferType.Size = new System.Drawing.Size(150, 20);
            this.lookUp_transferType.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(318, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "COURSE at NTNU";
            // 
            // lookUp_ourCourse
            // 
            this.lookUp_ourCourse.EditValue = "";
            this.lookUp_ourCourse.Location = new System.Drawing.Point(318, 52);
            this.lookUp_ourCourse.Name = "lookUp_ourCourse";
            this.lookUp_ourCourse.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_ourCourse.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_ourCourse.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_ourCourse.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_ourCourse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_ourCourse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_ourCourse.Properties.NullText = "";
            this.lookUp_ourCourse.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_ourCourse.Properties.ShowFooter = false;
            this.lookUp_ourCourse.Properties.ShowHeader = false;
            this.lookUp_ourCourse.Size = new System.Drawing.Size(351, 20);
            this.lookUp_ourCourse.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(558, 78);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(68, 13);
            this.labelControl8.TabIndex = 11;
            this.labelControl8.Text = "DESCRIPTION";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(12, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(95, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "FOREIGN COURSE";
            // 
            // lookUp_foreignCourse
            // 
            this.lookUp_foreignCourse.EditValue = "";
            this.lookUp_foreignCourse.Location = new System.Drawing.Point(12, 52);
            this.lookUp_foreignCourse.Name = "lookUp_foreignCourse";
            this.lookUp_foreignCourse.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_foreignCourse.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_foreignCourse.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_foreignCourse.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_foreignCourse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_foreignCourse.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_foreignCourse.Properties.NullText = "";
            this.lookUp_foreignCourse.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_foreignCourse.Properties.ShowFooter = false;
            this.lookUp_foreignCourse.Properties.ShowHeader = false;
            this.lookUp_foreignCourse.Size = new System.Drawing.Size(300, 20);
            this.lookUp_foreignCourse.TabIndex = 0;
            this.lookUp_foreignCourse.EditValueChanged += new System.EventHandler(this.lookUp_foreignCourse_EditValueChanged);
            this.lookUp_foreignCourse.Validating += new System.ComponentModel.CancelEventHandler(this.lookUp_foreignCourse_Validating);
            // 
            // transfer_course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 170);
            this.Controls.Add(this.group_transferCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "transfer_course";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer Course";
            this.Load += new System.EventHandler(this.transfer_course_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_transferCourse)).EndInit();
            this.group_transferCourse.ResumeLayout(false);
            this.group_transferCourse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.check_foreignCourses.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memo_desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_grade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_gradeLetter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_gradingType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_transferType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_ourCourse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_foreignCourse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider_transferredCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lookUp_gradeLetter;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit lookUp_gradingType;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUp_transferType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUp_ourCourse;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUp_foreignCourse;
        private DevExpress.XtraEditors.SimpleButton button_save;
        private DevExpress.XtraEditors.SimpleButton button_cancel;
        private DevExpress.XtraEditors.SpinEdit spinEdit_grade;
        public DevExpress.XtraEditors.GroupControl group_transferCourse;
        private DevExpress.XtraEditors.MemoExEdit memo_desc;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider_transferredCourses;
        private DevExpress.XtraEditors.CheckEdit check_foreignCourses;
    }
}