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
            btnLogin = new Button();
            label4 = new Label();
            label3 = new Label();
            txtboxUsername = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(63, 331);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 0;
            label2.Text = "Password:";
            // 
            // txtboxPassword
            // 
            txtboxPassword.Location = new Point(63, 356);
            txtboxPassword.Name = "txtboxPassword";
            txtboxPassword.Size = new Size(272, 27);
            txtboxPassword.TabIndex = 2;
            txtboxPassword.UseSystemPasswordChar = true;
            txtboxPassword.TextChanged += txtboxPassword_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(252, 252, 252);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtboxUsername);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(txtboxPassword);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(363, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 550);
            panel1.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Navy;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Tw Cen MT", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(63, 422);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(272, 44);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "LOG IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT Condensed", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(172, 207);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 7;
            label4.Text = "University";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT Condensed Extra Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(151, 184);
            label3.Name = "label3";
            label3.Size = new Size(105, 27);
            label3.TabIndex = 6;
            label3.Text = "NexusTech";
            // 
            // txtboxUsername
            // 
            txtboxUsername.Location = new Point(63, 288);
            txtboxUsername.Name = "txtboxUsername";
            txtboxUsername.Size = new Size(272, 27);
            txtboxUsername.TabIndex = 5;
            txtboxUsername.TextChanged += txtboxUsername_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(63, 263);
            label1.Name = "label1";
            label1.Size = new Size(71, 17);
            label1.TabIndex = 4;
            label1.Text = "Username:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(136, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(129, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 619);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private TextBox txtboxPassword;
        private Panel panel1;
        private PictureBox pictureBox1;
        private TextBox txtboxUsername;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button btnLogin;
    }
}
