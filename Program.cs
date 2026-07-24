using CardViewer.Models;
using CardViewer.Views;
using System.Text.Json;

namespace CardViewer
{
    internal static class Program
    {
        public const string Version = "v1.0.2";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(new Home());
        }
    }
}