using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ST10261874_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for Clear.xaml
    /// </summary>
    public partial class Clear : Window
    {
        private bool clearAllRecipes; // Flag to indicate if all recipes should be cleared

        public Clear()
        {
            InitializeComponent();
            PopulateRecipeListBox(); // Initialize the window by populating the recipe list
        }

        private void PopulateRecipeListBox()
        {
            // Populate the ListBox with recipe names
            RecipeSelectionListBox.ItemsSource = RecipeManager.Recipes.Select(recipe => recipe.Name).ToList();
        }

        private void ClearAllRecipes_Click(object sender, RoutedEventArgs e)
        {
            clearAllRecipes = true; // Set the flag to indicate clearing all recipes
            ShowConfirmationPrompt("Are you sure you want to clear all recipes?"); // Prompt for confirmation
        }

        private void ShowConfirmationPrompt(string message)
        {
            // Show the confirmation panel with the provided message
            ConfirmationPanel.Visibility = Visibility.Visible;
            ConfirmationPanel.Children.OfType<TextBlock>().First().Text = message;
        }

        private async void ConfirmClear_Click(object sender, RoutedEventArgs e)
        {
            // Hide all panels and show the loading screen
            ConfirmationPanel.Visibility = Visibility.Collapsed;
            LoadingScreen.Visibility = Visibility.Visible;

            // Simulate data clearing with a delay
            await Task.Delay(2000); // Simulate a 2-second delay for clearing data

            if (clearAllRecipes)
            {
                // Clear all data if confirmed
                RecipeManager.ClearAllData();
            }

            // Hide the loading screen and show the cleared message
            LoadingScreen.Visibility = Visibility.Collapsed;
            ClearedMessage.Visibility = Visibility.Visible;
        }

        private void CancelClear_Click(object sender, RoutedEventArgs e)
        {
            // Return to the initial state if clearing is cancelled
            ConfirmationPanel.Visibility = Visibility.Collapsed;
            RecipeSelectionListBox.Visibility = clearAllRecipes ? Visibility.Collapsed : Visibility.Visible;
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            // Navigate back to the main recipe window
            Recipe recipe = new Recipe();
            recipe.Show();
            this.Close();
        }

        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShowInstructions(); // Show instructions when the image is clicked
        }

        private void ShowInstructions()
        {
            // Display instructions in a message box
            string instructions = "Instructions on how to use this window:\n\n" +
                                  "1. To clear all recipes, click the 'Clear All Recipes' button.\n" +
                                  "2. Confirm your action when prompted.\n" +
                                  "3. A loading screen will appear briefly while data is cleared.\n" +
                                  "4. Once completed, a message will confirm all data has been cleared.\n" +
                                  "\n" +
                                  "For further assistance, please contact diancanaidu@gmail.com.";

            MessageBox.Show(instructions, "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
