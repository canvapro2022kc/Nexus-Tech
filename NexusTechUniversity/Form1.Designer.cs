namespace NexusTechUniversity
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label2 = new Label();
            txtboxPassword = new TextBox();
            panel1 = new Panel();
            btn_Login = new ReaLTaiizor.Controls.Button();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            label3 = new Label();
            txtboxUsername = new TextBox();
            label1 = new Label();
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(94, 416);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 0;
            label2.Text = "Password:";
            // 
            // txtboxPassword
            // 
            txtboxPassword.BackColor = Color.White;
            txtboxPassword.Location = new Point(94, 440);
            txtboxPassword.Name = "txtboxPassword";
            txtboxPassword.Size = new Size(271, 27);
            txtboxPassword.TabIndex = 1;
            txtboxPassword.UseSystemPasswordChar = true;
            txtboxPassword.TextChanged += txtboxPassword_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(252, 252, 252);
            panel1.Controls.Add(btn_Login);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtboxUsername);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtboxPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(materialCard1);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 610);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Transparent;
            btn_Login.BorderColor = Color.FromArgb(3, 37, 83);
            btn_Login.EnteredBorderColor = Color.FromArgb(3, 37, 83);
            btn_Login.EnteredColor = Color.FromArgb(3, 37, 83);
            btn_Login.Font = new Font("Tw Cen MT", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Login.Image = null;
            btn_Login.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Login.InactiveColor = Color.FromArgb(3, 37, 83);
            btn_Login.Location = new Point(93, 492);
            btn_Login.Name = "btn_Login";
            btn_Login.PressedBorderColor = Color.FromArgb(3, 37, 83);
            btn_Login.PressedColor = Color.FromArgb(3, 37, 83);
            btn_Login.Size = new Size(272, 44);
            btn_Login.TabIndex = 10;
            btn_Login.Text = "LOG IN";
            btn_Login.TextAlignment = StringAlignment.Center;
            btn_Login.Click += btn_Login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(163, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(118, 131);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT Condensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(3, 37, 83);
            label4.Location = new Point(188, 268);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 7;
            label4.Text = "University";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT Condensed Extra Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(3, 37, 83);
            label3.Location = new Point(160, 237);
            label3.Name = "label3";
            label3.Size = new Size(126, 33);
            label3.TabIndex = 6;
            label3.Text = "NexusTech";
            // 
            // txtboxUsername
            // 
            txtboxUsername.BackColor = Color.White;
            txtboxUsername.Location = new Point(94, 374);
            txtboxUsername.Name = "txtboxUsername";
            txtboxUsername.Size = new Size(271, 27);
            txtboxUsername.TabIndex = 0;
            txtboxUsername.TextChanged += txtboxUsername_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(94, 350);
            label1.Name = "label1";
            label1.Size = new Size(71, 17);
            label1.TabIndex = 4;
            label1.Text = "Username:";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(93, 492);
            materialCard1.Margin = new Padding(17);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(17);
            materialCard1.Size = new Size(272, 44);
            materialCard1.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Tw Cen MT", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(3, 37, 83);
            label5.Location = new Point(724, 69);
            label5.Name = "label5";
            label5.Size = new Size(350, 50);
            label5.TabIndex = 5;
            label5.Text = "Unlocking Potential,";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Tw Cen MT", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(254, 182, 2);
            label6.Location = new Point(757, 121);
            label6.Name = "label6";
            label6.Size = new Size(317, 50);
            label6.TabIndex = 6;
            label6.Text = "Unleashing Minds.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(3, 37, 83);
            label7.Location = new Point(824, 541);
            label7.Name = "label7";
            label7.Size = new Size(273, 17);
            label7.TabIndex = 7;
            label7.Text = "For inquiries, email us at info@nexus.edu.ph";
            label7.Click += label7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.IMG_9890;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1140, 608);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtboxPassword;
        private Panel panel1;
        private TextBox txtboxUsername;
        private Label label1;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private ReaLTaiizor.Controls.Button btn_Login;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
    }
}
