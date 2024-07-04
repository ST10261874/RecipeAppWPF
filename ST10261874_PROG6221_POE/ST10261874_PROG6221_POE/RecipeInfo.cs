using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10261874_PROG6221_POE
{
    /// <summary>
    /// Represents information about a recipe, including its name, date added, ingredients, and steps.
    /// </summary>
    public class RecipeInfo
    {
        public string Name { get; set; } // Name of the recipe
        public DateTime DateAdded { get; set; } // Date when the recipe was added
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>(); // List of ingredients in the recipe
        public List<Step> Steps { get; set; } = new List<Step>(); // List of steps to prepare the recipe
        
        public RecipeInfo Clone()
        {
            return new RecipeInfo
            {
                Name = this.Name, // Copy the name
                DateAdded = this.DateAdded, // Copy the date added

                // Create new lists of ingredients and steps by cloning each item
                Ingredients = this.Ingredients.Select(i => new Ingredient
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Calories = i.Calories,
                    FoodGroup = i.FoodGroup
                }).ToList(),

                Steps = this.Steps.Select(s => new Step
                {
                    Description = s.Description
                }).ToList()
            };
        }
    }
}
