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
            panel1 = new Panel();
            btnStudents = new Button();
            btnLogout = new Button();
            btnCurriculum = new Button();
            btnDashboard = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(btnStudents);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnCurriculum);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 619);
            panel1.TabIndex = 0;
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
            btnStudents.TabIndex = 10;
            btnStudents.Text = "Students";
            btnStudents.TextAlign = ContentAlignment.MiddleLeft;
            btnStudents.UseVisualStyleBackColor = true;
            btnStudents.Click += btnStudents_Click;
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
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(panel1);
            Name = "AdminDashboard";
            Text = "AdminDashboard";
            Load += AdminDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button btnDashboard;
        private PictureBox pictureBox1;
        private Button btnCurriculum;
        private Button btnLogout;
        private Button btnStudents;
    }
}