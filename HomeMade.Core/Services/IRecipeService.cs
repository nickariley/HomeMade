using HomeMade.Core.Models;
using System.Collections.Generic;

namespace HomeMade.Core.Services
{
    public interface IRecipeService
    {
        Recipe Add(Recipe recipe);
        Recipe Get(int id);
        IEnumerable<Recipe> GetAll();
        void Remove(Recipe recipe);
        Recipe Update(Recipe updatedRecipe);
    }
}