using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Buyer
{
    partial class FrmCart
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Panel pnlBottom;
        private Label lblTitle;
        private DataGridView dgvCart;
        private Label lblTotal;
        private Button btnIncrease;
        private Button btnDecrease;
        private Button btnRemove;
        private Button btnCheckout;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new Panel();
            this.pnlBottom = new Panel();
            this.lblTitle = new Label();
            this.dgvCart = new DataGridView();
            this.lblTotal = new Label();
            this.btnIncrease = new Button();
            this.btnDecrease = new Button();
            this.btnRemove = new Button();
            this.btnCheckout = new Button();
            this.btnClose = new Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvCart).BeginInit();
            this.SuspendLayout();

            // FrmCart
            this.ClientSize = new Size(800, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Benshop - Cart";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // pnlTop
            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(800, 60);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Shopping Cart";
            this.lblTitle.Location = new Point(20, 12);

            this.pnlTop.Controls.Add(this.lblTitle);

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.BackgroundColor = Color.White;
            this.dgvCart.BorderStyle = BorderStyle.None;
            this.dgvCart.ColumnHeadersHeight = 40;
            this.dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvCart.Location = new Point(20, 80);
            this.dgvCart.Size = new Size(760, 300);
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowTemplate.Height = 35;
            this.dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            // pnlBottom
            this.pnlBottom.BackColor = Color.White;
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Size = new Size(800, 160);
            this.pnlBottom.Padding = new Padding(20);

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblTotal.Text = "Total: Rp 0";
            this.lblTotal.Location = new Point(30, 20);

            // btnDecrease
            this.btnDecrease.BackColor = Color.FromArgb(226, 232, 240);
            this.btnDecrease.FlatStyle = FlatStyle.Flat;
            this.btnDecrease.FlatAppearance.BorderSize = 0;
            this.btnDecrease.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnDecrease.Text = "-";
            this.btnDecrease.Location = new Point(30, 70);
            this.btnDecrease.Size = new Size(40, 40);
            this.btnDecrease.Cursor = Cursors.Hand;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);

            // btnIncrease
            this.btnIncrease.BackColor = Color.FromArgb(226, 232, 240);
            this.btnIncrease.FlatStyle = FlatStyle.Flat;
            this.btnIncrease.FlatAppearance.BorderSize = 0;
            this.btnIncrease.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnIncrease.Text = "+";
            this.btnIncrease.Location = new Point(80, 70);
            this.btnIncrease.Size = new Size(40, 40);
            this.btnIncrease.Cursor = Cursors.Hand;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);

            // btnRemove
            this.btnRemove.BackColor = Color.FromArgb(239, 68, 68);
            this.btnRemove.FlatStyle = FlatStyle.Flat;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnRemove.ForeColor = Color.White;
            this.btnRemove.Text = "Hapus";
            this.btnRemove.Location = new Point(140, 70);
            this.btnRemove.Size = new Size(100, 40);
            this.btnRemove.Cursor = Cursors.Hand;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // btnCheckout
            this.btnCheckout.BackColor = Color.FromArgb(13, 148, 136);
            this.btnCheckout.FlatStyle = FlatStyle.Flat;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnCheckout.ForeColor = Color.White;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.Location = new Point(580, 60);
            this.btnCheckout.Size = new Size(180, 55);
            this.btnCheckout.Cursor = Cursors.Hand;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // btnClose
            this.btnClose.BackColor = Color.FromArgb(226, 232, 240);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.btnClose.Text = "Tutup";
            this.btnClose.Location = new Point(480, 60);
            this.btnClose.Size = new Size(80, 55);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlBottom.Controls.Add(this.lblTotal);
            this.pnlBottom.Controls.Add(this.btnIncrease);
            this.pnlBottom.Controls.Add(this.btnDecrease);
            this.pnlBottom.Controls.Add(this.btnRemove);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.btnCheckout);

            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvCart).EndInit();
            this.ResumeLayout(false);
        }
    }
}
