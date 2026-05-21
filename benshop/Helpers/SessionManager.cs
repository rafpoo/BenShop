using benshop.Models;

namespace benshop.Helpers
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn { get { return CurrentUser != null; } }

        public static bool IsBuyer { get { return CurrentUser != null && CurrentUser.Role == "Buyer"; } }

        public static bool IsSeller { get { return CurrentUser != null && CurrentUser.Role == "Seller"; } }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
