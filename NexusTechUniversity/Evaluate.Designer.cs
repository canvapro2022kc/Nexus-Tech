namespace NexusTechUniversity
{
    partial class Evaluate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Evaluate));
            panel1 = new Panel();
            label8 = new Label();
            dataGridView1 = new DataGridView();
            btnAddStudent = new Button();
            courseCode = new DataGridViewTextBoxColumn();
            courseTitle = new DataGridViewTextBoxColumn();
            courseDescription = new DataGridViewTextBoxColumn();
            units = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnAddStudent);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label8);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1133, 619);
            panel1.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tw Cen MT", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Navy;
            label8.Location = new Point(32, 73);
            label8.Name = "label8";
            label8.Size = new Size(152, 33);
            label8.TabIndex = 12;
            label8.Text = "Assignment";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { courseCode, courseTitle, courseDescription, units });
            dataGridView1.Location = new Point(28, 119);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1082, 429);
            dataGridView1.TabIndex = 13;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.Navy;
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(932, 567);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(178, 31);
            btnAddStudent.TabIndex = 14;
            btnAddStudent.Text = "Assign to Student";
            btnAddStudent.UseVisualStyleBackColor = false;
            // 
            // courseCode
            // 
            courseCode.HeaderText = "Course Code";
            courseCode.MinimumWidth = 6;
            courseCode.Name = "courseCode";
            courseCode.Width = 125;
            // 
            // courseTitle
            // 
            courseTitle.HeaderText = "Course Title";
            courseTitle.MinimumWidth = 6;
            courseTitle.Name = "courseTitle";
            courseTitle.Width = 125;
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(32, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tw Cen MT Condensed Extra Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Navy;
            label7.Location = new Point(89, 39);
            label7.Name = "label7";
            label7.Size = new Size(74, 21);
            label7.TabIndex = 27;
            label7.Text = "University";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Navy;
            label9.Location = new Point(89, 18);
            label9.Name = "label9";
            label9.Size = new Size(90, 23);
            label9.TabIndex = 26;
            label9.Text = "NexusTech";
            // 
            // Evaluate
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(panel1);
            Name = "Evaluate";
            Text = "Evaluate";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label8;
        private Button btnAddStudent;
        private DataGridViewTextBoxColumn courseCode;
        private DataGridViewTextBoxColumn courseTitle;
        private DataGridViewTextBoxColumn courseDescription;
        private DataGridViewTextBoxColumn units;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label9;
    }
}