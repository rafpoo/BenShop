using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace benshop.DAL
{
    public static class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["BenshopDB"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}
