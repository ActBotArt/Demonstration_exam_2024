namespace Demonstration_exam_2024.Forms
{
    partial class PartnerEditForm
    {
        private System.ComponentModel.IContainer components = null;

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

            this.lblCompanyType = new System.Windows.Forms.Label();
            this.cmbCompanyType = new System.Windows.Forms.ComboBox();

            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();

            this.lblDirectorName = new System.Windows.Forms.Label();
            this.txtDirectorName = new System.Windows.Forms.TextBox();

            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();

            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();

            this.lblINN = new System.Windows.Forms.Label();
            this.txtINN = new System.Windows.Forms.TextBox();

            this.lblRating = new System.Windows.Forms.Label();
            this.numericRating = new System.Windows.Forms.NumericUpDown();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numericRating)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;
            this.panelTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);

            // Настройка остальных контролов
            int startY = 80;
            int labelX = 20;
            int controlX = 150;
            int spacing = 40;
            int controlWidth = 300;

            // Тип компании
            this.lblCompanyType.Location = new System.Drawing.Point(labelX, startY);
            this.lblCompanyType.Text = "Тип компании:";
            this.cmbCompanyType.Location = new System.Drawing.Point(controlX, startY);
            this.cmbCompanyType.Width = controlWidth;

            // Название компании
            startY += spacing;
            this.lblCompanyName.Location = new System.Drawing.Point(labelX, startY);
            this.lblCompanyName.Text = "Название:";
            this.txtCompanyName.Location = new System.Drawing.Point(controlX, startY);
            this.txtCompanyName.Width = controlWidth;

            // ФИО директора
            startY += spacing;
            this.lblDirectorName.Location = new System.Drawing.Point(labelX, startY);
            this.lblDirectorName.Text = "Директор:";
            this.txtDirectorName.Location = new System.Drawing.Point(controlX, startY);
            this.txtDirectorName.Width = controlWidth;

            // Телефон
            startY += spacing;
            this.lblPhone.Location = new System.Drawing.Point(labelX, startY);
            this.lblPhone.Text = "Телефон:";
            this.txtPhone.Location = new System.Drawing.Point(controlX, startY);
            this.txtPhone.Width = controlWidth;

            // Email
            startY += spacing;
            this.lblEmail.Location = new System.Drawing.Point(labelX, startY);
            this.lblEmail.Text = "Email:";
            this.txtEmail.Location = new System.Drawing.Point(controlX, startY);
            this.txtEmail.Width = controlWidth;

            // Адрес
            startY += spacing;
            this.lblAddress.Location = new System.Drawing.Point(labelX, startY);
            this.lblAddress.Text = "Адрес:";
            this.txtAddress.Location = new System.Drawing.Point(controlX, startY);
            this.txtAddress.Width = controlWidth;

            // ИНН
            startY += spacing;
            this.lblINN.Location = new System.Drawing.Point(labelX, startY);
            this.lblINN.Text = "ИНН:";
            this.txtINN.Location = new System.Drawing.Point(controlX, startY);
            this.txtINN.Width = controlWidth;

            // Рейтинг
            startY += spacing;
            this.lblRating.Location = new System.Drawing.Point(labelX, startY);
            this.lblRating.Text = "Рейтинг:";
            this.numericRating.Location = new System.Drawing.Point(controlX, startY);
            this.numericRating.Width = 100;

            // Кнопки
            startY += spacing + 20;
            this.btnSave.Location = new System.Drawing.Point(controlX, startY);
            this.btnSave.Width = 100;
            this.btnSave.Height = 30;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(controlX + 120, startY);
            this.btnCancel.Width = 100;
            this.btnCancel.Height = 30;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // PartnerEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, startY + 80);

            // Добавление контролов на форму
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblCompanyType);
            this.Controls.Add(this.cmbCompanyType);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.lblDirectorName);
            this.Controls.Add(this.txtDirectorName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblINN);
            this.Controls.Add(this.txtINN);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.numericRating);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.numericRating)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCompanyType;
        private System.Windows.Forms.ComboBox cmbCompanyType;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblDirectorName;
        private System.Windows.Forms.TextBox txtDirectorName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblINN;
        private System.Windows.Forms.TextBox txtINN;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.NumericUpDown numericRating;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}