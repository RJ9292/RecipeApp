using System;

namespace RecipeApp.Class
{
    // Represents an ingredient used in a recipe
    public class Ingredient
    {
        // Properties of the Ingredient class
        public string IngredientName { get; set; } // Name of the ingredient
        public string IngredientQuantity { get; set; } // Quantity of the ingredient
        public string IngredientMeasurement { get; set; } // Unit of measurement for the ingredient (e.g., cups, grams)
        public string FoodGroup { get; set; } // Food group to which the ingredient belongs (e.g., Dairy, Protein)
        public int Calories { get; set; } // Calorie count for the ingredient

        // Constructor to initialize the properties of the Ingredient class
        public Ingredient(string name, string quantity, string measurement, string foodGroup, int calories)
        {
            IngredientName = name; // Initialize the ingredient name
            IngredientQuantity = quantity; // Initialize the ingredient quantity
            IngredientMeasurement = measurement; // Initialize the unit of measurement
            FoodGroup = foodGroup; // Initialize the food group
            Calories = calories; // Initialize the calorie count
        }

        // End of Ingredient class
    }

    // End of RecipeApp.Class namespace
}
