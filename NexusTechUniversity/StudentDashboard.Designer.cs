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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            courseCode = new DataGridViewTextBoxColumn();
            courseName = new DataGridViewTextBoxColumn();
            courseDescription = new DataGridViewTextBoxColumn();
            units = new DataGridViewTextBoxColumn();
            remarks = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnAddStudent = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnAddStudent);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1133, 619);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Navy;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(951, 558);
            button1.Name = "button1";
            button1.Size = new Size(127, 31);
            button1.TabIndex = 11;
            button1.Text = "Export POS";
            button1.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { courseCode, courseName, courseDescription, units, remarks });
            dataGridView1.Location = new Point(481, 138);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(597, 401);
            dataGridView1.TabIndex = 10;
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
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(52, 138);
            panel2.Name = "panel2";
            panel2.Size = new Size(387, 166);
            panel2.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Navy;
            label6.Location = new Point(23, 68);
            label6.Name = "label6";
            label6.Size = new Size(331, 20);
            label6.TabIndex = 14;
            label6.Text = "• College of Infomatics and Computing Sciences";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Navy;
            label5.Location = new Point(23, 121);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 13;
            label5.Text = "• ENROLLED";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Navy;
            label3.Location = new Point(23, 96);
            label3.Name = "label3";
            label3.Size = new Size(113, 17);
            label3.TabIndex = 12;
            label3.Text = "• A.Y. 2025-2026";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(23, 30);
            label4.Name = "label4";
            label4.Size = new Size(143, 23);
            label4.TabIndex = 11;
            label4.Text = "FName M. LName";
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.White;
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStudent.ForeColor = Color.Navy;
            btnAddStudent.Location = new Point(951, 48);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(127, 31);
            btnAddStudent.TabIndex = 8;
            btnAddStudent.Text = "LOG OUT";
            btnAddStudent.UseVisualStyleBackColor = false;
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Label label3;
        private Label label4;
        private Button btnAddStudent;
        private Label label6;
        private Label label5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn courseCode;
        private DataGridViewTextBoxColumn courseName;
        private DataGridViewTextBoxColumn courseDescription;
        private DataGridViewTextBoxColumn units;
        private DataGridViewTextBoxColumn remarks;
        private Button button1;
    }
}