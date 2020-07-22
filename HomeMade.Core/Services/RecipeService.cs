using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _recipeRepo;

        public RecipeService(IRecipeRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        public Recipe Add(Recipe recipe)
        {
            _recipeRepo.Add(recipe);
            return recipe;
        }

        public Recipe Get(int id)
        {
            return _recipeRepo.Get(id);
        }

        public Recipe Update(Recipe updatedRecipe)
        {
            var recipe = _recipeRepo.Update(updatedRecipe);
            return recipe;
        }

        public void Remove(Recipe recipe)
        {
            _recipeRepo.Remove(recipe);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _recipeRepo.GetAll();
        }
    }
}
