using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using benshop.Helpers;

namespace benshop.Forms.Seller
{
    public partial class FrmSellerDashboard : Form
    {
        public FrmSellerDashboard()
        {
            InitializeComponent();
            pnlContent.Resize += (sender, args) => ArrangeDashboard();
            ArrangeDashboard();
            LoadStats();
            LoadTopProducts();
            LoadRecentTransactions();
        }

        private void ArrangeDashboard()
        {
            int padding = 20;
            int gap = 16;
            int statsHeight = 96;
            int refreshHeight = 35;
            int contentWidth = pnlContent.ClientSize.Width - (padding * 2);
            int contentHeight = pnlContent.ClientSize.Height - (padding * 2);

            if (contentWidth <= 0 || contentHeight <= 0)
                return;

            pnlStats.Location = new Point(padding, padding);
            pnlStats.Size = new Size(contentWidth, statsHeight);

            int statColumnWidth = contentWidth / 3;
            PositionStat(lblTotalProducts, lblTotalProductsValue, 24, statColumnWidth);
            PositionStat(lblTotalTransactions, lblTotalTransactionsValue, 24 + statColumnWidth, statColumnWidth);
            PositionStat(lblRevenueToday, lblRevenueTodayValue, 24 + (statColumnWidth * 2), statColumnWidth);

            int tablesTop = pnlStats.Bottom + gap;
            int refreshTop = pnlContent.ClientSize.Height - padding - refreshHeight;
            int tableHeight = Math.Max(220, refreshTop - gap - tablesTop);
            int tableWidth = (contentWidth - gap) / 2;

            dgvTopProducts.Location = new Point(padding, tablesTop);
            dgvTopProducts.Size = new Size(tableWidth, tableHeight);

            dgvRecentTransactions.Location = new Point(padding + tableWidth + gap, tablesTop);
            dgvRecentTransactions.Size = new Size(contentWidth - tableWidth - gap, tableHeight);

            btnRefresh.Location = new Point(padding + contentWidth - btnRefresh.Width, refreshTop);
        }

        private static void PositionStat(Label title, Label value, int left, int width)
        {
            title.Location = new Point(left, 14);
            title.MaximumSize = new Size(width - 32, 0);
            value.Location = new Point(left, 38);
            value.MaximumSize = new Size(width - 32, 0);
        }

        private void LoadStats()
        {
            try
            {
                DataTable dt = BLL.ReportBLL.GetDashboardStats();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblTotalProductsValue.Text = row["TotalProducts"].ToString();
                    lblTotalTransactionsValue.Text = row["TotalTransactions"].ToString();
                    lblRevenueTodayValue.Text = FormatHelper.ToRupiah(Convert.ToDecimal(row["RevenueToday"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat statistik: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTopProducts()
        {
            try
            {
                DataTable dt = BLL.ReportBLL.GetTopProducts(5);
                dgvTopProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat produk terlaris: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentTransactions()
        {
            try
            {
                DataTable dt = BLL.ReportBLL.GetRecentTransactions(10);
                dgvRecentTransactions.DataSource = dt;
                if (dgvRecentTransactions.Columns["TransactionID"] != null)
                    dgvRecentTransactions.Columns["TransactionID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat transaksi terbaru: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRecentTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvRecentTransactions.Rows[e.RowIndex].Cells["TransactionID"].Value == null)
                return;

            int transactionId = Convert.ToInt32(dgvRecentTransactions.Rows[e.RowIndex].Cells["TransactionID"].Value);
            string currentStatus = dgvRecentTransactions.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            string newStatus = PromptForStatus(currentStatus);

            if (string.IsNullOrEmpty(newStatus) || newStatus == currentStatus)
                return;

            try
            {
                DAL.TransactionDAL.UpdateTransactionStatus(transactionId, newStatus);
                LoadStats();
                LoadTopProducts();
                LoadRecentTransactions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal mengubah status transaksi: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string PromptForStatus(string currentStatus)
        {
            using (Form dialog = new Form())
            using (ComboBox cboStatus = new ComboBox())
            using (Button btnOk = new Button())
            using (Button btnCancel = new Button())
            using (Label lblStatus = new Label())
            {
                dialog.Text = "Ubah Status Transaksi";
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.ClientSize = new Size(320, 145);
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                lblStatus.Text = "Status";
                lblStatus.Location = new Point(20, 18);
                lblStatus.AutoSize = true;

                cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                cboStatus.Items.AddRange(new object[] { "Diproses", "Dikirim", "Selesai", "Dibatalkan" });
                cboStatus.Location = new Point(20, 44);
                cboStatus.Size = new Size(280, 30);
                cboStatus.SelectedItem = currentStatus;
                if (cboStatus.SelectedIndex < 0)
                    cboStatus.SelectedIndex = 0;

                btnOk.Text = "Simpan";
                btnOk.DialogResult = DialogResult.OK;
                btnOk.Location = new Point(120, 95);
                btnOk.Size = new Size(85, 32);

                btnCancel.Text = "Batal";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(215, 95);
                btnCancel.Size = new Size(85, 32);

                dialog.Controls.Add(lblStatus);
                dialog.Controls.Add(cboStatus);
                dialog.Controls.Add(btnOk);
                dialog.Controls.Add(btnCancel);
                dialog.AcceptButton = btnOk;
                dialog.CancelButton = btnCancel;

                return dialog.ShowDialog() == DialogResult.OK ? cboStatus.SelectedItem.ToString() : null;
            }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            using (var products = new FrmProducts())
            {
                products.ShowDialog();
                LoadStats();
            }
        }

        private void btnPromo_Click(object sender, EventArgs e)
        {
            using (var promo = new FrmPromo())
            {
                promo.ShowDialog();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            using (var report = new FrmSellerReport())
            {
                report.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStats();
            LoadTopProducts();
            LoadRecentTransactions();
        }
    }
}
