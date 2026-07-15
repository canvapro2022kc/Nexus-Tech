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
                try
                {
                    // 1. Dito natin itinatakda ang path patungo sa iyong service account key file
                    string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                    // 2. Pagkatapos ma-set ng credentials, tsaka pa lang natin gagawin ang database connection
                    db = FirestoreDb.Create("enrollmentit331");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Initialization Error: {ex.Message}\nMake sure 'serviceAccountKey.json' is in your bin folder.",
                        "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtboxPassword_TextChanged(object sender, EventArgs e) { }
        private void txtboxUsername_TextChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }

        private async void btn_Login_Click(object sender, EventArgs e)
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
                // Siguraduhin nating hindi null ang db bago gamitin
                if (db == null)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                    db = FirestoreDb.Create("enrollmentit331");
                }

                DocumentReference userRef = db.Collection("users").Document(enteredUsername);
                DocumentSnapshot snapshot = await userRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    MessageBox.Show("User does not exist.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string storedPassword = snapshot.GetValue<string>("password")?.Trim() ?? string.Empty;
                string role = snapshot.GetValue<string>("role") ?? string.Empty;

                if (enteredPassword != storedPassword)
                {
                    MessageBox.Show("Invalid password. Please try again.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Login successful! Welcome, {role}.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (role.Equals("student", StringComparison.OrdinalIgnoreCase))
                {
                    // Ipapasa ang username para malaman ng dashboard kung sinong estudyante ang ilo-load.
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

        private void label7_Click(object sender, EventArgs e) { }
    }
}