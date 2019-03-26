using Caliburn.Micro;
using DataManager.Abstractions;
using TyranidsWpfUI.Views;

namespace TyranidsWpfUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        public ShellViewModel(IQueryUnitOfWork queryUnitOfWork, IRepositoryFactory repositoryFactory)
        {
            var homepageView = new HomePageView(queryUnitOfWork, repositoryFactory);

            homepageView.ShowDialog();
        }
    }
}

