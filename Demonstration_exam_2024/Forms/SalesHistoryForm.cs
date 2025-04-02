using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Demonstration_exam_2024.Utils;

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
        }

        private void SetupForm()
        {
            try
            {
                Text = "Sales History";
                BackColor = ColorTranslator.FromHtml("#F4E8D3");
                MinimumSize = new Size(816, 489);

                SetupDataGridView();
                ConfigureButtons();
                LoadPartnerInfo();
                LoadSalesHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dgvSales.AutoGenerateColumns = false;
            dgvSales.Columns.Clear();

            dgvSales.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "SaleDate",
                    HeaderText = "Sale Date",
                    DataPropertyName = "SaleDate",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Product",
                    DataPropertyName = "ProductName",
                    Width = 250
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Quantity",
                    DataPropertyName = "Quantity",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "SalePrice",
                    HeaderText = "Price",
                    DataPropertyName = "SalePrice",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalAmount",
                    HeaderText = "Total",
                    DataPropertyName = "TotalAmount",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
                }
            });
        }

        private void ConfigureButtons()
        {
            btnClose.BackColor = ColorTranslator.FromHtml("#67BA80");
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
        }

        private void LoadPartnerInfo()
        {
            string query = @"SELECT CompanyName, CompanyType, Rating 
                           FROM Partners 
                           WHERE PartnerId = @PartnerId";

            var parameters = new[] { new SqlParameter("@PartnerId", partnerId) };
            DataTable result = db.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                lblPartnerInfo.Text = $"Partner: {row["CompanyType"]} \"{row["CompanyName"]}\", Rating: {row["Rating"]}";
            }
        }

        private void LoadSalesHistory()
        {
            string query = @"SELECT s.SaleDate, p.ProductName, s.Quantity, s.SalePrice, 
                           (s.Quantity * s.SalePrice) as TotalAmount
                           FROM Sales s
                           JOIN Products p ON p.ProductId = s.ProductId
                           WHERE s.PartnerId = @PartnerId
                           ORDER BY s.SaleDate DESC";

            var parameters = new[] { new SqlParameter("@PartnerId", partnerId) };
            DataTable salesData = db.ExecuteQuery(query, parameters);
            dgvSales.DataSource = salesData;
        }

        private void btnClose_Click(object sender, EventArgs e)
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