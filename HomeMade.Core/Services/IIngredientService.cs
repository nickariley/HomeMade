using HomeMade.Core.Models;
using System.Collections.Generic;

namespace HomeMade.Core.Services
{
    public interface IIngredientService
    {
        Ingredient Add(Ingredient ingredient);
        Ingredient Get(int id);
        IEnumerable<Ingredient> GetAll();
        void Remove(Ingredient ingredient);
        Ingredient Update(Ingredient updatedIngredient);
    }
}