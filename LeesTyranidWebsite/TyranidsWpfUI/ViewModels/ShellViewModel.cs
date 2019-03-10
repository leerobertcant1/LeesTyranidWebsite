using BusinessLogic.Abstractions;
using Caliburn.Micro;
using TyranidsWpfUI.Views;

namespace TyranidsWpfUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        public ShellViewModel(IApiService apiService)
        {
            var homepageView = new HomePageView(apiService);

            homepageView.ShowDialog();
        }
    }
}

