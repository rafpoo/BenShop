using System;

namespace benshop.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string TransactionNo { get; set; }
        public int BuyerID { get; set; }
        public int? PromoID { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Total { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public string BuyerName { get; set; }
        public string PromoCode { get; set; }
    }
}
