using StoreManager.Dto;
using NUnit.Framework;
using System;

namespace StoreManager.Tests.RepositoryTests
{
    [TestFixture]
    public class AccountTests : TestsBase
    {
        [Test]
        public void InsertAccount_ShouldAddAccount()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newAccount = new Account
            {
                Email = "new.user@example.com",
                Username = "newuser",
                Password = "hashedpassword",
                EmployeeID = 1
            };

            int id = _unitOfWork.AccountRepository.Insert(newAccount);
            var account = _unitOfWork.AccountRepository.Get(id);

            Assert.IsNotNull(account);
            Assert.AreEqual("newuser", account?.Username);
        }

        [Test]
        public void UpdateAccount_ShouldModifyAccount()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingAccount = _unitOfWork.AccountRepository.Get(1);
            Assert.IsNotNull(existingAccount);

            string updatedUsername = $"Updated{existingAccount!.Username}";

            existingAccount.Username = updatedUsername;
            _unitOfWork.AccountRepository.Update(existingAccount);

            var updatedAccount = _unitOfWork.AccountRepository.Get(1);
            Assert.IsNotNull(updatedAccount);
            Assert.AreEqual(updatedUsername, updatedAccount!.Username);
        }

        [Test]
        public void DeleteAccount_ShouldRemoveAccount()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingAccount = _unitOfWork.AccountRepository.Get(2);
            Assert.IsNotNull(existingAccount);

            _unitOfWork.AccountRepository.Delete(existingAccount!.AccountID);
            var deletedAccount = _unitOfWork.AccountRepository.Get(2);
            Assert.IsNull(deletedAccount);
        }

    }
}

