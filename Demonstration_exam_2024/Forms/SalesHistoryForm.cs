// SalesHistoryForm.cs
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Demonstration_exam_2024.Utils;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Forms
{
    public partial class SalesHistoryForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int partnerId;

        public SalesHistoryForm(int partnerId)
        {
            InitializeComponent();
            db = new DatabaseContext();
            this.partnerId = partnerId;
            SetupForm();
            LoadSalesHistory();
        }

        private void SetupForm()
        {
            try
            {
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

                // Получение названия партнера
                var partner = db.Partners.Find(partnerId);
                if (partner != null)
                {
                    lblPartnerName.Text = partner.CompanyName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalesHistory()
        {
            try
            {
                var sales = db.Sales
                    .Where(s => s.PartnerId == partnerId)
                    .Select(s => new
                    {
                        s.SaleDate,
                        ProductName = s.Product.ProductName,
                        s.Quantity,
                        Price = s.SalePrice,
                        Total = s.Quantity * s.SalePrice
                    })
                    .OrderByDescending(s => s.SaleDate)
                    .ToList();

                dataGridViewSales.DataSource = sales;

                if (dataGridViewSales.Columns.Count > 0)
                {
                    ConfigureColumns();

                    // Добавляем информацию о скидках
                    var discount = DiscountCalculator.CalculateDiscount(partnerId);
                    var totalAmount = sales.Sum(s => s.Total);
                    var discountedAmount = DiscountCalculator.ApplyDiscount(totalAmount, discount);

                    // Создаем панель с информацией о скидках
                    Panel infoPanel = new Panel
                    {
                        Location = new Point(12, dataGridViewSales.Bottom + 10),
                        Size = new Size(760, 80),
                        BackColor = ColorTranslator.FromHtml("#F4E8D3")
                    };

                    Label lblTotalInfo = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 10),
                        Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                        Text = $"Общая сумма: {totalAmount:C2}\n" +
                               $"Текущая скидка: {discount}%\n" +
                               $"Сумма со скидкой: {discountedAmount:C2}"
                    };

                    infoPanel.Controls.Add(lblTotalInfo);
                    this.Controls.Add(infoPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории продаж: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            dataGridViewSales.Columns["SaleDate"].HeaderText = "Дата продажи";
            dataGridViewSales.Columns["ProductName"].HeaderText = "Наименование продукции";
            dataGridViewSales.Columns["Quantity"].HeaderText = "Количество";
            dataGridViewSales.Columns["Price"].HeaderText = "Цена";
            dataGridViewSales.Columns["Total"].HeaderText = "Сумма";

            dataGridViewSales.Columns["SaleDate"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            dataGridViewSales.Columns["Price"].DefaultCellStyle.Format = "C2";
            dataGridViewSales.Columns["Total"].DefaultCellStyle.Format = "C2";
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db?.Dispose();
        }
    }
}