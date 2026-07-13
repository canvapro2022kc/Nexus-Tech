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
            panel1 = new Panel();
            btnExportPOS = new Button();
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
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
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
            panel1.Size = new Size(1133, 619);
            panel1.TabIndex = 0;
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
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(panel1);
            Name = "StudentDashboard";
            Text = "StudentDashboard";
            Load += StudentDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
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
        private Button btnExportPOS;
        private Label lblAcadYear;
    }
}