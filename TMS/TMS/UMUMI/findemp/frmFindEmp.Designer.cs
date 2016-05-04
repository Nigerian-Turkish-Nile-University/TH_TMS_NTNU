namespace findemp
{
    partial class frmFindEmp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindEmp));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.image_employee = new System.Windows.Forms.PictureBox();
            this.edthname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.edtsname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtname = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgEmployee = new System.Windows.Forms.DataGridView();
            this.btnsec = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_employee)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.image_employee);
            this.groupBox1.Controls.Add(this.edthname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.edtsname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.edtname);
            this.groupBox1.Controls.Add(this.lname);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // image_employee
            // 
            this.image_employee.Dock = System.Windows.Forms.DockStyle.Right;
            this.image_employee.Image = global::TMS.Properties.Resources.no_foto;
            this.image_employee.InitialImage = null;
            this.image_employee.Location = new System.Drawing.Point(403, 16);
            this.image_employee.Name = "image_employee";
            this.image_employee.Size = new System.Drawing.Size(64, 85);
            this.image_employee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image_employee.TabIndex = 26;
            this.image_employee.TabStop = false;
            // 
            // edthname
            // 
            this.edthname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edthname.Location = new System.Drawing.Point(78, 72);
            this.edthname.Name = "edthname";
            this.edthname.Size = new System.Drawing.Size(317, 20);
            this.edthname.TabIndex = 3;
            this.edthname.TextChanged += new System.EventHandler(this.edthname_TextChanged);
            this.edthname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtname_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username";
            // 
            // edtsname
            // 
            this.edtsname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtsname.Location = new System.Drawing.Point(78, 46);
            this.edtsname.Name = "edtsname";
            this.edtsname.Size = new System.Drawing.Size(317, 20);
            this.edtsname.TabIndex = 2;
            this.edtsname.TextChanged += new System.EventHandler(this.edtsname_TextChanged);
            this.edtsname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtname_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Surname";
            // 
            // edtname
            // 
            this.edtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtname.Location = new System.Drawing.Point(78, 20);
            this.edtname.Name = "edtname";
            this.edtname.Size = new System.Drawing.Size(317, 20);
            this.edtname.TabIndex = 1;
            this.edtname.TextChanged += new System.EventHandler(this.edtname_TextChanged);
            this.edtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtname_KeyDown);
            // 
            // lname
            // 
            this.lname.AutoSize = true;
            this.lname.Location = new System.Drawing.Point(38, 22);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(34, 14);
            this.lname.TabIndex = 0;
            this.lname.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgEmployee);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 211);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgEmployee
            // 
            this.dgEmployee.AllowUserToAddRows = false;
            this.dgEmployee.AllowUserToDeleteRows = false;
            this.dgEmployee.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEmployee.Location = new System.Drawing.Point(3, 16);
            this.dgEmployee.MultiSelect = false;
            this.dgEmployee.Name = "dgEmployee";
            this.dgEmployee.ReadOnly = true;
            this.dgEmployee.RowHeadersVisible = false;
            this.dgEmployee.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmployee.Size = new System.Drawing.Size(464, 192);
            this.dgEmployee.TabIndex = 0;
            this.dgEmployee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEmployee_CellDoubleClick);
            this.dgEmployee.SelectionChanged += new System.EventHandler(this.dgEmployee_SelectionChanged);
            // 
            // btnsec
            // 
            this.btnsec.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnsec.Location = new System.Drawing.Point(170, 338);
            this.btnsec.Name = "btnsec";
            this.btnsec.Size = new System.Drawing.Size(75, 23);
            this.btnsec.TabIndex = 4;
            this.btnsec.Text = "OK";
            this.btnsec.UseVisualStyleBackColor = true;
            this.btnsec.Click += new System.EventHandler(this.btnsec_Click);
            // 
            // btnclose
            // 
            this.btnclose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnclose.Location = new System.Drawing.Point(291, 338);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "Cancel";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // frmFindEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 373);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnsec);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "frmFindEmp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find STAFF";
            this.Load += new System.EventHandler(this.frmFindEmp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_employee)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtname;
        private System.Windows.Forms.Label lname;
        private System.Windows.Forms.TextBox edthname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtsname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnsec;
        public System.Windows.Forms.DataGridView dgEmployee;
        private System.Windows.Forms.Button btnclose;
        public System.Windows.Forms.PictureBox image_employee;
    }
}