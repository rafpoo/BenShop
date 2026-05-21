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
            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                string statusFilter = cboStatus.SelectedItem != null ? cboStatus.SelectedItem.ToString() : null;
                DataTable dt = DAL.TransactionDAL.GetBuyerTransactions(
                    SessionManager.CurrentUser.UserID, statusFilter);
                dgvHistory.DataSource = dt;
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

            int transactionId = Convert.ToInt32(dgvHistory.Rows[e.RowIndex].Cells["colTransactionID"].Value);
            string transNo = dgvHistory.Rows[e.RowIndex].Cells["colTransactionNo"].Value.ToString();

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
