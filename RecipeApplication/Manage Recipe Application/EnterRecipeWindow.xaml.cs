using RecipeApp.Class;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class EnterRecipeWindow : Window
    {
        // Property to store the new recipe added by the user
        public Recipe NewRecipe { get; private set; }

        // Private field to store the current recipe being created
        private Recipe currentRecipe;

        // Constructor to initialize the EnterRecipeWindow
        public EnterRecipeWindow()
        {
            InitializeComponent();
            currentRecipe = new Recipe(string.Empty); // Initialize with a placeholder name
        } // End of method

        // Event handler for the "Add Ingredient" button click
        private void BtnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var addIngredientWindow = new AddIngredientWindow(currentRecipe);
            if (addIngredientWindow.ShowDialog() == true)
            {
                lstIngredients.Items.Add(addIngredientWindow.NewIngredient);
            }
        } // End of method

        // Event handler for the "Delete Ingredient" button click
        private void BtnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (lstIngredients.SelectedItem != null)
            {
                var selectedIngredient = (Ingredient)lstIngredients.SelectedItem;
                currentRecipe.Ingredients.Remove(selectedIngredient);
                lstIngredients.Items.Remove(selectedIngredient);
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
                lstSteps.Items.Add(txtStep.Text);
                txtStep.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a step.");
            }
        } // End of method

        // Event handler for the "Delete Step" button click
        private void BtnDeleteStep_Click(object sender, RoutedEventArgs e)
        {
            if (lstSteps.SelectedItem != null)
            {
                lstSteps.Items.Remove(lstSteps.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a step to delete.");
            }
        } // End of method

        // Event handler for the "Save Recipe" button click
        private void BtnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRecipeName.Text))
            {
                currentRecipe.RecipeName = txtRecipeName.Text;
                NewRecipe = currentRecipe;
                foreach (string step in lstSteps.Items)
                {
                    NewRecipe.Steps.Add(step);
                }
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a recipe name.");
            }
        } // End of method
    } // End of EnterRecipeWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
