using Microsoft.Data.SqlClient;
using StoreManager.Dto;


namespace StoreManager.Tests.RepositoryTests
{
    [TestFixture]
    public class RoleTests : TestsBase
    {
        [Test]
        public void InsertRole_ShouldAddRole()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newRole = new Role
            {
                RoleName = "New role",
                Description = "Description"
            };

            int id = _unitOfWork.RoleRepository.Insert(newRole);
            var role = _unitOfWork.RoleRepository.Get(id);

            Assert.IsNotNull(role);
            Assert.AreEqual("New role", role?.RoleName);
        }

        [Test]
        public void InsertRole_ShouldNotAddRole()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var newRole = new Role
            {
                RoleName = null,
                Description = "Description"
            };

            Assert.Throws<SqlException>(() => _unitOfWork.RoleRepository.Insert(newRole));
        }


        [Test]
        public void UpdateRole_ShouldModifyRole()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingRole = _unitOfWork.RoleRepository.Get(1);
            Assert.IsNotNull(existingRole);

            string updatedRoleName = $"Updated {existingRole!.RoleName}";

            existingRole!.RoleName = updatedRoleName;
            _unitOfWork.RoleRepository.Update(existingRole);

            var updatedRole = _unitOfWork.RoleRepository.Get(1);
            Assert.IsNotNull(updatedRole);
            Assert.AreEqual(updatedRoleName, updatedRole!.RoleName);
        }

        [Test]
        public void UpdateRole_ShouldNotModifyRole()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingRole = _unitOfWork.RoleRepository.Get(1);
            Assert.IsNotNull(existingRole);

            existingRole.RoleName = null;

            Assert.Throws<SqlException>(() => _unitOfWork.RoleRepository.Update(existingRole));

            var notUpdatedRole = _unitOfWork.RoleRepository.Get(1);
            Assert.IsNotNull(notUpdatedRole);
            Assert.AreNotEqual(null, notUpdatedRole.RoleName);
        }


        [Test]
        public void DeleteRole_ShouldRemoveRole()
        {
            if (_unitOfWork == null) throw new ArgumentNullException("UnitOfWork is null.");

            var existingRole = _unitOfWork.RoleRepository.Get(2);
            Assert.IsNotNull(existingRole);

            _unitOfWork.RoleRepository.Delete(existingRole!.RoleID);
            var deletedRole = _unitOfWork.RoleRepository.Get(2);
            Assert.IsNull(deletedRole);
        }
    }
}
