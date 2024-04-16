namespace RecipeApp.Class
{
    internal class Ingredient
    {
        // setters and getters for the variables and array
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Measurement { get; set; }

        public Ingredient(string name, string quantity, string measurement)
        {
            Name = name;
            Quantity = quantity;
            Measurement = measurement;
        }
    }
}