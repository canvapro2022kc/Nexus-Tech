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

        public Add_Student(string studentId)
        {
            InitializeComponent();
        }

        public Add_Student()
        {
            InitializeComponent();
            // Defer runtime-only initialization to Load event to avoid design-time errors in the WinForms designer
            this.Load += Add_Student_Load;
        }

        private async void Add_Student_Load(object? sender, EventArgs e)
        {
            // Avoid running runtime initialization while the Visual Studio designer instantiates the form
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            try
            {
                if (db == null)
                {
                    db = FirestoreDb.Create("enrollmentit331");
                }

                // Optionally refresh the grid on load if needed
                await RefreshStudentsGrid();
            }
            catch (Exception ex)
            {
                // Show message at runtime only; designer won't reach this code.
                MessageBox.Show("Failed to initialize Firestore: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (db == null)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "serviceAccountKey.json";
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create("enrollmentit331");
            }

            CollectionReference collectionRef = db.Collection("students");

            Dictionary<string, object> studentData = new Dictionary<string, object>
            {
                { "studentID", txtboxCode.Text },
                { "firstName", txtboxFName.Text },
                { "middleInitial", txtboxMI.Text },
                { "lastName", txtboxLName.Text },
                { "currentAcademicYear", comboBox3.SelectedItem?.ToString() ?? "" },
                { "currentSemester", comboBox2.SelectedItem?.ToString() ?? "" },
                { "status", comboBox4.SelectedItem?.ToString() ?? "" },
                { "email", txtboxCode.Text + "@nexus.edu.ph" },
                { "subStatus", "freshman" },
                { "irregularReason", "null" },
                
                // CHANGED: Save the literal string text directly (e.g., "Third Year")
                { "yearLevel", comboBox1.SelectedItem?.ToString() ?? "" }
            };

            try
            {
                DocumentReference docRef = collectionRef.Document(txtboxCode.Text);
                await docRef.SetAsync(studentData);

                MessageBox.Show("Student successfully added!");
                await RefreshStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to Firestore: " + ex.Message);
            }
        }

        private async Task RefreshStudentsGrid()
        {
            try
            {
                CollectionReference collectionRef = db.Collection("students");
                QuerySnapshot snapshot = await collectionRef.GetSnapshotAsync();

                DataTable dt = new DataTable();
                dt.Columns.Add("SR-Code");
                dt.Columns.Add("First Name");
                dt.Columns.Add("Last Name");
                dt.Columns.Add("Year Level");
                dt.Columns.Add("Student Type");

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> data = document.ToDictionary();
                        string studentIdentifier = "";

                        if (data.ContainsKey("studentID") && data["studentID"] != null)
                        {
                            studentIdentifier = data["studentID"].ToString();
                        }
                        else if (data.ContainsKey("studentId") && data["studentId"] != null)
                        {
                            studentIdentifier = data["studentId"].ToString();
                        }
                        else
                        {
                            studentIdentifier = document.Id;
                        }
                        dt.Rows.Add(
                            studentIdentifier,
                            data.ContainsKey("firstName") ? data["firstName"] : "",
                            data.ContainsKey("lastName") ? data["lastName"] : "",
                            data.ContainsKey("yearLevel") ? data["yearLevel"] : "", // Displays string directly
                            data.ContainsKey("subStatus") ? data["subStatus"] : ""
                        );
                    }
                }

                dgvStudents.DataSource = dt;
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

                // CHANGED: Match the text string directly back into the ComboBox
                string yearVal = row.Cells["Year Level"].Value?.ToString() ?? "";
                comboBox1.SelectedIndex = comboBox1.FindStringExact(yearVal);

                comboBox4.SelectedIndex = comboBox4.FindStringExact(row.Cells["Student Type"].Value?.ToString() ?? "");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtboxFName.ReadOnly = false;
            txtboxLName.ReadOnly = false;
            txtboxMI.ReadOnly = false;
            txtboxCode.ReadOnly = false;

            MessageBox.Show("Fields are now editable. Click 'Save' when finished.");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxCode.Text))
            {
                MessageBox.Show("Please select or enter a Student ID/SR-Code to save updates.");
                return;
            }

            try
            {
                DocumentReference docRef = db.Collection("students").Document(txtboxCode.Text);

                Dictionary<string, object> updatedData = new Dictionary<string, object>
                {
                    { "studentID", txtboxCode.Text },
                    { "firstName", txtboxFName.Text },
                    { "lastName", txtboxLName.Text },
                    { "middleInitial", txtboxMI.Text },
                    { "currentAcademicYear", comboBox3.SelectedItem?.ToString() ?? "" },
                    { "currentSemester", comboBox2.SelectedItem?.ToString() ?? "" },
                    { "subStatus", comboBox4.SelectedItem?.ToString() ?? "" },
                    
                    // CHANGED: Keep it as a string here as well
                    { "yearLevel", comboBox1.SelectedItem?.ToString() ?? "" }
                };

                await docRef.SetAsync(updatedData, SetOptions.MergeAll);

                MessageBox.Show("Student changes saved successfully!");
                await RefreshStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student data: " + ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
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

                    txtboxCode.Clear();
                    txtboxFName.Clear();
                    txtboxLName.Clear();
                    txtboxMI.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;

                    await RefreshStudentsGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting student: " + ex.Message);
                }
            }
        }

        private async void btnLoadStudents_Click(object sender, EventArgs e)
        {
            await RefreshStudentsGrid();
            MessageBox.Show("Successfully loaded all students from the database.");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Show();
            this.Hide();
        }

        private void Add_Student_Load_1(object sender, EventArgs e)
        {

        }
    }
}