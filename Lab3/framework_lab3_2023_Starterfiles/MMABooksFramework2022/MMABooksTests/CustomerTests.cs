using NUnit.Framework;

using MMABooksBusiness;
using MMABooksProps;
using MMABooksDB;

using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;

using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace MMABooksTests
{
    internal class CustomerTests
    {
        [SetUp]
        public void TestResetDatabase()
        {
            CustomerDB db = new CustomerDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetCustomer1Data";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
            command.CommandText = "usp_testingResetCustomer2Data";
            db.RunNonQueryProcedure(command);
        }
        [Test]
        public void TestNewCustomerConstructor()
        {
            // not in Data Store - no code
            Customer c = new Customer();
            Assert.AreEqual(0, c.CustomerID);
            Assert.AreEqual(string.Empty, c.Name);
            Assert.IsTrue(c.IsNew);
            Assert.IsFalse(c.IsValid);
        }
        [Test]
        public void TestRetrieveFromDataStoreContructor()
        {
            // retrieves from Data Store
            Customer c = new Customer(1);
            Assert.AreEqual(1, c.CustomerID);
            Assert.IsTrue(c.Name.Length > 0);
            Assert.IsFalse(c.IsNew);
            Assert.IsTrue(c.IsValid);
        }
        [Test]
        public void TestSaveToDataStore()
        {
            Customer c = new Customer();
            c.Name = "Test Customer";
            c.Address = "123 Test St.";
            c.City = "Testville";
            c.State = "OR";
            c.ZipCode = "12345";
            c.Save();
            Customer c2 = new Customer(c.CustomerID);
            Assert.AreEqual(c.CustomerID, c2.CustomerID);
            Assert.AreEqual(c.Name, c2.Name);
            Assert.AreEqual(c.Address, c2.Address);
            Assert.AreEqual(c.City, c2.City);
            Assert.AreEqual(c.State, c2.State);
            Assert.AreEqual(c.ZipCode, c2.ZipCode);
        }
        [Test]
        public void TestInvalidZipCode()
        {
            Customer c = new Customer();
            c.Name = "Test Customer";
            c.Address = "123 Test St.";
            c.City = "Testville";
            c.State = "OR";
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "1234");
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "1234567890123456");
        }
        [Test]
        public void TestUpdate()
        {
            Customer c = new Customer(1);
            string originalName = c.Name;
            c.Name = "Updated Name";
            c.Save();
            Customer c2 = new Customer(1);
            Assert.AreEqual("Updated Name", c2.Name);
        }
        [Test]
        public void TestDelete()
        {
            Customer c = new Customer(1);
            c.Delete();
            c.Save();
            Assert.Throws<Exception>(() => new Customer(1));
        }
        [Test]
        public void TestConcurrencyIssue()
        {
            Customer c1 = new Customer(1);
            Customer c2 = new Customer(1);
            c1.Name = "Updated first";
            c1.Save();
            c2.Name = "Updated second";
            Assert.Throws<Exception>(() => c2.Save());
        }
        [Test]
        public void TestGetList()
        {
            Customer c = new Customer();
            List<Customer> customers = (List<Customer>)c.GetList();
            Assert.AreEqual(696, customers.Count);
            Assert.AreEqual("Molunguri, A", customers[0].Name);
        }
        [Test]
        public void TestNoRequiredPropertiesSet()
        {
            Customer c = new Customer();
            Assert.Throws<Exception>(() => c.Save());
        }

        [Test]
        public void TestSomeRequiredPropertiesNotSet()
        {
            Customer c = new Customer();
            c.Name = "Test Customer";
            c.Address = "123 Test St.";
            Assert.Throws<Exception>(() => c.Save());
        }
        [Test]
        public void TestAllRequiredPropertiesSet()
        {
            Customer c = new Customer();
            c.Name = "Test Customer";
            c.Address = "123 Test St.";
            c.City = "Testville";
            c.State = "OR";
            c.ZipCode = "12345";
            Assert.DoesNotThrow(() => c.Save());
        }
        [Test]
        public void TestInvalidPropertySet()
        {
            Customer c = new Customer();
            c.Name = "Test Customer";
            c.Address = "123 Test St.";
            c.City = "Testville";
            c.State = "OR";
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "12");
        }
    }
}