using Microsoft.Data.SqlClient;
using StoreManager.Dto;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}