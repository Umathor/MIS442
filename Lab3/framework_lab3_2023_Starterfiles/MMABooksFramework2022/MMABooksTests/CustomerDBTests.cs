using NUnit.Framework;

using MMABooksProps;
using MMABooksDB;

using DBCommand = MySql.Data.MySqlClient.MySqlCommand;
using System.Data;

using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
namespace MMABooksTests
{
    internal class CustomerDBTests
    {
        CustomerDB db;
        [SetUp]
        public void ResetData()
        {
            db = new CustomerDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
            //command.CommandText = "usp_testingResetStateData";
            //db.RunNonQueryProcedure(command);

        }

        [Test]
        public void TestRetrieve()
        {
            CustomerProps p = (CustomerProps)db.Retrieve(1);
            Assert.AreEqual(1, p.CustomerID);
            Assert.AreEqual("Molunguri, A", p.Name);
        }
        [Test]
        public void TestRetrieveAll()
        {
            List<CustomerProps> list = (List<CustomerProps>)db.RetrieveAll();
            Assert.AreEqual(696, list.Count);
        }
        [Test]
        public void TestDelete()
        {
            CustomerProps p = (CustomerProps)db.Retrieve(10);
            Assert.True(db.Delete(p));
            Assert.Throws<Exception>(() => db.Retrieve(10));
        }
        /*[Test]
        public void TestDeleteForeignKeyConstraint()
        {
            // CustomerID foreign key constraint with invoices table is cascade so delete won't fail.
            CustomerProps p = (CustomerProps)db.Retrieve(20);
            Assert.Throws<MySqlException>(() => db.Delete(p));
        }*/
        [Test]
        public void TestUpdate()
        {
            CustomerProps p = (CustomerProps)db.Retrieve(2);
            p.Name = "Edited Name";
            Assert.True(db.Update(p));
            CustomerProps p2 = (CustomerProps)db.Retrieve(2);
            Assert.AreEqual("Edited Name", p2.Name);
        }
        [Test]
        public void TestUpdateFieldTooLong()
        {
            CustomerProps p = (CustomerProps)db.Retrieve(3);
            p.Name = new string('A', 101); // assuming max length is 100
            Assert.Throws<MySqlException>(() => db.Update(p));
        }
        [Test]
        public void TestUpdateConcurrencyViolation()
        {
            CustomerProps p1 = (CustomerProps)db.Retrieve(4);
            CustomerProps p2 = (CustomerProps)db.Retrieve(4);
            p1.Name = "First Update";
            Assert.True(db.Update(p1));
            p2.Name = "Second Update";
            Assert.Throws<Exception>(() => db.Update(p2));
        }

        [Test]
        public void TestCreate()
        {
            CustomerProps p = new CustomerProps();
            p.Name = "New Customer";
            p.Address = "123 New St";
            p.City = "New City";
            p.StateCode = "OR";
            p.ZipCode = "97035";
            db.Create(p);
            CustomerProps p2 = (CustomerProps)db.Retrieve(p.CustomerID);
            Assert.AreEqual("New Customer", p2.Name);
            Assert.AreEqual("123 New St", p2.Address);
            Assert.AreEqual("New City", p2.City);
            Assert.AreEqual("OR", p2.StateCode);
            Assert.AreEqual("97035", p2.ZipCode);
        }
        [Test]
        public void TestCreateInvalidStateCode()
        {
            CustomerProps p = new CustomerProps();
            p.Name = "Invalid State Customer";
            p.Address = "456 Invalid St";
            p.City = "Invalid City";
            p.StateCode = "XX"; // assuming XX is not a valid state code
            p.ZipCode = "12345";
            Assert.Throws<MySqlException>(() => db.Create(p));
        }
    }
}
