using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ST10261874_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class Display : Window
    {
        private List<string> recipeNames;

        public Display(List<string> recipeNames)
        {
            InitializeComponent();
            this.recipeNames = recipeNames; // Initialize with provided recipe names
            PopulateRecipeListView(); // Populate the recipe list view when window is initialized
        }

        private void PopulateRecipeListView()
        {
            // Clear existing items in the ListView
            RecipeListView.Items.Clear();

            // Add recipes to ListView
            foreach (RecipeInfo recipeInfo in RecipeManager.Recipes)
            {
                // Add each recipe info object to the list view
                RecipeListView.Items.Add(recipeInfo);
            }
        }

        // Method to update the ListView with scaled recipe
        public void UpdateScaledRecipe(RecipeInfo scaledRecipe)
        {
            // Update or add scaled recipe to the ListView
            RecipeInfo existingRecipe = RecipeManager.Recipes.FirstOrDefault(r => r.Name == scaledRecipe.Name);
            if (existingRecipe != null)
            {
                RecipeListView.Items.Remove(existingRecipe); // Remove existing recipe if it exists
            }
            RecipeListView.Items.Add(scaledRecipe); // Add scaled recipe to the list view
        }

        // Method to update the ListView with reset recipe
        public void UpdateResetRecipe(RecipeInfo resetRecipe)
        {
            // Update or add reset recipe to the ListView
            RecipeInfo existingRecipe = RecipeManager.Recipes.FirstOrDefault(r => r.Name == resetRecipe.Name);
            if (existingRecipe != null)
            {
                RecipeListView.Items.Remove(existingRecipe); // Remove existing recipe if it exists
            }
            RecipeListView.Items.Add(resetRecipe); // Add reset recipe to the list view
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Open the EnterDetails window to add more recipes
            EnterDetails enterDetailsWindow = new EnterDetails();
            enterDetailsWindow.Show();
            this.Close(); // Close the current Display window
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Return to the main Recipe window
            Recipe recipe = new Recipe();
            recipe.Show();
            this.Close(); // Close the current Display window
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Get the selected sorting option from the ComboBox
            string sortBy = (SortByComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Sort the RecipeListView based on the selected option
            if (sortBy == "Sort by Name")
            {
                RecipeListView.Items.SortDescriptions.Clear();
                RecipeListView.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending)); // Sort by recipe name
            }
            else if (sortBy == "Sort by Date")
            {
                RecipeListView.Items.SortDescriptions.Clear();
                RecipeListView.Items.SortDescriptions.Add(new SortDescription("DateAdded", ListSortDirection.Ascending)); // Sort by date added
            }
        }

        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Display instructions in a message box when the image is clicked
            string instructions = "Instructions for using this window:\n\n" +
                                  "1. Use the Sort by dropdown to select sorting criteria (Name or Date Added).\n" +
                                  "2. Click the Sort button to apply the selected sorting.\n" +
                                  "3. View recipes in the list, sorted as per your selection.\n" +
                                  "4. Click Add More Recipes to add new recipes to the list.\n" +
                                  "5. Click Go Back to Recipe Menu to return to the main recipe menu window.";

            MessageBox.Show(instructions, "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
