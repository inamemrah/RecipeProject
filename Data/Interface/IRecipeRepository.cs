using Data.ApiModel;
using Data.Entity;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        GetRecipeModel GetRecipes();
    }
}
