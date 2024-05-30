using System;

namespace RecipeApp.Class
{
    public class Ingredient
    {
        public string IngredientName { get; set; }
        public string IngredientQuantity { get; set; }
        public string IngredientMeasurement { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }

        public Ingredient(string name, string quantity, string measurement, string foodGroup, int calories)
        {
            IngredientName = name;
            IngredientQuantity = quantity;
            IngredientMeasurement = measurement;
            FoodGroup = foodGroup;
            Calories = calories;
        }

        // End of Ingredient class
    }

    // End of RecipeApp.Class namespace
}
