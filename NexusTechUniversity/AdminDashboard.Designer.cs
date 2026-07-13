namespace NexusTechUniversity
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            btnLogout = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAddStudent = new Button();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            btnCurriculum = new Button();
            label7 = new Label();
            pictureBox4 = new PictureBox();
            btnStudents = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Navy;
            btnLogout.Location = new Point(1003, 29);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(97, 43);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(437, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(99, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT Condensed Extra Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(549, 133);
            label2.Name = "label2";
            label2.Size = new Size(147, 40);
            label2.TabIndex = 2;
            label2.Text = "University";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(549, 96);
            label1.Name = "label1";
            label1.Size = new Size(180, 48);
            label1.TabIndex = 1;
            label1.Text = "NexusTech";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.AppWorkspace;
            label3.Location = new Point(437, 513);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(466, 573);
            label4.Name = "label4";
            label4.Size = new Size(210, 20);
            label4.TabIndex = 9;
            label4.Text = "© 2026 NexusTech University";
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.Navy;
            btnAddStudent.DialogResult = DialogResult.Continue;
            btnAddStudent.FlatAppearance.BorderColor = Color.Black;
            btnAddStudent.FlatAppearance.BorderSize = 2;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Tw Cen MT Condensed Extra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(222, 283);
            btnAddStudent.Margin = new Padding(3, 4, 3, 4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(203, 185);
            btnAddStudent.TabIndex = 0;
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Navy;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(301, 332);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 45);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Navy;
            label5.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(256, 390);
            label5.Name = "label5";
            label5.Size = new Size(138, 23);
            label5.TabIndex = 10;
            label5.Text = "Add New Student";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Navy;
            label6.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(765, 390);
            label6.Name = "label6";
            label6.Size = new Size(91, 23);
            label6.TabIndex = 13;
            label6.Text = "Curriculum";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Navy;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(784, 332);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(49, 45);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // btnCurriculum
            // 
            btnCurriculum.BackColor = Color.Navy;
            btnCurriculum.DialogResult = DialogResult.Continue;
            btnCurriculum.FlatAppearance.BorderColor = Color.Black;
            btnCurriculum.FlatAppearance.BorderSize = 2;
            btnCurriculum.FlatStyle = FlatStyle.Flat;
            btnCurriculum.Font = new Font("Tw Cen MT Condensed Extra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCurriculum.ForeColor = Color.White;
            btnCurriculum.Location = new Point(707, 283);
            btnCurriculum.Margin = new Padding(3, 4, 3, 4);
            btnCurriculum.Name = "btnCurriculum";
            btnCurriculum.Size = new Size(203, 185);
            btnCurriculum.TabIndex = 11;
            btnCurriculum.UseVisualStyleBackColor = false;
            btnCurriculum.Click += btnCurriculum_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(248, 180, 0);
            label7.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Navy;
            label7.Location = new Point(532, 390);
            label7.Name = "label7";
            label7.Size = new Size(73, 23);
            label7.TabIndex = 16;
            label7.Text = "Students";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(248, 180, 0);
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(542, 332);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(49, 45);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 15;
            pictureBox4.TabStop = false;
            // 
            // btnStudents
            // 
            btnStudents.BackColor = Color.FromArgb(248, 180, 0);
            btnStudents.DialogResult = DialogResult.Continue;
            btnStudents.FlatAppearance.BorderColor = Color.Black;
            btnStudents.FlatAppearance.BorderSize = 2;
            btnStudents.FlatStyle = FlatStyle.Flat;
            btnStudents.Font = new Font("Tw Cen MT Condensed Extra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStudents.ForeColor = Color.White;
            btnStudents.Location = new Point(466, 283);
            btnStudents.Margin = new Padding(3, 4, 3, 4);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(203, 185);
            btnStudents.TabIndex = 14;
            btnStudents.UseVisualStyleBackColor = false;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(label7);
            Controls.Add(pictureBox4);
            Controls.Add(btnStudents);
            Controls.Add(label6);
            Controls.Add(pictureBox3);
            Controls.Add(btnCurriculum);
            Controls.Add(label5);
            Controls.Add(pictureBox2);
            Controls.Add(label4);
            Controls.Add(btnAddStudent);
            Controls.Add(label3);
            Controls.Add(btnLogout);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            Load += AdminDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnLogout;
        private Label label3;
        private Label label4;
        private Button btnAddStudent;
        private PictureBox pictureBox2;
        private Label label5;
        private Label label6;
        private PictureBox pictureBox3;
        private Button btnCurriculum;
        private Label label7;
        private PictureBox pictureBox4;
        private Button btnStudents;
    }
}