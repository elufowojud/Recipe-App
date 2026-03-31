namespace RecipeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Force light theme to fix text visibility issues
            UserAppTheme = AppTheme.Light;

            MainPage = new AppShell();
        }
    }
}