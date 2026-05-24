using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Seller
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
            ApplyModernTheme();
            Resize += (sender, args) => ArrangeProductForm();
            ArrangeProductForm();
            LoadProducts();
        }

        private void ApplyModernTheme()
        {
            Helpers.UiHelper.ApplyForm(this, new Size(1000, 650));
            Helpers.UiHelper.ApplyHeader(pnlTop, lblTitle, "Manajemen Produk");
            Helpers.UiHelper.ApplyGrid(dgvProducts);
            Helpers.UiHelper.ApplySection(pnlForm);

            foreach (Control control in new Control[] { txtName, txtCategory, nudPrice, nudStock })
                Helpers.UiHelper.ApplyInput(control);

            Helpers.UiHelper.ApplyButton(btnAdd, Helpers.ButtonKind.Primary);
            Helpers.UiHelper.ApplyButton(btnEdit, Helpers.ButtonKind.Info);
            Helpers.UiHelper.ApplyButton(btnDelete, Helpers.ButtonKind.Danger);
            Helpers.UiHelper.ApplyButton(btnClose, Helpers.ButtonKind.Secondary);
        }

        private void ArrangeProductForm()
        {
            int padding = 24;
            int width = ClientSize.Width - (padding * 2);
            int top = pnlTop.Bottom + 20;

            dgvProducts.Location = new Point(padding, top);
            dgvProducts.Size = new Size(width, Math.Max(260, ClientSize.Height - top - 260));

            pnlForm.Location = new Point(padding, dgvProducts.Bottom + 18);
            pnlForm.Size = new Size(width, 190);

            btnClose.Location = new Point(pnlForm.Width - 130, 90);
        }

        private void LoadProducts()
        {
            try
            {
                DataTable dt = BLL.ProductBLL.GetAllProducts();
                dgvProducts.DataSource = dt;
                if (dgvProducts.Columns["ProductID"] != null)
                    dgvProducts.Columns["ProductID"].Visible = false;
                if (dgvProducts.Columns["ImagePath"] != null)
                    dgvProducts.Columns["ImagePath"].Visible = false;
                if (dgvProducts.Columns["CreatedAt"] != null)
                    dgvProducts.Columns["CreatedAt"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat produk: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtCategory.Clear();
            nudPrice.Value = 0;
            nudStock.Value = 0;
            txtName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string category = txtCategory.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Nama dan kategori harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (BLL.ProductBLL.IsProductNameExists(name))
            {
                MessageBox.Show("Nama produk sudah ada!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BLL.ProductBLL.AddProduct(name, category, nudPrice.Value, (int)nudStock.Value);
                MessageBox.Show("Produk berhasil ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal menambah produk: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);
            string name = txtName.Text.Trim();
            string category = txtCategory.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Nama dan kategori harus diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (BLL.ProductBLL.IsProductNameExistsExcludeId(name, productId))
            {
                MessageBox.Show("Nama produk sudah digunakan produk lain!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                BLL.ProductBLL.UpdateProduct(productId, name, category, nudPrice.Value, (int)nudStock.Value);
                MessageBox.Show("Produk berhasil diupdate!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal mengupdate produk: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);
            string name = dgvProducts.CurrentRow.Cells["Name"].Value.ToString();

            var result = MessageBox.Show(string.Format("Nonaktifkan produk '{0}'?", name), "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    BLL.ProductBLL.DeleteProduct(productId);
                    MessageBox.Show("Produk berhasil dinonaktifkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Gagal menonaktifkan produk: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            var row = dgvProducts.CurrentRow;
            txtName.Text = row.Cells["Name"].Value != null ? row.Cells["Name"].Value.ToString() : "";
            txtCategory.Text = row.Cells["Category"].Value != null ? row.Cells["Category"].Value.ToString() : "";
            nudPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
            nudStock.Value = Convert.ToInt32(row.Cells["Stock"].Value ?? 0);
        }
    }
}
