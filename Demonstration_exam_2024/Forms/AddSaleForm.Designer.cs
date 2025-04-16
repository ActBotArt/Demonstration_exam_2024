namespace Demonstration_exam_2024.Forms
{
    partial class AddSaleForm
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
            this.lblProduct = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numericQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numericPrice = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4E8D3");
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 70;
            this.panelTop.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Добавление продажи";
            this.panelTop.Controls.Add(this.lblTitle);

            // lblProduct
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(20, 90);
            this.lblProduct.Text = "Продукт *";

            // cmbProduct
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Location = new System.Drawing.Point(20, 110);
            this.cmbProduct.Size = new System.Drawing.Size(360, 23);
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(20, 145);
            this.lblQuantity.Text = "Количество *";

            // numericQuantity
            this.numericQuantity.Location = new System.Drawing.Point(20, 165);
            this.numericQuantity.Size = new System.Drawing.Size(360, 23);
            this.numericQuantity.ValueChanged += new System.EventHandler(this.numericQuantity_ValueChanged);

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 200);
            this.lblPrice.Text = "Цена *";

            // numericPrice
            this.numericPrice.Location = new System.Drawing.Point(20, 220);
            this.numericPrice.Size = new System.Drawing.Size(360, 23);
            this.numericPrice.ReadOnly = true;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(20, 265);
            this.btnSave.Size = new System.Drawing.Size(170, 40);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(210, 265);
            this.btnCancel.Size = new System.Drawing.Size(170, 40);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddSaleForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.panelTop,
                this.lblProduct,
                this.cmbProduct,
                this.lblQuantity,
                this.numericQuantity,
                this.lblPrice,
                this.numericPrice,
                this.btnSave,
                this.btnCancel
            });
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;

            ((System.ComponentModel.ISupportInitialize)(this.numericQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numericQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}