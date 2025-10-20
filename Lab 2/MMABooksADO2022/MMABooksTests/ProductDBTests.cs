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
    }
}
