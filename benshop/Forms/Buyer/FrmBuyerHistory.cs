using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using benshop.Helpers;

namespace benshop.Forms.Buyer
{
    public partial class FrmBuyerHistory : Form
    {
        public FrmBuyerHistory()
        {
            InitializeComponent();
            ApplyModernTheme();
            Resize += (sender, args) => ArrangeHistory();
            ArrangeHistory();
            LoadHistory();
        }

        private void ApplyModernTheme()
        {
            UiHelper.ApplyForm(this, new Size(900, 550));
            UiHelper.ApplyHeader(pnlTop, lblTitle, "Riwayat Transaksi");
            UiHelper.ApplyGrid(dgvHistory);
            UiHelper.ApplyInput(cboStatus);
            UiHelper.ApplyButton(btnClose, ButtonKind.Secondary);
        }

        private void ArrangeHistory()
        {
            int padding = 24;
            cboStatus.Location = new Point(padding, pnlTop.Bottom + 20);
            dgvHistory.Location = new Point(padding, cboStatus.Bottom + 16);
            dgvHistory.Size = new Size(ClientSize.Width - (padding * 2), ClientSize.Height - dgvHistory.Top - 76);
            btnClose.Location = new Point(ClientSize.Width - padding - btnClose.Width, ClientSize.Height - 52);
        }

        private void LoadHistory()
        {
            try
            {
                string statusFilter = cboStatus.SelectedItem != null ? cboStatus.SelectedItem.ToString() : null;
                DataTable dt = DAL.TransactionDAL.GetBuyerTransactions(
                    SessionManager.CurrentUser.UserID, statusFilter);
                dgvHistory.DataSource = dt;
                if (dgvHistory.Columns["TransactionID"] != null)
                    dgvHistory.Columns["TransactionID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat riwayat: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHistory();
        }

        private void dgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int transactionId = Convert.ToInt32(dgvHistory.Rows[e.RowIndex].Cells["TransactionID"].Value);
            string transNo = dgvHistory.Rows[e.RowIndex].Cells["TransactionNo"].Value.ToString();

            using (var detail = new FrmTransactionDetail(transactionId, transNo))
            {
                detail.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
