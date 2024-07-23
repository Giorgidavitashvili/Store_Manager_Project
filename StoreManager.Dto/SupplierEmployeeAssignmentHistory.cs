namespace StoreManager.Dto
{
    public sealed class SupplierEmployeeAssignmentHistory
    {
        public int AssignedEmployeeID  { get; set; }
        public int SupplierID { get; set; }
        public int EmployeeID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
