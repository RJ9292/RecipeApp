using System;

namespace RecipeApp.Class
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Recipe res = new Recipe();
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose an Option to the Corresponding Number:");
                Console.WriteLine("");
                Console.WriteLine("1) Enter A Recipe");
                Console.WriteLine("2) Change Measurements");
                Console.WriteLine("3) Reset Measurements");
                Console.WriteLine("4) Print Recipe");
                Console.WriteLine("5) Delete Recipe");
                Console.WriteLine("6) Exit");
                Console.WriteLine("\r\nSelect an Option:   ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Handles the entire input of the recipe from the user

                        res.EnterRecipe();
                        break;

                    case "2":
                        // Handles the change of measurements with the ratios provided
                        Multiplier multiplier = new Multiplier();
                        Console.WriteLine("Enter A Multiplier of 0.5, 2, 3.");
                        double multiplierValue = double.Parse(Console.ReadLine());
                        multiplier.ApplyMultiplier(res.Ingredients, multiplierValue);
                        break;

                    case "3":
                        // Handles resetting the values to the original state
                        res.ResetValues();
                        break;

                    case "4":
                        // handles printing the recipe to check if the change in measurements were correct
                        res.PrintRecipe();
                        break;
                        

                    case "5":
                        // deletes the recipe to create space for the next one
                        res.DeleteRecipe();
                        break;
                        
                    case "6":
                        // exits out of the console
                        exit = true;
                        break;

                    default:
                        // if the user selects a wrong number or input this prompt is shown
                        Console.WriteLine("Incorrect Selection");
                        break;
                }
                // brings you back to the main menu after you press enter
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }

        }

    }
}