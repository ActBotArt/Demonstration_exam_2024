using System;
using System.Windows.Forms;
using Demonstration_exam_2024.Forms;

namespace Demonstration_exam_2024
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}