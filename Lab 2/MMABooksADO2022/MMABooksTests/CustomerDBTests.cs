using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            Customer c = new Customer();
            c.Name = "Minnie Mouse";
            c.Address = "102 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10102";
            c.CustomerID = CustomerDB.AddCustomer(c);
            bool deleted = CustomerDB.DeleteCustomer(c);
            Assert.IsTrue(deleted);
            c = CustomerDB.GetCustomer(c.CustomerID);
            Assert.IsNull(c);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            Customer c = new Customer();
            Customer c2 = new Customer();
            c.Name = "Donald Duck";
            c.Address = "103 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10103";
            c.CustomerID = CustomerDB.AddCustomer(c);
            c2.Name = "Donald E. Duck";
            c2.Address = "104 Main Street";
            c2.City = "Miami";
            c2.State = "NY";
            c2.ZipCode = "20204";

            CustomerDB.UpdateCustomer(c, c2);
            c = CustomerDB.GetCustomer(c.CustomerID);
            Assert.AreEqual("Donald E. Duck", c.Name);
            Assert.AreEqual("104 Main Street", c.Address);
            Assert.AreEqual("Miami", c.City);
            Assert.AreEqual("NY", c.State);
            Assert.AreEqual("20204", c.ZipCode);
        }
    }
}
