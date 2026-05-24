using System;
using System.Drawing;
using System.Windows.Forms;
using benshop.Helpers;

namespace benshop.Forms.Buyer
{
    public partial class FrmCart : Form
    {
        public FrmCart()
        {
            InitializeComponent();
            ApplyModernTheme();
            Resize += (sender, args) => ArrangeCart();
            ArrangeCart();
            LoadCart();
        }

        private void ApplyModernTheme()
        {
            UiHelper.ApplyForm(this, new Size(800, 550));
            UiHelper.ApplyHeader(pnlTop, lblTitle, "Keranjang Belanja");
            UiHelper.ApplyGrid(dgvCart);
            pnlBottom.BackColor = Color.White;
            UiHelper.ApplyButton(btnIncrease, ButtonKind.Secondary);
            UiHelper.ApplyButton(btnDecrease, ButtonKind.Secondary);
            UiHelper.ApplyButton(btnRemove, ButtonKind.Danger);
            UiHelper.ApplyButton(btnClose, ButtonKind.Secondary);
            UiHelper.ApplyButton(btnCheckout, ButtonKind.Primary);
            lblTotal.Font = UiHelper.Font(18, FontStyle.Bold);
            lblTotal.ForeColor = UiHelper.Teal;
        }

        private void ArrangeCart()
        {
            int padding = 24;
            dgvCart.Location = new Point(padding, pnlTop.Bottom + 20);
            dgvCart.Size = new Size(ClientSize.Width - (padding * 2), ClientSize.Height - pnlTop.Height - pnlBottom.Height - 44);
            btnCheckout.Location = new Point(pnlBottom.Width - 220, 58);
            btnClose.Location = new Point(btnCheckout.Left - 100, 58);
        }

        private void LoadCart()
        {
            var items = BLL.CartBLL.GetItems();
            dgvCart.DataSource = null;
            dgvCart.DataSource = items;
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = BLL.CartBLL.GetTotal();
            lblTotal.Text = string.Format("Total: {0}", FormatHelper.ToRupiah(total));
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            var item = (Models.CartItem)dgvCart.CurrentRow.DataBoundItem;
            if (item.Quantity < item.MaxStock)
            {
                BLL.CartBLL.UpdateQuantity(item.ProductID, item.Quantity + 1);
                LoadCart();
            }
            else
            {
                MessageBox.Show("Stok tidak mencukupi!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            var item = (Models.CartItem)dgvCart.CurrentRow.DataBoundItem;
            if (item.Quantity > 1)
            {
                BLL.CartBLL.UpdateQuantity(item.ProductID, item.Quantity - 1);
                LoadCart();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null) return;
            var item = (Models.CartItem)dgvCart.CurrentRow.DataBoundItem;
            BLL.CartBLL.RemoveItem(item.ProductID);
            LoadCart();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (BLL.CartBLL.GetItems().Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var checkout = new FrmCheckout())
            {
                if (checkout.ShowDialog() == DialogResult.OK)
                {
                    BLL.CartBLL.Clear();
                    LoadCart();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
