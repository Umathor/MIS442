using MMABooksProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MMABooksTests
{
    internal class ProductPropsTest
    {
        ProductProps props;
        [SetUp]
        public void Setup()
        {
            props = new ProductProps();
            props.ProductCode = "az12";
            props.Description = "This is a sample product.";
            props.UnitPrice = 19.99m;
            props.OnHandQuantity = 100;
        }
        [Test]
        public void TestGetState()
        {
            string jsonString = props.GetState();
            Console.WriteLine(jsonString);
            Assert.IsTrue(jsonString.Contains(props.ProductCode));
            Assert.IsTrue(jsonString.Contains(props.Description));
            Assert.IsTrue(jsonString.Contains(props.UnitPrice.ToString()));
            Assert.IsTrue(jsonString.Contains(props.OnHandQuantity.ToString()));
        }
        [Test]
        public void TestSetState()
        {
            string jsonString = props.GetState();
            ProductProps newProps = new ProductProps();
            newProps.SetState(jsonString);
            Assert.AreEqual(props.ProductCode, newProps.ProductCode);
            Assert.AreEqual(props.Description, newProps.Description);
            Assert.AreEqual(props.UnitPrice, newProps.UnitPrice);
            Assert.AreEqual(props.OnHandQuantity, newProps.OnHandQuantity);
            Assert.AreEqual(props.ConcurrencyID, newProps.ConcurrencyID);
        }
        [Test]
        public void TestClone()
        {
            ProductProps newProps = (ProductProps)props.Clone();
            Assert.AreEqual(props.ProductCode, newProps.ProductCode);
            Assert.AreEqual(props.Description, newProps.Description);
            Assert.AreEqual(props.UnitPrice, newProps.UnitPrice);
            Assert.AreEqual(props.OnHandQuantity, newProps.OnHandQuantity);
            Assert.AreEqual(props.ConcurrencyID, newProps.ConcurrencyID);
        }
    }
}
