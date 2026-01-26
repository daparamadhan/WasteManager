using System;
using System.Windows.Forms;
using WasteManagementSystem.Data;
using WasteManagementSystem.Forms;

namespace WasteManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Init DB
                DatabaseHelper.InitializeDatabase();

                ApplicationConfiguration.Initialize();
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Critical Error: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Application Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}