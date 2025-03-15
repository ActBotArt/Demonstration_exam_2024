namespace Demonstration_exam_2024
{
    partial class MainForm
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btnPartners = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();

            // panelMenu
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Width = 250;
            this.panelMenu.Controls.Add(this.pictureBoxLogo);
            this.panelMenu.Controls.Add(this.btnPartners);
            this.panelMenu.Controls.Add(this.btnProducts);
            this.panelMenu.Controls.Add(this.btnWarehouse);
            this.panelMenu.Controls.Add(this.btnEmployees);

            // pictureBoxLogo
            this.pictureBoxLogo.Size = new System.Drawing.Size(230, 120);
            this.pictureBoxLogo.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // btnPartners
            this.btnPartners.Text = "Партнеры";
            this.btnPartners.Location = new System.Drawing.Point(10, 150);
            this.btnPartners.Size = new System.Drawing.Size(230, 40);
            this.btnPartners.Click += new System.EventHandler(this.btnPartners_Click);

            // btnProducts
            this.btnProducts.Text = "Продукция";
            this.btnProducts.Location = new System.Drawing.Point(10, 200);
            this.btnProducts.Size = new System.Drawing.Size(230, 40);
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);

            // btnWarehouse
            this.btnWarehouse.Text = "Склад";
            this.btnWarehouse.Location = new System.Drawing.Point(10, 250);
            this.btnWarehouse.Size = new System.Drawing.Size(230, 40);
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);

            // btnEmployees
            this.btnEmployees.Text = "Сотрудники";
            this.btnEmployees.Location = new System.Drawing.Point(10, 300);
            this.btnEmployees.Size = new System.Drawing.Size(230, 40);
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelMenu);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button btnPartners;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnEmployees;
    }
}