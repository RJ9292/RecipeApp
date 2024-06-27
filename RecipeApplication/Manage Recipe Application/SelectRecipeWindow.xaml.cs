using RecipeApp.Class;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class SelectRecipeWindow : Window
    {
        // Property to store the selected recipe
        public Recipe SelectedRecipe { get; private set; }

        // Property to store the selected recipes
        public ObservableCollection<Recipe> SelectedRecipes { get; private set; }

        // Private field to store the list of recipes
        private ObservableCollection<Recipe> recipes;

        // Constructor to initialize the SelectRecipeWindow with the list of recipes
        public SelectRecipeWindow(ObservableCollection<Recipe> recipes)
        {
            InitializeComponent();
            this.recipes = recipes;
            // Set the ItemsSource of the ListBox to a formatted list of recipe details
            lstRecipes.ItemsSource = recipes.Select(r => $"{r.RecipeName} - {r.Ingredients.Count} ingredients, {r.CalculateTotalCalories()} calories").ToList();
        } // End of method

        // Event handler for the "Select" button click
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one recipe.");
                return;
            }

            SelectedRecipes = new ObservableCollection<Recipe>();
            foreach (var selectedItem in lstRecipes.SelectedItems)
            {
                var recipeName = selectedItem.ToString().Split('-')[0].Trim();
                var selectedRecipe = recipes.FirstOrDefault(r => r.RecipeName == recipeName);
                if (selectedRecipe != null)
                {
                    SelectedRecipes.Add(selectedRecipe);
                }
            }

            if (SelectedRecipes.Count == 1)
            {
                SelectedRecipe = SelectedRecipes.First();
            }

            this.DialogResult = true;
            this.Close();
        } // End of method

        // Event handler for double-clicking an item in the ListBox
        private void lstRecipes_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstRecipes.SelectedItem != null)
            {
                var recipeName = lstRecipes.SelectedItem.ToString().Split('-')[0].Trim();
                SelectedRecipe = recipes.FirstOrDefault(r => r.RecipeName == recipeName);
                if (SelectedRecipe != null)
                {
                    this.DialogResult = true;
                    this.Close();
                }
            }
        } // End of method
    } // End of SelectRecipeWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
