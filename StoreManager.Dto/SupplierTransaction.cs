namespace StoreManager.Dto
{
    public sealed class SupplierTransaction
    {
        public int TransactionID { get; set; }
        public int SupplierID { get; set; }
        public string TransactionCode { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public byte Status { get; set; }
    }
}
