using System;

namespace benshop.Models
{
    public class PromoCode
    {
        public int PromoID { get; set; }
        public string Code { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountVal { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public int UsageCount { get; set; }
        public bool IsActive { get; set; }
    }
}
