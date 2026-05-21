using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Buyer
{
    partial class FrmCheckout
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Label lblTitle;
        private Label lblRecipient;
        private TextBox txtRecipient;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblPayment;
        private ComboBox cboPayment;
        private Label lblPromo;
        private TextBox txtPromo;
        private Button btnApplyPromo;
        private Label lblSubtotal;
        private Label lblSubtotalValue;
        private Label lblDiscount;
        private Label lblDiscountValue;
        private Label lblTotal;
        private Label lblTotalValue;
        private Button btnConfirm;
        private Button btnCancel;

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
            this.lblRecipient = new Label();
            this.txtRecipient = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.lblPayment = new Label();
            this.cboPayment = new ComboBox();
            this.lblPromo = new Label();
            this.txtPromo = new TextBox();
            this.btnApplyPromo = new Button();
            this.lblSubtotal = new Label();
            this.lblSubtotalValue = new Label();
            this.lblDiscount = new Label();
            this.lblDiscountValue = new Label();
            this.lblTotal = new Label();
            this.lblTotalValue = new Label();
            this.btnConfirm = new Button();
            this.btnCancel = new Button();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // FrmCheckout
            this.ClientSize = new Size(700, 620);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Benshop - Checkout";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // pnlTop
            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(700, 60);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Checkout";
            this.lblTitle.Location = new Point(20, 12);

            this.pnlTop.Controls.Add(this.lblTitle);

            // lblRecipient
            this.lblRecipient.AutoSize = true;
            this.lblRecipient.Font = new Font("Segoe UI", 10);
            this.lblRecipient.Location = new Point(30, 90);
            this.lblRecipient.Text = "Nama Penerima";

            // txtRecipient
            this.txtRecipient.Font = new Font("Segoe UI", 11);
            this.txtRecipient.Location = new Point(30, 112);
            this.txtRecipient.Size = new Size(300, 30);
            this.txtRecipient.BackColor = Color.White;
            this.txtRecipient.BorderStyle = BorderStyle.FixedSingle;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new Font("Segoe UI", 10);
            this.lblPhone.Location = new Point(360, 90);
            this.lblPhone.Text = "No. Telepon";

            // txtPhone
            this.txtPhone.Font = new Font("Segoe UI", 11);
            this.txtPhone.Location = new Point(360, 112);
            this.txtPhone.Size = new Size(300, 30);
            this.txtPhone.BackColor = Color.White;
            this.txtPhone.BorderStyle = BorderStyle.FixedSingle;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new Font("Segoe UI", 10);
            this.lblAddress.Location = new Point(30, 160);
            this.lblAddress.Text = "Alamat Pengiriman";

            // txtAddress
            this.txtAddress.Font = new Font("Segoe UI", 11);
            this.txtAddress.Location = new Point(30, 182);
            this.txtAddress.Size = new Size(630, 30);
            this.txtAddress.BackColor = Color.White;
            this.txtAddress.BorderStyle = BorderStyle.FixedSingle;

            // lblPayment
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new Font("Segoe UI", 10);
            this.lblPayment.Location = new Point(30, 230);
            this.lblPayment.Text = "Metode Pembayaran";

            // cboPayment
            this.cboPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPayment.Font = new Font("Segoe UI", 11);
            this.cboPayment.Items.AddRange(new object[] { "Tunai", "Transfer Bank", "QRIS" });
            this.cboPayment.Location = new Point(30, 252);
            this.cboPayment.Size = new Size(300, 30);
            this.cboPayment.BackColor = Color.White;

            // lblPromo
            this.lblPromo.AutoSize = true;
            this.lblPromo.Font = new Font("Segoe UI", 10);
            this.lblPromo.Location = new Point(30, 300);
            this.lblPromo.Text = "Kode Promo";

            // txtPromo
            this.txtPromo.Font = new Font("Segoe UI", 11);
            this.txtPromo.Location = new Point(30, 322);
            this.txtPromo.Size = new Size(200, 30);
            this.txtPromo.BackColor = Color.White;
            this.txtPromo.BorderStyle = BorderStyle.FixedSingle;

            // btnApplyPromo
            this.btnApplyPromo.BackColor = Color.FromArgb(13, 148, 136);
            this.btnApplyPromo.FlatStyle = FlatStyle.Flat;
            this.btnApplyPromo.FlatAppearance.BorderSize = 0;
            this.btnApplyPromo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnApplyPromo.ForeColor = Color.White;
            this.btnApplyPromo.Text = "Apply";
            this.btnApplyPromo.Location = new Point(240, 320);
            this.btnApplyPromo.Size = new Size(90, 32);
            this.btnApplyPromo.Cursor = Cursors.Hand;
            this.btnApplyPromo.Click += new System.EventHandler(this.btnApplyPromo_Click);

            // lblSubtotal
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new Font("Segoe UI", 12);
            this.lblSubtotal.Location = new Point(30, 390);
            this.lblSubtotal.Text = "Subtotal";

            // lblSubtotalValue
            this.lblSubtotalValue.AutoSize = true;
            this.lblSubtotalValue.Font = new Font("Segoe UI", 12);
            this.lblSubtotalValue.ForeColor = Color.FromArgb(30, 41, 59);
            this.lblSubtotalValue.Location = new Point(500, 390);
            this.lblSubtotalValue.Text = "Rp 0";

            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new Font("Segoe UI", 12);
            this.lblDiscount.Location = new Point(30, 420);
            this.lblDiscount.Text = "Diskon";

            // lblDiscountValue
            this.lblDiscountValue.AutoSize = true;
            this.lblDiscountValue.Font = new Font("Segoe UI", 12);
            this.lblDiscountValue.ForeColor = Color.FromArgb(239, 68, 68);
            this.lblDiscountValue.Location = new Point(500, 420);
            this.lblDiscountValue.Text = "Rp 0";

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTotal.Location = new Point(30, 455);
            this.lblTotal.Text = "Total";

            // lblTotalValue
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTotalValue.ForeColor = Color.FromArgb(13, 148, 136);
            this.lblTotalValue.Location = new Point(500, 455);
            this.lblTotalValue.Text = "Rp 0";

            // btnConfirm
            this.btnConfirm.BackColor = Color.FromArgb(13, 148, 136);
            this.btnConfirm.FlatStyle = FlatStyle.Flat;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnConfirm.ForeColor = Color.White;
            this.btnConfirm.Text = "Konfirmasi Pesanan";
            this.btnConfirm.Location = new Point(420, 540);
            this.btnConfirm.Size = new Size(240, 50);
            this.btnConfirm.Cursor = Cursors.Hand;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            this.btnCancel.Text = "Batal";
            this.btnCancel.Location = new Point(300, 540);
            this.btnCancel.Size = new Size(100, 50);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblRecipient);
            this.Controls.Add(this.txtRecipient);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.cboPayment);
            this.Controls.Add(this.lblPromo);
            this.Controls.Add(this.txtPromo);
            this.Controls.Add(this.btnApplyPromo);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblSubtotalValue);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblDiscountValue);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
