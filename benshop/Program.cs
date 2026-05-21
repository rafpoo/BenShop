using System;
using System.Windows.Forms;
using benshop.Forms.Login;

namespace benshop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool restart = true;
            while (restart)
            {
                restart = false;

                using (var login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        return;
                }

                Form dashboard = null;
                if (Helpers.SessionManager.IsBuyer)
                    dashboard = new Forms.Buyer.FrmBuyerDashboard();
                else if (Helpers.SessionManager.IsSeller)
                    dashboard = new Forms.Seller.FrmSellerDashboard();

                if (dashboard != null)
                {
                    dashboard.FormClosed += (s, args) =>
                    {
                        if (Helpers.SessionManager.CurrentUser == null)
                            restart = true;
                    };
                    Application.Run(dashboard);
                }
            }
        }
    }
}
