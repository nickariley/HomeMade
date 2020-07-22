using HomeMade.Core.Models;
using HomeMade.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeMade.Infrastructure.Data
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext _dbContext;

        public IngredientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Ingredient Add(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);

            _dbContext.SaveChanges();

            return ingredient;
        }

        public Ingredient Get(int id)
        {
            return _dbContext.Ingredients.SingleOrDefault(i => i.Id == id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _dbContext.Ingredients.ToList();
        }

        public void Remove(Ingredient ingredient)
        {
            _dbContext.Ingredients.Remove(ingredient);

            _dbContext.SaveChanges();
        }

        public Ingredient Update(Ingredient updatedIngredient)
        {
            var currentIngredient = _dbContext.Ingredients.Find(updatedIngredient.Id);

            if (currentIngredient == null) return null;

            _dbContext.Entry(currentIngredient).CurrentValues.SetValues(updatedIngredient);

            _dbContext.Ingredients.Update(currentIngredient);

            _dbContext.SaveChanges();

            return currentIngredient;
        }
    }
}
