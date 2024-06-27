using System.Windows;
using System.Windows.Controls;
using RecipeApp.Class;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class AddIngredientWindow : Window
    {
        // Property to store the new ingredient added by the user
        public Ingredient NewIngredient { get; private set; }

        // Private field to store the recipe to which the ingredient will be added
        private Recipe recipe;

        // Constructor to initialize the AddIngredientWindow with the given recipe
        public AddIngredientWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
        } // End of method

        // Event handler for the "Add" button click
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Check if all input fields are filled correctly
            if (!string.IsNullOrEmpty(txtIngredientName.Text) &&
                !string.IsNullOrEmpty(txtQuantity.Text) &&
                cbMeasurementUnit.SelectedItem != null &&
                cbFoodGroup.SelectedItem != null &&
                int.TryParse(txtCalories.Text, out int calories))
            {
                // Create a new ingredient with the provided details
                NewIngredient = new Ingredient(
                    txtIngredientName.Text,
                    txtQuantity.Text,
                    ((ComboBoxItem)cbMeasurementUnit.SelectedItem).Content.ToString(),
                    ((ComboBoxItem)cbFoodGroup.SelectedItem).Content.ToString(),
                    calories);

                // Add the new ingredient to the recipe's ingredient list
                recipe.Ingredients.Add(NewIngredient);

                // Set the dialog result to true and close the window
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                // Show a message if any of the input fields are missing or incorrect
                MessageBox.Show("Please enter all ingredient details.");
            }
        } // End of method
    } // End of AddIngredientWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
