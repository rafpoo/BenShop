using System;
using System.Drawing;
using System.Windows.Forms;
using benshop.Helpers;

namespace benshop.Forms.Buyer
{
    public partial class FrmCheckout : Form
    {
        public FrmCheckout()
        {
            InitializeComponent();
            LoadSummary();
        }

        private void LoadSummary()
        {
            var items = BLL.CartBLL.GetItems();
            decimal subtotal = BLL.CartBLL.GetTotal();
            decimal discount = BLL.CartBLL.GetDiscount();
            decimal total = subtotal - discount;

            lblSubtotal.Text = FormatHelper.ToRupiah(subtotal);
            lblDiscount.Text = FormatHelper.ToRupiah(discount);
            lblTotal.Text = FormatHelper.ToRupiah(total);
        }

        private void btnApplyPromo_Click(object sender, EventArgs e)
        {
            string code = txtPromo.Text.Trim();
            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Masukkan kode promo!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool valid = BLL.CheckoutBLL.ValidatePromo(code);
                if (valid)
                {
                    BLL.CartBLL.ApplyPromo(code);
                    MessageBox.Show("Promo berhasil diterapkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSummary();
                }
                else
                {
                    MessageBox.Show("Kode promo tidak valid atau sudah kadaluarsa!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string recipient = txtRecipient.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string payment = cboPayment.SelectedItem != null ? cboPayment.SelectedItem.ToString() : null;

            if (string.IsNullOrWhiteSpace(recipient) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(address) || string.IsNullOrEmpty(payment))
            {
                MessageBox.Show("Semua field harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string transNo = BLL.CheckoutBLL.CreateTransaction(recipient, phone, address, payment);
                MessageBox.Show(string.Format("Transaksi berhasil!\nNo. Transaksi: {0}", transNo), "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memproses checkout: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
