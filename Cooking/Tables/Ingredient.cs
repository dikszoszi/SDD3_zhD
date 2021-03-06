#nullable disable

namespace Cooking.Tables
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int Amount { get; set; }
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public override string ToString()
        {
            return $"#{this.Id} {this.IngredientName} ({this.Amount})";
        }
    }
}
