using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demonstration_exam_2024
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка формы
                this.Text = "Мастер пол - Главное окно";

                // Загрузка иконки из файла
                this.Icon = new Icon("Resources/Мастер_пол.ico");

                this.BackColor = Color.White;
                this.Font = new Font("Segoe UI", 9F);

                // Загрузка изображения из файла
                pictureBoxLogo.Image = Image.FromFile("Resources/Мастер_пол.png");
                pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;

                // Настройка цветов панелей
                panelMenu.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Настройка кнопок
                ConfigureButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ресурсов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureButtons()
        {
            // Настраиваем все кнопки в меню
            foreach (Control control in panelMenu.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = ColorTranslator.FromHtml("#67BA80");
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                }
            }
        }

        private void btnPartners_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел Партнеры");
            // Здесь будет открытие формы управления партнерами
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел Продукция");
            // Здесь будет открытие формы управления продукцией
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел Склад");
            // Здесь будет открытие формы управления складом
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Раздел Сотрудники");
            // Здесь будет открытие формы управления сотрудниками
        }
    }
}