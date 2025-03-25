namespace Demonstration_exam_2024.Forms
{
    partial class PartnerHistoryForm
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
            this.lblCompanyInfo = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();

            this.dgvHistory = new System.Windows.Forms.DataGridView();

            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotalInfo = new System.Windows.Forms.Label();

            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 100;
            this.panelTop.Controls.Add(this.lblCompanyInfo);
            this.panelTop.Controls.Add(this.lblDiscount);

            // lblCompanyInfo
            this.lblCompanyInfo.AutoSize = true;
            this.lblCompanyInfo.Location = new System.Drawing.Point(20, 20);

            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 60);

            // dgvHistory
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;

            // panelBottom
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 80;
            this.panelBottom.Controls.Add(this.lblTotalInfo);

            // lblTotalInfo
            this.lblTotalInfo.AutoSize = true;
            this.lblTotalInfo.Location = new System.Drawing.Point(20, 20);

            // PartnerHistoryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblCompanyInfo;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblTotalInfo;
    }
}