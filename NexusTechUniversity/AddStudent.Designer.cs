namespace NexusTechUniversity
{
    partial class Add_Student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Student));
            pictureBox1 = new PictureBox();
            label7 = new Label();
            label9 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtboxFName = new TextBox();
            txtboxLName = new TextBox();
            txtboxMI = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            label8 = new Label();
            dgvStudents = new DataGridView();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAddStudent = new Button();
            button4 = new Button();
            label10 = new Label();
            txtboxCode = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(49, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 31;
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
            label7.TabIndex = 30;
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
            label9.TabIndex = 29;
            label9.Text = "NexusTech";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT", 9.75F);
            label1.Location = new Point(48, 104);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 32;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT", 9.75F);
            label2.Location = new Point(235, 104);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 33;
            label2.Text = "M.I:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 9.75F);
            label3.Location = new Point(312, 104);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 34;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT", 9.75F);
            label4.Location = new Point(505, 104);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 35;
            label4.Text = "Year Level:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tw Cen MT", 9.75F);
            label5.Location = new Point(703, 104);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 36;
            label5.Text = "Semester:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tw Cen MT", 9.75F);
            label6.Location = new Point(899, 104);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 37;
            label6.Text = "Academic Year:";
            // 
            // txtboxFName
            // 
            txtboxFName.Location = new Point(48, 129);
            txtboxFName.Margin = new Padding(3, 4, 3, 4);
            txtboxFName.Name = "txtboxFName";
            txtboxFName.Size = new Size(179, 27);
            txtboxFName.TabIndex = 38;
            // 
            // txtboxLName
            // 
            txtboxLName.Location = new Point(312, 129);
            txtboxLName.Margin = new Padding(3, 4, 3, 4);
            txtboxLName.Name = "txtboxLName";
            txtboxLName.Size = new Size(179, 27);
            txtboxLName.TabIndex = 39;
            // 
            // txtboxMI
            // 
            txtboxMI.Location = new Point(235, 129);
            txtboxMI.Margin = new Padding(3, 4, 3, 4);
            txtboxMI.Name = "txtboxMI";
            txtboxMI.Size = new Size(67, 27);
            txtboxMI.TabIndex = 43;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "First Year", "Second Year", "Third Year", "Fourth Year", "Fifth Year" });
            comboBox1.Location = new Point(505, 129);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(179, 28);
            comboBox1.TabIndex = 44;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "First Semester", "Second Semester", "Midterm" });
            comboBox2.Location = new Point(703, 129);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(179, 28);
            comboBox2.TabIndex = 45;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "2021-2022", "2022-2023", "2023-2024", "2024-2025", "2025-2026", "2026-2027" });
            comboBox3.Location = new Point(899, 128);
            comboBox3.Margin = new Padding(3, 4, 3, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(179, 28);
            comboBox3.TabIndex = 46;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Freshman", "Transferee", "Irregular\t" });
            comboBox4.Location = new Point(48, 191);
            comboBox4.Margin = new Padding(3, 4, 3, 4);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(179, 28);
            comboBox4.TabIndex = 48;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tw Cen MT", 9.75F);
            label8.Location = new Point(48, 164);
            label8.Name = "label8";
            label8.Size = new Size(103, 20);
            label8.TabIndex = 47;
            label8.Text = "Student Type:";
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(48, 243);
            dgvStudents.Margin = new Padding(3, 4, 3, 4);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1031, 307);
            dgvStudents.TabIndex = 51;
            dgvStudents.CellClick += dataStudents_CellContentClick;
            dgvStudents.CellContentClick += dataStudents_CellContentClick;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Navy;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(998, 565);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 31);
            btnDelete.TabIndex = 55;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Navy;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(910, 565);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 31);
            btnSave.TabIndex = 54;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Navy;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(822, 565);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(82, 31);
            btnEdit.TabIndex = 53;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.Navy;
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(734, 565);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(82, 31);
            btnAddStudent.TabIndex = 52;
            btnAddStudent.Text = "Add";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnBack
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.DialogResult = DialogResult.Continue;
            button4.FlatAppearance.BorderColor = Color.Black;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Tw Cen MT Condensed Extra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(18, 28);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(21, 29);
            button4.TabIndex = 58;
            button4.UseVisualStyleBackColor = false;
            // 
            // btnLoadStudents
            // 
            btnLoadStudents.BackColor = Color.Navy;
            btnLoadStudents.FlatAppearance.BorderSize = 0;
            btnLoadStudents.FlatStyle = FlatStyle.Flat;
            btnLoadStudents.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadStudents.ForeColor = Color.White;
            btnLoadStudents.Location = new Point(49, 565);
            btnLoadStudents.Name = "btnLoadStudents";
            btnLoadStudents.Size = new Size(118, 31);
            btnLoadStudents.TabIndex = 59;
            btnLoadStudents.Text = "Load Students";
            btnLoadStudents.UseVisualStyleBackColor = false;
            btnLoadStudents.Click += btnLoadStudents_Click;
            // 
            // Add_Student
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(btnLoadStudents);
            Controls.Add(button4);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(btnAddStudent);
            Controls.Add(dgvStudents);
            Controls.Add(comboBox4);
            Controls.Add(label8);
            Controls.Add(label10);
            Controls.Add(txtboxCode);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(txtboxMI);
            Controls.Add(txtboxLName);
            Controls.Add(txtboxFName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(label7);
            Controls.Add(label9);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Add_Student";
            Text = "Add_Student";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label7;
        private Label label9;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtboxFName;
        private TextBox txtboxLName;
        private TextBox txtboxMI;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private TextBox txtboxCode;
        private Label label8;
        private DataGridView dgvStudents;
        private Button btnDelete;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAddStudent;
        private Button button4;
        private Button btnLoadStudents;
        private Label label10;
    }
}