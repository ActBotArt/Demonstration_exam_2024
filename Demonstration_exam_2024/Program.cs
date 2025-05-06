using System;
using System.Windows.Forms;
using Demonstration_exam_2024.Forms;

namespace Demonstration_exam_2024
{
    static class Program
    {
        // Атрибут, указывающий что приложение является однопоточным STA (Single-threaded apartment)
        [STAThread]
        static void Main()
        {
            try
            {
                // Включение визуальных стилей Windows для элементов управления
                Application.EnableVisualStyles();
                // Установка режима отрисовки текста для совместимости
                Application.SetCompatibleTextRenderingDefault(false);

                // Создание и открытие формы авторизации в блоке using для автоматического освобождения ресурсов
                using (var loginForm = new LoginForm())
                {
                    // Открытие формы авторизации в модальном режиме
                    // Проверка результата диалога - если пользователь успешно авторизовался
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Если авторизация успешна, выходим из метода
                        // Основная форма уже создана и открыта в LoginForm
                        return;
                    }
                }
            }
            // Обработка всех возможных исключений при запуске приложения
            catch (Exception ex)
            {
                // Отображение окна с сообщением об ошибке
                MessageBox.Show($"Критическая ошибка при запуске приложения: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}