using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NexusTechUniversity
{
    public partial class StudentDashboard : Form
    {

        public StudentDashboard() : this("admin")
        {
        }

        private string userRole;
        public StudentDashboard(string role)
        {
            InitializeComponent();
            this.userRole = role;

            if (userRole == "student")
            {
                ApplyViewOnlyMode();
            }
        }

         private void ApplyViewOnlyMode()
        {
            // Set view-only title for students. No edit controls on this form.
            this.Text = "Nexus Tech University - Student Dashboard (View Only)";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
