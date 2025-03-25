namespace Demonstration_exam_2024.Forms
{
    partial class EditPartnerForm
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
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblPartnerType = new System.Windows.Forms.Label();
            this.cmbPartnerType = new System.Windows.Forms.ComboBox();
            this.lblRating = new System.Windows.Forms.Label();
            this.numRating = new System.Windows.Forms.NumericUpDown();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblDirectorName = new System.Windows.Forms.Label();
            this.txtDirectorName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblINN = new System.Windows.Forms.Label();
            this.txtINN = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            this.SuspendLayout();

            // Layout
            int labelX = 20;
            int controlX = 150;
            int startY = 20;
            int stepY = 40;
            int currentY = startY;

            // CompanyName
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(labelX, currentY);
            this.lblCompanyName.Text = "Наименование:";

            this.txtCompanyName.Location = new System.Drawing.Point(controlX, currentY);
            this.txtCompanyName.Size = new System.Drawing.Size(300, 23);
            currentY += stepY;

            // PartnerType
            this.lblPartnerType.AutoSize = true;
            this.lblPartnerType.Location = new System.Drawing.Point(labelX, currentY);
            this.lblPartnerType.Text = "Тип партнера:";

            this.cmbPartnerType.Location = new System.Drawing.Point(controlX, currentY);
            this.cmbPartnerType.Size = new System.Drawing.Size(200, 23);
            currentY += stepY;

            // Rating
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(labelX, currentY);
            this.lblRating.Text = "Рейтинг:";

            this.numRating.Location = new System.Drawing.Point(controlX, currentY);
            this.numRating.Size = new System.Drawing.Size(100, 23);
            this.numRating.Maximum = 100;
            currentY += stepY;

            // Address
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(labelX, currentY);
            this.lblAddress.Text = "Адрес:";

            this.txtAddress.Location = new System.Drawing.Point(controlX, currentY);
            this.txtAddress.Size = new System.Drawing.Size(300, 23);
            currentY += stepY;

            // DirectorName
            this.lblDirectorName.AutoSize = true;
            this.lblDirectorName.Location = new System.Drawing.Point(labelX, currentY);
            this.lblDirectorName.Text = "ФИО директора:";

            this.txtDirectorName.Location = new System.Drawing.Point(controlX, currentY);
            this.txtDirectorName.Size = new System.Drawing.Size(300, 23);
            currentY += stepY;

            // Phone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(labelX, currentY);
            this.lblPhone.Text = "Телефон:";

            this.txtPhone.Location = new System.Drawing.Point(controlX, currentY);
            this.txtPhone.Size = new System.Drawing.Size(200, 23);
            currentY += stepY;

            // Email
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(labelX, currentY);
            this.lblEmail.Text = "Email:";

            this.txtEmail.Location = new System.Drawing.Point(controlX, currentY);
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            currentY += stepY;

            // INN
            this.lblINN.AutoSize = true;
            this.lblINN.Location = new System.Drawing.Point(labelX, currentY);
            this.lblINN.Text = "ИНН:";

            this.txtINN.Location = new System.Drawing.Point(controlX, currentY);
            this.txtINN.Size = new System.Drawing.Size(200, 23);
            currentY += stepY + 20;

            // Buttons
            this.btnSave.Location = new System.Drawing.Point(controlX, currentY);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Location = new System.Drawing.Point(controlX + 120, currentY);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, currentY + 50);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCompanyName, this.txtCompanyName,
                this.lblPartnerType, this.cmbPartnerType,
                this.lblRating, this.numRating,
                this.lblAddress, this.txtAddress,
                this.lblDirectorName, this.txtDirectorName,
                this.lblPhone, this.txtPhone,
                this.lblEmail, this.txtEmail,
                this.lblINN, this.txtINN,
                this.btnSave, this.btnCancel
            });
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblPartnerType;
        private System.Windows.Forms.ComboBox cmbPartnerType;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblDirectorName;
        private System.Windows.Forms.TextBox txtDirectorName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblINN;
        private System.Windows.Forms.TextBox txtINN;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}