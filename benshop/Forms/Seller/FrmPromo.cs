using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace benshop.Forms.Seller
{
    public partial class FrmPromo : Form
    {
        public FrmPromo()
        {
            InitializeComponent();
            LoadPromos();
        }

        private void LoadPromos()
        {
            try
            {
                DataTable dt = DAL.PromoDAL.GetAllPromos();
                dgvPromo.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat promo: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtCode.Clear();
            cboDiscountType.SelectedIndex = -1;
            nudDiscountVal.Value = 0;
            dtpValidFrom.Value = DateTime.Today;
            dtpValidUntil.Value = DateTime.Today.AddMonths(1);
            chkActive.Checked = true;
            txtCode.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string discType = cboDiscountType.SelectedItem != null ? cboDiscountType.SelectedItem.ToString() : null;

            if (!ValidatePromoInput(code, discType))
                return;

            try
            {
                DAL.PromoDAL.AddPromo(code, discType, nudDiscountVal.Value,
                    dtpValidFrom.Value, dtpValidUntil.Value, chkActive.Checked);
                MessageBox.Show("Promo berhasil ditambahkan!", "Berhasil",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadPromos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal menambah promo: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPromo.CurrentRow == null) return;

            string code = txtCode.Text.Trim();
            string discType = cboDiscountType.SelectedItem != null ? cboDiscountType.SelectedItem.ToString() : null;

            if (!ValidatePromoInput(code, discType))
                return;

            try
            {
                int promoId = Convert.ToInt32(dgvPromo.CurrentRow.Cells["PromoID"].Value);
                DAL.PromoDAL.UpdatePromo(promoId, code, discType, nudDiscountVal.Value,
                    dtpValidFrom.Value, dtpValidUntil.Value, chkActive.Checked);
                MessageBox.Show("Promo berhasil diupdate!", "Berhasil",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadPromos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal mengupdate promo: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvPromo.CurrentRow == null) return;

            int promoId = Convert.ToInt32(dgvPromo.CurrentRow.Cells["PromoID"].Value);
            bool isActive = Convert.ToBoolean(dgvPromo.CurrentRow.Cells["IsActive"].Value ?? true);
            string action = isActive ? "nonaktifkan" : "aktifkan";

            var result = MessageBox.Show(string.Format("Yakin ingin {0} promo ini?", action), "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                DAL.PromoDAL.SetPromoActive(promoId, !isActive);
                LoadPromos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal mengubah status promo: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePromoInput(string code, string discType)
        {
            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrEmpty(discType))
            {
                MessageBox.Show("Kode promo dan tipe diskon harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (nudDiscountVal.Value <= 0)
            {
                MessageBox.Show("Nilai diskon harus lebih dari 0!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (discType == "Percent" && nudDiscountVal.Value > 100)
            {
                MessageBox.Show("Diskon persen tidak boleh lebih dari 100!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpValidUntil.Value.Date < dtpValidFrom.Value.Date)
            {
                MessageBox.Show("Tanggal berlaku sampai tidak boleh sebelum tanggal mulai!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dgvPromo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPromo.CurrentRow == null) return;

            var row = dgvPromo.CurrentRow;
            txtCode.Text = row.Cells["Code"].Value != null ? row.Cells["Code"].Value.ToString() : "";
            cboDiscountType.SelectedItem = row.Cells["DiscountType"].Value != null ? row.Cells["DiscountType"].Value.ToString() : null;
            nudDiscountVal.Value = Convert.ToDecimal(dgvPromo.CurrentRow.Cells["DiscountVal"].Value ?? 0);
            dtpValidFrom.Value = GetDateCellValue(dgvPromo.CurrentRow.Cells["ValidFrom"].Value, DateTime.Today);
            dtpValidUntil.Value = GetDateCellValue(dgvPromo.CurrentRow.Cells["ValidUntil"].Value, DateTime.Today);
            chkActive.Checked = Convert.ToBoolean(dgvPromo.CurrentRow.Cells["IsActive"].Value ?? true);
            btnDeactivate.Text = chkActive.Checked ? "Nonaktifkan" : "Aktifkan";
        }

        private static DateTime GetDateCellValue(object value, DateTime fallback)
        {
            if (value == null || value == DBNull.Value)
                return fallback;
            return Convert.ToDateTime(value);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
