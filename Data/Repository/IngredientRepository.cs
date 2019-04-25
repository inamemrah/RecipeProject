using Data.Entity;
using Data.Interface;

namespace Data.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        private RecipesDbContext _dbContext;
        public IngredientRepository(RecipesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
