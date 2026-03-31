using Microsoft.Extensions.Logging;
using RecipeApp.Services;
using RecipeApp.ViewModels;
using RecipeApp.Views;

namespace RecipeApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Services
            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<MealDbService>();

            // ViewModels
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<RecipeListViewModel>();
            builder.Services.AddTransient<RecipeDetailViewModel>();
            builder.Services.AddTransient<AddRecipeViewModel>();
            builder.Services.AddTransient<EditRecipeViewModel>();
            builder.Services.AddTransient<FavoritesViewModel>();
            builder.Services.AddTransient<SearchViewModel>();
            builder.Services.AddTransient<BrowseApiViewModel>();

            // Pages
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<RecipeListPage>();
            builder.Services.AddTransient<RecipeDetailPage>();
            builder.Services.AddTransient<AddRecipePage>();
            builder.Services.AddTransient<EditRecipePage>();
            builder.Services.AddTransient<FavoritesPage>();
            builder.Services.AddTransient<SearchPage>();
            builder.Services.AddTransient<BrowseApiPage>();

            return builder.Build();
        }
    }
}