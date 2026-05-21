using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Seller
{
    partial class FrmSellerDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlSidebar;
        private Panel pnlTop;
        private Panel pnlContent;
        private Panel pnlStats;
        private Label lblAppName;
        private Button btnProducts;
        private Button btnPromo;
        private Button btnReport;
        private Button btnLogout;
        private Label lblTotalProducts;
        private Label lblTotalProductsValue;
        private Label lblTotalTransactions;
        private Label lblTotalTransactionsValue;
        private Label lblRevenueToday;
        private Label lblRevenueTodayValue;
        private DataGridView dgvTopProducts;
        private DataGridView dgvRecentTransactions;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new Panel();
            this.pnlTop = new Panel();
            this.pnlContent = new Panel();
            this.pnlStats = new Panel();
            this.lblAppName = new Label();
            this.btnProducts = new Button();
            this.btnPromo = new Button();
            this.btnReport = new Button();
            this.btnLogout = new Button();
            this.lblTotalProducts = new Label();
            this.lblTotalProductsValue = new Label();
            this.lblTotalTransactions = new Label();
            this.lblTotalTransactionsValue = new Label();
            this.lblRevenueToday = new Label();
            this.lblRevenueTodayValue = new Label();
            this.dgvTopProducts = new DataGridView();
            this.dgvRecentTransactions = new DataGridView();
            this.btnRefresh = new Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvTopProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecentTransactions).BeginInit();
            this.SuspendLayout();

            this.ClientSize = new Size(1200, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Benshop - Seller Dashboard";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.WindowState = FormWindowState.Maximized;

            // pnlSidebar
            this.pnlSidebar.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Size = new Size(220, 750);
            this.pnlSidebar.Padding = new Padding(0, 20, 0, 0);

            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            this.lblAppName.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblAppName.Text = "Benshop";
            this.lblAppName.Location = new Point(50, 30);

            this.btnProducts.BackColor = Color.Transparent;
            this.btnProducts.FlatStyle = FlatStyle.Flat;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.Font = new Font("Segoe UI", 12);
            this.btnProducts.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnProducts.Text = "   Products";
            this.btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new Point(20, 120);
            this.btnProducts.Size = new Size(180, 50);
            this.btnProducts.Cursor = Cursors.Hand;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);

            this.btnPromo.BackColor = Color.Transparent;
            this.btnPromo.FlatStyle = FlatStyle.Flat;
            this.btnPromo.FlatAppearance.BorderSize = 0;
            this.btnPromo.Font = new Font("Segoe UI", 12);
            this.btnPromo.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnPromo.Text = "   Promo";
            this.btnPromo.TextAlign = ContentAlignment.MiddleLeft;
            this.btnPromo.Location = new Point(20, 180);
            this.btnPromo.Size = new Size(180, 50);
            this.btnPromo.Cursor = Cursors.Hand;
            this.btnPromo.Click += new System.EventHandler(this.btnPromo_Click);

            this.btnReport.BackColor = Color.Transparent;
            this.btnReport.FlatStyle = FlatStyle.Flat;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.Font = new Font("Segoe UI", 12);
            this.btnReport.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnReport.Text = "   Report";
            this.btnReport.TextAlign = ContentAlignment.MiddleLeft;
            this.btnReport.Location = new Point(20, 240);
            this.btnReport.Size = new Size(180, 50);
            this.btnReport.Cursor = Cursors.Hand;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);

            this.btnLogout.BackColor = Color.Transparent;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new Font("Segoe UI", 12);
            this.btnLogout.ForeColor = Color.FromArgb(239, 68, 68);
            this.btnLogout.Text = "   Logout";
            this.btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new Point(20, 600);
            this.btnLogout.Size = new Size(180, 50);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Controls.Add(this.btnProducts);
            this.pnlSidebar.Controls.Add(this.btnPromo);
            this.pnlSidebar.Controls.Add(this.btnReport);
            this.pnlSidebar.Controls.Add(this.btnLogout);

            // pnlTop
            this.pnlTop.BackColor = Color.White;
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(980, 20);

            // pnlContent
            this.pnlContent.BackColor = Color.FromArgb(248, 250, 252);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Padding = new Padding(20);

            // pnlStats
            this.pnlStats.BackColor = Color.White;
            this.pnlStats.Location = new Point(20, 20);
            this.pnlStats.Size = new Size(940, 120);
            this.pnlStats.BorderStyle = BorderStyle.None;

            // Stat cards
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new Font("Segoe UI", 10);
            this.lblTotalProducts.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblTotalProducts.Text = "Total Produk";
            this.lblTotalProducts.Location = new Point(30, 20);

            this.lblTotalProductsValue.AutoSize = true;
            this.lblTotalProductsValue.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblTotalProductsValue.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblTotalProductsValue.Text = "0";
            this.lblTotalProductsValue.Location = new Point(30, 45);

            this.lblTotalTransactions.AutoSize = true;
            this.lblTotalTransactions.Font = new Font("Segoe UI", 10);
            this.lblTotalTransactions.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblTotalTransactions.Text = "Total Transaksi";
            this.lblTotalTransactions.Location = new Point(350, 20);

            this.lblTotalTransactionsValue.AutoSize = true;
            this.lblTotalTransactionsValue.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblTotalTransactionsValue.ForeColor = Color.FromArgb(59, 130, 246);
            this.lblTotalTransactionsValue.Text = "0";
            this.lblTotalTransactionsValue.Location = new Point(350, 45);

            this.lblRevenueToday.AutoSize = true;
            this.lblRevenueToday.Font = new Font("Segoe UI", 10);
            this.lblRevenueToday.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblRevenueToday.Text = "Pendapatan Hari Ini";
            this.lblRevenueToday.Location = new Point(670, 20);

            this.lblRevenueTodayValue.AutoSize = true;
            this.lblRevenueTodayValue.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblRevenueTodayValue.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblRevenueTodayValue.Text = "Rp 0";
            this.lblRevenueTodayValue.Location = new Point(670, 45);

            this.pnlStats.Controls.Add(this.lblTotalProducts);
            this.pnlStats.Controls.Add(this.lblTotalProductsValue);
            this.pnlStats.Controls.Add(this.lblTotalTransactions);
            this.pnlStats.Controls.Add(this.lblTotalTransactionsValue);
            this.pnlStats.Controls.Add(this.lblRevenueToday);
            this.pnlStats.Controls.Add(this.lblRevenueTodayValue);

            // dgvTopProducts
            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToDeleteRows = false;
            this.dgvTopProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProducts.BackgroundColor = Color.White;
            this.dgvTopProducts.BorderStyle = BorderStyle.None;
            this.dgvTopProducts.ColumnHeadersHeight = 40;
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvTopProducts.Location = new Point(20, 160);
            this.dgvTopProducts.Size = new Size(460, 250);
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowTemplate.Height = 35;
            this.dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            // dgvRecentTransactions
            this.dgvRecentTransactions.AllowUserToAddRows = false;
            this.dgvRecentTransactions.AllowUserToDeleteRows = false;
            this.dgvRecentTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentTransactions.BackgroundColor = Color.White;
            this.dgvRecentTransactions.BorderStyle = BorderStyle.None;
            this.dgvRecentTransactions.ColumnHeadersHeight = 40;
            this.dgvRecentTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvRecentTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvRecentTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvRecentTransactions.Location = new Point(500, 160);
            this.dgvRecentTransactions.Size = new Size(460, 250);
            this.dgvRecentTransactions.ReadOnly = true;
            this.dgvRecentTransactions.RowTemplate.Height = 35;
            this.dgvRecentTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            this.dgvRecentTransactions.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvRecentTransactions_CellDoubleClick);

            // btnRefresh
            this.btnRefresh.BackColor = Color.FromArgb(13, 148, 136);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new Point(870, 430);
            this.btnRefresh.Size = new Size(90, 35);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.pnlContent.Controls.Add(this.pnlStats);
            this.pnlContent.Controls.Add(this.dgvTopProducts);
            this.pnlContent.Controls.Add(this.dgvRecentTransactions);
            this.pnlContent.Controls.Add(this.btnRefresh);

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSidebar);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvTopProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecentTransactions).EndInit();
            this.ResumeLayout(false);
        }
    }
}
