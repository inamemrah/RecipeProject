using Data.Entity;
using System.Collections.Generic;

namespace Data.ApiModel
{
    public class GetRecipeModel
    {
        public int Result { get; set; }
        public int Total { get; set; }
        public GetRecipeContentModel Recipes { get; set; }

    }

    public class GetRecipeContentModel
    {
        public string Title { get; set; }
        public List<string> Categories { get; set; }
        public List<GetIngredientModel> Ingredients { get; set; }
        public GetDirectionModel Directions { get; set; }
    }

    public class GetIngredientModel
    {
        public GetAmountModel Amount { get; set; }
        public string Name { get; set; }
    }

    public class GetAmountModel
    {
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }

    public class GetDirectionModel
    {
        public string Step { get; set; }
    }

}
