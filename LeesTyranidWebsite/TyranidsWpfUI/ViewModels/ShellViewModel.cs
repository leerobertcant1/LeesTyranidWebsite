using Caliburn.Micro;
using DataManager.Abstractions;
using TyranidsApi.Abstractions;
using TyranidsWpfUI.Views;

namespace TyranidsWpfUI.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        public ShellViewModel(IApiService apiService, IQueryUnitOfWork queryUnitOfWork, IRepositoryFactory repositoryFactory)
        {
            var homepageView = new HomePageView(apiService, queryUnitOfWork, repositoryFactory);

            homepageView.ShowDialog();
        }
    }
}

