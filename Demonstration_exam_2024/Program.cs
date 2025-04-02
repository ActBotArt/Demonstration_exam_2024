using System;
using System.Windows.Forms;
using Demonstration_exam_2024.Forms;

namespace Demonstration_exam_2024
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Создаем форму авторизации
                using (var loginForm = new LoginForm())
                {
                    // Если авторизация успешна, форма закроется с DialogResult.OK
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Основная форма создается и открывается в LoginForm при успешной авторизации
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Критическая ошибка при запуске приложения: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}