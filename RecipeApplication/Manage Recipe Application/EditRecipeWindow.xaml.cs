using RecipeApp.Class;
using System.Collections.ObjectModel;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class EditRecipeWindow : Window
    {
        // Private fields to store the selected recipe and the collection of recipes
        private Recipe recipe;
        private ObservableCollection<Recipe> recipes;

        // Constructor to initialize the EditRecipeWindow with the selected recipe and the collection of recipes
        public EditRecipeWindow(Recipe selectedRecipe, ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();
            this.recipe = selectedRecipe;
            this.recipes = recipes;
            DataContext = this.recipe;
            DisplayRecipeDetails();
        } // End of method

        // Method to display the details of the selected recipe
        private void DisplayRecipeDetails()
        {
            txtRecipeName.Text = recipe.RecipeName;
            txtTotalCalories.Text = recipe.CalculateTotalCalories().ToString();
            lstIngredients.ItemsSource = recipe.Ingredients;
            lstSteps.ItemsSource = recipe.Steps;
        } // End of method

        // Event handler for the "Save Changes" button click
        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            recipe.RecipeName = txtRecipeName.Text;
            recipe.CalculateTotalCalories();
            this.Close();
        } // End of method

        // Event handler for the "Add Ingredient" button click
        private void BtnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(recipe);
            addIngredientWindow.ShowDialog();
            DisplayRecipeDetails();
        } // End of method

        // Event handler for the "Delete Ingredient" button click
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
        } // End of method

        // Event handler for the "Add Step" button click
        private void BtnAddStep_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStep.Text))
            {
                recipe.Steps.Add(txtStep.Text);
                txtStep.Clear();
                DisplayRecipeDetails();
            }
        } // End of method

        // Event handler for the "Delete Step" button click
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
        } // End of method

        // Event handler for the "Back to Menu" button click
        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } // End of method

        // Event handler for the "Change Measurements" button click
        private void BtnChangeMeasurements_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtMultiplier.Text, out double multiplier))
            {
                var multiplierLogic = new Multiplier();
                multiplierLogic.ApplyMultiplier(recipe.Ingredients, multiplier);
                DisplayRecipeDetails();
            }
            else
            {
                MessageBox.Show("Invalid multiplier value.");
            }
        } // End of method

        // Event handler for the "Reset Measurements" button click
        private void BtnResetMeasurements_Click(object sender, RoutedEventArgs e)
        {
            recipe.ResetValues();
            DisplayRecipeDetails();
        } // End of method

        // Event handler for the "Print Recipe" button click
        private void BtnPrintRecipe_Click(object sender, RoutedEventArgs e)
        {
            var printRecipeWindow = new PrintRecipeWindow(recipe);
            printRecipeWindow.ShowDialog();
        } // End of method

        // Event handler for the "Delete Recipe" button click
        private void BtnDeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecipe(recipe);
        } // End of method

        // Method to delete the selected recipe from the collection
        public void DeleteRecipe(Recipe recipe)
        {
            if (recipes.Contains(recipe))
            {
                recipes.Remove(recipe);
                MessageBox.Show($"Recipe '{recipe.RecipeName}' deleted.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Recipe not found.");
            }
        } // End of method
    } // End of EditRecipeWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
