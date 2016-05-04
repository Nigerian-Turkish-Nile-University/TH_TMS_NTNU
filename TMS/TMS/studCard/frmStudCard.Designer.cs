namespace TMS.studCard
{
    partial class frmStudCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudCard));
            this.group_card = new DevExpress.XtraEditors.GroupControl();
            this.button_print = new DevExpress.XtraEditors.SimpleButton();
            this.dataSet1 = new System.Data.DataSet();
            this.report1 = new FastReport.Report();
            this.label_class = new System.Windows.Forms.Label();
            this.label_studID = new System.Windows.Forms.Label();
            this.label_parent = new System.Windows.Forms.Label();
            this.label_dep = new System.Windows.Forms.Label();
            this.label_fullname = new System.Windows.Forms.Label();
            this.image_stud = new System.Windows.Forms.PictureBox();
            this.button_preview = new System.Windows.Forms.Button();
            this.dataSet2 = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.group_card)).BeginInit();
            this.group_card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_stud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // group_card
            // 
            this.group_card.Controls.Add(this.button_print);
            this.group_card.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.group_card.Location = new System.Drawing.Point(0, 161);
            this.group_card.Name = "group_card";
            this.group_card.Size = new System.Drawing.Size(300, 75);
            this.group_card.TabIndex = 0;
            this.group_card.Text = "Number of LAST Printet CARD:";
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(78, 40);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(150, 23);
            this.button_print.TabIndex = 0;
            this.button_print.Text = "Print same CARD";
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // report1
            // 
            this.report1.ReportResourceString = resources.GetString("report1.ReportResourceString");
            // 
            // label_class
            // 
            this.label_class.AutoSize = true;
            this.label_class.Location = new System.Drawing.Point(130, 107);
            this.label_class.Name = "label_class";
            this.label_class.Size = new System.Drawing.Size(34, 14);
            this.label_class.TabIndex = 23;
            this.label_class.Text = "Class";
            // 
            // label_studID
            // 
            this.label_studID.AutoSize = true;
            this.label_studID.Location = new System.Drawing.Point(130, 12);
            this.label_studID.Name = "label_studID";
            this.label_studID.Size = new System.Drawing.Size(56, 14);
            this.label_studID.TabIndex = 22;
            this.label_studID.Text = "Student ID";
            // 
            // label_parent
            // 
            this.label_parent.AutoSize = true;
            this.label_parent.Location = new System.Drawing.Point(130, 59);
            this.label_parent.Name = "label_parent";
            this.label_parent.Size = new System.Drawing.Size(38, 14);
            this.label_parent.TabIndex = 21;
            this.label_parent.Text = "Father";
            // 
            // label_dep
            // 
            this.label_dep.AutoSize = true;
            this.label_dep.Location = new System.Drawing.Point(130, 83);
            this.label_dep.Name = "label_dep";
            this.label_dep.Size = new System.Drawing.Size(62, 14);
            this.label_dep.TabIndex = 20;
            this.label_dep.Text = "Department";
            // 
            // label_fullname
            // 
            this.label_fullname.AutoSize = true;
            this.label_fullname.Location = new System.Drawing.Point(130, 35);
            this.label_fullname.Name = "label_fullname";
            this.label_fullname.Size = new System.Drawing.Size(74, 14);
            this.label_fullname.TabIndex = 19;
            this.label_fullname.Text = "Name, SName";
            // 
            // image_stud
            // 
            this.image_stud.Image = global::TMS.Properties.Resources.no_foto;
            this.image_stud.InitialImage = null;
            this.image_stud.Location = new System.Drawing.Point(12, 12);
            this.image_stud.Name = "image_stud";
            this.image_stud.Size = new System.Drawing.Size(112, 142);
            this.image_stud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_stud.TabIndex = 18;
            this.image_stud.TabStop = false;
            // 
            // button_preview
            // 
            this.button_preview.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_preview.Location = new System.Drawing.Point(133, 133);
            this.button_preview.Name = "button_preview";
            this.button_preview.Size = new System.Drawing.Size(157, 22);
            this.button_preview.TabIndex = 17;
            this.button_preview.Text = "Print New Student CARD";
            this.button_preview.UseVisualStyleBackColor = true;
            this.button_preview.Click += new System.EventHandler(this.button_preview_Click);
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "NewDataSet";
            // 
            // frmStudCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 236);
            this.Controls.Add(this.label_class);
            this.Controls.Add(this.label_studID);
            this.Controls.Add(this.label_parent);
            this.Controls.Add(this.label_dep);
            this.Controls.Add(this.label_fullname);
            this.Controls.Add(this.image_stud);
            this.Controls.Add(this.button_preview);
            this.Controls.Add(this.group_card);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student CARD";
            this.Activated += new System.EventHandler(this.frmStudCard_Activated);
            this.Load += new System.EventHandler(this.frmStudCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.group_card)).EndInit();
            this.group_card.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_stud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl group_card;
        private System.Data.DataSet dataSet1;
        private FastReport.Report report1;
        private System.Windows.Forms.Label label_class;
        private System.Windows.Forms.Label label_studID;
        private System.Windows.Forms.Label label_parent;
        private System.Windows.Forms.Label label_dep;
        private System.Windows.Forms.Label label_fullname;
        private System.Windows.Forms.PictureBox image_stud;
        private System.Windows.Forms.Button button_preview;
        private DevExpress.XtraEditors.SimpleButton button_print;
        private System.Data.DataSet dataSet2;

    }
}