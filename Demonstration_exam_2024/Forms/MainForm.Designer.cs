namespace Demonstration_exam_2024.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Объявление компонентов
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblUserLogin;

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
            this.components = new System.ComponentModel.Container();

            // Инициализация компонентов
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblUserLogin = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4E8D3");
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;
            this.panelTop.Controls.Add(this.pictureBoxLogo);
            this.panelTop.Controls.Add(this.lblDateTime);
            this.panelTop.Controls.Add(this.lblUserLogin);
            this.panelTop.Controls.Add(this.lblSearch);
            this.panelTop.Controls.Add(this.txtSearch);

            // pictureBoxLogo
            this.pictureBoxLogo.Location = new System.Drawing.Point(420, 10);
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // lblDateTime
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(12, 10);
            this.lblDateTime.Text = "";
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblUserLogin
            this.lblUserLogin.AutoSize = true;
            this.lblUserLogin.Location = new System.Drawing.Point(12, 35);
            this.lblUserLogin.Text = "";
            this.lblUserLogin.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(640, 23);
            this.lblSearch.Text = "Поиск:";
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(690, 20);
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            // dataGridView1
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.Size = new System.Drawing.Size(984, 452);
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;

            // Кнопки внизу формы
            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 520);
            this.btnAdd.Size = new System.Drawing.Size(150, 30);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(172, 520);
            this.btnEdit.Size = new System.Drawing.Size(150, 30);
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(332, 520);
            this.btnDelete.Size = new System.Drawing.Size(150, 30);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;

            // btnViewHistory
            this.btnViewHistory.Location = new System.Drawing.Point(492, 520);
            this.btnViewHistory.Size = new System.Drawing.Size(150, 30);
            this.btnViewHistory.Text = "История продаж";
            this.btnViewHistory.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnViewHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewHistory.FlatAppearance.BorderSize = 0;

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(652, 520);
            this.btnRefresh.Size = new System.Drawing.Size(150, 30);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.BackColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Добавление элементов управления на форму
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.panelTop,
                this.dataGridView1,
                this.btnAdd,
                this.btnEdit,
                this.btnDelete,
                this.btnViewHistory,
                this.btnRefresh
            });

            // Привязка обработчиков событий
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}