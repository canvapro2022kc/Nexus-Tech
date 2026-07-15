using Microsoft.VisualBasic.ApplicationServices;

namespace NexusTechUniversity
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            string keyPath = @"C:\Users\Sandra Montas\Documents\IT 332 - Ms. Zette\Final Project\Curriculum\serviceAccountKey.json.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", keyPath);
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Student());
        }
    }
}