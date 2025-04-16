namespace Demonstration_exam_2024.Forms
{
    partial class AddProductForm
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
            this.lblFormDescription = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.lblArticleNumber = new System.Windows.Forms.Label();
            this.txtArticleNumber = new System.Windows.Forms.TextBox();
            this.lblMinCost = new System.Windows.Forms.Label();
            this.numericMinCost = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinCost)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(120, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Продукция";

            // lblFormDescription
            this.lblFormDescription.AutoSize = true;
            this.lblFormDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFormDescription.Location = new System.Drawing.Point(22, 45);
            this.lblFormDescription.Name = "lblFormDescription";
            this.lblFormDescription.Size = new System.Drawing.Size(350, 19);
            this.lblFormDescription.TabIndex = 1;
            this.lblFormDescription.Text = "Добавление информации о продукции";

            // lblProductName
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(20, 100);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(135, 15);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Название продукции *";

            // txtProductName
            this.txtProductName.Location = new System.Drawing.Point(20, 120);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(560, 23);
            this.txtProductName.TabIndex = 3;

            // lblTypeName
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(20, 155);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(102, 15);
            this.lblTypeName.TabIndex = 4;
            this.lblTypeName.Text = "Тип продукции *";

            // txtTypeName
            this.txtTypeName.Location = new System.Drawing.Point(20, 175);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(560, 23);
            this.txtTypeName.TabIndex = 5;

            // lblArticleNumber
            this.lblArticleNumber.AutoSize = true;
            this.lblArticleNumber.Location = new System.Drawing.Point(20, 210);
            this.lblArticleNumber.Name = "lblArticleNumber";
            this.lblArticleNumber.Size = new System.Drawing.Size(67, 15);
            this.lblArticleNumber.TabIndex = 6;
            this.lblArticleNumber.Text = "Артикул *";

            // txtArticleNumber
            this.txtArticleNumber.Location = new System.Drawing.Point(20, 230);
            this.txtArticleNumber.Name = "txtArticleNumber";
            this.txtArticleNumber.Size = new System.Drawing.Size(560, 23);
            this.txtArticleNumber.TabIndex = 7;

            // lblMinCost
            this.lblMinCost.AutoSize = true;
            this.lblMinCost.Location = new System.Drawing.Point(20, 265);
            this.lblMinCost.Name = "lblMinCost";
            this.lblMinCost.Size = new System.Drawing.Size(156, 15);
            this.lblMinCost.TabIndex = 8;
            this.lblMinCost.Text = "Минимальная стоимость *";

            // numericMinCost
            this.numericMinCost.Location = new System.Drawing.Point(20, 285);
            this.numericMinCost.Name = "numericMinCost";
            this.numericMinCost.Size = new System.Drawing.Size(560, 23);
            this.numericMinCost.TabIndex = 9;
            this.numericMinCost.DecimalPlaces = 2;
            this.numericMinCost.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(20, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(270, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(310, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(270, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddProductForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 390);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.panelTop,
                this.lblProductName,
                this.txtProductName,
                this.lblTypeName,
                this.txtTypeName,
                this.lblArticleNumber,
                this.txtArticleNumber,
                this.lblMinCost,
                this.numericMinCost,
                this.btnSave,
                this.btnCancel
            });
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Продукция";
            this.BackColor = System.Drawing.Color.White;

            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFormDescription;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label lblArticleNumber;
        private System.Windows.Forms.TextBox txtArticleNumber;
        private System.Windows.Forms.Label lblMinCost;
        private System.Windows.Forms.NumericUpDown numericMinCost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}