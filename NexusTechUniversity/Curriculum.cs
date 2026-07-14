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

            comboBoxCurriculum.Items.Clear();
            comboBoxCurriculum.Items.Add("AY 2025-Onwards");
            comboBoxCurriculum.Items.Add("AY 2020-2024");
            comboBoxCurriculum.SelectedIndex = 0;

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

        private async Task LoadCurriculumGrid()
        {
            if (db == null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create("enrollmentit331");
            }

            if (comboBoxCurriculum.SelectedItem == null)
            {
                MessageBox.Show("Please select a curriculum type first.");
                return;
            }

            string selectedCurriculum = comboBoxCurriculum.SelectedItem.ToString();
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

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (!document.Exists) continue;

                    Dictionary<string, object> data = document.ToDictionary();

                    // Read explicit properties matching your Firestore fields
                    string docCurriculum = data.ContainsKey("curriculum_id") ? data["curriculum_id"]?.ToString() : "";
                    string courseTrack = data.ContainsKey("track") ? data["track"]?.ToString() : "None";

                    // 1. Core Filter: Filter strictly by selected curriculum type
                    if (!docCurriculum.Equals(selectedCurriculum, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    // 2. Track Filter: If "AY 2020-2024" curriculum is selected, filter by tracks
                    if (selectedCurriculum.Equals("AY 2020-2024", StringComparison.OrdinalIgnoreCase))
                    {
                        // If track is not "None", it must strictly match the selected combo box track
                        if (!courseTrack.Equals("None", StringComparison.OrdinalIgnoreCase) &&
                            !courseTrack.Equals(selectedTrack, StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                    }

                    // Extract values matching database keys
                    string courseCode = data.ContainsKey("course_code") ? data["course_code"]?.ToString() : document.Id;
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

                    dt.Rows.Add(courseCode, courseName, unitsStr, lecStr, labStr, preReq, yearOrder, semOrder, false, yearLevel, semester);
                }

                // Sort everything perfectly for structured representation
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

                ApplyFormalGridStyling();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading curriculum: " + ex.Message);
            }
        }

        private void AddSemesterTotalRow(DataTable targetTable, List<DataRow> rows)
        {
            int totalUnits = 0, totalLec = 0, totalLab = 0;
            foreach (var r in rows)
            {
                int.TryParse(r["Units"].ToString(), out int u);
                int.TryParse(r["Lec"].ToString(), out int le);
                int.TryParse(r["Lab"].ToString(), out int la);
                totalUnits += u; totalLec += le; totalLab += la;
            }
            DataRow totRow = targetTable.NewRow();
            totRow["Course Title"] = "TOTAL";
            totRow["Units"] = totalUnits;
            totRow["Lec"] = totalLec;
            totRow["Lab"] = totalLab;
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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
                if (db == null)
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                    db = FirestoreDb.Create("enrollmentit331");
                }

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
                await docRef.SetAsync(courseData);

                MessageBox.Show($"Successfully added {courseCode} to the curriculum!");
                await LoadCurriculumGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save course: " + ex.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtboxCode.Text.Trim();
            string title = txtboxTitle.Text.Trim();
            string units = txtboxUnits.Text.Trim();
            string lec = txtboxLec.Text.Trim();
            string lab = txtboxLab.Text.Trim();
            string preReq = txtboxPreReq.Text.Trim();

            string rawCurriculum = txtboxType.Text.Trim();
            string curriculum = "AY 2025-Onwards";

            if (rawCurriculum.Equals("AY 2020-2024", StringComparison.OrdinalIgnoreCase))
            {
                curriculum = "AY 2020-2024";
            }

            string rawTrack = txtboxTrack.Text.Trim();
            string track = "None";

            if (curriculum == "AY 2020-2024")
            {
                if (rawTrack.Equals("Network Technology", StringComparison.OrdinalIgnoreCase) || rawTrack.Equals("NT", StringComparison.OrdinalIgnoreCase))
                {
                    track = "Network Technology";
                }
                else if (rawTrack.Equals("Business Analytics", StringComparison.OrdinalIgnoreCase) || rawTrack.Equals("BA", StringComparison.OrdinalIgnoreCase))
                {
                    track = "Business Analytics";
                }
                else if (rawTrack.Equals("Service Management", StringComparison.OrdinalIgnoreCase) || rawTrack.Equals("SM", StringComparison.OrdinalIgnoreCase))
                {
                    track = "Service Management";
                }
                else
                {
                    track = rawTrack;
                }
            }

            string year = comboBoxLevel.SelectedItem?.ToString() ?? "First Year";
            string sem = comboBoxSem.SelectedItem?.ToString() ?? "First Semester";

            string originalCode = txtboxCode.Tag?.ToString();
            if (!string.IsNullOrEmpty(originalCode) && !originalCode.Equals(code, StringComparison.OrdinalIgnoreCase))
            {
                string oldDocId = $"{originalCode}-{track}-{curriculum}";
                try
                {
                    DocumentReference oldDocRef = db.Collection("courses").Document(oldDocId);
                    await oldDocRef.DeleteAsync();
                }
                catch { }
            }

            await AddCourseToFirestore(code, title, units, lec, lab, preReq, curriculum, track, year, sem);

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
        }

        private void dgvCurriculum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCurriculum.Rows[e.RowIndex];

                var isHeaderVal = row.Cells["IsHeader"].Value;
                if (isHeaderVal != null && (bool)isHeaderVal) return;

                txtboxCode.Text = row.Cells["Code"].Value?.ToString() ?? "";
                txtboxTitle.Text = row.Cells["Course Title"].Value?.ToString() ?? "";
                txtboxUnits.Text = row.Cells["Units"].Value?.ToString() ?? "0";
                txtboxLec.Text = row.Cells["Lec"].Value?.ToString() ?? "0";
                txtboxLab.Text = row.Cells["Lab"].Value?.ToString() ?? "0";
                txtboxPreReq.Text = row.Cells["Prerequisite"].Value?.ToString() ?? "-";

                txtboxCode.Tag = row.Cells["Code"].Value?.ToString();

                string currentCurriculum = comboBoxCurriculum.SelectedItem?.ToString() ?? "AY 2025-Onwards";
                txtboxType.Text = currentCurriculum;

                string currentTrack = currentCurriculum == "AY 2025-Onwards" ? "None" : (comboBoxTrack.SelectedItem?.ToString() ?? "None");
                txtboxTrack.Text = currentTrack;

                string yearVal = row.Cells["YearLevelDisplay"].Value?.ToString() ?? "First Year";
                comboBoxLevel.SelectedIndex = comboBoxLevel.FindStringExact(yearVal);

                string semVal = row.Cells["SemesterDisplay"].Value?.ToString() ?? "First Semester";
                comboBoxSem.SelectedIndex = comboBoxSem.FindStringExact(semVal);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string code = txtboxCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please select a course from the grid first before trying to delete it.");
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
                    string rawCurriculum = txtboxType.Text.Trim();
                    string curriculum = "AY 2025-Onwards";

                    if (rawCurriculum.Equals("AY 2020-2024", StringComparison.OrdinalIgnoreCase))
                    {
                        curriculum = "AY 2020-2024";
                    }

                    string rawTrack = txtboxTrack.Text.Trim();
                    string track = "None";
                    if (curriculum == "AY 2020-2024")
                    {
                        if (rawTrack.Equals("Network Technology", StringComparison.OrdinalIgnoreCase) || rawTrack.Equals("NT", StringComparison.OrdinalIgnoreCase))
                            track = "Network Technology";
                        else if (rawTrack.Equals("Business Analytics", StringComparison.OrdinalIgnoreCase) || rawTrack.Equals("BA", StringComparison.OrdinalIgnoreCase))
                            track = "Business Analytics";
                        else if (rawTrack.Equals("Service Management", StringComparison.OrdinalIgnoreCase) || rawTrack.Equals("SM", StringComparison.OrdinalIgnoreCase))
                            track = "Service Management";
                        else
                            track = rawTrack;
                    }

                    string docId = $"{code}-{track}-{curriculum}";

                    if (db == null)
                    {
                        string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                        db = FirestoreDb.Create("enrollmentit331");
                    }

                    DocumentReference docRef = db.Collection("courses").Document(docId);
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

        private void comboBoxSem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtboxTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDashboard adminForm = new AdminDashboard();

            adminForm.Show();

            this.Hide();
        }

        private void Curriculum_Load(object sender, EventArgs e)
        {

        }
    }
}