using StoreManager.Dto;
using Microsoft.Data.SqlClient;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class ProductQuantityRepository : RepositoryBase<ProductQuantity>, IProductQuantityRepository
    {
        public ProductQuantityRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}