using System;
using System.Collections.Generic;

namespace RecipeApp.Class
{
    // Class for applying a multiplier to ingredient quantities and calories
    public class Multiplier
    {
        // Method to apply the multiplier to each ingredient in the list
        public void ApplyMultiplier(List<Ingredient> ingredients, double multiplier)
        {
            try
            {
                // Iterate through each ingredient in the list
                foreach (var ingredient in ingredients)
                {
                    // Try to parse the ingredient quantity as a double
                    if (double.TryParse(ingredient.IngredientQuantity, out double quantity))
                    {
                        // Apply the multiplier to the quantity and update the ingredient
                        ingredient.IngredientQuantity = (quantity * multiplier).ToString();
                    }
                    // Apply the multiplier to the calories and update the ingredient
                    ingredient.Calories = (int)(ingredient.Calories * multiplier);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the multiplication process
                Console.WriteLine($"An error occurred while applying the multiplier: {ex.Message}");
            }
        }

        // End of Multiplier class
    }

    // End of RecipeApp.Class namespace
}
