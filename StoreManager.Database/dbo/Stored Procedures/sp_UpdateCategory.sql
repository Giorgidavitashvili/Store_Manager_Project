create procedure sp_UpdateCategories
	@CategoryName nvarchar(50),
	@CategoryID int
as
begin
	update Categories
		set CategoryName = @CategoryName,
			UpdateDate = GETDATE()
		where CategoryID = @CategoryID;
	return 0;
end