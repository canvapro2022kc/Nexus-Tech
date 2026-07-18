namespace NexusTechUniversity
{
    partial class Student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Student));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btn_Logout = new ReaLTaiizor.Controls.Button();
            btnCurriculum = new Button();
            btnStudents = new Button();
            btnDashboard = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtboxSearchName = new TextBox();
            label4 = new Label();
            dgvStudent = new DataGridView();
            srCode = new DataGridViewTextBoxColumn();
            firstName = new DataGridViewTextBoxColumn();
            middleInitial = new DataGridViewTextBoxColumn();
            lastName = new DataGridViewTextBoxColumn();
            yearLevel = new DataGridViewTextBoxColumn();
            currentSemester = new DataGridViewTextBoxColumn();
            academicYear = new DataGridViewTextBoxColumn();
            btnEvaluation = new DataGridViewButtonColumn();
            btn_AddStudent = new ReaLTaiizor.Controls.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(btn_Logout);
            panel1.Controls.Add(btnCurriculum);
            panel1.Controls.Add(btnStudents);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 608);
            panel1.TabIndex = 1;
            // 
            // btn_Logout
            // 
            btn_Logout.BackColor = Color.Navy;
            btn_Logout.BorderColor = Color.FromArgb(3, 37, 83);
            btn_Logout.EnteredBorderColor = Color.FromArgb(3, 37, 83);
            btn_Logout.EnteredColor = Color.FromArgb(3, 37, 83);
            btn_Logout.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Logout.Image = null;
            btn_Logout.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Logout.InactiveColor = Color.FromArgb(3, 37, 83);
            btn_Logout.Location = new Point(47, 546);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.PressedBorderColor = Color.White;
            btn_Logout.PressedColor = Color.White;
            btn_Logout.Size = new Size(147, 34);
            btn_Logout.TabIndex = 15;
            btn_Logout.Text = "LOG OUT";
            btn_Logout.TextAlignment = StringAlignment.Center;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // btnCurriculum
            // 
            btnCurriculum.FlatAppearance.BorderSize = 0;
            btnCurriculum.FlatStyle = FlatStyle.Flat;
            btnCurriculum.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCurriculum.ForeColor = Color.White;
            btnCurriculum.Location = new Point(49, 195);
            btnCurriculum.Name = "btnCurriculum";
            btnCurriculum.Size = new Size(107, 37);
            btnCurriculum.TabIndex = 6;
            btnCurriculum.Text = "Curriculum";
            btnCurriculum.TextAlign = ContentAlignment.MiddleLeft;
            btnCurriculum.UseVisualStyleBackColor = true;
            btnCurriculum.Click += btnCurriculum_Click;
            // 
            // btnStudents
            // 
            btnStudents.FlatAppearance.BorderSize = 0;
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStudents.ForeColor = Color.White;
            btnStudents.Location = new Point(50, 151);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(107, 37);
            btnStudents.TabIndex = 5;
            btnStudents.Text = "Students";
            btnStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnStudents.UseVisualStyleBackColor = true;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(49, 108);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(107, 37);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(47, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(104, 61);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 2;
            label2.Text = "University";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(104, 41);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 1;
            label1.Text = "NexusTech";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(275, 49);
            label3.Name = "label3";
            label3.Size = new Size(112, 33);
            label3.TabIndex = 10;
            label3.Text = "Students";
            // 
            // txtboxSearchName
            // 
            txtboxSearchName.BackColor = Color.White;
            txtboxSearchName.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtboxSearchName.Location = new Point(711, 55);
            txtboxSearchName.Name = "txtboxSearchName";
            txtboxSearchName.Size = new Size(251, 24);
            txtboxSearchName.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(599, 58);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 12;
            label4.Text = "Search Name:";
            // 
            // dgvStudent
            // 
            dgvStudent.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvStudent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudent.Columns.AddRange(new DataGridViewColumn[] { srCode, firstName, middleInitial, lastName, yearLevel, currentSemester, academicYear, btnEvaluation });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvStudent.DefaultCellStyle = dataGridViewCellStyle4;
            dgvStudent.Location = new Point(275, 95);
            dgvStudent.Name = "dgvStudent";
            dgvStudent.RowHeadersVisible = false;
            dgvStudent.RowHeadersWidth = 51;
            dgvStudent.Size = new Size(836, 485);
            dgvStudent.TabIndex = 13;
            dgvStudent.CellContentClick += dgvStudent_CellContentClick;
            // 
            // srCode
            // 
            srCode.HeaderText = "SR-Code";
            srCode.MinimumWidth = 6;
            srCode.Name = "srCode";
            srCode.Width = 80;
            // 
            // firstName
            // 
            firstName.HeaderText = "First Name";
            firstName.MinimumWidth = 6;
            firstName.Name = "firstName";
            firstName.Width = 125;
            // 
            // middleInitial
            // 
            middleInitial.HeaderText = "M.I.";
            middleInitial.MinimumWidth = 6;
            middleInitial.Name = "middleInitial";
            middleInitial.Width = 50;
            // 
            // lastName
            // 
            lastName.HeaderText = "Last Name";
            lastName.MinimumWidth = 6;
            lastName.Name = "lastName";
            lastName.Width = 125;
            // 
            // yearLevel
            // 
            yearLevel.HeaderText = "Year Level";
            yearLevel.MinimumWidth = 6;
            yearLevel.Name = "yearLevel";
            yearLevel.Width = 125;
            // 
            // currentSemester
            // 
            currentSemester.HeaderText = "Semester";
            currentSemester.MinimumWidth = 6;
            currentSemester.Name = "currentSemester";
            currentSemester.Width = 125;
            // 
            // academicYear
            // 
            academicYear.HeaderText = "Curriculum Year";
            academicYear.MinimumWidth = 6;
            academicYear.Name = "academicYear";
            academicYear.Width = 125;
            // 
            // btnEvaluation
            // 
            btnEvaluation.HeaderText = "Evaluate";
            btnEvaluation.MinimumWidth = 6;
            btnEvaluation.Name = "btnEvaluation";
            btnEvaluation.Width = 80;
            // 
            // btn_AddStudent
            // 
            btn_AddStudent.BackColor = Color.Transparent;
            btn_AddStudent.BorderColor = Color.FromArgb(32, 34, 37);
            btn_AddStudent.EnteredBorderColor = Color.FromArgb(3, 37, 83);
            btn_AddStudent.EnteredColor = Color.FromArgb(3, 37, 83);
            btn_AddStudent.Font = new Font("Tw Cen MT", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddStudent.Image = null;
            btn_AddStudent.ImageAlign = ContentAlignment.MiddleLeft;
            btn_AddStudent.InactiveColor = Color.FromArgb(3, 37, 83);
            btn_AddStudent.Location = new Point(977, 55);
            btn_AddStudent.Name = "btn_AddStudent";
            btn_AddStudent.PressedBorderColor = Color.FromArgb(3, 37, 83);
            btn_AddStudent.PressedColor = Color.FromArgb(3, 37, 83);
            btn_AddStudent.Size = new Size(134, 27);
            btn_AddStudent.TabIndex = 14;
            btn_AddStudent.Text = "+ ADD STUDENT";
            btn_AddStudent.TextAlignment = StringAlignment.Center;
            btn_AddStudent.Click += btn_AddStudent_Click;
            // 
            // Student
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 608);
            Controls.Add(btn_AddStudent);
            Controls.Add(dgvStudent);
            Controls.Add(label4);
            Controls.Add(txtboxSearchName);
            Controls.Add(label3);
            Controls.Add(panel1);
            Name = "Student";
            Text = "Student";
            Load += Student_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCurriculum;
        private Button btnStudents;
        private Button btnDashboard;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtboxSearchName;
        private Label label4;
        private DataGridView dgvStudent;
        private ReaLTaiizor.Controls.Button btn_AddStudent;
        private ReaLTaiizor.Controls.Button btn_Logout;
        private DataGridViewTextBoxColumn srCode;
        private DataGridViewTextBoxColumn firstName;
        private DataGridViewTextBoxColumn middleInitial;
        private DataGridViewTextBoxColumn lastName;
        private DataGridViewTextBoxColumn yearLevel;
        private DataGridViewTextBoxColumn currentSemester;
        private DataGridViewTextBoxColumn academicYear;
        private DataGridViewButtonColumn btnEvaluation;
    }
}