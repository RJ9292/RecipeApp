using RecipeApp.Class;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class PrintRecipeWindow : Window
    {
        // Private field to store the recipe to be printed
        private Recipe recipe;

        // Constructor to initialize the PrintRecipeWindow with the given recipe
        public PrintRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            DataContext = this.recipe; // Set the DataContext for data binding
        } // End of method

        // Event handler for the "Close" button click
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window
        } // End of method
    } // End of PrintRecipeWindow class
} // End of RecipeApplication.ManageRecipeApplication namespace
