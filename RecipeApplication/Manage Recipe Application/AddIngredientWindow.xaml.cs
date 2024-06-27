using System.Windows;
using System.Windows.Controls;
using RecipeApp.Class;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class AddIngredientWindow : Window
    {
        private Recipe recipe;

        public AddIngredientWindow()
        {
            InitializeComponent();
        }

        public AddIngredientWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIngredientName.Text) &&
                !string.IsNullOrEmpty(txtQuantity.Text) &&
                cbMeasurementUnit.SelectedItem != null &&
                cbFoodGroup.SelectedItem != null &&
                int.TryParse(txtCalories.Text, out int calories))
            {
                Ingredient ingredient = new Ingredient(
                    txtIngredientName.Text,
                    txtQuantity.Text,
                    ((ComboBoxItem)cbMeasurementUnit.SelectedItem).Content.ToString(),
                    ((ComboBoxItem)cbFoodGroup.SelectedItem).Content.ToString(),
                    calories);

                recipe.Ingredients.Add(ingredient);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter all ingredient details.");
            }
        }
    }
}
