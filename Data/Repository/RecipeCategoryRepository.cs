using Data.Entity;
using Data.Interface;

namespace Data.Repository
{
    public class RecipeCategoryRepository : Repository<RecipeCategory>, IRecipeCategoryRepository
    {
        private RecipesDbContext _dbContext;
        public RecipeCategoryRepository(RecipesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
