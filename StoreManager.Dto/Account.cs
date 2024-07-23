namespace StoreManager.Dto
{
    public sealed class Account
    {
        public int AccountID { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int EmployeeID { get; set; }

    }
}
