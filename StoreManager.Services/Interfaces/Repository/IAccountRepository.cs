using StoreManager.Dto;

namespace StoreManager.Services.Interfaces.Repository;

public interface IAccountRepository : IRepositoryBase<Account>
{
    bool Login(string username, string password);
}