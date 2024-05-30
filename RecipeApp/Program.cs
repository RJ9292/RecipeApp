using System;
using System.Collections.Generic;

namespace RecipeApp.Class
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Set console background and foreground colors
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear(); // Apply the background color to the entire console

            DisplayExplanations(); // Display explanations for the user

            List<Recipe> recipes = new List<Recipe>();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option to the Corresponding Number:")
                Console.WriteLine("");
                Console.WriteLine("1) Enter A Recipe");
                Console.WriteLine("2) Prefill Pancake Recipe");
                Console.WriteLine("3) Prefill Ciabatta Bread Recipe");
                Console.WriteLine("4) Select A Recipe");
                Console.WriteLine("5) Exit");
                Console.WriteLine("\r\nSelect an Option:   ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            // Handles the entire input of a new recipe from the user
                            Console.WriteLine("Enter the name of the new recipe:");
                            string recipeName = Console.ReadLine();
                            Recipe newRecipe = new Recipe(recipeName);
                            if (newRecipe.EnterRecipe())
                            {
                                recipes.Add(newRecipe);
                            }
                            break;

                        case "2":
                            // Prefill a pancake recipe
                            Recipe pancakeRecipe = new Recipe("Pancake");
                            pancakeRecipe.EnterPancakeRecipe();
                            recipes.Add(pancakeRecipe);
                            break;

                        case "3":
                            // Prefill a ciabatta bread recipe
                            Recipe ciabattaRecipe = new Recipe("Ciabatta Bread");
                            ciabattaRecipe.EnterCiabattaRecipe();
                            recipes.Add(ciabattaRecipe);
                            break;

                        case "4":
                            // Select a recipe to perform actions on it
                            SelectRecipe(recipes, out Recipe selectedRecipe);
                            if (selectedRecipe != null)
                            {
                                ManageSelectedRecipe(recipes, selectedRecipe);
                            }
                            break;

                        case "5":
                            // Exit the application
                            exit = true;
                            break;

                        default:
                            // If the user selects a wrong number or input, this prompt is shown
                            Console.WriteLine("Incorrect Selection");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                // Brings you back to the main menu after you press enter
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        // Display explanations for calories and food groups
        private static void DisplayExplanations()
        {
            Console.WriteLine("Explanation:");
            Console.WriteLine("Calories: The energy provided by food, measured in kilocalories (kcal).");
            Console.WriteLine("Food Groups: Categories of foods that have similar nutritional properties. Examples include:");
            Console.WriteLine("- Grains");
            Console.WriteLine("- Dairy");
            Console.WriteLine("- Protein");
            Console.WriteLine("- Sweetener");
            Console.WriteLine("- Leavening Agent");
            Console.WriteLine("- Spice");
            Console.WriteLine("- Fat");
            Console.WriteLine("- Liquid");
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        // Select a recipe from the list
        private static void SelectRecipe(List<Recipe> recipes, out Recipe selectedRecipe)
        {
            selectedRecipe = null;
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            // Sort recipes alphabetically
            recipes.Sort((r1, r2) => r1.RecipeName.CompareTo(r2.RecipeName));

            Console.WriteLine("Select a Recipe by Number:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {recipes[i].RecipeName}");
            }
            Console.WriteLine("Enter the number of the recipe you want to select:");
            if (int.TryParse(Console.ReadLine(), out int recipeNumber) && recipeNumber > 0 && recipeNumber <= recipes.Count)
            {
                selectedRecipe = recipes[recipeNumber - 1];
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        // Manage the selected recipe
        private static void ManageSelectedRecipe(List<Recipe> recipes, Recipe selectedRecipe)
        {
            bool backToMenu = false;
            while (!backToMenu)
            {
                Console.Clear();
                Console.WriteLine($"Manage Selected Recipe: {selectedRecipe.RecipeName}");
                Console.WriteLine("1) Change Measurements");
                Console.WriteLine("2) Reset Measurements");
                Console.WriteLine("3) Print Recipe");
                Console.WriteLine("4) Edit Recipe");
                Console.WriteLine("5) Delete Recipe");
                Console.WriteLine("6) Back to Main Menu");
                Console.WriteLine("\r\nSelect an Option:   ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            // Change measurements with the ratios provided
                            Multiplier multiplier = new Multiplier();
                            Console.WriteLine("Enter a Multiplier (e.g., 0.5, 2, 3):");
                            if (double.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double multiplierValue))
                            {
                                multiplier.ApplyMultiplier(selectedRecipe.Ingredients, multiplierValue);
                                selectedRecipe.PrintRecipe();
                            }
                            else
                            {
                                Console.WriteLine("Invalid multiplier value.");
                            }
                            break;

                        case "2":
                            // Reset the values to the original state
                            selectedRecipe.ResetValues();
                            selectedRecipe.PrintRecipe();
                            break;

                        case "3":
                            // Print the recipe to check if the change in measurements were correct
                            selectedRecipe.PrintRecipe();
                            Console.ForegroundColor = ConsoleColor.Gray; // Reset text color to light gray
                            break;

                        case "4":
                            // Edit the selected recipe
                            selectedRecipe.EditRecipe();
                            break;

                        case "5":
                            // Delete the selected recipe
                            Console.WriteLine("Are you sure you want to delete this recipe? (yes/no)");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                recipes.Remove(selectedRecipe);
                                backToMenu = true; // Go back to the main menu after deletion
                            }
                            break;

                        case "6":
                            // Back to main menu
                            backToMenu = true;
                            break;

                        default:
                            // If the user selects a wrong number or input, this prompt is shown
                            Console.WriteLine("Incorrect Selection");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                // Brings you back to the manage menu after you press enter
                if (!backToMenu)
                {
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
