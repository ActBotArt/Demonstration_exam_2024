using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
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
                this.Text = "Мастер-Пол | Партнеры";

                // Загрузка логотипа
                LoadLogo();

                // Настройка DataGridView
                ConfigureDataGridView();

                // Загрузка данных
                LoadData();

                // Обновление информации о пользователе
                UpdateUserInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLogo()
        {
            // Загрузка иконки
            string iconRelativePath = System.IO.Path.Combine("..", "..", "Resources", "Мастер_пол.ico");
            string iconFullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconRelativePath));

            if (System.IO.File.Exists(iconFullPath))
            {
                this.Icon = new Icon(iconFullPath);
            }
            else
            {
                MessageBox.Show($"Иконка не найдена по пути: {iconFullPath}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Настройка стилей строк
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#67BA80");
            dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.White;
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
            lblDateTime.Text = $"Дата и время: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
        }

        private void UpdateUserInfo()
        {
            try
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    lblUserLogin.Text = $"Пользователь: {user.Login}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных пользователя: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var partners = db.Partners
                    .OrderBy(p => p.CompanyName)
                    .Select(p => new
                    {
                        p.PartnerId,
                        Тип = p.CompanyType,
                        Наименование = p.CompanyName,
                        Директор = p.DirectorName,
                        Телефон = p.Phone,
                        Email = p.Email,
                        Адрес = p.Address,
                        ИНН = p.INN,
                        Рейтинг = p.Rating
                    })
                    .ToList();

                dataGridView1.DataSource = partners;

                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["PartnerId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();
                var partners = db.Partners
                    .Where(p =>
                        p.CompanyName.ToLower().Contains(searchText) ||
                        p.DirectorName.ToLower().Contains(searchText) ||
                        p.INN.Contains(searchText) ||
                        p.Phone.Contains(searchText) ||
                        p.Email.ToLower().Contains(searchText))
                    .OrderBy(p => p.CompanyName)
                    .Select(p => new
                    {
                        p.PartnerId,
                        Тип = p.CompanyType,
                        Наименование = p.CompanyName,
                        Директор = p.DirectorName,
                        Телефон = p.Phone,
                        Email = p.Email,
                        Адрес = p.Address,
                        ИНН = p.INN,
                        Рейтинг = p.Rating
                    })
                    .ToList();

                dataGridView1.DataSource = partners;
                dataGridView1.Columns["PartnerId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new PartnerEditForm(null))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении партнера: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedPartner();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            try
            {
                int partnerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PartnerId"].Value);
                string companyName = dataGridView1.CurrentRow.Cells["Наименование"].Value.ToString();

                if (MessageBox.Show($"Вы действительно хотите удалить партнера \"{companyName}\"?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var partner = db.Partners.Find(partnerId);
                    if (partner != null)
                    {
                        db.Partners.Remove(partner);
                        db.SaveChanges();
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении партнера: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите партнера для просмотра истории продаж",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int partnerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PartnerId"].Value);
                using (var form = new SalesHistoryForm(partnerId))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии истории продаж: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelectedPartner();
            }
        }

        private void EditSelectedPartner()
        {
            if (dataGridView1.CurrentRow == null) return;

            try
            {
                int partnerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PartnerId"].Value);
                using (var form = new PartnerEditForm(partnerId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании партнера: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            timer?.Stop();
            timer?.Dispose();
            db?.Dispose();
        }
    }
}