using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO; 
using Demonstration_exam_2024.Utils;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Forms
{
    public partial class PartnerEditForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int? partnerId;
        private Partner partner;

        public PartnerEditForm(int? partnerId = null)
        {
            InitializeComponent();
            db = new DatabaseContext();
            this.partnerId = partnerId;
            SetupForm();
            LoadData();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка формы
                this.Text = partnerId.HasValue ? "Редактирование партнера" : "Добавление партнера";

                // Загрузка иконки
                // Загрузка иконки в формате ICO, используя относительный путь от каталога запуска приложения
                string relativePath = System.IO.Path.Combine("..", "..", "Resources", "Мастер_пол.ico");
                string iconPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath));

                if (System.IO.File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
                else
                {
                    MessageBox.Show($"Иконка не найдена по пути: {iconPath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Настройка цветов
                this.BackColor = Color.White;
                panelTop.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Настройка комбобокса типов компаний
                cmbCompanyType.Items.AddRange(new[] { "ООО", "ПАО", "АО", "ЗАО", "ОАО" });
                cmbCompanyType.DropDownStyle = ComboBoxStyle.DropDownList;

                // Настройка кнопок
                StyleButtons();

                // Настройка валидации
                SetupValidation();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleButtons()
        {
            foreach (Button btn in new[] { btnSave, btnCancel })
            {
                btn.BackColor = ColorTranslator.FromHtml("#67BA80");
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = new Font("Segoe UI", 9F);
            }
            btnCancel.BackColor = Color.Gray;
        }

        private void SetupValidation()
        {
            // Ограничение длины полей
            txtCompanyName.MaxLength = 200;
            txtDirectorName.MaxLength = 150;
            txtPhone.MaxLength = 20;
            txtEmail.MaxLength = 100;
            txtAddress.MaxLength = 300;
            txtINN.MaxLength = 12;

            // Валидация рейтинга
            numericRating.Minimum = 0;
            numericRating.Maximum = 10;

            // Валидация телефона
            txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '+' && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != '\b')
                    e.Handled = true;
            };

            // Валидация ИНН
            txtINN.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                    e.Handled = true;
            };
        }

        private void LoadData()
        {
            if (partnerId.HasValue)
            {
                partner = db.Partners.Find(partnerId.Value);
                if (partner != null)
                {
                    cmbCompanyType.Text = partner.CompanyType;
                    txtCompanyName.Text = partner.CompanyName;
                    txtDirectorName.Text = partner.DirectorName;
                    txtPhone.Text = partner.Phone;
                    txtEmail.Text = partner.Email;
                    txtAddress.Text = partner.Address;
                    txtINN.Text = partner.INN;
                    numericRating.Value = partner.Rating.GetValueOrDefault();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                if (partner == null)
                    partner = new Partner();

                partner.CompanyType = cmbCompanyType.Text;
                partner.CompanyName = txtCompanyName.Text.Trim();
                partner.DirectorName = txtDirectorName.Text.Trim();
                partner.Phone = txtPhone.Text.Trim();
                partner.Email = txtEmail.Text.Trim();
                partner.Address = txtAddress.Text.Trim();
                partner.INN = txtINN.Text.Trim();
                partner.Rating = (int)numericRating.Value;

                if (!partnerId.HasValue)
                    db.Partners.Add(partner);

                db.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(cmbCompanyType.Text))
            {
                MessageBox.Show("Выберите тип компании", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Введите название компании", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDirectorName.Text))
            {
                MessageBox.Show("Введите ФИО директора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Введите email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Введите адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtINN.Text) || txtINN.Text.Length != 10)
            {
                MessageBox.Show("ИНН должен содержать 10 цифр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db?.Dispose();
        }
    }
}