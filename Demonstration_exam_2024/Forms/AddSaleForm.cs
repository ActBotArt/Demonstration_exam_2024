using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Demonstration_exam_2024.Models;
using Demonstration_exam_2024.Utils;

namespace Demonstration_exam_2024.Forms
{
    public partial class AddSaleForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int partnerId;
        private readonly int? saleId;
        private bool isLoading = false;
        private bool isAutoCalculating = true;

        public AddSaleForm(int partnerId, int? saleId = null)
        {
            InitializeComponent();
            db = new DatabaseContext();
            this.partnerId = partnerId;
            this.saleId = saleId;
            SetupForm();

            if (saleId.HasValue)
            {
                LoadSaleData();
                isAutoCalculating = false; // При редактировании отключаем автопересчет
            }
            else
            {
                LoadProductsAndSetInitialPrice();
            }
        }

        private void SetupForm()
        {
            try
            {
                this.Text = saleId.HasValue ? "Редактирование продажи" : "Добавление продажи";
                lblTitle.Text = this.Text;

                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductId";

                numericQuantity.Minimum = 1;
                numericQuantity.Maximum = 1000000;
                numericQuantity.Value = 1;

                numericPrice.DecimalPlaces = 2;
                numericPrice.Minimum = 0;
                numericPrice.Maximum = decimal.MaxValue;
                numericPrice.ThousandsSeparator = true;
                numericPrice.ReadOnly = false;

                StyleButtons();

                string iconPath = System.IO.Path.Combine("..", "..", "Resources", "Мастер_пол.ico");
                string fullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconPath));
                if (System.IO.File.Exists(fullPath))
                {
                    this.Icon = new Icon(fullPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductsAndSetInitialPrice()
        {
            try
            {
                isLoading = true;
                var products = db.Products.OrderBy(p => p.ProductName).ToList();
                cmbProduct.DataSource = products;

                if (products.Any() && cmbProduct.SelectedItem is Product firstProduct)
                {
                    CalculatePrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка продукции: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void LoadSaleData()
        {
            try
            {
                var sale = db.Sales.Find(saleId.Value);
                if (sale != null)
                {
                    isLoading = true;
                    var products = db.Products.OrderBy(p => p.ProductName).ToList();
                    cmbProduct.DataSource = products;
                    cmbProduct.SelectedValue = sale.ProductId;
                    numericQuantity.Value = sale.Quantity;
                    numericPrice.Value = sale.SalePrice;
                    isLoading = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculatePrice()
        {
            if (!isLoading && isAutoCalculating && cmbProduct.SelectedItem is Product selectedProduct)
            {
                decimal basePrice = selectedProduct.MinimumCost;
                decimal quantity = numericQuantity.Value;
                numericPrice.Value = basePrice * quantity;
            }
        }

        private void StyleButtons()
        {
            btnSave.BackColor = ColorTranslator.FromHtml("#67BA80");
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            btnCancel.BackColor = Color.FromArgb(255, 74, 74);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void numericPrice_Enter(object sender, EventArgs e)
        {
            // Когда пользователь начинает редактировать цену, отключаем автопересчет
            isAutoCalculating = false;
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                isAutoCalculating = true; // Включаем автопересчет при смене продукта
                CalculatePrice();
            }
        }

        private void numericQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                CalculatePrice();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduct.SelectedValue == null)
                {
                    MessageBox.Show("Выберите продукт", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numericPrice.Value <= 0)
                {
                    MessageBox.Show("Цена должна быть больше 0", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sale = saleId.HasValue
                    ? db.Sales.Find(saleId.Value)
                    : new Sale { PartnerId = partnerId, SaleDate = DateTime.Now };

                if (sale != null)
                {
                    sale.ProductId = (int)cmbProduct.SelectedValue;
                    sale.Quantity = (int)numericQuantity.Value;
                    sale.SalePrice = numericPrice.Value;

                    if (!saleId.HasValue)
                        db.Sales.Add(sale);

                    db.SaveChanges();
                    DialogResult = DialogResult.OK;
                    Close();
                }
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