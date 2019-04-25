using Data.Entity;
using Data.Interface;

namespace Data.Repository
{
    public class RecipeDirectionRepository : Repository<RecipeDirection>, IRecipeDirectionRepository
    {
        private RecipesDbContext _dbContext;
        public RecipeDirectionRepository(RecipesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
