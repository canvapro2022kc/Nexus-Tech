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
            comboBoxCurriculum.Items.Add("New");
            comboBoxCurriculum.Items.Add("Old");
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
                    string docCurriculum = data.ContainsKey("curriculum_type") ? data["curriculum_type"]?.ToString() : "";
                    string courseTrack = data.ContainsKey("track") ? data["track"]?.ToString() : "None";

                    // 1. Core Filter: Filter strictly by selected curriculum type (New or Old)
                    if (!docCurriculum.Equals(selectedCurriculum, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    // 2. Track Filter: If "Old" curriculum is selected, filter by tracks
                    if (selectedCurriculum.Equals("Old", StringComparison.OrdinalIgnoreCase))
                    {
                        // If track is not "None", it must strictly match the selected combo box track
                        if (!courseTrack.Equals("None", StringComparison.OrdinalIgnoreCase) &&
                            !courseTrack.Equals(selectedTrack, StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                    }

                    // Extract values matching screenshot keys
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
            if (selected == "Old")
            {
                comboBoxTrack.Visible = true;
            }
            else
            {
                comboBoxTrack.Visible = false;
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
    }
}