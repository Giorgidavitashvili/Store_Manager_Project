namespace StoreManager.Dto
{
    public sealed class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
