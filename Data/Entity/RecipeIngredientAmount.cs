namespace Data.Entity
{
    public class RecipeIngredientAmount
    {
        public int Id { get; set; }
        public int RecipeIngredientId { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
    }
}
