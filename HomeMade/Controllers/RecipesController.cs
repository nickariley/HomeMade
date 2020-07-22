using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeMade.ApiModels;
using HomeMade.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeMade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }


        // GET: api/<RecipesController>
        [HttpGet()]
        public IActionResult GetRecipes()
        {
            var recipes = _recipeService.GetAll().ToList();
            return Ok(recipes.ToApiModels());
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {
            var recipe = _recipeService.Get(id);
            return Ok(recipe.ToApiModel());
        }

        // POST api/<RecipesController>
        [HttpPost]
        public IActionResult Add([FromBody] RecipeModel recipeModel)
        {
            //ModelState.AddModelError("AddQuestion", "Not Implemented!");
            //return NotFound(ModelState);
            try
            {
                var savedRecipe = _recipeService.Add(recipeModel.ToDomainModel());
                return CreatedAtAction("Get", new { Id = savedRecipe.Id }, savedRecipe.ToApiModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddRecipe", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RecipeModel recipeModel)
        {
            //ModelState.AddModelError("UpdateQuestion", "Not Implemented!");            
            //return BadRequest(ModelState);
            var updatedRecipe = _recipeService.Update(recipeModel.ToDomainModel());
            return Ok(updatedRecipe.ToApiModel());
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            //ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
            //return BadRequest(ModelState);
            //_recipeService.Remove(id);
            //return Ok();
            var recipe = _recipeService.Get(id);

            if (recipe == null) return NotFound();

            _recipeService.Remove(recipe);

            return NoContent();
        }
    }
}
