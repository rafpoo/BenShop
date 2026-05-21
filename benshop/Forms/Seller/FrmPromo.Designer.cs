using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Seller
{
    partial class FrmPromo
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Panel pnlForm;
        private Label lblTitle;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblDiscountType;
        private ComboBox cboDiscountType;
        private Label lblDiscountVal;
        private NumericUpDown nudDiscountVal;
        private Label lblValidFrom;
        private DateTimePicker dtpValidFrom;
        private Label lblValidUntil;
        private DateTimePicker dtpValidUntil;
        private CheckBox chkActive;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDeactivate;
        private Button btnClose;
        private DataGridView dgvPromo;

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
            this.lblCode = new Label();
            this.txtCode = new TextBox();
            this.lblDiscountType = new Label();
            this.cboDiscountType = new ComboBox();
            this.lblDiscountVal = new Label();
            this.nudDiscountVal = new NumericUpDown();
            this.lblValidFrom = new Label();
            this.dtpValidFrom = new DateTimePicker();
            this.lblValidUntil = new Label();
            this.dtpValidUntil = new DateTimePicker();
            this.chkActive = new CheckBox();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDeactivate = new Button();
            this.btnClose = new Button();
            this.dgvPromo = new DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudDiscountVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPromo).BeginInit();
            this.SuspendLayout();

            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Benshop - Manajemen Promo";
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.pnlTop.BackColor = Color.FromArgb(15, 23, 42);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Size = new Size(900, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Text = "Manajemen Promo";
            this.lblTitle.Location = new Point(20, 12);
            this.pnlTop.Controls.Add(this.lblTitle);

            // dgvPromo
            this.dgvPromo.AllowUserToAddRows = false;
            this.dgvPromo.AllowUserToDeleteRows = false;
            this.dgvPromo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPromo.BackgroundColor = Color.White;
            this.dgvPromo.BorderStyle = BorderStyle.None;
            this.dgvPromo.ColumnHeadersHeight = 40;
            this.dgvPromo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            this.dgvPromo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvPromo.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.dgvPromo.Location = new Point(20, 80);
            this.dgvPromo.Size = new Size(860, 250);
            this.dgvPromo.ReadOnly = true;
            this.dgvPromo.RowTemplate.Height = 35;
            this.dgvPromo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromo.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            this.dgvPromo.SelectionChanged += new System.EventHandler(this.dgvPromo_SelectionChanged);

            // Form panel
            this.pnlForm.BackColor = Color.White;
            this.pnlForm.Location = new Point(20, 350);
            this.pnlForm.Size = new Size(860, 220);
            this.pnlForm.Padding = new Padding(20);

            this.lblCode.AutoSize = true;
            this.lblCode.Font = new Font("Segoe UI", 10);
            this.lblCode.Text = "Kode Promo";
            this.lblCode.Location = new Point(20, 15);

            this.txtCode.Font = new Font("Segoe UI", 11);
            this.txtCode.Location = new Point(20, 38);
            this.txtCode.Size = new Size(200, 30);
            this.txtCode.BorderStyle = BorderStyle.FixedSingle;
            this.txtCode.CharacterCasing = CharacterCasing.Upper;

            this.lblDiscountType.AutoSize = true;
            this.lblDiscountType.Font = new Font("Segoe UI", 10);
            this.lblDiscountType.Text = "Tipe Diskon";
            this.lblDiscountType.Location = new Point(240, 15);

            this.cboDiscountType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboDiscountType.Font = new Font("Segoe UI", 11);
            this.cboDiscountType.Items.AddRange(new object[] { "Percent", "Fixed" });
            this.cboDiscountType.Location = new Point(240, 38);
            this.cboDiscountType.Size = new Size(150, 30);

            this.lblDiscountVal.AutoSize = true;
            this.lblDiscountVal.Font = new Font("Segoe UI", 10);
            this.lblDiscountVal.Text = "Nilai Diskon";
            this.lblDiscountVal.Location = new Point(410, 15);

            this.nudDiscountVal.Font = new Font("Segoe UI", 11);
            this.nudDiscountVal.Location = new Point(410, 38);
            this.nudDiscountVal.Size = new Size(150, 30);
            this.nudDiscountVal.Maximum = 999999999;
            this.nudDiscountVal.DecimalPlaces = 2;

            this.lblValidFrom.AutoSize = true;
            this.lblValidFrom.Font = new Font("Segoe UI", 10);
            this.lblValidFrom.Text = "Berlaku Dari";
            this.lblValidFrom.Location = new Point(20, 85);

            this.dtpValidFrom.Font = new Font("Segoe UI", 11);
            this.dtpValidFrom.Format = DateTimePickerFormat.Short;
            this.dtpValidFrom.Location = new Point(20, 108);
            this.dtpValidFrom.Size = new Size(180, 30);

            this.lblValidUntil.AutoSize = true;
            this.lblValidUntil.Font = new Font("Segoe UI", 10);
            this.lblValidUntil.Text = "Berlaku Sampai";
            this.lblValidUntil.Location = new Point(220, 85);

            this.dtpValidUntil.Font = new Font("Segoe UI", 11);
            this.dtpValidUntil.Format = DateTimePickerFormat.Short;
            this.dtpValidUntil.Location = new Point(220, 108);
            this.dtpValidUntil.Size = new Size(180, 30);

            this.chkActive.Font = new Font("Segoe UI", 10);
            this.chkActive.Text = "Aktif";
            this.chkActive.Checked = true;
            this.chkActive.Location = new Point(420, 108);
            this.chkActive.Size = new Size(80, 30);

            this.btnAdd.BackColor = Color.FromArgb(13, 148, 136);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.Location = new Point(20, 160);
            this.btnAdd.Size = new Size(120, 40);
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.BackColor = Color.FromArgb(59, 130, 246);
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new Point(150, 160);
            this.btnEdit.Size = new Size(120, 40);
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDeactivate.BackColor = Color.FromArgb(245, 158, 11);
            this.btnDeactivate.FlatStyle = FlatStyle.Flat;
            this.btnDeactivate.FlatAppearance.BorderSize = 0;
            this.btnDeactivate.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnDeactivate.ForeColor = Color.White;
            this.btnDeactivate.Text = "Nonaktifkan";
            this.btnDeactivate.Location = new Point(280, 160);
            this.btnDeactivate.Size = new Size(140, 40);
            this.btnDeactivate.Cursor = Cursors.Hand;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);

            this.btnClose.BackColor = Color.FromArgb(226, 232, 240);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 11);
            this.btnClose.Text = "Tutup";
            this.btnClose.Location = new Point(730, 160);
            this.btnClose.Size = new Size(100, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.pnlForm.Controls.Add(this.lblCode);
            this.pnlForm.Controls.Add(this.txtCode);
            this.pnlForm.Controls.Add(this.lblDiscountType);
            this.pnlForm.Controls.Add(this.cboDiscountType);
            this.pnlForm.Controls.Add(this.lblDiscountVal);
            this.pnlForm.Controls.Add(this.nudDiscountVal);
            this.pnlForm.Controls.Add(this.lblValidFrom);
            this.pnlForm.Controls.Add(this.dtpValidFrom);
            this.pnlForm.Controls.Add(this.lblValidUntil);
            this.pnlForm.Controls.Add(this.dtpValidUntil);
            this.pnlForm.Controls.Add(this.chkActive);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.btnEdit);
            this.pnlForm.Controls.Add(this.btnDeactivate);
            this.pnlForm.Controls.Add(this.btnClose);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvPromo);
            this.Controls.Add(this.pnlForm);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudDiscountVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPromo).EndInit();
            this.ResumeLayout(false);
        }
    }
}
