using System;
using System.Data;
using benshop.DAL;
using benshop.Helpers;

namespace benshop.BLL
{
    public static class CheckoutBLL
    {
        public static bool ValidatePromo(string code)
        {
            var row = PromoDAL.GetPromoByCode(code);
            if (row == null) return false;

            DateTime validFrom = (DateTime)row["ValidFrom"];
            DateTime validUntil = (DateTime)row["ValidUntil"];
            DateTime today = DateTime.Today;

            return today >= validFrom && today <= validUntil;
        }

        public static string CreateTransaction(string recipient, string phone, string address, string paymentMethod)
        {
            var items = CartBLL.GetItems();
            if (items.Count == 0)
                throw new InvalidOperationException("Keranjang belanja kosong!");

            int buyerId = SessionManager.CurrentUser.UserID;
            decimal subtotal = CartBLL.GetTotal();
            decimal discount = CartBLL.GetDiscount();
            decimal total = subtotal - discount;

            string promoCode = CartBLL.GetAppliedPromo();
            int? promoId = null;
            if (!string.IsNullOrEmpty(promoCode))
            {
                var promoRow = PromoDAL.GetPromoByCode(promoCode);
                if (promoRow != null)
                    promoId = (int)promoRow["PromoID"];
            }

            DataTable cartDt = CartBLL.ToDataTable();
            return TransactionDAL.CreateTransaction(buyerId, subtotal, discount, total,
                paymentMethod, cartDt, promoId, recipient, phone, address);
        }
    }
}
