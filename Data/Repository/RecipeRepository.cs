using Data.ApiModel;
using Data.Entity;
using Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private RecipesDbContext _dbContext;
        public RecipeRepository(RecipesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public GetRecipeModel GetRecipes()
        {
            var result = (from recipe in _dbContext.Recipes
                          join recipeCategory in _dbContext.RecipeCategories on recipe.Id equals recipeCategory.RecipeId
                          join recipeIngredient in _dbContext.RecipeIngredients on recipe.Id equals recipeIngredient.RecipeId
                          select new GetRecipeModel
                          {
                              Total = _dbContext.Recipes.Count(),
                              Result = recipe.Id,
                              Recipes = new GetRecipeContentModel()
                              {
                                  Categories = (from categories in _dbContext.Categories
                                                join recipeCategories in _dbContext.RecipeCategories on categories.Id equals recipeCategories.CategoryId
                                                where recipeCategories.RecipeId == recipe.Id
                                                select categories.Name).ToList(),
                                  Title = recipe.Title,
                                  Ingredients = (from ingredient in _dbContext.Ingredients
                                                 join recipeIngredients in _dbContext.RecipeIngredients on ingredient.Id equals recipeIngredients.IngredientId
                                                 join recipeIngredientsAmount in _dbContext.RecipeIngredientsAmount on recipeIngredients.Id equals recipeIngredientsAmount.RecipeIngredientId
                                                 where recipeIngredients.RecipeId == recipe.Id
                                                 select new GetIngredientModel
                                                 {
                                                     Amount = new GetAmountModel() { Quantity = recipeIngredientsAmount.Quantity, Unit = recipeIngredientsAmount.Unit },
                                                     Name = ingredient.Name
                                                 }).ToList(),
                                  Directions = (from directions in _dbContext.RecipeDirections
                                                where directions.RecipeId == recipe.Id
                                                select new GetDirectionModel
                                                {
                                                    Step = directions.Step
                                                }).FirstOrDefault()
                              }

                          }).FirstOrDefault();

            return result;
        }

    }
}
