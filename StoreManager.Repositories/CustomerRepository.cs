using Microsoft.Data.SqlClient;
using StoreManager.Dto;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}
