using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Buyer
{
    partial class FrmTransactionDetail
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Label lblTitle;
        private Label lblTransNo;
        private DataGridView dgvDetails;
        private Label lblTotal;
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
            this.lblTitle = new Label();
            this.lblTransNo = new Label();
            this.dgvDetails = new DataGridView();
            this.lblTotal = new Label();
            this.btnClose = new Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvDetails).BeginInit();
            this.SuspendLayout();

            this.ClientSize = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Detail Transaksi";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(700, 80);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Detail Transaksi";
            this.lblTitle.Location = new Point(20, 10);

            this.lblTransNo.AutoSize = true;
            this.lblTransNo.Font = new Font("Segoe UI", 10);
            this.lblTransNo.ForeColor = Color.FromArgb(148, 163, 184);
            this.lblTransNo.Text = "No. Transaksi:";
            this.lblTransNo.Location = new Point(20, 45);

            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblTransNo);

            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = Color.White;
            this.dgvDetails.BorderStyle = BorderStyle.None;
            this.dgvDetails.ColumnHeadersHeight = 40;
            this.dgvDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvDetails.Location = new Point(20, 100);
            this.dgvDetails.Size = new Size(660, 250);
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowTemplate.Height = 35;
            this.dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblTotal.Location = new Point(20, 365);
            this.lblTotal.Text = "Total: Rp 0";

            this.btnClose.BackColor = Color.FromArgb(226, 232, 240);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 11);
            this.btnClose.Text = "Tutup";
            this.btnClose.Location = new Point(560, 390);
            this.btnClose.Size = new Size(120, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnClose);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvDetails).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
