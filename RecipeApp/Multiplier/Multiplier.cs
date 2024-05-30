using System;
using System.Collections.Generic;

namespace RecipeApp.Class
{
    public class Multiplier
    {
        // Handles changing the string from the user input into a double and then applying the multiplier to it.
        public void ApplyMultiplier(List<Ingredient> ingredients, double multiplier)
        {
            try
            {
                foreach (var ingredient in ingredients)
                {
                    if (double.TryParse(ingredient.IngredientQuantity, out double quantity))
                    {
                        ingredient.IngredientQuantity = (quantity * multiplier).ToString();
                    }
                    ingredient.Calories = (int)(ingredient.Calories * multiplier);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while applying the multiplier: {ex.Message}");
            }
        }

        // End of Multiplier class
    }

    // End of RecipeApp.Class namespace
}
