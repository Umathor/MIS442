using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using MMABooksBusinessClasses;
namespace MMABooksTests
{
    public class ProductTests
    {

        [Test]
        public void TestProductConstructor()
        {
            Product prod1 = new Product();
            Assert.IsNotNull(prod1);
            Assert.AreEqual(null, prod1.ProductCode);
            Assert.AreEqual(null, prod1.Description);
            Assert.AreEqual(0, prod1.OnHandQuantity);
            Assert.AreEqual(0.0m, prod1.UnitPrice);
            string newCode = "P001";
            string newDesc = "Sample Product";
            int newQty = 10;
            decimal newPrice = 19.99m;
            Product prod2 = new Product(newDesc, newQty, newCode, newPrice);
            Assert.IsNotNull(prod2);
            Assert.AreEqual(newCode, prod2.ProductCode);
            Assert.AreEqual(newDesc, prod2.Description);
            Assert.AreEqual(newQty, prod2.OnHandQuantity);
            Assert.AreEqual(newPrice, prod2.UnitPrice);
        }

        [Test]
        public void TestProductSetters()
        {
            Product prod = new Product("Sample Product", 10, "P001", 19.99m);
            string newCode = "P002";
            string newDesc = "Updated Product";
            int newQty = 20;
            decimal newPrice = 29.99m;
            prod.ProductCode = newCode;
            prod.Description = newDesc;
            prod.OnHandQuantity = newQty;
            prod.UnitPrice = newPrice;
            Assert.AreEqual(newCode, prod.ProductCode);
            Assert.AreEqual(newDesc, prod.Description);
            Assert.AreEqual(newQty, prod.OnHandQuantity);
            Assert.AreEqual(newPrice, prod.UnitPrice);
        }

        [Test]
        public void TestProductToString()
        {
            Product prod = new Product("Sample Product", 10, "P001", 19.99m);
            string expectedString = "Sample Product, 10, P001, 19.99";
            Assert.AreEqual(expectedString, prod.ToString());
        }

        [Test]
        public void TestProductCodeLengthValidation()
        {
            Product prod = new Product();
            Assert.Throws<ArgumentOutOfRangeException>(() => prod.ProductCode = "TOO_LONG_CODE");
        }

        [Test]
        public void TestProductDescriptionLengthValidation()
        {
            Product prod = new Product();
            string longDescription = new string('A', 51); // 51 characters
            Assert.Throws<ArgumentOutOfRangeException>(() => prod.Description = longDescription);
        }

    }
}
