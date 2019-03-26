using Api.Controllers;
using DataManager.Abstractions;
using System.Windows;
using TyranidsWpfUI.ViewModels;

namespace TyranidsWpfUI.Views
{
    public partial class HomePageView : Window
    {
        private IQueryUnitOfWork _queryUnitOfWork;
        private IRepositoryFactory _repositoryFactory;

        public HomePageView(IQueryUnitOfWork queryUnitOfWork, IRepositoryFactory repositoryFactory)
        {
            _queryUnitOfWork = queryUnitOfWork;

            _repositoryFactory = repositoryFactory;

            InitializeComponent();
        }
       
        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            var homepage = new HomepageViewModel();

            var data = new ModelsController(_queryUnitOfWork, _repositoryFactory).GetAllModels();

            homepage.Show();

            Close();
        }
    }
}
