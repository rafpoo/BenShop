using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Buyer
{
    partial class FrmBuyerHistory
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Label lblTitle;
        private ComboBox cboStatus;
        private DataGridView dgvHistory;
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
            this.cboStatus = new ComboBox();
            this.dgvHistory = new DataGridView();
            this.btnClose = new Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvHistory).BeginInit();
            this.SuspendLayout();

            // FrmBuyerHistory
            this.ClientSize = new Size(900, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Benshop - Riwayat Transaksi";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // pnlTop
            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(900, 60);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Riwayat Transaksi";
            this.lblTitle.Location = new Point(20, 12);

            this.pnlTop.Controls.Add(this.lblTitle);

            // cboStatus
            this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new Font("Segoe UI", 11);
            this.cboStatus.Items.AddRange(new object[] { "Semua", "Diproses", "Dikirim", "Selesai", "Dibatalkan" });
            this.cboStatus.Location = new Point(20, 80);
            this.cboStatus.Size = new Size(200, 30);
            this.cboStatus.SelectedIndex = 0;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);

            // dgvHistory
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = Color.White;
            this.dgvHistory.BorderStyle = BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeight = 40;
            this.dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvHistory.Location = new Point(20, 120);
            this.dgvHistory.Size = new Size(860, 350);
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowTemplate.Height = 35;
            this.dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            this.dgvHistory.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvHistory_CellDoubleClick);

            // btnClose
            this.btnClose.BackColor = Color.FromArgb(226, 232, 240);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            this.btnClose.Text = "Tutup";
            this.btnClose.Location = new Point(780, 490);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.btnClose);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvHistory).EndInit();
            this.ResumeLayout(false);
        }
    }
}
