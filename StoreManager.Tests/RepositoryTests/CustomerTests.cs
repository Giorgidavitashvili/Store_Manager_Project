using StoreManager.Dto;
using NUnit.Framework;
using System;
using Microsoft.Data.SqlClient;

namespace StoreManager.Tests.RepositoryTests
{
    [TestFixture]
    public class CustomerTests : TestsBase
    {
        [Test]
        public void InsertCustomer_ShouldAddCustomer()
        {
            if (_unitOfWork == null) throw new ArgumentNullException(nameof(_unitOfWork));

            var newCustomer = new Customer
            {
                FirstName = "Nika",
                MiddleName = "",
                LastName = "Ninoshvili",
                Email = ".Nikaninoshvili@example.com",
                Phone = "1234567890",
                Country = "Georgia",
                City = "Tbilisi",
                CustomerAddress = "Vazha pshavela 22",
                IsActive = true
            };

            int id = _unitOfWork.CustomerRepository.Insert(newCustomer);
            var customer = _unitOfWork.CustomerRepository.Get(id);

            Assert.IsNotNull(customer);
            Assert.AreEqual("Nika", customer?.FirstName);
        }

        [Test]
        public void InsertCustomer_ShouldNotAddCustomer()
        {
            if (_unitOfWork == null) throw new ArgumentNullException(nameof(_unitOfWork));

            var newCustomer = new Customer
            {
                FirstName = null,
                IsActive = true
            };

            Assert.Throws<SqlException>(() => _unitOfWork.CustomerRepository.Insert(newCustomer));
        }


        //[Test]
        public void GetAccountById_ShouldReturnAccount()
        {
            //var account = new Account
            //{
            //    Username = "testuser",
            //    Password = "hashedpassword",
            //    UpdateDate = DateTime.Now
            //};

            //_unitOfWork.AccountRepository.Add(account);
            //_unitOfWork.Save();

            //var retrievedAccount = _unitOfWork.AccountRepository.GetById(account.Id);

            //Assert.IsNotNull(retrievedAccount);
            //Assert.AreEqual("testuser", retrievedAccount.Username);
        }

        [Test]
        //[Explicit]
        public void UpdateCustomer_ShouldModifyCustomer()
        {
            if (_unitOfWork == null) throw new ArgumentNullException(nameof(_unitOfWork));

            var existingCustomer = _unitOfWork.CustomerRepository.Get(1);
            Assert.IsNotNull(existingCustomer);

            string updatedLastName = $"Updated {existingCustomer!.LastName}";

            existingCustomer.LastName = updatedLastName;
            _unitOfWork.CustomerRepository.Update(existingCustomer);

            var updatedCustomer = _unitOfWork.CustomerRepository.Get(1);
            Assert.IsNotNull(updatedCustomer);
            Assert.AreEqual(updatedLastName, updatedCustomer!.LastName);
        }

        [Test]
        public void UpdateCustomer_ShouldNotModifyCustomer()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingCustomer = _unitOfWork.CustomerRepository.Get(1);
            Assert.IsNotNull(existingCustomer);

            existingCustomer.LastName = null;

            Assert.Throws<SqlException>(() => _unitOfWork.CustomerRepository.Update(existingCustomer));

            var notUpdatedCustomer = _unitOfWork.CustomerRepository.Get(1);
            Assert.IsNotNull(notUpdatedCustomer);
            Assert.AreNotEqual(null, notUpdatedCustomer.LastName);
        }


        [Test]
        public void DeleteCustomer_ShouldRemoveCustomer()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingCustomer = _unitOfWork.CustomerRepository.Get(2);
            Assert.IsNotNull(existingCustomer);

            _unitOfWork.CustomerRepository.Delete(existingCustomer!.CustomerID);
            var deletedCustomer = _unitOfWork.CustomerRepository.Get(2);
            Assert.IsNull(deletedCustomer);
        }
    }
}
