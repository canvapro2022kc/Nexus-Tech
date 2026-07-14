namespace NexusTechUniversity
{
    partial class StudentDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDashboard));
            dgvCourses = new DataGridView();
            courseCode = new DataGridViewTextBoxColumn();
            courseName = new DataGridViewTextBoxColumn();
            courseDescription = new DataGridViewTextBoxColumn();
            units = new DataGridViewTextBoxColumn();
            remarks = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            lblAcadYear = new Label();
            lblDepartment = new Label();
            lblStatus = new Label();
            lblfName = new Label();
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            btnExportPOS = new Button();
            panel1 = new Panel();
            btnChangePassword = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCourses
            // 
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] { courseCode, courseName, courseDescription, units, remarks });
            dgvCourses.Location = new Point(481, 138);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.Size = new Size(597, 401);
            dgvCourses.TabIndex = 10;
            dgvCourses.CellContentClick += dgvCourses_CellContentClick;
            // 
            // courseCode
            // 
            courseCode.HeaderText = "Course Code";
            courseCode.MinimumWidth = 6;
            courseCode.Name = "courseCode";
            courseCode.Width = 125;
            // 
            // courseName
            // 
            courseName.HeaderText = "Course Name";
            courseName.MinimumWidth = 6;
            courseName.Name = "courseName";
            courseName.Width = 125;
            // 
            // courseDescription
            // 
            courseDescription.HeaderText = "Course Description";
            courseDescription.MinimumWidth = 6;
            courseDescription.Name = "courseDescription";
            courseDescription.Width = 125;
            // 
            // units
            // 
            units.HeaderText = "Units";
            units.MinimumWidth = 6;
            units.Name = "units";
            units.Width = 125;
            // 
            // remarks
            // 
            remarks.HeaderText = "Remarks";
            remarks.MinimumWidth = 6;
            remarks.Name = "remarks";
            remarks.Width = 125;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblAcadYear);
            panel2.Controls.Add(lblDepartment);
            panel2.Controls.Add(lblStatus);
            panel2.Controls.Add(lblfName);
            panel2.Location = new Point(52, 138);
            panel2.Name = "panel2";
            panel2.Size = new Size(387, 166);
            panel2.TabIndex = 9;
            // 
            // lblAcadYear
            // 
            lblAcadYear.AutoSize = true;
            lblAcadYear.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAcadYear.ForeColor = Color.Navy;
            lblAcadYear.Location = new Point(23, 92);
            lblAcadYear.Name = "lblAcadYear";
            lblAcadYear.Size = new Size(113, 17);
            lblAcadYear.TabIndex = 15;
            lblAcadYear.Text = "• A.Y. 2025-2026";
            lblAcadYear.Click += lblAcadyear_Click;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepartment.ForeColor = Color.Navy;
            lblDepartment.Location = new Point(23, 61);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(331, 20);
            lblDepartment.TabIndex = 14;
            lblDepartment.Text = "• College of Infomatics and Computing Sciences";
            lblDepartment.Click += lblDepartment_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Navy;
            lblStatus.Location = new Point(22, 119);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 20);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "• ENROLLED";
            // 
            // lblfName
            // 
            lblfName.AutoSize = true;
            lblfName.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblfName.ForeColor = Color.Navy;
            lblfName.Location = new Point(23, 28);
            lblfName.Name = "lblfName";
            lblfName.Size = new Size(143, 23);
            lblfName.TabIndex = 11;
            lblfName.Text = "FName M. LName";
            lblfName.Click += lblfName_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.White;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Navy;
            btnLogout.Location = new Point(951, 48);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(127, 31);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(52, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT Condensed Extra Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(109, 73);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 6;
            label2.Text = "University";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(109, 52);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 5;
            label1.Text = "NexusTech";
            // 
            // btnExportPOS
            // 
            btnExportPOS.BackColor = Color.Navy;
            btnExportPOS.FlatAppearance.BorderSize = 0;
            btnExportPOS.FlatStyle = FlatStyle.Flat;
            btnExportPOS.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportPOS.ForeColor = Color.White;
            btnExportPOS.Location = new Point(951, 558);
            btnExportPOS.Name = "btnExportPOS";
            btnExportPOS.Size = new Size(127, 31);
            btnExportPOS.TabIndex = 11;
            btnExportPOS.Text = "Export POS";
            btnExportPOS.UseVisualStyleBackColor = false;
            btnExportPOS.Click += btnExportPOS_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnChangePassword);
            panel1.Controls.Add(btnExportPOS);
            panel1.Controls.Add(dgvCourses);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1140, 608);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.Navy;
            btnChangePassword.Font = new Font("Tw Cen MT Condensed Extra Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = Color.GhostWhite;
            btnChangePassword.Location = new Point(75, 319);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(331, 29);
            btnChangePassword.TabIndex = 12;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(87, 347);
            label3.Name = "label3";
            label3.Size = new Size(233, 15);
            label3.TabIndex = 13;
            label3.Text = "* Required to change for security purposes";
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 608);
            Controls.Add(panel1);
            Name = "StudentDashboard";
            Text = "StudentDashboard";
            Load += StudentDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private Label lblfName;
        private Button btnLogout;
        private Label lblDepartment;
        private Label lblStatus;
        private DataGridView dgvCourses;
        private DataGridViewTextBoxColumn courseCode;
        private DataGridViewTextBoxColumn courseName;
        private DataGridViewTextBoxColumn courseDescription;
        private DataGridViewTextBoxColumn units;
        private DataGridViewTextBoxColumn remarks;
        private Label lblAcadYear;
        private Button btnExportPOS;
        private Panel panel1;
        private Label label3;
        private Button btnChangePassword;
    }
}
