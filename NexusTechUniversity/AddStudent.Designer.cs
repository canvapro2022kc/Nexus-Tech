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
            label6 = new Label();
            txtboxFName = new TextBox();
            txtboxLName = new TextBox();
            txtboxMI = new TextBox();
            comboBox3 = new ComboBox();
            dgvStudents = new DataGridView();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAddStudent = new Button();
            button4 = new Button();
            txtboxCode = new TextBox();
            label10 = new Label();
            btnBack = new Button();
            label4 = new Label();
            comboBox4 = new ComboBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label8 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(55, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 31;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tw Cen MT Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(3, 37, 83);
            label7.Location = new Point(112, 49);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 30;
            label7.Text = "University";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(3, 37, 83);
            label9.Location = new Point(112, 29);
            label9.Name = "label9";
            label9.Size = new Size(90, 23);
            label9.TabIndex = 29;
            label9.Text = "NexusTech";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT", 9.75F);
            label1.Location = new Point(52, 163);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 32;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT", 9.75F);
            label2.Location = new Point(240, 163);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 33;
            label2.Text = "M.I:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 9.75F);
            label3.Location = new Point(316, 163);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 34;
            label3.Text = "Last Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tw Cen MT", 9.75F);
            label6.Location = new Point(182, 94);
            label6.Name = "label6";
            label6.Size = new Size(116, 20);
            label6.TabIndex = 37;
            label6.Text = "Academic Year:";
            // 
            // txtboxFName
            // 
            txtboxFName.Location = new Point(52, 188);
            txtboxFName.Margin = new Padding(3, 4, 3, 4);
            txtboxFName.Name = "txtboxFName";
            txtboxFName.Size = new Size(179, 27);
            txtboxFName.TabIndex = 38;
            // 
            // txtboxLName
            // 
            txtboxLName.Location = new Point(316, 188);
            txtboxLName.Margin = new Padding(3, 4, 3, 4);
            txtboxLName.Name = "txtboxLName";
            txtboxLName.Size = new Size(179, 27);
            txtboxLName.TabIndex = 39;
            // 
            // txtboxMI
            // 
            txtboxMI.Location = new Point(240, 188);
            txtboxMI.Margin = new Padding(3, 4, 3, 4);
            txtboxMI.Name = "txtboxMI";
            txtboxMI.Size = new Size(67, 27);
            txtboxMI.TabIndex = 43;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "2021-2022", "2022-2023", "2023-2024", "2024-2025", "2025-2026", "2026-2027" });
            comboBox3.Location = new Point(183, 117);
            comboBox3.Margin = new Padding(3, 4, 3, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(179, 28);
            comboBox3.TabIndex = 46;
            // 
            // dgvStudents
            // 
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(51, 236);
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
            btnDelete.BackColor = Color.FromArgb(3, 37, 83);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(913, 558);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 31);
            btnDelete.TabIndex = 55;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(3, 37, 83);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1000, 558);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 31);
            btnSave.TabIndex = 54;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(3, 37, 83);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(825, 558);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(82, 31);
            btnEdit.TabIndex = 53;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.FromArgb(3, 37, 83);
            btnAddStudent.FlatAppearance.BorderSize = 0;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(737, 558);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(82, 31);
            btnAddStudent.TabIndex = 52;
            btnAddStudent.Text = "ADD";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.DialogResult = DialogResult.Continue;
            button4.FlatAppearance.BorderColor = Color.Black;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Tw Cen MT Condensed Extra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(18, 28);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(21, 29);
            button4.TabIndex = 58;
            button4.UseVisualStyleBackColor = false;
            // 
            // txtboxCode
            // 
            txtboxCode.Location = new Point(51, 118);
            txtboxCode.Name = "txtboxCode";
            txtboxCode.Size = new Size(125, 27);
            txtboxCode.TabIndex = 59;
            txtboxCode.TextChanged += txtboxCode_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(51, 93);
            label10.Name = "label10";
            label10.Size = new Size(74, 20);
            label10.TabIndex = 60;
            label10.Text = "SR-Code:";
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
            btnBack.Location = new Point(21, 32);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(21, 29);
            btnBack.TabIndex = 61;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT", 9.75F);
            label4.Location = new Point(371, 95);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 35;
            label4.Text = "Year Level:";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Freshman", "Regular", "Transferee", "Irregular\t" });
            comboBox4.Location = new Point(750, 118);
            comboBox4.Margin = new Padding(3, 4, 3, 4);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(179, 28);
            comboBox4.TabIndex = 48;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "First Year", "Second Year", "Third Year", "Fourth Year", "Fifth Year" });
            comboBox1.Location = new Point(371, 118);
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
            comboBox2.Location = new Point(561, 118);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(179, 28);
            comboBox2.TabIndex = 45;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tw Cen MT", 9.75F);
            label8.Location = new Point(750, 95);
            label8.Name = "label8";
            label8.Size = new Size(103, 20);
            label8.TabIndex = 47;
            label8.Text = "Student Type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tw Cen MT", 9.75F);
            label5.Location = new Point(562, 95);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 36;
            label5.Text = "Semester:";
            // 
            // Add_Student
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 608);
            Controls.Add(btnBack);
            Controls.Add(label10);
            Controls.Add(txtboxCode);
            Controls.Add(button4);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(btnAddStudent);
            Controls.Add(dgvStudents);
            Controls.Add(comboBox4);
            Controls.Add(label8);
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
            Load += Add_Student_Load_2;
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
        private Label label6;
        private TextBox txtboxFName;
        private TextBox txtboxLName;
        private TextBox txtboxMI;
        private ComboBox comboBox3;
        private DataGridView dgvStudents;
        private Button btnDelete;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAddStudent;
        private Button button4;
        private Button btnLoadStudents;
        private TextBox txtboxCode;
        private Label label10;
        private Button btnBack;
        private Label label4;
        private ComboBox comboBox4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label8;
        private Label label5;
    }
}