using Dapper;
using Microsoft.Data.SqlClient;
using StoreManager.Extensions;
using System.Data;

namespace StoreManager.Repositories
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        protected readonly SqlConnection _connection;
        protected readonly SqlTransaction? _transaction;
        private readonly string _typeName;
        private readonly string _typePluralName;

        protected RepositoryBase(SqlConnection connection, SqlTransaction? transaction)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _transaction = transaction;
            _typeName = typeof(T).Name;
            _typePluralName = typeof(T).Name.Pluralize();
        }

        public T? Get(int id)
        {
            DynamicParameters parameters = new();
            parameters.Add($"@{_typeName}ID", id);

            return _connection.QuerySingleOrDefault<T>(
                $"sp_Get{_typeName}",
                parameters,
                commandType: CommandType.StoredProcedure, 
                transaction: _transaction
            );
        }

        public IEnumerable<T> Get()
        {
            DynamicParameters parameters = new();
            return _connection.Query<T>(
                $"sp_Get{_typePluralName}",
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction
            );
        }

        public virtual int Insert(T record)
        {
            DynamicParameters parameters = GetInsertParameters(record);
            parameters.Add($"@{_typeName}Id", DbType.Int32, direction: ParameterDirection.Output);

            _connection.Execute(
                $"sp_Insert{_typeName}",
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction
            );

            return parameters.Get<int>($"@{_typeName}Id");
        }

        public virtual void Update(T record)
        {
            DynamicParameters parameters = GetUpdateParameters(record);

            _connection.Execute(
                $"sp_Update{_typeName}",
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction
            );
        }

        public virtual void Delete(object id)
        {
            DynamicParameters parameters = new();
            parameters.Add($"@{_typeName}ID", id);

            _connection.Execute(
                $"sp_Delete{_typeName}",
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction
            );
        }

        private string[] IgnoredInsertProperties =>
            new[] { $"{_typeName}ID", "IsActive", "CreateDate", "UpdateDate" };

        private string[] IgnoredUpdateProperties =>
            new[] { "IsActive", "CreateDate", "UpdateDate" };

        private DynamicParameters GetInsertParameters(T record)
        {
            DynamicParameters parameters = new();
            foreach (var property in typeof(T).GetProperties())
            {
                if (IgnoredInsertProperties.Contains(property.Name))
                {
                    continue;
                }

                parameters.Add($"@{property.Name}", property.GetValue(record));
            }
            return parameters;
        }

        private DynamicParameters GetUpdateParameters(T record)
        {
            DynamicParameters parameters = new();
            foreach (var property in typeof(T).GetProperties())
            {
                if (IgnoredUpdateProperties.Contains(property.Name))
                {
                    continue;
                }

                parameters.Add($"@{property.Name}", property.GetValue(record));
            }
            return parameters;
        }
    }
}