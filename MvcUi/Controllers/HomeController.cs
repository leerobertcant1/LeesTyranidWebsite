using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcUi.Models;
using Tyranids.MvcUi;
using Tyranids.MvcUi.Models;
using TyranidsApi.Abstractions;

namespace MvcUi.Controllers
{
    /* 
     * TO DO - use API project to get where
     * TO DO - setup logger.
     * TO DO - start dynamically adding items to the UI.
     * TO DO - Integrate security on API calls.
     * TO DO - Look at mentioned advanced features.
     */

    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        private readonly IJsonService _jsonService;

        public HomeController(IApiService apiService, IConfiguration configuration, IJsonService jsonService)
        {
            _apiService = apiService;
            _configuration = configuration;
            _jsonService = jsonService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> HQ()
        {
            var response =  await GetApiData(GlobalStrings.ModelClassificationEndPointEnum);

            return View();
        }

        public IActionResult Troops()
        {
            return View();
        }

        public IActionResult Elites()
        {
            return View();
        }

        public IActionResult FastAttack()
        {
            return View();
        }

        public IActionResult HeavySupport()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<ApiModel> GetApiData(string endPoint)
        {
            try
            {
                var baseApiAddress = _configuration[GlobalStrings.LocalHostApiEndPoints];

                if(string.IsNullOrEmpty(baseApiAddress))
                    return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true };

                var fullEndpoint = $"{baseApiAddress}{endPoint}";
                var response = await _apiService.GetDataAsync(fullEndpoint);

                if (!response.IsSuccessStatusCode)
                    return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true };
                else
                {
                    var asyncResult = response.Content.ReadAsStringAsync().Result;

                    return new ApiModel { IsError = false, Response = _jsonService.ConvertJsonList<ModelModel>(asyncResult) };
                }
            }
            catch (Exception exception)
            {
                return new ApiModel { ErrorMessage = "An error occcured", IsError = true };
            }
        }
    }
}
