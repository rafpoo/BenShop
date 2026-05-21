using System;
using System.Data;
using System.Data.SqlClient;
using benshop.DAL;

namespace benshop.BLL
{
    public static class ReportBLL
    {
        public static DataTable GetDashboardStats()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"
                    SELECT
                        (SELECT COUNT(*) FROM Products WHERE IsActive = 1) AS TotalProducts,
                        (SELECT COUNT(*) FROM Transactions) AS TotalTransactions,
                        ISNULL((
                            SELECT SUM(Total)
                            FROM Transactions
                            WHERE CreatedAt >= CAST(GETDATE() AS DATE)
                              AND CreatedAt < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
                              AND ISNULL(Status, '') <> 'Dibatalkan'
                        ), 0) AS RevenueToday";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable GetTopProducts(int top)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"
                    SELECT TOP (@Top) p.Name, p.Category, SUM(td.Quantity) AS TotalSold, SUM(td.Subtotal) AS TotalRevenue
                    FROM TransactionDetails td
                    JOIN Products p ON td.ProductID = p.ProductID
                    JOIN Transactions t ON td.TransactionID = t.TransactionID
                    WHERE ISNULL(t.Status, '') <> 'Dibatalkan'
                    GROUP BY p.Name, p.Category
                    ORDER BY TotalSold DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Top", top);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable GetRecentTransactions(int count)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"
                    SELECT TOP (@Count) t.TransactionID, t.TransactionNo, u.FullName AS Buyer, t.Total, t.Status, t.CreatedAt
                    FROM Transactions t
                    JOIN Users u ON t.BuyerID = u.UserID
                    ORDER BY t.CreatedAt DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Count", count);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataSet GetTransactionSummary(string period)
        {
            string query;
            if (period == "week")
                query = BuildTransactionSummaryQuery("WHERE CreatedAt >= DATEADD(DAY,-7,GETDATE())");
            else if (period == "month")
                query = BuildTransactionSummaryQuery("WHERE YEAR(CreatedAt) = YEAR(GETDATE()) AND MONTH(CreatedAt) = MONTH(GETDATE())");
            else if (period == "year")
                query = BuildTransactionSummaryQuery("WHERE YEAR(CreatedAt) = YEAR(GETDATE())");
            else
                query = BuildTransactionSummaryQuery("");

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "TransactionSummary");
                return ds;
            }
        }

        public static DataTable GetTopProductsData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"
                    SELECT p.Name, p.Category, SUM(td.Quantity) AS TotalSold, SUM(td.Subtotal) AS TotalRevenue
                    FROM TransactionDetails td
                    JOIN Products p ON td.ProductID = p.ProductID
                    JOIN Transactions t ON td.TransactionID = t.TransactionID
                    WHERE ISNULL(t.Status, '') <> 'Dibatalkan'
                    GROUP BY p.Name, p.Category
                    ORDER BY TotalSold DESC";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable GetProfitTrend()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"
                    SELECT
                        YEAR(CreatedAt) AS TxYear,
                        MONTH(CreatedAt) AS TxMonth,
                        DATENAME(MONTH, CreatedAt) AS MonthName,
                        SUM(Total) AS Revenue,
                        COUNT(*) AS Transactions
                    FROM Transactions
                    WHERE ISNULL(Status, '') <> 'Dibatalkan'
                    GROUP BY YEAR(CreatedAt), MONTH(CreatedAt), DATENAME(MONTH, CreatedAt)
                    ORDER BY TxYear, TxMonth";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        private static string BuildTransactionSummaryQuery(string periodWhere)
        {
            string statusFilter = string.IsNullOrWhiteSpace(periodWhere)
                ? "WHERE ISNULL(Status, '') <> 'Dibatalkan'"
                : periodWhere + " AND ISNULL(Status, '') <> 'Dibatalkan'";

            return @"
                SELECT
                    CAST(CreatedAt AS DATE) AS TxDate,
                    DATENAME(MONTH, CreatedAt) AS MonthName,
                    YEAR(CreatedAt) AS TxYear,
                    COUNT(*) AS TotalTransactions,
                    SUM(Subtotal) AS TotalSubtotal,
                    SUM(DiscountAmount) AS TotalDiscount,
                    SUM(Total) AS TotalRevenue
                FROM Transactions
                " + statusFilter + @"
                GROUP BY CAST(CreatedAt AS DATE), DATENAME(MONTH, CreatedAt), YEAR(CreatedAt)
                ORDER BY TxDate";
        }
    }
}
