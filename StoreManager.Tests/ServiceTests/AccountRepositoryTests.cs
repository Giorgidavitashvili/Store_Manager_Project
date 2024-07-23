using StoreManager.Dto;
using NUnit.Framework;
using System;
using StoreManager.Services;

namespace StoreManager.Tests.ServiceTests
{
	[TestFixture]
	public class EmployeeServiceTests : TestsBase
	{
		[Test]
		public void LoginTest_ShouldLoginValidUser()
		{
			EmployeeService employeeService =
				new EmployeeService(_unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork)));

			Assert.IsTrue(employeeService.Login("testuser1", "testuser1"));
		}

		[Test]
		public void LoginTest_ShouldNotLoginWrongUsername()
		{
			EmployeeService employeeService =
				new EmployeeService(_unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork)));

			Assert.IsFalse(employeeService.Login("wronguser", "testuser1"));
		}

		[Test]
		public void LoginTest_ShouldNotLoginWrongPassword()
		{
			EmployeeService employeeService =
				new EmployeeService(_unitOfWork ?? throw new ArgumentNullException(nameof(_unitOfWork)));

			Assert.IsFalse(employeeService.Login("testuser1", "wrongpassowrd"));
		}
	}
}

