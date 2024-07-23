using Microsoft.Data.SqlClient;
using StoreManager.Dto;

namespace StoreManager.Tests.RepositoryTests;

[TestFixture]
public class SupplierTests : TestsBase
{
    [Test]
    public void InsertSupplier_ShouldAddSupplier()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var newSupplier = new Supplier
        {
            CompanyName = "New supplier",
            Country = "Georgia",
            City = "Tbilisi",
            Address = "Vazha-Pshavela 15",
            PostalCode = "0019",
            Phone = "555-555-555",
            IsActive = true
        };

        int id = _unitOfWork.SupplierRepository.Insert(newSupplier);
        var supplier = _unitOfWork.SupplierRepository.Get(id);

        Assert.IsNotNull(supplier);
        Assert.AreEqual("New supplier", supplier?.CompanyName);
    }

    [Test]
    public void InsertSupplier_ShouldNotAddSupplier()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var newSupplier = new Supplier
        {
            CompanyName = null,
            IsActive = true
        };

        Assert.Throws<SqlException>(() => _unitOfWork.SupplierRepository.Insert(newSupplier));
    }


    [Test]
    public void UpdateSupplier_ShouldModifySupplier()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var existingSupplier = _unitOfWork.SupplierRepository.Get(1);
        Assert.IsNotNull(existingSupplier);

        string updatedSupplierName = $"Updated {existingSupplier!.CompanyName}";

        existingSupplier!.CompanyName = updatedSupplierName;
        _unitOfWork.SupplierRepository.Update(existingSupplier);

        var updatedSupplier = _unitOfWork.SupplierRepository.Get(1);
        Assert.IsNotNull(updatedSupplier);
        Assert.AreEqual(updatedSupplierName, updatedSupplier!.CompanyName);
    }

    [Test]
    public void UpdateSupplier_ShouldNotModifySupplier()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var existingSupplier = _unitOfWork.SupplierRepository.Get(1);
        Assert.IsNotNull(existingSupplier);

        existingSupplier.City = null;

        Assert.Throws<SqlException>(() => _unitOfWork.SupplierRepository.Update(existingSupplier));

        var notUpdatedSupplier = _unitOfWork.SupplierRepository.Get(1);
        Assert.IsNotNull(notUpdatedSupplier);
        Assert.AreNotEqual(null, notUpdatedSupplier.City);
    }


    [Test]
    public void DeleteSupplier_ShouldRemoveSupplier()
    {
        if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

        var existingSupplier = _unitOfWork.SupplierRepository.Get(2);
        Assert.IsNotNull(existingSupplier);

        _unitOfWork.SupplierRepository.Delete(existingSupplier!.SupplierID);
        var deletedSupplier = _unitOfWork.SupplierRepository.Get(2);
        Assert.IsNull(deletedSupplier);
    }
}
