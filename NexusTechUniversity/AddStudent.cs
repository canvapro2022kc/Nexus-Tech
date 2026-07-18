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
    public partial class Add_Student : Form
    {
        private FirestoreDb db;

        public Add_Student()
        {
            InitializeComponent();
            this.Load += Add_Student_Load;
        }

        private async void Add_Student_Load(object? sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                if (db == null)
                {
                    db = FirestoreDb.Create("enrollmentit331");
                }

                // Lock the text box so it remains clickable/selectable but not typeable
                txtboxCode.ReadOnly = true;
                txtboxCode.TabStop = false;

                // Allow admin to type custom inputs in the Academic Year combo box
                comboBox3.DropDownStyle = ComboBoxStyle.DropDown;

                SetupComboBoxItems();
                await RefreshStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize Firestore: " + ex.Message);
            }
        }

        private void SetupComboBoxItems()
        {
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(new string[] { "freshman", "regular", "transferee", "irregular" });

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "First Year", "Second Year", "Third Year", "Fourth Year" });

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "First Semester", "Second Semester", "Midterm" });
        }

        // Helper function to dynamically determine the curriculum based on Academic Year string
        private string DetermineCurriculumId(string academicYear)
        {
            string cleanAY = academicYear.Trim();
            if (!string.IsNullOrEmpty(cleanAY) && cleanAY.Length >= 4)
            {
                if (int.TryParse(cleanAY.Substring(0, 4), out int startYear))
                {
                    if (startYear >= 2020 && startYear <= 2024)
                    {
                        return "AY 2020-2024";
                    }
                    else if (startYear >= 2025)
                    {
                        return "AY 2025-Onwards";
                    }
                }
            }
            return "AY 2025-Onwards"; // Default fallback
        }

        // Optimized server-side unique SR-Code generation (Only reads 1 document)
        private async Task<string> GenerateUniqueSRCodeAsync()
        {
            string currentYearSuffix = DateTime.Now.ToString("yy"); // e.g., "26"
            CollectionReference collectionRef = db.Collection("students");

            // This query only uses range filters, which does NOT require a composite index
            Query query = collectionRef
                .WhereGreaterThanOrEqualTo(FieldPath.DocumentId, currentYearSuffix + "-00000")
                .WhereLessThanOrEqualTo(FieldPath.DocumentId, currentYearSuffix + "-99999");

            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            int nextNumber = 1;

            // Because it naturally sorts ascending, the highest ID will be the LAST item in the list
            if (snapshot.Documents.Count > 0)
            {
                string lastId = snapshot.Documents[snapshot.Documents.Count - 1].Id; // Grab the last item
                string[] parts = lastId.Split('-');

                if (parts.Length == 2 && int.TryParse(parts[1], out int lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return $"{currentYearSuffix}-{nextNumber:D5}"; // Returns "26-00001"
        }

        private async Task GenerateStudentPassword(string srCode, string firstName, string lastName)
        {
            try
            {
                // 1. I-save ang password sa 'students' collection
                DocumentReference studentDocRef = db.Collection("students").Document(srCode);
                Dictionary<string, object> passwordData = new Dictionary<string, object>
                {
                    { "password", srCode }
                };
                await studentDocRef.SetAsync(passwordData, SetOptions.MergeAll);

                // 2. GUMAWA NG BAGONG DOCUMENT SA 'users' COLLECTION
                DocumentReference userDocRef = db.Collection("users").Document(srCode);
                Dictionary<string, object> userData = new Dictionary<string, object>
                {
                    { "firstName", firstName },
                    { "lastName", lastName },
                    { "password", srCode },         // Default password ay SR Code pa rin
                    { "role", "student" },          // Laging "student" para sa screen na ito
                    { "username", srCode }          // Ang username ay ang SR Code
                };
                await userDocRef.SetAsync(userData); // SetAsync nang walang Merge para malinis na magawa ang user record
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create user login credentials: " + ex.Message);
            }
        }

        private bool ValidateStudentInputs(out string errorMessage)
        {
            errorMessage = "";

            string firstName = txtboxFName.Text.Trim();
            string lastName = txtboxLName.Text.Trim();
            string MI = txtboxMI.Text.Trim();
            string yearLevel = comboBox1.SelectedItem?.ToString() ?? "";
            string semester = comboBox2.SelectedItem?.ToString() ?? "";
            string studentType = comboBox4.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(MI))
            {
                errorMessage = "First name, Last name, and Middle initial are required fields.";
                return false;
            }

            if (string.IsNullOrEmpty(studentType))
            {
                errorMessage = "Please select a Student Type.";
                return false;
            }

            if (string.IsNullOrEmpty(yearLevel) || string.IsNullOrEmpty(semester))
            {
                errorMessage = "Please select both a Year Level and a Semester.";
                return false;
            }

            // Validation Rule 1: Freshman must only be First Year
            if (studentType == "freshman" && yearLevel != "First Year")
            {
                errorMessage = "Validation Error: Freshmen can only be enrolled as a First Year student.";
                return false;
            }

            // Validation Rule 2: Transferee restricted to Second Year or Third Year
            if (studentType == "transferee")
            {
                bool isValidTransferee = (yearLevel == "Second Year") || (yearLevel == "Third Year");
                if (!isValidTransferee)
                {
                    errorMessage = "Validation Error: Transferee status is restricted to Second Year or Third Year levels only.";
                    return false;
                }
            }

            return true;
        }

        private async Task RefreshStudentsGrid()
        {
            try
            {
                if (db == null) return;

                CollectionReference collectionRef = db.Collection("students");
                QuerySnapshot snapshot = await collectionRef.GetSnapshotAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add("SR-Code");
                dt.Columns.Add("First Name");
                dt.Columns.Add("Middle Initial");
                dt.Columns.Add("Last Name");
                dt.Columns.Add("Year Level");
                dt.Columns.Add("Semester");
                dt.Columns.Add("Academic Year");
                dt.Columns.Add("Track"); // Added field
                dt.Columns.Add("Student Type");

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> data = document.ToDictionary();
                        string studentIdentifier = data.ContainsKey("studentID") && data["studentID"] != null
                            ? data["studentID"].ToString()
                            : document.Id;

                        dt.Rows.Add(
                            studentIdentifier,
                            data.ContainsKey("firstName") ? data["firstName"] : "",
                            data.ContainsKey("middleInitial") ? data["middleInitial"] : "",
                            data.ContainsKey("lastName") ? data["lastName"] : "",
                            data.ContainsKey("yearLevel") ? data["yearLevel"] : "",
                            data.ContainsKey("currentSemester") ? data["currentSemester"] : "",
                            data.ContainsKey("currentAcademicYear") ? data["currentAcademicYear"] : "",
                            data.ContainsKey("track") ? data["track"] : "None", // Safe fall-through fallback value
                            data.ContainsKey("subStatus") ? data["subStatus"] : ""
                        );
                    }
                }

                dgvStudents.DataSource = dt;
            //    if (dgvStudents.Columns.Contains("Middle Initial")) dgvStudents.Columns["Middle Initial"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing grid: " + ex.Message);
            }
        }

        private void dataStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                txtboxCode.Text = row.Cells["SR-Code"].Value?.ToString() ?? "";
                txtboxFName.Text = row.Cells["First Name"].Value?.ToString() ?? "";
                txtboxLName.Text = row.Cells["Last Name"].Value?.ToString() ?? "";
                txtboxMI.Text = row.Cells["Middle Initial"].Value?.ToString() ?? "";
                combotrack.Text = row.Cells["Track"].Value?.ToString() ?? "";

                string yearVal = row.Cells["Year Level"].Value?.ToString() ?? "";
                comboBox1.SelectedIndex = comboBox1.FindStringExact(yearVal);

                string semVal = row.Cells["Semester"].Value?.ToString() ?? "";
                comboBox2.SelectedIndex = comboBox2.FindStringExact(semVal);

                string acadYearVal = row.Cells["Academic Year"].Value?.ToString() ?? "";
                comboBox3.Text = acadYearVal; // Gumamit ng .Text para mabasa ang custom values

                string typeVal = row.Cells["Student Type"].Value?.ToString() ?? "";
                comboBox4.SelectedIndex = comboBox4.FindStringExact(typeVal);


            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                txtboxCode.Text = row.Cells["SR-Code"].Value?.ToString() ?? "";
                txtboxFName.Text = row.Cells["First Name"].Value?.ToString() ?? "";
                txtboxLName.Text = row.Cells["Last Name"].Value?.ToString() ?? "";
                txtboxMI.Text = row.Cells["Middle Initial"].Value?.ToString() ?? "";
                combotrack.Text = row.Cells["Track"].Value?.ToString() ?? "None";

                string yearVal = row.Cells["Year Level"].Value?.ToString() ?? "";
                comboBox1.SelectedIndex = comboBox1.FindStringExact(yearVal);

                string semVal = row.Cells["Semester"].Value?.ToString() ?? "";
                comboBox2.SelectedIndex = comboBox2.FindStringExact(semVal);

                string acadYearVal = row.Cells["Academic Year"].Value?.ToString() ?? "";
                comboBox3.Text = acadYearVal; // Gumamit ng .Text para mabasa ang custom values

                string typeVal = row.Cells["Student Type"].Value?.ToString() ?? "";
                comboBox4.SelectedIndex = comboBox4.FindStringExact(typeVal);
            }
        }

        private void Add_Student_Load_1(object sender, EventArgs e)
        {
            Add_Student_Load(sender, e);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxCode.Text))
            {
                MessageBox.Show("Please select a student from the grid to update fields.");
                return;
            }

            if (!ValidateStudentInputs(out string validationError))
            {
                MessageBox.Show(validationError, "Validation Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DocumentReference docRef = db.Collection("students").Document(txtboxCode.Text);
                string selectedAY = comboBox3.Text.Trim();
                string calculatedCurriculum = DetermineCurriculumId(selectedAY);

                Dictionary<string, object> updatedData = new Dictionary<string, object>
                {
                    { "firstName", txtboxFName.Text.Trim() },
                    { "lastName", txtboxLName.Text.Trim() },
                    { "middleInitial", txtboxMI.Text.Trim() },
                    { "currentAcademicYear", selectedAY },
                    { "curriculum_id", calculatedCurriculum }, // Dynamic classification update
                    { "currentSemester", comboBox2.SelectedItem?.ToString() ?? "" },
                    { "subStatus", comboBox4.SelectedItem.ToString() },
                    { "yearLevel", comboBox1.SelectedItem.ToString() },
                    { "track", combotrack.Text.Trim() }
                };

                await docRef.SetAsync(updatedData, SetOptions.MergeAll);

                MessageBox.Show("Student changes saved successfully!");
                ClearInputFields();
                await RefreshStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student data: " + ex.Message);
            }
        }

        private void ClearInputFields()
        {
            txtboxCode.Clear();
            txtboxFName.Clear();
            txtboxLName.Clear();
            txtboxMI.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            // Llinisin din ang curriculum academic year box at track text box
            comboBox3.SelectedIndex = -1;
            comboBox3.Text = "";
            combotrack.SelectedIndex = -1;
            combotrack.Text = "";
        }

        private async Task btnLoadStudents_Click(object sender, EventArgs e)
        {
            await RefreshStudentsGrid();
            MessageBox.Show("Successfully loaded all students from the database.");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedYear = comboBox3.Text.Trim();
            string calculatedCurriculum = DetermineCurriculumId(selectedYear);

            if (calculatedCurriculum.Equals("AY 2025-Onwards", StringComparison.OrdinalIgnoreCase))
            {
                combotrack.Text = "None";
                combotrack.Enabled = false;
                combotrack.BackColor = Color.LightGray;
            }
            else
            {
                combotrack.Enabled = true;
                combotrack.BackColor = Color.White;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDashboard adminForm = new AdminDashboard();
            adminForm.Show();
            this.Hide();
        }

        private void Add_Student_Load_2(object sender, EventArgs e) { }
        private void txtboxCode_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminDashboard adding = new AdminDashboard();
            adding.Show();
            this.Hide();
        }

        private async void btn_AddStudent_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInputs(out string validationError))
            {
                MessageBox.Show(validationError, "Validation Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string generatedSRCode = await GenerateUniqueSRCodeAsync();
                CollectionReference collectionRef = db.Collection("students");

                string selectedAY = comboBox3.Text.Trim();
                string calculatedCurriculum = DetermineCurriculumId(selectedAY);

                // BAGONG LOGIKA: Kung AY 2025-Onwards at blanko ang track, gawing "None"
                string trackValue = combotrack.Text.Trim();
                if (calculatedCurriculum == "AY 2025-Onwards" && string.IsNullOrEmpty(trackValue))
                {
                    trackValue = "None";
                }

                Dictionary<string, object> studentData = new Dictionary<string, object>
        {
            { "studentID", generatedSRCode },
            { "firstName", txtboxFName.Text.Trim() },
            { "middleInitial", txtboxMI.Text.Trim() },
            { "lastName", txtboxLName.Text.Trim() },
            { "currentAcademicYear", selectedAY },
            { "curriculum_id", calculatedCurriculum },
            { "currentSemester", comboBox2.SelectedItem?.ToString() ?? "" },
            { "status", "Enrolled" },
            { "email", $"{generatedSRCode}@nexus.edu.ph" },
            { "track", trackValue }, // Gagamitin ang sinalang trackValue
            { "subStatus", comboBox4.SelectedItem.ToString() },
            { "yearLevel", comboBox1.SelectedItem.ToString() }
        };

                DocumentReference docRef = collectionRef.Document(generatedSRCode);
                await docRef.SetAsync(studentData);

                string fName = txtboxFName.Text.Trim();
                string lName = txtboxLName.Text.Trim();
                await GenerateStudentPassword(generatedSRCode, fName, lName);

                MessageBox.Show($"Student successfully added!\nGenerated SR-Code: {generatedSRCode}\nDefault Password: {generatedSRCode}");

                ClearInputFields();
                await RefreshStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to Firestore: " + ex.Message);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            txtboxFName.ReadOnly = false;
            txtboxLName.ReadOnly = false;
            txtboxMI.ReadOnly = false;
            txtboxCode.ReadOnly = true;

            MessageBox.Show("Fields are now editable (SR-Code remains system-managed). Click 'Save' when finished.");
        }

        private async void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxCode.Text))
            {
                MessageBox.Show("Please select a student from the grid to delete.");
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to permanently delete student {txtboxCode.Text}?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    DocumentReference docRef = db.Collection("students").Document(txtboxCode.Text);
                    await docRef.DeleteAsync();

                    MessageBox.Show("Student successfully deleted from the database.");
                    ClearInputFields();
                    await RefreshStudentsGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting student: " + ex.Message);
                }
            }
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            // Ipinapasa ang tawag sa parehong lohika ng btnSave_Click para iwas kalat sa duplicate handler
            await btnSave_Click_Internal();
        }

        private async Task btnSave_Click_Internal()
        {
            if (string.IsNullOrWhiteSpace(txtboxCode.Text))
            {
                MessageBox.Show("Please select a student from the grid to update fields.");
                return;
            }

            if (!ValidateStudentInputs(out string validationError))
            {
                MessageBox.Show(validationError, "Validation Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DocumentReference docRef = db.Collection("students").Document(txtboxCode.Text);
                string selectedAY = comboBox3.Text.Trim();
                string calculatedCurriculum = DetermineCurriculumId(selectedAY);

                // BAGONG LOGIKA: Kung AY 2025-Onwards at blanko ang track, gawing "None"
                string trackValue = combotrack.Text.Trim();
                if (calculatedCurriculum == "AY 2025-Onwards" && string.IsNullOrEmpty(trackValue))
                {
                    trackValue = "None";
                }

                Dictionary<string, object> updatedData = new Dictionary<string, object>
        {
            { "firstName", txtboxFName.Text.Trim() },
            { "lastName", txtboxLName.Text.Trim() },
            { "middleInitial", txtboxMI.Text.Trim() },
            { "currentAcademicYear", selectedAY },
            { "curriculum_id", calculatedCurriculum },
            { "currentSemester", comboBox2.SelectedItem?.ToString() ?? "" },
            { "subStatus", comboBox4.SelectedItem.ToString() },
            { "yearLevel", comboBox1.SelectedItem.ToString() },
            { "track", trackValue } // Gagamitin ang sinalang trackValue
        };

                await docRef.SetAsync(updatedData, SetOptions.MergeAll);

                MessageBox.Show("Student changes saved successfully!");
                ClearInputFields();
                await RefreshStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student data: " + ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e) { }
    }
}