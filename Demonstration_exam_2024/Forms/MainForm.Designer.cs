namespace Demonstration_exam_2024.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnViewHistory;
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
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblUserLogin = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // pictureBoxLogo
            this.pictureBoxLogo.Location = new System.Drawing.Point(420, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 40);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;

            // lblDateTime
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(12, 12);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(200, 15);
            this.lblDateTime.Text = "";
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblUserLogin
            this.lblUserLogin.AutoSize = true;
            this.lblUserLogin.Location = new System.Drawing.Point(12, 37);
            this.lblUserLogin.Name = "lblUserLogin";
            this.lblUserLogin.Size = new System.Drawing.Size(200, 15);
            this.lblUserLogin.Text = "";
            this.lblUserLogin.Font = new System.Drawing.Font("Segoe UI", 9F);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(640, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 15);
            this.lblSearch.Text = "Поиск:";
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(690, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            // dataGridView1
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(960, 450);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);

            // btnAdd
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 520);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить партнера";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnViewHistory
            this.btnViewHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewHistory.Location = new System.Drawing.Point(172, 520);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(150, 30);
            this.btnViewHistory.TabIndex = 4;
            this.btnViewHistory.Text = "История продаж";
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnViewHistory);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblUserLogin);
            this.Controls.Add(this.pictureBoxLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мастер-Пол";
            this.Load += new System.EventHandler(this.MainForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}