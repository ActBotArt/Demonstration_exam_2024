using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using Demonstration_exam_2024.Utils;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int userId;
        private readonly string userRole;
        private Timer timer;

        public MainForm(int userId, string userRole)
        {
            InitializeComponent();
            db = new DatabaseContext();
            this.userId = userId;
            this.userRole = userRole;
            SetupForm();
            SetupTimer();
        }

        private void SetupForm()
        {
            try
            {
                // Настройка формы
                this.Text = "Мастер-Пол";
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                // Настройка фона и цветов
                this.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Настройка DataGridView
                ConfigureDataGridView();

                // Настройка кнопок
                ConfigureButtons();

                // Загрузка логотипа
                LoadLogo();

                // Загрузка данных
                LoadData();

                // Обновление информации о пользователе
                UpdateUserInfo();
            }
            catch (Exception ex)
            {
                ShowError("Ошибка при настройке формы", ex);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#67BA80");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;

            // Настройка стилей строк
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F5F5F5");
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#67BA80");
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void ConfigureButtons()
        {
            // Настройка кнопок
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = ColorTranslator.FromHtml("#67BA80");
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.Font = new Font("Segoe UI", 9F);
                    button.Cursor = Cursors.Hand;

                    // Эффекты при наведении
                    button.MouseEnter += (s, e) => button.BackColor = ColorTranslator.FromHtml("#5AA572");
                    button.MouseLeave += (s, e) => button.BackColor = ColorTranslator.FromHtml("#67BA80");
                }
            }

            // Настройка поля поиска
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            lblSearch.Font = new Font("Segoe UI", 9F);
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "Resources", "Мастер_пол.png");
                if (System.IO.File.Exists(logoPath))
                {
                    pictureBoxLogo.Image = Image.FromFile(logoPath);
                    pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка при загрузке логотипа: {ex.Message}");
            }
        }

        private void SetupTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => UpdateDateTime();
            timer.Start();
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = $"Current Date and Time (UTC - YYYY-MM-DD HH:MM:SS formatted): {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}";
        }

        private void UpdateUserInfo()
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    lblUserLogin.Text = $"Current User's Login: {user.Login}";
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка при загрузке данных пользователя", ex);
            }
        }

        private void LoadData()
        {
            try
            {
                var partners = db.Partners.Select(p => new
                {
                    p.CompanyName,
                    p.CompanyType,
                    p.DirectorName,
                    p.Phone,
                    p.Email,
                    p.Address,
                    p.INN,
                    p.Rating
                }).ToList();

                dataGridView1.DataSource = partners;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["CompanyName"].HeaderText = "Наименование";
                    dataGridView1.Columns["CompanyType"].HeaderText = "Тип";
                    dataGridView1.Columns["DirectorName"].HeaderText = "ФИО Директора";
                    dataGridView1.Columns["Phone"].HeaderText = "Телефон";
                    dataGridView1.Columns["Email"].HeaderText = "Email";
                    dataGridView1.Columns["Address"].HeaderText = "Адрес";
                    dataGridView1.Columns["INN"].HeaderText = "ИНН";
                    dataGridView1.Columns["Rating"].HeaderText = "Рейтинг";
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка при загрузке данных", ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();
                var partners = db.Partners.Where(p =>
                    p.CompanyName.ToLower().Contains(searchText) ||
                    p.DirectorName.ToLower().Contains(searchText) ||
                    p.INN.Contains(searchText) ||
                    p.Phone.Contains(searchText) ||
                    p.Email.ToLower().Contains(searchText)
                ).Select(p => new
                {
                    p.CompanyName,
                    p.CompanyType,
                    p.DirectorName,
                    p.Phone,
                    p.Email,
                    p.Address,
                    p.INN,
                    p.Rating
                }).ToList();

                dataGridView1.DataSource = partners;
            }
            catch (Exception ex)
            {
                ShowError("Ошибка при поиске", ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var addForm = new EditPartnerForm(null))
                {
                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка при открытии формы добавления", ex);
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    string inn = dataGridView1.CurrentRow.Cells["INN"].Value.ToString();
                    var partner = db.Partners.FirstOrDefault(p => p.INN == inn);
                    if (partner != null)
                    {
                        using (var historyForm = new SalesHistoryForm(partner.PartnerId))
                        {
                            historyForm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите партнера для просмотра истории продаж",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка при открытии истории продаж", ex);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string inn = dataGridView1.Rows[e.RowIndex].Cells["INN"].Value.ToString();
                    var partner = db.Partners.FirstOrDefault(p => p.INN == inn);
                    if (partner != null)
                    {
                        using (var editForm = new EditPartnerForm(partner.PartnerId))
                        {
                            if (editForm.ShowDialog() == DialogResult.OK)
                            {
                                LoadData();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Ошибка при открытии формы редактирования", ex);
            }
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Debug.WriteLine($"{message}: {ex}");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timer?.Stop();
            timer?.Dispose();
            db?.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}