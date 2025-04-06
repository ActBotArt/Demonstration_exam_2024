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
                        s.Quantity
                    })
                    .OrderByDescending(s => s.SaleDate)
                    .ToList();

                dataGridViewSales.DataSource = sales;

                if (dataGridViewSales.Columns.Count > 0)
                {
                    dataGridViewSales.Columns["SaleDate"].HeaderText = "Дата продажи";
                    dataGridViewSales.Columns["ProductName"].HeaderText = "Наименование продукции";
                    dataGridViewSales.Columns["Quantity"].HeaderText = "Количество";
                    dataGridViewSales.Columns["SaleDate"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории продаж: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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