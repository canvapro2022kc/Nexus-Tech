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
            courseTitle = new DataGridViewTextBoxColumn();
            units = new DataGridViewTextBoxColumn();
            yearLevel = new DataGridViewTextBoxColumn();
            semester = new DataGridViewTextBoxColumn();
            cacademicyear = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            lblAcadYear = new Label();
            lblDepartment = new Label();
            lblfName = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            btnLogout = new ReaLTaiizor.Controls.Button();
            btn_Export = new ReaLTaiizor.Controls.Button();
            btn_ChangePass = new ReaLTaiizor.Controls.Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCourses
            // 
            dgvCourses.BackgroundColor = Color.White;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] { courseCode, courseTitle, units, yearLevel, semester, cacademicyear });
            dgvCourses.Location = new Point(424, 129);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.Size = new Size(684, 401);
            dgvCourses.TabIndex = 10;
            dgvCourses.CellContentClick += dgvCourses_CellContentClick;
            // 
            // courseCode
            // 
            courseCode.HeaderText = "Course Code";
            courseCode.MinimumWidth = 6;
            courseCode.Name = "courseCode";
            courseCode.Width = 110;
            // 
            // courseTitle
            // 
            courseTitle.HeaderText = "Course Title";
            courseTitle.MinimumWidth = 6;
            courseTitle.Name = "courseTitle";
            courseTitle.Width = 110;
            // 
            // units
            // 
            units.HeaderText = "Units";
            units.MinimumWidth = 6;
            units.Name = "units";
            units.Width = 110;
            // 
            // yearLevel
            // 
            yearLevel.HeaderText = "Year Level";
            yearLevel.MinimumWidth = 6;
            yearLevel.Name = "yearLevel";
            yearLevel.Width = 110;
            // 
            // semester
            // 
            semester.HeaderText = "Semester";
            semester.MinimumWidth = 6;
            semester.Name = "semester";
            semester.Width = 110;
            // 
            // cacademicyear
            // 
            cacademicyear.HeaderText = "Pre-requisite/s";
            cacademicyear.MinimumWidth = 6;
            cacademicyear.Name = "cacademicyear";
            cacademicyear.Width = 135;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(lblAcadYear);
            panel2.Controls.Add(lblDepartment);
            panel2.Controls.Add(lblfName);
            panel2.Location = new Point(32, 129);
            panel2.Name = "panel2";
            panel2.Size = new Size(375, 314);
            panel2.TabIndex = 9;
            panel2.Paint += panel2_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.picpeople_filled__1_;
            pictureBox2.Location = new Point(122, 41);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(125, 130);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // lblAcadYear
            // 
            lblAcadYear.AutoSize = true;
            lblAcadYear.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAcadYear.ForeColor = Color.FromArgb(3, 37, 83);
            lblAcadYear.Location = new Point(21, 266);
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
            lblDepartment.ForeColor = Color.FromArgb(3, 37, 83);
            lblDepartment.Location = new Point(21, 236);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(331, 20);
            lblDepartment.TabIndex = 14;
            lblDepartment.Text = "• College of Infomatics and Computing Sciences";
            lblDepartment.Click += lblDepartment_Click;
            // 
            // lblfName
            // 
            lblfName.AutoSize = true;
            lblfName.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblfName.ForeColor = Color.FromArgb(3, 37, 83);
            lblfName.Location = new Point(112, 186);
            lblfName.Name = "lblfName";
            lblfName.Size = new Size(143, 23);
            lblfName.TabIndex = 11;
            lblfName.Text = "FName M. LName";
            lblfName.Click += lblfName_Click;
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
            label2.Font = new Font("Tw Cen MT Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(3, 37, 83);
            label2.Location = new Point(109, 73);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 6;
            label2.Text = "University";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(3, 37, 83);
            label1.Location = new Point(109, 52);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 5;
            label1.Text = "NexusTech";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btn_Export);
            panel1.Controls.Add(btn_ChangePass);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dgvCourses);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1140, 608);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.BorderColor = Color.FromArgb(32, 34, 37);
            btnLogout.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnLogout.EnteredColor = Color.FromArgb(32, 34, 37);
            btnLogout.Font = new Font("Tw Cen MT", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Image = null;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.InactiveColor = Color.FromArgb(3, 37, 83);
            btnLogout.Location = new Point(1011, 52);
            btnLogout.Name = "btnLogout";
            btnLogout.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnLogout.PressedColor = Color.FromArgb(165, 37, 37);
            btnLogout.Size = new Size(97, 31);
            btnLogout.TabIndex = 20;
            btnLogout.Text = "LOG OUT";
            btnLogout.TextAlignment = StringAlignment.Center;
            btnLogout.Click += btnLogout_Click;
            // 
            // btn_Export
            // 
            btn_Export.BackColor = Color.Transparent;
            btn_Export.BorderColor = Color.FromArgb(32, 34, 37);
            btn_Export.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btn_Export.EnteredColor = Color.FromArgb(32, 34, 37);
            btn_Export.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold);
            btn_Export.Image = null;
            btn_Export.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Export.InactiveColor = Color.FromArgb(3, 37, 83);
            btn_Export.Location = new Point(981, 548);
            btn_Export.Name = "btn_Export";
            btn_Export.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btn_Export.PressedColor = Color.FromArgb(165, 37, 37);
            btn_Export.Size = new Size(127, 32);
            btn_Export.TabIndex = 16;
            btn_Export.Text = "Export";
            btn_Export.TextAlignment = StringAlignment.Center;
            btn_Export.Click += btn_Export_Click;
            // 
            // btn_ChangePass
            // 
            btn_ChangePass.BackColor = Color.Transparent;
            btn_ChangePass.BorderColor = Color.FromArgb(32, 34, 37);
            btn_ChangePass.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btn_ChangePass.EnteredColor = Color.FromArgb(32, 34, 37);
            btn_ChangePass.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_ChangePass.Image = null;
            btn_ChangePass.ImageAlign = ContentAlignment.MiddleLeft;
            btn_ChangePass.InactiveColor = Color.FromArgb(3, 37, 83);
            btn_ChangePass.Location = new Point(32, 463);
            btn_ChangePass.Name = "btn_ChangePass";
            btn_ChangePass.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btn_ChangePass.PressedColor = Color.FromArgb(165, 37, 37);
            btn_ChangePass.Size = new Size(375, 47);
            btn_ChangePass.TabIndex = 14;
            btn_ChangePass.Text = "Change Password";
            btn_ChangePass.TextAlignment = StringAlignment.Center;
            btn_ChangePass.Click += btn_ChangePass_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Firebrick;
            label3.Location = new Point(32, 515);
            label3.Name = "label3";
            label3.Size = new Size(228, 15);
            label3.TabIndex = 13;
            label3.Text = "Required to change for security purposes.*";
            label3.Click += label3_Click;
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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private Label lblDepartment;
        private DataGridView dgvCourses;
        private Label lblAcadYear;
        private Panel panel1;
        private Label label3;
        private ReaLTaiizor.Controls.Button btn_ChangePass;
        private ReaLTaiizor.Controls.Button btn_Export;
        private PictureBox pictureBox2;
        private DataGridViewTextBoxColumn courseCode;
        private DataGridViewTextBoxColumn courseTitle;
        private DataGridViewTextBoxColumn units;
        private DataGridViewTextBoxColumn yearLevel;
        private DataGridViewTextBoxColumn semester;
        private DataGridViewTextBoxColumn cacademicyear;
        private ReaLTaiizor.Controls.Button btnLogout;
    }
}
