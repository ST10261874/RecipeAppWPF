using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ST10261874_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for Choose.xaml
    /// </summary>
    public partial class Choose : Window
    {
        private List<RecipeInfo> displayedRecipes; // Filtered and displayed recipes
        private List<RecipeInfo> originalRecipes; // Backup of all recipes

        public Choose()
        {
            InitializeComponent();
            displayedRecipes = RecipeManager.Recipes.ToList(); // Initialize with all recipes
            originalRecipes = new List<RecipeInfo>(displayedRecipes); // Backup of all recipes
            PopulateRecipeListView(displayedRecipes);
        }

        private void PopulateRecipeListView(List<RecipeInfo> recipes)
        {
            RecipeListView.ItemsSource = recipes; // Set the ItemsSource of RecipeListView to the provided list of recipes
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected recipe
            if (RecipeListView.SelectedItem != null)
            {
                RecipeInfo selectedRecipe = RecipeListView.SelectedItem as RecipeInfo;

                // Display the details of the selected recipe in the RichTextBox
                StringBuilder detailsBuilder = new StringBuilder();
                detailsBuilder.AppendLine($"Name: {selectedRecipe.Name}");
                detailsBuilder.AppendLine($"Date Added: {selectedRecipe.DateAdded}");
                detailsBuilder.AppendLine($"Number of Ingredients: {selectedRecipe.Ingredients.Count}");
                detailsBuilder.AppendLine("Ingredients:");
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    detailsBuilder.AppendLine($"- Name: {ingredient.Name}, Quantity: {ingredient.Quantity}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
                }

                RecipeDetailsRichTextBox.Document.Blocks.Clear();
                RecipeDetailsRichTextBox.Document.Blocks.Add(new Paragraph(new Run(detailsBuilder.ToString())));

                // Populate steps in the ListBox with checkboxes
                StepsListBox.ItemsSource = selectedRecipe.Steps;

                // Show the DetailsStackPanel and hide other controls
                DetailsStackPanel.Visibility = Visibility.Visible;
                RecipeListView.Visibility = Visibility.Collapsed;
                FilterControls.Visibility = Visibility.Collapsed;
                ShowDetailsButton.Visibility = Visibility.Collapsed; // Hide Show Details button
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if all steps in StepsListBox are completed
            bool allStepsCompleted = true;

            foreach (var item in StepsListBox.Items)
            {
                var container = StepsListBox.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                if (container != null)
                {
                    var checkBox = FindVisualChild<CheckBox>(container); // Find the CheckBox in the ListBoxItem
                    if (checkBox != null && checkBox.IsChecked == false)
                    {
                        allStepsCompleted = false;
                        break;
                    }
                }
            }

            // Show appropriate message based on completion status
            if (allStepsCompleted)
            {
                MessageBox.Show("Well done on completing the steps!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
                Recipe recipe = new Recipe();
                recipe.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please complete all the steps before clicking Done.", "Incomplete Steps", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FilterRecipes(); // Filter recipes based on current filter criteria
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ResetFilters(); // Reset filters and display all recipes in case of error
            }
        }

        private void FilterRecipes()
        {
            // Gather filter criteria from UI elements
            string keyword = KeywordTextBox.Text.Trim().ToLower();
            string recipeName = RecipeNameTextBox.Text.Trim().ToLower();
            string foodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            int maxCalories = 0;

            try
            {
                if (!string.IsNullOrEmpty(MaxCaloriesTextBox.Text.Trim()))
                {
                    maxCalories = int.Parse(MaxCaloriesTextBox.Text.Trim()); // Parse max calories input
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for Max Calories.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Apply filters to displayedRecipes list
            displayedRecipes = RecipeManager.Recipes.Where(recipe =>
                (string.IsNullOrEmpty(keyword) || recipe.Name.ToLower().Contains(keyword) || recipe.Ingredients.Any(ingredient => ingredient.Name.ToLower().Contains(keyword))) &&
                (string.IsNullOrEmpty(recipeName) || recipe.Name.ToLower().Contains(recipeName)) &&
                (foodGroup == "All" || string.IsNullOrEmpty(foodGroup) || recipe.Ingredients.Any(ingredient => ingredient.FoodGroup == foodGroup)) &&
                (maxCalories == 0 || recipe.Ingredients.Sum(ingredient => Convert.ToInt32(ingredient.Calories)) <= maxCalories))
                .ToList();

            PopulateRecipeListView(displayedRecipes); // Update the RecipeListView with filtered recipes

            // If no recipes match the filter criteria, show a message and reset filters
            if (displayedRecipes.Count == 0)
            {
                MessageBox.Show("No recipes found matching the filter criteria.", "No Results", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetFilters();
            }
        }

        // Event handlers for text changes and selection changes in filter controls
        private void KeywordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterRecipes(); // Filter recipes when KeywordTextBox text changes
        }

        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterRecipes(); // Filter recipes when RecipeNameTextBox text changes
        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterRecipes(); // Filter recipes when FoodGroupComboBox selection changes
        }

        private void MaxCaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterRecipes(); // Filter recipes when MaxCaloriesTextBox text changes
        }

        // Reset all filter controls and display all original recipes
        private void ResetFilters()
        {
            KeywordTextBox.Text = string.Empty; // Clear keyword text box
            RecipeNameTextBox.Text = string.Empty; // Clear recipe name text box
            FoodGroupComboBox.SelectedIndex = 0; // Reset food group combo box to "All"
            MaxCaloriesTextBox.Text = string.Empty; // Clear max calories text box
            displayedRecipes = new List<RecipeInfo>(originalRecipes); // Restore displayed recipes to original state
            PopulateRecipeListView(displayedRecipes); // Update RecipeListView with original recipes
        }

        // Helper method to find a child of a specific type within a DependencyObject
        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i); // Get child DependencyObject at index i
                if (child != null && child is childItem)
                    return (childItem)child; // Return childItem if found
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child); // Recursive call to find childItem within child
                    if (childOfChild != null)
                        return childOfChild; // Return childItem if found
                }
            }
            return null; // Return null if childItem not found
        }

        // Reset all filters when ResetButton is clicked
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetFilters(); // Reset filters to display all original recipes
        }

        // Display instructions in a message box when Image is clicked
        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Instructions for using the window
            string instructions = "Instructions for using this window:\n\n" +
                                  "1. Use the Keyword text box to search by keywords in recipe names or ingredients.\n" +
                                  "2. Enter the Recipe Name to filter recipes by their exact names.\n" +
                                  "3. Select a Food Group from the drop-down to filter recipes by food groups.\n" +
                                  "4. Specify a Max Calories value to filter recipes by calorie content.\n" +
                                  "5. Click Filter to apply the selected filters.\n" +
                                  "6. Click Reset to clear all filters and show all recipes.\n" +
                                  "7. Click on a recipe in the list to see its details.\n" +
                                  "8. Click Show Details to display the details of the selected recipe.\n" +
                                  "9. Complete all the steps listed in the Steps section and click Done to finish.";

            MessageBox.Show(instructions, "Instructions", MessageBoxButton.OK, MessageBoxImage.Information); // Show instructions in message box
        }
    }
}
