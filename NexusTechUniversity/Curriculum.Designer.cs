namespace NexusTechUniversity
{
    partial class Curriculum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Curriculum));
            panel2 = new Panel();
            label14 = new Label();
            textBox1 = new TextBox();
            comboBoxSem = new ComboBox();
            comboBoxLevel = new ComboBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtboxTrack = new TextBox();
            txtboxType = new TextBox();
            txtboxPreReq = new TextBox();
            txtboxLab = new TextBox();
            button4 = new Button();
            txtboxLec = new TextBox();
            pictureBox1 = new PictureBox();
            txtboxUnits = new TextBox();
            label2 = new Label();
            txtboxTitle = new TextBox();
            label1 = new Label();
            txtboxCode = new TextBox();
            comboBoxTrack = new ComboBox();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAddCourse = new Button();
            label8 = new Label();
            comboBoxCurriculum = new ComboBox();
            dgvCurriculum = new DataGridView();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCurriculum).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label14);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(comboBoxSem);
            panel2.Controls.Add(comboBoxLevel);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtboxTrack);
            panel2.Controls.Add(txtboxType);
            panel2.Controls.Add(txtboxPreReq);
            panel2.Controls.Add(txtboxLab);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(txtboxLec);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(txtboxUnits);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtboxTitle);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtboxCode);
            panel2.Controls.Add(comboBoxTrack);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnAddCourse);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(comboBoxCurriculum);
            panel2.Controls.Add(dgvCurriculum);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1140, 608);
            panel2.TabIndex = 3;
            panel2.Paint += panel2_Paint;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = SystemColors.Control;
            label14.Font = new Font("Tw Cen MT", 9F);
            label14.Location = new Point(34, 308);
            label14.Name = "label14";
            label14.Size = new Size(102, 17);
            label14.TabIndex = 79;
            label14.Text = "Academic Year:";
            label14.Click += label14_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(35, 328);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(155, 27);
            textBox1.TabIndex = 78;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // comboBoxSem
            // 
            comboBoxSem.BackColor = Color.White;
            comboBoxSem.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBoxSem.ForeColor = SystemColors.Window;
            comboBoxSem.FormattingEnabled = true;
            comboBoxSem.Items.AddRange(new object[] { "First Semester", "Second Semester", "Midterm" });
            comboBoxSem.Location = new Point(34, 387);
            comboBoxSem.Name = "comboBoxSem";
            comboBoxSem.Size = new Size(162, 25);
            comboBoxSem.TabIndex = 77;
            comboBoxSem.SelectedIndexChanged += comboBoxSem_SelectedIndexChanged;
            // 
            // comboBoxLevel
            // 
            comboBoxLevel.BackColor = Color.White;
            comboBoxLevel.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBoxLevel.ForeColor = SystemColors.Window;
            comboBoxLevel.FormattingEnabled = true;
            comboBoxLevel.Items.AddRange(new object[] { "First Year", "Second Year", "Third Year", "Fourth Year", "Fifth Year" });
            comboBoxLevel.Location = new Point(202, 330);
            comboBoxLevel.Name = "comboBoxLevel";
            comboBoxLevel.Size = new Size(162, 25);
            comboBoxLevel.TabIndex = 76;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.Control;
            label13.Font = new Font("Tw Cen MT", 9F);
            label13.Location = new Point(34, 367);
            label13.Name = "label13";
            label13.Size = new Size(67, 17);
            label13.TabIndex = 75;
            label13.Text = "Semester:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.Control;
            label12.Font = new Font("Tw Cen MT", 9F);
            label12.Location = new Point(202, 308);
            label12.Name = "label12";
            label12.Size = new Size(76, 17);
            label12.TabIndex = 74;
            label12.Text = "Year Level:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Control;
            label11.Font = new Font("Tw Cen MT", 9F);
            label11.Location = new Point(173, 248);
            label11.Name = "label11";
            label11.Size = new Size(44, 17);
            label11.TabIndex = 73;
            label11.Text = "Track:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.Control;
            label10.Font = new Font("Tw Cen MT", 9F);
            label10.Location = new Point(35, 248);
            label10.Name = "label10";
            label10.Size = new Size(108, 17);
            label10.TabIndex = 72;
            label10.Text = "Curriculum Type:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.Control;
            label9.Font = new Font("Tw Cen MT", 9F);
            label9.Location = new Point(220, 189);
            label9.Name = "label9";
            label9.Size = new Size(91, 17);
            label9.TabIndex = 71;
            label9.Text = "Pre-Requisite:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Control;
            label7.Font = new Font("Tw Cen MT", 9F);
            label7.Location = new Point(121, 189);
            label7.Name = "label7";
            label7.Size = new Size(79, 17);
            label7.TabIndex = 70;
            label7.Text = "Laboratory:";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Control;
            label6.Font = new Font("Tw Cen MT", 9F);
            label6.Location = new Point(35, 189);
            label6.Name = "label6";
            label6.Size = new Size(55, 17);
            label6.TabIndex = 69;
            label6.Text = "Lecture:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Tw Cen MT", 9F);
            label5.Location = new Point(306, 128);
            label5.Name = "label5";
            label5.Size = new Size(39, 17);
            label5.TabIndex = 68;
            label5.Text = "Units:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Tw Cen MT", 9F);
            label4.Location = new Point(147, 128);
            label4.Name = "label4";
            label4.Size = new Size(82, 17);
            label4.TabIndex = 67;
            label4.Text = "Course Title:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Tw Cen MT", 9F);
            label3.Location = new Point(35, 128);
            label3.Name = "label3";
            label3.Size = new Size(90, 17);
            label3.TabIndex = 66;
            label3.Text = "Course Code:";
            // 
            // txtboxTrack
            // 
            txtboxTrack.BackColor = Color.White;
            txtboxTrack.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxTrack.ForeColor = SystemColors.Window;
            txtboxTrack.Location = new Point(173, 268);
            txtboxTrack.Name = "txtboxTrack";
            txtboxTrack.Size = new Size(191, 24);
            txtboxTrack.TabIndex = 63;
            // 
            // txtboxType
            // 
            txtboxType.BackColor = Color.White;
            txtboxType.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxType.ForeColor = SystemColors.Window;
            txtboxType.Location = new Point(35, 268);
            txtboxType.Name = "txtboxType";
            txtboxType.Size = new Size(123, 24);
            txtboxType.TabIndex = 62;
            // 
            // txtboxPreReq
            // 
            txtboxPreReq.BackColor = Color.White;
            txtboxPreReq.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxPreReq.ForeColor = SystemColors.Window;
            txtboxPreReq.Location = new Point(220, 209);
            txtboxPreReq.Name = "txtboxPreReq";
            txtboxPreReq.Size = new Size(144, 24);
            txtboxPreReq.TabIndex = 61;
            // 
            // txtboxLab
            // 
            txtboxLab.BackColor = Color.White;
            txtboxLab.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxLab.ForeColor = SystemColors.Window;
            txtboxLab.Location = new Point(121, 209);
            txtboxLab.Name = "txtboxLab";
            txtboxLab.Size = new Size(89, 24);
            txtboxLab.TabIndex = 60;
            // 
            // button4
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
            button4.Location = new Point(21, 26);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(21, 29);
            button4.TabIndex = 59;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // txtboxLec
            // 
            txtboxLec.BackColor = Color.White;
            txtboxLec.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxLec.ForeColor = SystemColors.Window;
            txtboxLec.Location = new Point(35, 209);
            txtboxLec.Name = "txtboxLec";
            txtboxLec.Size = new Size(76, 24);
            txtboxLec.TabIndex = 24;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(54, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // txtboxUnits
            // 
            txtboxUnits.BackColor = Color.White;
            txtboxUnits.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxUnits.ForeColor = SystemColors.Window;
            txtboxUnits.Location = new Point(306, 148);
            txtboxUnits.Name = "txtboxUnits";
            txtboxUnits.Size = new Size(58, 24);
            txtboxUnits.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT Condensed Extra Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Navy;
            label2.Location = new Point(109, 41);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 2;
            label2.Text = "University";
            // 
            // txtboxTitle
            // 
            txtboxTitle.BackColor = Color.White;
            txtboxTitle.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxTitle.ForeColor = SystemColors.Window;
            txtboxTitle.Location = new Point(145, 148);
            txtboxTitle.Name = "txtboxTitle";
            txtboxTitle.Size = new Size(147, 24);
            txtboxTitle.TabIndex = 22;
            txtboxTitle.TextChanged += txtboxTitle_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Navy;
            label1.Location = new Point(108, 20);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.TabIndex = 1;
            label1.Text = "NexusTech";
            // 
            // txtboxCode
            // 
            txtboxCode.BackColor = Color.White;
            txtboxCode.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxCode.ForeColor = SystemColors.Window;
            txtboxCode.Location = new Point(34, 148);
            txtboxCode.Name = "txtboxCode";
            txtboxCode.Size = new Size(97, 24);
            txtboxCode.TabIndex = 21;
            // 
            // comboBoxTrack
            // 
            comboBoxTrack.FormattingEnabled = true;
            comboBoxTrack.Items.AddRange(new object[] { "Business Analytics", "Networking Technology", "Service Management" });
            comboBoxTrack.Location = new Point(790, 65);
            comboBoxTrack.Name = "comboBoxTrack";
            comboBoxTrack.Size = new Size(151, 28);
            comboBoxTrack.TabIndex = 20;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Navy;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1020, 548);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 31);
            btnDelete.TabIndex = 18;
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
            btnSave.Location = new Point(928, 548);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(82, 31);
            btnSave.TabIndex = 17;
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
            btnEdit.Location = new Point(836, 548);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(82, 31);
            btnEdit.TabIndex = 16;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAddCourse
            // 
            btnAddCourse.BackColor = Color.Navy;
            btnAddCourse.FlatAppearance.BorderSize = 0;
            btnAddCourse.FlatStyle = FlatStyle.Flat;
            btnAddCourse.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCourse.ForeColor = Color.White;
            btnAddCourse.Location = new Point(220, 381);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(144, 31);
            btnAddCourse.TabIndex = 15;
            btnAddCourse.Text = "Add";
            btnAddCourse.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tw Cen MT", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Navy;
            label8.Location = new Point(396, 60);
            label8.Name = "label8";
            label8.Size = new Size(141, 33);
            label8.TabIndex = 12;
            label8.Text = "Curriculum";
            // 
            // comboBoxCurriculum
            // 
            comboBoxCurriculum.FormattingEnabled = true;
            comboBoxCurriculum.Items.AddRange(new object[] { "AY 2020-2024", "AY 2025-Onwards" });
            comboBoxCurriculum.Location = new Point(951, 66);
            comboBoxCurriculum.Name = "comboBoxCurriculum";
            comboBoxCurriculum.Size = new Size(151, 28);
            comboBoxCurriculum.TabIndex = 1;
            comboBoxCurriculum.SelectedIndexChanged += comboBoxCurriculum_SelectedIndexChanged;
            // 
            // dgvCurriculum
            // 
            dgvCurriculum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurriculum.Location = new Point(396, 106);
            dgvCurriculum.Name = "dgvCurriculum";
            dgvCurriculum.RowHeadersWidth = 51;
            dgvCurriculum.Size = new Size(706, 424);
            dgvCurriculum.TabIndex = 0;
            dgvCurriculum.CellClick += dgvCurriculum_CellClick;
            dgvCurriculum.CellFormatting += dgvCurriculum_CellFormatting;
            // 
            // Curriculum
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 608);
            Controls.Add(panel2);
            Name = "Curriculum";
            Text = "Curriculum";
            Load += Curriculum_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCurriculum).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private DataGridView dgvCurriculum;
        private ComboBox comboBoxCurriculum;
        private Label label8;
        private Button btnDelete;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAddCourse;
        private ComboBox comboBoxTrack;
        private TextBox txtboxCode;
        private TextBox txtboxTitle;
        private TextBox txtboxLec;
        private TextBox txtboxUnits;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button4;
        private Label label3;
        private TextBox txtboxTrack;
        private TextBox txtboxType;
        private TextBox txtboxPreReq;
        private TextBox txtboxLab;
        private Label label4;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label9;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private ComboBox comboBoxLevel;
        private Label label14;
        private TextBox textBox1;
        private ComboBox comboBoxSem;
    }
}