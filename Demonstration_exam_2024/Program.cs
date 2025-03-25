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

            try
            {
                // Проверяем подключение к БД
                using (var db = new partner_system_dbEntities())
                {
                    db.Database.Connection.Open();
                }

                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}