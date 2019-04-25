using Data.ApiModel;
using Data.Entity;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        CategoryModel GetCategories();
    }
}
