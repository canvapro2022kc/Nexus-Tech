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
            public string Code = "", Title = "", Units = "", YearLevel = "", Semester = "", CurriculumId = "", Prerequisite = "";
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
                    Prerequisite = GetField(data, "pre_requisite", "prerequisite", "pre-requisite").Trim()
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
                dgCoursesTaken.Rows.Add(isAlreadyPassed, c.Code, c.Title, c.Units, c.YearLevel, c.Semester, c.Prerequisite);
            }
        }

        private bool IsMinorSubject(Course c)
        {
            string code = c.Code.ToUpper().Trim();
            return code.StartsWith("GED") ||
                   code.StartsWith("PATHFIT") ||
                   code.StartsWith("NSTP") ||
                   code.StartsWith("GEC") ||
                   code.StartsWith("PE");
        }

        private async void btnEvaluateAssign_Click(object sender, EventArgs e)
        {
            try
            {
                dgCoursesTaken.EndEdit();
                var updatedPassedCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                // 1. I-sync ang UI checkboxes patungo sa local passed list
                foreach (DataGridViewRow row in dgCoursesTaken.Rows)
                {
                    if (row.IsNewRow) continue;
                    bool isChecked = row.Cells["taken"].Value != null && Convert.ToBoolean(row.Cells["taken"].Value);
                    string code = row.Cells["courseCode"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(code) && isChecked)
                    {
                        updatedPassedCodes.Add(code.Trim());
                    }
                }

                // I-save ang updated history sa Firestore
                await db.Collection("studentCourses").Document(srCode).SetAsync(new Dictionary<string, object> {
                    { "firstName", txtFname.Text }, { "lastName", txtLname.Text },
                    { "courses", updatedPassedCodes.Select(c => new Dictionary<string, object> { { "course_code", c } }).ToList() }
                });

                passedHistory = updatedPassedCodes;

                string targetYear = txtYearLevel.Text.Trim();
                string targetSem = txtSemester.Text.Trim();
                int targetSeq = YearNum(targetYear) * 10 + SemNum(targetSem);

                // Kuhanin ang Unit Limit para sa kasalukuyang Semester
                int maxUnitsAllowed = GetMaxUnitsAllowed(currentStudentCurriculum, targetYear, targetSem);

                // Kuhanin ang lahat ng naunang subjects (Prior / Back Subjects)
                var priorCourses = allCourses
                    .Where(c => c.CurriculumId.Equals(currentStudentCurriculum, StringComparison.OrdinalIgnoreCase))
                    .Where(c => c.Seq > 0 && c.Seq < targetSeq)
                    .ToList();

                // Standing checks logic
                bool meetsStandingRequirement = CheckStandingQualifications(priorCourses, passedHistory);

                // --- PRIORITY 1: Back Subjects (Strict Semester Matching) ---
                var backSubjects = priorCourses
                    .Where(c => !passedHistory.Contains(c.Code))
                    .Where(c => c.Semester.Equals(targetSem, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(c => c.Seq)
                    .ToList();

                // --- PRIORITY 2: Current Semester Subjects ---
                var currentSemSubjects = allCourses
                    .Where(c => c.CurriculumId.Equals(currentStudentCurriculum, StringComparison.OrdinalIgnoreCase))
                    .Where(c => c.Seq == targetSeq)
                    .ToList();

                // --- PRIORITY 3: Advanced Minor Subjects (Higher Year, Same Sem) ---
                var advancedMinors = allCourses
                    .Where(c => c.CurriculumId.Equals(currentStudentCurriculum, StringComparison.OrdinalIgnoreCase))
                    .Where(c => YearNum(c.YearLevel) > YearNum(targetYear))
                    .Where(c => c.Semester.Equals(targetSem, StringComparison.OrdinalIgnoreCase))
                    .Where(c => IsMinorSubject(c))
                    .Where(c => !passedHistory.Contains(c.Code))
                    .OrderBy(c => c.Seq)
                    .ToList();

                List<Course> evaluatedToTake = new List<Course>();
                int currentTotalUnits = 0;

                // Loop para mag-load ng back subjects
                foreach (var c in backSubjects)
                {
                    if (int.TryParse(c.Units, out int unitsVal))
                    {
                        if (currentTotalUnits + unitsVal <= maxUnitsAllowed)
                        {
                            evaluatedToTake.Add(c);
                            currentTotalUnits += unitsVal;
                        }
                    }
                }

                // Helper para sa prerequisite evaluation ng kahit anong subject (Multiple Prereqs Supported)
                bool IsPrerequisiteMet(Course c)
                {
                    if (string.IsNullOrWhiteSpace(c.Prerequisite) ||
                        c.Prerequisite.Equals("-") ||
                        c.Prerequisite.Equals("None", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }

                    string req = c.Prerequisite.Trim();
                    if (req.Equals("3rd Year Standing", StringComparison.OrdinalIgnoreCase) ||
                        req.Equals("4th Year Standing", StringComparison.OrdinalIgnoreCase))
                    {
                        return meetsStandingRequirement;
                    }

                    string[] reqs = req.Split(new[] { ',', ';', '/' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var r in reqs)
                    {
                        string cleanReq = r.Trim();
                        bool hasPassedPrereq = passedHistory.Any(p => p.Equals(cleanReq, StringComparison.OrdinalIgnoreCase));
                        if (!hasPassedPrereq) return false;
                    }
                    return true;
                }

                // Loop para sa current semester subjects
                foreach (var c in currentSemSubjects)
                {
                    if (passedHistory.Contains(c.Code)) continue;
                    if (!IsPrerequisiteMet(c)) continue;

                    if (int.TryParse(c.Units, out int unitsVal))
                    {
                        if (currentTotalUnits + unitsVal <= maxUnitsAllowed)
                        {
                            evaluatedToTake.Add(c);
                            currentTotalUnits += unitsVal;
                        }
                    }
                }

                // Loop para sa advanced minor subjects
                foreach (var c in advancedMinors)
                {
                    if (currentTotalUnits >= maxUnitsAllowed) break;
                    if (!IsPrerequisiteMet(c)) continue;

                    if (int.TryParse(c.Units, out int unitsVal))
                    {
                        if (currentTotalUnits + unitsVal <= maxUnitsAllowed)
                        {
                            if (!evaluatedToTake.Any(x => x.Code.Equals(c.Code, StringComparison.OrdinalIgnoreCase)))
                            {
                                evaluatedToTake.Add(c);
                                currentTotalUnits += unitsVal;
                            }
                        }
                    }
                }

                coursesToTake = evaluatedToTake;

                // I-render sa DataGridView
                dgvCoursesToTake.Rows.Clear();
                foreach (var c in coursesToTake)
                {
                    dgvCoursesToTake.Rows.Add(c.Code, c.Title, c.Units, c.YearLevel, c.Semester, c.Prerequisite);
                }

                MessageBox.Show($"Evaluation Completed!\nTotal Units Evaluated: {currentTotalUnits} / {maxUnitsAllowed} Max Units.");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private bool CheckStandingQualifications(List<Course> priorCourses, HashSet<string> passedList)
        {
            if (priorCourses.Count == 0) return true;

            bool passedAllPrior = priorCourses.All(c => passedList.Contains(c.Code));
            if (!passedAllPrior) return false;

            double totalUnitsCount = 0;
            double passedUnitsCount = 0;

            foreach (var c in priorCourses)
            {
                if (double.TryParse(c.Units, out double u))
                {
                    totalUnitsCount += u;
                    if (passedList.Contains(c.Code))
                    {
                        passedUnitsCount += u;
                    }
                }
            }

            if (totalUnitsCount == 0) return true;
            double percentagePassed = (passedUnitsCount / totalUnitsCount) * 100.0;

            return percentagePassed >= 70.0;
        }

        private int GetMaxUnitsAllowed(string curriculum, string year, string sem)
        {
            int yrNum = YearNum(year);
            int semNum = SemNum(sem);

            if (curriculum.Equals("AY 2020-2024", StringComparison.OrdinalIgnoreCase))
            {
                if (yrNum == 1 && semNum == 1) return 23;
                if (yrNum == 1 && semNum == 2) return 23;
                if (yrNum == 2 && semNum == 1) return 23;
                if (yrNum == 2 && semNum == 2) return 23;
                if (yrNum == 3 && semNum == 1) return 21;
                if (yrNum == 3 && semNum == 2) return 21;
                if (yrNum == 3 && semNum == 3) return 6;
                if (yrNum == 4 && semNum == 1) return 21;
                if (yrNum == 4 && semNum == 2) return 6;
            }
            else // AY 2025-Onwards
            {
                if (yrNum == 1 && semNum == 1) return 24;
                if (yrNum == 1 && semNum == 2) return 24;
                if (yrNum == 2 && semNum == 1) return 23;
                if (yrNum == 2 && semNum == 2) return 23;
                if (yrNum == 2 && semNum == 3) return 6;
                if (yrNum == 3 && semNum == 1) return 21;
                if (yrNum == 3 && semNum == 2) return 21;
                if (yrNum == 3 && semNum == 3) return 6;
                if (yrNum == 4 && semNum == 1) return 21;
                if (yrNum == 4 && semNum == 2) return 6;
            }
            return 26;
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
                string nextYearStr = "";
                string nextSemStr = "";

                if (currentS == 1) // Galing First Semester
                {
                    nextSemStr = "Second Semester";
                    nextYearStr = (currentY == 1 ? "First Year" :
                                   currentY == 2 ? "Second Year" :
                                   currentY == 3 ? "Third Year" : "Fourth Year");
                }
                else if (currentS == 2) // Galing Second Semester
                {
                    nextSemStr = "First Semester";
                    int nextY = currentY + 1;
                    nextYearStr = (nextY == 2 ? "Second Year" :
                                   nextY == 3 ? "Third Year" : "Fourth Year");
                }
                else // Galing Midterm
                {
                    nextSemStr = "First Semester";
                    int nextY = currentY + 1;
                    nextYearStr = (nextY == 2 ? "Second Year" :
                                   nextY == 3 ? "Third Year" : "Fourth Year");
                }

                await db.Collection("students").Document(srCode).UpdateAsync(new Dictionary<string, object> {
                    { "yearLevel", nextYearStr }, { "currentSemester", nextSemStr }
                });

                MessageBox.Show($"Assigned! Next term: {nextYearStr} {nextSemStr}.");
                Student students = new Student();
                students.Show();
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

        private void SetupGrids()
        {
            if (dgCoursesTaken.Columns.Count > 6)
            {
                dgCoursesTaken.Columns[6].HeaderText = "Prerequisite";
                dgCoursesTaken.Columns[6].Name = "prerequisite";
            }
            if (dgvCoursesToTake.Columns.Count > 5)
            {
                dgvCoursesToTake.Columns[5].HeaderText = "Prerequisite";
                dgvCoursesToTake.Columns[5].Name = "prerequisite";
            }
        }

        private void btnBack_Click(object sender, EventArgs e) {
            Student students = new Student();
            students.Show();
            this.Hide(); }

        private async void btnExport_Click(object sender, EventArgs e)
        {
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

                    html.Append("<div class='header'>");
                    html.Append($"<img src='{logoUrl}' alt='Logo' style='width:100px;'><br>");
                    html.Append("<h1>Nexus Tech University</h1>");
                    html.Append("<div class='contact-info'>");
                    html.Append("info@nexustech.edu | 123-456-7890<br>");
                    html.Append("Batangas City, Philippines | www.nexustech.edu");
                    html.Append("</div></div>");

                    html.Append($"<p><b>Name:</b> {txtFname.Text} {txtLname.Text}</p>");
                    html.Append($"<p><b>Academic Year:</b> {txtAcademicYear.Text} | <b>Level:</b> {txtYearLevel.Text} - {txtSemester.Text}</p>");

                    html.Append("<table><tr>");
                    html.Append("<th>Code</th><th>Course Title</th><th>Units</th><th>Year</th><th>Sem</th><th>Prerequisite</th><th>Remarks</th>");
                    html.Append("</tr>");

                    foreach (var c in coursesToTake)
                    {
                        html.Append($"<tr><td>{c.Code}</td><td>{c.Title}</td><td>{c.Units}</td><td>{c.YearLevel}</td><td>{c.Semester}</td><td>{c.Prerequisite}</td><td class='enrolled'>For Enrollment</td></tr>");
                    }

                    html.Append("</table></body></html>");
                    System.IO.File.WriteAllText(saveFileDialog.FileName, html.ToString());
                    MessageBox.Show("Evaluation report exported successfully!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error exporting: " + ex.Message); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void dgvCoursesToTake_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}