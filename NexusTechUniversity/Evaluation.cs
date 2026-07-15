using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexusTechUniversity
{
    public partial class Evaluation : Form
    {
        private FirestoreDb db;
        private string srCode;
        private Dictionary<string, object> studentData = new Dictionary<string, object>();
        private List<Course> allCourses = new List<Course>();
        private List<Course> coursesToTake = new List<Course>();
        private string currentStudentCurriculum = "AY 2025-Onwards";
        private HashSet<string> passedHistory = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private class Course
        {
            public string Code = "", Title = "", Units = "", YearLevel = "", Semester = "", CurriculumId = "";
            public int Seq;
        }

        public Evaluation(string? srCode)
        {
            InitializeComponent();
            db = FirestoreDb.Create("enrollmentit331");
            this.srCode = srCode ?? "";
        }

        private async void Evaluation_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(srCode)) return;
                SetupGrids();
                await LoadStudentAsync();
                await LoadStudentCoursesHistoryAsync();
                await LoadAllCoursesAsync();
                LoadCoursesTaken();
            }
            catch (Exception ex) { MessageBox.Show("Error loading: " + ex.Message); }
        }

        private async Task LoadStudentAsync()
        {
            var q = await db.Collection("students").WhereEqualTo("studentID", srCode).Limit(1).GetSnapshotAsync();
            DocumentSnapshot doc = q.Count > 0 ? q.Documents[0] : await db.Collection("students").Document(srCode).GetSnapshotAsync();

            if (doc != null && doc.Exists)
            {
                studentData = doc.ToDictionary();
                txtSRCode.Text = srCode;
                txtFname.Text = GetField(studentData, "firstName");
                txtLname.Text = GetField(studentData, "lastName");
                txtAcademicYear.Text = GetField(studentData, "currentAcademicYear", "academicYear");
                txtYearLevel.Text = GetField(studentData, "yearLevel");
                txtSemester.Text = GetField(studentData, "currentSemester", "semester");

                int entryYear = (srCode.Length >= 2 && int.TryParse(srCode.Substring(0, 2), out int y)) ? 2000 + y : 2025;
                currentStudentCurriculum = (entryYear >= 25) ? "AY 2025-Onwards" : "AY 2020-2024";
            }
        }

        private async Task LoadAllCoursesAsync()
        {
            allCourses.Clear();
            var snap = await db.Collection("courses").GetSnapshotAsync();
            foreach (var d in snap.Documents)
            {
                var data = d.ToDictionary();
                var c = new Course
                {
                    Code = GetField(data, "course_code", "courseCode").Trim(),
                    Title = GetField(data, "course_title", "courseTitle").Trim(),
                    Units = GetField(data, "units").Trim(),
                    YearLevel = GetField(data, "year_level", "yearLevel").Trim(),
                    Semester = GetField(data, "semester").Trim(),
                    CurriculumId = GetField(data, "curriculum_id").Trim(),
                };
                c.Seq = YearNum(c.YearLevel) * 10 + SemNum(c.Semester);
                allCourses.Add(c);
            }
        }

        private async Task LoadStudentCoursesHistoryAsync()
        {
            passedHistory.Clear();
            var snap = await db.Collection("studentCourses").Document(srCode).GetSnapshotAsync();
            if (!snap.Exists) return;

            var data = snap.ToDictionary();
            if (data.ContainsKey("courses") && data["courses"] is System.Collections.IEnumerable list)
            {
                foreach (var item in list)
                {
                    if (item is Dictionary<string, object> m)
                    {
                        string code = m.ContainsKey("course_code") ? m["course_code"]?.ToString() : "";
                        if (!string.IsNullOrWhiteSpace(code)) passedHistory.Add(code.Trim());
                    }
                }
            }
        }

        private void LoadCoursesTaken()
        {
            dgCoursesTaken.Rows.Clear();
            int targetSeq = YearNum(txtYearLevel.Text) * 10 + SemNum(txtSemester.Text);

            var prior = allCourses
                .Where(c => c.CurriculumId.Equals(currentStudentCurriculum, StringComparison.OrdinalIgnoreCase))
                .Where(c => c.Seq > 0 && c.Seq < targetSeq)
                .OrderBy(c => c.Seq)
                .ToList();

            foreach (var c in prior)
            {
                bool isAlreadyPassed = passedHistory.Contains(c.Code);
                dgCoursesTaken.Rows.Add(isAlreadyPassed, c.Code, c.Title, c.Units, c.YearLevel, c.Semester, c.CurriculumId);
            }
        }

        private async void btnEvaluateAssign_Click(object sender, EventArgs e)
        {
            try
            {
                dgCoursesTaken.EndEdit();
                var updatedPassedCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                // 1. Sync from UI checkboxes to local set
                foreach (DataGridViewRow row in dgCoursesTaken.Rows)
                {
                    if (row.IsNewRow) continue;
                    // Siguraduhin na 'taken' ang pangalan ng checkbox column sa Designer
                    bool isChecked = row.Cells["taken"].Value != null && Convert.ToBoolean(row.Cells["taken"].Value);
                    string code = row.Cells["courseCode"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(code) && isChecked)
                    {
                        updatedPassedCodes.Add(code.Trim());
                    }
                }

                // 2. Persist to Firestore
                await db.Collection("studentCourses").Document(srCode).SetAsync(new Dictionary<string, object> {
                    { "firstName", txtFname.Text }, { "lastName", txtLname.Text },
                    { "courses", updatedPassedCodes.Select(c => new Dictionary<string, object> { { "course_code", c } }).ToList() }
                });

                passedHistory = updatedPassedCodes;
                int targetSeq = YearNum(txtYearLevel.Text) * 10 + SemNum(txtSemester.Text);

                // 3. Filter for courses to take (Excluding already passed ones)
                coursesToTake = allCourses
                    .Where(c => c.CurriculumId.Trim().Equals(currentStudentCurriculum.Trim(), StringComparison.OrdinalIgnoreCase))
                    .Where(c => c.Seq > 0 && c.Seq <= targetSeq)
                    .Where(c => !passedHistory.Contains(c.Code))
                    .OrderBy(c => c.Seq)
                    .ToList();

                dgvCoursesToTake.Rows.Clear();
                foreach (var c in coursesToTake)
                {
                    dgvCoursesToTake.Rows.Add(c.Code, c.Title, c.Units, c.YearLevel, c.Semester, c.CurriculumId);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (coursesToTake.Count == 0) { MessageBox.Show("Evaluate muna!"); return; }

                await db.Collection("evaluation").Document(srCode).SetAsync(new Dictionary<string, object> {
                    { "firstName", txtFname.Text }, { "lastName", txtLname.Text },
                    { "courses", coursesToTake.Select(c => new Dictionary<string, object> {
                        { "course_code", c.Code }, { "year_Level", c.YearLevel }, { "currentSemester", c.Semester }
                    }).ToList() }
                });

                int currentY = YearNum(txtYearLevel.Text);
                int currentS = SemNum(txtSemester.Text);
                string nextYearStr = txtYearLevel.Text;
                string nextSemStr = "";

                // Progression logic
                if (currentY == 1) // First Year
                {
                    if (currentS == 1) nextSemStr = "Second Semester";
                    else { nextSemStr = "First Semester"; currentY++; }
                }
                else // 2nd/3rd Year
                {
                    if (currentS == 1) nextSemStr = "Second Semester";
                    else if (currentS == 2) nextSemStr = "Midterm";
                    else { nextSemStr = "First Semester"; currentY++; }
                }

                nextYearStr = (currentY == 2 ? "Second Year" : currentY == 3 ? "Third Year" : "Fourth Year");

                await db.Collection("students").Document(srCode).UpdateAsync(new Dictionary<string, object> {
                    { "yearLevel", nextYearStr }, { "currentSemester", nextSemStr }
                });

                MessageBox.Show($"Assigned! Next term: {nextYearStr} {nextSemStr}.");
                this.Hide();
            }
            catch (Exception ex) { MessageBox.Show("Error assigning: " + ex.Message); }
        }

        private static string GetField(Dictionary<string, object> d, params string[] k) { foreach (var key in k) if (d.ContainsKey(key) && d[key] != null) return d[key].ToString(); return ""; }

        private static int YearNum(string y)
        {
            y = y.ToLower().Trim();
            if (y.Contains("first")) return 1;
            if (y.Contains("second")) return 2;
            if (y.Contains("third")) return 3;
            if (y.Contains("fourth")) return 4;
            return 9;
        }

        private static int SemNum(string s)
        {
            s = s.ToLower().Trim();
            if (s.Contains("first")) return 1;
            if (s.Contains("second")) return 2;
            if (s.Contains("midterm")) return 3;
            return 1;
        }

        private void SetupGrids() { /* Siguraduhin ang Column Names sa Designer ay 'taken', 'courseCode', etc. */ }
        private void btnBack_Click(object sender, EventArgs e) { this.Hide(); }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            // Siguraduhin na may laman ang listahan bago mag-export
            if (coursesToTake == null || coursesToTake.Count == 0)
            {
                MessageBox.Show("Click Evaluate Button First.");
                return;
            }

            string logoPath = System.IO.Path.Combine(Application.StartupPath, "Images", "IMG_9764 (1).png");
            string logoUrl = new Uri(logoPath).AbsoluteUri;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "HTML Files|*.html";
                saveFileDialog.FileName = $"Evaluation_For_Enrollment_{srCode}.html";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var html = new System.Text.StringBuilder();

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

                    // Student Info
                    html.Append($"<p><b>Name:</b> {txtFname.Text} {txtLname.Text}</p>");
                    html.Append($"<p><b>Academic Year:</b> {txtAcademicYear.Text} | <b>Level:</b> {txtYearLevel.Text} - {txtSemester.Text}</p>");

                    // Table
                    html.Append("<table><tr>");
                    html.Append("<th>Code</th><th>Course Title</th><th>Units</th><th>Year</th><th>Sem</th><th>Remarks</th>");
                    html.Append("</tr>");

                    // Data Loop - Dito natin ginagamit ang `coursesToTake` list
                    foreach (var c in coursesToTake)
                    {
                        html.Append($"<tr><td>{c.Code}</td><td>{c.Title}</td><td>{c.Units}</td><td>{c.YearLevel}</td><td>{c.Semester}</td><td class='enrolled'>For Enrollment</td></tr>");
                    }

                    html.Append("</table></body></html>");
                    System.IO.File.WriteAllText(saveFileDialog.FileName, html.ToString());
                    MessageBox.Show("Evaluation report exported successfully!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error exporting: " + ex.Message); }
        }
    }
}