using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Demonstration_exam_2024.Utils;

namespace Demonstration_exam_2024.Forms
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseContext db;

        public LoginForm()
        {
            InitializeComponent();
            db = new DatabaseContext();
            SetupForm();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка формы
                this.Text = "Login";
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Настройка кнопок
                ConfigureButton(btnLogin, "Login");
                ConfigureButton(btnCancel, "Cancel");

                // Настройка полей ввода
                txtLogin.MaxLength = 50;
                txtPassword.MaxLength = 50;
                txtPassword.PasswordChar = '*';

                // Добавление обработчиков событий
                this.btnLogin.Click += btnLogin_Click;
                this.btnCancel.Click += btnCancel_Click;
                this.txtPassword.KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Enter) btnLogin_Click(s, e); };
            }
            catch (Exception ex)
            {
                ShowError("Initialization Error", ex);
            }
        }

        private void ConfigureButton(Button button, string text)
        {
            button.Text = text;
            button.BackColor = ColorTranslator.FromHtml("#67BA80");
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    string query = "SELECT UserId, Role FROM Users WHERE Login = @Login AND Password = @Password";
                    var parameters = new[]
                    {
                        new SqlParameter("@Login", txtLogin.Text.Trim()),
                        new SqlParameter("@Password", txtPassword.Text)
                    };

                    DataTable result = db.ExecuteQuery(query, parameters);

                    if (result.Rows.Count > 0)
                    {
                        int userId = Convert.ToInt32(result.Rows[0]["UserId"]);
                        string role = result.Rows[0]["Role"].ToString();

                        Hide();
                        using (var mainForm = new MainForm(userId))
                        {
                            mainForm.ShowDialog();
                        }
                        Close();
                    }
                    else
                    {
                        ShowError("Login Error", "Invalid login or password");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Login Error", ex);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                ShowError("Validation Error", "Please enter login");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowError("Validation Error", "Please enter password");
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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
            db?.Dispose();
        }
    }
}