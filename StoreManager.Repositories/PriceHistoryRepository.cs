﻿using StoreManager.Dto;
using Microsoft.Data.SqlClient;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    internal sealed class PriceHistoryRepository : RepositoryBase<PriceHistory>, IPriceHistoryRepository
    {
        public PriceHistoryRepository(SqlConnection connection, SqlTransaction? transaction = null) : base(connection, transaction) { }
    }
}