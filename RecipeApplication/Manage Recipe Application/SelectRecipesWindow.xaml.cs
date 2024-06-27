using RecipeApp.Class;
using System.Collections.Generic;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class SelectRecipesWindow : Window
    {
        public List<Recipe> SelectedRecipes { get; private set; }

        public SelectRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            lstRecipes.ItemsSource = recipes;
            SelectedRecipes = new List<Recipe>();
        }

        private void LstRecipes_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedRecipe = lstRecipes.SelectedItem as Recipe;
            if (selectedRecipe != null && !SelectedRecipes.Contains(selectedRecipe))
            {
                SelectedRecipes.Add(selectedRecipe);
                MessageBox.Show($"{selectedRecipe.RecipeName} added to selection.");
            }
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
