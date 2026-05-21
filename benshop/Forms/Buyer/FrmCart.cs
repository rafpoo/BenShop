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
            LoadCart();
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
