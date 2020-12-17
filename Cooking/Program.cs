namespace Cooking
{
    using System;
    using System.Linq;
    using Tables;

    /*
     * TOOLS - NuGet Package Manager - Package Manager Console
     * Scaffold-DbContext "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Resources\Recipes.mdf;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Tables
     */
    class Program
    {
        static void Main(string[] args)
        {
            RecipesDbContext ctx = new RecipesDbContext();
            Fridge fridge = Fridge.GetFridgeFromXml(@"Resources\fridge.xml");
            //fridge.Products.PrintToConsole("Stuff available in fridge");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Number of Recipes in DB: " + ctx.Set<Recipe>().Count());
            Console.ResetColor();

            ctx.Set<Recipe>().Where(reci => reci.IsFavourite).PrintToConsole("Favourite Recipes");

            var joinedTables = ctx.Set<Recipe>().Join(ctx.Set<Ingredient>(), reci => reci.Id, ingred => ingred.RecipeId, (recipe, ingredient) => new { recipe, ingredient });
            //joinedTables.PrintToConsole(nameof(joinedTables));

            string request = "Olaj";
            joinedTables.Where(jointype => jointype.ingredient.IngredientName == request)
                .OrderByDescending(jointype => jointype.recipe.Price)
                .PrintToConsole("Recipes containing " + request);

            joinedTables.GroupBy(jointype => jointype.ingredient.IngredientName)
                .Select(grp => new { IngredientName = grp.Key, Amount = grp.Sum(jointype => jointype.ingredient.Amount) })
                .PrintToConsole("Ingredients and Total Amounts");
            
            Console.Write("\n"); // begin reflection part
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Helper.PropToString(fridge));
            fridge.Products.ForEach(prod =>
            {
                Console.WriteLine(Helper.PropToString(prod));
            });
            Console.ResetColor();
            Console.Write("\n"); // end of reflection part

            Console.WriteLine("\n*** Type the name of the recipe you wish to prepare then press Enter.");
            Recipe selectedRecipe = ctx.Set<Recipe>().FirstOrDefault(reci => reci.RecipeName.Contains(Console.ReadLine()));
            if (selectedRecipe is not null)
            {
                //selectedRecipe.Ingredients.PrintToConsole("Necessary for " + selectedRecipe.ToString());
                //fridge.Products.PrintToConsole("Available");
                bool isSufficient = selectedRecipe.Ingredients
                    .GroupJoin(fridge.Products, ingr => ingr.IngredientName, prod => prod.ProductName, (ingredient, products) => new { ingredient, products })
                    .SelectMany(ingredientProducts => ingredientProducts.products.DefaultIfEmpty(new Product
                    {
                        ProductName = "MISSING",
                        Quantity = 0
                    }), (ingredientProducts, product) => new { ingredientProducts.ingredient.Amount, product.Quantity })
                    .All(jointype => jointype.Quantity >= jointype.Amount);

                Console.WriteLine($"Can we make " + selectedRecipe.RecipeName + " now? " + (isSufficient ? "Yes" : "No"));
            }
            else
            {
                Console.WriteLine("The recipe could not be found.");
            }

            var isEnough = joinedTables.ToList()
                .GroupJoin(fridge.Products, ingr => ingr.ingredient.IngredientName, prod => prod.ProductName, (recipeIngredients, products) => new { recipeIngredients.ingredient, products })
                .SelectMany(ingredientProducts => ingredientProducts.products.DefaultIfEmpty(new Product
                {
                    ProductName = "MISSING",
                    Quantity = 0
                }), (ingredientProducts, product) => new { ingredientProducts.ingredient.Amount, product.Quantity })
                .All(jointype => jointype.Quantity >= jointype.Amount);

            Console.WriteLine($"Can we make EVERYTHING now? " + (isEnough ? "Yes" : "No"));
        }
    }
}
