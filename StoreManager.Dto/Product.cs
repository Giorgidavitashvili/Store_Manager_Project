namespace StoreManager.Dto
{
    public sealed class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; } 
        public int Price { get; set; }       
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
