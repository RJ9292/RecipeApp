using RecipeApp.Class;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class MultiplierWindow : Window
    {
        private Recipe recipe;

        public MultiplierWindow(Recipe selectedRecipe)
        {
            InitializeComponent();
            recipe = selectedRecipe;
        }

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
        }

        private void ApplyMultiplier(Recipe recipe, double multiplier)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if (double.TryParse(ingredient.Quantity, out double quantity))
                {
                    ingredient.Quantity = (quantity * multiplier).ToString();
                }
                else
                {
                    MessageBox.Show($"Unable to multiply quantity for ingredient {ingredient.Name}. Invalid format.");
                }
            }
        }
    }
}
