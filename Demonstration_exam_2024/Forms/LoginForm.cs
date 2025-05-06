using System;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Demonstration_exam_2024.Utils;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Forms
{
    public partial class LoginForm : Form
    {
        // Контекст базы данных для работы с пользователями
        private readonly DatabaseContext db;
        // Подсказки для полей ввода
        private ToolTip toolTip;

        // Конструктор формы
        public LoginForm()
        {
            InitializeComponent();        // Инициализация компонентов формы
            db = new DatabaseContext();   // Создание контекста БД
            SetupForm();                 // Настройка внешнего вида формы
            TestDatabaseConnection();     // Проверка подключения к БД
        }

        // Метод настройки внешнего вида формы
        private void SetupForm()
        {
            try
            {
                // Настройка заголовка и поведения окна
                this.Text = "Мастер-Пол - Авторизация";
                this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Фиксированный размер окна
                this.MaximizeBox = false;                           // Запрет развертывания окна
                this.StartPosition = FormStartPosition.CenterScreen; // Центрирование окна
                this.BackColor = ColorTranslator.FromHtml("#F4E8D3"); // Установка цвета фона

                // Загрузка и установка логотипа
                string logoRelativePath = System.IO.Path.Combine("..", "..", "Res", "Мастер_пол.png");
                string logoFullPath = System.IO.Path.GetFullPath(
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logoRelativePath));

                if (System.IO.File.Exists(logoFullPath))
                {
                    pictureBoxLogo.Image = Image.FromFile(logoFullPath);
                    pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show($"Логотип не найден по пути: {logoFullPath}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Загрузка и установка иконки приложения
                string iconRelativePath = System.IO.Path.Combine("..", "..", "Res", "Мастер_пол.ico");
                string iconFullPath = System.IO.Path.GetFullPath(
                    System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconRelativePath));

                if (System.IO.File.Exists(iconFullPath))
                {
                    this.Icon = new Icon(iconFullPath);
                }
                else
                {
                    MessageBox.Show($"Иконка не найдена по пути: {iconFullPath}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Настройка полей ввода
                txtLogin.Text = "admin";           // Логин по умолчанию
                txtPassword.Text = "admin";        // Пароль по умолчанию
                txtPassword.PasswordChar = '●';    // Маскировка символов пароля

                // Настройка внешнего вида кнопки входа
                btnLogin.BackColor = ColorTranslator.FromHtml("#67BA80");
                btnLogin.ForeColor = Color.White;
                btnLogin.FlatStyle = FlatStyle.Flat;
                btnLogin.FlatAppearance.BorderSize = 0;
                btnLogin.Cursor = Cursors.Hand;

                // Добавление эффектов при наведении на кнопку
                btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = ColorTranslator.FromHtml("#5AA572");
                btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = ColorTranslator.FromHtml("#67BA80");

                // Настройка всплывающих подсказок
                toolTip = new ToolTip();
                toolTip.SetToolTip(txtLogin, "Введите логин");
                toolTip.SetToolTip(txtPassword, "Введите пароль");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод проверки подключения к базе данных
        private void TestDatabaseConnection()
        {
            try
            {
                var userCount = db.Users.ToList().Count;
                Debug.WriteLine($"Подключение успешно. Количество пользователей: {userCount}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик нажатия кнопки входа
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Поиск пользователя в БД по логину и паролю
                var user = db.Users.FirstOrDefault(u =>
                    u.Login == txtLogin.Text && u.Password == txtPassword.Text);

                if (user != null)
                {
                    // Если пользователь найден, открываем главную форму
                    var mainForm = new MainForm(user.UserId, user.Role);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Если пользователь не найден, показываем ошибку
                    MessageBox.Show("Неверный логин или пароль!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}\n\nПолное сообщение:\n{ex}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Освобождение ресурсов при закрытии формы
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (db != null)
            {
                db.Dispose();
            }
        }

        // Обработчик нажатия Enter в поле логина
        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();  // Переход к полю пароля
                e.Handled = true;
            }
        }

        // Обработчик нажатия Enter в поле пароля
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);  // Имитация нажатия кнопки входа
                e.Handled = true;
            }
        }
    }
}