using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Demonstration_exam_2024.Models;
using Demonstration_exam_2024.Utils;

namespace Demonstration_exam_2024.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly DatabaseContext db;

        public ProductListForm()
        {
            InitializeComponent();
            db = new DatabaseContext();
            SetupForm();
            LoadData();
        }

        private void SetupForm()
        {
            try
            {
                this.Text = "Продукция";

                // Загрузка иконки
                string iconPath = Path.Combine("..", "..", "Res", "Мастер_пол.ico");
                string fullPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, iconPath));
                if (File.Exists(fullPath))
                {
                    this.Icon = new Icon(fullPath);
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
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;

            // Настройка колонок
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductId",
                    HeaderText = "ID",
                    DataPropertyName = "ProductId",
                    Width = 50,
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Название продукции",
                    DataPropertyName = "ProductName",
                    Width = 250
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ArticleNumber",
                    HeaderText = "Артикул",
                    DataPropertyName = "ArticleNumber",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductTypeName",
                    HeaderText = "Тип продукции",
                    DataPropertyName = "TypeName",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "MinimumCost",
                    HeaderText = "Мин. стоимость",
                    DataPropertyName = "MinimumCost",
                    Width = 120,
                    DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
                }
            );

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            dataGridView1.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#67BA80");
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private void StyleButtons()
        {
            foreach (Button btn in new[] { btnAdd, btnEdit })
            {
                btn.BackColor = ColorTranslator.FromHtml("#67BA80");
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            foreach (Button btn in new[] { btnDelete, btnBack })
            {
                btn.BackColor = Color.FromArgb(255, 74, 74);
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void LoadData(string searchText = "")
        {
            try
            {
                var query = db.Products.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    searchText = searchText.ToLower();
                    query = query.Where(p =>
                        p.ProductName.ToLower().Contains(searchText) ||
                        p.ArticleNumber.ToLower().Contains(searchText) ||
                        p.ProductType.ProductTypeName.ToLower().Contains(searchText));
                }

                var products = query
                    .OrderBy(p => p.ProductName)
                    .Select(p => new
                    {
                        p.ProductId,
                        p.ProductName,
                        p.ArticleNumber,
                        TypeName = p.ProductType.ProductTypeName,
                        p.MinimumCost
                    })
                    .ToList();

                dataGridView1.DataSource = products;
                lblCount.Text = $"Всего записей: {products.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddProductForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var productId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ProductId"].Value);
            using (var form = new AddProductForm(productId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var productId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ProductId"].Value);
            var productName = dataGridView1.CurrentRow.Cells["ProductName"].Value.ToString();

            if (MessageBox.Show($"Вы действительно хотите удалить продукт \"{productName}\"?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var product = db.Products.Find(productId);
                    if (product != null)
                    {
                        db.Products.Remove(product);
                        db.SaveChanges();
                        LoadData();
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