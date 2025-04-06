namespace Demonstration_exam_2024.Forms
{
    partial class PartnersListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnViewSales;
        private System.Windows.Forms.DataGridView dataGridViewPartners;

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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnViewSales = new System.Windows.Forms.Button();
            this.dataGridViewPartners = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartners)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4E8D3");
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Список партнеров";
            this.panelTop.Controls.Add(this.lblTitle);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 82);
            this.btnAdd.Size = new System.Drawing.Size(150, 35);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnViewSales
            this.btnViewSales.Location = new System.Drawing.Point(172, 82);
            this.btnViewSales.Size = new System.Drawing.Size(150, 35);
            this.btnViewSales.Text = "История продаж";
            this.btnViewSales.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnViewSales.ForeColor = System.Drawing.Color.White;
            this.btnViewSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSales.FlatAppearance.BorderSize = 0;
            this.btnViewSales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewSales.Click += new System.EventHandler(this.btnViewSales_Click);

            // dataGridViewPartners
            this.dataGridViewPartners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPartners.Location = new System.Drawing.Point(12, 129);
            this.dataGridViewPartners.Size = new System.Drawing.Size(960, 420);
            this.dataGridViewPartners.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPartners.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPartners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPartners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPartners.ReadOnly = true;
            this.dataGridViewPartners.RowHeadersVisible = false;
            this.dataGridViewPartners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPartners.MultiSelect = false;
            this.dataGridViewPartners.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPartners_CellDoubleClick);

            // PartnersListForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnViewSales);
            this.Controls.Add(this.dataGridViewPartners);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Text = "Партнеры";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartners)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}