using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using RecipeApp.Class;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class EnterRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }
        private List<Ingredient> ingredients;

        public EnterRecipeWindow()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
        }

        private void BtnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIngredientName.Text) &&
                !string.IsNullOrEmpty(txtQuantity.Text) &&
                cbMeasurementUnit.SelectedItem != null &&
                cbFoodGroup.SelectedItem != null &&
                int.TryParse(txtCalories.Text, out int calories))
            {
                var ingredient = new Ingredient(
                    txtIngredientName.Text,
                    txtQuantity.Text,
                    ((ComboBoxItem)cbMeasurementUnit.SelectedItem).Content.ToString(),
                    ((ComboBoxItem)cbFoodGroup.SelectedItem).Content.ToString(),
                    calories);

                ingredients.Add(ingredient);
                ClearIngredientInputs();
            }
            else
            {
                MessageBox.Show("Please enter all ingredient details.");
            }
        }

        private void BtnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRecipeName.Text))
            {
                NewRecipe = new Recipe(txtRecipeName.Text);
                foreach (var ingredient in ingredients)
                {
                    NewRecipe.Ingredients.Add(ingredient);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a recipe name.");
            }
        }

        private void ClearIngredientInputs()
        {
            txtIngredientName.Clear();
            txtQuantity.Clear();
            cbMeasurementUnit.SelectedItem = null;
            txtCalories.Clear();
            cbFoodGroup.SelectedItem = null;
        }
    }
}
