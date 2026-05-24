using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using benshop.Helpers;
using Microsoft.Reporting.WinForms;

namespace benshop.Forms.Seller
{
    public partial class FrmSellerReport : Form
    {
        public FrmSellerReport()
        {
            InitializeComponent();
            ApplyModernTheme();
            SetDefaultDateRange();
            LoadTransactionSummary();
        }

        private void ApplyModernTheme()
        {
            Helpers.UiHelper.ApplyForm(this, new Size(1100, 760));
            Helpers.UiHelper.ApplyHeader(pnlTop, lblTitle, "Laporan Penjualan");
            pnlFilter.BackColor = Color.White;
            pnlSummary.BackColor = Color.FromArgb(241, 245, 249);
            Helpers.UiHelper.ApplyInput(dtpStartDate);
            Helpers.UiHelper.ApplyInput(dtpEndDate);
            Helpers.UiHelper.ApplyButton(btnShow, Helpers.ButtonKind.Primary);
            Helpers.UiHelper.ApplyButton(btnWeekly, Helpers.ButtonKind.Primary);
            Helpers.UiHelper.ApplyButton(btnMonthly, Helpers.ButtonKind.Info);
            Helpers.UiHelper.ApplyButton(btnYearly, Helpers.ButtonKind.Danger);
            Helpers.UiHelper.ApplyButton(btnTopProducts, Helpers.ButtonKind.Info);
            Helpers.UiHelper.ApplyButton(btnProfitTrend, Helpers.ButtonKind.Warning);
            Helpers.UiHelper.ApplyButton(btnPromoUsage, Helpers.ButtonKind.Info);
            Helpers.UiHelper.ApplyButton(btnClose, Helpers.ButtonKind.Secondary);
        }

        private void SetDefaultDateRange()
        {
            DateTime today = DateTime.Today;
            dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDate.Value = today;
        }

        private bool TryGetDateRange(out DateTime startDate, out DateTime endDate)
        {
            startDate = dtpStartDate.Value.Date;
            endDate = dtpEndDate.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("Tanggal sampai tidak boleh sebelum tanggal mulai.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadTransactionSummary();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-6);
            dtpEndDate.Value = DateTime.Today;
            LoadTransactionSummary();
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDate.Value = today;
            LoadTransactionSummary();
        }

        private void btnYearly_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpStartDate.Value = new DateTime(today.Year, 1, 1);
            dtpEndDate.Value = today;
            LoadTransactionSummary();
        }

        private void btnTopProducts_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;
            if (!TryGetDateRange(out startDate, out endDate))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                LoadReportSummary(startDate, endDate);
                DataTable dt = BLL.ReportBLL.GetTopProductsData(startDate, endDate);
                ShowReport("TopProducts", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat laporan: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnProfitTrend_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;
            if (!TryGetDateRange(out startDate, out endDate))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                LoadReportSummary(startDate, endDate);
                DataTable dt = BLL.ReportBLL.GetRevenueTrend(startDate, endDate);
                ShowReport("RevenueTrend", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat laporan: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnPromoUsage_Click(object sender, EventArgs e)
        {
            DateTime startDate;
            DateTime endDate;
            if (!TryGetDateRange(out startDate, out endDate))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                LoadReportSummary(startDate, endDate);
                DataTable dt = BLL.ReportBLL.GetPromoUsage(startDate, endDate);
                ShowReport("PromoUsage", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat laporan: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadTransactionSummary()
        {
            DateTime startDate;
            DateTime endDate;
            if (!TryGetDateRange(out startDate, out endDate))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                LoadReportSummary(startDate, endDate);
                DataSet ds = BLL.ReportBLL.GetTransactionSummary(startDate, endDate);
                DataTable dt = ds.Tables["TransactionSummary"];
                ShowReport("TransactionSummary", dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Gagal memuat laporan: {0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadReportSummary(DateTime startDate, DateTime endDate)
        {
            DataTable summary = BLL.ReportBLL.GetReportSummary(startDate, endDate);
            if (summary.Rows.Count == 0)
            {
                SetSummaryValues(0, 0, 0, 0, 0);
                return;
            }

            DataRow row = summary.Rows[0];
            SetSummaryValues(
                GetIntValue(row, "TotalTransactions"),
                GetDecimalValue(row, "TotalSubtotal"),
                GetDecimalValue(row, "TotalDiscount"),
                GetDecimalValue(row, "TotalRevenue"),
                GetDecimalValue(row, "AverageTransaction"));
        }

        private void SetSummaryValues(int totalTransactions, decimal totalSubtotal,
            decimal totalDiscount, decimal totalRevenue, decimal averageTransaction)
        {
            lblTotalTransactionsValue.Text = totalTransactions.ToString("N0");
            lblTotalSubtotalValue.Text = FormatHelper.ToRupiah(totalSubtotal);
            lblTotalDiscountValue.Text = FormatHelper.ToRupiah(totalDiscount);
            lblTotalRevenueValue.Text = FormatHelper.ToRupiah(totalRevenue);
            lblAverageTransactionValue.Text = FormatHelper.ToRupiah(averageTransaction);
        }

        private static int GetIntValue(DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
                return 0;
            return Convert.ToInt32(row[columnName]);
        }

        private static decimal GetDecimalValue(DataRow row, string columnName)
        {
            if (row[columnName] == DBNull.Value)
                return 0;
            return Convert.ToDecimal(row[columnName]);
        }

        private void ShowReport(string dataSetName, DataTable data)
        {
            System.IO.Stream rdlcStream = Helpers.ReportHelper.GenerateRdlc(dataSetName, data);
            string tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Benshop_" + dataSetName + ".rdlc");
            using (System.IO.FileStream fs = new System.IO.FileStream(tempPath, System.IO.FileMode.Create))
            {
                rdlcStream.CopyTo(fs);
            }
            rdlcStream.Position = 0;
            reportViewer.LocalReport.LoadReportDefinition(rdlcStream);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(dataSetName, data));
            reportViewer.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
