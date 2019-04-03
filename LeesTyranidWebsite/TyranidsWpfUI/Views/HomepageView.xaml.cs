using Api.Controllers;
using Api.Static_Values;
using DataManager.Abstractions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using TyranidsApi.Abstractions;
using TyranidsApi.Static_Values;
using TyranidsWpfUI.ViewModels;

namespace TyranidsWpfUI.Views
{
    public partial class HomePageView : Window
    {
        private IApiService _apiService;
        private IQueryUnitOfWork _queryUnitOfWork;
        private IRepositoryFactory _repositoryFactory;

        public HomePageView(IApiService apiService, IQueryUnitOfWork queryUnitOfWork, IRepositoryFactory repositoryFactory)
        {
            _apiService = apiService;
            _queryUnitOfWork = queryUnitOfWork;
            _repositoryFactory = repositoryFactory;

            InitializeComponent();
        }
       
        private async void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            var homepage = new HomepageViewModel();
            var result = string.Empty;


            //Need to write service to handle this in JSON
            var response = await _apiService.GetData(ApiEndpoints.Models);

            if (!response.IsSuccessStatusCode)
                result = "An error occcured";
            else
                result = response.Content.ReadAsStringAsync().Result;


            homepage.Show();

            Close();
        }
    }
}
