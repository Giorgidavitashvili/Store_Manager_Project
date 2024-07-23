using StoreManager.Dto;
using Microsoft.Data.SqlClient;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}
