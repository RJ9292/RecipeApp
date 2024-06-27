using RecipeApp.Class;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class SelectRecipeWindow : Window
    {
        public Recipe SelectedRecipe { get; private set; }

        public SelectRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            lstRecipes.ItemsSource = recipes.Select(r => new
            {
                Recipe = r,
                DisplayInfo = $"{r.RecipeName} - {r.Ingredients.Count} Ingredients - {r.CalculateTotalCalories()} Calories"
            }).ToList();
            lstRecipes.DisplayMemberPath = "DisplayInfo";
            lstRecipes.SelectedValuePath = "Recipe";
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipes.SelectedItem != null)
            {
                SelectedRecipe = (lstRecipes.SelectedValue as Recipe);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a recipe.");
            }
        }
    }
}
