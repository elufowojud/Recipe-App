using SQLite;
using System.Text.Json;

namespace RecipeApp.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        // Store lists as JSON strings in database
        public string IngredientsJson { get; set; } = "[]";
        public string InstructionsJson { get; set; } = "[]";

        // These are NOT stored in database - computed from JSON
        [Ignore]
        public List<string> Ingredients
        {
            get => string.IsNullOrEmpty(IngredientsJson) || IngredientsJson == "[]"
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(IngredientsJson) ?? new List<string>();
            set => IngredientsJson = JsonSerializer.Serialize(value);
        }

        [Ignore]
        public List<string> Instructions
        {
            get => string.IsNullOrEmpty(InstructionsJson) || InstructionsJson == "[]"
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(InstructionsJson) ?? new List<string>();
            set => InstructionsJson = JsonSerializer.Serialize(value);
        }

        public bool IsFavorite { get; set; }
        public bool IsCustom { get; set; }
    }
}