using System;
using System.Data;
using System.Data.SqlClient;

namespace benshop.DAL
{
    public static class PromoDAL
    {
        public static DataTable GetAllPromos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM PromoCodes ORDER BY Code";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static void AddPromo(string code, string discountType, decimal discountVal,
            DateTime validFrom, DateTime validUntil, bool isActive)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"INSERT INTO PromoCodes (Code, DiscountType, DiscountVal, ValidFrom, ValidUntil, IsActive)
                               VALUES (@Code, @DiscountType, @DiscountVal, @ValidFrom, @ValidUntil, @IsActive)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@DiscountType", discountType);
                    cmd.Parameters.AddWithValue("@DiscountVal", discountVal);
                    cmd.Parameters.AddWithValue("@ValidFrom", validFrom);
                    cmd.Parameters.AddWithValue("@ValidUntil", validUntil);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool PromoCodeExists(string code, int? excludePromoId = null)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"SELECT COUNT(1)
                                 FROM PromoCodes
                                 WHERE UPPER(Code) = UPPER(@Code)
                                   AND (@ExcludePromoID IS NULL OR PromoID <> @ExcludePromoID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.Add("@ExcludePromoID", SqlDbType.Int).Value = excludePromoId.HasValue
                        ? (object)excludePromoId.Value
                        : DBNull.Value;
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        public static void UpdatePromo(int promoId, string code, string discountType, decimal discountVal,
            DateTime validFrom, DateTime validUntil, bool isActive)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"UPDATE PromoCodes
                                 SET Code = @Code,
                                     DiscountType = @DiscountType,
                                     DiscountVal = @DiscountVal,
                                     ValidFrom = @ValidFrom,
                                     ValidUntil = @ValidUntil,
                                     IsActive = @IsActive
                                 WHERE PromoID = @PromoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PromoID", promoId);
                    cmd.Parameters.AddWithValue("@Code", code);
                    cmd.Parameters.AddWithValue("@DiscountType", discountType);
                    cmd.Parameters.AddWithValue("@DiscountVal", discountVal);
                    cmd.Parameters.AddWithValue("@ValidFrom", validFrom);
                    cmd.Parameters.AddWithValue("@ValidUntil", validUntil);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SetPromoActive(int promoId, bool isActive)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "UPDATE PromoCodes SET IsActive = @IsActive WHERE PromoID = @PromoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PromoID", promoId);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataRow GetPromoByCode(string code)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT * FROM PromoCodes WHERE Code = @Code AND IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", code);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                            return dt.Rows[0];
                    }
                }
            }
            return null;
        }

        public static void IncrementUsage(int promoId)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "UPDATE PromoCodes SET UsageCount = UsageCount + 1 WHERE PromoID = @PromoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PromoID", promoId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
