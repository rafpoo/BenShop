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
            ApplyModernTheme();
            Resize += (sender, args) => ArrangeDetail();
            _transactionId = transactionId;
            _transactionNo = transactionNo;
            lblTransNo.Text = string.Format("No. Transaksi: {0}", _transactionNo);
            ArrangeDetail();
            LoadDetails();
        }

        private void ApplyModernTheme()
        {
            UiHelper.ApplyForm(this, new Size(700, 450));
            UiHelper.ApplyHeader(pnlTop, lblTitle, "Detail Transaksi");
            lblTransNo.Font = UiHelper.Font(10);
            lblTransNo.ForeColor = Color.FromArgb(203, 213, 225);
            UiHelper.ApplyGrid(dgvDetails);
            UiHelper.ApplyButton(btnClose, ButtonKind.Secondary);
            lblTotal.Font = UiHelper.Font(16, FontStyle.Bold);
            lblTotal.ForeColor = UiHelper.Teal;
        }

        private void ArrangeDetail()
        {
            int padding = 24;
            dgvDetails.Location = new Point(padding, pnlTop.Bottom + 20);
            dgvDetails.Size = new Size(ClientSize.Width - (padding * 2), ClientSize.Height - pnlTop.Height - 114);
            lblTotal.Location = new Point(padding, dgvDetails.Bottom + 18);
            btnClose.Location = new Point(ClientSize.Width - padding - btnClose.Width, ClientSize.Height - 52);
        }

        private void LoadDetails()
        {
            try
            {
                DataTable dt = DAL.TransactionDAL.GetTransactionDetails(_transactionId);
                dgvDetails.DataSource = dt;
                if (dgvDetails.Columns["DetailID"] != null)
                    dgvDetails.Columns["DetailID"].Visible = false;
                if (dgvDetails.Columns["TransactionID"] != null)
                    dgvDetails.Columns["TransactionID"].Visible = false;
                if (dgvDetails.Columns["ProductID"] != null)
                    dgvDetails.Columns["ProductID"].Visible = false;
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
