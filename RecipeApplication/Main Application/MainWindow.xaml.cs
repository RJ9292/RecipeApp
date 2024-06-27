using RecipeApp.Class;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace RecipeApplication.MainApplication
{
    public partial class MainWindow : Window
    {
        private List<Recipe> recipes;

        public MainWindow()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
        }

        private void BtnEnterRecipe_Click(object sender, RoutedEventArgs e)
        {
            var enterRecipeWindow = new RecipeApplication.ManageRecipeApplication.EnterRecipeWindow();
            enterRecipeWindow.ShowDialog();

            if (enterRecipeWindow.NewRecipe != null)
            {
                recipes.Add(enterRecipeWindow.NewRecipe);
                DisplayRecipe(enterRecipeWindow.NewRecipe);
            }
        }

        private void BtnPrefillPancake_Click(object sender, RoutedEventArgs e)
        {
            var pancakeRecipe = new Recipe("Pancake");
            pancakeRecipe.EnterPancakeRecipe();
            recipes.Add(pancakeRecipe);
            DisplayRecipe(pancakeRecipe);
        }

        private void BtnPrefillCiabatta_Click(object sender, RoutedEventArgs e)
        {
            var ciabattaRecipe = new Recipe("Ciabatta Bread");
            ciabattaRecipe.EnterCiabattaRecipe();
            recipes.Add(ciabattaRecipe);
            DisplayRecipe(ciabattaRecipe);
        }

        private void BtnSelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            recipes.Sort((r1, r2) => r1.RecipeName.CompareTo(r2.RecipeName));

            var selectRecipeWindow = new RecipeApplication.ManageRecipeApplication.SelectRecipeWindow(recipes);
            selectRecipeWindow.ShowDialog();

            if (selectRecipeWindow.SelectedRecipe != null)
            {
                var manageRecipeWindow = new RecipeApplication.ManageRecipeApplication.EditRecipeWindow(selectRecipeWindow.SelectedRecipe);
                manageRecipeWindow.ShowDialog();
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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
        }

        public void DeleteRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
            contentArea.Children.Clear();
            MessageBox.Show("Recipe deleted.");
        }

        public void PrintRecipe(Recipe recipe)
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
                var stepCheckBox = new CheckBox
                {
                    Content = $"{i + 1}. {recipe.Steps[i]}",
                    FontSize = 16,
                    Foreground = new SolidColorBrush(Colors.Black),
                    Margin = new Thickness(20, 5, 10, 5)
                };
                contentArea.Children.Add(stepCheckBox);
            }
        }

        private void BtnCreateChart_Click(object sender, RoutedEventArgs e)
        {
            if (recipes.Count == 0)
            {
                MessageBox.Show("No recipes available.");
                return;
            }

            var selectRecipesWindow = new RecipeApplication.ManageRecipeApplication.SelectRecipesWindow(recipes);
            selectRecipesWindow.ShowDialog();

            if (selectRecipesWindow.SelectedRecipes != null && selectRecipesWindow.SelectedRecipes.Count > 0)
            {
                DisplayMenuPieChart(selectRecipesWindow.SelectedRecipes);
            }
        }

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
        }
    }
}
