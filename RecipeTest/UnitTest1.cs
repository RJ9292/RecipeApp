using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp.Class;
using System;
using System.Collections.Generic;

namespace RecipeApp.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void CalculateTotalCalories_ShouldReturnCorrectTotal()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 100));
            recipe.Ingredients.Add(new Ingredient("Milk", "1", "cup", "Dairy", 150));
            recipe.Ingredients.Add(new Ingredient("Egg", "1", "large", "Protein", 70));

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(320, totalCalories);
        }

        [DataTestMethod]
        [DataRow(0.5, 160)]
        [DataRow(2, 640)]
        [DataRow(3, 960)]
        public void ApplyMultiplier_ShouldScaleCaloriesCorrectly(double multiplier, int expectedCalories)
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 100));
            recipe.Ingredients.Add(new Ingredient("Milk", "1", "cup", "Dairy", 150));
            recipe.Ingredients.Add(new Ingredient("Egg", "1", "large", "Protein", 70));
            var multiplierClass = new Multiplier();

            // Act
            multiplierClass.ApplyMultiplier(recipe.Ingredients, multiplier);
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(expectedCalories, totalCalories);
        }

        [TestMethod]
        public void PrintRecipe_ShouldShowCorrectCalorieWarning()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new Ingredient("Butter", "1", "cup", "Fat", 800));
            recipe.Ingredients.Add(new Ingredient("Sugar", "1", "cup", "Sweetener", 774));
            recipe.Ingredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 455));

            // Act
            var output = new System.IO.StringWriter();
            Console.SetOut(output);
            recipe.PrintRecipe();
            var consoleOutput = output.ToString();

            // Assert
            StringAssert.Contains(consoleOutput, "Warning: Are you trying to set a new record for the highest calorie dish ever?");
        }

        [TestMethod]
        public void ResetValues_ShouldRestoreOriginalValues()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 100));
            recipe.OriginalIngredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 100));
            recipe.Ingredients[0].Quantity = "2";

            // Act
            recipe.ResetValues();

            // Assert
            Assert.AreEqual("1", recipe.Ingredients[0].Quantity);
        }

        [TestMethod]
        public void EnterRecipe_ShouldAllowAddingIngredientsAndSteps()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            var input = new System.IO.StringReader("1\nFlour\n1\ncup\n1\n100\n1\nMix ingredients\n");
            Console.SetIn(input);

            // Act
            bool result = recipe.EnterRecipe();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, recipe.Ingredients.Count);
            Assert.AreEqual(1, recipe.Steps.Count);
            Assert.AreEqual("Flour", recipe.Ingredients[0].Name);
        }
    }
}
