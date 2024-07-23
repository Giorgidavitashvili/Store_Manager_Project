namespace StoreManager.Dto
{
    public sealed class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public byte Status { get; set; }
        public string ?Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
