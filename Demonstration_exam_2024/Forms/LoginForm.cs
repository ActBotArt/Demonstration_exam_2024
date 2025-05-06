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
        private readonly DatabaseContext db;
        private ToolTip toolTip; // Изменяем объявление tooltip

        public LoginForm()
        {
            InitializeComponent();
            db = new DatabaseContext();
            SetupForm();
            TestDatabaseConnection();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка формы
                this.Text = "Мастер-Пол - Авторизация";
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                // Настройка фона и цветов
                this.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Загрузка логотипа
                string logoRelativePath = System.IO.Path.Combine("..", "..", "Res", "Мастер_пол.png");
                string logoFullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logoRelativePath));

                if (System.IO.File.Exists(logoFullPath))
                {
                    pictureBoxLogo.Image = Image.FromFile(logoFullPath);
                    pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show($"Логотип не найден по пути: {logoFullPath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Загрузка иконки
                string iconRelativePath = System.IO.Path.Combine("..", "..", "Res", "Мастер_пол.ico");
                string iconFullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconRelativePath));

                if (System.IO.File.Exists(iconFullPath))
                {
                    this.Icon = new Icon(iconFullPath);
                }
                else
                {
                    MessageBox.Show($"Иконка не найдена по пути: {iconFullPath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Настройка текстовых полей
                txtLogin.Text = "admin"; // Значение по умолчанию
                txtPassword.Text = "admin"; // Значение по умолчанию
                txtPassword.PasswordChar = '●';

                // Настройка кнопки
                btnLogin.BackColor = ColorTranslator.FromHtml("#67BA80");
                btnLogin.ForeColor = Color.White;
                btnLogin.FlatStyle = FlatStyle.Flat;
                btnLogin.FlatAppearance.BorderSize = 0;
                btnLogin.Cursor = Cursors.Hand;

                // Добавляем эффект при наведении на кнопку
                btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = ColorTranslator.FromHtml("#5AA572");
                btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = ColorTranslator.FromHtml("#67BA80");

                // Инициализация и настройка ToolTip
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

        private void TestDatabaseConnection()
        {
            try
            {
                // Используем ToList() перед Count() для выполнения запроса
                var userCount = db.Users.ToList().Count;
                Debug.WriteLine($"Подключение успешно. Количество пользователей: {userCount}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var user = db.Users.FirstOrDefault(u =>
                    u.Login == txtLogin.Text && u.Password == txtPassword.Text);

                if (user != null)
                {
                    var mainForm = new MainForm(user.UserId, user.Role);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (db != null)
            {
                db.Dispose();
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}