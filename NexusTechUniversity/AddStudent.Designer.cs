namespace NexusTechUniversity
{
    partial class AddStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStudent));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            label9 = new Label();
            btnLoad = new Button();
            comboBox3 = new ComboBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            textBox3 = new TextBox();
            dgvNewStudent = new DataGridView();
            label6 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            panel2 = new Panel();
            btnAddStudent = new Button();
            dgvCoursesTaken = new DataGridView();
            label8 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNewStudent).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCoursesTaken).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(dgvNewStudent);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(22, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(612, 595);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(28, 5);
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
            label7.Location = new Point(85, 30);
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
            label9.Location = new Point(85, 9);
            label9.Name = "label9";
            label9.Size = new Size(90, 23);
            label9.TabIndex = 23;
            label9.Text = "NexusTech";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(488, 187);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 22;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(225, 140);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(152, 28);
            comboBox3.TabIndex = 21;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(409, 140);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(152, 28);
            comboBox1.TabIndex = 20;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(36, 140);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(152, 28);
            comboBox2.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 117);
            label4.Name = "label4";
            label4.Size = new Size(110, 20);
            label4.TabIndex = 15;
            label4.Text = "Academic Year:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(340, 86);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(221, 27);
            textBox3.TabIndex = 14;
            // 
            // dgvNewStudent
            // 
            dgvNewStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNewStudent.Location = new Point(17, 227);
            dgvNewStudent.Name = "dgvNewStudent";
            dgvNewStudent.RowHeadersWidth = 51;
            dgvNewStudent.Size = new Size(565, 322);
            dgvNewStudent.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(225, 117);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 11;
            label6.Text = "Semester:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 117);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 9;
            label5.Text = "Year Level:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(276, 86);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(48, 27);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(276, 63);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 3;
            label3.Text = "M.I:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(340, 63);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 2;
            label2.Text = "Last Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 63);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 1;
            label1.Text = "First Name:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 27);
            textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnAddStudent);
            panel2.Controls.Add(dgvCoursesTaken);
            panel2.Controls.Add(label8);
            panel2.Location = new Point(653, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(468, 595);
            panel2.TabIndex = 1;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.Navy;
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(327, 560);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(127, 31);
            btnAddStudent.TabIndex = 13;
            btnAddStudent.Text = "Evaluate";
            btnAddStudent.UseVisualStyleBackColor = false;
            // 
            // dgvCoursesTaken
            // 
            dgvCoursesTaken.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCoursesTaken.Location = new Point(13, 53);
            dgvCoursesTaken.Name = "dgvCoursesTaken";
            dgvCoursesTaken.RowHeadersWidth = 51;
            dgvCoursesTaken.Size = new Size(441, 496);
            dgvCoursesTaken.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tw Cen MT", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Navy;
            label8.Location = new Point(3, 2);
            label8.Name = "label8";
            label8.Size = new Size(183, 33);
            label8.TabIndex = 11;
            label8.Text = "Courses Taken";
            // 
            // AddStudent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AddStudent";
            Text = "AddStudent";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNewStudent).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCoursesTaken).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label6;
        private DataGridView dgvNewStudent;
        private ComboBox comboBox3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label4;
        private TextBox textBox3;
        private Button btnLoad;
        private Panel panel2;
        private Label label8;
        private DataGridView dgvCoursesTaken;
        private Button btnAddStudent;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label9;
    }
}