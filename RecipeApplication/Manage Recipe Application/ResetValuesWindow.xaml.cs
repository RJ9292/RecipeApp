using RecipeApp.Class;
using System.Windows;

namespace RecipeApplication.ManageRecipeApplication
{
    public partial class ResetValuesWindow : Window
    {
        private Recipe _recipe;

        public ResetValuesWindow(Recipe recipe)
        {
            InitializeComponent();
            _recipe = recipe;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            _recipe.ResetValues();
            MessageBox.Show("Recipe values have been reset.");
            this.Close();
        }
    }
}
