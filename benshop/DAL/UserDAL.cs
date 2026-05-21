using System.Data;
using System.Data.SqlClient;
using benshop.Models;

namespace benshop.DAL
{
    public static class UserDAL
    {
        public static User Authenticate(string username, string passwordHash)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = (int)reader["UserID"],
                                Username = reader["Username"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Role = reader["Role"].ToString(),
                                CreatedAt = (System.DateTime)reader["CreatedAt"]
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
