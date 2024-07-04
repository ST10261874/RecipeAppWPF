using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ST10261874_PROG6221_POE
{
    public partial class Scale : Window
    {
        // Fields to hold original and scaled recipe information
        private RecipeInfo originalRecipe;
        private RecipeInfo scaledRecipe;

        // Constructor
        public Scale()
        {
            InitializeComponent();
            PopulateRecipeComboBox();  // Populate recipe names in the ComboBox
            RecipeManager.SaveOriginalState();  // Save original state of recipes
        }

        // Populates the recipe names into the ComboBox
        private void PopulateRecipeComboBox()
        {
            RecipeComboBox.ItemsSource = RecipeManager.Recipes.Select(recipe => recipe.Name).ToList();
        }

        // Event handler for the Scale Recipe button click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem != null)
            {
                string selectedRecipeName = RecipeComboBox.SelectedItem.ToString();
                RecipeInfo selectedRecipe = RecipeManager.Recipes.Find(recipe => recipe.Name == selectedRecipeName);

                if (selectedRecipe != null)
                {
                    double scalingFactor = 1.0;
                    if (ScalingFactorComboBox.SelectedItem != null)
                    {
                        scalingFactor = double.Parse((ScalingFactorComboBox.SelectedItem as ComboBoxItem).Content.ToString());
                    }

                    originalRecipe = selectedRecipe;
                    DisplayRecipeDetails(OriginalRecipeRichTextBox, originalRecipe);  // Display details of original recipe

                    scaledRecipe = ScaleRecipe(selectedRecipe, scalingFactor);  // Scale the recipe
                    DisplayRecipeDetails(ScaledRecipeRichTextBox, scaledRecipe);  // Display details of scaled recipe

                    // Show the comparison grid and OK button, hide other controls
                    ComparisonGrid.Visibility = Visibility.Visible;
                    OkButton.Visibility = Visibility.Visible;
                    RecipeComboBox.Visibility = Visibility.Collapsed;
                    ScalingFactorComboBox.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Selected recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Display recipe details in a RichTextBox
        private void DisplayRecipeDetails(RichTextBox richTextBox, RecipeInfo recipe)
        {
            richTextBox.Document.Blocks.Clear();  // Clear existing content

            // Display recipe name and date added
            richTextBox.Document.Blocks.Add(new Paragraph(new Run($"Name: {recipe.Name}")));
            richTextBox.Document.Blocks.Add(new Paragraph(new Run($"Date Added: {recipe.DateAdded}")));

            // Display ingredients
            richTextBox.Document.Blocks.Add(new Paragraph(new Run("Ingredients:")));
            foreach (var ingredient in recipe.Ingredients)
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run($"{ingredient.Name} - {ingredient.Quantity} - {ingredient.Calories} calories - {ingredient.FoodGroup}")));
            }

            // Display steps
            richTextBox.Document.Blocks.Add(new Paragraph(new Run("Steps:")));
            foreach (var step in recipe.Steps)
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run($"{step.Description}")));
            }
        }

        // Scale the recipe based on the selected scaling factor
        private RecipeInfo ScaleRecipe(RecipeInfo originalRecipe, double scalingFactor)
        {
            RecipeInfo scaledRecipe = new RecipeInfo
            {
                Name = $"{originalRecipe.Name} (Scaled x{scalingFactor})",  // Adjust recipe name to indicate scaling
                DateAdded = originalRecipe.DateAdded  // Retain original date added
            };

            // Scale each ingredient in the recipe
            foreach (var ingredient in originalRecipe.Ingredients)
            {
                double scaledQuantity = double.Parse(ingredient.Quantity) * scalingFactor;
                double scaledCalories = double.Parse(ingredient.Calories) * scalingFactor;

                Ingredient scaledIngredient = new Ingredient
                {
                    Name = ingredient.Name,
                    Quantity = scaledQuantity.ToString(),
                    Calories = scaledCalories.ToString(),
                    FoodGroup = ingredient.FoodGroup
                };

                scaledRecipe.Ingredients.Add(scaledIngredient);
            }

            // Copy steps from original recipe to scaled recipe
            foreach (var step in originalRecipe.Steps)
            {
                scaledRecipe.Steps.Add(step);
            }

            return scaledRecipe;
        }

        // Event handler for the OK button click
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide comparison grid and OK button, show reset and back buttons
            ComparisonGrid.Visibility = Visibility.Collapsed;
            OkButton.Visibility = Visibility.Collapsed;
            RecipeComboBox.Visibility = Visibility.Visible;
            ScalingFactorComboBox.Visibility = Visibility.Visible;
            ResetButton.Visibility = Visibility.Visible;
        }

        // Event handler for the Reset Recipe button click
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (originalRecipe != null)
            {
                RestoreOriginalRecipe(originalRecipe);  // Restore original recipe details
                DisplayRecipeDetails(OriginalRecipeRichTextBox, originalRecipe);  // Display restored original recipe
                DisplayRecipeDetails(ScaledRecipeRichTextBox, originalRecipe);  // Display restored original recipe in scaled view

                MessageBox.Show("Recipe reset to original.", "Reset Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Original recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Restore the original state of the recipe
        private void RestoreOriginalRecipe(RecipeInfo recipe)
        {
            RecipeInfo originalRecipe = RecipeManager.GetOriginalRecipe(recipe.Name);
            if (originalRecipe != null)
            {
                recipe.Name = originalRecipe.Name;
                recipe.DateAdded = originalRecipe.DateAdded;
                recipe.Ingredients = new List<Ingredient>(originalRecipe.Ingredients.Select(i => new Ingredient
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Calories = i.Calories,
                    FoodGroup = i.FoodGroup
                }));
                recipe.Steps = new List<Step>(originalRecipe.Steps.Select(s => new Step
                {
                    Description = s.Description
                }));
            }
            else
            {
                MessageBox.Show("Original recipe backup not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the Back to Recipe Menu button click
        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();  // Create new instance of Recipe window
            recipe.Show();  // Show Recipe window
            this.Close();  // Close current Scale window
        }

        // Event handler for the Image MouseUp event
        private void Image_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Display instructions for using this window in a MessageBox
            MessageBox.Show("Instructions on how to use this window:\n" +
                "1. Select a recipe from the dropdown list.\n" +
                "2. Choose a scaling factor (0.5, 2, 3) from the dropdown.\n" +
                "3. Click 'Scale Recipe' to generate a scaled version.\n" +
                "4. View the original and scaled recipes side by side.\n" +
                "5. Click 'OK' to return to the scaling options.\n" +
                "6. Click 'Reset Recipe' to revert to the original recipe.\n" +
                "7. Click 'Back to Recipe Menu' to return to the main recipe window."
                , "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

