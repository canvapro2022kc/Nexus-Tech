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
            panel1 = new Panel();
            btnLogout = new Button();
            btnCurriculum = new Button();
            btnStudents = new Button();
            btnDashboard = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            dgvOldStudent = new DataGridView();
            btnAddStudent = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            srCode = new DataGridViewTextBoxColumn();
            firstName = new DataGridViewTextBoxColumn();
            middleInitial = new DataGridViewTextBoxColumn();
            lastName = new DataGridViewTextBoxColumn();
            btnEnroll = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOldStudent).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnCurriculum);
            panel1.Controls.Add(btnStudents);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 619);
            panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Navy;
            btnLogout.Location = new Point(46, 552);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(161, 40);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnCurriculum
            // 
            btnCurriculum.FlatAppearance.BorderSize = 0;
            btnCurriculum.FlatStyle = FlatStyle.Flat;
            btnCurriculum.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCurriculum.ForeColor = Color.White;
            btnCurriculum.Location = new Point(49, 194);
            btnCurriculum.Name = "btnCurriculum";
            btnCurriculum.Size = new Size(107, 37);
            btnCurriculum.TabIndex = 6;
            btnCurriculum.Text = "Curriculum";
            btnCurriculum.TextAlign = ContentAlignment.MiddleLeft;
            btnCurriculum.UseVisualStyleBackColor = true;
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
            label2.Font = new Font("Tw Cen MT Condensed Extra Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(104, 62);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
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
            // dgvOldStudent
            // 
            dgvOldStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOldStudent.Columns.AddRange(new DataGridViewColumn[] { srCode, firstName, middleInitial, lastName, btnEnroll });
            dgvOldStudent.Location = new Point(281, 171);
            dgvOldStudent.Name = "dgvOldStudent";
            dgvOldStudent.RowHeadersVisible = false;
            dgvOldStudent.RowHeadersWidth = 51;
            dgvOldStudent.Size = new Size(815, 398);
            dgvOldStudent.TabIndex = 2;
            dgvOldStudent.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.Navy;
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(969, 114);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(127, 31);
            btnAddStudent.TabIndex = 3;
            btnAddStudent.Text = "+  Add Student";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(281, 49);
            label3.Name = "label3";
            label3.Size = new Size(112, 33);
            label3.TabIndex = 10;
            label3.Text = "Students";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(359, 119);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 27);
            textBox1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(281, 125);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 12;
            label4.Text = "SR-Code:";
            // 
            // srCode
            // 
            srCode.HeaderText = "SR-Code";
            srCode.MinimumWidth = 6;
            srCode.Name = "srCode";
            srCode.Width = 125;
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
            middleInitial.Width = 125;
            // 
            // lastName
            // 
            lastName.HeaderText = "Last Name";
            lastName.MinimumWidth = 6;
            lastName.Name = "lastName";
            lastName.Width = 125;
            // 
            // btnEnroll
            // 
            btnEnroll.HeaderText = "Enroll";
            btnEnroll.MinimumWidth = 6;
            btnEnroll.Name = "btnEnroll";
            btnEnroll.Width = 125;
            // 
            // Student
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(btnAddStudent);
            Controls.Add(dgvOldStudent);
            Controls.Add(panel1);
            Name = "Student";
            Text = "Student";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOldStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnLogout;
        private Button btnCurriculum;
        private Button btnStudents;
        private Button btnDashboard;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private DataGridView dgvOldStudent;
        private Button btnAddStudent;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private DataGridViewTextBoxColumn srCode;
        private DataGridViewTextBoxColumn firstName;
        private DataGridViewTextBoxColumn middleInitial;
        private DataGridViewTextBoxColumn lastName;
        private DataGridViewButtonColumn btnEnroll;
    }
}