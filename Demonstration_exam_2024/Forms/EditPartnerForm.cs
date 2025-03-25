using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Demonstration_exam_2024.Models;
using Demonstration_exam_2024.Utils;

namespace Demonstration_exam_2024.Forms
{
    public partial class EditPartnerForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int? partnerId;
        private Partner currentPartner;

        public EditPartnerForm(int? partnerId)
        {
            InitializeComponent();
            db = new DatabaseContext();
            this.partnerId = partnerId;
            SetupForm();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка формы
                this.Text = partnerId.HasValue ? "Редактирование партнёра" : "Добавление партнёра";
                this.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Настройка комбобокса типов партнёров
                cmbPartnerType.Items.Clear();
                cmbPartnerType.Items.AddRange(new string[] { "ООО", "ИП", "АО", "ПАО" });
                cmbPartnerType.DropDownStyle = ComboBoxStyle.DropDownList;

                // Настройка кнопок
                btnSave.BackColor = ColorTranslator.FromHtml("#67BA80");
                btnSave.ForeColor = Color.White;
                btnSave.FlatStyle = FlatStyle.Flat;

                btnCancel.BackColor = Color.White;
                btnCancel.FlatStyle = FlatStyle.Flat;

                // Если это редактирование - загружаем данные партнёра
                if (partnerId.HasValue)
                {
                    LoadPartnerData();
                }

                // Настройка валидации
                SetupValidation();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPartnerData()
        {
            try
            {
                // Используем GetValueOrDefault для избежания проблем с null
                currentPartner = db.Partners.FirstOrDefault(p => p.PartnerId == partnerId.GetValueOrDefault());
                if (currentPartner != null)
                {
                    txtCompanyName.Text = currentPartner.CompanyName;
                    cmbPartnerType.SelectedItem = currentPartner.CompanyType;
                    numRating.Value = currentPartner.Rating;
                    txtAddress.Text = currentPartner.Address;
                    txtDirectorName.Text = currentPartner.DirectorName;
                    txtPhone.Text = currentPartner.Phone;
                    txtEmail.Text = currentPartner.Email;
                    txtINN.Text = currentPartner.INN;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных партнёра: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupValidation()
        {
            // Валидация ввода в TextBox'ах для телефона и ИНН
            txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
                {
                    e.Handled = true;
                }
            };

            txtINN.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            // Ограничение длины ИНН
            txtINN.MaxLength = 12;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Введите наименование компании!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbPartnerType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип партнёра!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDirectorName.Text))
            {
                MessageBox.Show("Введите ФИО директора!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Введите корректный email!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("Введите корректный номер телефона!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidINN(txtINN.Text))
            {
                MessageBox.Show("Введите корректный ИНН!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return !string.IsNullOrWhiteSpace(phone) && phone.Length >= 10;
        }

        private bool IsValidINN(string inn)
        {
            return !string.IsNullOrWhiteSpace(inn) &&
                   (inn.Length == 10 || inn.Length == 12) &&
                   inn.All(char.IsDigit);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm()) return;

                if (currentPartner == null)
                    currentPartner = new Partner();

                currentPartner.CompanyName = txtCompanyName.Text;
                currentPartner.CompanyType = cmbPartnerType.SelectedItem.ToString();
                currentPartner.Rating = (int)numRating.Value;
                currentPartner.Address = txtAddress.Text;
                currentPartner.DirectorName = txtDirectorName.Text;
                currentPartner.Phone = txtPhone.Text;
                currentPartner.Email = txtEmail.Text;
                currentPartner.INN = txtINN.Text;

                if (!partnerId.HasValue)
                    db.Partners.Add(currentPartner);

                db.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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