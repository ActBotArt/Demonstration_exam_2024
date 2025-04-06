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
            this.lblFormDescription = new System.Windows.Forms.Label();
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

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRating)).BeginInit();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4E8D3");
            this.panelTop.Controls.Add(this.lblFormDescription);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 80);
            this.panelTop.TabIndex = 0;
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(103, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Партнер";

            // lblFormDescription
            this.lblFormDescription.AutoSize = true;
            this.lblFormDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFormDescription.Location = new System.Drawing.Point(22, 45);
            this.lblFormDescription.Name = "lblFormDescription";
            this.lblFormDescription.Size = new System.Drawing.Size(350, 19);
            this.lblFormDescription.TabIndex = 1;
            this.lblFormDescription.Text = "Добавление/Редактирование информации о партнере";

            // lblCompanyType
            this.lblCompanyType.AutoSize = true;
            this.lblCompanyType.Location = new System.Drawing.Point(20, 100);
            this.lblCompanyType.Name = "lblCompanyType";
            this.lblCompanyType.Size = new System.Drawing.Size(107, 15);
            this.lblCompanyType.TabIndex = 1;
            this.lblCompanyType.Text = "Тип организации *";

            // cmbCompanyType
            this.cmbCompanyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanyType.FormattingEnabled = true;
            this.cmbCompanyType.Location = new System.Drawing.Point(20, 120);
            this.cmbCompanyType.Name = "cmbCompanyType";
            this.cmbCompanyType.Size = new System.Drawing.Size(560, 23);
            this.cmbCompanyType.TabIndex = 2;

            // lblCompanyName
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(20, 155);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(164, 15);
            this.lblCompanyName.TabIndex = 3;
            this.lblCompanyName.Text = "Наименование организации *";

            // txtCompanyName
            this.txtCompanyName.Location = new System.Drawing.Point(20, 175);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(560, 23);
            this.txtCompanyName.TabIndex = 4;

            // lblDirectorName
            this.lblDirectorName.AutoSize = true;
            this.lblDirectorName.Location = new System.Drawing.Point(20, 210);
            this.lblDirectorName.Name = "lblDirectorName";
            this.lblDirectorName.Size = new System.Drawing.Size(102, 15);
            this.lblDirectorName.TabIndex = 5;
            this.lblDirectorName.Text = "ФИО директора *";

            // txtDirectorName
            this.txtDirectorName.Location = new System.Drawing.Point(20, 230);
            this.txtDirectorName.Name = "txtDirectorName";
            this.txtDirectorName.Size = new System.Drawing.Size(560, 23);
            this.txtDirectorName.TabIndex = 6;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 265);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(63, 15);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Телефон *";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(20, 285);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(270, 23);
            this.txtPhone.TabIndex = 8;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(310, 265);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 15);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email *";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(310, 285);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(270, 23);
            this.txtEmail.TabIndex = 10;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 320);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(134, 15);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Юридический адрес *";

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(20, 340);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(560, 23);
            this.txtAddress.TabIndex = 12;

            // lblINN
            this.lblINN.AutoSize = true;
            this.lblINN.Location = new System.Drawing.Point(20, 375);
            this.lblINN.Name = "lblINN";
            this.lblINN.Size = new System.Drawing.Size(45, 15);
            this.lblINN.TabIndex = 13;
            this.lblINN.Text = "ИНН *";

            // txtINN
            this.txtINN.Location = new System.Drawing.Point(20, 395);
            this.txtINN.MaxLength = 10;
            this.txtINN.Name = "txtINN";
            this.txtINN.Size = new System.Drawing.Size(270, 23);
            this.txtINN.TabIndex = 14;

            // lblRating
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(310, 375);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(89, 15);
            this.lblRating.TabIndex = 15;
            this.lblRating.Text = "Рейтинг (0-10)";

            // numericRating
            this.numericRating.Location = new System.Drawing.Point(310, 395);
            this.numericRating.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numericRating.Name = "numericRating";
            this.numericRating.Size = new System.Drawing.Size(270, 23);
            this.numericRating.TabIndex = 16;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(20, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(270, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(310, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(270, 40);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(255, 74, 74);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // PartnerEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.panelTop,
                this.lblCompanyType,
                this.cmbCompanyType,
                this.lblCompanyName,
                this.txtCompanyName,
                this.lblDirectorName,
                this.txtDirectorName,
                this.lblPhone,
                this.txtPhone,
                this.lblEmail,
                this.txtEmail,
                this.lblAddress,
                this.txtAddress,
                this.lblINN,
                this.txtINN,
                this.lblRating,
                this.numericRating,
                this.btnSave,
                this.btnCancel
            });
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(616, 500);
            this.MaximumSize = new System.Drawing.Size(616, 800);
            this.Name = "PartnerEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Партнер";
            this.AutoScroll = true;

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFormDescription;
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