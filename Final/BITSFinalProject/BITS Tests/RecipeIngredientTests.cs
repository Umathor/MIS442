using BITSFinalProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITS_Tests
{
    [TestFixture]
    public class RecipeIngredientTests
    {
        BITSContext dbContext;
        RecipeIngredient? testRecipeIngredient;
        List<RecipeIngredient> recipeIngredients;

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
        //letting the AI take the wheel a bit for test generation. Using builting copilot autocomplete from here.
        [Test]
        public void GetAllTest()
        {
            // Arrange
            recipeIngredients = dbContext.RecipeIngredients.ToList();
            // Act
            int count = recipeIngredients.Count;
            // Assert
            Assert.AreEqual(57, count);
        }
        [Test]
        public void GetByIdTest()
        {
            // Arrange
            int idToFind = 1;
            // Act, AI wanted to pull the whole list then search it with where instead of using the existing find function
            testRecipeIngredient = dbContext.RecipeIngredients.Find(idToFind);
            // Assert
            Assert.IsNotNull(testRecipeIngredient);
            Assert.AreEqual(1, testRecipeIngredient.RecipeIngredientId);
            Assert.AreEqual(1, testRecipeIngredient.RecipeId);
            Assert.AreEqual(1084, testRecipeIngredient.IngredientId);
            Assert.AreEqual(0.0283495, testRecipeIngredient.Quantity);
            Assert.AreEqual(60, testRecipeIngredient.Time);
            Assert.AreEqual(3, testRecipeIngredient.UseDuringId);
        }
        [Test]
        public void CreateTest()
        {
            // Arrange
            RecipeIngredient newRecipeIngredient = new RecipeIngredient
            {
                RecipeId = 2,
                IngredientId = 1000,
                Quantity = 1.5,
                Time = 30,
                UseDuringId = 1
            };
            // Act
            dbContext.RecipeIngredients.Add(newRecipeIngredient);
            dbContext.SaveChanges();
            // Assert
            Assert.IsTrue(newRecipeIngredient.RecipeIngredientId > 0);
            RecipeIngredient? createdRecipeIngredient = dbContext.RecipeIngredients.Find(newRecipeIngredient.RecipeIngredientId);
            Assert.IsNotNull(createdRecipeIngredient);
            Assert.AreEqual(2, createdRecipeIngredient.RecipeId);
            Assert.AreEqual(1000, createdRecipeIngredient.IngredientId);
            Assert.AreEqual(1.5, createdRecipeIngredient.Quantity);
            Assert.AreEqual(30, createdRecipeIngredient.Time);
            Assert.AreEqual(1, createdRecipeIngredient.UseDuringId);
        }
        [Test]
        public void UpdateTest()
        {
            // Arrange
            int idToUpdate = 1;
            testRecipeIngredient = dbContext.RecipeIngredients.Find(idToUpdate);
            Assert.IsNotNull(testRecipeIngredient);
            // Act
            testRecipeIngredient.Quantity = 0.05;
            testRecipeIngredient.Time = 45;
            dbContext.SaveChanges();
            // Assert
            RecipeIngredient? updatedRecipeIngredient = dbContext.RecipeIngredients.Find(idToUpdate);
            Assert.IsNotNull(updatedRecipeIngredient);
            Assert.AreEqual(0.05, updatedRecipeIngredient.Quantity);
            Assert.AreEqual(45, updatedRecipeIngredient.Time);
        }
        [Test]
        public void DeleteTest()
        {
            // Arrange
            int idToDelete = 1;
            testRecipeIngredient = dbContext.RecipeIngredients.Find(idToDelete);
            Assert.IsNotNull(testRecipeIngredient);
            // Act
            dbContext.RecipeIngredients.Remove(testRecipeIngredient);
            dbContext.SaveChanges();
            // Assert
            RecipeIngredient? deletedRecipeIngredient = dbContext.RecipeIngredients.Find(idToDelete);
            Assert.IsNull(deletedRecipeIngredient);
        }
    }
}