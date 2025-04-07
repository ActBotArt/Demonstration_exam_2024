using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Demonstration_exam_2024.Utils;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Forms
{
    public partial class PartnersListForm : Form
    {
        private readonly DatabaseContext db;

        public PartnersListForm()
        {
            InitializeComponent();
            db = new DatabaseContext();
            SetupForm();
            LoadPartners();
        }

        private void SetupForm()
        {
            try
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

                // Настройка DataGridView
                dataGridViewPartners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewPartners.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#67BA80");
                dataGridViewPartners.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridViewPartners.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось настроить форму: {ex.Message}",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadPartners()
        {
            try
            {
                var partners = db.Partners
                    .Select(p => new
                    {
                        p.PartnerId,
                        p.CompanyType,
                        p.CompanyName,
                        p.DirectorName,
                        p.Phone,
                        p.Email,
                        p.Address,
                        p.INN,
                        p.Rating,
                        ТекущаяСкидка = DiscountCalculator.CalculateDiscount(p.PartnerId) + "%",
                        ОбщийОбъемПродаж = p.Sales.Sum(s => s.Quantity)
                    })
                    .ToList();

                dataGridViewPartners.DataSource = partners;
                ConfigureColumns();

                // Добавляем информацию о системе скидок
                Label lblDiscountInfo = new Label
                {
                    AutoSize = true,
                    Location = new Point(12, dataGridViewPartners.Bottom + 10),
                    Font = new Font("Segoe UI", 9F),
                    Text = DiscountCalculator.GetDiscountDescription()
                };
                Controls.Add(lblDiscountInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка партнеров: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureColumns()
        {
            if (dataGridViewPartners.Columns.Count > 0)
            {
                dataGridViewPartners.Columns["PartnerId"].Visible = false;
                dataGridViewPartners.Columns["CompanyType"].HeaderText = "Тип";
                dataGridViewPartners.Columns["CompanyName"].HeaderText = "Название";
                dataGridViewPartners.Columns["DirectorName"].HeaderText = "Директор";
                dataGridViewPartners.Columns["Phone"].HeaderText = "Телефон";
                dataGridViewPartners.Columns["Email"].HeaderText = "Email";
                dataGridViewPartners.Columns["Address"].HeaderText = "Адрес";
                dataGridViewPartners.Columns["INN"].HeaderText = "ИНН";
                dataGridViewPartners.Columns["Rating"].HeaderText = "Рейтинг";
                dataGridViewPartners.Columns["Discount"].HeaderText = "Скидка %";

                foreach (DataGridViewColumn column in dataGridViewPartners.Columns)
                {
                    column.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
                }
            }
        }

        private void UpdateDiscountInfo()
        {
            Label lblDiscountInfo = new Label
            {
                AutoSize = true,
                Location = new Point(12, dataGridViewPartners.Bottom + 10),
                Font = new Font("Segoe UI", 9F),
                Text = DiscountCalculator.GetDiscountDescription()
            };
            Controls.Add(lblDiscountInfo);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PartnerEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPartners();
                }
            }
        }

        private void btnViewSales_Click(object sender, EventArgs e)
        {
            if (dataGridViewPartners.CurrentRow != null)
            {
                int partnerId = Convert.ToInt32(dataGridViewPartners.CurrentRow.Cells["PartnerId"].Value);
                using (var form = new SalesHistoryForm(partnerId))
                {
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите партнера для просмотра истории продаж.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewPartners_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int partnerId = Convert.ToInt32(dataGridViewPartners.Rows[e.RowIndex].Cells["PartnerId"].Value);
                using (var form = new PartnerEditForm(partnerId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadPartners();
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            db?.Dispose();
        }
    }
}