using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace benshop.Forms.Seller
{
    public partial class FrmSellerReport : Form
    {
        public FrmSellerReport()
        {
            InitializeComponent();
            reportViewer.RefreshReport();
        }

        private void btnWeekly_Click(object sender, EventArgs e)
        {
            LoadTransactionSummary("week");
        }

        private void btnMonthly_Click(object sender, EventArgs e)
        {
            LoadTransactionSummary("month");
        }

        private void btnYearly_Click(object sender, EventArgs e)
        {
            LoadTransactionSummary("year");
        }

        private void btnTopProducts_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt = BLL.ReportBLL.GetTopProductsData();
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
            try
            {
                Cursor = Cursors.WaitCursor;
                DataTable dt = BLL.ReportBLL.GetProfitTrend();
                ShowReport("ProfitTrend", dt);
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

        private void LoadTransactionSummary(string period)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DataSet ds = BLL.ReportBLL.GetTransactionSummary(period);
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
