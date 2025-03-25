using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
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
            LoadSalesHistory();
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
                        ProductName = s.Product.ProductName,  // Используем навигационное свойство
                        s.Quantity,
                        UnitPrice = s.SalePrice,  // Используем SalePrice вместо UnitPrice
                        TotalAmount = s.Quantity * s.SalePrice
                    })
                    .OrderByDescending(s => s.SaleDate)
                    .ToList();

                dataGridViewSales.DataSource = sales;

                if (dataGridViewSales.Columns.Count > 0)
                {
                    dataGridViewSales.Columns["SaleDate"].HeaderText = "Дата продажи";
                    dataGridViewSales.Columns["ProductName"].HeaderText = "Наименование товара";
                    dataGridViewSales.Columns["Quantity"].HeaderText = "Количество";
                    dataGridViewSales.Columns["UnitPrice"].HeaderText = "Цена за единицу";
                    dataGridViewSales.Columns["TotalAmount"].HeaderText = "Общая сумма";

                    dataGridViewSales.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
                    dataGridViewSales.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                    dataGridViewSales.Columns["SaleDate"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории продаж: {ex.Message}",
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