using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int IngredientQuantity { get; set; }
        public string IngredientUnit { get; set; }
        public float IngredientEdibleYieldPercentage { get; set; }
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
