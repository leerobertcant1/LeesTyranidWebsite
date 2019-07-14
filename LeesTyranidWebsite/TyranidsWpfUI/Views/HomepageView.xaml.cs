using DataManager.Abstractions;
using System.Windows;
using TyranidsApi.Abstractions;
using TyranidsApi.Static_Values;
using TyranidsWpfUI.ViewModels;
using DataManager.Models;


namespace TyranidsWpfUI.Views
{
    public partial class HomePageView : Window
    {
        private IApiService _apiService;
        private IJsonService _jsonService;
        private IQueryUnitOfWork _queryUnitOfWork;
        private IRepositoryFactory _repositoryFactory;

        public HomePageView(IApiService apiService, IJsonService jsonService,  IQueryUnitOfWork queryUnitOfWork, IRepositoryFactory repositoryFactory)
        {
            _apiService = apiService;
            _jsonService = jsonService;
            _queryUnitOfWork = queryUnitOfWork;
            _repositoryFactory = repositoryFactory;

            InitializeComponent();
        }
       
        private async void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            var homepage = new HomepageViewModel();
            var result = string.Empty;

            var response = await _apiService.GetData(ApiEndpoints.Models);

            if (!response.IsSuccessStatusCode)
                result = "An error occcured";
            else
            {
                var asyncResult = response.Content.ReadAsStringAsync().Result;

                var items = _jsonService.ConvertJsonList<ModelModel>(asyncResult);           
            }
      
            homepage.Show();

            Close();
        }
    }
}