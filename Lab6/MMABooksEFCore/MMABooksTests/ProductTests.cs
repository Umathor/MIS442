using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using MMABooksEFClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {

        MMABooksContext dbContext;
        Product p;
        List<Product> products;

        [SetUp]
        public void Setup()
        {
            dbContext = new MMABooksContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
            dbContext.Dispose();
        }

        [Test]
        public void GetAllTest()
        {
            // get a list of all of the products ordered by product code
            products = dbContext.Products
                .OrderBy(p => p.ProductCode)
                .ToList();
            Assert.AreEqual(16, products.Count);
            Assert.AreEqual("A4CS", products[0].ProductCode);
            PrintAll(products);
        }

        [Test]
        public void GetByPrimaryKeyTest()
        {
            // get the product whose product code is A4CS
            p = dbContext.Products.Find("A4CS");
            Assert.IsNotNull(p);
            Assert.AreEqual("Murach's ASP.NET 4 Web Programming with C# 2010", p.Description);
            Console.WriteLine(p);
        }

        [Test]
        public void GetUsingWhere()
        {
            // get a list of all of the products that have a unit price of 56.50
            products = dbContext.Products
                .Where(p => p.UnitPrice == 56.50m)
                .OrderBy(p => p.ProductCode)
                .ToList();
            Assert.AreEqual(7, products.Count);
            Assert.AreEqual("A4CS", products[0].ProductCode);
            PrintAll(products);
        }

        [Test]
        public void GetWithCalculatedFieldTest()
        {
            // get a list of objects that include the productcode, unitprice, quantity and inventoryvalue
            var products = dbContext.Products.Select(
            p => new { p.ProductCode, p.UnitPrice, p.OnHandQuantity, Value = p.UnitPrice * p.OnHandQuantity }).
            OrderBy(p => p.ProductCode).ToList();
            Assert.AreEqual(16, products.Count);
            Assert.AreEqual("A4CS", products[0].ProductCode);
            Assert.AreEqual(261990.50m, products[0].Value);
        }

        [Test]
        public void DeleteTest()
        {
            // Attempt to delete the product whose product code is A4CS. It should fail because of foreign key constraints.
            p = dbContext.Products.Find("A4CS");
            Assert.IsNotNull(p);
            dbContext.Products.Remove(p);
            Assert.Throws<DbUpdateException>(() => dbContext.SaveChanges());
        }
   
        [Test]
        public void CreateTest()
        {
            // Create a new product and save it to the database
            p = new Product();
            p.ProductCode = "TEST";
            p.Description = "Test Product";
            p.UnitPrice = 9.99m;
            p.OnHandQuantity = 100;
            dbContext.Products.Add(p);
            dbContext.SaveChanges();
            // retrieve the new product
            p = dbContext.Products.Find("TEST");
            Assert.AreEqual("Test Product", p.Description);
            Assert.AreEqual(9.99m, p.UnitPrice);
            Assert.AreEqual(100, p.OnHandQuantity);
        }

        [Test]
        public void UpdateTest()
        {
            // Update the product whose product code is A4CS
            p = dbContext.Products.Find("A4CS");
            Assert.IsNotNull(p);
            p.Description = "Updated";
            p.UnitPrice = 59.99m;
            dbContext.SaveChanges();
            // retrieve the updated product
            p = dbContext.Products.Find("A4CS");
            Assert.AreEqual("Updated", p.Description);
            Assert.AreEqual(59.99m, p.UnitPrice);

        }

        public void PrintAll(List<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }

    }
}