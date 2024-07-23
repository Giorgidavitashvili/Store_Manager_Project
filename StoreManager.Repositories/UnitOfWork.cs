using System.Data;
using Microsoft.Data.SqlClient;
using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IPermissionRepository> _permissionRepository;
        private readonly Lazy<IPriceHistoryRepository> _priceHistoryRepository;
        private readonly Lazy<IProductQuantityRepository> _productQuantityRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<IRoleRepository> _roleRepository;
        private readonly Lazy<ISupplierRepository> _supplierRepository;
        private readonly Lazy<ISupplierTransactionRepository> _supplierTransactionRepository;

        private readonly SqlConnection _connection;
        private SqlTransaction? _transaction;
        private bool _disposed = false;

        public UnitOfWork(SqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(connection, _transaction));
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(connection, _transaction));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(connection, _transaction));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(connection, _transaction));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(connection, _transaction));
            _permissionRepository = new Lazy<IPermissionRepository>(() => new PermissionRepository(connection, _transaction));
            _priceHistoryRepository = new Lazy<IPriceHistoryRepository>(() => new PriceHistoryRepository(connection, _transaction));
            _productQuantityRepository = new Lazy<IProductQuantityRepository>(() => new ProductQuantityRepository(connection, _transaction));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(connection, _transaction));
            _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(connection, _transaction));
            _supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(connection, _transaction));
            _supplierTransactionRepository = new Lazy<ISupplierTransactionRepository>(() => new SupplierTransactionRepository(connection, _transaction));
        }

        public IAccountRepository AccountRepository => _accountRepository.Value;
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;
        public ICustomerRepository CustomerRepository => _customerRepository.Value;
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
        public IOrderRepository OrderRepository => _orderRepository.Value;
        public IPermissionRepository PermissionRepository => _permissionRepository.Value;
        public IPriceHistoryRepository PriceHistoryRepository => _priceHistoryRepository.Value;
        public IProductQuantityRepository ProductQuantityRepository => _productQuantityRepository.Value;
        public IProductRepository ProductRepository => _productRepository.Value;
        public IRoleRepository RoleRepository => _roleRepository.Value;
        public ISupplierRepository SupplierRepository => _supplierRepository.Value;
        public ISupplierTransactionRepository SupplierTransactionRepository => _supplierTransactionRepository.Value;

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction already started");
            }
            _transaction = _connection.BeginTransaction();

        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction not started");
            }
            _transaction?.Commit();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction not started");
            }
            _transaction?.Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
            }

            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}