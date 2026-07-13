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
        // Parameterless constructor needed for the WinForms designer.
        public AdminDashboard() : this("admin")
        {
        }

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
            // Set view-only title for students. No edit controls on this form.
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

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Add_Student student = new Add_Student();
            student.Show();
            this.Hide();
        }

        private void btnCurriculum_Click(object sender, EventArgs e)
        {
            Curriculum subjects = new Curriculum();
            subjects.Show();
            this.Hide();
        }

        private void btnStudents_Click_1(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();
            this.Hide();
        }
    }
}
