using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using benshop.Helpers;

namespace benshop.Forms.Buyer
{
    public partial class FrmBuyerDashboard : Form
    {
        private DataView _productView;

        public FrmBuyerDashboard()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
        }

        private void LoadCategories()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Semua Kategori");
            try
            {
                DataTable catDt = BLL.ProductBLL.GetCategories();
                foreach (DataRow row in catDt.Rows)
                    cboCategory.Items.Add(row["Category"].ToString());
            }
            catch { }
            cboCategory.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            try
            {
                DataTable dt = BLL.ProductBLL.GetAllProducts();
                _productView = dt.DefaultView;
                dgvProducts.DataSource = _productView;
                ConfigureColumns();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat produk: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            if (dgvProducts.Columns["colAddToCart"] != null)
                return;

            dgvProducts.Columns["ProductID"].Visible = false;
            dgvProducts.Columns["ImagePath"].Visible = false;
            dgvProducts.Columns["IsActive"].Visible = false;
            dgvProducts.Columns["CreatedAt"].Visible = false;

            dgvProducts.Columns["Name"].HeaderText = "Nama Produk";
            dgvProducts.Columns["Price"].HeaderText = "Harga";
            dgvProducts.Columns["Stock"].HeaderText = "Stok";

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.Name = "colAddToCart";
            btnCol.HeaderText = "";
            btnCol.Text = "+ Keranjang";
            btnCol.UseColumnTextForButtonValue = true;
            btnCol.FlatStyle = FlatStyle.Flat;
            btnCol.DefaultCellStyle.BackColor = Color.FromArgb(13, 148, 136);
            btnCol.DefaultCellStyle.ForeColor = Color.White;
            btnCol.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvProducts.Columns.Add(btnCol);
        }

        private void ApplyFilter()
        {
            if (_productView == null) return;

            string search = txtSearch.Text.Trim().ToLower();
            string category = cboCategory.SelectedItem != null ? cboCategory.SelectedItem.ToString() : null;

            string filter = "IsActive = 1";

            if (!string.IsNullOrWhiteSpace(search))
                filter += string.Format(" AND Name LIKE '%{0}%'", search.Replace("'", "''"));

            if (!string.IsNullOrEmpty(category) && category != "Semua Kategori")
                filter += string.Format(" AND Category = '{0}'", category.Replace("'", "''"));

            _productView.RowFilter = filter;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvProducts.Columns["colAddToCart"].Index)
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value);
                string name = dgvProducts.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                decimal price = Convert.ToDecimal(dgvProducts.Rows[e.RowIndex].Cells["Price"].Value);
                int stock = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Stock"].Value);

                if (stock <= 0)
                {
                    MessageBox.Show("Stok produk habis!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var qtyForm = new FrmQtySelector(name, stock))
                {
                    if (qtyForm.ShowDialog() == DialogResult.OK)
                    {
                        BLL.CartBLL.AddItem(productId, name, price, qtyForm.Quantity, stock);
                        MessageBox.Show(string.Format("{0} ({1} pcs) ditambahkan ke keranjang!", name, qtyForm.Quantity), "Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvProducts.Columns[e.ColumnIndex].Name == "colAddToCart")
            {
                e.CellStyle.BackColor = Color.FromArgb(13, 148, 136);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                e.CellStyle.SelectionBackColor = Color.FromArgb(13, 148, 136);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            using (var cart = new FrmCart())
            {
                cart.ShowDialog();
                LoadProducts();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            using (var history = new FrmBuyerHistory())
            {
                history.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            Close();
        }
    }
}
