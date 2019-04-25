using Data.Entity;
using Data.Interface;

namespace Data.Repository
{
    public class RecipeIngredientRepository : Repository<RecipeIngredient>, IRecipeIngredientRepository
    {
        private RecipesDbContext _dbContext;
        public RecipeIngredientRepository(RecipesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
