using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NexusTechUniversity
{
    public partial class AdminDashboard : Form
    {
        private string userRole;
        public AdminDashboard(string role)
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
            // Example: Disable your buttons so students can't change anything
            // Use Controls.Find to avoid referencing designer fields that may not exist
            var save = this.Controls.Find("btnSave", true);
            if (save.Length > 0) save[0].Enabled = false;

            var del = this.Controls.Find("btnDelete", true);
            if (del.Length > 0) del[0].Enabled = false;

            var upd = this.Controls.Find("btnUpdate", true);
            if (upd.Length > 0) upd[0].Enabled = false;

            // Optional: Change window title to reflect status
            this.Text = "Nexus Tech University - Student Dashboard (View Only)";
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }


        private void btnStudents_Click(object sender, EventArgs e)
        {
            Student students = new Student();
            students.Show();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
