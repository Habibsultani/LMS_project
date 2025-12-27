using System;
using System.Windows.Forms;

namespace LMS_project
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Forms.LoginForm());
        }
    }
}
