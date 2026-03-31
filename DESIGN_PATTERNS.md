using RecipeApp.Views;

namespace RecipeApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation
            Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
            Routing.RegisterRoute(nameof(RecipeListPage), typeof(RecipeListPage));
            Routing.RegisterRoute(nameof(AddRecipePage), typeof(AddRecipePage));
            Routing.RegisterRoute(nameof(EditRecipePage), typeof(EditRecipePage));
            Routing.RegisterRoute(nameof(BrowseApiPage), typeof(BrowseApiPage));
        }
    }
}