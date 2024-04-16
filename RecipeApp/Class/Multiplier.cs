using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Class
{
    internal class Multiplier

    { // handles changing the string from the user input into a double and then applying the multiplier to it. 
        public void ApplyMultiplier( List<Ingredient> ingredients, double multiplier) //
        {
            foreach (var ingredient in ingredients)// this will iterates through each ingredient and converts the property of the quantity to a double.
            {
                ingredient.Quantity = (double.Parse(ingredient.Quantity) * multiplier).ToString();
            }
        }
    }
}
