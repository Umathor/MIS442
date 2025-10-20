using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void TestCustomerConstructor()
        {
            Customer cust1 = new Customer();
            Assert.IsNotNull(cust1);
            Assert.AreEqual(0, cust1.CustomerID);
            Assert.AreEqual(null, cust1.Name);
            Assert.AreEqual(null, cust1.Address);
            Assert.AreEqual(null, cust1.City);
            Assert.AreEqual(null, cust1.State);
            Assert.AreEqual(null, cust1.ZipCode);
            int newID = 1;
            string newName = "John Doe";
            string newAddress = "123 Main St";
            string newCity = "Anytown";
            string newState = "CA";
            string newZip = "90210";
            Customer cust2 = new Customer(newID, newName, newAddress, newCity, newState, newZip);
            Assert.IsNotNull(cust2);
            Assert.AreEqual(newID, cust2.CustomerID);
            Assert.AreEqual(newName, cust2.Name);
            Assert.AreEqual(newAddress, cust2.Address);
            Assert.AreEqual(newCity, cust2.City);
            Assert.AreEqual(newState, cust2.State);
            Assert.AreEqual(newZip, cust2.ZipCode);
        }

        [Test]
        public void TestCustomerSetters()
        {
            Customer cust = new Customer(1, "John Doe", "123 Main St", "Anytown", "CA", "90210");
            int newID = 2;
            string newName = "Jane Smith";
            string newAddress = "456 Oak Ave";
            string newCity = "Othertown";
            string newState = "NY";
            string newZip = "10001";
            cust.CustomerID = newID;
            cust.Name = newName;
            cust.Address = newAddress;
            cust.City = newCity;
            cust.State = newState;
            cust.ZipCode = newZip;
            Assert.AreEqual(newID, cust.CustomerID);
            Assert.AreEqual(newName, cust.Name);
            Assert.AreEqual(newAddress, cust.Address);
            Assert.AreEqual(newCity, cust.City);
            Assert.AreEqual(newState, cust.State);
            Assert.AreEqual(newZip, cust.ZipCode);

        }

        [Test]
        public void TestCustomerToString()
        {
            Customer cust = new Customer(1, "John Doe", "123 Main St", "Anytown", "CA", "90210");
            string expected = "1, John Doe, 123 Main St, Anytown, CA, 90210";
            Assert.AreEqual(expected, cust.ToString());
        }

        [Test]
        public void TestCustomerStateValidation()
        {
            Customer cust = new Customer();
            cust.State = "TX";
            Assert.AreEqual("TX", cust.State);
            Assert.Throws<ArgumentOutOfRangeException>(() => cust.State = "TEX");
        }

        [Test]
        public void TestCustomerZipCodeValidation()
        {
            Customer cust = new Customer();
            cust.ZipCode = "12345";
            Assert.AreEqual("12345", cust.ZipCode);
            cust.ZipCode = "12345-6789";
            Assert.AreEqual("12345-6789", cust.ZipCode);
            Assert.Throws<ArgumentOutOfRangeException>(() => cust.ZipCode = "1234");
            Assert.Throws<ArgumentOutOfRangeException>(() => cust.ZipCode = "123456");
        }
    }
}
