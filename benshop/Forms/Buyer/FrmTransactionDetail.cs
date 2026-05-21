using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using benshop.Helpers;

namespace benshop.Forms.Buyer
{
    public partial class FrmTransactionDetail : Form
    {
        private int _transactionId;
        private string _transactionNo;

        public FrmTransactionDetail(int transactionId, string transactionNo)
        {
            InitializeComponent();
            _transactionId = transactionId;
            _transactionNo = transactionNo;
            lblTransNo.Text = string.Format("No. Transaksi: {0}", _transactionNo);
            LoadDetails();
        }

        private void LoadDetails()
        {
            try
            {
                DataTable dt = DAL.TransactionDAL.GetTransactionDetails(_transactionId);
                dgvDetails.DataSource = dt;
                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                    total += Convert.ToDecimal(row["Subtotal"]);
                lblTotal.Text = string.Format("Total: {0}", FormatHelper.ToRupiah(total));
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat detail: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
