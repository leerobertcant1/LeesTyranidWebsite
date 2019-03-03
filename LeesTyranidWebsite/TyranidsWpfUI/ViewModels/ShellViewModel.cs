using Caliburn.Micro;
using TyranidsWpfUI.Views;

namespace TyranidsWpfUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        public ShellViewModel()
        {
            var homepageView = new HomePageView();

            homepageView.ShowDialog();
        }
    }
}

