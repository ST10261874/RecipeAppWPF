using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10261874_PROG6221_POE
{
    public class Ingredient
    {
        public string Quantity { get; set; } // Quantity of the ingredient
        public string Name { get; set; } // Name of the ingredient
        public string Unit { get; set; } // Unit of measurement
        public string Calories { get; set; } // Calories per unit of the ingredient
        public string FoodGroup { get; set; } // Food group the ingredient belongs to
    }
}
