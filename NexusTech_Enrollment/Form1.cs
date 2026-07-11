using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text;

namespace NexusTech_Enrollment
{
    public partial class Form1 : Form
    {
        private FirestoreService _firestoreService;
        public Form1()
        {
            InitializeComponent();

            _firestoreService = new FirestoreService();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 4. Call your service (Change "students" to match your exact Firestore collection name)
                var dataList = await _firestoreService.GetCollectionDataAsync("students");

                // 5. Build a quick text layout to display what we found
                StringBuilder sb = new StringBuilder();

                foreach (var docData in dataList)
                {
                    foreach (var field in docData)
                    {
                        sb.AppendLine($"{field.Key}: {field.Value}");
                    }
                    sb.AppendLine("-------------------------");
                }

                // 6. Show the database content in a WinForms Popup Alert box
                if (dataList.Count > 0)
                {
                    MessageBox.Show(sb.ToString(), "Firestore Data Found!");
                }
                else
                {
                    MessageBox.Show("Connected, but the collection is empty.", "Notice");
                }
            }
            catch (Exception ex)
            {
                // Helps you debug connection or path mistakes immediately
                MessageBox.Show($"Error loading data: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Text = "Connecting...";
            btnLoad.Enabled = false;

            try
            {
                var dataList = await _firestoreService.GetCollectionDataAsync("courses");

                if (dataList == null || dataList.Count == 0)
                {
                    MessageBox.Show("Connected successfully, but your Firestore collection is completely empty!",
                        "Success, but Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvCurriculum.DataSource = null;
                    return;
                }

                System.Data.DataTable dt = new System.Data.DataTable();

                foreach (var key in dataList[0].Keys)
                {
                    dt.Columns.Add(key);
                }

                foreach (var doc in dataList)
                {
                    var row = dt.NewRow();
                    foreach (var key in doc.Keys)
                    {
                        row[key] = doc[key] ?? DBNull.Value;
                    }
                    dt.Rows.Add(row);
                }

                dgvCurriculum.DataSource = dt;

                MessageBox.Show($"Success! Loaded {dataList.Count} documents from Firestore.",
                        "Connection Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection Failed!\n\nError Message: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoad.Text = "Load Firestore Data";
                btnLoad.Enabled = true;
            }
        }
    }
}
