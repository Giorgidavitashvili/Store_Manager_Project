using StoreManager.Services.Interfaces.Repository;

namespace StoreManager.Services
{
    public interface IEmployeeService
    {
        bool Login(string username, string password);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public bool Login(string username, string password)
        {
            return _unitOfWork.AccountRepository.Login(username, password);
        }
    }
}
