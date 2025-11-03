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
    }
}
