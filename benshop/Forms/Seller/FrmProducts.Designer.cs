using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Seller
{
    partial class FrmProducts
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Panel pnlForm;
        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private TextBox txtCategory;
        private Label lblPrice;
        private NumericUpDown nudPrice;
        private Label lblStock;
        private NumericUpDown nudStock;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClose;
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
            this.pnlForm = new Panel();
            this.lblTitle = new Label();
            this.lblName = new Label();
            this.txtName = new TextBox();
            this.lblCategory = new Label();
            this.txtCategory = new TextBox();
            this.lblPrice = new Label();
            this.nudPrice = new NumericUpDown();
            this.lblStock = new Label();
            this.nudStock = new NumericUpDown();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnClose = new Button();
            this.dgvProducts = new DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).BeginInit();
            this.SuspendLayout();

            this.ClientSize = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Benshop - Manajemen Produk";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(1000, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Manajemen Produk";
            this.lblTitle.Location = new Point(20, 12);
            this.pnlTop.Controls.Add(this.lblTitle);

            // dgvProducts
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = Color.White;
            this.dgvProducts.BorderStyle = BorderStyle.None;
            this.dgvProducts.ColumnHeadersHeight = 40;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvProducts.Location = new Point(20, 80);
            this.dgvProducts.Size = new Size(960, 300);
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 35;
            this.dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);

            // Form fields
            this.pnlForm.BackColor = Color.White;
            this.pnlForm.Location = new Point(20, 400);
            this.pnlForm.Size = new Size(960, 200);
            this.pnlForm.Padding = new Padding(20);

            this.lblName.AutoSize = true;
            this.lblName.Font = new Font("Segoe UI", 10);
            this.lblName.Text = "Nama Produk";
            this.lblName.Location = new Point(20, 15);

            this.txtName.Font = new Font("Segoe UI", 11);
            this.txtName.Location = new Point(20, 38);
            this.txtName.Size = new Size(250, 30);
            this.txtName.BorderStyle = BorderStyle.FixedSingle;

            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new Font("Segoe UI", 10);
            this.lblCategory.Text = "Kategori";
            this.lblCategory.Location = new Point(290, 15);

            this.txtCategory.Font = new Font("Segoe UI", 11);
            this.txtCategory.Location = new Point(290, 38);
            this.txtCategory.Size = new Size(200, 30);
            this.txtCategory.BorderStyle = BorderStyle.FixedSingle;

            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new Font("Segoe UI", 10);
            this.lblPrice.Text = "Harga";
            this.lblPrice.Location = new Point(510, 15);

            this.nudPrice.Font = new Font("Segoe UI", 11);
            this.nudPrice.Location = new Point(510, 38);
            this.nudPrice.Size = new Size(150, 30);
            this.nudPrice.Maximum = 999999999;
            this.nudPrice.DecimalPlaces = 2;

            this.lblStock.AutoSize = true;
            this.lblStock.Font = new Font("Segoe UI", 10);
            this.lblStock.Text = "Stok";
            this.lblStock.Location = new Point(680, 15);

            this.nudStock.Font = new Font("Segoe UI", 11);
            this.nudStock.Location = new Point(680, 38);
            this.nudStock.Size = new Size(100, 30);
            this.nudStock.Maximum = 99999;

            this.btnAdd.BackColor = Color.FromArgb(13, 148, 136);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.Location = new Point(20, 90);
            this.btnAdd.Size = new Size(120, 40);
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BackColor = Color.FromArgb(59, 130, 246);
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new Point(150, 90);
            this.btnEdit.Size = new Size(120, 40);
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Text = "Hapus";
            this.btnDelete.Location = new Point(280, 90);
            this.btnDelete.Size = new Size(120, 40);
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClose.BackColor = Color.FromArgb(226, 232, 240);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 11);
            this.btnClose.Text = "Tutup";
            this.btnClose.Location = new Point(830, 90);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.lblCategory);
            this.pnlForm.Controls.Add(this.txtCategory);
            this.pnlForm.Controls.Add(this.lblPrice);
            this.pnlForm.Controls.Add(this.nudPrice);
            this.pnlForm.Controls.Add(this.lblStock);
            this.pnlForm.Controls.Add(this.nudStock);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.btnEdit);
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnClose);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.pnlForm);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvProducts).EndInit();
            this.ResumeLayout(false);
        }
    }
}
