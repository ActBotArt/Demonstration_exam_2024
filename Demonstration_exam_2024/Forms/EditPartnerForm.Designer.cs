namespace Demonstration_exam_2024.Forms
{
    partial class EditPartnerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Объявление элементов управления
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.ComboBox cmbPartnerType;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtDirectorName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtINN;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.cmbPartnerType = new System.Windows.Forms.ComboBox();
            this.numRating = new System.Windows.Forms.NumericUpDown();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtDirectorName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtINN = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(20, 20);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(200, 22);
            this.txtCompanyName.TabIndex = 0;
            // 
            // cmbPartnerType
            // 
            this.cmbPartnerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartnerType.FormattingEnabled = true;
            this.cmbPartnerType.Location = new System.Drawing.Point(20, 60);
            this.cmbPartnerType.Name = "cmbPartnerType";
            this.cmbPartnerType.Size = new System.Drawing.Size(200, 24);
            this.cmbPartnerType.TabIndex = 1;
            // 
            // numRating
            // 
            this.numRating.Location = new System.Drawing.Point(20, 100);
            this.numRating.Name = "numRating";
            this.numRating.Size = new System.Drawing.Size(120, 22);
            this.numRating.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(20, 140);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 22);
            this.txtAddress.TabIndex = 3;
            // 
            // txtDirectorName
            // 
            this.txtDirectorName.Location = new System.Drawing.Point(20, 180);
            this.txtDirectorName.Name = "txtDirectorName";
            this.txtDirectorName.Size = new System.Drawing.Size(200, 22);
            this.txtDirectorName.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(20, 220);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 22);
            this.txtPhone.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 260);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // txtINN
            // 
            this.txtINN.Location = new System.Drawing.Point(20, 300);
            this.txtINN.Name = "txtINN";
            this.txtINN.Size = new System.Drawing.Size(200, 22);
            this.txtINN.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditPartnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtINN);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtDirectorName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.numRating);
            this.Controls.Add(this.cmbPartnerType);
            this.Controls.Add(this.txtCompanyName);
            this.Name = "EditPartnerForm";
            this.Text = "Редактирование партнёра";
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}