using System;
using NUnit.Framework;
using BITSFinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITS_Tests
{
    [TestFixture]
    public class RecipeTests
    {
        BITSContext dbContext;
        Recipe? testRecipe;
        List<Recipe> recipes;
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
            recipes = dbContext.Recipes.ToList();
            // Act
            int count = recipes.Count;
            // Assert
            Assert.AreEqual(4, count);
        }
        [Test]
        public void GetByIdTest()
        {
            // Arrange
            int idToFind = 1;
            // Act
            testRecipe = dbContext.Recipes.Find(idToFind);
            // Assert. The AI figured out we are making beer, but it is still just making up class properties instead of pulling from the class
            //Not going to test all properties since some are null
            Assert.IsNotNull(testRecipe);
            Assert.AreEqual(1, testRecipe.RecipeId);
            Assert.AreEqual("Fuzzy Tales Juicy IPA", testRecipe.Name);
            Assert.AreEqual(1, testRecipe.Version);
            Assert.AreEqual(133, testRecipe.StyleId);
            Assert.AreEqual(37.8541178, testRecipe.Volume);
        }
        [Test]
        public void UpdateTest()
        {
            // Arrange
            int idToUpdate = 2;
            string newName = "Updated Stout Recipe";
            testRecipe = dbContext.Recipes.Find(idToUpdate);
            Assert.IsNotNull(testRecipe);
            // Act
            testRecipe.Name = newName;
            dbContext.SaveChanges();
            // Retrieve again to verify update
            Recipe? updatedRecipe = dbContext.Recipes.Find(idToUpdate);
            // Assert
            Assert.IsNotNull(updatedRecipe);
            Assert.AreEqual(newName, updatedRecipe.Name);
        }
        [Test]
        public void DeleteTest()
        {
            // Arrange
            int idToDelete = 4;
            testRecipe = dbContext.Recipes.Find(idToDelete);
            Assert.IsNotNull(testRecipe);
            // Act
            dbContext.Recipes.Remove(testRecipe);
            // Assert
            Assert.Throws<DbUpdateException>(() => dbContext.SaveChanges());
        }
        [Test]
        public void CreateTest()
        {
            // Arrange
            Recipe newRecipe = new Recipe
            {
                Name = "New Lager Recipe",
                Version = 1,
                StyleId = 70,
                Volume = 25.0,
                EquipmentId = 1,
                MashId = 16,
                Brewer = "Test Brewer"
            };
            // Act
            dbContext.Recipes.Add(newRecipe);
            dbContext.SaveChanges();
            // Retrieve to verify creation
            Recipe? createdRecipe = dbContext.Recipes
                .FirstOrDefault(r => r.Name == "New Lager Recipe" && r.Version == 1);
            // Assert
            Assert.IsNotNull(createdRecipe);
            Assert.AreEqual("New Lager Recipe", createdRecipe.Name);
            Assert.AreEqual(1, createdRecipe.Version);
            Assert.AreEqual(70, createdRecipe.StyleId);
            Assert.AreEqual(25.0, createdRecipe.Volume);
            Assert.AreEqual(1, createdRecipe.EquipmentId);
            Assert.AreEqual(16, createdRecipe.MashId);
        }
    }
}
