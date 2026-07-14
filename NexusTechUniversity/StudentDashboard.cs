using Google.Cloud.Firestore;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexusTechUniversity
{
    public partial class StudentDashboard : Form
    {
        // ==== Firestore connection (created once, shared) ====
        private static FirestoreDb? _db;
        private static FirestoreDb Db
        {
            get
            {
                if (_db == null)
                {
                    string projectId = "enrollmentit331";

                    // serviceAccountKey.json must sit next to the .exe (bin\Debug).
                    // Set its "Copy to Output Directory" to "Copy if newer".
                    string credPath = Path.Combine(Application.StartupPath, "serviceAccountKey.json");
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credPath);

                    _db = FirestoreDb.Create(projectId);
                }
                return _db;
            }
        }

        private readonly string userRole;
        private readonly string? studentId;

        // Only one constructor. If anything calls this with a missing argument,
        // the project won't compile — which prevents the "empty studentId" bug.
        public StudentDashboard(string role, string? studentId)
        {
            InitializeComponent();

            this.userRole = role;
            this.studentId = studentId;

            if (userRole == "student")
            {
                ApplyViewOnlyMode();
            }
        }

        private void ApplyViewOnlyMode()
        {
            this.Text = "Nexus Tech University - Student Dashboard (View Only)";
        }

        // ==== Form load ====
        private async void StudentDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadStudentInfo();
                await LoadCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load dashboard data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==== Student panel (name, college, A.Y., status) ====
        private async Task LoadStudentInfo()
        {
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("No student is currently logged in.",
                    "Missing student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DocumentSnapshot doc = await Db.Collection("users")
                                           .Document(studentId)
                                           .GetSnapshotAsync();

            if (!doc.Exists)
            {
                MessageBox.Show($"Student record '{studentId}' not found.",
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the student's information from Firestore
            string first = GetField(doc, "firstName");
            string middle = GetField(doc, "middleName");   // Optional
            string last = GetField(doc, "lastName");
            string college = GetField(doc, "college");
            string acadYear = GetField(doc, "academicYear");
            string status = GetField(doc, "status");

            // Build the middle initial
            string middleInitial = string.IsNullOrEmpty(middle)
                ? ""
                : middle.Substring(0, 1).ToUpper() + ". ";

            // Display the data on the labels
            lblfName.Text = $"{first} {middleInitial}{last}";
            lblDepartment.Text = "• " + college;
            lblAcadYear.Text = "• A.Y. " + acadYear;
            lblStatus.Text = "• " + status.ToUpper();
        }

        // ==== Course grid ====
        private async Task LoadCourses()
        {
            if (string.IsNullOrEmpty(studentId)) return;

            dgvCourses.Rows.Clear();

            QuerySnapshot snap = await Db.Collection("users")
                                         .Document(studentId)
                                         .Collection("courses")
                                         .GetSnapshotAsync();

            foreach (DocumentSnapshot d in snap.Documents)
            {
                dgvCourses.Rows.Add(
                    GetField(d, "CourseCode"),
                    GetField(d, "CourseTitle"),
                    GetField(d, "CourseDescription"),
                    GetField(d, "Units"),
                    (d.TryGetValue("Passed", out bool p) && p) ? "PASSED" : "ENROLLED"
                );
            }

            if (dgvCourses.Rows.Count == 0)
            {
                MessageBox.Show("No enrolled courses found for this student.",
                    "No courses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Safe reader – never returns null
        private static string GetField(DocumentSnapshot doc, string field)
        {
            if (doc.TryGetValue(field, out object value) && value != null)
                return value.ToString() ?? "";
            return "";
        }

        // ==== Logout ====
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to log out?",
                "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var login = new Form1();
                login.Show();
                this.Close();
            }
        }

        // ==== Export POS (Program of Study) ====
        private void btnExportPOS_Click(object sender, EventArgs e)
        {
            if (dgvCourses.Rows.Count == 0)
            {
                MessageBox.Show("There are no courses to export.",
                    "Nothing to export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt)|*.txt|CSV file (*.csv)|*.csv";
                sfd.FileName = $"POS_{(string.IsNullOrEmpty(studentId) ? "student" : studentId)}_{DateTime.Now:yyyyMMdd}.txt";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var sb = new StringBuilder();
                    bool csv = sfd.FilterIndex == 2;

                    sb.AppendLine("NEXUS TECH UNIVERSITY");
                    sb.AppendLine("PROGRAM OF STUDY (POS)");
                    sb.AppendLine(new string('-', 60));
                    sb.AppendLine($"Student : {lblfName.Text}");
                    sb.AppendLine($"College : {lblDepartment.Text.TrimStart('•', ' ')}");
                    sb.AppendLine($"{lblAcadYear.Text.TrimStart('•', ' ')}");
                    sb.AppendLine($"Status  : {lblStatus.Text.TrimStart('•', ' ')}");
                    sb.AppendLine(new string('-', 60));
                    sb.AppendLine();

                    if (csv)
                        sb.AppendLine("Course Code,Course Name,Course Description,Units,Remarks");

                    foreach (DataGridViewRow row in dgvCourses.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string code = Cell(row, 0);
                        string name = Cell(row, 1);
                        string desc = Cell(row, 2);
                        string units = Cell(row, 3);
                        string remarks = Cell(row, 4);

                        if (csv)
                            sb.AppendLine($"{Q(code)},{Q(name)},{Q(desc)},{Q(units)},{Q(remarks)}");
                        else
                            sb.AppendLine($"{code,-12}{name,-25}{units,-8}{remarks}");
                    }

                    sb.AppendLine();
                    sb.AppendLine($"Generated: {DateTime.Now:g}");

                    File.WriteAllText(sfd.FileName, sb.ToString());

                    MessageBox.Show("Program of Study exported successfully.",
                        "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to export POS:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static string Cell(DataGridViewRow row, int index)
            => row.Cells[index].Value?.ToString() ?? "";

        private static string Q(string s)
            => s.Contains(",") || s.Contains("\"")
               ? "\"" + s.Replace("\"", "\"\"") + "\""
               : s;

        // ---- Designer click handlers (intentionally empty; view-only form) ----
        private void lblAcadyear_Click(object sender, EventArgs e)
        {

        }
        private void lblfName_Click(object sender, EventArgs e)
        {

        }
        private void lblDepartment_Click(object sender, EventArgs e)
        {

        }
        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Cannot change password. No logged-in student found.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gagamit tayo ng simpleng Microsoft Visual Basic InputBox para makuha ang bagong password.
            // (Tiyaking walang error ito. Kung hindi mo magamit ang Interaction.InputBox, 
            // maaari mong palitan ito ng text box input mula sa iyong UI tulad ng txtboxNewPassword.Text)
            string newPassword = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your new password:",
                "Change Password",
                "");

            // I-validate kung walang nilagay o kinansela ang pag-input
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Password change cancelled or invalid input.",
                    "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 1. I-update ang password sa 'users' collection
                DocumentReference userDocRef = Db.Collection("users").Document(studentId);
                Dictionary<string, object> userUpdate = new Dictionary<string, object>
                {
                    { "password", newPassword }
                };
                await userDocRef.SetAsync(userUpdate, SetOptions.MergeAll);

                // 2. I-update din ang password sa 'students' collection para laging tugma ang dalawa
                DocumentReference studentDocRef = Db.Collection("students").Document(studentId);
                Dictionary<string, object> studentUpdate = new Dictionary<string, object>
                {
                    { "password", newPassword }
                };
                await studentDocRef.SetAsync(studentUpdate, SetOptions.MergeAll);

                MessageBox.Show("Your password has been successfully changed!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to change password in database:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}