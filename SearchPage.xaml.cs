using CommunityToolkit.Mvvm.ComponentModel;

namespace RecipeApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string title = string.Empty;

        public BaseViewModel()
        {
        }
    }
}