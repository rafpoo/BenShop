namespace benshop.Models
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get { return UnitPrice * Quantity; } }
        public int MaxStock { get; set; }
    }
}
