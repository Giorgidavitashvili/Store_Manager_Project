using StoreManager.Dto;
using NUnit.Framework;
using System;

namespace StoreManager.Tests.RepositoryTests
{
    [TestFixture]
    public class EmployeeTests : TestsBase
    {
        [Test]
        public void InsertEmployee_ShouldAddEmployee()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newEmployee = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                ReportTo = 1,
                IsActive = true
            };

            int id = _unitOfWork.EmployeeRepository.Insert(newEmployee);
            var employee = _unitOfWork.EmployeeRepository.Get(id);

            Assert.IsNotNull(employee);
            Assert.That(employee?.FirstName, Is.EqualTo("John"));
            Assert.That(employee?.LastName, Is.EqualTo("Doe"));
        }

        [Test]
        public void UpdateEmployee_ShouldModifyEmployee()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingEmployee = _unitOfWork.EmployeeRepository.Get(1);
            Assert.IsNotNull(existingEmployee);

            string updatedLastName = $"Updated {existingEmployee!.LastName}";

            existingEmployee.LastName = updatedLastName;
            _unitOfWork.EmployeeRepository.Update(existingEmployee);

            var updatedEmployee = _unitOfWork.EmployeeRepository.Get(1);
            Assert.IsNotNull(updatedEmployee);
            Assert.That(updatedEmployee!.LastName, Is.EqualTo(updatedLastName));
        }

        [Test]
        public void DeleteEmployee_ShouldRemoveEmployee()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingEmployee = _unitOfWork.EmployeeRepository.Get(2);
            Assert.IsNotNull(existingEmployee);

            _unitOfWork.EmployeeRepository.Delete(existingEmployee!.EmployeeID);
            var deletedEmployee = _unitOfWork.EmployeeRepository.Get(2);
            Assert.IsNull(deletedEmployee);
        }

    }
}

