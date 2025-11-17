using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using MMABooksEFClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace MMABooksTests
{
    [TestFixture]
    public class StateTests
    {
        
        MMABooksContext dbContext;
        State s;
        List<State> states;

        [SetUp]
        public void Setup()
        {
            dbContext = new MMABooksContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetStateData()");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetStateData()");
            dbContext.Dispose();
        }

        [Test]
        public void GetAllTest()
        {
            states = dbContext.States.OrderBy(s => s.StateName).ToList();
            Assert.AreEqual(53, states.Count);
            Assert.AreEqual("Alabama", states[0].StateName);
            PrintAll(states);
        }

        [Test]
        public void GetByPrimaryKeyTest()
        {
            s = dbContext.States.Find("OR");
            Assert.IsNotNull(s);
            Assert.AreEqual("Ore", s.StateName);
            Console.WriteLine(s);
        }

        [Test]
        public void GetUsingWhere()
        {
            // current version generates a null processing error StartsWith can't operate on a nullable value
            // states = dbContext.States.Where(s => s.StateName.StartsWith("A")).OrderBy(s => s.StateName).ToList();
            states = dbContext.States.Where(s => s.StateName == "Ore").OrderBy(s => s.StateName).ToList();
            Assert.AreEqual(1, states.Count);
            Assert.AreEqual("OR", states[0].StateCode);
            PrintAll(states);
        }

        [Test]
        public void GetWithCustomersTest()
        {
            s = dbContext.States.Include("Customers").Where(s => s.StateCode == "OR").SingleOrDefault();
            Assert.IsNotNull(s);
            Assert.AreEqual("Ore", s.StateName);
            Assert.AreEqual(5, s.Customers.Count);
            Console.WriteLine(s);
        }

        [Test]
        public void DeleteTest()
        {
            s = dbContext.States.Find("HI");
            dbContext.States.Remove(s);
            dbContext.SaveChanges();
            Assert.IsNull(dbContext.States.Find("HI"));
        }

        [Test]
        public void CreateTest()
        {
            s = new State();
            s.StateCode = "ZZ";
            s.StateName = "Zzyzx";
            dbContext.States.Add(s);
            dbContext.SaveChanges();
            Assert.AreEqual("Zzyzx", dbContext.States.Find("ZZ").StateName);
        }

        [Test]
        public void UpdateTest()
        {
            s = dbContext.States.Find("OR");
            s.StateName = "Oregon";
            dbContext.SaveChanges();
            Assert.AreEqual("Oregon", dbContext.States.Find("OR").StateName);

        }

        public void PrintAll(List<State> states)
        {
            foreach (State s in states)
            {
                Console.WriteLine(s);
            }
        }
        
    }
}