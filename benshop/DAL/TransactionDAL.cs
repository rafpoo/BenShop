using System;
using System.Data;
using System.Data.SqlClient;

namespace benshop.DAL
{
    public static class TransactionDAL
    {
        public static DataTable GetBuyerTransactions(int buyerId, string statusFilter)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"SELECT * FROM Transactions WHERE BuyerID = @BuyerID";
                if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Semua")
                    query += " AND Status = @Status";
                query += " ORDER BY CreatedAt DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BuyerID", buyerId);
                    if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "Semua")
                        cmd.Parameters.AddWithValue("@Status", statusFilter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static DataTable GetTransactionDetails(int transactionId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"SELECT td.*, p.Name as ProductName, p.Category
                               FROM TransactionDetails td
                               JOIN Products p ON td.ProductID = p.ProductID
                               WHERE td.TransactionID = @TransactionID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static string CreateTransaction(int buyerId, decimal subtotal, decimal discount, decimal total,
            string paymentMethod, DataTable cartItems, int? promoId, string recipient, string phone, string address)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string transNo = GenerateTransactionNo(conn, trans);
                        bool hasShippingColumns = HasColumn(conn, trans, "Transactions", "RecipientName")
                            && HasColumn(conn, trans, "Transactions", "RecipientPhone")
                            && HasColumn(conn, trans, "Transactions", "ShippingAddress");

                        string insertTx = hasShippingColumns
                            ? @"INSERT INTO Transactions (TransactionNo, BuyerID, PromoID, Subtotal, DiscountAmount, Total, PaymentMethod, Status, CreatedAt, RecipientName, RecipientPhone, ShippingAddress)
                                VALUES (@TransNo, @BuyerID, @PromoID, @Subtotal, @Discount, @Total, @Payment, 'Diproses', GETDATE(), @Recipient, @Phone, @Address);
                                SELECT SCOPE_IDENTITY();"
                            : @"INSERT INTO Transactions (TransactionNo, BuyerID, PromoID, Subtotal, DiscountAmount, Total, PaymentMethod, Status, CreatedAt)
                                VALUES (@TransNo, @BuyerID, @PromoID, @Subtotal, @Discount, @Total, @Payment, 'Diproses', GETDATE());
                                SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmd = new SqlCommand(insertTx, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@TransNo", transNo);
                            cmd.Parameters.AddWithValue("@BuyerID", buyerId);
                            cmd.Parameters.AddWithValue("@PromoID", (object)promoId ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                            cmd.Parameters.AddWithValue("@Discount", discount);
                            cmd.Parameters.AddWithValue("@Total", total);
                            cmd.Parameters.AddWithValue("@Payment", paymentMethod);
                            if (hasShippingColumns)
                            {
                                cmd.Parameters.AddWithValue("@Recipient", recipient);
                                cmd.Parameters.AddWithValue("@Phone", phone);
                                cmd.Parameters.AddWithValue("@Address", address);
                            }
                            int txId = Convert.ToInt32(cmd.ExecuteScalar());

                            foreach (DataRow row in cartItems.Rows)
                            {
                                int productId = Convert.ToInt32(row["ProductID"]);
                                int quantity = Convert.ToInt32(row["Quantity"]);

                                string updateStock = @"UPDATE Products
                                                       SET Stock = Stock - @Qty
                                                       WHERE ProductID = @ProductID
                                                         AND IsActive = 1
                                                         AND Stock >= @Qty";
                                using (SqlCommand stockCmd = new SqlCommand(updateStock, conn, trans))
                                {
                                    stockCmd.Parameters.AddWithValue("@ProductID", productId);
                                    stockCmd.Parameters.AddWithValue("@Qty", quantity);
                                    if (stockCmd.ExecuteNonQuery() == 0)
                                        throw new InvalidOperationException("Stok produk tidak mencukupi atau produk sudah tidak aktif.");
                                }

                                string insertDetail = @"INSERT INTO TransactionDetails (TransactionID, ProductID, Quantity, UnitPrice, Subtotal)
                                                      VALUES (@TxID, @ProductID, @Qty, @Price, @Subtotal)";
                                using (SqlCommand detailCmd = new SqlCommand(insertDetail, conn, trans))
                                {
                                    detailCmd.Parameters.AddWithValue("@TxID", txId);
                                    detailCmd.Parameters.AddWithValue("@ProductID", productId);
                                    detailCmd.Parameters.AddWithValue("@Qty", quantity);
                                    detailCmd.Parameters.AddWithValue("@Price", row["UnitPrice"]);
                                    detailCmd.Parameters.AddWithValue("@Subtotal", row["Subtotal"]);
                                    detailCmd.ExecuteNonQuery();
                                }
                            }

                            if (promoId.HasValue)
                            {
                                using (SqlCommand promoCmd = new SqlCommand(
                                    "UPDATE PromoCodes SET UsageCount = UsageCount + 1 WHERE PromoID = @PromoID", conn, trans))
                                {
                                    promoCmd.Parameters.AddWithValue("@PromoID", promoId.Value);
                                    promoCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        trans.Commit();
                        return transNo;
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public static void UpdateTransactionStatus(int transactionId, string status)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "UPDATE Transactions SET Status = @Status WHERE TransactionID = @TransactionID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                    cmd.Parameters.AddWithValue("@Status", status);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static bool HasColumn(SqlConnection conn, SqlTransaction trans, string tableName, string columnName)
        {
            string query = @"SELECT COUNT(*)
                             FROM sys.columns c
                             JOIN sys.tables t ON c.object_id = t.object_id
                             WHERE t.name = @TableName AND c.name = @ColumnName";
            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@TableName", tableName);
                cmd.Parameters.AddWithValue("@ColumnName", columnName);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static string GenerateTransactionNo(SqlConnection conn, SqlTransaction trans)
        {
            string prefix = string.Format("TRX-{0}-", DateTime.Today.ToString("yyyyMMdd"));
            string query = @"SELECT COUNT(*)
                             FROM Transactions WITH (UPDLOCK, HOLDLOCK)
                             WHERE TransactionNo LIKE @Prefix + '%'";
            using (SqlCommand cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@Prefix", prefix);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return prefix + (count + 1).ToString("D3");
            }
        }
    }
}
