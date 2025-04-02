using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using Demonstration_exam_2024.Utils;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Forms
{
    public partial class EditPartnerForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int? partnerId;
        private Partner partner;

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
                // Настройка заголовка формы на английском
                this.Text = partnerId.HasValue ? "Edit Partner" : "Add Partner";

                // Настройка формы
                this.MinimumSize = new Size(400, 520);
                this.StartPosition = FormStartPosition.CenterParent;
                this.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Настройка элементов управления
                ConfigureControls();

                // Загрузка данных партнера, если это редактирование
                if (partnerId.HasValue)
                {
                    LoadPartnerData();
                }
            }
            catch (Exception ex)
            {
                ShowError("Error", ex);
            }
        }

        private void ConfigureControls()
        {
            // Настройка типов компаний на английском
            cmbPartnerType.Items.Clear();
            cmbPartnerType.Items.AddRange(new string[] { "LLC", "IE", "JSC", "PJSC" });

            // Настройка поля телефона
            txtPhone.Text = "+7(XXX)XXX-XX-XX";
            txtPhone.ForeColor = Color.Gray;

            // Настройка поля ИНН
            txtINN.MaxLength = 12;

            // Настройка кнопок
            ConfigureButton(btnSave, "Save");
            ConfigureButton(btnCancel, "Cancel");

            // Обработчики событий для поля телефона
            txtPhone.Enter += (s, e) =>
            {
                if (txtPhone.Text == "+7(XXX)XXX-XX-XX")
                {
                    txtPhone.Text = "";
                    txtPhone.ForeColor = Color.Black;
                }
            };

            txtPhone.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    txtPhone.Text = "+7(XXX)XXX-XX-XX";
                    txtPhone.ForeColor = Color.Gray;
                }
            };

            // Валидация ввода
            txtPhone.KeyPress += ValidatePhoneInput;
            txtINN.KeyPress += ValidateNumericInput;

            // Настройка рейтинга
            numRating.Minimum = 0;
            numRating.Maximum = 5;
        }

        private void ConfigureButton(Button button, string text)
        {
            button.Text = text;
            button.BackColor = ColorTranslator.FromHtml("#67BA80");
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        private void ValidatePhoneInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void ValidateNumericInput(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadPartnerData()
        {
            try
            {
                string query = "SELECT * FROM Partners WHERE PartnerId = @PartnerId";
                var parameters = new[] { new SqlParameter("@PartnerId", partnerId) };

                DataTable result = db.ExecuteQuery(query, parameters);
                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    partner = new Partner
                    {
                        PartnerId = (int)row["PartnerId"],
                        CompanyName = row["CompanyName"].ToString(),
                        CompanyType = row["CompanyType"].ToString(),
                        DirectorName = row["DirectorName"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Email = row["Email"].ToString(),
                        Address = row["Address"].ToString(),
                        INN = row["INN"].ToString(),
                        Rating = Convert.ToInt32(row["Rating"])
                    };

                    FillFormFields();
                }
            }
            catch (Exception ex)
            {
                ShowError("Data Loading Error", ex);
            }
        }

        private void FillFormFields()
        {
            txtCompanyName.Text = partner.CompanyName;
            cmbPartnerType.SelectedItem = partner.CompanyType;
            txtDirectorName.Text = partner.DirectorName;
            txtPhone.Text = partner.Phone;
            txtPhone.ForeColor = Color.Black;
            txtEmail.Text = partner.Email;
            txtAddress.Text = partner.Address;
            txtINN.Text = partner.INN;
            numRating.Value = partner.Rating;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    SavePartner();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowError("Save Error", ex);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                ShowError("Validation Error", "Please enter company name");
                return false;
            }

            if (cmbPartnerType.SelectedItem == null)
            {
                ShowError("Validation Error", "Please select company type");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDirectorName.Text))
            {
                ShowError("Validation Error", "Please enter director name");
                return false;
            }

            if (txtPhone.Text == "+7(XXX)XXX-XX-XX" || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                ShowError("Validation Error", "Please enter phone number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                ShowError("Validation Error", "Please enter valid email");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ShowError("Validation Error", "Please enter address");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtINN.Text) || txtINN.Text.Length < 10)
            {
                ShowError("Validation Error", "Please enter valid INN (minimum 10 digits)");
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

        private void SavePartner()
        {
            string query;
            SqlParameter[] parameters;

            if (!partnerId.HasValue)
            {
                query = @"INSERT INTO Partners (CompanyName, CompanyType, DirectorName, Phone, Email, Address, INN, Rating) 
                         VALUES (@CompanyName, @CompanyType, @DirectorName, @Phone, @Email, @Address, @INN, @Rating)";
            }
            else
            {
                query = @"UPDATE Partners 
                         SET CompanyName = @CompanyName, 
                             CompanyType = @CompanyType, 
                             DirectorName = @DirectorName, 
                             Phone = @Phone, 
                             Email = @Email, 
                             Address = @Address, 
                             INN = @INN, 
                             Rating = @Rating 
                         WHERE PartnerId = @PartnerId";
            }

            var paramList = new List<SqlParameter>
            {
                new SqlParameter("@CompanyName", txtCompanyName.Text.Trim()),
                new SqlParameter("@CompanyType", cmbPartnerType.SelectedItem.ToString()),
                new SqlParameter("@DirectorName", txtDirectorName.Text.Trim()),
                new SqlParameter("@Phone", txtPhone.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@Address", txtAddress.Text.Trim()),
                new SqlParameter("@INN", txtINN.Text.Trim()),
                new SqlParameter("@Rating", (int)numRating.Value)
            };

            if (partnerId.HasValue)
            {
                paramList.Add(new SqlParameter("@PartnerId", partnerId.Value));
            }

            parameters = paramList.ToArray();
            db.ExecuteNonQuery(query, parameters);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}