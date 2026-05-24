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
        private Panel pnlSummary;
        private Label lblTitle;
        private Label lblStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnShow;
        private Button btnWeekly;
        private Button btnMonthly;
        private Button btnYearly;
        private Button btnTopProducts;
        private Button btnProfitTrend;
        private Button btnPromoUsage;
        private Button btnClose;
        private Label lblTotalTransactionsTitle;
        private Label lblTotalTransactionsValue;
        private Label lblTotalSubtotalTitle;
        private Label lblTotalSubtotalValue;
        private Label lblTotalDiscountTitle;
        private Label lblTotalDiscountValue;
        private Label lblTotalRevenueTitle;
        private Label lblTotalRevenueValue;
        private Label lblAverageTransactionTitle;
        private Label lblAverageTransactionValue;
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
            this.pnlSummary = new Panel();
            this.lblTitle = new Label();
            this.lblStartDate = new Label();
            this.lblEndDate = new Label();
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.btnShow = new Button();
            this.btnWeekly = new Button();
            this.btnMonthly = new Button();
            this.btnYearly = new Button();
            this.btnTopProducts = new Button();
            this.btnProfitTrend = new Button();
            this.btnPromoUsage = new Button();
            this.btnClose = new Button();
            this.lblTotalTransactionsTitle = new Label();
            this.lblTotalTransactionsValue = new Label();
            this.lblTotalSubtotalTitle = new Label();
            this.lblTotalSubtotalValue = new Label();
            this.lblTotalDiscountTitle = new Label();
            this.lblTotalDiscountValue = new Label();
            this.lblTotalRevenueTitle = new Label();
            this.lblTotalRevenueValue = new Label();
            this.lblAverageTransactionTitle = new Label();
            this.lblAverageTransactionValue = new Label();
            this.reportViewer = new ReportViewer();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();

            this.ClientSize = new Size(1100, 760);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Benshop - Laporan";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.MinimumSize = new Size(1080, 720);

            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(1100, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Laporan Penjualan";
            this.lblTitle.Location = new Point(20, 12);
            this.pnlTop.Controls.Add(this.lblTitle);

            this.pnlFilter.BackColor = Color.White;
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Size = new Size(1100, 112);
            this.pnlFilter.Padding = new Padding(20, 12, 20, 12);

            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblStartDate.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblStartDate.Text = "Dari Tanggal";
            this.lblStartDate.Location = new Point(20, 14);

            this.dtpStartDate.Font = new Font("Segoe UI", 10);
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new Point(20, 36);
            this.dtpStartDate.Size = new Size(135, 30);

            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.lblEndDate.ForeColor = Color.FromArgb(51, 65, 85);
            this.lblEndDate.Text = "Sampai Tanggal";
            this.lblEndDate.Location = new Point(170, 14);

            this.dtpEndDate.Font = new Font("Segoe UI", 10);
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new Point(170, 36);
            this.dtpEndDate.Size = new Size(135, 30);

            this.btnShow.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnShow.Text = "Tampilkan";
            this.btnShow.Location = new Point(320, 34);
            this.btnShow.Size = new Size(115, 34);
            this.btnShow.Cursor = Cursors.Hand;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);

            this.btnWeekly.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnWeekly.Text = "Mingguan";
            this.btnWeekly.Location = new Point(20, 74);
            this.btnWeekly.Size = new Size(110, 30);
            this.btnWeekly.Cursor = Cursors.Hand;
            this.btnWeekly.Click += new System.EventHandler(this.btnWeekly_Click);

            this.btnMonthly.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnMonthly.Text = "Bulanan";
            this.btnMonthly.Location = new Point(140, 74);
            this.btnMonthly.Size = new Size(110, 30);
            this.btnMonthly.Cursor = Cursors.Hand;
            this.btnMonthly.Click += new System.EventHandler(this.btnMonthly_Click);

            this.btnYearly.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnYearly.Text = "Tahunan";
            this.btnYearly.Location = new Point(260, 74);
            this.btnYearly.Size = new Size(110, 30);
            this.btnYearly.Cursor = Cursors.Hand;
            this.btnYearly.Click += new System.EventHandler(this.btnYearly_Click);

            this.btnTopProducts.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnTopProducts.Text = "Produk Terlaris";
            this.btnTopProducts.Location = new Point(390, 74);
            this.btnTopProducts.Size = new Size(135, 30);
            this.btnTopProducts.Cursor = Cursors.Hand;
            this.btnTopProducts.Click += new System.EventHandler(this.btnTopProducts_Click);

            this.btnProfitTrend.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnProfitTrend.Text = "Tren Pendapatan";
            this.btnProfitTrend.Location = new Point(535, 74);
            this.btnProfitTrend.Size = new Size(155, 30);
            this.btnProfitTrend.Cursor = Cursors.Hand;
            this.btnProfitTrend.Click += new System.EventHandler(this.btnProfitTrend_Click);

            this.btnPromoUsage.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnPromoUsage.Text = "Promo";
            this.btnPromoUsage.Location = new Point(700, 74);
            this.btnPromoUsage.Size = new Size(100, 30);
            this.btnPromoUsage.Cursor = Cursors.Hand;
            this.btnPromoUsage.Click += new System.EventHandler(this.btnPromoUsage_Click);

            this.btnClose.Font = new Font("Segoe UI", 10);
            this.btnClose.Text = "Tutup";
            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(970, 34);
            this.btnClose.Size = new Size(100, 34);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlFilter.Controls.Add(this.lblStartDate);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Controls.Add(this.lblEndDate);
            this.pnlFilter.Controls.Add(this.dtpEndDate);
            this.pnlFilter.Controls.Add(this.btnShow);
            this.pnlFilter.Controls.Add(this.btnWeekly);
            this.pnlFilter.Controls.Add(this.btnMonthly);
            this.pnlFilter.Controls.Add(this.btnYearly);
            this.pnlFilter.Controls.Add(this.btnTopProducts);
            this.pnlFilter.Controls.Add(this.btnProfitTrend);
            this.pnlFilter.Controls.Add(this.btnPromoUsage);
            this.pnlFilter.Controls.Add(this.btnClose);

            this.pnlSummary.BackColor = Color.FromArgb(241, 245, 249);
            this.pnlSummary.Dock = DockStyle.Top;
            this.pnlSummary.Size = new Size(1100, 92);
            this.pnlSummary.Padding = new Padding(20, 12, 20, 12);

            ConfigureSummaryLabel(this.lblTotalTransactionsTitle, "Total Transaksi", 20, 14, false);
            ConfigureSummaryLabel(this.lblTotalTransactionsValue, "0", 20, 40, true);
            ConfigureSummaryLabel(this.lblTotalSubtotalTitle, "Omzet Kotor", 220, 14, false);
            ConfigureSummaryLabel(this.lblTotalSubtotalValue, "Rp 0", 220, 40, true);
            ConfigureSummaryLabel(this.lblTotalDiscountTitle, "Total Diskon", 430, 14, false);
            ConfigureSummaryLabel(this.lblTotalDiscountValue, "Rp 0", 430, 40, true);
            ConfigureSummaryLabel(this.lblTotalRevenueTitle, "Pendapatan Bersih", 640, 14, false);
            ConfigureSummaryLabel(this.lblTotalRevenueValue, "Rp 0", 640, 40, true);
            ConfigureSummaryLabel(this.lblAverageTransactionTitle, "Rata-rata Transaksi", 860, 14, false);
            ConfigureSummaryLabel(this.lblAverageTransactionValue, "Rp 0", 860, 40, true);

            this.pnlSummary.Controls.Add(this.lblTotalTransactionsTitle);
            this.pnlSummary.Controls.Add(this.lblTotalTransactionsValue);
            this.pnlSummary.Controls.Add(this.lblTotalSubtotalTitle);
            this.pnlSummary.Controls.Add(this.lblTotalSubtotalValue);
            this.pnlSummary.Controls.Add(this.lblTotalDiscountTitle);
            this.pnlSummary.Controls.Add(this.lblTotalDiscountValue);
            this.pnlSummary.Controls.Add(this.lblTotalRevenueTitle);
            this.pnlSummary.Controls.Add(this.lblTotalRevenueValue);
            this.pnlSummary.Controls.Add(this.lblAverageTransactionTitle);
            this.pnlSummary.Controls.Add(this.lblAverageTransactionValue);

            this.reportViewer.Dock = DockStyle.Fill;
            this.reportViewer.Location = new Point(0, 264);
            this.reportViewer.Size = new Size(1100, 496);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.ShowToolBar = true;

            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
        }

        private void ConfigureSummaryLabel(Label label, string text, int left, int top, bool isValue)
        {
            label.AutoSize = true;
            label.Font = isValue
                ? new Font("Segoe UI", 14, FontStyle.Bold)
                : new Font("Segoe UI", 9, FontStyle.Bold);
            label.ForeColor = isValue ? Color.FromArgb(15, 23, 42) : Color.FromArgb(100, 116, 139);
            label.Text = text;
            label.Location = new Point(left, top);
        }
    }
}
