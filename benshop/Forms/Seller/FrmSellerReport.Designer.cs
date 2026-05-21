using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace benshop.Forms.Seller
{
    partial class FrmSellerReport
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Panel pnlFilter;
        private Label lblTitle;
        private Button btnWeekly;
        private Button btnMonthly;
        private Button btnYearly;
        private Button btnTopProducts;
        private Button btnProfitTrend;
        private Button btnClose;
        private ReportViewer reportViewer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.pnlFilter = new Panel();
            this.lblTitle = new Label();
            this.btnWeekly = new Button();
            this.btnMonthly = new Button();
            this.btnYearly = new Button();
            this.btnTopProducts = new Button();
            this.btnProfitTrend = new Button();
            this.btnClose = new Button();
            this.reportViewer = new ReportViewer();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();

            this.ClientSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Benshop - Laporan";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // pnlTop
            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(1000, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Laporan Penjualan";
            this.lblTitle.Location = new Point(20, 12);
            this.pnlTop.Controls.Add(this.lblTitle);

            // pnlFilter
            this.pnlFilter.BackColor = Color.White;
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Size = new Size(1000, 70);
            this.pnlFilter.Padding = new Padding(10);

            this.btnWeekly.BackColor = Color.FromArgb(13, 148, 136);
            this.btnWeekly.FlatStyle = FlatStyle.Flat;
            this.btnWeekly.FlatAppearance.BorderSize = 0;
            this.btnWeekly.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnWeekly.ForeColor = Color.White;
            this.btnWeekly.Text = "Mingguan";
            this.btnWeekly.Location = new Point(20, 15);
            this.btnWeekly.Size = new Size(120, 40);
            this.btnWeekly.Cursor = Cursors.Hand;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);

            this.btnMonthly.BackColor = Color.FromArgb(59, 130, 246);
            this.btnMonthly.FlatStyle = FlatStyle.Flat;
            this.btnMonthly.FlatAppearance.BorderSize = 0;
            this.btnMonthly.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnMonthly.ForeColor = Color.White;
            this.btnMonthly.Text = "Bulanan";
            this.btnMonthly.Location = new Point(150, 15);
            this.btnMonthly.Size = new Size(120, 40);
            this.btnMonthly.Cursor = Cursors.Hand;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);

            this.btnYearly.BackColor = Color.FromArgb(239, 68, 68);
            this.btnYearly.FlatStyle = FlatStyle.Flat;
            this.btnYearly.FlatAppearance.BorderSize = 0;
            this.btnYearly.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnYearly.ForeColor = Color.White;
            this.btnYearly.Text = "Tahunan";
            this.btnYearly.Location = new Point(280, 15);
            this.btnYearly.Size = new Size(120, 40);
            this.btnYearly.Cursor = Cursors.Hand;
            this.btnYearly.Click += new System.EventHandler(this.btnYearly_Click);

            this.btnTopProducts.BackColor = Color.FromArgb(168, 85, 247);
            this.btnTopProducts.FlatStyle = FlatStyle.Flat;
            this.btnTopProducts.FlatAppearance.BorderSize = 0;
            this.btnTopProducts.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnTopProducts.ForeColor = Color.White;
            this.btnTopProducts.Text = "Produk Terlaris";
            this.btnTopProducts.Location = new Point(430, 15);
            this.btnTopProducts.Size = new Size(150, 40);
            this.btnTopProducts.Cursor = Cursors.Hand;
            this.btnTopProducts.Click += new System.EventHandler(this.btnTopProducts_Click);

            this.btnProfitTrend.BackColor = Color.FromArgb(245, 158, 11);
            this.btnProfitTrend.FlatStyle = FlatStyle.Flat;
            this.btnProfitTrend.FlatAppearance.BorderSize = 0;
            this.btnProfitTrend.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnProfitTrend.ForeColor = Color.White;
            this.btnProfitTrend.Text = "Tren Laba";
            this.btnProfitTrend.Location = new Point(590, 15);
            this.btnProfitTrend.Size = new Size(130, 40);
            this.btnProfitTrend.Cursor = Cursors.Hand;
            this.btnProfitTrend.Click += new System.EventHandler(this.btnProfitTrend_Click);

            this.btnClose.BackColor = Color.FromArgb(226, 232, 240);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 11);
            this.btnClose.Text = "Tutup";
            this.btnClose.Location = new Point(850, 15);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlFilter.Controls.Add(this.btnWeekly);
            this.pnlFilter.Controls.Add(this.btnMonthly);
            this.pnlFilter.Controls.Add(this.btnYearly);
            this.pnlFilter.Controls.Add(this.btnTopProducts);
            this.pnlFilter.Controls.Add(this.btnProfitTrend);
            this.pnlFilter.Controls.Add(this.btnClose);

            // reportViewer
            this.reportViewer.Dock = DockStyle.Fill;
            this.reportViewer.Location = new Point(0, 130);
            this.reportViewer.Size = new Size(1000, 570);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.ShowToolBar = true;

            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
