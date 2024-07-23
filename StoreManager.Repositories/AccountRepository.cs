using Dapper;
using Microsoft.Data.SqlClient;
using StoreManager.Dto;
using StoreManager.Services.Interfaces.Repository;
using System.Data;

namespace StoreManager.Repositories
{
    internal sealed class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }

        public bool Login(string username, string password)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Username", username);
            parameters.Add("@Password", password);

            return _connection.QuerySingle<bool>(
                "sp_AccountLogin",
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction
            );
        }
    }
}