using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ST10261874_PROG6221_POE
{
    /// <summary>
    /// Interaction logic for EnterDetails.xaml
    /// </summary>
    public partial class EnterDetails : Window
    {
        // Lists to hold ingredients, steps, and recipe names
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<Step> steps = new List<Step>();
        private List<string> recipeNames = new List<string>();

        public EnterDetails()
        {
            InitializeComponent();
            // Initialize the window by clearing input fields and focusing on RecipeNameTextBox
            RecipeNameTextBox.Text = string.Empty;
            RecipeNameTextBox.Focus();
        }

        // Validate all textboxes
        private bool ValidateTextBoxes(IEnumerable<TextBox> textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Please enter data in Textbox.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }

        // Validate all comboboxes
        private bool ValidateComboBoxes(IEnumerable<ComboBox> comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                if (comboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select an item in Combobox.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }
        // Validate calories
        private bool ValidateCalories(string calories)
        {
            if (int.TryParse(calories, out int calorieValue))
            {
                if (calorieValue > 300)
                {
                    var result = MessageBox.Show("Calories exceed the limit of 300. Do you want to continue with this amount?", "Calorie Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    return result == MessageBoxResult.Yes;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Please enter a valid calorie amount.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        // Button click event for entering recipe name
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Validate the recipe name textbox
            if (!ValidateTextBoxes(new[] { RecipeNameTextBox }))
                return;

            // Show the ingredient count panel to proceed to the next step
            IngredientCountPanel.Visibility = Visibility.Visible;
        }

        // Button click event for entering ingredient count
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Validate the ingredient count textbox
            if (!ValidateTextBoxes(new[] { IngredientCountTextBox }))
                return;

            // Parse the ingredient count
            int count;
            if (!int.TryParse(IngredientCountTextBox.Text, out count) || count <= 0)
            {
                MessageBox.Show("Please enter a valid number of ingredients.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // add ingredient input fields based on the count
            for (int i = 0; i < count; i++)
            {
                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
                stackPanel.Children.Add(new TextBlock { Text = "Quantity:", VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White) });
                stackPanel.Children.Add(new TextBox { Width = 50, Margin = new Thickness(10, 0, 0, 0) });
                stackPanel.Children.Add(new TextBlock { Text = "Ingredient:", VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(20, 0, 0, 0) });
                stackPanel.Children.Add(new TextBox { Width = 150, Margin = new Thickness(10, 0, 0, 0) });
                stackPanel.Children.Add(new TextBlock { Text = "Unit:", VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(20, 0, 0, 0) });
                stackPanel.Children.Add(new ComboBox { Width = 100, Margin = new Thickness(10, 0, 0, 0), ItemsSource = new List<string> { "Cup", "Liter", "Milliliter", "Teaspoon", "Tablespoon" } });
                stackPanel.Children.Add(new TextBlock { Text = "Calories:", VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(20, 0, 0, 0) });
                stackPanel.Children.Add(new TextBox { Width = 50, Margin = new Thickness(10, 0, 0, 0) });
                stackPanel.Children.Add(new TextBlock { Text = "Food Group:", VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White), Margin = new Thickness(20, 0, 0, 0) });
                stackPanel.Children.Add(new ComboBox { Width = 150, Margin = new Thickness(10, 0, 0, 0), ItemsSource = new List<string> { "Starchy foods", "Vegetables and Fruits", "Dry beans, peas, lentils and soya", "Chicken, fish, meat and eggs", "Milk and dairy products", "Fats and oil", "Water" } });
                IngredientInputsPanel.Children.Add(stackPanel);
            }

            // Show the ingredients panel to proceed to the next step
            IngredientsPanel.Visibility = Visibility.Visible;
        }

        // Button click event for adding ingredients
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Collect all textboxes and comboboxes within ingredient input panels
            var textBoxes = IngredientInputsPanel.Children.OfType<StackPanel>().SelectMany(panel => panel.Children.OfType<TextBox>());
            var comboBoxes = IngredientInputsPanel.Children.OfType<StackPanel>().SelectMany(panel => panel.Children.OfType<ComboBox>());

            // Validate all textboxes and comboboxes
            if (!ValidateTextBoxes(textBoxes) || !ValidateComboBoxes(comboBoxes))
                return;

            // Iterate through ingredient input panels to retrieve data and populate ingredients list
            foreach (var child in IngredientInputsPanel.Children)
            {
                if (child is StackPanel panel)
                {
                    var quantity = (panel.Children[1] as TextBox)?.Text;
                    var name = (panel.Children[3] as TextBox)?.Text;
                    var unit = (panel.Children[5] as ComboBox)?.SelectedItem?.ToString();
                    var calories = (panel.Children[7] as TextBox)?.Text;
                    var foodGroup = (panel.Children[9] as ComboBox)?.SelectedItem?.ToString();

                    if (!ValidateCalories(calories)) // Validate calories input
                    {
                        return;
                    }

                    ingredients.Add(new Ingredient
                    {
                        Quantity = quantity,
                        Name = name,
                        Unit = unit,
                        Calories = calories,
                        FoodGroup = foodGroup
                    });
                }
            }

            // Clear and refresh the data grid with ingredients
            IngredientsDataGrid.ItemsSource = null;
            IngredientsDataGrid.ItemsSource = ingredients;
            IngredientsDataGrid.Visibility = Visibility.Visible;

            // Show the step count panel to proceed to the next step
            StepCountPanel.Visibility = Visibility.Visible;
        }

        // Button click event for entering step count
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Validate the step count textbox
            if (!int.TryParse(StepCountTextBox.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Please enter a valid number of steps.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Add step input fields based on the count
            for (int i = 0; i < count; i++)
            {
                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
                stackPanel.Children.Add(new TextBlock { Text = "Step Description:", VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush(Colors.White) });
                stackPanel.Children.Add(new TextBox { Width = 300, Margin = new Thickness(10, 0, 0, 0), Name = $"StepTextBox_{i}" });
                StepInputsPanel.Children.Add(stackPanel);
            }

            // Show the steps panel to proceed to the next step
            StepsPanel.Visibility = Visibility.Visible;
        }

        // Button click event for adding steps
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Clear existing steps and validate each step description input
            steps.Clear();
            bool isValid = true;

            foreach (var child in StepInputsPanel.Children)
            {
                if (child is StackPanel panel)
                {
                    var stepTextBox = panel.Children[1] as TextBox;

                    if (string.IsNullOrWhiteSpace(stepTextBox?.Text))
                    {
                        isValid = false;
                        break;
                    }

                    steps.Add(new Step
                    {
                        Description = stepTextBox.Text
                    });
                }
            }

            // Show error message if any step description is empty
            if (!isValid)
            {
                MessageBox.Show("Please fill out all step descriptions.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Clear and refresh the data grid with steps
            StepsDataGrid.ItemsSource = null;
            StepsDataGrid.ItemsSource = steps;
            StepsDataGrid.Visibility = Visibility.Visible;
        }

        // Button click event for saving the recipe
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Validate recipe name, ingredients, and steps
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ingredients.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (steps.Count == 0)
            {
                MessageBox.Show("Please add at least one step.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new RecipeInfo object and populate it with the details
            var newRecipe = new RecipeInfo
            {
                Name = RecipeNameTextBox.Text,
                DateAdded = DateTime.Now,
                Ingredients = new List<Ingredient>(ingredients),
                Steps = new List<Step>(steps)
            };

            // Add the new recipe to the RecipeManager
            RecipeManager.Recipes.Add(newRecipe);

            // Clear all data except the recipe names
            ingredients.Clear();
            steps.Clear();
            IngredientsDataGrid.ItemsSource = null;
            StepsDataGrid.ItemsSource = null;
            RecipeNameTextBox.Text = string.Empty;
            IngredientCountTextBox.Text = string.Empty;
            IngredientInputsPanel.Children.Clear();
            StepCountTextBox.Text = string.Empty;
            StepInputsPanel.Children.Clear();

            // Hide all input panels and grids
            IngredientCountPanel.Visibility = Visibility.Collapsed;
            IngredientsPanel.Visibility = Visibility.Collapsed;
            StepCountPanel.Visibility = Visibility.Collapsed;
            StepsPanel.Visibility = Visibility.Collapsed;
            IngredientsDataGrid.Visibility = Visibility.Collapsed;
            StepsDataGrid.Visibility = Visibility.Collapsed;

            // Show success message
            MessageBox.Show("Recipe saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Button click event for clearing all data
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            // Confirm with the user before clearing all data
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all data?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Clear all data fields and hide input panels and grids
                ingredients.Clear();
                steps.Clear();
                IngredientsDataGrid.ItemsSource = null;
                StepsDataGrid.ItemsSource = null;
                RecipeNameTextBox.Text = string.Empty;
                IngredientCountTextBox.Text = string.Empty;
                IngredientInputsPanel.Children.Clear();
                StepCountTextBox.Text = string.Empty;
                StepInputsPanel.Children.Clear();

                IngredientCountPanel.Visibility = Visibility.Collapsed;
                IngredientsPanel.Visibility = Visibility.Collapsed;
                StepCountPanel.Visibility = Visibility.Collapsed;
                StepsPanel.Visibility = Visibility.Collapsed;
                IngredientsDataGrid.Visibility = Visibility.Collapsed;
                StepsDataGrid.Visibility = Visibility.Collapsed;
            }
        }

        // Button click event for displaying the recipe list
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // Pass the recipe names to the Display window
            Display displayWindow = new Display(recipeNames);
            displayWindow.Show();
            this.Close();
        }

        // Mouse up event for displaying instructions
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Show instructions on how to use the window
            MessageBox.Show("Instructions on how to use this window:\n" +
                "1. Enter the recipe name and click 'OK'.\n" +
                "2. Enter the number of ingredients and click 'OK'.\n" +
                "3. Enter each ingredient's details and click 'Add Ingredients'.\n" +
                "4. Enter the number of steps and click 'OK'.\n" +
                "5. Enter each step description and click 'Add Steps'.\n" +
                "6. Review the entered data in the grid.\n" +
                "7. Click 'Save Recipe' to save the recipe.\n" +
                "8. Click 'Cancel' to clear all entered data.\n" +
                "9. Click 'Display Recipe List' to view all saved recipes."
                , "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
