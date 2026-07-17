using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NexusTechUniversity
{
    public partial class Student : Form
    {
        private FirestoreDb db;

        public Student()
        {
            InitializeComponent();
            db = FirestoreDb.Create("enrollmentit331");

            // Wire up the TextChanged event for the search bar
            txtboxSearchName.TextChanged += txtboxSearchName_TextChanged;
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Check if a valid row was clicked (ignores clicks on the column headers)
            // 2. Check if the clicked column is the "Evaluate" column (Index 7 based on your designer)
            if (e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                string srCode = dgvStudent.Rows[e.RowIndex].Cells[0].Value.ToString();

                Evaluation evaluation = new Evaluation(srCode);
                evaluation.Show();

                this.Hide();
            }
        }

        private async void Student_Load(object sender, EventArgs e)
        {
            await LoadStudentsAsync();
        }
        
        private async void txtboxSearchName_TextChanged(object sender, EventArgs e)
        {
            // Re-load and filter whenever the user types
            await LoadStudentsAsync(txtboxSearchName.Text.Trim());
        }

        private async Task LoadStudentsAsync(string filterText = "")
        {
            try
            {
                dgvStudent.Rows.Clear();

                CollectionReference studentsRef = db.Collection("students");
                QuerySnapshot snapshot = await studentsRef.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> data = document.ToDictionary();

                        string firstNameVal = data.ContainsKey("firstName") && data["firstName"] != null ? data["firstName"].ToString() : "";
                        string lastNameVal = data.ContainsKey("lastName") && data["lastName"] != null ? data["lastName"].ToString() : "";

                        // If there is a search filter, skip records that don't match the name
                        if (!string.IsNullOrEmpty(filterText))
                        {
                            bool matchesFirst = firstNameVal.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0;
                            bool matchesLast = lastNameVal.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0;

                            if (!matchesFirst && !matchesLast)
                            {
                                continue;
                            }
                        }

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

                        dgvStudent.Rows.Add(
                            studentIdentifier,
                            firstNameVal,
                            data.ContainsKey("middleInitial") ? data["middleInitial"] : "",
                            lastNameVal,
                            data.ContainsKey("yearLevel") ? data["yearLevel"] : "",
                            data.ContainsKey("currentSemester") ? data["currentSemester"] : "",
                            data.ContainsKey("currentAcademicYear") ? data["currentAcademicYear"] : ""
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard admindashboard = new AdminDashboard();
            admindashboard.Show();
            this.Hide();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
        }

        private void btnCurriculum_Click(object sender, EventArgs e)
        {
            Curriculum curriculum = new Curriculum();
            curriculum.Show();
            this.Hide();
        }

        private void btn_AddStudent_Click(object sender, EventArgs e)
        {
            Add_Student addstudent = new Add_Student();
            addstudent.Show();
            this.Hide();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Form1 logout = new Form1();
            logout.Show();
            this.Hide();
        }
    }
}