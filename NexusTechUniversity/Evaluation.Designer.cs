namespace NexusTechUniversity
{
    partial class Evaluation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Evaluation));
            panel1 = new Panel();
            label1 = new Label();
            dgvStudents = new DataGridView();
            btnBack = new Button();
            btnEvaluate = new Button();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            label9 = new Label();
            dgvCourses = new DataGridView();
            panel2 = new Panel();
            button1 = new Button();
            label12 = new Label();
            dgvProgramOfStudy = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProgramOfStudy).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dgvStudents);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(btnEvaluate);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(dgvCourses);
            panel1.Location = new Point(22, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(613, 595);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(30, 90);
            label1.Name = "label1";
            label1.Size = new Size(187, 31);
            label1.TabIndex = 63;
            label1.Text = "Student Details:";
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(30, 124);
            dgvStudents.Margin = new Padding(3, 4, 3, 4);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(568, 77);
            dgvStudents.TabIndex = 62;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick_1;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.BackgroundImage = (Image)resources.GetObject("btnBack.BackgroundImage");
            btnBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnBack.DialogResult = DialogResult.Continue;
            btnBack.FlatAppearance.BorderColor = Color.Black;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Tw Cen MT Condensed Extra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(18, 28);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(21, 29);
            btnBack.TabIndex = 61;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnEvaluate
            // 
            btnEvaluate.BackColor = Color.Navy;
            btnEvaluate.FlatAppearance.BorderSize = 0;
            btnEvaluate.FlatStyle = FlatStyle.Flat;
            btnEvaluate.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEvaluate.ForeColor = Color.White;
            btnEvaluate.Location = new Point(471, 556);
            btnEvaluate.Name = "btnEvaluate";
            btnEvaluate.Size = new Size(127, 31);
            btnEvaluate.TabIndex = 13;
            btnEvaluate.Text = "Evaluate";
            btnEvaluate.UseVisualStyleBackColor = false;
            btnEvaluate.Click += btnEvaluate_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tw Cen MT", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Navy;
            label8.Location = new Point(30, 217);
            label8.Name = "label8";
            label8.Size = new Size(110, 31);
            label8.TabIndex = 11;
            label8.Text = "Courses ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tw Cen MT Condensed Extra Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Navy;
            label7.Location = new Point(106, 43);
            label7.Name = "label7";
            label7.Size = new Size(74, 21);
            label7.TabIndex = 24;
            label7.Text = "University";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Navy;
            label9.Location = new Point(106, 23);
            label9.Name = "label9";
            label9.Size = new Size(90, 23);
            label9.TabIndex = 23;
            label9.Text = "NexusTech";
            // 
            // dgvCourses
            // 
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(30, 251);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.Size = new Size(568, 297);
            dgvCourses.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(dgvProgramOfStudy);
            panel2.Location = new Point(653, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(469, 595);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(13, 556);
            button1.Name = "button1";
            button1.Size = new Size(441, 31);
            button1.TabIndex = 58;
            button1.Text = "Print Program of Study";
            button1.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Tw Cen MT", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Navy;
            label12.Location = new Point(13, 13);
            label12.Name = "label12";
            label12.Size = new Size(218, 33);
            label12.TabIndex = 58;
            label12.Text = "Program of Study";
            // 
            // dgvProgramOfStudy
            // 
            dgvProgramOfStudy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProgramOfStudy.Location = new Point(13, 53);
            dgvProgramOfStudy.Name = "dgvProgramOfStudy";
            dgvProgramOfStudy.RowHeadersWidth = 51;
            dgvProgramOfStudy.Size = new Size(441, 497);
            dgvProgramOfStudy.TabIndex = 12;
            // 
            // Evaluation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Evaluation";
            Text = "AddStudent";
            Load += Evaluation_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProgramOfStudy).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvNewStudent;
        private Panel panel2;
        private Label label8;
        private DataGridView dgvCoursesTaken;
        private Button btnAddStudent;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label9;
        private Button button1;
        private Label label12;
        private Button btnBack;
        private DataGridView dgvStudents;
        private Label label1;
        private Button btnEvaluate;
        private DataGridView dgvCourses;
        private DataGridView dgvProgramOfStudy;
    }
}