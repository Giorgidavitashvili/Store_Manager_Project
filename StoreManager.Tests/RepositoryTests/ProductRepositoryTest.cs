using StoreManager.Dto;

namespace StoreManager.Tests.RepositoryTests
{
    [TestFixture]
    public class ProductTests : TestsBase
    {
        [Test]
        public void InsertProduct_ShouldAddProduct()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newProduct = new Product
            {
                CategoryID = 1,
                SupplierID = 1,
                ProductName = "Sample Product",
                Description = null,
                Price = 100,
                IsActive = true,
            };

            int id = _unitOfWork.ProductRepository.Insert(newProduct);
            var product = _unitOfWork.ProductRepository.Get(id);

            Assert.IsNotNull(product);
            Assert.AreEqual("Sample Product", product?.ProductName);
        }

        public void GetAccountById_ShouldReturnAccount()
        {

        }

        [Test]
        public void UpdateProduct_ShouldModifyProduct()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingProduct = _unitOfWork.ProductRepository.Get(1);
            Assert.IsNotNull(existingProduct);

            string updatedProductName = $"Updated {existingProduct!.ProductName}";

            existingProduct.ProductName = updatedProductName;
            _unitOfWork.ProductRepository.Update(existingProduct);

            var updatedProduct = _unitOfWork.ProductRepository.Get(1);
            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(updatedProductName, updatedProduct!.ProductName);
        }

        [Test]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingProduct = _unitOfWork.ProductRepository.Get(2);
            Assert.IsNotNull(existingProduct);

            _unitOfWork.ProductRepository.Delete(existingProduct.ProductID);

            var deletedProduct = _unitOfWork.ProductRepository.Get(2);
            Assert.IsNull(deletedProduct);
        }
    }
}

