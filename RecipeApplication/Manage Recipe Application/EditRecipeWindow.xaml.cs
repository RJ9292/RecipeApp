using RecipeApp.Class;
using RecipeApplication.MainApplication;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class EditRecipeWindow : Window
    {
        private Recipe recipe;

        public EditRecipeWindow(Recipe selectedRecipe)
        {
            InitializeComponent();
            recipe = selectedRecipe;
            DisplayRecipeDetails();
        }

        private void DisplayRecipeDetails()
        {
            txtRecipeName.Text = recipe.RecipeName;
            lstIngredients.ItemsSource = null;
            lstIngredients.ItemsSource = recipe.Ingredients;
            lstSteps.ItemsSource = null;
            lstSteps.ItemsSource = recipe.Steps;
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            recipe.RecipeName = txtRecipeName.Text;
            this.Close();
        }

        private void BtnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(recipe);
            addIngredientWindow.ShowDialog();
            DisplayRecipeDetails();
        }

        private void BtnAddStep_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNewStep.Text))
            {
                recipe.Steps.Add(txtNewStep.Text);
                txtNewStep.Clear();
                DisplayRecipeDetails();
            }
            else
            {
                MessageBox.Show("Please enter a step.");
            }
        }


        private void BtnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (lstIngredients.SelectedItem != null)
            {
                Ingredient selectedIngredient = lstIngredients.SelectedItem as Ingredient;
                recipe.Ingredients.Remove(selectedIngredient);
                DisplayRecipeDetails();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to delete.");
            }
        }

        private void BtnDeleteStep_Click(object sender, RoutedEventArgs e)
        {
            if (lstSteps.SelectedItem != null)
            {
                string selectedStep = lstSteps.SelectedItem as string;
                recipe.Steps.Remove(selectedStep);
                DisplayRecipeDetails();
            }
            else
            {
                MessageBox.Show("Please select a step to delete.");
            }
        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnChangeMeasurements_Click(object sender, RoutedEventArgs e)
        {
            var multiplierWindow = new MultiplierWindow(recipe);
            multiplierWindow.ShowDialog();
            DisplayRecipeDetails();
        }

        private void BtnResetMeasurements_Click(object sender, RoutedEventArgs e)
        {
            // Example: Reset measurements to original values (you might want to store original values somewhere)
            foreach (var ingredient in recipe.Ingredients)
            {
                // Reset logic goes here
                // Assuming we have a method to reset measurements
                ingredient.ResetMeasurement();
            }
            DisplayRecipeDetails();
        }

        private void BtnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this recipe?", "Delete Recipe", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Logic to delete the recipe
                ((MainWindow)Application.Current.MainWindow).DeleteRecipe(recipe);
                this.Close();
            }
        }

        private void BtnPrintRecipe_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).PrintRecipe(recipe);
            this.Close();
        }
    }
}
