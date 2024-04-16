using System;
using System.Collections.Generic;

namespace RecipeApp.Class
{
    internal class Recipe
    { // the properties will get stored in these arrays
        public List<Ingredient> orignalIngredients;
        public List<Ingredient> Ingredients { get; private set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            orignalIngredients = new List<Ingredient>();
        }

        public void EnterRecipe()
        { // this will run through prompts asking the user for their recipe
            Console.WriteLine("How many Ingredients do you want to enter?");
            int InNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= InNum; i++) // this counter will allow the system to loop through the amount the user requests
            {
                Console.WriteLine($"Enter Ingredient {i}:"); // i i this case will take the users input and will be placed in the question for clarity
                string ingredientName = Console.ReadLine();

                Console.WriteLine($"Enter Quantity for {ingredientName}:");
                string quantity = Console.ReadLine();

                Console.WriteLine($"Enter Measurement for {ingredientName} ({quantity}):");
                string measurement = Console.ReadLine();

                Ingredient ingredient = new Ingredient(ingredientName, quantity, measurement);
                Ingredients.Add(ingredient);
            }

            Console.WriteLine("All ingredients entered.");

            Console.WriteLine("How many Steps do you want to enter?");
            int StepsNum = int.Parse(Console.ReadLine());

            List<string> steps = new List<string>();

            for (int i = 1; i <= StepsNum; i++)
            {
                Console.WriteLine($"Enter Step {i}:");
                string step = Console.ReadLine();
                steps.Add(step);
            }

            Console.WriteLine("All steps entered.");

            Console.WriteLine("\nRecipe:"); // this will handle the format of the printing out the recip 
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Measurement} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }
        public void PrintRecipe() // this method is used as the same as before but turned into its own method for easy use in the program for printing out the recip
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Measurement} of {ingredient.Name}");
            }
        }
        public void DeleteRecipe() // this will delete the recipe taking ingredients and using the function clear to reset the array
        {
            Ingredients.Clear();
            Console.WriteLine("Recipe Deleted");
        }
        
        public void ResetValues() // This will run through the program iterating over the initial aray comparing it to the the quantity. if null there will be no changed if there are changes it will be reversed to its original state.
        {
            foreach(var orignalIngredient in orignalIngredients)
            {
                var ingredient = Ingredients.Find(i => i.Name == orignalIngredient.Name);
                if (ingredient != null)
                {
                    ingredient.Quantity = orignalIngredient.Quantity;
                }
            }
        }
    }
}