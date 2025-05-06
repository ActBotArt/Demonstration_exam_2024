using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Demonstration_exam_2024.Utils;
using Demonstration_exam_2024.Models;
using ClosedXML.Excel;

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
                string iconPath = Path.Combine("..", "..", "Res", "Мастер_пол.ico");
                string fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconPath));
                if (File.Exists(fullPath))
                {
                    this.Icon = new Icon(fullPath);
                }

                var partner = db.Partners.Find(partnerId);
                if (partner != null)
                {
                    lblPartnerName.Text = $"Партнер: {partner.CompanyName}";
                }

                ConfigureDataGridView();
                StyleButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dataGridViewSales.AutoGenerateColumns = false;
            dataGridViewSales.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridViewSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewSales.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            dataGridViewSales.EnableHeadersVisualStyles = false;
            dataGridViewSales.RowHeadersVisible = false;
            dataGridViewSales.AllowUserToAddRows = false;
            dataGridViewSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSales.BackgroundColor = Color.White;
            dataGridViewSales.BorderStyle = BorderStyle.None;
            dataGridViewSales.MultiSelect = false;
            dataGridViewSales.ReadOnly = true;

            dataGridViewSales.Columns.Clear();
            dataGridViewSales.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "SaleId",
                    HeaderText = "ID",
                    DataPropertyName = "SaleId",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "SaleDate",
                    HeaderText = "Дата продажи",
                    DataPropertyName = "SaleDate",
                    Width = 150,
                    DefaultCellStyle = { Format = "dd.MM.yyyy" }
                },
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
                    Width = 100,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Цена",
                    DataPropertyName = "Price",
                    Width = 120,
                    DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    HeaderText = "Сумма",
                    DataPropertyName = "Total",
                    Width = 120,
                    DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
                }
            );

            dataGridViewSales.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            dataGridViewSales.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#67BA80");
            dataGridViewSales.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void StyleButtons()
        {
            foreach (Button btn in new[] { btnAddSale, btnEditSale, btnExportExcel })
            {
                btn.BackColor = ColorTranslator.FromHtml("#67BA80");
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            foreach (Button btn in new[] { btnDeleteSale, btnBack })
            {
                btn.BackColor = Color.FromArgb(255, 74, 74);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void LoadSalesHistory(string searchText = "")
        {
            try
            {
                var query = db.Sales.Where(s => s.PartnerId == partnerId);

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    searchText = searchText.ToLower();
                    query = query.Where(s =>
                        s.Product.ProductName.ToLower().Contains(searchText) ||
                        s.SaleDate.ToString().Contains(searchText) ||
                        s.SalePrice.ToString().Contains(searchText) ||
                        s.Quantity.ToString().Contains(searchText));
                }

                var sales = query
                    .Select(s => new
                    {
                        s.SaleId,
                        s.SaleDate,
                        s.Product.ProductName,
                        s.Quantity,
                        Price = s.SalePrice,
                        Total = s.Quantity * s.SalePrice
                    })
                    .OrderByDescending(s => s.SaleDate)
                    .ToList();

                dataGridViewSales.DataSource = sales;
                UpdateTotalInfo(sales.Sum(s => s.Total));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории продаж: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalInfo(decimal totalAmount)
        {
            var discount = DiscountCalculator.CalculateDiscount(partnerId);
            var discountedAmount = DiscountCalculator.ApplyDiscount(totalAmount, discount);
            lblTotal.Text = $"Общая сумма: {totalAmount:C2} (Скидка: {discount}%)";
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel файлы (*.xlsx)|*.xlsx";
                    sfd.FileName = $"История_продаж_{DateTime.Now:yyyy-MM-dd}.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("История продаж");

                            // Заголовки
                            worksheet.Cell(1, 1).Value = "Дата продажи";
                            worksheet.Cell(1, 2).Value = "Наименование продукции";
                            worksheet.Cell(1, 3).Value = "Количество";
                            worksheet.Cell(1, 4).Value = "Цена";
                            worksheet.Cell(1, 5).Value = "Сумма";

                            // Стилизация заголовков
                            var headerRange = worksheet.Range(1, 1, 1, 5);
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Fill.BackgroundColor = XLColor.FromHtml("#F4E8D3");
                            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Данные
                            for (int i = 0; i < dataGridViewSales.Rows.Count; i++)
                            {
                                worksheet.Cell(i + 2, 1).Value = Convert.ToDateTime(
                                    dataGridViewSales.Rows[i].Cells["SaleDate"].Value).ToString("dd.MM.yyyy");
                                worksheet.Cell(i + 2, 2).Value =
                                    dataGridViewSales.Rows[i].Cells["ProductName"].Value.ToString();
                                worksheet.Cell(i + 2, 3).Value =
                                    Convert.ToInt32(dataGridViewSales.Rows[i].Cells["Quantity"].Value);
                                worksheet.Cell(i + 2, 4).Value =
                                    Convert.ToDecimal(dataGridViewSales.Rows[i].Cells["Price"].Value);
                                worksheet.Cell(i + 2, 5).Value =
                                    Convert.ToDecimal(dataGridViewSales.Rows[i].Cells["Total"].Value);
                            }

                            // Форматирование данных
                            var dataRange = worksheet.Range(2, 1, dataGridViewSales.Rows.Count + 1, 5);
                            dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                            // Форматирование числовых столбцов
                            worksheet.Column(3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            worksheet.Column(4).Style.NumberFormat.Format = "₽ #,##0.00";
                            worksheet.Column(4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            worksheet.Column(5).Style.NumberFormat.Format = "₽ #,##0.00";
                            worksheet.Column(5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            // Автоподбор ширины столбцов
                            worksheet.Columns().AdjustToContents();

                            // Добавление итоговой строки
                            int lastRow = dataGridViewSales.Rows.Count + 2;
                            worksheet.Cell(lastRow, 1).Value = "ИТОГО:";
                            worksheet.Range(lastRow, 1, lastRow, 4).Merge();
                            worksheet.Range(lastRow, 1, lastRow, 4).Style.Alignment.Horizontal =
                                XLAlignmentHorizontalValues.Right;
                            worksheet.Cell(lastRow, 5).FormulaA1 = $"=SUM(E2:E{lastRow - 1})";
                            worksheet.Cell(lastRow, 5).Style.NumberFormat.Format = "₽ #,##0.00";
                            worksheet.Range(lastRow, 1, lastRow, 5).Style.Font.Bold = true;

                            workbook.SaveAs(sfd.FileName);
                            MessageBox.Show("Данные успешно экспортированы в Excel!",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSalesHistory(txtSearch.Text);
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddSaleForm(partnerId))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSalesHistory(txtSearch.Text);
                }
            }
        }

        private void btnEditSale_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.CurrentRow == null)
            {
                MessageBox.Show("Выберите продажу для редактирования",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var saleId = Convert.ToInt32(dataGridViewSales.CurrentRow.Cells["SaleId"].Value);
            using (var editForm = new AddSaleForm(partnerId, saleId))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSalesHistory(txtSearch.Text);
                }
            }
        }

        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            if (dataGridViewSales.CurrentRow == null)
            {
                MessageBox.Show("Выберите продажу для удаления",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var saleId = Convert.ToInt32(dataGridViewSales.CurrentRow.Cells["SaleId"].Value);
            var productName = dataGridViewSales.CurrentRow.Cells["ProductName"].Value.ToString();
            var saleDate = Convert.ToDateTime(dataGridViewSales.CurrentRow.Cells["SaleDate"].Value)
                .ToString("dd.MM.yyyy");

            if (MessageBox.Show(
                $"Вы действительно хотите удалить продажу товара \"{productName}\" от {saleDate}?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var sale = db.Sales.Find(saleId);
                    if (sale != null)
                    {
                        db.Sales.Remove(sale);
                        db.SaveChanges();
                        LoadSalesHistory(txtSearch.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db?.Dispose();
        }
    }
}