namespace Demonstration_exam_2024.Forms
{
    partial class SalesHistoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPartnerName;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnAddSale;
        private System.Windows.Forms.Button btnEditSale;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnDeleteSale;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPartnerName = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnAddSale = new System.Windows.Forms.Button();
            this.btnEditSale = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnDeleteSale = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4E8D3");
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 80;
            this.panelTop.Padding = new System.Windows.Forms.Padding(12);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Text = "История продаж";

            // lblPartnerName
            this.lblPartnerName.AutoSize = true;
            this.lblPartnerName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPartnerName.Location = new System.Drawing.Point(12, 35);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 55);
            this.lblSearch.Text = "Поиск:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(60, 52);
            this.txtSearch.Size = new System.Drawing.Size(250, 23);

            // dataGridViewSales
            this.dataGridViewSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSales.Location = new System.Drawing.Point(0, 80);
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.AllowUserToResizeRows = false;
            this.dataGridViewSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSales.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.MultiSelect = false;
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.RowHeadersVisible = false;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.ShowEditingIcon = false;

            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 60;
            this.panelBottom.Padding = new System.Windows.Forms.Padding(12);

            // Buttons
            int buttonWidth = 120;
            int buttonHeight = 35;
            int buttonSpacing = 10;
            int startX = 12;

            // btnAddSale
            this.btnAddSale.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnAddSale.Location = new System.Drawing.Point(startX, 12);
            this.btnAddSale.Text = "Добавить";
            this.btnAddSale.UseVisualStyleBackColor = true;

            // btnEditSale
            this.btnEditSale.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnEditSale.Location = new System.Drawing.Point(startX + buttonWidth + buttonSpacing, 12);
            this.btnEditSale.Text = "Изменить";
            this.btnEditSale.UseVisualStyleBackColor = true;

            // btnExportExcel
            this.btnExportExcel.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnExportExcel.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacing) * 2, 12);
            this.btnExportExcel.Text = "Экспорт";
            this.btnExportExcel.UseVisualStyleBackColor = true;

            // btnDeleteSale
            this.btnDeleteSale.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnDeleteSale.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacing) * 3, 12);
            this.btnDeleteSale.Text = "Удалить";
            this.btnDeleteSale.UseVisualStyleBackColor = true;

            // btnBack
            this.btnBack.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
            this.btnBack.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacing) * 4, 12);
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(startX + (buttonWidth + buttonSpacing) * 5, 21);
            this.lblTotal.Text = "Общая сумма: 0.00 ₽";

            // Add controls to panels
            this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.lblPartnerName,
                this.lblSearch,
                this.txtSearch
            });

            this.panelBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAddSale,
                this.btnEditSale,
                this.btnExportExcel,
                this.btnDeleteSale,
                this.btnBack,
                this.lblTotal
            });

            // SalesHistoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.dataGridViewSales);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.Text = "История продаж";

            // Events
            this.btnAddSale.Click += new System.EventHandler(this.btnAddSale_Click);
            this.btnEditSale.Click += new System.EventHandler(this.btnEditSale_Click);
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            this.btnDeleteSale.Click += new System.EventHandler(this.btnDeleteSale_Click);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}