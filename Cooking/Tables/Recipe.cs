using System;
using System.Collections.Generic;

#nullable disable

namespace Cooking.Tables
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public string RecipeName { get; set; }
        public int Price { get; set; }
        public bool IsFavourite { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; private set; }

        public override string ToString()
        {
            return $"#{this.Id} {this.RecipeName} [{this.Price}] " + (this.IsFavourite ? "Fav." : "NOT fav.");
        }
    }
}
