using Data.Entity;
using Data.Interface;

namespace Data.Repository
{
    public class RecipeIngredientAmountRepository : Repository<RecipeIngredientAmount>, IRecipeIngredientAmountRepository
    {
        private RecipesDbContext _dbContext;
        public RecipeIngredientAmountRepository(RecipesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
