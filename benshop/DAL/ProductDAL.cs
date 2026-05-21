using System;
using System.Data;
using System.Data.SqlClient;

namespace benshop.DAL
{
    public static class ProductDAL
    {
        public static DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT DISTINCT Category FROM Products WHERE IsActive = 1 AND Category IS NOT NULL ORDER BY Category";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Products ORDER BY Name";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static bool IsProductNameExists(string name)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Products WHERE Name = @Name AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static bool IsProductNameExistsExcludeId(string name, int excludeId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Products WHERE Name = @Name AND IsActive = 1 AND ProductID <> @ProductID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@ProductID", excludeId);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static void AddProduct(string name, string category, decimal price, int stock)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"INSERT INTO Products (Name, Category, Price, Stock, IsActive, CreatedAt)
                               VALUES (@Name, @Category, @Price, @Stock, 1, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateProduct(int productId, string name, string category, decimal price, int stock)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"UPDATE Products SET Name = @Name, Category = @Category,
                               Price = @Price, Stock = @Stock WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteProduct(int productId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "UPDATE Products SET IsActive = 0 WHERE ProductID = @ProductID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
