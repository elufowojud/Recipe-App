using SQLite;
using RecipeApp.Models;

namespace RecipeApp.Services
{
    public class DatabaseContext
    {
        private SQLiteAsyncConnection _database;

        private async Task Init()
        {
            if (_database != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "recipes.db");
            _database = new SQLiteAsyncConnection(databasePath);
            await _database.CreateTableAsync<Recipe>();

            // Seed data if database is empty
            var count = await _database.Table<Recipe>().CountAsync();
            if (count == 0)
            {
                await SeedDataAsync();
            }
        }

        private async Task SeedDataAsync()
        {
            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Name = "Fluffy Pancakes",
                    Category = "Breakfast",
                    PrepTime = 10,
                    Ingredients = new List<string>
                    {
                        "2 cups all-purpose flour",
                        "2 tablespoons sugar",
                        "2 teaspoons baking powder",
                        "1 teaspoon salt",
                        "2 eggs",
                        "1.5 cups milk"
                    },
                    Instructions = new List<string>
                    {
                        "Mix dry ingredients in a bowl",
                        "Beat eggs and milk in another bowl",
                        "Combine wet and dry ingredients",
                        "Heat griddle to medium heat",
                        "Pour batter and cook until bubbles form",
                        "Flip and cook until golden brown",
                        "Serve hot with syrup"
                    },
                    IsFavorite = false
                },
                new Recipe
                {
                    Name = "Caesar Salad",
                    Category = "Lunch",
                    PrepTime = 15,
                    Ingredients = new List<string>
                    {
                        "1 head romaine lettuce",
                        "1/2 cup Caesar dressing",
                        "1/2 cup parmesan cheese",
                        "1 cup croutons",
                        "Black pepper to taste"
                    },
                    Instructions = new List<string>
                    {
                        "Wash and chop romaine lettuce",
                        "Place lettuce in large bowl",
                        "Add Caesar dressing and toss",
                        "Add parmesan cheese",
                        "Top with croutons",
                        "Season with black pepper"
                    },
                    IsFavorite = false
                },
                new Recipe
                {
                    Name = "Spaghetti Carbonara",
                    Category = "Dinner",
                    PrepTime = 10,
                    Ingredients = new List<string>
                    {
                        "400g spaghetti",
                        "200g bacon",
                        "4 egg yolks",
                        "1 cup parmesan cheese",
                        "Black pepper",
                        "Salt"
                    },
                    Instructions = new List<string>
                    {
                        "Boil spaghetti until al dente",
                        "Fry bacon until crispy",
                        "Mix egg yolks with parmesan",
                        "Drain pasta, reserve 1 cup water",
                        "Toss hot pasta with bacon",
                        "Remove from heat, add egg mixture",
                        "Add pasta water if needed",
                        "Season with pepper"
                    },
                    IsFavorite = false
                },
                new Recipe
                {
                    Name = "Chocolate Cake",
                    Category = "Dessert",
                    PrepTime = 20,
                    Ingredients = new List<string>
                    {
                        "2 cups flour",
                        "2 cups sugar",
                        "3/4 cup cocoa powder",
                        "2 eggs",
                        "1 cup milk",
                        "1/2 cup vegetable oil"
                    },
                    Instructions = new List<string>
                    {
                        "Preheat oven to 350°F",
                        "Mix dry ingredients",
                        "Add eggs, milk, and oil",
                        "Beat for 2 minutes",
                        "Pour into greased pan",
                        "Bake 30-35 minutes",
                        "Cool before frosting"
                    },
                    IsFavorite = false
                },
                new Recipe
                {
                    Name = "French Toast",
                    Category = "Breakfast",
                    PrepTime = 5,
                    Ingredients = new List<string>
                    {
                        "4 slices bread",
                        "2 eggs",
                        "1/4 cup milk",
                        "1 teaspoon vanilla",
                        "Cinnamon",
                        "Butter for frying"
                    },
                    Instructions = new List<string>
                    {
                        "Beat eggs, milk, vanilla, cinnamon",
                        "Heat butter in pan",
                        "Dip bread in egg mixture",
                        "Fry until golden on both sides",
                        "Serve with syrup"
                    },
                    IsFavorite = false
                }
            };

            foreach (var recipe in recipes)
            {
                await _database.InsertAsync(recipe);
            }
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            await Init();
            return await _database.Table<Recipe>().ToListAsync();
        }

        public async Task<List<Recipe>> GetRecipesByCategoryAsync(string category)
        {
            await Init();
            return await _database.Table<Recipe>()
                .Where(r => r.Category == category)
                .ToListAsync();
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            await Init();
            return await _database.Table<Recipe>()
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> SaveRecipeAsync(Recipe recipe)
        {
            await Init();

            if (recipe.Id != 0)
            {
                return await _database.UpdateAsync(recipe);
            }
            else
            {
                return await _database.InsertAsync(recipe);
            }
        }

        public async Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            await Init();
            return await _database.DeleteAsync(recipe);
        }

        public async Task<List<Recipe>> GetFavoriteRecipesAsync()
        {
            await Init();
            return await _database.Table<Recipe>()
                .Where(r => r.IsFavorite)
                .ToListAsync();
        }

        public async Task<List<Recipe>> SearchRecipesAsync(string searchText)
        {
            await Init();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                return new List<Recipe>();
            }

            // Get all recipes and search case-insensitively
            var allRecipes = await _database.Table<Recipe>().ToListAsync();

            var results = allRecipes
                .Where(r => r.Name.ToLower().Contains(searchText.ToLower()))
                .ToList();

            System.Diagnostics.Debug.WriteLine($"=== SEARCH: Found {results.Count} recipes for '{searchText}' ===");
            foreach (var recipe in results)
            {
                System.Diagnostics.Debug.WriteLine($"  - {recipe.Name}");
            }

            return results;
        }
    }
}