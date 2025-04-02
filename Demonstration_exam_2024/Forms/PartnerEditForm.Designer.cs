using System;
using System.Windows.Forms;
using System.Drawing;

namespace Demonstration_exam_2024.Forms
{
    partial class PartnerEditForm
    {
        private System.ComponentModel.IContainer components = null;

        // Объявление элементов управления
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
            // Инициализация компонентов
            this.components = new System.ComponentModel.Container();

            // Создание элементов управления
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFormDescription = new System.Windows.Forms.Label();
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

            // Настройка формы
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 580);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // Настройка panelTop
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4E8D3");
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // Заголовок
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "Партнер";
            this.panelTop.Controls.Add(this.lblTitle);

            // Описание формы
            this.lblFormDescription.AutoSize = true;
            this.lblFormDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFormDescription.Location = new System.Drawing.Point(22, 40);
            this.lblFormDescription.Text = "Добавление/Редактирование информации о партнере";
            this.panelTop.Controls.Add(this.lblFormDescription);

            // Начальные координаты для размещения элементов
            int startY = 90;            // Начальная позиция Y после панели
            int leftMargin = 20;        // Отступ слева
            int labelHeight = 20;       // Высота метки
            int controlHeight = 30;     // Высота элемента управления
            int verticalGap = 25;       // Вертикальный промежуток между группами элементов
            int horizontalGap = 20;     // Горизонтальный промежуток между элементами
            int controlWidth = 560;     // Ширина для полных элементов
            int halfWidth = 270;        // Ширина для половинных элементов

            // Функция для настройки общего стиля меток
            void SetupLabel(System.Windows.Forms.Label label)
            {
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("Segoe UI", 9F);
                label.ForeColor = System.Drawing.Color.Black;
            }

            // Тип организации
            SetupLabel(this.lblCompanyType);
            this.lblCompanyType.Location = new System.Drawing.Point(leftMargin, startY);
            this.lblCompanyType.Text = "Тип организации *";

            this.cmbCompanyType.Location = new System.Drawing.Point(leftMargin, startY + labelHeight);
            this.cmbCompanyType.Size = new System.Drawing.Size(controlWidth, controlHeight);
            startY += labelHeight + controlHeight + verticalGap;

            // Название организации
            SetupLabel(this.lblCompanyName);
            this.lblCompanyName.Location = new System.Drawing.Point(leftMargin, startY);
            this.lblCompanyName.Text = "Наименование организации *";

            this.txtCompanyName.Location = new System.Drawing.Point(leftMargin, startY + labelHeight);
            this.txtCompanyName.Size = new System.Drawing.Size(controlWidth, controlHeight);
            startY += labelHeight + controlHeight + verticalGap;

            // ФИО директора
            SetupLabel(this.lblDirectorName);
            this.lblDirectorName.Location = new System.Drawing.Point(leftMargin, startY);
            this.lblDirectorName.Text = "ФИО директора *";

            this.txtDirectorName.Location = new System.Drawing.Point(leftMargin, startY + labelHeight);
            this.txtDirectorName.Size = new System.Drawing.Size(controlWidth, controlHeight);
            startY += labelHeight + controlHeight + verticalGap;

            // Телефон и Email в одну строку
            SetupLabel(this.lblPhone);
            this.lblPhone.Location = new System.Drawing.Point(leftMargin, startY);
            this.lblPhone.Text = "Телефон *";

            SetupLabel(this.lblEmail);
            this.lblEmail.Location = new System.Drawing.Point(leftMargin + halfWidth + horizontalGap, startY);
            this.lblEmail.Text = "Email *";

            this.txtPhone.Location = new System.Drawing.Point(leftMargin, startY + labelHeight);
            this.txtPhone.Size = new System.Drawing.Size(halfWidth, controlHeight);

            this.txtEmail.Location = new System.Drawing.Point(leftMargin + halfWidth + horizontalGap, startY + labelHeight);
            this.txtEmail.Size = new System.Drawing.Size(halfWidth, controlHeight);
            startY += labelHeight + controlHeight + verticalGap;

            // Адрес
            SetupLabel(this.lblAddress);
            this.lblAddress.Location = new System.Drawing.Point(leftMargin, startY);
            this.lblAddress.Text = "Юридический адрес *";

            this.txtAddress.Location = new System.Drawing.Point(leftMargin, startY + labelHeight);
            this.txtAddress.Size = new System.Drawing.Size(controlWidth, controlHeight);
            startY += labelHeight + controlHeight + verticalGap;

            // ИНН и Рейтинг в одну строку
            SetupLabel(this.lblINN);
            this.lblINN.Location = new System.Drawing.Point(leftMargin, startY);
            this.lblINN.Text = "ИНН *";

            SetupLabel(this.lblRating);
            this.lblRating.Location = new System.Drawing.Point(leftMargin + halfWidth + horizontalGap, startY);
            this.lblRating.Text = "Рейтинг (0-10)";

            this.txtINN.Location = new System.Drawing.Point(leftMargin, startY + labelHeight);
            this.txtINN.Size = new System.Drawing.Size(halfWidth, controlHeight);

            this.numericRating.Location = new System.Drawing.Point(leftMargin + halfWidth + horizontalGap, startY + labelHeight);
            this.numericRating.Size = new System.Drawing.Size(halfWidth, controlHeight);
            startY += labelHeight + controlHeight + verticalGap + 10;

            // Кнопки
            this.btnSave.Location = new System.Drawing.Point(leftMargin, startY);
            this.btnSave.Size = new System.Drawing.Size(halfWidth, 40);
            this.btnSave.Text = "Сохранить";
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#67BA80");
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.btnCancel.Location = new System.Drawing.Point(leftMargin + halfWidth + horizontalGap, startY);
            this.btnCancel.Size = new System.Drawing.Size(halfWidth, 40);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(255, 74, 74);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // Добавление элементов управления на форму
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

            // Привязка обработчиков событий
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            ((System.ComponentModel.ISupportInitialize)(this.numericRating)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}