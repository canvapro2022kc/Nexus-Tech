using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NexusTechUniversity
{
    public partial class Evaluation : Form
    {
        private FirestoreDb db;

        private string currentStudentId;
        private string? studentId;

        public Evaluation(string? srCode)
        {
            InitializeComponent();

            // 1. Assign the passed parameter (srCode) to your class variable
            currentStudentId = srCode;

            // 2. Initialize Firestore so it is ready for your Load event or btnLoad_Click
            // Remember to replace with your actual project ID
            db = FirestoreDb.Create("enrollmentit331");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
        }

        private async void Evaluation_Load(object sender, EventArgs e)
        {
            // Ensure we actually received an ID before trying to load data
            if (string.IsNullOrEmpty(currentStudentId))
            {
                MessageBox.Show("No student ID was provided.");
                return;
            }// Designer expects this handler. No initialization required currently.

            try
            {
                // 1. Clear everything (both rows AND any old columns)
                dgvStudents.Rows.Clear();
                dgvStudents.Columns.Clear();

                // 2. DYNAMICALLY ADD COLUMNS
                // Format: Columns.Add("ColumnName", "Header Text");
                dgvStudents.Columns.Add("srCode", "SR-Code");
                dgvStudents.Columns.Add("firstName", "First Name");
                dgvStudents.Columns.Add("lastName", "Last Name");
                dgvStudents.Columns.Add("yearLevel", "Year Level");
                dgvStudents.Columns.Add("status", "Status");

                // Make the columns automatically stretch to fill the grid
                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // ---> ADD THESE TWO LINES HERE <---
                // This removes the first column with the arrow/asterisk
                dgvStudents.RowHeadersVisible = false;

                // This removes the blank row at the very bottom
                dgvStudents.AllowUserToAddRows = false;

                // ==========================================
                // 3. LOAD SPECIFIC STUDENT DETAILS
                // ==========================================
                DocumentReference studentRef = db.Collection("students").Document(currentStudentId);
                DocumentSnapshot studentSnap = await studentRef.GetSnapshotAsync();

                if (studentSnap.Exists)
                {
                    Dictionary<string, object> data = studentSnap.ToDictionary();

                    // Now this will work perfectly because the 5 columns exist!
                    dgvStudents.Rows.Add(
                        currentStudentId,
                        data.ContainsKey("firstName") ? data["firstName"] : "",
                        data.ContainsKey("lastName") ? data["lastName"] : "",
                        data.ContainsKey("yearLevel") ? data["yearLevel"] : "",
                        data.ContainsKey("status") ? data["status"] : ""
                    );
                }

                // ==========================================
                // SETUP COURSES DATAGRIDVIEW
                // ==========================================
                dgvCourses.Rows.Clear();
                dgvCourses.Columns.Clear();

                // Create a Checkbox Column for the admin to select passed courses
                DataGridViewCheckBoxColumn chkPassed = new DataGridViewCheckBoxColumn();
                chkPassed.Name = "chkPassed";
                chkPassed.HeaderText = "Passed";
                chkPassed.Width = 50;
                dgvCourses.Columns.Add(chkPassed);

                // Add the rest of the course columns
                dgvCourses.Columns.Add("courseCode", "Course Code");
                dgvCourses.Columns.Add("courseTitle", "Course Title");
                dgvCourses.Columns.Add("units", "Units");

                // Formatting to match your clean UI
                dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCourses.RowHeadersVisible = false;
                dgvCourses.AllowUserToAddRows = false;

                // ==========================================
                // SETUP PROGRAM OF STUDY DATAGRIDVIEW
                // ==========================================
                dgvProgramOfStudy.Rows.Clear();
                dgvProgramOfStudy.Columns.Clear();

                // This one doesn't need a checkbox, just the course details
                dgvProgramOfStudy.Columns.Add("courseCode", "Course Code");
                dgvProgramOfStudy.Columns.Add("courseTitle", "Course Title");
                dgvProgramOfStudy.Columns.Add("units", "Units");

                // Formatting
                dgvProgramOfStudy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProgramOfStudy.RowHeadersVisible = false;
                dgvProgramOfStudy.AllowUserToAddRows = false;

                // ==========================================
                // LOAD COURSES FROM FIRESTORE
                // ==========================================
                // Query your studentCourses collection here
                Query coursesQuery = db.Collection("studentCourses").WhereEqualTo("studentID", currentStudentId);
                QuerySnapshot coursesSnap = await coursesQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot courseDoc in coursesSnap.Documents)
                {
                    if (courseDoc.Exists)
                    {
                        Dictionary<string, object> courseData = courseDoc.ToDictionary();

                        // Add row: The 'false' sets the checkbox to unchecked by default
                        dgvCourses.Rows.Add(
                            false,
                            courseData.ContainsKey("courseCode") ? courseData["courseCode"] : "",
                            courseData.ContainsKey("courseTitle") ? courseData["courseTitle"] : "",
                            courseData.ContainsKey("units") ? courseData["units"] : ""
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private async void btnEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. KUNIN ANG MGA NAIPASA (CHECKED) NA SUBJECTS
                List<string> passedCourses = new List<string>();

                foreach (DataGridViewRow row in dgvCourses.Rows)
                {
                    DataGridViewCheckBoxCell chk = row.Cells["chkPassed"] as DataGridViewCheckBoxCell;

                    // Kung naka-check ang box, i-save ang course code sa listahan
                    if (chk != null && chk.Value != null && (bool)chk.Value == true)
                    {
                        string courseCode = row.Cells["courseCode"].Value?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(courseCode))
                        {
                            passedCourses.Add(courseCode);
                        }
                    }
                }

                // Linisin ang right grid (Program of Study) bago maglagay ng bagong data
                dgvProgramOfStudy.Rows.Clear();

                // 2. KUNIN ANG MASTER CURRICULUM SA FIRESTORE
                // Kukunin natin ang collection na "courses" (ito yung master list ng lahat ng subjects)
                CollectionReference curriculumRef = db.Collection("courses");
                QuerySnapshot curriculumSnap = await curriculumRef.GetSnapshotAsync();

                // 3. I-COMPARE AT I-DISPLAY ANG MGA KULANG PANG SUBJECTS
                foreach (DocumentSnapshot doc in curriculumSnap.Documents)
                {
                    if (doc.Exists)
                    {
                        Dictionary<string, object> courseData = doc.ToDictionary();

                        string masterCourseCode = courseData.ContainsKey("courseCode") ? courseData["courseCode"].ToString() : "";

                        // LOGIC: Kung WALA sa 'passedCourses' ang master subject na ito, 
                        // ibig sabihin kailangan niya itong kunin/retake!
                        if (!string.IsNullOrEmpty(masterCourseCode) && !passedCourses.Contains(masterCourseCode))
                        {
                            string title = courseData.ContainsKey("courseTitle") ? courseData["courseTitle"].ToString() : "";
                            string units = courseData.ContainsKey("units") ? courseData["units"].ToString() : "";

                            // Ilagay sa kanang table (Program of Study)
                            dgvProgramOfStudy.Rows.Add(masterCourseCode, title, units);
                        }
                    }
                }

                // Notification Message para sa Admin
                if (dgvProgramOfStudy.Rows.Count > 0)
                {
                    MessageBox.Show("Evaluation complete! Generated the remaining Program of Study.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Evaluation complete! The student has passed all subjects in the curriculum.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Program of Study: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
