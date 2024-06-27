using RecipeApp.Class;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System.Collections.Generic;

namespace RecipeApplication.MainApplication
{
    public partial class MainWindow : Window
    {
        // ObservableCollection to store the list of recipes
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();

        // Constructor to initialize the MainWindow
        public MainWindow()
        {
            InitializeComponent();
        } // End of method

        // Event handler for the "Enter A Recipe" button click
        private void BtnEnterRecipe_Click(object sender, RoutedEventArgs e)
        {
            var enterRecipeWindow = new RecipeApplication.ManageRecipeApplication.EnterRecipeWindow();
            enterRecipeWindow.ShowDialog();

            if (enterRecipeWindow.NewRecipe != null)
            {
                Recipes.Add(enterRecipeWindow.NewRecipe);
                DisplayRecipe(enterRecipeWindow.NewRecipe);
            }
        } // End of method

        // Event handler for the "Prefill Pancake Recipe" button click
        private void BtnPrefillPancake_Click(object sender, RoutedEventArgs e)
        {
            var pancakeRecipe = new Recipe("Pancake");
            pancakeRecipe.EnterPancakeRecipe();
            Recipes.Add(pancakeRecipe);
            DisplayRecipe(pancakeRecipe);
        } // End of method

        // Event handler for the "Prefill Ciabatta Bread Recipe" button click
        private void BtnPrefillCiabatta_Click(object sender, RoutedEventArgs e)
        {
            var ciabattaRecipe = new Recipe("Ciabatta Bread");
            ciabattaRecipe.EnterCiabattaRecipe();
            Recipes.Add(ciabattaRecipe);
            DisplayRecipe(ciabattaRecipe);
        } // End of method

        // Event handler for the "Select A Recipe" button click
        private void BtnSelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            var selectRecipeWindow = new RecipeApplication.ManageRecipeApplication.SelectRecipeWindow(Recipes);
            selectRecipeWindow.ShowDialog();

            if (selectRecipeWindow.SelectedRecipes != null && selectRecipeWindow.SelectedRecipes.Count > 0)
            {
                var manageRecipeWindow = new RecipeApplication.ManageRecipeApplication.EditRecipeWindow(selectRecipeWindow.SelectedRecipe, Recipes);
                manageRecipeWindow.ShowDialog();
                DisplayRecipe(selectRecipeWindow.SelectedRecipe);
            }
        } // End of method

        // Event handler for the "Exit" button click
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } // End of method

        // Method to display the selected recipe in the content area
        private void DisplayRecipe(Recipe recipe)
        {
            contentArea.Children.Clear();

            var recipeNameTextBlock = new TextBlock
            {
                Text = recipe.RecipeName,
                FontSize = 24,
                FontWeight = System.Windows.FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.DarkBlue),
                Margin = new Thickness(10)
            };
            contentArea.Children.Add(recipeNameTextBlock);

            var ingredientsTextBlock = new TextBlock
            {
                Text = "Ingredients:",
                FontSize = 18,
                FontWeight = System.Windows.FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.DarkGreen),
                Margin = new Thickness(10, 10, 10, 5)
            };
            contentArea.Children.Add(ingredientsTextBlock);

            foreach (var ingredient in recipe.Ingredients)
            {
                var ingredientTextBlock = new TextBlock
                {
                    Text = ingredient.ToString(),
                    FontSize = 16,
                    Foreground = new SolidColorBrush(Colors.Black),
                    Margin = new Thickness(20, 5, 10, 5)
                };
                contentArea.Children.Add(ingredientTextBlock);
            }

            var stepsTextBlock = new TextBlock
            {
                Text = "Steps:",
                FontSize = 18,
                FontWeight = System.Windows.FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.DarkGreen),
                Margin = new Thickness(10, 10, 10, 5)
            };
            contentArea.Children.Add(stepsTextBlock);

            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                var stepTextBlock = new TextBlock
                {
                    Text = $"{i + 1}. {recipe.Steps[i]}",
                    FontSize = 16,
                    Foreground = new SolidColorBrush(Colors.Black),
                    Margin = new Thickness(20, 5, 10, 5)
                };
                contentArea.Children.Add(stepTextBlock);
            }

            var totalCalories = recipe.CalculateTotalCalories();
            var caloriesTextBlock = new TextBlock
            {
                Text = $"Total Calories: {totalCalories}",
                FontSize = 18,
                FontWeight = System.Windows.FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.DarkRed),
                Margin = new Thickness(10, 10, 10, 5)
            };
            contentArea.Children.Add(caloriesTextBlock);

            recipe.SetCalorieWarningDelegate(totalCalories);
            var warningMessage = recipe.GetCalorieWarningMessage(totalCalories);
            var warningTextBlock = new TextBlock
            {
                Text = warningMessage,
                FontSize = 16,
                Foreground = new SolidColorBrush(Colors.Red),
                Margin = new Thickness(10, 5, 10, 5)
            };
            contentArea.Children.Add(warningTextBlock);
        } // End of method

        // Event handler for the "Create Chart" button click
        private void BtnCreateChart_Click(object sender, RoutedEventArgs e)
        {
            if (Recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            var selectRecipesWindow = new RecipeApplication.ManageRecipeApplication.SelectRecipeWindow(Recipes);
            selectRecipesWindow.ShowDialog();

            if (selectRecipesWindow.SelectedRecipes != null && selectRecipesWindow.SelectedRecipes.Count > 0)
            {
                DisplayMenuPieChart(selectRecipesWindow.SelectedRecipes.ToList());
            }
        } // End of method

        // Method to display a pie chart of the food group distribution in the selected recipes
        private void DisplayMenuPieChart(List<Recipe> selectedRecipes)
        {
            var foodGroupCounts = new Dictionary<string, int>();

            foreach (var recipe in selectedRecipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (!foodGroupCounts.ContainsKey(ingredient.FoodGroup))
                    {
                        foodGroupCounts[ingredient.FoodGroup] = 0;
                    }
                    foodGroupCounts[ingredient.FoodGroup]++;
                }
            }

            var plotModel = new PlotModel { Title = "Food Group Distribution" };

            var pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            foreach (var foodGroup in foodGroupCounts)
            {
                pieSeries.Slices.Add(new PieSlice(foodGroup.Key, foodGroup.Value));
            }

            plotModel.Series.Add(pieSeries);

            var plotView = new PlotView
            {
                Model = plotModel,
                Height = 400,
                Width = 600
            };

            contentArea.Children.Clear();
            contentArea.Children.Add(plotView);
        } // End of method
    } // End of MainWindow class
} // End of RecipeApplication.MainApplication namespace
