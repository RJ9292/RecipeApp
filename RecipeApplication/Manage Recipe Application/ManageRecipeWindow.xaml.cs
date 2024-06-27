using RecipeApp.Class;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class ManageRecipeWindow : Window
    {
        private Recipe recipe;

        public ManageRecipeWindow(Recipe selectedRecipe)
        {
            InitializeComponent();
            recipe = selectedRecipe;
            DisplayRecipeDetails();
        }

        private void DisplayRecipeDetails()
        {
            txtRecipeName.Text = recipe.RecipeName;
            lstIngredients.ItemsSource = recipe.Ingredients;
            lstSteps.ItemsSource = recipe.Steps;
            txtTotalCalories.Text = recipe.CalculateTotalCalories().ToString();
        }

        private void BtnChangeMeasurements_Click(object sender, RoutedEventArgs e)
        {
            var multiplierWindow = new MultiplierWindow(recipe);
            multiplierWindow.ShowDialog();
            DisplayRecipeDetails();
        }

        private void BtnResetMeasurements_Click(object sender, RoutedEventArgs e)
        {
            recipe.ResetValues();
            DisplayRecipeDetails();
        }

        private void BtnEditRecipe_Click(object sender, RoutedEventArgs e)
        {
            var editRecipeWindow = new EditRecipeWindow(recipe);
            editRecipeWindow.ShowDialog();
            DisplayRecipeDetails();
        }

        private void BtnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Recipe", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Logic to delete the recipe
                recipe.DeleteRecipe();
                this.Close();
            }
        }

        private void BtnPrintRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Logic to print the recipe
            recipe.PrintRecipe();
        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
