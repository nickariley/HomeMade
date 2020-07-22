using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMade.ApiModels
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int IngredientQuantity { get; set; }
        public string IngredientUnit { get; set; }
        public float IngredientEdibleYieldPercentage { get; set; }
    }
}
