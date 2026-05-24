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
        private Label _pageTitle;
        private Label _pageHint;

        public FrmBuyerDashboard()
        {
            InitializeComponent();
            ApplyModernTheme();
            pnlContent.Resize += (sender, args) => ArrangeBuyerDashboard();
            ArrangeBuyerDashboard();
            LoadCategories();
            LoadProducts();
        }

        private void ApplyModernTheme()
        {
            UiHelper.ApplyForm(this, new Size(1100, 700));
            pnlSidebar.BackColor = UiHelper.Navy;
            pnlTop.BackColor = Color.White;
            pnlContent.BackColor = UiHelper.Page;

            lblAppName.Text = "BenShop";
            lblAppName.Font = UiHelper.Font(20, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(28, 28);

            lblGreeting.Text = string.Format("Halo, {0}", GetGreetingName());
            lblGreeting.Font = UiHelper.Font(12, FontStyle.Bold);
            lblGreeting.ForeColor = UiHelper.Text;
            lblGreeting.AutoSize = true;
            pnlTop.Resize += (sender, args) => PositionGreeting(lblGreeting, pnlTop);
            PositionGreeting(lblGreeting, pnlTop);

            UiHelper.ApplySideButton(btnCart);
            UiHelper.ApplySideButton(btnHistory);
            UiHelper.ApplySideButton(btnLogout);
            btnCart.Text = "   Keranjang";
            btnHistory.Text = "   Riwayat";
            btnLogout.Text = "   Keluar";
            btnLogout.ForeColor = Color.FromArgb(252, 165, 165);

            //lblSearch.Text = "Cari produk";
            lblSearch.Font = UiHelper.Font(10, FontStyle.Bold);
            lblSearch.ForeColor = UiHelper.Text;
            UiHelper.ApplyInput(txtSearch);
            UiHelper.ApplyInput(cboCategory);

            UiHelper.ApplyGrid(dgvProducts);

            _pageTitle = UiHelper.SectionTitle("Katalog Produk");
            _pageTitle.Font = UiHelper.Font(18, FontStyle.Bold);
            _pageHint = UiHelper.SectionHint("Cari produk, pilih kategori, lalu tambahkan ke keranjang.");
            pnlContent.Controls.Add(_pageTitle);
            pnlContent.Controls.Add(_pageHint);
        }

        private static string GetGreetingName()
        {
            if (SessionManager.CurrentUser == null)
                return "Pengguna";

            string fullName = SessionManager.CurrentUser.FullName;
            if (string.IsNullOrWhiteSpace(fullName))
                fullName = SessionManager.CurrentUser.Username;

            if (string.IsNullOrWhiteSpace(fullName))
                return "Pengguna";

            return fullName.Trim().Split(' ')[0];
        }

        private static void PositionGreeting(Label label, Panel panel)
        {
            label.Location = new Point(Math.Max(24, panel.ClientSize.Width - label.Width - 28), 28);
        }

        private void ArrangeBuyerDashboard()
        {
            int padding = 24;
            int width = pnlContent.ClientSize.Width - (padding * 2);
            int height = pnlContent.ClientSize.Height - (padding * 2);
            if (width <= 0 || height <= 0) return;

            _pageTitle.Location = new Point(padding, padding);
            _pageHint.Location = new Point(padding, padding + 34);

            dgvProducts.Location = new Point(padding, padding + 82);
            dgvProducts.Size = new Size(width, Math.Max(260, height - 82));
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
                ConfigureProductGrid();
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
            ConfigureProductGrid();
        }

        private void ConfigureProductGrid()
        {
            if (dgvProducts.Columns["ProductID"] != null)
                dgvProducts.Columns["ProductID"].Visible = false;
            if (dgvProducts.Columns["ImagePath"] != null)
                dgvProducts.Columns["ImagePath"].Visible = false;
            if (dgvProducts.Columns["IsActive"] != null)
                dgvProducts.Columns["IsActive"].Visible = false;
            if (dgvProducts.Columns["CreatedAt"] != null)
                dgvProducts.Columns["CreatedAt"].Visible = false;
            if (dgvProducts.Columns["Name"] != null)
                dgvProducts.Columns["Name"].HeaderText = "Nama Produk";
            if (dgvProducts.Columns["Category"] != null)
                dgvProducts.Columns["Category"].HeaderText = "Kategori";
            if (dgvProducts.Columns["Price"] != null)
                dgvProducts.Columns["Price"].HeaderText = "Harga";
            if (dgvProducts.Columns["Stock"] != null)
                dgvProducts.Columns["Stock"].HeaderText = "Stok";
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
