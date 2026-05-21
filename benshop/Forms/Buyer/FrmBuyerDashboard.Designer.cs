using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Buyer
{
    partial class FrmBuyerDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Panel pnlSidebar;
        private Panel pnlContent;
        private Label lblAppName;
        private Button btnLogout;
        private Button btnCart;
        private Button btnHistory;
        private Label lblSearch;
        private TextBox txtSearch;
        private ComboBox cboCategory;
        private DataGridView dgvProducts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.pnlSidebar = new Panel();
            this.pnlContent = new Panel();
            this.lblAppName = new Label();
            this.btnLogout = new Button();
            this.btnCart = new Button();
            this.btnHistory = new Button();
            this.txtSearch = new TextBox();
            this.lblSearch = new Label();
            this.cboCategory = new ComboBox();
            this.dgvProducts = new DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
            this.SuspendLayout();

            // FrmBuyerDashboard
            this.ClientSize = new Size(1200, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Benshop - Buyer Dashboard";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.WindowState = FormWindowState.Maximized;

            // pnlSidebar
            this.pnlSidebar.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlSidebar.Dock = DockStyle.Left;
            this.pnlSidebar.Size = new Size(220, 750);
            this.pnlSidebar.Padding = new Padding(0, 20, 0, 0);

            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            this.lblAppName.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblAppName.Text = "Benshop";
            this.lblAppName.Location = new Point(50, 30);

            this.btnCart.BackColor = Color.Transparent;
            this.btnCart.FlatStyle = FlatStyle.Flat;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            this.btnCart.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnCart.Text = "   Cart";
            this.btnCart.TextAlign = ContentAlignment.MiddleLeft;
            this.btnCart.Location = new Point(20, 120);
            this.btnCart.Size = new Size(180, 50);
            this.btnCart.Cursor = Cursors.Hand;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);

            this.btnHistory.BackColor = Color.Transparent;
            this.btnHistory.FlatStyle = FlatStyle.Flat;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            this.btnHistory.ForeColor = Color.FromArgb(148, 163, 184);
            this.btnHistory.Text = "   History";
            this.btnHistory.TextAlign = ContentAlignment.MiddleLeft;
            this.btnHistory.Location = new Point(20, 180);
            this.btnHistory.Size = new Size(180, 50);
            this.btnHistory.Cursor = Cursors.Hand;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);

            this.btnLogout.BackColor = Color.Transparent;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            this.btnLogout.ForeColor = Color.FromArgb(239, 68, 68);
            this.btnLogout.Text = "   Logout";
            this.btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new Point(20, 600);
            this.btnLogout.Size = new Size(180, 50);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Controls.Add(this.btnCart);
            this.pnlSidebar.Controls.Add(this.btnHistory);
            this.pnlSidebar.Controls.Add(this.btnLogout);

            // pnlTop - Search bar
            this.pnlTop.BackColor = Color.White;
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(980, 80);
            this.pnlTop.Padding = new Padding(20, 20, 20, 20);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new Font("Segoe UI", 12F);
            this.lblSearch.ForeColor = Color.FromArgb(100, 116, 139);
            this.lblSearch.Text = "Search";
            this.lblSearch.Location = new Point(30, 26);

            this.txtSearch.Font = new Font("Segoe UI", 12);
            this.txtSearch.Location = new Point(100, 22);
            this.txtSearch.Size = new Size(280, 35);
            this.txtSearch.BackColor = Color.FromArgb(248, 250, 252);
            this.txtSearch.BorderStyle = BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new Font("Segoe UI", 12);
            this.cboCategory.Location = new Point(400, 22);
            this.cboCategory.Size = new Size(180, 35);
            this.cboCategory.BackColor = Color.FromArgb(248, 250, 252);
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);

            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.cboCategory);

            // pnlContent
            this.pnlContent.BackColor = Color.FromArgb(248, 250, 252);
            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.Padding = new Padding(20);

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoGenerateColumns = true;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = Color.White;
            this.dgvProducts.BorderStyle = BorderStyle.None;
            this.dgvProducts.ColumnHeadersHeight = 45;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvProducts.Location = new Point(20, 100);
            this.dgvProducts.Size = new Size(940, 600);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellClick += new DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvProducts_CellFormatting);
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 40;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            this.pnlContent.Controls.Add(this.dgvProducts);

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSidebar);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
            this.ResumeLayout(false);
        }
    }
}
