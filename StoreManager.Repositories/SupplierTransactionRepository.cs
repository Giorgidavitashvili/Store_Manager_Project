using Microsoft.Data.SqlClient;
using StoreManager.Dto;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class SupplierTransactionRepository : RepositoryBase<SupplierTransaction>, ISupplierTransactionRepository
    {
        public SupplierTransactionRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}