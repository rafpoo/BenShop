using System.Collections.Generic;
using System.Data;
using System.Linq;
using benshop.DAL;
using benshop.Models;

namespace benshop.BLL
{
    public static class CartBLL
    {
        private static List<CartItem> _items = new List<CartItem>();
        private static string _appliedPromo = null;

        public static void AddItem(int productId, string name, decimal price, int quantity, int maxStock)
        {
            var existing = _items.FirstOrDefault(i => i.ProductID == productId);
            if (existing != null)
            {
                existing.Quantity += quantity;
                if (existing.Quantity > existing.MaxStock)
                    existing.Quantity = existing.MaxStock;
            }
            else
            {
                if (quantity > maxStock)
                    quantity = maxStock;

                _items.Add(new CartItem
                {
                    ProductID = productId,
                    ProductName = name,
                    UnitPrice = price,
                    Quantity = quantity,
                    MaxStock = maxStock
                });
            }
        }

        public static List<CartItem> GetItems()
        {
            return _items.ToList();
        }

        public static void UpdateQuantity(int productId, int quantity)
        {
            var item = _items.FirstOrDefault(i => i.ProductID == productId);
            if (item != null)
            {
                if (quantity < 1)
                    quantity = 1;
                if (quantity > item.MaxStock)
                    quantity = item.MaxStock;
                item.Quantity = quantity;
            }
        }

        public static void RemoveItem(int productId)
        {
            _items.RemoveAll(i => i.ProductID == productId);
        }

        public static decimal GetTotal()
        {
            return _items.Sum(i => i.Subtotal);
        }

        public static decimal GetDiscount()
        {
            if (string.IsNullOrEmpty(_appliedPromo))
                return 0;

            var promoRow = PromoDAL.GetPromoByCode(_appliedPromo);
            if (promoRow == null) return 0;

            decimal subtotal = GetTotal();
            string discType = promoRow["DiscountType"].ToString();
            decimal discVal = (decimal)promoRow["DiscountVal"];

            if (discType == "Percent")
                return subtotal * discVal / 100;
            else
                return discVal > subtotal ? subtotal : discVal;
        }

        public static void ApplyPromo(string code)
        {
            _appliedPromo = code;
        }

        public static string GetAppliedPromo()
        {
            return _appliedPromo;
        }

        public static void Clear()
        {
            _items.Clear();
            _appliedPromo = null;
        }

        public static DataTable ToDataTable()
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            dt.Columns.Add("Subtotal", typeof(decimal));

            foreach (var item in _items)
            {
                dt.Rows.Add(item.ProductID, item.Quantity, item.UnitPrice, item.Subtotal);
            }
            return dt;
        }
    }
}
