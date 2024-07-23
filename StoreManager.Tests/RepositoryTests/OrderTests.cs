using StoreManager.Dto;
using NUnit.Framework;
using System;

namespace StoreManager.Tests.RepositoryTests
{
    [TestFixture]
    public class OrderTests : TestsBase
    {
        [Test]
        public void InsertOrder_ShouldAddOrder()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newOrder = new Order
            {
                CustomerID = 1,
                EmployeeID = 1,
                Status = 1,
                OrderDate = DateTime.Now,
                Description = "New order description"
            };

            int id = _unitOfWork.OrderRepository.Insert(newOrder);
            var order = _unitOfWork.OrderRepository.Get(id);

            Assert.IsNotNull(order);
            Assert.AreEqual(1, order?.CustomerID);
            Assert.AreEqual(1, order?.EmployeeID);
        }

        [Test]
        public void UpdateOrder_ShouldModifyOrder()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingOrder = _unitOfWork.OrderRepository.Get(1);
            Assert.IsNotNull(existingOrder);

            string updatedDescription = $"Updated {existingOrder!.Description}";

            existingOrder.Description = updatedDescription;
            _unitOfWork.OrderRepository.Update(existingOrder);

            var updatedOrder = _unitOfWork.OrderRepository.Get(1);
            Assert.IsNotNull(updatedOrder);
            Assert.AreEqual(updatedDescription, updatedOrder!.Description);
        }

        [Test]
        public void DeleteOrder_ShouldRemoveOrder()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingOrder = _unitOfWork.OrderRepository.Get(2);
            Assert.IsNotNull(existingOrder);

            _unitOfWork.OrderRepository.Delete(existingOrder!.OrderID);
            var deletedOrder = _unitOfWork.OrderRepository.Get(2);
            Assert.IsNull(deletedOrder);
        }
    }
}

