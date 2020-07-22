using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMade.ApiModels
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeClassification { get; set; }
        public float? RecipeCost { get; set; }
        public float? PortionCost { get; set; }
        public int? RecipeStandardYield { get; set; }
        public User User { get; set; } //added
        public int UserId { get; set; } //added
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
        public int IngredientId { get; set; } //added
    }
}
