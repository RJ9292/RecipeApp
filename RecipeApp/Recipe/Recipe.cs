using System;
using System.Collections.Generic;

namespace RecipeApp.Class
{
    // Delegate for calorie warning messages
    public delegate void CalorieWarningDelegate(int totalCalories);

    // Class representing a recipe
    public class Recipe
    {
        // Properties of the Recipe class
        public string RecipeName { get; set; } // Name of the recipe
        public List<Ingredient> OriginalIngredients { get; set; } // List of original ingredients
        public List<Ingredient> Ingredients { get; set; } // List of ingredients
        public List<string> Steps { get; set; } // List of steps to prepare the recipe
        public CalorieWarningDelegate CalorieWarning; // Delegate for calorie warnings

        // Constructor to initialize the properties of the Recipe class
        public Recipe(string name)
        {
            RecipeName = name; // Initialize the recipe name
            Ingredients = new List<Ingredient>(); // Initialize the list of ingredients
            OriginalIngredients = new List<Ingredient>(); // Initialize the list of original ingredients
            Steps = new List<string>(); // Initialize the list of steps
            CalorieWarning = DefaultWarning; // Set the default calorie warning
        } // End of method

        // Method to enter a new recipe
        public bool EnterRecipe()
        {
            try
            {
                Console.WriteLine($"Enter details for recipe: {RecipeName}");
                Console.WriteLine("Type 'back' at any prompt to return to the main menu.");

                Console.WriteLine("How many ingredients do you want to enter?");
                string input = Console.ReadLine();
                if (input.ToLower() == "back") return false;

                if (!int.TryParse(input, out int ingredientCount))
                {
                    Console.WriteLine("Invalid number of ingredients. Returning to the main menu.");
                    return false;
                }

                for (int i = 1; i <= ingredientCount; i++)
                {
                    Console.WriteLine($"Enter Ingredient {i} (or type 'back' to cancel):");
                    string ingredientName = Console.ReadLine();
                    if (ingredientName.ToLower() == "back") return false;

                    Console.WriteLine($"Enter Quantity for {ingredientName} (or type 'back' to cancel):");
                    string quantity = Console.ReadLine();
                    if (quantity.ToLower() == "back") return false;

                    Console.WriteLine($"Enter Measurement for {ingredientName} ({quantity}) (or type 'back' to cancel):");
                    string measurement = Console.ReadLine();
                    if (measurement.ToLower() == "back") return false;

                    Console.WriteLine($"Select Food Group for {ingredientName}:");
                    Console.WriteLine("1) Grains");
                    Console.WriteLine("2) Dairy");
                    Console.WriteLine("3) Protein");
                    Console.WriteLine("4) Sweetener");
                    Console.WriteLine("5) Leavening Agent");
                    Console.WriteLine("6) Spice");
                    Console.WriteLine("7) Fat");
                    Console.WriteLine("8) Liquid");
                    string foodGroup = Console.ReadLine();
                    if (foodGroup.ToLower() == "back") return false;

                    switch (foodGroup)
                    {
                        case "1":
                            foodGroup = "Grains";
                            break;
                        case "2":
                            foodGroup = "Dairy";
                            break;
                        case "3":
                            foodGroup = "Protein";
                            break;
                        case "4":
                            foodGroup = "Sweetener";
                            break;
                        case "5":
                            foodGroup = "Leavening Agent";
                            break;
                        case "6":
                            foodGroup = "Spice";
                            break;
                        case "7":
                            foodGroup = "Fat";
                            break;
                        case "8":
                            foodGroup = "Liquid";
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Returning to the main menu.");
                            return false;
                    }

                    Console.WriteLine($"Enter Calories for {ingredientName} (or type 'back' to cancel):");
                    if (!int.TryParse(Console.ReadLine(), out int calories))
                    {
                        Console.WriteLine("Invalid calories. Returning to the main menu.");
                        return false;
                    }

                    // Create a new ingredient and add it to the lists
                    Ingredient ingredient = new Ingredient(ingredientName, quantity, measurement, foodGroup, calories);
                    Ingredients.Add(ingredient);
                    OriginalIngredients.Add(new Ingredient(ingredientName, quantity, measurement, foodGroup, calories));
                }

                Console.WriteLine("How many steps do you want to enter?");
                input = Console.ReadLine();
                if (input.ToLower() == "back") return false;

                if (!int.TryParse(input, out int stepsCount))
                {
                    Console.WriteLine("Invalid number of steps. Returning to the main menu.");
                    return false;
                }

                for (int i = 1; i <= stepsCount; i++)
                {
                    Console.WriteLine($"Enter Step {i} (or type 'back' to cancel):");
                    string step = Console.ReadLine();
                    if (step.ToLower() == "back") return false;

                    Steps.Add(step);
                }

                Console.WriteLine("All ingredients and steps entered.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while entering the recipe: {ex.Message}");
                return false;
            }
        } // End of method

        // Method to print the recipe
        public void PrintRecipe()
        {
            try
            {
                int totalCalories = CalculateTotalCalories();

                Console.WriteLine($"\nRecipe: {RecipeName}");
                Console.WriteLine(new string('-', RecipeName.Length + 8)); // Underline the recipe name
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in Ingredients)
                {
                    string ingredientDetails = $"{ingredient.Quantity} {ingredient.Measurement} of {ingredient.Name} ({ingredient.FoodGroup}, {ingredient.Calories} calories)";
                    Console.WriteLine(ingredientDetails);
                }

                Console.WriteLine("Steps:");
                for (int i = 0; i < Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Steps[i]}");
                }

                Console.WriteLine($"\nTotal Calories: {totalCalories}");
                SetCalorieWarningDelegate(totalCalories);
                CalorieWarning(totalCalories);
                Console.ForegroundColor = ConsoleColor.Gray; // Reset text color to light gray
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while printing the recipe: {ex.Message}");
            }
        } // End of method

        // Method to calculate total calories
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (var ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        } // End of method

        // Method to set the calorie warning delegate based on total calories
        public void SetCalorieWarningDelegate(int totalCalories)
        {
            if (totalCalories > 2000)
            {
                CalorieWarning = Over2000CaloriesWarning;
            }
            else if (totalCalories > 1200)
            {
                CalorieWarning = Over1200CaloriesWarning;
            }
            else if (totalCalories > 600)
            {
                CalorieWarning = Over600CaloriesWarning;
            }
            else if (totalCalories > 300)
            {
                CalorieWarning = Over300CaloriesWarning;
            }
            else
            {
                CalorieWarning = DefaultWarning;
            }
        } // End of method

        // Method to get the calorie warning message based on total calories
        public string GetCalorieWarningMessage(int totalCalories)
        {
            if (totalCalories > 2000)
            {
                return "Warning: Are you trying to set a new record for the highest calorie dish ever? This monstrosity is over 2000 calories! Why not just eat a brick of butter?";
            }
            else if (totalCalories > 1200)
            {
                return "Warning: Over 1200 calories! Are you sure this is a recipe and not a nutritional disaster? Maybe rethink your life choices.";
            }
            else if (totalCalories > 600)
            {
                return "Warning: This recipe is over 600 calories! Do you have a death wish, or are you just planning on sharing this with a small village?";
            }
            else if (totalCalories > 300)
            {
                return "Warning: This recipe is a calorie bomb! Over 300 calories? Are you trying to feed an army or just yourself? Excessive calorie intake can lead to weight gain, increased risk of chronic diseases like diabetes and heart disease. Please be mindful of your health.";
            }
            else
            {
                return "Your recipe looks good!";
            }
        } // End of method

        // Calorie warning for over 2000 calories
        public void Over2000CaloriesWarning(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: Are you trying to set a new record for the highest calorie dish ever? This monstrosity is over 2000 calories! Why not just eat a brick of butter?");
        } // End of method

        // Calorie warning for over 1200 calories
        public void Over1200CaloriesWarning(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: Over 1200 calories! Are you sure this is a recipe and not a nutritional disaster? Maybe rethink your life choices.");
        } // End of method

        // Calorie warning for over 600 calories
        public void Over600CaloriesWarning(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: This recipe is over 600 calories! Do you have a death wish, or are you just planning on sharing this with a small village?");
        } // End of method

        // Calorie warning for over 300 calories
        public void Over300CaloriesWarning(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: This recipe is a calorie bomb! Over 300 calories? Are you trying to feed an army or just yourself?");
            Console.WriteLine("Excessive calorie intake can lead to weight gain, increased risk of chronic diseases like diabetes and heart disease. Please be mindful of your health.");
        } // End of method

        // Default warning for recipes with fewer calories
        public void DefaultWarning(int totalCalories)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your recipe looks good!");
        } // End of method

        // Method to delete the recipe
        public void DeleteRecipe()
        {
            try
            {
                Ingredients.Clear();
                OriginalIngredients.Clear();
                Steps.Clear();
                Console.WriteLine("Recipe Deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the recipe: {ex.Message}");
            }
        } // End of method

        // Method to reset the values to the original state
        public void ResetValues()
        {
            try
            {
                Ingredients.Clear();
                foreach (var ingredient in OriginalIngredients)
                {
                    Ingredients.Add(new Ingredient(ingredient.Name, ingredient.Quantity, ingredient.Measurement, ingredient.FoodGroup, ingredient.Calories));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while resetting the values: {ex.Message}");
            }
        } // End of method

        // Method to edit the recipe
        public void EditRecipe()
        {
            try
            {
                Console.WriteLine($"Editing Recipe: {RecipeName}");
                Console.WriteLine("You can update the ingredient quantities, measurements, food groups, and calories.");

                for (int i = 0; i < Ingredients.Count; i++)
                {
                    var ingredient = Ingredients[i];

                    Console.WriteLine($"Current Ingredient {i + 1}: {ingredient.Name}, {ingredient.Quantity} {ingredient.Measurement} ({ingredient.FoodGroup}, {ingredient.Calories} calories)");

                    Console.WriteLine($"Enter new Quantity for {ingredient.Name} (or press Enter to keep current):");

                    string newQuantity = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newQuantity))
                    {
                        ingredient.Quantity = newQuantity;
                    }

                    Console.WriteLine($"Enter new Measurement for {ingredient.Name} (or press Enter to keep current):");
                    string newMeasurement = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newMeasurement))
                    {
                        ingredient.Measurement = newMeasurement;
                    }

                    Console.WriteLine($"Enter new Food Group for {ingredient.Name} (or press Enter to keep current):");
                    string newFoodGroup = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newFoodGroup))
                    {
                        ingredient.FoodGroup = newFoodGroup;
                    }

                    Console.WriteLine($"Enter new Calories for {ingredient.Name} (or press Enter to keep current):");
                    if (int.TryParse(Console.ReadLine(), out int newCalories))
                    {
                        ingredient.Calories = newCalories;
                    }
                }

                Console.WriteLine("Ingredients updated. You can also update the steps.");

                for (int i = 0; i < Steps.Count; i++)
                {
                    Console.WriteLine($"Current Step {i + 1}: {Steps[i]}");
                    Console.WriteLine($"Enter new Step {i + 1} (or press Enter to keep current):");
                    string newStep = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newStep))
                    {
                        Steps[i] = newStep;
                    }
                }

                Console.WriteLine("Recipe updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while editing the recipe: {ex.Message}");
            }
        } // End of method

        // Prefill Pancake recipe
        public void EnterPancakeRecipe()
        {
            try
            {
                Console.WriteLine("Prefilling Pancake Recipe...");

                Ingredients.Add(new Ingredient("Flour", "1", "cup", "Grain", 100));
                Ingredients.Add(new Ingredient("Milk", "1", "cup", "Dairy", 150));
                Ingredients.Add(new Ingredient("Egg", "1", "large", "Protein", 70));
                Ingredients.Add(new Ingredient("Sugar", "2", "tablespoons", "Sweetener", 30));
                Ingredients.Add(new Ingredient("Baking Powder", "2", "teaspoons", "Leavening Agent", 5));
                Ingredients.Add(new Ingredient("Salt", "0.5", "teaspoons", "Spice", 0));
                Ingredients.Add(new Ingredient("Butter", "2", "tablespoons", "Fat", 200));

                OriginalIngredients.AddRange(Ingredients);

                Steps.Add("In a large bowl, whisk together the flour, sugar, baking powder, and salt.");
                Steps.Add("Make a well in the center and pour in the milk, egg, and melted butter; mix until smooth.");
                Steps.Add("Heat a lightly oiled griddle or frying pan over medium-high heat.");
                Steps.Add("Pour or scoop the batter onto the griddle, using approximately 1/4 cup for each pancake.");
                Steps.Add("Brown on both sides and serve hot.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while prefilling the pancake recipe: {ex.Message}");
            }
        } // End of method

        // Prefill Ciabatta recipe
        public void EnterCiabattaRecipe()
        {
            try
            {
                Console.WriteLine("Prefilling Ciabatta Bread Recipe...");

                Ingredients.Add(new Ingredient("Bread Flour", "500", "grams", "Grain", 1700));
                Ingredients.Add(new Ingredient("Water", "350", "ml", "Liquid", 0));
                Ingredients.Add(new Ingredient("Olive Oil", "2", "tablespoons", "Fat", 240));
                Ingredients.Add(new Ingredient("Salt", "1", "teaspoon", "Spice", 0));
                Ingredients.Add(new Ingredient("Yeast", "1", "teaspoon", "Leavening Agent", 10));

                OriginalIngredients.AddRange(Ingredients);

                Steps.Add("Mix the flour, water, olive oil, salt, and yeast in a large bowl.");
                Steps.Add("Knead the dough for about 10 minutes.");
                Steps.Add("Let the dough rise for about 1-2 hours.");
                Steps.Add("Shape the dough into a flat, rectangular loaf.");
                Steps.Add("Let the dough rise again for 45 minutes.");
                Steps.Add("Preheat the oven to 220°C (425°F).");
                Steps.Add("Bake the bread for 20-25 minutes until golden brown.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while prefilling the ciabatta recipe: {ex.Message}");
            }
        } // End of method

        // Override of the ToString method to provide a string representation of the recipe
        public override string ToString()
        {
            return $"{RecipeName} - {Ingredients.Count} ingredients, {CalculateTotalCalories()} calories";
        } // End of method

    } // End of Recipe class

} // End of RecipeApp.Class namespace
