using HomeMade.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMade.ApiModels
{
    public static class RecipeMappingExtensions
    {
        public static RecipeModel ToApiModel(this Recipe recipe)
        {
            return new RecipeModel
            {
                Id = recipe.Id,
                RecipeName = recipe.RecipeName,
                RecipeClassification = recipe.RecipeClassification,
                RecipeIngredients = (IEnumerable<RecipeIngredient>)(recipe.RecipeIngredients?.Select(ri => ri.Ingredient).ToApiModel().ToList())
                //RecipeIngredients = recipe.RecipeIngredients?.ToApiModels().ToList()
            };
        }

        public static Recipe ToDomainModel(this RecipeModel recipeModel)
        {
            return new Recipe
            {
                Id = recipeModel.Id,
                RecipeClassification = recipeModel.RecipeClassification,
                RecipeName = recipeModel.RecipeName
                //RecipeIngredients = (IEnumerable<RecipeIngredient>)(recipeModel.RecipeIngredients?.Select(ri => ri.Ingredient).ToDomainModel().ToList())
            };
        }

        public static IEnumerable<RecipeModel> ToApiModels(this IEnumerable<Recipe> recipes)
        {
            return recipes.Select(r => r.ToApiModel());
        }

        public static IEnumerable<Recipe> ToDomainModels(this IEnumerable<RecipeModel> recipeModels)
        {
            return recipeModels.Select(r => r.ToDomainModel());
        }
    }
}
