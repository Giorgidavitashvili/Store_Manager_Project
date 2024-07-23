using Microsoft.Data.SqlClient;
using StoreManager.Configuration;
using StoreManager.Repositories;

namespace StoreManager.Tests;

public abstract class TestsBase
{
    protected UnitOfWork? _unitOfWork;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var cleanupScript =
             "DELETE FROM Orders; DBCC CHECKIDENT(Orders, RESEED, 0); " +
             "DELETE FROM Accounts;  DBCC CHECKIDENT(Accounts, RESEED, 0)" +
             "DELETE FROM Employees; DBCC CHECKIDENT(Employees, RESEED, 0); " +
             "DELETE FROM Products; DBCC CHECKIDENT(Products, RESEED, 0); " +
             "DELETE FROM Categories; DBCC CHECKIDENT(Categories, RESEED, 0); " +
             "DELETE FROM Suppliers; DBCC CHECKIDENT(Suppliers, RESEED, 0); " +
             "DELETE FROM Customers; DBCC CHECKIDENT(Customers, RESEED, 0); " +
             "DELETE FROM Roles; DBCC CHECKIDENT(Roles, RESEED, 0); " +
             "DELETE FROM Permissions; DBCC CHECKIDENT(Permissions, RESEED, 0);";

        var seedScript =
             "INSERT INTO Categories(CategoryName, IsActive) VALUES('Category 1', 1); " +
             "INSERT INTO Categories(CategoryName, IsActive) VALUES('Category 2', 1); " +
             "INSERT INTO Categories(CategoryName, IsActive) VALUES('Category 3', 0); " +

             "INSERT INTO Suppliers(CompanyName, Country, City, [Address], PostalCode, Phone, IsActive) " +
             "VALUES('Supplier 1', 'Georgia', 'Tbilisi', 'Vazha-Pshavela 15', '0019', '555-555-555', 1); " +
             "INSERT INTO Suppliers(CompanyName, Country, City, [Address], PostalCode, Phone, IsActive) " +
             "VALUES('Supplier 2', 'Georgia', 'Rustavi', 'Vazha-Pshavela 16', '0019', '555-555-555', 1); " +
             "INSERT INTO Suppliers(CompanyName, Country, City, [Address], PostalCode, Phone, IsActive) " +
             "VALUES('Supplier 3', 'Georgia', 'Kutaisi', 'Vazha-Pshavela 15', '0019', '555-555-555', 1); " +

             "INSERT INTO Roles(RoleName, IsActive) VALUES('role 1', 1); " +
             "INSERT INTO Roles(RoleName, IsActive) VALUES('role 2', 1); " +

             "INSERT INTO Permissions(Code, PermissionName, IsActive) VALUES('PR1', 'Permission 1', 1); " +
             "INSERT INTO Permissions(Code, PermissionName, IsActive) VALUES('PR2', 'Permission 2', 1); " +

             "INSERT INTO Products (CategoryID, SupplierID, ProductName, Description, Price, IsActive) " +
             "VALUES (1, 1, 'Laptop', 'High-performance laptop with 16GB RAM and 512GB SSD.', 999.99, 1); " +
             "INSERT INTO Products (CategoryID, SupplierID, ProductName, Description, Price, IsActive) " +
             "VALUES (2, 2, 'Smartphone', 'Latest model smartphone with advanced features.', 799.99, 1); " +
             "INSERT INTO Products (CategoryID, SupplierID, ProductName, Description, Price, IsActive) " +
             "VALUES (3, 3, 'Wireless Headphones', 'Noise-cancelling wireless headphones with long battery life.', 199.99, 1); " +

             "INSERT INTO Customers(FirstName, MiddleName, LastName, Email, Phone, Country, City, CustomerAddress, IsActive) " +
             "VALUES('John', 'A', 'Doe', 'john.doe@example.com', '123-456-7890', 'USA', 'New York', '123 Main St', 1); " +
             "INSERT INTO Customers(FirstName, MiddleName, LastName, Email, Phone, Country, City, CustomerAddress, IsActive) " +
             "VALUES('Jane', 'B', 'Smith', 'jane.smith@example.com', '234-567-8901', 'Canada', 'Toronto', '456 Maple Ave', 1); " +
             "INSERT INTO Customers(FirstName, MiddleName, LastName, Email, Phone, Country, City, CustomerAddress, IsActive) " +
             "VALUES('Alice', NULL, 'Johnson', 'alice.johnson@example.com', '345-678-9012', 'UK', 'London', '789 Oak St', 1); " +

             "INSERT INTO Employees(FirstName, LastName, Email, ReportTo, IsActive) " +
             "VALUES('Employee 1', 'Lastname 1', 'employee1@example.com', NULL, 1); " +
             "INSERT INTO Employees(FirstName, LastName, Email, ReportTo, IsActive) " +
             "VALUES('Employee 2', 'Lastname 2', 'employee2@example.com', 1, 1); " +
             "INSERT INTO Employees(FirstName, LastName, Email, ReportTo, IsActive) " +
             "VALUES('Employee 3', 'Lastname 3', 'employee3@example.com', 1, 0); " +

             "INSERT INTO Accounts(Email, Username, Password, EmployeeID) " +
             "VALUES('test.user1@example.com', 'testuser1', HASHBYTES('SHA2_512', N'testuser1'), 1); " +
             "INSERT INTO Accounts(Email, Username, Password, EmployeeID) " +
             "VALUES('test.user2@example.com', 'testuser2', HASHBYTES('SHA2_512', N'testuser2'), 2); " +
             "INSERT INTO Accounts(Email, Username, Password, IsActive, EmployeeID) " +
             "VALUES('test.user3@example.com', 'testuser3', HASHBYTES('SHA2_512', N'testuser3'), 0, 3); " +

             "INSERT INTO Orders(CustomerID, EmployeeID, Status, OrderDate, Description) " +
             "VALUES(1, 1, 1, GETDATE(), 'Order description 1'); " +
             "INSERT INTO Orders(CustomerID, EmployeeID, Status, OrderDate, Description) " +
             "VALUES(2, 2, 1, GETDATE(), 'Order description 2'); " +
             "INSERT INTO Orders(CustomerID, EmployeeID, Status, OrderDate, Description) " +
             "VALUES(3, 3, 2, GETDATE(), 'Order description 3'); ";

        // ToDo: Add transaction to cleanup and seed the database.
        using var connection = new SqlConnection(ConfigurationManager.ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        // Cleanup the database before running the tests.
        if (!string.IsNullOrWhiteSpace(cleanupScript))
        {
            using var command = new SqlCommand(cleanupScript, connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }

        // Seed the database with test data.
        if (!string.IsNullOrWhiteSpace(seedScript))
        {
            using var command = new SqlCommand(seedScript, connection);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }

        transaction.Commit();
    }

    [SetUp]
    public void Setup()
    {
        _unitOfWork = new UnitOfWork(new SqlConnection(ConfigurationManager.ConnectionString));
    }

    [TearDown]
    public void Teardown()
    {
        _unitOfWork?.Dispose();
    }
}