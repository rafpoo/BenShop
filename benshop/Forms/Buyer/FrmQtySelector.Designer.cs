using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Buyer
{
    partial class FrmQtySelector
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblProduct;
        private NumericUpDown nudQty;
        private Button btnOK;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblProduct = new Label();
            this.nudQty = new NumericUpDown();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)this.nudQty).BeginInit();
            this.SuspendLayout();

            this.ClientSize = new Size(350, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Pilih Jumlah";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.lblProduct.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblProduct.Location = new Point(20, 30);
            this.lblProduct.Size = new Size(310, 30);
            this.lblProduct.Text = "Produk";

            this.nudQty.Font = new Font("Segoe UI", 14);
            this.nudQty.Location = new Point(20, 70);
            this.nudQty.Size = new Size(310, 40);
            this.nudQty.TextAlign = HorizontalAlignment.Center;

            this.btnOK.BackColor = Color.FromArgb(13, 148, 136);
            this.btnOK.FlatStyle = FlatStyle.Flat;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnOK.ForeColor = Color.White;
            this.btnOK.Text = "Tambah";
            this.btnOK.Location = new Point(30, 140);
            this.btnOK.Size = new Size(130, 40);
            this.btnOK.Cursor = Cursors.Hand;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            this.btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 11);
            this.btnCancel.Text = "Batal";
            this.btnCancel.Location = new Point(190, 140);
            this.btnCancel.Size = new Size(130, 40);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.nudQty);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            ((System.ComponentModel.ISupportInitialize)this.nudQty).EndInit();
            this.ResumeLayout(false);
        }
    }
}
