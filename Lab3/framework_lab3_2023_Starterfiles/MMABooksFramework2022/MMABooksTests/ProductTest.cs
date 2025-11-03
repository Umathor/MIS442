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
    internal class ProductTest
    {
        [SetUp]
        public void TestResetDatabase()
        {
            ProductDB db = new ProductDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetProductData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestNewProductConstructor()
        {
            // not in Data Store - no code
            Product p = new Product();
            Assert.AreEqual(0, p.ProductID);
            Assert.AreEqual(string.Empty, p.ProductCode);
            Assert.IsTrue(p.IsNew);
            Assert.IsFalse(p.IsValid);
        }
        [Test]
        public void TestRetrieveFromDataStoreContructor()
        {
            // retrieves from Data Store
            Product p = new Product(1);
            Assert.AreEqual(1, p.ProductID);
            Assert.IsTrue(p.ProductCode.Length > 0);
            Assert.IsFalse(p.IsNew);
            Assert.IsTrue(p.IsValid);
        }
        [Test]
        public void TestSaveToDataStore()
        {
            Product p = new Product();
            p.ProductCode = "TESTCODE";
            p.Description = "Test Product Description";
            p.UnitPrice = 9.99m;
            p.OnHandQuantity = 100;
            p.Save();
            Product p2 = new Product(p.ProductID);
            Assert.AreEqual(p.ProductID, p2.ProductID);
            Assert.AreEqual("TESTCODE", p2.ProductCode);
            Assert.AreEqual("Test Product Description", p2.Description);
            Assert.AreEqual(9.99m, p2.UnitPrice);
            Assert.AreEqual(100, p2.OnHandQuantity);
        }
        [Test]
        public void TestSaveInvalidProduct()
        {
            Product p = new Product();
            p.ProductCode = ""; // Invalid - empty code
            p.Description = "Test Product Description";
            p.UnitPrice = 9.99m;
            p.OnHandQuantity = 100;
            Assert.Throws<Exception>(() => p.Save());
        }
        [Test]
        public void TestConcurrencyIssue()
        {
            Product p1 = new Product(1);
            Product p2 = new Product(1);
            p1.Description = "Updated first";
            p1.Save();
            p2.Description = "Updated second";
            Assert.Throws<Exception>(() => p2.Save());
        }
        [Test]
        public void TestUpdate()
        {
            Product p = new Product(1);
            p.Description = "Edited Description";
            p.Save();
            Product p2 = new Product(1);
            Assert.AreEqual("Edited Description", p2.Description);
        }
        [Test]
        public void TestDelete()
        {
            Product p = new Product(2);
            p.Delete();
            p.Save();
            Assert.Throws<Exception>(() => new Product(2));
        }
        [Test]
        public void TestGetList()
        {
            Product p = new Product();
            List<Product> list = (List<Product>)p.GetList();
            Assert.AreEqual(16, list.Count);
            Assert.AreEqual("A4CS", list[0].ProductCode);
        }
        [Test]
        public void TestNoRequiredPropertiesSet()
        {
            Product p = new Product();
            Assert.Throws<Exception>(() => p.Save());
        }
        [Test]
        public void TestSomeRequiredPropertiesSet()
        {
            Product p = new Product();
            p.ProductCode = "PARTIAL";
            p.UnitPrice = 10.00m;
            Assert.Throws<Exception>(() => p.Save());
        }
        [Test]
        public void TestAllRequiredPropertiesSet()
        {
            Product p = new Product();
            p.ProductCode = "COMPLETE";
            p.Description = "Complete Product";
            p.UnitPrice = 15.00m;
            p.OnHandQuantity = 50;
            Assert.DoesNotThrow(() => p.Save());
        }
        [Test]
        public void TestInvalidUnitPrice()
        {
            Product p = new Product();
            Assert.Throws<ArgumentOutOfRangeException>(() => p.UnitPrice = -5.00m);
        }
        [Test]
        public void TestInvalidOnHandQuantity()
        {
            Product p = new Product();
            Assert.Throws<ArgumentOutOfRangeException>(() => p.OnHandQuantity = -10);
        }
    }
}
