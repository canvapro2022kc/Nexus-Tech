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
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }


        private void btnStudents_Click(object sender, EventArgs e)
        {
            Student students = new Student();
            students.Show();
        }
    }
}
