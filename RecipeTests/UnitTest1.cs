using System;
using System.Collections.Generic;
using Xunit;
using RecipeApp.Class;

namespace RecipeApp.Tests
{
    public class RecipeTests
    {
        [Fact]
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
            Assert.Equal(320, totalCalories);
        }

        [Theory]
        [InlineData(0.5, 160)]
        [InlineData(2, 640)]
        [InlineData(3, 960)]
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
            Assert.Equal(expectedCalories, totalCalories);
        }

        [Fact]
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
            Assert.Contains("Warning: Over 2000 calories!", consoleOutput);
        }

        [Fact]
        public void ResetValues_ShouldRestoreOriginalValues()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 100));
            recipe.OriginalIngredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 100));
            recipe.Ingredients[0].IngredientQuantity = "2";

            // Act
            recipe.ResetValues();

            // Assert
            Assert.Equal("1", recipe.Ingredients[0].IngredientQuantity);
        }

        [Fact]
        public void EnterRecipe_ShouldAllowAddingIngredientsAndSteps()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            var input = new System.IO.StringReader("1\nFlour\n1\ncup\nGrain\n100\n1\nMix ingredients\n");
            Console.SetIn(input);

            // Act
            bool result = recipe.EnterRecipe();

            // Assert
            Assert.True(result);
            Assert.Single(recipe.Ingredients);
            Assert.Single(recipe.Steps);
            Assert.Equal("Flour", recipe.Ingredients[0].IngredientName);
        }
    }
}
