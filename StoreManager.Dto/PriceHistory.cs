namespace StoreManager.Dto
{
    public sealed class PriceHistory
    {
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
