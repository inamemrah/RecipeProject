﻿using Data.ApiModel;
using Data.Entity;
using Data.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("service/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private IRecipeRepository _recipeRepository;
        private ICategoryRepository _categoryRepository;
        private IRecipeCategoryRepository _recipeCategoryRepository;
        private IRecipeDirectionRepository _recipeDirectionRepository;
        private IRecipeIngredientRepository _recipeIngredientRepository;
        private IRecipeIngredientAmountRepository _recipeIngredientAmountRepository;

        public RecipeController(IRecipeRepository recipeRepository,
                                ICategoryRepository categoryRepository,
                                IRecipeCategoryRepository recipeCategoryRepository,
                                IRecipeDirectionRepository recipeDirectionRepository,
                                IRecipeIngredientRepository recipeIngredientRepository,
                                IRecipeIngredientAmountRepository recipeIngredientAmountRepository)
        {
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
            _recipeCategoryRepository = recipeCategoryRepository;
            _recipeDirectionRepository = recipeDirectionRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
            _recipeIngredientAmountRepository = recipeIngredientAmountRepository;
        }

        [HttpPost("all")]
        public ActionResult GetRecipe()
        {
            try
            {
                var result = _recipeRepository.GetRecipes();
                if (result == null)
                    return NotFound("No recipes found");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("filter/categories")]
        public ActionResult GetAllCategory()
        {
            try
            {
                var result = _categoryRepository.GetCategories();
                if (result == null)
                    return NotFound("No categories found ");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("add")]
        public ActionResult AddRecipe([FromBody] AddRecipeModel model)
        {
            if(model == null)
            {
                return BadRequest("Wrong Json Object");
            }
            try
            {
                int recipeId = AddRecipes(model);
                AddRecipeCategory(model, recipeId);
                AddRecipeIngredients(model, recipeId);
                AddRecipeDirection(model, recipeId);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        private int AddRecipes(AddRecipeModel model)
        {
            var recipe = new Recipe()
            {
                Title = model.Title,
            };
            _recipeRepository.Insert(recipe);

            return recipe.Id;
        }

        private void AddRecipeCategory(AddRecipeModel model, int recipeId)
        {
            for (int i = 0; i < model.Categories.Count; i++)
            {
                var recipeCategory = new RecipeCategory()
                {
                    RecipeId = recipeId,
                    CategoryId = model.Categories[i]
                };
                _recipeCategoryRepository.Insert(recipeCategory);
            }
        }

        private void AddRecipeIngredients(AddRecipeModel model, int recipeId)
        {
            for (int i = 0; i < model.Ingredients.Count; i++)
            {
                var recipeIngredient = new RecipeIngredient()
                {
                    RecipeId = recipeId,
                    IngredientId = model.Ingredients[i].Name
                };
                _recipeIngredientRepository.Insert(recipeIngredient);

                var recipeIngredientAmount = new RecipeIngredientAmount()
                {
                    RecipeIngredientId = recipeIngredient.Id,
                    Quantity = model.Ingredients[i].Amount.Quantity,
                    Unit = model.Ingredients[i].Amount.Unit
                };
                _recipeIngredientAmountRepository.Insert(recipeIngredientAmount);
            }
        }

        private void AddRecipeDirection(AddRecipeModel model, int recipeId)
        {
            for (int i = 0; i < model.Directions.Count; i++)
            {
                var recipeDirection = new RecipeDirection()
                {
                    RecipeId = recipeId,
                    Step = model.Directions[i].Step
                };
                _recipeDirectionRepository.Insert(recipeDirection);
            }
        }

    }
}
