namespace Demonstration_exam_2024.Forms
{
    partial class ProductListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCount;

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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4E8D3");
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.lblSearch);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "Продукция";

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 35);
            this.lblSearch.Text = "Поиск:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(60, 32);
            this.txtSearch.Size = new System.Drawing.Size(250, 23);

            // dataGridView1
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);

            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.White;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 60;
            this.panelBottom.Padding = new System.Windows.Forms.Padding(12);

            // Кнопки
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Text = "Добавить";

            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.Location = new System.Drawing.Point(142, 12);
            this.btnEdit.Text = "Изменить";

            this.btnDelete.Size = new System.Drawing.Size(120, 35);
            this.btnDelete.Location = new System.Drawing.Point(272, 12);
            this.btnDelete.Text = "Удалить";

            this.btnBack.Size = new System.Drawing.Size(120, 35);
            this.btnBack.Location = new System.Drawing.Point(402, 12);
            this.btnBack.Text = "Назад";

            // lblCount
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(532, 21);
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.Text = "Всего записей: 0";

            // Добавление контролов на panelBottom
            this.panelBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd,
                this.btnEdit,
                this.btnDelete,
                this.btnBack,
                this.lblCount
            });

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // События
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}