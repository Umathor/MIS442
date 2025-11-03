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
    internal class ProductDBTests
    {
        ProductDB db;
        [SetUp]
        public void ResetData()
        {
            db = new ProductDB();
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
            //This was easier for me than fixing the resetdata stored procedure to include the state data
            //upon further checking the testingreset data stored procedure is borked, it has two versions
            //of itself in the provided sql and the first one is incomplete. 
            //command.CommandText = "usp_testingResetStateData";
            //db.RunNonQueryProcedure(command);
        }
        [Test]
        public void TestRetrieve()
        {
            ProductProps p = (ProductProps)db.Retrieve(1);
            Assert.AreEqual(1, p.ProductID);
            Assert.AreEqual("A4CS", p.ProductCode);
        }
        [Test]
        public void TestRetrieveAll()
        {
            List<ProductProps> list = (List<ProductProps>)db.RetrieveAll();
            Assert.AreEqual(16, list.Count);
        }
        [Test]
        public void TestDelete()
        {
            ProductProps p = (ProductProps)db.Retrieve(10);
            Assert.True(db.Delete(p));
            Assert.Throws<Exception>(() => db.Retrieve(10));
        }
        [Test]
        public void TestUpdate()
        {
            ProductProps p = (ProductProps)db.Retrieve(2);
            p.Description = "Updated Description";
            Assert.True(db.Update(p));
            p = (ProductProps)db.Retrieve(2);
            Assert.AreEqual("Updated Description", p.Description);
        }
        [Test]
        public void TestUpdateFieldTooLong()
        {
            ProductProps p = (ProductProps)db.Retrieve(3);
            p.ProductCode = new string('X', 21); // assuming max length is 20
            Assert.Throws<MySqlException>(() => db.Update(p));
        }
        [Test]
        public void TestUpdateConcurrencyViolation()
        {
            ProductProps p1 = (ProductProps)db.Retrieve(4);
            ProductProps p2 = (ProductProps)db.Retrieve(4);
            p1.Description = "First Update";
            Assert.True(db.Update(p1));
            p2.Description = "Second Update";
            Assert.Throws<Exception>(() => db.Update(p2));
        }
        [Test]
        public void TestCreate() 
        {
            ProductProps p = new ProductProps();
            p.ProductCode = "NEWPC";
            p.Description = "New Product";
            p.UnitPrice = 19.99m;
            p.OnHandQuantity = 100;
            db.Create(p);

            ProductProps p2 = (ProductProps)db.Retrieve(p.ProductID);
            Assert.AreEqual("NEWPC", p2.ProductCode);
            Assert.AreEqual("New Product", p2.Description);
            Assert.AreEqual(19.99m, p2.UnitPrice);
            Assert.AreEqual(100, p2.OnHandQuantity);
        }
    }
}
