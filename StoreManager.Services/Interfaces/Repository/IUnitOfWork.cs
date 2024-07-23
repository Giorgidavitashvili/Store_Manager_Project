namespace StoreManager.Services.Interfaces.Repository;

public interface IUnitOfWork
{
    IAccountRepository AccountRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IOrderRepository OrderRepository { get; }
    IPermissionRepository PermissionRepository { get; }
    IPriceHistoryRepository PriceHistoryRepository { get; }
    IProductQuantityRepository ProductQuantityRepository { get; }
    IProductRepository ProductRepository { get; }
    IRoleRepository RoleRepository { get; }
    ISupplierRepository SupplierRepository { get; }
    ISupplierTransactionRepository SupplierTransactionRepository { get; }

    void OpenConnection();
    void CloseConnection();
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}