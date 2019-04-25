using Data.ApiModel;
using Data.Entity;
using Data.Interface;
using System.Linq;

namespace Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private RecipesDbContext _dbContext;
        public CategoryRepository(RecipesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CategoryModel GetCategories()
        {
            var result = (from category in _dbContext.Categories
                         select new CategoryModel
                         {
                             Results = _dbContext.Categories.Count(),
                             Categories = (from categories in _dbContext.Categories
                                           select categories.Name).ToList(),
                             
                         }).FirstOrDefault();
            return result;
           
        }

        
    }

}

