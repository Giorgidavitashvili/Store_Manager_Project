using Microsoft.Data.SqlClient;
using StoreManager.Dto;

namespace StoreManager.Tests.RepositoryTests
{
    public class PermissionTests : TestsBase
    {
        [Test]
        public void InsertPermission_ShouldAddPermission()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newPermission = new Permission
            {
                PermissionName = "New Permission",
                Code = "Code"
            };

            int id = _unitOfWork.PermissionRepository.Insert(newPermission);
            var permission = _unitOfWork.PermissionRepository.Get(id);

            Assert.IsNotNull(permission);
            Assert.AreEqual("New Permission", permission?.PermissionName);
        }

        [Test]
        public void InsertPermission_ShouldNotAddPermission()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newPermission = new Permission
            {
                PermissionName = null,
                IsActive = true,
            };

            Assert.Throws<SqlException>(() => _unitOfWork.PermissionRepository.Insert(newPermission));
        }


        [Test]
        public void UpdatePermission_ShouldModifyPermission()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingPermission = _unitOfWork.PermissionRepository.Get(1);
            Assert.IsNotNull(existingPermission);

            string updatedPermissionName = $"Updated {existingPermission!.PermissionName}";

            existingPermission!.PermissionName = updatedPermissionName;
            _unitOfWork.PermissionRepository.Update(existingPermission);

            var updatedPermission = _unitOfWork.PermissionRepository.Get(1);
            Assert.IsNotNull(updatedPermission);
            Assert.AreEqual(updatedPermissionName, updatedPermission!.PermissionName);
        }

        [Test]
        public void UpdatePermission_ShouldNotModifyPermission()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingPermission = _unitOfWork.PermissionRepository.Get(1);
            Assert.IsNotNull(existingPermission);

            existingPermission.Code = null;

            Assert.Throws<SqlException>(() => _unitOfWork.PermissionRepository.Update(existingPermission));

            var notUpdatedPermission = _unitOfWork.PermissionRepository.Get(1);
            Assert.IsNotNull(notUpdatedPermission);
            Assert.AreNotEqual(null, notUpdatedPermission.Code);
        }


        [Test]
        public void DeletePermission_ShouldRemovePermission()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingPermission = _unitOfWork.PermissionRepository.Get(2);
            Assert.IsNotNull(existingPermission);

            _unitOfWork.PermissionRepository.Delete(existingPermission!.PermissionID);
            var deletedPermission = _unitOfWork.PermissionRepository.Get(2);
            Assert.IsNull(deletedPermission);
        }
    }
}
