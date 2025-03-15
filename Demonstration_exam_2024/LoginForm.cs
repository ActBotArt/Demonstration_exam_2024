using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demonstration_exam_2024
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка формы
                this.Text = "Авторизация - Мастер пол";

                // Загрузка иконки из файла
                this.Icon = new Icon("Resources/Мастер_пол.ico");

                this.BackColor = Color.White;
                this.Font = new Font("Segoe UI", 9F);

                // Загрузка изображения из файла
                pictureBoxLogo.Image = Image.FromFile("Resources/Мастер_пол.png");
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;

                // Настройка цветов
                panelBackground.BackColor = ColorTranslator.FromHtml("#F4E8D3");
                btnLogin.BackColor = ColorTranslator.FromHtml("#67BA80");
                btnLogin.ForeColor = Color.White;
                btnLogin.FlatStyle = FlatStyle.Flat;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ресурсов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Здесь будет проверка логина и пароля через базу данных
            if (username == "admin" && password == "admin") // Временно для тестирования
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные учетные данные", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}