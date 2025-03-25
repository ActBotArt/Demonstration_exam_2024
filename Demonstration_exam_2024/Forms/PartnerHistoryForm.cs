using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Demonstration_exam_2024.Utils;
using System.IO;

namespace Demonstration_exam_2024.Forms
{
    public partial class PartnerHistoryForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int partnerId;

        public PartnerHistoryForm(int partnerId)
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
                var partner = db.Partners.Find(partnerId);
                if (partner == null) throw new Exception("Партнер не найден");

                // Настройка формы
                this.Text = $"История продаж - {partner.CompanyName}";

                // Загрузка иконки
                string iconPath = Path.Combine(Application.StartupPath, "Resources", "Мастер_пол.ico");
                if (File.Exists(iconPath))
                    this.Icon = new Icon(iconPath);

                // Настройка цветов
                this.BackColor = Color.White;
                panelTop.BackColor = ColorTranslator.FromHtml("#F4E8D3");

                // Настройка заголовка
                lblCompanyInfo.Text = $"{partner.CompanyType} \"{partner.CompanyName}\"";
                lblCompanyInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

                // Настройка DataGridView
                ConfigureDataGridView();

                // Расчет и отображение скидки
                int discount = DiscountCalculator.CalculateDiscount(partnerId);
                lblDiscount.Text = $"Текущая скидка: {discount}%";
                lblDiscount.Font = new Font("Segoe UI", 12F);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ConfigureDataGridView()
        {
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();
            dgvHistory.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Наименование продукции",
                    DataPropertyName = "ProductName",
                    Width = 300
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Количество",
                    DataPropertyName = "Quantity",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "SaleDate",
                    HeaderText = "Дата продажи",
                    DataPropertyName = "SaleDate",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "dd.MM.yyyy"
                    }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "SalePrice",
                    HeaderText = "Цена",
                    DataPropertyName = "SalePrice",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2"
                    }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalAmount",
                    HeaderText = "Сумма",
                    DataPropertyName = "TotalAmount",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2"
                    }
                }
            });

            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.MultiSelect = false;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.ReadOnly = true;

            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void LoadData()
        {
            try
            {
                var sales = db.Sales
                    .Where(s => s.PartnerId == partnerId)
                    .Select(s => new
                    {
                        s.Product.ProductName,
                        s.Quantity,
                        s.SaleDate,
                        s.SalePrice,
                        TotalAmount = s.Quantity * s.SalePrice
                    })
                    .OrderByDescending(s => s.SaleDate)
                    .ToList();

                dgvHistory.DataSource = sales;

                // Подсчет итогов
                decimal totalSum = sales.Sum(s => s.TotalAmount);
                int totalQuantity = sales.Sum(s => s.Quantity);

                lblTotalInfo.Text = $"Всего продаж: {sales.Count}\n" +
                                  $"Общее количество: {totalQuantity:N0}\n" +
                                  $"Общая сумма: {totalSum:C2}";
                lblTotalInfo.Font = new Font("Segoe UI", 10F);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db?.Dispose();
        }
    }
}