using System;
using System.ComponentModel;
using System.Windows.Forms;
using Google.Cloud.Firestore;

namespace NexusTechUniversity
{
    public partial class Form1 : Form
    {
        private FirestoreDb db;

        public Form1()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                db = FirestoreDb.Create("enrollmentit331");
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUsername = txtboxUsername.Text.Trim();
            string enteredPassword = txtboxPassword.Text.Trim();

            if (string.IsNullOrEmpty(enteredUsername) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DocumentReference userRef = db.Collection("users").Document(enteredUsername);
                DocumentSnapshot snapshot = await userRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    MessageBox.Show("User does not exist.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string storedPassword = snapshot.GetValue<string>("password").Trim();
                string role = snapshot.GetValue<string>("role");

                    // Direct comparison without BCrypt hashing
                    if (enteredPassword == storedPassword)
                    {
                        if (role.Equals("student", StringComparison.OrdinalIgnoreCase))
                        {
                            StudentDashboard studentDashboard = new StudentDashboard(role);
                            studentDashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show($"Login successful! Welcome, {role}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AdminDashboard adminDashboard = new AdminDashboard(role);
                        adminDashboard.Show();

                if (role.Equals("student", StringComparison.OrdinalIgnoreCase))
                {
                    // Pass the username so the dashboard knows which student to load.
                    var studentDashboard = new StudentDashboard(role, enteredUsername);
                    studentDashboard.Show();
                }
                else
                {
                    var adminDashboard = new AdminDashboard(role);
                    adminDashboard.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtboxPassword_TextChanged(object sender, EventArgs e) { }
        private void txtboxUsername_TextChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
    }
}