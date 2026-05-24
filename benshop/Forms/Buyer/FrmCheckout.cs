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
            ApplyModernTheme();
            LoadSummary();
        }

        private void ApplyModernTheme()
        {
            UiHelper.ApplyForm(this, new Size(700, 620));
            UiHelper.ApplyHeader(pnlTop, lblTitle, "Checkout Pesanan");

            foreach (Control control in new Control[] { txtRecipient, txtPhone, txtAddress, cboPayment, txtPromo })
                UiHelper.ApplyInput(control);

            foreach (Label label in new Label[] { lblRecipient, lblPhone, lblAddress, lblPayment, lblPromo })
            {
                label.Font = UiHelper.Font(10, FontStyle.Bold);
                label.ForeColor = UiHelper.Text;
            }

            UiHelper.ApplyButton(btnApplyPromo, ButtonKind.Info);
            UiHelper.ApplyButton(btnConfirm, ButtonKind.Primary);
            UiHelper.ApplyButton(btnCancel, ButtonKind.Secondary);
            btnApplyPromo.Text = "Terapkan";
            btnConfirm.Text = "Konfirmasi Pesanan";

            foreach (Label label in new Label[] { lblSubtotal, lblDiscount, lblTotal })
            {
                label.ForeColor = UiHelper.Text;
                label.TextAlign = ContentAlignment.MiddleLeft;
            }
            foreach (Label label in new Label[] { lblSubtotalValue, lblDiscountValue, lblTotalValue })
                label.TextAlign = ContentAlignment.MiddleRight;
        }

        private void LoadSummary()
        {
            var items = BLL.CartBLL.GetItems();
            decimal subtotal = BLL.CartBLL.GetTotal();
            decimal discount = BLL.CartBLL.GetDiscount();
            decimal total = subtotal - discount;

            lblSubtotalValue.Text = FormatHelper.ToRupiah(subtotal);
            lblDiscountValue.Text = FormatHelper.ToRupiah(discount);
            lblTotalValue.Text = FormatHelper.ToRupiah(total);
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
