using Microsoft.EntityFrameworkCore;

namespace Data.Entity
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext(DbContextOptions<RecipesDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeIngredientAmount> RecipeIngredientsAmount { get; set; }
        public DbSet<RecipeDirection> RecipeDirections { get; set; }
    }
}
