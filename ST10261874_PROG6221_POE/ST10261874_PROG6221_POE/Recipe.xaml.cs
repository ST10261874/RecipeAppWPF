using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ST10261874_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Window
    {
        public Recipe()
        {
            InitializeComponent();
        }

        // Event handler for selecting "Enter Recipe Details" option
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            EnterDetails enterRecipeDetailsWindow = new EnterDetails(); // Create EnterDetails window instance
            this.Close(); // Close current window
            enterRecipeDetailsWindow.Show(); // Show EnterDetails window
        }

        // Event handler for selecting "Choose Recipe" option
        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            Choose chooseRecipeWindow = new Choose(); // Create Choose window instance
            this.Close(); // Close current window
            chooseRecipeWindow.Show(); // Show Choose window
        }

        // Event handler for selecting "Scale Recipe" option
        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            Scale scaleRecipeWindow = new Scale(); // Create Scale window instance
            this.Close(); // Close current window
            scaleRecipeWindow.Show(); // Show Scale window
        }

        // Event handler for selecting "Clear Recipes" option
        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            Clear clearRecipesWindow = new Clear(); // Create Clear window instance
            this.Close(); // Close current window
            clearRecipesWindow.Show(); // Show Clear window
        }

        // Event handler for selecting "Display Recipes" option
        private void ListViewItem_Selected_6(object sender, RoutedEventArgs e)
        {
            // Create a list to hold the recipe names (not currently used)
            List<string> recipeNames = new List<string>();

            // Example of adding a recipe name to the list (for demonstration purposes)
            recipeNames.Add("Example Recipe Name");

            // Pass the recipe names to the Display window
            Display displayWindow = new Display(recipeNames);
            displayWindow.Show(); // Show Display window
            this.Close(); // Close current window
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();  // Create new instance of Main window
            main.Show();  // Show Main window
            this.Close();  // Close current Recipe window
        }
    }
}
