using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeClassification { get; set; }
        public float? RecipeCost { get; set; }
        public float? PortionCost { get; set; }
        public int? RecipeStandardYield { get; set; }
        public User User { get; set; } //added
        public int UserId { get; set; } //added
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
