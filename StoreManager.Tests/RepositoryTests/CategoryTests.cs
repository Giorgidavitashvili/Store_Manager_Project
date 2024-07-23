using Microsoft.Data.SqlClient;
using StoreManager.Dto;

namespace StoreManager.Tests.RepositoryTests;

// ToDo: Add negative tests

[TestFixture]
public class CategoryTests : TestsBase
{
    [Test]
    [TestCase("Test Category 1")]
    [TestCase("Test Category 2")]
    [TestCase("Test Category 3")]
    [TestCase("Test Category 4")]
    [TestCase("Test Category 5")]
    public void InsertCategory_ShouldAddCategory(string testCategoryName)
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var newCategory = new Category
        {
            CategoryName = testCategoryName,
            IsActive = true
        };

        int id = _unitOfWork.CategoryRepository.Insert(newCategory);
        var category = _unitOfWork.CategoryRepository.Get(id);

        Assert.IsNotNull(category);
        Assert.AreEqual(testCategoryName, category?.CategoryName);
    }

    [Test]
    public void InsertCategory_ShouldNotAddCategory()
    {
        if (_unitOfWork == null) throw new ArgumentNullException(nameof(_unitOfWork));

        var newCategory = new Category
        {
            CategoryName = null,
            IsActive = true
        };

        Assert.Throws<SqlException>(() => _unitOfWork.CategoryRepository.Insert(newCategory));
    }

    //[Test]
    public void GetAccountById_ShouldReturnAccount()
    {

    }

    [Test]
    public void UpdateCategory_ShouldModifyCategory()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var existingCategory = _unitOfWork.CategoryRepository.Get(1);
        Assert.IsNotNull(existingCategory);

        string updatedCategoryName = $"Updated {existingCategory!.CategoryName}";

        existingCategory!.CategoryName = updatedCategoryName;
        _unitOfWork.CategoryRepository.Update(existingCategory);

        var updatedCategory = _unitOfWork.CategoryRepository.Get(1);
        Assert.IsNotNull(updatedCategory);
        Assert.AreEqual(updatedCategoryName, updatedCategory!.CategoryName);
    }

    [Test]
    public void UpdateCategory_ShouldNotModifyCategory()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var existingCategory = _unitOfWork.CategoryRepository.Get(1);
        Assert.IsNotNull(existingCategory);

        string originalCategoryName = existingCategory!.CategoryName;

        existingCategory.CategoryName = null;

        Assert.Throws<SqlException>(() => _unitOfWork.CategoryRepository.Update(existingCategory));

        var notUpdatedCategory = _unitOfWork.CategoryRepository.Get(1);
        Assert.IsNotNull(notUpdatedCategory);
        Assert.AreEqual(originalCategoryName, notUpdatedCategory!.CategoryName);
    }

    [Test]
    public void DeleteCategory_ShouldRemoveCategory()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var existingCategory = _unitOfWork.CategoryRepository.Get(2);
        Assert.IsNotNull(existingCategory);

        _unitOfWork.CategoryRepository.Delete(existingCategory!.CategoryID);
        var deletedCategory = _unitOfWork.CategoryRepository.Get(2);
        Assert.IsNull(deletedCategory);
    }

    [Test]
    public void DeleteCategory_ShouldNotRemoveNonExsistingCategory()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        Assert.Throws<SqlException>(() => _unitOfWork.CategoryRepository.Delete(-1));
    }
}
