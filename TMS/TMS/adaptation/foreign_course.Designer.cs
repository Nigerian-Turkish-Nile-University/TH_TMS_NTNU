namespace TMS.adaptation
{
    partial class foreign_course
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
            this.group_foreignCourse = new DevExpress.XtraEditors.GroupControl();
            this.button_save = new DevExpress.XtraEditors.SimpleButton();
            this.button_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.spin_ects = new DevExpress.XtraEditors.SpinEdit();
            this.spin_credit = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_grade = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.edit_dersTitle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.edit_gradeLetter = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.edit_dersCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_university = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUp_semester = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUp_year = new DevExpress.XtraEditors.LookUpEdit();
            this.dxValidationProvider_foreignCourses = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.group_foreignCourse)).BeginInit();
            this.group_foreignCourse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spin_ects.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_credit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_grade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_dersTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_gradeLetter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_dersCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_university.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_semester.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider_foreignCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // group_foreignCourse
            // 
            this.group_foreignCourse.Controls.Add(this.button_save);
            this.group_foreignCourse.Controls.Add(this.button_cancel);
            this.group_foreignCourse.Controls.Add(this.spin_ects);
            this.group_foreignCourse.Controls.Add(this.spin_credit);
            this.group_foreignCourse.Controls.Add(this.spinEdit_grade);
            this.group_foreignCourse.Controls.Add(this.labelControl6);
            this.group_foreignCourse.Controls.Add(this.labelControl7);
            this.group_foreignCourse.Controls.Add(this.edit_dersTitle);
            this.group_foreignCourse.Controls.Add(this.labelControl5);
            this.group_foreignCourse.Controls.Add(this.edit_gradeLetter);
            this.group_foreignCourse.Controls.Add(this.labelControl9);
            this.group_foreignCourse.Controls.Add(this.labelControl8);
            this.group_foreignCourse.Controls.Add(this.edit_dersCode);
            this.group_foreignCourse.Controls.Add(this.labelControl4);
            this.group_foreignCourse.Controls.Add(this.labelControl1);
            this.group_foreignCourse.Controls.Add(this.lookUp_university);
            this.group_foreignCourse.Controls.Add(this.labelControl3);
            this.group_foreignCourse.Controls.Add(this.labelControl2);
            this.group_foreignCourse.Controls.Add(this.lookUp_semester);
            this.group_foreignCourse.Controls.Add(this.lookUp_year);
            this.group_foreignCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_foreignCourse.Location = new System.Drawing.Point(0, 0);
            this.group_foreignCourse.Name = "group_foreignCourse";
            this.group_foreignCourse.Size = new System.Drawing.Size(537, 219);
            this.group_foreignCourse.TabIndex = 42;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(368, 184);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "ADD";
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(449, 184);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "Cancel";
            // 
            // spin_ects
            // 
            this.spin_ects.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spin_ects.Location = new System.Drawing.Point(118, 142);
            this.spin_ects.Name = "spin_ects";
            this.spin_ects.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spin_ects.Properties.MaxLength = 3;
            this.spin_ects.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spin_ects.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.spin_ects.Size = new System.Drawing.Size(100, 20);
            this.spin_ects.TabIndex = 6;
            // 
            // spin_credit
            // 
            this.spin_credit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spin_credit.Location = new System.Drawing.Point(12, 142);
            this.spin_credit.Name = "spin_credit";
            this.spin_credit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spin_credit.Properties.IsFloatValue = false;
            this.spin_credit.Properties.Mask.EditMask = "N00";
            this.spin_credit.Properties.MaxLength = 2;
            this.spin_credit.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spin_credit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.spin_credit.Size = new System.Drawing.Size(100, 20);
            this.spin_credit.TabIndex = 5;
            // 
            // spinEdit_grade
            // 
            this.spinEdit_grade.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_grade.Location = new System.Drawing.Point(224, 142);
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
            this.spinEdit_grade.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(224, 123);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(29, 13);
            this.labelControl6.TabIndex = 81;
            this.labelControl6.Text = "Grade";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(310, 123);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(61, 13);
            this.labelControl7.TabIndex = 80;
            this.labelControl7.Text = "Letter Grade";
            // 
            // edit_dersTitle
            // 
            this.edit_dersTitle.Location = new System.Drawing.Point(224, 97);
            this.edit_dersTitle.Name = "edit_dersTitle";
            this.edit_dersTitle.Properties.MaxLength = 100;
            this.edit_dersTitle.Size = new System.Drawing.Size(300, 20);
            this.edit_dersTitle.TabIndex = 4;
            this.edit_dersTitle.Validating += new System.ComponentModel.CancelEventHandler(this.lookUp_year_Validating);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Location = new System.Drawing.Point(224, 78);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 51;
            this.labelControl5.Text = "Course Title";
            // 
            // edit_gradeLetter
            // 
            this.edit_gradeLetter.Location = new System.Drawing.Point(310, 142);
            this.edit_gradeLetter.Name = "edit_gradeLetter";
            this.edit_gradeLetter.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.edit_gradeLetter.Properties.MaxLength = 2;
            this.edit_gradeLetter.Size = new System.Drawing.Size(100, 20);
            this.edit_gradeLetter.TabIndex = 8;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(118, 123);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(25, 13);
            this.labelControl9.TabIndex = 49;
            this.labelControl9.Text = "ECTS";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 123);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(29, 13);
            this.labelControl8.TabIndex = 49;
            this.labelControl8.Text = "Credit";
            // 
            // edit_dersCode
            // 
            this.edit_dersCode.Location = new System.Drawing.Point(12, 97);
            this.edit_dersCode.Name = "edit_dersCode";
            this.edit_dersCode.Properties.MaxLength = 8;
            this.edit_dersCode.Size = new System.Drawing.Size(206, 20);
            this.edit_dersCode.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Location = new System.Drawing.Point(12, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 13);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "Course Code";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(224, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 47;
            this.labelControl1.Text = "University";
            // 
            // lookUp_university
            // 
            this.lookUp_university.EditValue = "";
            this.lookUp_university.Location = new System.Drawing.Point(224, 52);
            this.lookUp_university.Name = "lookUp_university";
            this.lookUp_university.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_university.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_university.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_university.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_university.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_university.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TITLE", "title")});
            this.lookUp_university.Properties.NullText = "";
            this.lookUp_university.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_university.Properties.ShowFooter = false;
            this.lookUp_university.Properties.ShowHeader = false;
            this.lookUp_university.Size = new System.Drawing.Size(300, 20);
            this.lookUp_university.TabIndex = 2;
            this.lookUp_university.Validating += new System.ComponentModel.CancelEventHandler(this.lookUp_year_Validating);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(118, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 45;
            this.labelControl3.Text = "Semester";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "EduYear";
            // 
            // lookUp_semester
            // 
            this.lookUp_semester.EditValue = "";
            this.lookUp_semester.Location = new System.Drawing.Point(118, 52);
            this.lookUp_semester.Name = "lookUp_semester";
            this.lookUp_semester.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_semester.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_semester.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_semester.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_semester.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_semester.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("V", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("D", "title")});
            this.lookUp_semester.Properties.NullText = "";
            this.lookUp_semester.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_semester.Properties.ShowFooter = false;
            this.lookUp_semester.Properties.ShowHeader = false;
            this.lookUp_semester.Size = new System.Drawing.Size(100, 20);
            this.lookUp_semester.TabIndex = 1;
            this.lookUp_semester.Validating += new System.ComponentModel.CancelEventHandler(this.lookUp_year_Validating);
            // 
            // lookUp_year
            // 
            this.lookUp_year.EditValue = "";
            this.lookUp_year.Location = new System.Drawing.Point(12, 52);
            this.lookUp_year.Name = "lookUp_year";
            this.lookUp_year.Properties.Appearance.Options.UseTextOptions = true;
            this.lookUp_year.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_year.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.lookUp_year.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lookUp_year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUp_year.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YEAR_CONF_YIL", "id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IL", "title", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Center)});
            this.lookUp_year.Properties.NullText = "";
            this.lookUp_year.Properties.PopupFormMinSize = new System.Drawing.Size(10, 0);
            this.lookUp_year.Properties.ShowFooter = false;
            this.lookUp_year.Properties.ShowHeader = false;
            this.lookUp_year.Size = new System.Drawing.Size(100, 20);
            this.lookUp_year.TabIndex = 0;
            this.lookUp_year.Validating += new System.ComponentModel.CancelEventHandler(this.lookUp_year_Validating);
            // 
            // foreign_course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 219);
            this.Controls.Add(this.group_foreignCourse);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "foreign_course";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Course";
            this.Load += new System.EventHandler(this.foreign_course_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_foreignCourse)).EndInit();
            this.group_foreignCourse.ResumeLayout(false);
            this.group_foreignCourse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spin_ects.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spin_credit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_grade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_dersTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_gradeLetter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edit_dersCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_university.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_semester.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUp_year.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider_foreignCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUp_semester;
        private DevExpress.XtraEditors.LookUpEdit lookUp_year;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUp_university;
        private DevExpress.XtraEditors.TextEdit edit_dersTitle;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit edit_dersCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spinEdit_grade;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton button_save;
        private DevExpress.XtraEditors.SimpleButton button_cancel;
        private DevExpress.XtraEditors.TextEdit edit_gradeLetter;
        public DevExpress.XtraEditors.GroupControl group_foreignCourse;
        private DevExpress.XtraEditors.SpinEdit spin_ects;
        private DevExpress.XtraEditors.SpinEdit spin_credit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider_foreignCourses;
    }
}