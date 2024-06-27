using RecipeApp.Class;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class FilterWindow : Window
    {
        private List<Recipe> allRecipes;
        public List<Recipe> FilteredRecipes { get; private set; }

        public FilterWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            allRecipes = recipes;
            FilteredRecipes = new List<Recipe>();
        }

        private void BtnApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            var selectedFoodGroup = (cbFoodGroup.SelectedItem as ComboBoxItem)?.Content.ToString();
            var ingredient = txtIngredient.Text.ToLower();
            var maxCalories = int.TryParse(txtMaxCalories.Text, out int calories) ? calories : int.MaxValue;

            FilteredRecipes = allRecipes.Where(r =>
                (string.IsNullOrEmpty(selectedFoodGroup) || r.Ingredients.Any(i => i.FoodGroup == selectedFoodGroup)) &&
                (string.IsNullOrEmpty(ingredient) || r.Ingredients.Any(i => i.Name.ToLower().Contains(ingredient))) &&
                r.CalculateTotalCalories() <= maxCalories
            ).ToList();

            this.Close();
        }
    }
}
