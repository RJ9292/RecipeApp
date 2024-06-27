using System;

namespace RecipeApp.Class
{
    public class Ingredient
    {
        // Properties of the Ingredient class
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Measurement { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }

        // Fields to store the original values for reset purposes
        private readonly string originalQuantity;
        private readonly string originalMeasurement;

        // Constructor to initialize the Ingredient object
        public Ingredient(string name, string quantity, string measurement, string foodGroup, int calories)
        {
            Name = name;
            Quantity = quantity;
            Measurement = measurement;
            FoodGroup = foodGroup;
            Calories = calories;

            // Store the original values
            originalQuantity = quantity;
            originalMeasurement = measurement;
        } // End of method

        // Method to scale and convert the quantity based on a multiplier
        public void ScaleAndConvert(double multiplier)
        {
            if (double.TryParse(Quantity, out double quantityValue))
            {
                var result = MeasurementConverter.ScaleMeasurement(quantityValue, Measurement, multiplier);
                Quantity = result.Quantity.ToString();
                Measurement = result.Unit;
            }
            else
            {
                throw new FormatException($"Invalid quantity format for ingredient {Name}.");
            }
        } // End of method

        // Method to reset the measurement to the original values
        public void ResetMeasurement()
        {
            Quantity = originalQuantity;
            Measurement = originalMeasurement;
        } // End of method

        // Method to reset only the quantity to the original value
        public void ResetValues()
        {
            Quantity = originalQuantity;
        } // End of method

        // Override of the ToString method to provide a string representation of the ingredient
        public override string ToString()
        {
            return $"{Quantity} {Measurement} of {Name} ({FoodGroup}, {Calories} calories)";
        } // End of method

        // Property to get a display string for the ingredient
        public string DisplayString => $"{Quantity} {Measurement} of {Name} ({FoodGroup}, {Calories} calories)";
    } // End of class
}
