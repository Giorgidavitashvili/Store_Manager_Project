namespace StoreManager.Dto
{
    public sealed class Permission
    {
        public int PermissionID { get; set; }
        public string PermissionName { get; set; } = null!;
        public string Code { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
