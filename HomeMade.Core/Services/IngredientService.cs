using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Core.Services
{
    public class IngredientService : IIngredientService
    {
        private IIngredientRepository _ingredientRepo;

        public IngredientService(IIngredientRepository ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }

        public Ingredient Add(Ingredient ingredient)
        {
            return _ingredientRepo.Add(ingredient);
        }

        public Ingredient Get(int id)
        {
            return _ingredientRepo.Get(id);
        }

        public Ingredient Update(Ingredient updatedIngredient)
        {
            var ingredient = _ingredientRepo.Update(updatedIngredient);
            return ingredient;
        }

        public void Remove(Ingredient ingredient)
        {
            _ingredientRepo.Remove(ingredient);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredientRepo.GetAll();
        }
    }
}
