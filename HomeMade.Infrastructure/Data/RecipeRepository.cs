using HomeMade.Core.Models;
using HomeMade.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeMade.Infrastructure.Data
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext _dbContext;

        public RecipeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Recipe Add(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);

            _dbContext.SaveChanges();

            return recipe;
        }

        public Recipe Get(int id)
        {
            return _dbContext.Recipes
                .Include(r => r.User)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri=>ri.Ingredient)
                .SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _dbContext.Recipes
                .Include(r => r.User)
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri=>ri.Ingredient)
                .ToList();
        }

        public void Remove(Recipe recipe)
        {
            _dbContext.Recipes.Remove(recipe);

            _dbContext.SaveChanges();
        }

        public Recipe Update(Recipe updatedRecipe)
        {
            var currentRecipe = _dbContext.Recipes.Find(updatedRecipe.Id);

            if (currentRecipe == null) return null;

            _dbContext.Entry(currentRecipe).CurrentValues.SetValues(updatedRecipe);

            _dbContext.Recipes.Update(currentRecipe);

            _dbContext.SaveChanges();

            return updatedRecipe;
        }
    }
}
