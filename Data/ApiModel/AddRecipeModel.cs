using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ApiModel
{
    public class AddRecipeModel
    {
        public string Title { get; set; }
        public List<int> Categories { get; set; }
        public List<AddRecipeIngredientModel> Ingredients { get; set; }
        public List<AddRecipeDirectionModel> Directions { get; set; }
    }

    public class AddRecipeIngredientModel
    {
        public AddRecipeAmountModel Amount { get; set; }
        public int Name { get; set; }
    }

    public class AddRecipeAmountModel
    {
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }

    public class AddRecipeDirectionModel
    {
        public string Step { get; set; }
    }
}
