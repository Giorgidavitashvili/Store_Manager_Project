using Microsoft.Data.SqlClient;
using StoreManager.Dto;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}