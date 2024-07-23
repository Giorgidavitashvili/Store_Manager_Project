using StoreManager.Dto;
using Microsoft.Data.SqlClient;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}