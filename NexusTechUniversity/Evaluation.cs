using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexusTechUniversity
{
    /*  ============================================================================
     *  ASSUMPTIONS  (change the constants / helpers below if your schema differs)
     *  ----------------------------------------------------------------------------
     *  CONTROL NAMES expected on this form:
     *      txtSRCode, txtFname, txtMI, txtLname,
     *      txtAcademicYear, txtYearLevel, txtSemester
     *      dgCoursesTaken   (the left grid)
     *      dgvCoursesToTake (the right grid)   <-- rename yours to this, or change below
     *      Buttons wired to: btnEvaluate_Click, btnBack_Click,
     *                        btnExport_Click, btnAssign_Click
     *
     *  FIRESTORE "courses" collection fields expected (flexible readers used):
     *      course_code, course_title, units, yearLevel, semester,
     *      academicYear (optional), prerequisites (array of course_code, optional),
     *      track (optional)
     *
     *  WRITE SHAPE for studentCourses / evaluation:
     *      Document ID = SR-Code
     *      Fields: firstName, lastName, currentAcademicYear, currentSemester,
     *              yearLevel, track (only for AY 2020-2024), and
     *              courses = [ {course_code, course_title}, ... ]   (array field)
     *  ============================================================================ */

    public partial class Evaluation : Form
    {
        private FirestoreDb db;

        // ---- config -----------------------------------------------------------
        private const string STUDENTS_COLLECTION = "students";
        private const string COURSES_COLLECTION = "courses";
        private const string STUDENT_COURSES_COLLECTION = "studentCourses";
        private const string EVALUATION_COLLECTION = "evaluation";

        // ---- state ------------------------------------------------------------
        private string srCode;
        private Dictionary<string, object> studentData = new Dictionary<string, object>();
        private List<Course> allCourses = new List<Course>();
        private List<Course> coursesToTake = new List<Course>();
        private int printIndex = 0;

        // simple model for a curriculum course
        private class Course
        {
            public string Code = "";
            public string Title = "";
            public string Units = "";
            public string YearLevel = "";
            public string Semester = "";
            public string AcademicYear = "";
            public List<string> Prerequisites = new List<string>();
            public int Seq;   // sortable position = year*10 + sem
        }

        public Evaluation(string? srCode)
        {
            InitializeComponent();
            db = FirestoreDb.Create("enrollmentit331");
            this.srCode = srCode ?? "";
        }

        // ======================================================================
        //  LOAD
        // ======================================================================
        private async void Evaluation_Load(object sender, EventArgs e)
        {
            try
            {
                SetupGrids();
                await LoadStudentAsync();     // fills the textboxes
                await LoadAllCoursesAsync();  // caches the curriculum
                LoadCoursesTaken();           // fills dgCoursesTaken with prior-sem courses

                // First-year-first-sem (freshman) -> nothing to tick.
                // Auto-generate the courses they must take right away.
                if (CountDataRows(dgCoursesTaken) == 0)
                {
                    await RunEvaluationAsync(saveToDb: false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading evaluation: " + ex.Message,
                    "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadStudentAsync()
        {
            DocumentSnapshot doc = null;

            // Try to match by studentID / studentId field first, then by document id.
            var q = await db.Collection(STUDENTS_COLLECTION)
                            .WhereEqualTo("studentID", srCode).Limit(1).GetSnapshotAsync();
            if (q.Count > 0) doc = q.Documents[0];

            if (doc == null)
            {
                var q2 = await db.Collection(STUDENTS_COLLECTION)
                                 .WhereEqualTo("studentId", srCode).Limit(1).GetSnapshotAsync();
                if (q2.Count > 0) doc = q2.Documents[0];
            }
            if (doc == null)
            {
                var byId = await db.Collection(STUDENTS_COLLECTION).Document(srCode).GetSnapshotAsync();
                if (byId.Exists) doc = byId;
            }
            if (doc == null)
            {
                MessageBox.Show("Student not found for SR-Code: " + srCode);
                return;
            }

            studentData = doc.ToDictionary();

            txtSRCode.Text = srCode;
            txtFname.Text = GetField(studentData, "firstName");
            txtMI.Text = GetField(studentData, "middleInitial", "mi", "MI");
            txtLname.Text = GetField(studentData, "lastName");
            txtAcademicYear.Text = GetField(studentData, "currentAcademicYear", "academicYear");
            txtYearLevel.Text = GetField(studentData, "yearLevel");
            txtSemester.Text = GetField(studentData, "currentSemester", "semester");
        }

        private async Task LoadAllCoursesAsync()
        {
            allCourses.Clear();
            var snap = await db.Collection(COURSES_COLLECTION).GetSnapshotAsync();
            foreach (var d in snap.Documents)
            {
                if (!d.Exists) continue;
                var data = d.ToDictionary();

                var c = new Course
                {
                    Code = GetField(data, "course_code", "courseCode", "code"),
                    Title = GetField(data, "course_title", "courseTitle", "title"),
                    Units = GetField(data, "units", "unit"),
                    YearLevel = GetField(data, "yearLevel", "year_level", "year"),
                    Semester = GetField(data, "semester", "sem"),
                    AcademicYear = GetField(data, "academicYear", "academic_year"),
                    Prerequisites = GetPrereqs(data)
                };
                c.Seq = YearNum(c.YearLevel) * 10 + SemNum(c.Semester);
                allCourses.Add(c);
            }
        }

        // Loads every curriculum course scheduled BEFORE the student's current
        // position. These are the ones the admin ticks off as "already passed".
        private void LoadCoursesTaken()
        {
            dgCoursesTaken.Rows.Clear();

            int studentSeq = YearNum(txtYearLevel.Text) * 10 + SemNum(txtSemester.Text);

            var prior = allCourses
                .Where(c => c.Seq > 0 && c.Seq < studentSeq)
                .OrderBy(c => c.Seq).ThenBy(c => c.Code)
                .ToList();

            foreach (var c in prior)
            {
                dgCoursesTaken.Rows.Add(false, c.Code, c.Title, c.Units,
                                        c.YearLevel, c.Semester, c.AcademicYear);
            }
        }

        // ======================================================================
        //  EVALUATE
        // ======================================================================
        private async void btnEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                await RunEvaluationAsync(saveToDb: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Evaluation failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RunEvaluationAsync(bool saveToDb)
        {
            dgCoursesTaken.EndEdit();

            // 1) Build the "passed" set from ticked rows.
            var passed = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var takenCourses = new List<Course>();

            foreach (DataGridViewRow row in dgCoursesTaken.Rows)
            {
                if (row.IsNewRow) continue;
                bool ticked = row.Cells["taken"].Value != null &&
                              Convert.ToBoolean(row.Cells["taken"].Value);
                if (!ticked) continue;

                string code = Convert.ToString(row.Cells["courseCode"].Value) ?? "";
                if (code == "") continue;

                passed.Add(code);
                takenCourses.Add(new Course
                {
                    Code = code,
                    Title = Convert.ToString(row.Cells["courseTitle"].Value) ?? ""
                });
            }

            // 2) Persist the passed courses to studentCourses (only when the admin
            //    pressed Evaluate; freshman auto-run has nothing to save).
            if (saveToDb && takenCourses.Count > 0)
            {
                var data = BuildStudentInfoDict();
                data["courses"] = takenCourses
                    .Select(c => (object)new Dictionary<string, object>
                    {
                        { "course_code",  c.Code },
                        { "course_title", c.Title }
                    }).ToList();

                await db.Collection(STUDENT_COURSES_COLLECTION)
                        .Document(srCode).SetAsync(data);
            }

            // 3) Work out what the student may take.
            //    Rule: a course is eligible if it is at (or before) the student's
            //    current position, has NOT already been passed, and ALL of its
            //    prerequisites are in the passed set.
            //    (Using <= includes retakes of failed earlier courses. Change to
            //     == studentSeq if you want strictly the current semester only.)
            int studentSeq = YearNum(txtYearLevel.Text) * 10 + SemNum(txtSemester.Text);

            coursesToTake = allCourses
                .Where(c => c.Seq > 0 && c.Seq <= studentSeq)
                .Where(c => !passed.Contains(c.Code))
                .Where(c => c.Prerequisites.All(p => passed.Contains(p)))
                .OrderBy(c => c.Seq).ThenBy(c => c.Code)
                .ToList();

            // 4) Show them.
            dgvCoursesToTake.Rows.Clear();
            foreach (var c in coursesToTake)
            {
                dgvCoursesToTake.Rows.Add(c.Code, c.Title, c.Units,
                                          c.YearLevel, c.Semester, c.AcademicYear);
            }

            if (saveToDb)
            {
                MessageBox.Show(
                    coursesToTake.Count == 0
                        ? "Evaluation complete. No eligible courses found."
                        : $"Evaluation complete. {coursesToTake.Count} course(s) recommended.",
                    "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ======================================================================
        //  ASSIGN TO STUDENT  ->  writes to the "evaluation" collection
        // ======================================================================
        private async void btnAssign_Click(object sender, EventArgs e)
        {
            if (coursesToTake == null || coursesToTake.Count == 0)
            {
                MessageBox.Show("Nothing to assign. Run Evaluate first.");
                return;
            }
            try
            {
                var data = BuildStudentInfoDict();
                data["courses"] = coursesToTake
                    .Select(c => (object)new Dictionary<string, object>
                    {
                        { "course_code",  c.Code },
                        { "course_title", c.Title }
                    }).ToList();

                await db.Collection(EVALUATION_COLLECTION)
                        .Document(srCode).SetAsync(data);

                MessageBox.Show("Evaluation assigned to student successfully.",
                    "Assigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to assign: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================================================
        //  EXPORT  ->  printable preview of the courses-to-take
        // ======================================================================
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (coursesToTake == null || coursesToTake.Count == 0)
            {
                MessageBox.Show("Nothing to export. Run Evaluate first.");
                return;
            }

            printIndex = 0;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;

            using (var preview = new PrintPreviewDialog { Document = pd, Width = 850, Height = 650 })
            {
                preview.ShowDialog();
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            using Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold);
            using Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
            using Font font = new Font("Segoe UI", 10);

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            if (printIndex == 0)
            {
                g.DrawString("NexusTech University", titleFont, Brushes.Black, x, y); y += 32;
                g.DrawString("Course Evaluation — Courses to Take", headerFont, Brushes.Black, x, y); y += 24;
                g.DrawString($"SR-Code: {txtSRCode.Text}    Name: {txtFname.Text} {txtMI.Text} {txtLname.Text}",
                             font, Brushes.Black, x, y); y += 18;
                g.DrawString($"Academic Year: {txtAcademicYear.Text}    Year Level: {txtYearLevel.Text}    Semester: {txtSemester.Text}",
                             font, Brushes.Black, x, y); y += 26;

                g.DrawString("Code", headerFont, Brushes.Black, x, y);
                g.DrawString("Title", headerFont, Brushes.Black, x + 130, y);
                g.DrawString("Units", headerFont, Brushes.Black, x + 430, y);
                y += 20;
                g.DrawLine(Pens.Black, x, y, e.MarginBounds.Right, y);
                y += 6;
            }

            while (printIndex < coursesToTake.Count)
            {
                var c = coursesToTake[printIndex];
                g.DrawString(c.Code, font, Brushes.Black, x, y);
                g.DrawString(c.Title, font, Brushes.Black, x + 130, y);
                g.DrawString(c.Units, font, Brushes.Black, x + 430, y);
                y += 18;
                printIndex++;

                if (y > e.MarginBounds.Bottom - 20 && printIndex < coursesToTake.Count)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            e.HasMorePages = false;
        }

        // ======================================================================
        //  BACK
        // ======================================================================
        private void btnBack_Click(object sender, EventArgs e)
        {
            Student students = new Student();
            students.Show();
            this.Hide();
        }

        // ======================================================================
        //  HELPERS
        // ======================================================================
        private void SetupGrids()
        {
            // ---- Courses Taken (has a Taken checkbox) ----
            dgCoursesTaken.Columns.Clear();
            dgCoursesTaken.AutoGenerateColumns = false;
            dgCoursesTaken.AllowUserToAddRows = false;
            dgCoursesTaken.EditMode = DataGridViewEditMode.EditOnEnter; // single-click toggle

            dgCoursesTaken.Columns.Add(new DataGridViewCheckBoxColumn { Name = "taken", HeaderText = "Taken", Width = 50 });
            AddTextCol(dgCoursesTaken, "courseCode", "Course Code");
            AddTextCol(dgCoursesTaken, "courseTitle", "Course Title", 220);
            AddTextCol(dgCoursesTaken, "units", "Units", 55);
            AddTextCol(dgCoursesTaken, "yearLevel", "Year Level");
            AddTextCol(dgCoursesTaken, "semester", "Semester");
            AddTextCol(dgCoursesTaken, "academicYear", "Academic Year");

            // ---- Courses To Take (read-only) ----
            dgvCoursesToTake.Columns.Clear();
            dgvCoursesToTake.AutoGenerateColumns = false;
            dgvCoursesToTake.AllowUserToAddRows = false;
            dgvCoursesToTake.ReadOnly = true;

            AddTextCol(dgvCoursesToTake, "ccode", "Course Code");
            AddTextCol(dgvCoursesToTake, "ctitle", "Course Title", 220);
            AddTextCol(dgvCoursesToTake, "cunits", "Units", 55);
            AddTextCol(dgvCoursesToTake, "cyearlevel", "Year Level");
            AddTextCol(dgvCoursesToTake, "csemester", "Semester");
            AddTextCol(dgvCoursesToTake, "cacademicyear", "Academic Year");
        }

        private static void AddTextCol(DataGridView grid, string name, string header, int width = 110)
        {
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                Width = width,
                ReadOnly = true
            });
        }

        private static int CountDataRows(DataGridView grid)
        {
            int n = 0;
            foreach (DataGridViewRow r in grid.Rows) if (!r.IsNewRow) n++;
            return n;
        }

        private Dictionary<string, object> BuildStudentInfoDict()
        {
            var d = new Dictionary<string, object>
            {
                { "firstName",           txtFname.Text },
                { "lastName",            txtLname.Text },
                { "currentAcademicYear", txtAcademicYear.Text },
                { "currentSemester",     txtSemester.Text },
                { "yearLevel",           txtYearLevel.Text }
            };

            // "track for those in AY 2020-2024"
            int startYear = ExtractStartYear(txtAcademicYear.Text);
            if (startYear >= 2020 && startYear <= 2024)
                d["track"] = GetField(studentData, "track");

            return d;
        }

        private static string GetField(Dictionary<string, object> data, params string[] keys)
        {
            foreach (var k in keys)
                if (data.ContainsKey(k) && data[k] != null)
                    return data[k].ToString();
            return "";
        }

        private static List<string> GetPrereqs(Dictionary<string, object> data)
        {
            var result = new List<string>();
            foreach (var key in new[] { "prerequisites", "prereq", "prerequisite", "prereqs" })
            {
                if (!data.ContainsKey(key) || data[key] == null) continue;

                var val = data[key];
                if (val is System.Collections.IEnumerable list && val is not string)
                {
                    foreach (var item in list)
                        if (item != null && !string.IsNullOrWhiteSpace(item.ToString()))
                            result.Add(item.ToString().Trim());
                }
                else
                {
                    foreach (var part in val.ToString().Split(new[] { ',', ';' },
                             StringSplitOptions.RemoveEmptyEntries))
                        result.Add(part.Trim());
                }
                break;
            }
            return result;
        }

        // Convert "1st Year" / "First Year" / "2" -> 1,2,3,4 ...
        private static int YearNum(string yearLevel)
        {
            if (string.IsNullOrWhiteSpace(yearLevel)) return 0;
            string s = yearLevel.Trim().ToLower();
            if (s.Contains("first") || s.Contains("1")) return 1;
            if (s.Contains("second") || s.Contains("2")) return 2;
            if (s.Contains("third") || s.Contains("3")) return 3;
            if (s.Contains("fourth") || s.Contains("4")) return 4;
            if (s.Contains("fifth") || s.Contains("5")) return 5;
            return 0;
        }

        // Convert semester text -> 1 (first), 2 (second), 3 (summer/midyear)
        private static int SemNum(string semester)
        {
            if (string.IsNullOrWhiteSpace(semester)) return 0;
            string s = semester.Trim().ToLower();
            if (s.Contains("summer") || s.Contains("mid")) return 3;
            if (s.Contains("second") || s.Contains("2")) return 2;
            if (s.Contains("first") || s.Contains("1")) return 1;
            return 0;
        }

        private static int ExtractStartYear(string academicYear)
        {
            if (string.IsNullOrWhiteSpace(academicYear)) return 0;
            var digits = new string(academicYear.TrimStart().TakeWhile(char.IsDigit).ToArray());
            return int.TryParse(digits, out int y) ? y : 0;
        }

        // ======================================================================
        //  Designer-referenced stubs kept so the form still compiles.
        //  (Leave them; they do nothing unless you wired something to them.)
        // ======================================================================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) { }
        private void btnLoad_Click(object sender, EventArgs e) { }
        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvStudents_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void mi_txt_TextChanged(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
    }
}