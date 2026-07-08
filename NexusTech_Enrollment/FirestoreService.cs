using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace NexusTech_Enrollment
{
    public class FirestoreService
    {
        private readonly FirestoreDb _db;

        public FirestoreService(string credentialPath = null)
        {
            // Order of precedence:
            // 1. explicit constructor parameter
            // 2. GOOGLE_APPLICATION_CREDENTIALS environment variable
            // 3. GoogleCredentialPath appSetting in app.config
            // 4. previous hard-coded fallback path
            string pathToKeyFile = credentialPath;

            if (string.IsNullOrWhiteSpace(pathToKeyFile))
            {
                pathToKeyFile = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");
            }

            if (string.IsNullOrWhiteSpace(pathToKeyFile))
            {
                try
                {
                    pathToKeyFile = ConfigurationManager.AppSettings["GoogleCredentialPath"];
                }
                catch
                {
                    // ignore configuration errors; will validate below
                }
            }

            if (string.IsNullOrWhiteSpace(pathToKeyFile))
            {
                pathToKeyFile = @"C:\Users\Sandra Montas\Documents\IT 332 - Ms.Zette\Final Project\Curriculum";
            }

            // If the path is a directory, try to locate a single JSON credentials file inside it.
            if (System.IO.Directory.Exists(pathToKeyFile))
            {
                var jsonFiles = System.IO.Directory.GetFiles(pathToKeyFile, "*.json", System.IO.SearchOption.TopDirectoryOnly);
                if (jsonFiles.Length == 1)
                {
                    pathToKeyFile = jsonFiles[0];
                }
                else if (jsonFiles.Length > 1)
                {
                    throw new System.InvalidOperationException($"Multiple JSON credential files found in '{pathToKeyFile}'. Specify the full path to the credential JSON file or set GOOGLE_APPLICATION_CREDENTIALS to a specific JSON file.");
                }
                else
                {
                    throw new System.IO.FileNotFoundException($"No JSON credential file found in directory '{pathToKeyFile}'. Set GOOGLE_APPLICATION_CREDENTIALS to the full path of the JSON key file.");
                }
            }

            // At this point pathToKeyFile should be a file path. Validate it.
            if (!System.IO.File.Exists(pathToKeyFile))
            {
                throw new System.IO.FileNotFoundException($"Google credential file not found at '{pathToKeyFile}'. Set GOOGLE_APPLICATION_CREDENTIALS to the full path of the JSON key file.");
            }

            // Ensure the file has a .json extension
            if (!string.Equals(System.IO.Path.GetExtension(pathToKeyFile), ".json", System.StringComparison.OrdinalIgnoreCase))
            {
                throw new System.InvalidOperationException($"Credential file '{pathToKeyFile}' is not a JSON file. Provide the full path to the JSON key file.");
            }

            // Set environment variable to the resolved JSON file path (not a directory)
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", pathToKeyFile);

            try
            {
                _db = FirestoreDb.Create("nexustech-enrollment");
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
