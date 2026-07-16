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

        // ==== Student panel (name, college, A.Y.) ====
        private async Task LoadStudentInfo()
        {
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("No student is currently logged in.",
                    "Missing student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kumukuha tayo ng data sa 'students' collection para laging sync ang currentAcademicYear
            DocumentSnapshot doc = await Db.Collection("students")
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
            string middle = GetField(doc, "middleInitial"); // Gumagamit ng middleInitial mula sa database
            string last = GetField(doc, "lastName");

            // Sync sa academic year field ng iyong 'students' registration schema
            string acadYear = GetField(doc, "currentAcademicYear");

            // Build the middle initial display
            string middleInitialDisplay = string.IsNullOrEmpty(middle)
                ? ""
                : middle.TrimEnd('.') + ". ";

            // Display the data on the labels
            lblfName.Text = $"{first} {middleInitialDisplay}{last}";

            // FIXED: Static Department Name ayon sa iyong instruction
            lblDepartment.Text = "• College of Informatics and Computing Sciences";

            lblAcadYear.Text = "• A.Y. " + acadYear;

        }

        // ==== Course grid ====
        private async Task LoadCourses()
        {
            if (string.IsNullOrEmpty(studentId)) return;

            dgvCourses.Rows.Clear();

            try
            {
                // 1. Kunin ang evaluation record na ginawa ng Admin
                DocumentSnapshot evalDoc = await Db.Collection("evaluation").Document(studentId).GetSnapshotAsync();

                if (evalDoc.Exists)
                {
                    var data = evalDoc.ToDictionary();

                    // 2. I-check kung may 'courses' array sa loob
                    if (data.ContainsKey("courses") && data["courses"] is System.Collections.Generic.List<object> coursesList)
                    {
                        foreach (var item in coursesList)
                        {
                            if (item is Dictionary<string, object> courseObj)
                            {
                                // Kunin ang basic info na naka-save sa evaluation document
                                string code = courseObj.ContainsKey("course_code") ? courseObj["course_code"].ToString() : "";
                                string yearLvl = courseObj.ContainsKey("year_Level") ? courseObj["year_Level"].ToString() : "";
                                string sem = courseObj.ContainsKey("currentSemester") ? courseObj["currentSemester"].ToString() : "";

                                string title = "";
                                string unitsVal = "";
                                string prereq = "";

                                // 3. I-query ang 'courses' collection para makuha ang Title, Units, at Pre-requisite
                                if (!string.IsNullOrEmpty(code))
                                {
                                    QuerySnapshot courseSnap = await Db.Collection("courses")
                                                                       .WhereEqualTo("course_code", code)
                                                                       .Limit(1)
                                                                       .GetSnapshotAsync();

                                    if (courseSnap.Documents.Count > 0)
                                    {
                                        var cDoc = courseSnap.Documents[0];

                                        title = GetField(cDoc, "course_title");
                                        if (string.IsNullOrEmpty(title)) title = GetField(cDoc, "courseTitle");

                                        unitsVal = GetField(cDoc, "units");

                                        prereq = GetField(cDoc, "pre_requisite");
                                        if (string.IsNullOrEmpty(prereq)) prereq = GetField(cDoc, "prerequisite");
                                        if (string.IsNullOrEmpty(prereq)) prereq = GetField(cDoc, "pre-requisite");
                                    }
                                }

                                // 4. I-add ang row gamit ang EXACT column names mo
                                int rowIndex = dgvCourses.Rows.Add();
                                DataGridViewRow row = dgvCourses.Rows[rowIndex];

                                row.Cells["courseCode"].Value = code;
                                row.Cells["courseTitle"].Value = title;
                                row.Cells["units"].Value = unitsVal;
                                row.Cells["yearLevel"].Value = yearLvl;
                                row.Cells["semester"].Value = sem;
                                row.Cells["cacademicyear"].Value = prereq; // Eto yung name mo para sa Pre-requisite/s
                            }
                        }
                    }

                    if (dgvCourses.Rows.Count == 0)
                    {
                        MessageBox.Show("No evaluated courses found in your record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please wait for the admin to assign your courses. No evaluation record found yet.",
                                    "No Evaluation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading evaluated courses:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Safe reader – never returns null
        private static string GetField(DocumentSnapshot doc, string field)
        {
            if (doc.TryGetValue(field, out object value) && value != null)
                return value.ToString() ?? "";
            return "";
        }
        private static string Cell(DataGridViewRow row, int index)
            => row.Cells[index].Value?.ToString() ?? "";

        private static string Q(string s)
            => s.Contains(",") || s.Contains("\"")
               ? "\"" + s.Replace("\"", "\"\"") + "\""
               : s;

        // ---- Designer click handlers (intentionally empty; view-only form) ----
        private void lblAcadyear_Click(object sender, EventArgs e) { }
        private void lblfName_Click(object sender, EventArgs e) { }
        private void lblDepartment_Click(object sender, EventArgs e) { }
        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblStatus_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btn_ChangePass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Cannot change password. No logged-in student found.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPassword = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your new password:",
                "Change Password",
                "");

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (dgvCourses.Rows.Count == 0)
            {
                MessageBox.Show("There are no courses to export.", "Nothing to export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Path ng logo (tulad sa Admin side)
            string logoPath = System.IO.Path.Combine(Application.StartupPath, "Images", "IMG_9764 (1).png");
            string logoUrl = new Uri(logoPath).AbsoluteUri;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "HTML Files|*.html";
                saveFileDialog.FileName = $"{studentId}_Evaluation.html";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var html = new System.Text.StringBuilder();

                    // Setup CSS
                    html.Append("<html><head><style>");
                    html.Append("body { font-family: Arial, sans-serif; margin: 30px; }");
                    html.Append(".header { text-align: center; border-bottom: 2px solid #2c3e50; padding-bottom: 20px; margin-bottom: 20px; }");
                    html.Append(".header img { width: 100px; }");
                    html.Append(".contact-info { font-size: 0.9em; color: #555; }");
                    html.Append("table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
                    html.Append("th { background-color: #2c3e50; color: white; padding: 10px; border: 1px solid #ddd; }");
                    html.Append("td { padding: 10px; border: 1px solid #ddd; text-align: left; }");
                    html.Append(".enrolled { color: blue; font-weight: bold; }");
                    html.Append("</style></head><body>");

                    // Header Section
                    html.Append("<div class='header'>");
                    html.Append($"<img src='{logoUrl}' alt='Logo' style='width:100px;'><br>");
                    html.Append("<h1>Nexus Tech University</h1>");
                    html.Append("<div class='contact-info'>");
                    html.Append("info@nexustech.edu | 123-456-7890<br>");
                    html.Append("Batangas City, Philippines | www.nexustech.edu");
                    html.Append("</div></div>");

                    // Student Info (Kinukuha sa Labels ng Dashboard)
                    html.Append($"<p><b>Name:</b> {lblfName.Text}</p>");
                    html.Append($"<p><b>Program:</b> {lblDepartment.Text.TrimStart('•', ' ')}</p>");
                    html.Append($"<p><b>Academic Year:</b> {lblAcadYear.Text.TrimStart('•', ' ')}</p>");

                    // Table Header
                    html.Append("<table><tr>");
                    html.Append("<th>Code</th><th>Course Title</th><th>Units</th><th>Year</th><th>Sem</th><th>Prerequisite</th><th>Remarks</th>");
                    html.Append("</tr>");

                    // Data Loop - Nagbabasa mula sa DataGridView gamit ang EXACT column names
                    foreach (DataGridViewRow row in dgvCourses.Rows)
                    {
                        if (row.IsNewRow) continue;

                        // Kukunin ang value based sa Name ng column na ibinigay mo
                        string code = row.Cells["courseCode"].Value?.ToString() ?? "";
                        string title = row.Cells["courseTitle"].Value?.ToString() ?? "";
                        string unitsVal = row.Cells["units"].Value?.ToString() ?? "";
                        string yearLvl = row.Cells["yearLevel"].Value?.ToString() ?? "";
                        string sem = row.Cells["semester"].Value?.ToString() ?? "";
                        string prereq = row.Cells["cacademicyear"].Value?.ToString() ?? ""; // Pre-requisite

                        html.Append($"<tr><td>{code}</td><td>{title}</td><td>{unitsVal}</td><td>{yearLvl}</td><td>{sem}</td><td>{prereq}</td><td class='enrolled'>For Enrollment</td></tr>");
                    }

                    html.Append("</table></body></html>");
                    System.IO.File.WriteAllText(saveFileDialog.FileName, html.ToString());
                    MessageBox.Show("Evaluation report exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
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
    }
}