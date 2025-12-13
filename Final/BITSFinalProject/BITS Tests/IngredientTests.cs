using NUnit.Framework;
using BITSFinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITS_Tests
{
    [TestFixture]
    public class IngredientTests
    {
        BITSContext dbContext;
        Ingredient? testIngredient;
        List<Ingredient> ingredients;
        [SetUp]
        public void Setup()
        {
            dbContext = new BITSContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData");
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData");
        }
        [TearDownAttribute]
        public void TearDown()
        {
            dbContext.Dispose();
        }
        [Test]
        public void GetAllTest()
        {
            // Arrange
            ingredients = dbContext.Ingredients.ToList();
            // Act
            int count = ingredients.Count;
            // Assert
            Assert.AreEqual(1149, count);
        }
        [Test]
        public void GetByIdTest()
        {
            // Arrange
            int idToFind = 1084;
            // Act
            testIngredient = dbContext.Ingredients.Find(idToFind);
            // Assert. AI really struggled here, it thinks we are a bakery not a brewery.
            Assert.IsNotNull(testIngredient);
            Assert.AreEqual(1084, testIngredient.IngredientId);
            Assert.AreEqual("Crystal", testIngredient.Name);
            Assert.AreEqual(1, testIngredient.Version);
            Assert.AreEqual(3, testIngredient.IngredientTypeId);
            Assert.AreEqual(0, testIngredient.OnHandQuantity);
            Assert.AreEqual(3, testIngredient.UnitTypeId);
            Assert.AreEqual(0.00, testIngredient.UnitCost);
            Assert.AreEqual(0, testIngredient.ReorderPoint);
            Assert.AreEqual(133, testIngredient.Notes.Count());
        }
        [Test]
        public void CreateTest()
        {
            // Arrange
            Ingredient newIngredient = new Ingredient
            {
                Name = "Test Ingredient",
                Version = 1,
                IngredientTypeId = 1,
                OnHandQuantity = 10,
                UnitTypeId = 1,
                UnitCost = 2.50m,
                ReorderPoint = 5
            };
            // Act
            dbContext.Ingredients.Add(newIngredient);
            dbContext.SaveChanges();
            // Assert
            Assert.IsTrue(newIngredient.IngredientId > 0);
            Ingredient? createdIngredient = dbContext.Ingredients.Find(newIngredient.IngredientId);
            Assert.IsNotNull(createdIngredient);
            Assert.AreEqual("Test Ingredient", createdIngredient.Name);
        }
        [Test]
        public void UpdateTest()
        {
            // Arrange
            int idToUpdate = 1084;
            Ingredient? ingredientToUpdate = dbContext.Ingredients.Find(idToUpdate);
            Assert.IsNotNull(ingredientToUpdate);
            // Act
            ingredientToUpdate.Name = "Updated Ingredient Name";
            dbContext.SaveChanges();
            // Assert
            Ingredient? updatedIngredient = dbContext.Ingredients.Find(idToUpdate);
            Assert.IsNotNull(updatedIngredient);
            Assert.AreEqual("Updated Ingredient Name", updatedIngredient.Name);
        }
        [Test]
        public void DeleteTest()
        {
            // Arrange
            int idToDelete = 1084;
            testIngredient = dbContext.Ingredients.Find(idToDelete);
            Assert.IsNotNull(testIngredient);
            // Act
            dbContext.Ingredients.Remove(testIngredient);
            // Assert
            Assert.Throws<DbUpdateException>(() => dbContext.SaveChanges());
        }
    }
}

