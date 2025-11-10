using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using MMABooksEFClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        
        MMABooksContext dbContext;
        Customer c;
        List<Customer> customers;

        [SetUp]
        public void Setup()
        {
            dbContext = new MMABooksContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetInvoiceData");
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetInvoiceData");
            dbContext.Dispose();
        }

        [Test]
        public void GetAllTest()
        {
            customers = dbContext.Customers.OrderBy(c => c.Name).ToList();
            Assert.AreEqual(696, customers.Count);
            Assert.AreEqual("Abeyatunge, Derek", customers[0].Name);
            PrintAll(customers);
        }

        [Test]
        public void GetByPrimaryKeyTest()
        {
            c = dbContext.Customers.Find(20);
            Assert.IsNotNull(c);
            Assert.AreEqual("Chamberland, Sarah", c.Name);
            Console.WriteLine(c);
        }

        [Test]
        public void GetUsingWhere()
        {
            // get a list of all of the customers who live in OR
            customers = dbContext.Customers
                .Where(c => c.State == "OR")
                .OrderBy(c => c.Name)
                .ToList();
            Assert.AreEqual(5, customers.Count);
            Assert.AreEqual("Erpenbach, Lee", customers[0].Name);
        }

        [Test]
        public void GetWithInvoicesTest()
        {
           // get the customer whose id is 20 and all of the invoices for that customer
              c = dbContext.Customers
                 .Include("Invoices")
                 .Where(c => c.CustomerId == 20)
                 .SingleOrDefault();
            Assert.IsNotNull(c);
            Assert.AreEqual("Chamberland, Sarah", c.Name);
            Assert.AreEqual(3, c.Invoices.Count);
        }

        /*[Test]
        public void GetWithJoinTest()
        {
            // get a list of objects that include the customer id, name, statecode and statename
            var customers = dbContext.Customers.Join(
               dbContext.States,
               c => c.State,
               s => s.StateCode,
               (c, s) => new { c.CustomerId, c.Name, c.State, s.StateName }).OrderBy(r => r.StateName).ToList();
            Assert.AreEqual(696, customers.Count);
        }
        */
        
        [Test]
        public void DeleteTest()
        {
            c = dbContext.Customers.Find(20);
            dbContext.Customers.Remove(c);
            dbContext.SaveChanges();
            Assert.IsNull(dbContext.Customers.Find(20));
        }

        [Test]
        public void CreateTest()
        {
            c = new Customer();
            c.Name = "Test, Test";
            c.Address = "123 Test St.";
            c.City = "Testville";
            c.State = "OR";
            c.ZipCode = "12345";
            dbContext.Customers.Add(c);
            dbContext.SaveChanges();
            // get the customerid of the new customer
            int newCustomerId = c.CustomerId;
            // retrieve the new customer
            c = dbContext.Customers.Find(newCustomerId);
            Assert.AreEqual("Test, Test", c.Name);
            Assert.AreEqual("123 Test St.", c.Address);
            Assert.AreEqual("Testville", c.City);
            Assert.AreEqual("OR", c.State);
            Assert.AreEqual("12345", c.ZipCode);
        }

        [Test]
        public void UpdateTest()
        {
            c = new Customer();
            c = dbContext.Customers.Find(20);
            c.Name = "Updated, Customer";
            dbContext.SaveChanges();
            Assert.AreEqual("Updated, Customer", dbContext.Customers.Find(20).Name);
        }

        public void PrintAll(List<Customer> customers)
        {
            foreach (Customer c in customers)
            {
                Console.WriteLine(c);
            }
        }
        
        
    }
}