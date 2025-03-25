namespace Demonstration_exam_2024.Forms
{
    partial class PartnerEditForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Объявление элементов управления
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox cmbCompanyType;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtDirectorName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtINN;
        private System.Windows.Forms.NumericUpDown numericRating;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
        /// Требуемый метод для поддержки конструктора – не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.cmbCompanyType = new System.Windows.Forms.ComboBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtDirectorName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtINN = new System.Windows.Forms.TextBox();
            this.numericRating = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericRating)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 50);
            this.panelTop.TabIndex = 0;
            // 
            // cmbCompanyType
            // 
            this.cmbCompanyType.FormattingEnabled = true;
            this.cmbCompanyType.Location = new System.Drawing.Point(20, 70);
            this.cmbCompanyType.Name = "cmbCompanyType";
            this.cmbCompanyType.Size = new System.Drawing.Size(150, 24);
            this.cmbCompanyType.TabIndex = 1;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(20, 110);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(300, 22);
            this.txtCompanyName.TabIndex = 2;
            // 
            // txtDirectorName
            // 
            this.txtDirectorName.Location = new System.Drawing.Point(20, 150);
            this.txtDirectorName.Name = "txtDirectorName";
            this.txtDirectorName.Size = new System.Drawing.Size(300, 22);
            this.txtDirectorName.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(20, 190);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(150, 22);
            this.txtPhone.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(20, 270);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(400, 22);
            this.txtAddress.TabIndex = 6;
            // 
            // txtINN
            // 
            this.txtINN.Location = new System.Drawing.Point(20, 310);
            this.txtINN.Name = "txtINN";
            this.txtINN.Size = new System.Drawing.Size(150, 22);
            this.txtINN.TabIndex = 7;
            // 
            // numericRating
            // 
            this.numericRating.Location = new System.Drawing.Point(20, 350);
            this.numericRating.Name = "numericRating";
            this.numericRating.Size = new System.Drawing.Size(120, 22);
            this.numericRating.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PartnerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericRating);
            this.Controls.Add(this.txtINN);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtDirectorName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.cmbCompanyType);
            this.Controls.Add(this.panelTop);
            this.Name = "PartnerEditForm";
            this.Text = "Редактирование партнера";
            ((System.ComponentModel.ISupportInitialize)(this.numericRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}