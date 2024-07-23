using StoreManager.Dto;
using Microsoft.Data.SqlClient;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}
