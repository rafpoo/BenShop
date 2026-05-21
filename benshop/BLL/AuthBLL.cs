using System.Security.Cryptography;
using System.Text;
using benshop.DAL;
using benshop.Models;

namespace benshop.BLL
{
    public static class AuthBLL
    {
        public static User Authenticate(string username, string password)
        {
            string passwordHash = HashPassword(password);
            return UserDAL.Authenticate(username, passwordHash);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
