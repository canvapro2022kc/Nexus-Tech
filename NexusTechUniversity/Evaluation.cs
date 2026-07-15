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
        private List<Dictionary<string, object>> existingTakenMaps = new List<Dictionary<string, object>>();

        private class Course
        {
            public string Code = "", Title = "", Units = "", YearLevel = "", Semester = "", CurriculumId = "";
            public List<string> Prerequisites = new List<string>();
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
                btnEvaluateAssign.Click -= btnEvaluateAssign_Click;
                btnEvaluateAssign.Click += btnEvaluateAssign_Click;
            }
            catch (Exception)
            {
                MessageBox.Show("WARNING: Hindi mahanap ang control na 'btnEvaluateAssign'. Paki-check kung tama ang Name ng button mo sa Form Designer.");
            }

            if (string.IsNullOrEmpty(srCode)) return;
            try
            {
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
                txtMI.Text = GetField(studentData, "mi", "middleInitial", "MI");
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
                    Code = GetField(data, "course_code", "courseCode"),
                    Title = GetField(data, "course_title", "courseTitle"),
                    Units = GetField(data, "units"),
                    YearLevel = GetField(data, "year_level", "yearLevel"),
                    Semester = GetField(data, "semester"),
                    CurriculumId = GetField(data, "curriculum_id"),
                };
                c.Seq = YearNum(c.YearLevel) * 10 + SemNum(c.Semester);
                allCourses.Add(c);
            }
        }

        private async Task LoadStudentCoursesHistoryAsync()
        {
            passedHistory.Clear();
            existingTakenMaps.Clear();

            var snap = await db.Collection("studentCourses").Document(srCode).GetSnapshotAsync();
            if (!snap.Exists) return;

            var data = snap.ToDictionary();
            if (data.ContainsKey("courses") && data["courses"] is System.Collections.IEnumerable list)
            {
                foreach (var item in list)
                {
                    if (item is Dictionary<string, object> m)
                    {
                        existingTakenMaps.Add(m);
                        string code = m.ContainsKey("course_code") ? m["course_code"]?.ToString() : "";
                        if (!string.IsNullOrWhiteSpace(code)) passedHistory.Add(code.Trim());
                    }
                }
            }
        }

        private void LoadCoursesTaken()
        {
            dgCoursesTaken.Rows.Clear();
            int studentSeq = YearNum(txtYearLevel.Text) * 10 + SemNum(txtSemester.Text);

            var prior = allCourses
                .Where(c => c.CurriculumId.Equals(currentStudentCurriculum, StringComparison.OrdinalIgnoreCase))
                .Where(c => c.Seq > 0 && c.Seq <= studentSeq)
                .OrderBy(c => c.Seq)
                .ToList();

            foreach (var c in prior)
            {
                bool isAlreadyPassed = passedHistory.Contains(c.Code);
                dgCoursesTaken.Rows.Add(isAlreadyPassed, c.Code, c.Title, c.Units, c.YearLevel, c.Semester, c.CurriculumId);
            }
        }

        // =====================================================================
        // MAIN FUNCTION WITH EVALUATION LOGIC
        // =====================================================================
        private async void btnEvaluateAssign_Click(object sender, EventArgs e)
        {
            try
            {
                dgCoursesTaken.EndEdit();

                // 1. KUNIN ANG LAHAT NG PASSED
                var passedCodes = new HashSet<string>(passedHistory, StringComparer.OrdinalIgnoreCase);

                foreach (DataGridViewRow row in dgCoursesTaken.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["taken"].Value))
                    {
                        passedCodes.Add(row.Cells["courseCode"].Value.ToString());
                    }
                    else
                    {
                        passedCodes.Remove(row.Cells["courseCode"].Value.ToString());
                    }
                }

                // 2. I-SAVE ANG UPDATED PASSED LIST SA FIRESTORE
                var updatedPassedList = new List<Dictionary<string, object>>();
                foreach (var code in passedCodes)
                {
                    updatedPassedList.Add(new Dictionary<string, object> { { "course_code", code } });
                }

                await db.Collection("studentCourses").Document(srCode).SetAsync(new Dictionary<string, object> {
                    { "firstName", txtFname.Text },
                    { "lastName", txtLname.Text },
                    { "courses", updatedPassedList }
                });

                passedHistory = new HashSet<string>(passedCodes, StringComparer.OrdinalIgnoreCase);

                // 3. KALKULAHIN ANG COURSES TO TAKE (Backlogs + Next Semester)
                int studentSeq = YearNum(txtYearLevel.Text) * 10 + SemNum(txtSemester.Text);
                int nextSeq = GetNextSeq(studentSeq); // Kunin ang sequence ng susunod na semester

                coursesToTake = allCourses
                    .Where(c => c.CurriculumId.Equals(currentStudentCurriculum, StringComparison.OrdinalIgnoreCase))
                    .Where(c => c.Seq > 0 && c.Seq <= nextSeq) // Hanggang sa Next Semester ang kukunin
                    .Where(c => !passedCodes.Contains(c.Code)) // Tanggalin lahat ng naipasa na
                    .OrderBy(c => c.Seq)
                    .ToList();

                // 4. I-UPDATE ANG UI
                dgvCoursesToTake.Rows.Clear();
                foreach (var c in coursesToTake)
                {
                    dgvCoursesToTake.Rows.Add(c.Code, c.Title, c.Units, c.YearLevel, c.Semester, c.CurriculumId);
                }

                MessageBox.Show($"Evaluation Saved! Nahanap na kailangang i-take para sa susunod na sem/backlogs: {coursesToTake.Count} subjects.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                var requiredList = coursesToTake.Select(c => (object)new Dictionary<string, object> {
                    { "course_code", c.Code }, { "course_title", c.Title }, { "units", int.TryParse(c.Units, out int u) ? u : 0 },
                    { "yearLevel", c.YearLevel }, { "currentSemester", c.Semester }, { "curriculum_id", c.CurriculumId }
                }).ToList();

                await db.Collection("evaluation").Document(srCode).SetAsync(new Dictionary<string, object> {
                    { "firstName", txtFname.Text }, { "lastName", txtLname.Text }, { "courses", requiredList }
                });
                MessageBox.Show("Evaluation assigned successfully!");
            }
            catch (Exception ex) { MessageBox.Show("Error assigning: " + ex.Message); }
        }

        // Helpers
        private static string GetField(Dictionary<string, object> d, params string[] k) { foreach (var key in k) if (d.ContainsKey(key)) return d[key].ToString(); return ""; }
        private static int YearNum(string y) { y = y.ToLower(); return y.Contains("first") ? 1 : y.Contains("second") ? 2 : y.Contains("third") ? 3 : 4; }
        private static int SemNum(string s) { s = s.ToLower(); return s.Contains("first") ? 1 : s.Contains("second") ? 2 : 3; }

        // Helper function para malaman ang Next Semester
        private static int GetNextSeq(int currentSeq)
        {
            int year = currentSeq / 10;
            int sem = currentSeq % 10;

            if (sem == 1) return year * 10 + 2;       // Kung 1st Sem, next is 2nd Sem
            if (sem == 2) return (year + 1) * 10 + 1; // Kung 2nd Sem, next is 1st Sem ng susunod na taon

            return currentSeq + 1;
        }

       

        private void SetupGrids()
        {
            dgCoursesTaken.Columns.Clear();
            dgCoursesTaken.AllowUserToAddRows = false;
            dgCoursesTaken.Columns.Add(new DataGridViewCheckBoxColumn { Name = "taken", HeaderText = "Taken", Width = 50 });
            dgCoursesTaken.Columns.Add(new DataGridViewTextBoxColumn { Name = "courseCode", HeaderText = "Course Code", Width = 90 });
            dgCoursesTaken.Columns.Add(new DataGridViewTextBoxColumn { Name = "courseTitle", HeaderText = "Course Title", Width = 200 });
            dgCoursesTaken.Columns.Add(new DataGridViewTextBoxColumn { Name = "units", HeaderText = "Units", Width = 50 });
            dgCoursesTaken.Columns.Add(new DataGridViewTextBoxColumn { Name = "yearLevel", HeaderText = "Year Level", Width = 90 });
            dgCoursesTaken.Columns.Add(new DataGridViewTextBoxColumn { Name = "semester", HeaderText = "Semester", Width = 100 });
            dgCoursesTaken.Columns.Add(new DataGridViewTextBoxColumn { Name = "academicYear", HeaderText = "Curriculum", Width = 110 });

            dgvCoursesToTake.Columns.Clear();
            dgvCoursesToTake.AllowUserToAddRows = false;
            dgvCoursesToTake.Columns.Add(new DataGridViewTextBoxColumn { Name = "ccode", HeaderText = "Course Code", Width = 90 });
            dgvCoursesToTake.Columns.Add(new DataGridViewTextBoxColumn { Name = "ctitle", HeaderText = "Course Title", Width = 200 });
            dgvCoursesToTake.Columns.Add(new DataGridViewTextBoxColumn { Name = "cunits", HeaderText = "Units", Width = 50 });
            dgvCoursesToTake.Columns.Add(new DataGridViewTextBoxColumn { Name = "cyearlevel", HeaderText = "Year Level", Width = 90 });
            dgvCoursesToTake.Columns.Add(new DataGridViewTextBoxColumn { Name = "csemester", HeaderText = "Semester", Width = 100 });
            dgvCoursesToTake.Columns.Add(new DataGridViewTextBoxColumn { Name = "cacademicyear", HeaderText = "Curriculum", Width = 110 });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student students = new Student();
            students.Show();
            this.Close();
        }
    }
}