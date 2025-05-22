using Cookbook.Domain;
using Cookbook.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Api.Controllers;

[ApiController]
[Route("api/recipies")]
public class RecipeController(CookbookContext dbContext) : ControllerBase
{
    [HttpGet("{recipeId:int}")]
    [ProducesResponseType(typeof(Recipe), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(int recipeId)
    {
        var recipeQuery = dbContext.Recipes
            .Include(recipe => recipe.Ingredients)
            .ThenInclude(ingredient => ingredient.Unit)
            .Include(recipe => recipe.Steps)
            .AsSplitQuery();
            
        var recipe = await recipeQuery // Break here and run recipeQuery.ToQueryString() in the debugger console.
            .FirstOrDefaultAsync(recipe => recipe.Id == recipeId, HttpContext.RequestAborted);
        
        if (recipe == null)
            return Problem(statusCode: StatusCodes.Status404NotFound);
        
        // Please don't return the entity directly, use a DTO instead
        return Ok(recipe);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(Recipe[]), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] string[] ingredientNames)
    {
        var recipeQuery = dbContext.Recipes
            .Where(recipe => recipe.Ingredients
                .Any(ingredient => 
                    ingredientNames.Any(name => ingredient.Name == name)))
            .Include(recipe => recipe.Ingredients)
            .ThenInclude(ingredient => ingredient.Unit)
            .Include(recipe => recipe.Steps)
            .AsSplitQuery();
            
        var recipes = await recipeQuery // Break here and run recipeQuery.ToQueryString() in the debugger console.
            .ToListAsync(HttpContext.RequestAborted);
    
        return Ok(recipes);
    }
}