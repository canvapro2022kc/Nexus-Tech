using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NexusTechUniversity
{
    public partial class Curriculum : Form
    {
        private FirestoreDb db;

        public Curriculum()
        {
            InitializeComponent();
            InitializeDatabase();

            // Load curriculum options from Firestore and defaults
            _ = LoadCurriculumOptionsAsync();

            if (comboBoxTrack != null)
            {
                comboBoxTrack.Visible = false;
                comboBoxTrack.Items.Clear();
                comboBoxTrack.Items.Add("Network Technology");
                comboBoxTrack.Items.Add("Business Analytics");
                comboBoxTrack.Items.Add("Service Management");
                comboBoxTrack.SelectedIndex = 0;
                comboBoxTrack.SelectedIndexChanged += comboBoxTrack_SelectedIndexChanged;
            }
        }

        private void InitializeDatabase()
        {
            if (db == null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create("enrollmentit331");
            }
        }

        private async Task LoadCurriculumOptionsAsync()
        {
            InitializeDatabase();
            try
            {
                comboBoxCurriculum.Items.Clear();
                // Default Options
                comboBoxCurriculum.Items.Add("AY 2025-Onwards");
                comboBoxCurriculum.Items.Add("AY 2020-2024");

                // Fetch custom curricula added to the database
                CollectionReference curriculaRef = db.Collection("curricula");
                QuerySnapshot snapshot = await curriculaRef.GetSnapshotAsync();

                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    if (doc.Exists && doc.ContainsField("curriculum_id"))
                    {
                        string currId = doc.GetValue<string>("curriculum_id");
                        if (!comboBoxCurriculum.Items.Contains(currId))
                        {
                            comboBoxCurriculum.Items.Add(currId);
                        }
                    }
                }

                if (comboBoxCurriculum.Items.Count > 0)
                    comboBoxCurriculum.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading curriculum options: " + ex.Message);
            }
        }

        private async Task LoadCurriculumGrid()
        {
            InitializeDatabase();

            if (comboBoxCurriculum.SelectedItem == null)
            {
                MessageBox.Show("Please select a curriculum type first.");
                return;
            }

            string selectedCurriculum = comboBoxCurriculum.SelectedItem.ToString();
            if (!selectedCurriculum.StartsWith("AY ") && selectedCurriculum.Contains("-"))
            {
                selectedCurriculum = "AY " + selectedCurriculum;
            }

            string selectedTrack = comboBoxTrack?.SelectedItem?.ToString() ?? "";

            try
            {
                CollectionReference coursesRef = db.Collection("courses");
                QuerySnapshot snapshot = await coursesRef.GetSnapshotAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add("Code");
                dt.Columns.Add("Course Title");
                dt.Columns.Add("Units");
                dt.Columns.Add("Lec");
                dt.Columns.Add("Lab");
                dt.Columns.Add("Prerequisite");
                dt.Columns.Add("YearOrder", typeof(int));
                dt.Columns.Add("SemOrder", typeof(int));
                dt.Columns.Add("IsHeader", typeof(bool));
                dt.Columns.Add("YearLevelDisplay");
                dt.Columns.Add("SemesterDisplay");
                dt.Columns.Add("DocId"); // Hidden column tracking the actual database Key
                dt.Columns.Add("Track"); //ALY ADDED

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (!document.Exists) continue;

                    Dictionary<string, object> data = document.ToDictionary();

                    string docCurriculum = data.ContainsKey("curriculum_id") ? data["curriculum_id"]?.ToString() : "";
                    string courseTrack = data.ContainsKey("track") ? data["track"]?.ToString() : "None";

                    if (!docCurriculum.Equals(selectedCurriculum, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (selectedCurriculum.Equals("AY 2020-2024", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!courseTrack.Equals("None", StringComparison.OrdinalIgnoreCase) &&
                            !courseTrack.Equals(selectedTrack, StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                    }

                    string courseCode = data.ContainsKey("course_code") ? data["course_code"]?.ToString() : "";
                    string courseName = data.ContainsKey("course_title") ? data["course_title"]?.ToString() : "";
                    string preReq = data.ContainsKey("pre-requisite") ? data["pre-requisite"]?.ToString() : "-";
                    if (string.IsNullOrEmpty(preReq)) preReq = "-";

                    string lecStr = data.ContainsKey("lec") ? data["lec"]?.ToString() : "0";
                    string labStr = data.ContainsKey("lab") ? data["lab"]?.ToString() : "0";
                    string unitsStr = data.ContainsKey("units") ? data["units"]?.ToString() : "0";

                    string yearLevel = data.ContainsKey("year_level") ? data["year_level"]?.ToString() : "First Year";
                    string semester = data.ContainsKey("semester") ? data["semester"]?.ToString() : "First Semester";

                    int yearOrder = yearLevel.Contains("First") ? 1 : yearLevel.Contains("Second") ? 2 : yearLevel.Contains("Third") ? 3 : 4;
                    int semOrder = semester.Contains("First") ? 1 : semester.Contains("Second") ? 2 : semester.Contains("Midterm") ? 3 : 4;

                    dt.Rows.Add(courseCode, courseName, unitsStr, lecStr, labStr, preReq, yearOrder, semOrder, false, yearLevel, semester, document.Id, courseTrack); //ALY ADDED THE LAST ROW
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "YearOrder ASC, SemOrder ASC, Code ASC";
                DataTable sortedRaw = dv.ToTable();

                DataTable finalTable = dt.Clone();
                string currentYear = "";
                string currentSem = "";

                List<DataRow> currentSemRows = new List<DataRow>();

                for (int i = 0; i < sortedRaw.Rows.Count; i++)
                {
                    DataRow row = sortedRaw.Rows[i];
                    string rowYear = row["YearLevelDisplay"].ToString().ToUpper();
                    string rowSem = row["SemesterDisplay"].ToString().ToUpper();

                    if ((rowYear != currentYear || rowSem != currentSem) && currentSemRows.Count > 0)
                    {
                        AddSemesterTotalRow(finalTable, currentSemRows);
                        currentSemRows.Clear();
                    }

                    if (rowYear != currentYear)
                    {
                        currentYear = rowYear;
                        DataRow yrHeader = finalTable.NewRow();
                        yrHeader["Code"] = currentYear;
                        yrHeader["IsHeader"] = true;
                        finalTable.Rows.Add(yrHeader);
                    }

                    if (rowSem != currentSem)
                    {
                        currentSem = rowSem;
                        DataRow semHeader = finalTable.NewRow();
                        semHeader["Code"] = currentSem;
                        semHeader["IsHeader"] = true;
                        finalTable.Rows.Add(semHeader);
                    }

                    finalTable.ImportRow(row);
                    currentSemRows.Add(row);
                }

                if (currentSemRows.Count > 0)
                {
                    AddSemesterTotalRow(finalTable, currentSemRows);
                }

                dgvCurriculum.DataSource = finalTable;

                dgvCurriculum.Columns["YearOrder"].Visible = false;
                dgvCurriculum.Columns["SemOrder"].Visible = false;
                dgvCurriculum.Columns["IsHeader"].Visible = false;
                dgvCurriculum.Columns["YearLevelDisplay"].Visible = false;
                dgvCurriculum.Columns["SemesterDisplay"].Visible = false;
                dgvCurriculum.Columns["DocId"].Visible = false;

                ApplyFormalGridStyling();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading curriculum: " + ex.Message);
            }
        }

        private void AddSemesterTotalRow(DataTable targetTable, List<DataRow> rows)
        {
            int totalUnits = 0;
            foreach (var r in rows)
            {
                int.TryParse(r["Units"].ToString(), out int u);
                totalUnits += u;
            }
            DataRow totRow = targetTable.NewRow();
            totRow["Course Title"] = "TOTAL";
            totRow["Units"] = totalUnits;
            totRow["IsHeader"] = true;
            targetTable.Rows.Add(totRow);
        }

        private void ApplyFormalGridStyling()
        {
            dgvCurriculum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCurriculum.BackgroundColor = Color.White;
            dgvCurriculum.BorderStyle = BorderStyle.None;
            dgvCurriculum.RowHeadersVisible = false;
            dgvCurriculum.AllowUserToAddRows = false;
            dgvCurriculum.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCurriculum.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 40, 80);
            dgvCurriculum.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCurriculum.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCurriculum.ColumnHeadersHeight = 35;
            dgvCurriculum.EnableHeadersVisualStyles = false;

            dgvCurriculum.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            dgvCurriculum.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dgvCurriculum.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCurriculum.RowTemplate.Height = 28;

            if (dgvCurriculum.Columns.Contains("Units")) dgvCurriculum.Columns["Units"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvCurriculum.Columns.Contains("Lec")) dgvCurriculum.Columns["Lec"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvCurriculum.Columns.Contains("Lab")) dgvCurriculum.Columns["Lab"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private async void comboBoxCurriculum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBoxCurriculum.SelectedItem?.ToString() ?? "";
            if (selected == "AY 2020-2024")
            {
                comboBoxTrack.Visible = true;
                txtboxTrack.ReadOnly = false;
            }
            else
            {
                comboBoxTrack.Visible = false;
                txtboxTrack.ReadOnly = true;
            }

            await LoadCurriculumGrid();
        }

        private async void comboBoxTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadCurriculumGrid();
        }

        private void dgvCurriculum_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var isHeaderVal = dgvCurriculum.Rows[e.RowIndex].Cells["IsHeader"].Value;
                if (isHeaderVal != null && (bool)isHeaderVal)
                {
                    string titleVal = dgvCurriculum.Rows[e.RowIndex].Cells["Course Title"].Value?.ToString() ?? "";

                    if (titleVal == "TOTAL")
                    {
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        e.CellStyle.BackColor = Color.FromArgb(245, 245, 245);
                    }
                    else
                    {
                        e.CellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                        e.CellStyle.BackColor = Color.FromArgb(235, 240, 250);
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        private async Task AddCourseToFirestore(
            string courseCode,
            string courseTitle,
            string units,
            string lec,
            string lab,
            string preReq,
            string curriculumId,
            string track,
            string yearLevel,
            string semester,
            string coReq = "")
        {
            try
            {
                InitializeDatabase();

                if (string.IsNullOrWhiteSpace(courseCode) || string.IsNullOrWhiteSpace(courseTitle))
                {
                    MessageBox.Show("Course Code and Course Title are required.");
                    return;
                }

                string customDocId = $"{courseCode.Trim()}-{track.Trim()}-{curriculumId.Trim()}";

                Dictionary<string, object> courseData = new Dictionary<string, object>
                {
                    { "course_code", courseCode.Trim() },
                    { "course_title", courseTitle.Trim() },
                    { "units", int.TryParse(units, out int u) ? u : 0 },
                    { "lec", int.TryParse(lec, out int le) ? le : 0 },
                    { "lab", int.TryParse(lab, out int la) ? la : 0 },
                    { "pre-requisite", string.IsNullOrWhiteSpace(preReq) ? "" : preReq.Trim() },
                    { "co-requisite", string.IsNullOrWhiteSpace(coReq) ? "" : coReq.Trim() },
                    { "curriculum_id", curriculumId },
                    { "track", track },
                    { "year_level", yearLevel },
                    { "semester", semester }
                };

                DocumentReference docRef = db.Collection("courses").Document(customDocId);
                await docRef.SetAsync(courseData, SetOptions.MergeAll);

                MessageBox.Show($"Successfully saved {courseCode} to the curriculum!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save course: " + ex.Message);
            }
        }

        private void PopulateFormFields(DataGridViewRow row)
        {
            txtboxCode.Text = row.Cells["Code"].Value?.ToString() ?? "";
            txtboxTitle.Text = row.Cells["Course Title"].Value?.ToString() ?? "";
            txtboxUnits.Text = row.Cells["Units"].Value?.ToString() ?? "0";
            txtboxLec.Text = row.Cells["Lec"].Value?.ToString() ?? "0";
            txtboxLab.Text = row.Cells["Lab"].Value?.ToString() ?? "0";
            txtboxPreReq.Text = row.Cells["Prerequisite"].Value?.ToString() ?? "-";

            // CRITICAL FIX: Storing the original document ID inside Tag to process smooth updates
            txtboxCode.Tag = row.Cells["DocId"].Value?.ToString();

            string currentCurriculum = comboBoxCurriculum.SelectedItem?.ToString() ?? "AY 2025-Onwards";
            txtboxType.Text = currentCurriculum;

            /*string currentTrack = currentCurriculum == "AY 2025-Onwards" ? "None" : (comboBoxTrack.SelectedItem?.ToString() ?? "None");
            txtboxTrack.Text = currentTrack;*/ //ALY REMOVED
            string pulledTrack = row.Cells["Track"].Value?.ToString() ?? "";

            if (pulledTrack.Equals("None", StringComparison.OrdinalIgnoreCase))
            {
                txtboxTrack.Text = ""; // Kung "None" ang nakasave, i-blank ang textbox
            }
            else
            {
                txtboxTrack.Text = pulledTrack; //ALY ADDED

                string yearVal = row.Cells["YearLevelDisplay"].Value?.ToString() ?? "First Year";
                comboBoxLevel.SelectedIndex = comboBoxLevel.FindStringExact(yearVal);

                string semVal = row.Cells["SemesterDisplay"].Value?.ToString() ?? "First Semester";
                comboBoxSem.SelectedIndex = comboBoxSem.FindStringExact(semVal);
            }
        }

        private void dgvCurriculum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCurriculum.Rows[e.RowIndex];
                var isHeaderVal = row.Cells["IsHeader"].Value;
                if (isHeaderVal != null && (bool)isHeaderVal) return;

                PopulateFormFields(row);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDashboard adminForm = new AdminDashboard();
            adminForm.Show();
            this.Hide();
        }

        private void btn_AddCourse_Click(object sender, EventArgs e)
        {
            txtboxCode.Clear();
            txtboxCode.Tag = null;   // null tag triggers standard "Add" process
            txtboxTitle.Clear();
            txtboxUnits.Clear();
            txtboxLec.Clear();
            txtboxLab.Clear();
            txtboxPreReq.Clear();

            string currentCurriculum = comboBoxCurriculum.SelectedItem?.ToString() ?? "AY 2025-Onwards";
            txtboxType.Text = currentCurriculum;

            string currentTrack = currentCurriculum == "AY 2025-Onwards"
                ? "None"
                : (comboBoxTrack.SelectedItem?.ToString() ?? "None");
            txtboxTrack.Text = "";
            comboBoxLevel.SelectedIndex = -1;
            comboBoxSem.SelectedIndex = -1;

            txtboxCode.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dgvCurriculum.CurrentRow == null)
            {
                MessageBox.Show("Please select a course from the grid to edit.");
                return;
            }

            DataGridViewRow row = dgvCurriculum.CurrentRow;
            var isHeaderVal = row.Cells["IsHeader"].Value;
            if (isHeaderVal != null && (bool)isHeaderVal)
            {
                MessageBox.Show("Please select an actual course row, not a header or total row.");
                return;
            }

            PopulateFormFields(row);
            txtboxTitle.Focus();
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            string code = txtboxCode.Text.Trim();
            string title = txtboxTitle.Text.Trim();
            string units = txtboxUnits.Text.Trim();
            string lec = txtboxLec.Text.Trim();
            string lab = txtboxLab.Text.Trim();
            string preReq = txtboxPreReq.Text.Trim();

            // 1. BLANK FIELD VALIDATION: Check for required empty fields
            if (string.IsNullOrWhiteSpace(code) ||
                string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(units) ||
                comboBoxLevel.SelectedIndex == -1 ||
                comboBoxSem.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields (Course Code, Course Title, Units, Year Level, and Semester).",
                                "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stops the save process
            }

            // 2. NUMBER VALIDATION: Ensure Units, Lec, and Lab are numeric
            double parsedValue;
            bool isUnitsValid = double.TryParse(units, out parsedValue);
            // We allow Lec and Lab to be empty, but if they have text, it MUST be a number
            bool isLecValid = string.IsNullOrWhiteSpace(lec) || double.TryParse(lec, out parsedValue);
            bool isLabValid = string.IsNullOrWhiteSpace(lab) || double.TryParse(lab, out parsedValue);

            if (!isUnitsValid || !isLecValid || !isLabValid)
            {
                MessageBox.Show("Units, Lecture, and Laboratory fields must contain valid numbers only.",
                                "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stops the save process
            }

            string rawCurriculum = txtboxType.Text.Trim();
            if (string.IsNullOrEmpty(rawCurriculum))
            {
                MessageBox.Show("Curriculum Type is required.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string curriculum = rawCurriculum.StartsWith("AY ") ? rawCurriculum : "AY " + rawCurriculum;

            string rawTrack = txtboxTrack.Text.Trim();
            //string track = string.IsNullOrWhiteSpace(rawTrack) ? "None" : rawTrack; (ALY REMOVED)
            string track = rawTrack; //ALY ADDED

            string year = comboBoxLevel.SelectedItem?.ToString() ?? "First Year";
            string sem = comboBoxSem.SelectedItem?.ToString() ?? "First Semester";

            // This stores the true original Document Id key from Firestore
            string originalDocId = txtboxCode.Tag?.ToString();
            /* string destinationDocId = $"{code}-{track}-{curriculum}"; */ //ALY REMOVED
            string destinationDocId = string.IsNullOrWhiteSpace(track)
            ? $"{code}-{curriculum}"
            : $"{code}-{track}-{curriculum}"; //ALY ADDED

            try
            {
                InitializeDatabase();

                // 1. DYNAMIC RANGE CHECK: If curriculum input doesn't exist in dropdown collections yet
                if (!comboBoxCurriculum.Items.Contains(curriculum))
                {
                    DocumentReference currRef = db.Collection("curricula").Document(curriculum);
                    Dictionary<string, object> currData = new Dictionary<string, object>
            {
                { "curriculum_id", curriculum }
            };
                    await currRef.SetAsync(currData);

                    comboBoxCurriculum.Items.Add(curriculum);
                    comboBoxCurriculum.SelectedItem = curriculum;
                }

                // 2. SAME COURSE CODE CONSTRAINT VALIDATION
                // Only validate unique conflicts if inserting new OR updating a record to a completely different Key
                if (string.IsNullOrEmpty(originalDocId) || !originalDocId.Equals(destinationDocId, StringComparison.OrdinalIgnoreCase))
                {
                    DocumentReference targetDocCheck = db.Collection("courses").Document(destinationDocId);
                    DocumentSnapshot targetSnap = await targetDocCheck.GetSnapshotAsync();

                    if (targetSnap.Exists)
                    {
                        MessageBox.Show($"Validation Violation: A course entry with parameters matching '{code}' under '{track}' within '{curriculum}' already exists. Duplicate keys are not allowed.", "Unique Constraint Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // 3. EDIT MODE CLEANUP
                // If this is an update and the explicit Document ID composition changed, safely clear out the old node structure
                if (!string.IsNullOrEmpty(originalDocId) && !originalDocId.Equals(destinationDocId, StringComparison.OrdinalIgnoreCase))
                {
                    DocumentReference oldDocRef = db.Collection("courses").Document(originalDocId);
                    await oldDocRef.DeleteAsync();
                }

                // 4. WRITE TARGET FIELD DATA TO FIRESTORE
                await AddCourseToFirestore(code, title, units, lec, lab, preReq, curriculum, track, year, sem);

                // 5. CLEAR ALL DISPOSABLE FIELDS AND REFRESH VIEW
                txtboxCode.Clear();
                txtboxTitle.Clear();
                txtboxUnits.Clear();
                txtboxLec.Clear();
                txtboxLab.Clear();
                txtboxPreReq.Clear();
                txtboxType.Clear();
                txtboxTrack.Clear();
                comboBoxLevel.SelectedIndex = -1;
                comboBoxSem.SelectedIndex = -1;
                txtboxCode.Tag = null;

                await LoadCurriculumGrid();

                MessageBox.Show("Course successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction execution aborted under engine error: " + ex.Message);
            }
        }

        private async void btn_Delete_Click(object sender, EventArgs e)
        {
            string originalDocId = txtboxCode.Tag?.ToString();
            string code = txtboxCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(originalDocId))
            {
                MessageBox.Show("Please select a valid course from the grid first before trying to delete it.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to permanently delete {code} from the database?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    InitializeDatabase();

                    DocumentReference docRef = db.Collection("courses").Document(originalDocId);
                    await docRef.DeleteAsync();

                    MessageBox.Show($"Successfully removed {code} from the curriculum.");

                    txtboxCode.Clear();
                    txtboxCode.Tag = null;
                    txtboxTitle.Clear();
                    txtboxUnits.Clear();
                    txtboxLec.Clear();
                    txtboxLab.Clear();
                    txtboxPreReq.Clear();
                    txtboxType.Clear();
                    txtboxTrack.Clear();

                    comboBoxLevel.SelectedIndex = -1;
                    comboBoxSem.SelectedIndex = -1;

                    await LoadCurriculumGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete course: " + ex.Message);
                }
            }
        }

        private void Curriculum_Load(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void comboBoxSem_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void txtboxTitle_TextChanged(object sender, EventArgs e) { }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}