using BusinessLogic.Abstractions;
using System;
using System.Windows;
using TyranidsWpfUI.ViewModels;

namespace TyranidsWpfUI.Views
{
    public partial class HomePageView : Window
    {
        private IApiService _apiService;

        public HomePageView(IApiService apiService)
        {
            _apiService = apiService;
            InitializeComponent();
        }
         
        private void HomePageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = _apiService.Authenticate("", "");
                var homepage = new HomepageViewModel();

                homepage.Show();

                Close();
            }
            catch(Exception ex)
            { /*Log here */} 
        }
    }
}
