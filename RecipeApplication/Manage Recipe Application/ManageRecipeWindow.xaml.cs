using RecipeApp.Class;
using System.Collections.ObjectModel;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class ManageRecipeWindow : Window
    {
        // Private fields to store the selected recipe and the collection of recipes
        private Recipe recipe;
        private ObservableCollection<Recipe> recipes;

        // Constructor to initialize the ManageRecipeWindow with the selected recipe and the collection of recipes
        public ManageRecipeWindow(Recipe selectedRecipe, ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();
            this.recipe = selectedRecipe;
            this.recipes = recipes;
            DisplayRecipeDetails();
        } // End of method

        // Method to display the details of the selected recipe
        private void DisplayRecipeDetails()
        {
            txtRecipeName.Text = recipe.RecipeName;
            lstIngredients.ItemsSource = recipe.Ingredients;
            lstSteps.ItemsSource = recipe.Steps;
            txtTotalCalories.Text = recipe.CalculateTotalCalories().ToString();
        } // End of method

        // Event handler for the "Change Measurements" button click
        private void BtnChangeMeasurements_Click(object sender, RoutedEventArgs e)
        {
            var multiplierWindow = new MultiplierWindow(recipe);
            multiplierWindow.ShowDialog();
            DisplayRecipeDetails();
        } // End of method

        // Event handler for the "Reset Measurements" button click
        private void BtnResetMeasurements_Click(object sender, RoutedEventArgs e)
        {
            recipe.ResetValues();
            DisplayRecipeDetails();
        } // End of method

        // Event handler for the "Edit Recipe" button click
        private void BtnEditRecipe_Click(object sender, RoutedEventArgs e)
        {
            var editRecipeWindow = new EditRecipeWindow(recipe, recipes);
            editRecipeWindow.ShowDialog();
            DisplayRecipeDetails();
        } // End of method

        // Event handler for the "Delete Recipe" button click
        private void BtnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Recipe", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                recipes.Remove(recipe);
                MessageBox.Show($"Recipe '{recipe.RecipeName}' deleted.");
                this.Close();
            }
        } // End of method

        // Event handler for the "Print Recipe" button click
        private void BtnPrintRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic to print the recipe
            recipe.PrintRecipe();
        } // End of method

        // Event handler for the "Back to Menu" button click
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } // End of method
    } // End of ManageRecipeWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
