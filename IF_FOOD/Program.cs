using IFFood.Forms;
using System.Security.Principal;

namespace IFFood
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
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using var wPrincipal = new WPrincipal();
            Application.Run(new Form2());
        }
    }
}