using RecipeApp.Class;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class MultiplierWindow : Window
    {
        // Private field to store the selected recipe
        private Recipe recipe;

        // Constructor to initialize the MultiplierWindow with the selected recipe
        public MultiplierWindow(Recipe selectedRecipe)
        {
            InitializeComponent();
            recipe = selectedRecipe;
        } // End of method

        // Event handler for the "Apply Multiplier" button click
        private void BtnApplyMultiplier_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtMultiplier.Text, out double multiplier))
            {
                ApplyMultiplier(recipe, multiplier);
                MessageBox.Show("Multiplier applied successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid multiplier value.");
            }
        } // End of method

        // Method to apply the multiplier to the ingredients of the recipe
        private void ApplyMultiplier(Recipe recipe, double multiplier)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.ScaleAndConvert(multiplier);
            }
        } // End of method
    } // End of MultiplierWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
