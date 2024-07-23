namespace StoreManager.Dto
{
	public sealed class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; } = null!;
		public bool IsActive { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
