using Microsoft.Data.SqlClient;
using Role = StoreManager.Dto.Role;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}