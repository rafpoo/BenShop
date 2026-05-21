namespace benshop.Models
{
    public class TransactionDetail
    {
        public int DetailID { get; set; }
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        public string ProductName { get; set; }
        public string Category { get; set; }
    }
}
