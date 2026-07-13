using Google.Cloud.Firestore;

namespace NexusTechUniversity
{
    public partial class Student : Form
    {
        private FirestoreDb db;
        public Student()
        {
            InitializeComponent();
            db = FirestoreDb.Create("enrollmentit331");
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Add_Student addstudent = new Add_Student();
            addstudent.Show();
            this.Hide();
        }


        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Check if a valid row was clicked (ignores clicks on the column headers)
            // 2. Check if the clicked column is the "Evaluate" column (Index 4)
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                // Retrieve the SR-Code from Column 0 of the clicked row
                string srCode = dgvStudent.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Create the new form and pass the SR-Code to its constructor
                // Note: Change 'AddStudent' if your evaluation form has a different class name
                Evaluation evaluation = new Evaluation(srCode);
                evaluation.Show();

                // Hide the current student list form
                this.Hide();
            }
        }

        private async void Student_Load(object sender, EventArgs e)
        {
            try
            {
                // Clear existing rows
                dgvStudent.Rows.Clear();

                // Fetch the 'students' collection
                CollectionReference studentsRef = db.Collection("students");
                QuerySnapshot snapshot = await studentsRef.GetSnapshotAsync();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Dictionary<string, object> data = document.ToDictionary();
                        string studentIdentifier = "";

                        // Checks for "studentID", then "studentId", then falls back to Document ID
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

                        // Add directly to the DataGridView using your formatting style
                        dgvStudent.Rows.Add(
                            studentIdentifier,
                            data.ContainsKey("firstName") ? data["firstName"] : "",
                            data.ContainsKey("middleInitial") ? data["middleInitial"] : "",
                            data.ContainsKey("lastName") ? data["lastName"] : ""
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
