using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using System.Configuration;

namespace NexusTech_Enrollment
{
    public class FirestoreService
    {
        private readonly FirestoreDb _db;

        public FirestoreService(string credentialPath = null)
        {
            string pathToKeyFile = credentialPath;

            if (string.IsNullOrWhiteSpace(pathToKeyFile))
            {
                pathToKeyFile = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            }

            if (string.IsNullOrWhiteSpace(pathToKeyFile))
            {
                pathToKeyFile = @"C:\Users\Sandra Montas\Documents\IT 332 - Ms.Zette\Final Project\Curriculum\serviceAccountKey.json";
            }

            // If the path is a directory, try to locate a single JSON credentials file inside it.
            if (!System.IO.File.Exists(pathToKeyFile))
            {
                using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
                {
                    openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    openFileDialog.Title = "Firebase JSON Key Not Found! Please select it manually.";

                    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        pathToKeyFile = openFileDialog.FileName;
                    }
                    else
                    {
                        throw new System.IO.FileNotFoundException("Database initialization canceled because no valid JSON key file was selected.");
                    }
                }
            }
            

            // Set environment variable to the resolved JSON file path (not a directory)
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", pathToKeyFile);

            try
            {
                _db = FirestoreDb.Create("enrollmentit331");
            }
            catch (System.Exception ex)
            {
                throw new System.InvalidOperationException($"Error creating FirestoreDb using credentials at '{pathToKeyFile}'. See inner exception for details.", ex);
            }
        }

        public async Task<List<Dictionary<string, object>>> GetCollectionDataAsync(string collectionName)
        {
            var results = new List<Dictionary<string, object>>();

            CollectionReference collectionRef = _db.Collection(collectionName);
            QuerySnapshot snapshot = await collectionRef.GetSnapshotAsync();

            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                if (document.Exists)
                {
                    results.Add(document.ToDictionary());
                }
            }
            return results;
        }
    }
}
