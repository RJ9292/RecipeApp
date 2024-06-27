using RecipeApp.Class;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class SelectRecipesWindow : Window
    {
        // Property to store the selected recipes
        public List<Recipe> SelectedRecipes { get; private set; }

        // Constructor to initialize the SelectRecipesWindow with the list of recipes
        public SelectRecipesWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            lstRecipes.ItemsSource = recipes; // Set the ItemsSource of the ListBox to the list of recipes
        } // End of method

        // Event handler for the "Select" button click
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            // Cast the selected items to a list of Recipe objects and store in SelectedRecipes
            SelectedRecipes = lstRecipes.SelectedItems.Cast<Recipe>().ToList();
            this.Close(); // Close the window
        } // End of method
    } // End of SelectRecipesWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
