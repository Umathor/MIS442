using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("ADC4");
            Assert.AreEqual("ADC4", p.ProductCode);
        }

        [Test]
        public void TestAddProduct()
        {
            Product p = new Product();
            p.ProductCode = "TST1";
            p.Description = "Test Product 1";
            p.OnHandQuantity = 50;
            p.UnitPrice = 9.99m;
            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("Test Product 1", p.Description);
        }

        [Test]
        public void TestDeleteProduct()
        {
            Product p = new Product();
            p.ProductCode = "TST2";
            p.Description = "Test Product 2";
            p.OnHandQuantity = 30;
            p.UnitPrice = 19.99m;
            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            bool deleted = ProductDB.DeleteProduct(p);
            Assert.IsTrue(deleted);
            p = ProductDB.GetProduct(productCode);
            Assert.IsNull(p);
        }

        [Test]
        public void TestUpdateProduct()
        {
            Product p = new Product();
            Product p2 = new Product();
            p.ProductCode = "TST3";
            p.Description = "Test Product 3";
            p.OnHandQuantity = 20;
            p.UnitPrice = 29.99m;
            ProductDB.AddProduct(p);
            p2.ProductCode = "TST4";
            p2.Description = "Updated Product 4";
            p2.OnHandQuantity = 40;
            p2.UnitPrice = 39.99m;
            bool updated = ProductDB.UpdateProduct(p, p2);
            Assert.IsTrue(updated);
            p = ProductDB.GetProduct("TST4");
            Assert.AreEqual("Updated Product 4", p.Description);
            Assert.AreEqual(40, p.OnHandQuantity);
            Assert.AreEqual(39.99m, p.UnitPrice);
            Assert.AreEqual("TST4", p.ProductCode);
        }
    }
}
