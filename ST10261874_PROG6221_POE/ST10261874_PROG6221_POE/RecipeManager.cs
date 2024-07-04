using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10261874_PROG6221_POE
{
    public class RecipeManager
    {
        // Static list of recipes
        public static List<RecipeInfo> Recipes { get; } = new List<RecipeInfo>();

        // Dictionary to store original recipes by name
        private static Dictionary<string, RecipeInfo> originalRecipes = new Dictionary<string, RecipeInfo>();

        // Save the original state of all recipes
        public static void SaveOriginalState()
        {
            originalRecipes.Clear();  // Clear previous entries

            // Iterate through current recipes and clone them to store as original
            foreach (var recipe in Recipes)
            {
                originalRecipes[recipe.Name] = recipe.Clone();  // Clone the recipe and store in dictionary
            }
        }

        // Clear all recipes from the manager
        public static void ClearAllData()
        {
            Recipes.Clear();  // Clear the list of recipes
        }

        // Retrieve a cloned copy of the original recipe by name
        public static RecipeInfo GetOriginalRecipe(string name)
        {
            if (originalRecipes.ContainsKey(name))
            {
                return originalRecipes[name].Clone();  // Return a clone to preserve original state
            }
            return null;  // Return null if the original recipe is not found
        }
    }
}
