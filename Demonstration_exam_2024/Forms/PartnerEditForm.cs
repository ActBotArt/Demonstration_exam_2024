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

                // Настройка цветов
                this.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                panelTop.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Загрузка иконки
                try
                {
                    string iconPath = Path.Combine(Application.StartupPath, "Resources", "Мастер_пол.ico");
                    if (File.Exists(iconPath))
                    {
                        this.Icon = new Icon(iconPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось загрузить иконку: {ex.Message}",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Настройка комбобокса
                cmbCompanyType.Items.Clear();
                cmbCompanyType.Items.AddRange(new[] { "ООО", "ПАО", "АО", "ЗАО", "ОАО" });
                cmbCompanyType.DropDownStyle = ComboBoxStyle.DropDownList;

                // Настройка кнопок
                StyleButtons();

                // Настройка валидации
                SetupValidation();

                // Настройка подсказок для полей
                SetupHints();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleButtons()
        {
            btnSave.BackColor = ColorTranslator.FromHtml("#67BA80");
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(255, 74, 74);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
        }

        private void SetupValidation()
        {
            txtPhone.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    e.KeyChar != '+' && e.KeyChar != '(' && e.KeyChar != ')' &&
                    e.KeyChar != ' ' && e.KeyChar != '-')
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

            txtINN.MaxLength = 10;
            numericRating.Minimum = 0;
            numericRating.Maximum = 10;
        }

        private void SetupHints()
        {
            SetTextBoxHint(txtCompanyName, "Введите название организации");
            SetTextBoxHint(txtDirectorName, "Введите ФИО директора");
            SetTextBoxHint(txtPhone, "+7 (XXX) XXX-XX-XX");
            SetTextBoxHint(txtEmail, "example@domain.com");
            SetTextBoxHint(txtAddress, "Введите юридический адрес");
            SetTextBoxHint(txtINN, "Введите 10 цифр ИНН");
        }

        private void SetTextBoxHint(TextBox textBox, string hint)
        {
            if (textBox.Text.Length == 0)
            {
                textBox.Text = hint;
                textBox.ForeColor = Color.Gray;
            }

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == hint)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = hint;
                    textBox.ForeColor = Color.Gray;
                }
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
                    txtCompanyName.ForeColor = Color.Black;
                    txtDirectorName.Text = partner.DirectorName;
                    txtDirectorName.ForeColor = Color.Black;
                    txtPhone.Text = partner.Phone;
                    txtPhone.ForeColor = Color.Black;
                    txtEmail.Text = partner.Email;
                    txtEmail.ForeColor = Color.Black;
                    txtAddress.Text = partner.Address;
                    txtAddress.ForeColor = Color.Black;
                    txtINN.Text = partner.INN;
                    txtINN.ForeColor = Color.Black;
                    numericRating.Value = partner.Rating.GetValueOrDefault();
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(cmbCompanyType.Text))
            {
                ShowError("Выберите тип компании");
                cmbCompanyType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) ||
                txtCompanyName.Text == "Введите название организации")
            {
                ShowError("Введите название компании");
                txtCompanyName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDirectorName.Text) ||
                txtDirectorName.Text == "Введите ФИО директора")
            {
                ShowError("Введите ФИО директора");
                txtDirectorName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text) ||
                txtPhone.Text == "+7 (XXX) XXX-XX-XX")
            {
                ShowError("Введите телефон");
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                txtEmail.Text == "example@domain.com" ||
                !IsValidEmail(txtEmail.Text))
            {
                ShowError("Введите корректный email");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text) ||
                txtAddress.Text == "Введите юридический адрес")
            {
                ShowError("Введите юридический адрес");
                txtAddress.Focus();
                return false;
            }

            if (txtINN.Text.Length != 10 || !txtINN.Text.All(char.IsDigit))
            {
                ShowError("ИНН должен содержать 10 цифр");
                txtINN.Focus();
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                partner.Rating = numericRating.Value;

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