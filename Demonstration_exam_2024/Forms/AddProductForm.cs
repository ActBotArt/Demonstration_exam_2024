using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Demonstration_exam_2024.Models;
using Demonstration_exam_2024.Utils;

namespace Demonstration_exam_2024.Forms
{
    public partial class AddProductForm : Form
    {
        private readonly DatabaseContext db;
        private readonly int? productId;
        private Product product;

        public AddProductForm(int? productId = null)
        {
            InitializeComponent();
            db = new DatabaseContext();
            this.productId = productId;
            SetupForm();
            if (productId.HasValue)
            {
                LoadData();
            }
        }

        private void SetupForm()
        {
            try
            {
                // Настройка заголовка формы
                this.Text = productId.HasValue ? "Редактирование продукции" : "Добавление продукции";
                lblFormDescription.Text = productId.HasValue ?
                    "Редактирование информации о продукции" :
                    "Добавление информации о продукции";

                // Загрузка иконки
                string iconPath = Path.Combine("..", "..", "Res", "Мастер_пол.ico");
                string fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconPath));
                if (File.Exists(fullPath))
                {
                    this.Icon = new Icon(fullPath);
                }

                // Настройка валидации
                SetupValidation();

                // Настройка подсказок для полей
                SetupHints();

                // Настройка кнопок
                StyleButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SetupValidation()
        {
            txtArticleNumber.MaxLength = 50;
            numericMinCost.Minimum = 0;
            numericMinCost.Maximum = 1000000;
            numericMinCost.DecimalPlaces = 2;
        }

        private void SetupHints()
        {
            SetTextBoxHint(txtProductName, "Введите название продукции");
            SetTextBoxHint(txtArticleNumber, "Введите артикул");
            SetTextBoxHint(txtTypeName, "Введите тип продукции");
        }

        private void SetTextBoxHint(TextBox textBox, string hint)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = hint;
                textBox.ForeColor = Color.Gray;
            }

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == hint)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = hint;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void LoadData()
        {
            try
            {
                if (productId.HasValue)
                {
                    product = db.Products.Find(productId.Value);
                    if (product != null)
                    {
                        txtProductName.Text = product.ProductName;
                        txtProductName.ForeColor = Color.Black;

                        txtTypeName.Text = product.ProductType?.ProductTypeName;
                        txtTypeName.ForeColor = Color.Black;

                        if (!string.IsNullOrEmpty(product.ArticleNumber))
                        {
                            txtArticleNumber.Text = product.ArticleNumber;
                            txtArticleNumber.ForeColor = Color.Black;
                        }

                        numericMinCost.Value = product.MinimumCost;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                txtProductName.Text == "Введите название продукции")
            {
                ShowError("Введите название продукции");
                txtProductName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTypeName.Text) ||
                txtTypeName.Text == "Введите тип продукции")
            {
                ShowError("Введите тип продукции");
                txtTypeName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtArticleNumber.Text) ||
                txtArticleNumber.Text == "Введите артикул")
            {
                ShowError("Введите артикул");
                txtArticleNumber.Focus();
                return false;
            }

            if (numericMinCost.Value <= 0)
            {
                ShowError("Минимальная стоимость должна быть больше 0");
                numericMinCost.Focus();
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                if (product == null)
                    product = new Product();

                // Проверяем существование типа
                var typeName = txtTypeName.Text.Trim();
                var productType = db.ProductTypes.FirstOrDefault(t => t.ProductTypeName == typeName);

                // Если тип не существует, создаем новый
                if (productType == null)
                {
                    productType = new ProductType { ProductTypeName = typeName };
                    db.ProductTypes.Add(productType);
                    db.SaveChanges(); // Сохраняем, чтобы получить ID типа
                }

                product.ProductTypeId = productType.ProductTypeId;
                product.ProductName = txtProductName.Text.Trim();
                product.ArticleNumber = txtArticleNumber.Text.Trim();
                product.MinimumCost = numericMinCost.Value;

                if (!productId.HasValue)
                    db.Products.Add(product);

                db.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
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