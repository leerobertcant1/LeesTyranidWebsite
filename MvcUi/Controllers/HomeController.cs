using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcUi.Models;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.MvcUi;
using Tyranids.MvcUi.Models;
using TyranidsApi.Abstractions;

namespace MvcUi.Controllers
{
    /* 
     * TO DO - implement logger in areas.
     * TO DO - style the UI better 9 maybe don't show where none, etc.
     * TO DO - Refactor API data into a service
     * TO DO - Integrate security on API calls.
     * TO DO - Refactor Repositories into one, because common code.
     * TO DO - Refactor into one .cshtml file perhaps.
     * TO DO - implement login.
     * TO DO - Add area where I can add the models myself and their associated image for Admin only.
     * TO DO - Allow JPGs only with certain file limit.
     * TO DO - Add more controllers for API end points and combine API endpoints code.
     * TO DO  -Add security around end points and request limit, somehow?
     * TO DO - Change to Stored Procedures.
     * TO DO - Add Unit Tests.
     * TO DO - Add Integration Tests.
     * TO DO - Look at ES6+ for JS functions.
     * TO DO - Add empty DB data.
     * TO DO - Deployment normal on Azure.
     * TO DO - Deployment with Docker.
     * TO DO - CICD process.
     * TO DO - Look at changing to DDD.
     * TO DO - Investigate GraphQL.
     * TO DO - fill out empty DB data.
     * TO DO - Look at Mobiles.
     * TO DO - Look at .NETCore.
     * TO DO - Look at PWA.
     */

    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;
        private readonly IJsonService _jsonService;
        private readonly ISeriLoggerService _seriLoggerService;

        public HomeController(IApiService apiService, IConfiguration configuration, 
            IJsonService jsonService, ISeriLoggerService seriLoggerService)
        {
            _apiService = apiService;
            _configuration = configuration;
            _jsonService = jsonService;
            _seriLoggerService = seriLoggerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> HQ()
        {
            var endpoint = GetModelClassificationString(GlobalStrings.ModelClassificationHQ);
            var apiData =  await GetApiData(endpoint);
            IList<ModelModel> castedData = CastIList<ModelModel>(apiData.Response);

            var isNoApiData = apiData == null || apiData.Response == null || castedData.Count == 0;

            return isNoApiData  ? View() : (IActionResult)View(castedData);
        }

        public async Task<IActionResult> Troops()
        {
            var endpoint = GetModelClassificationString(GlobalStrings.ModelClassificationTroops);
            var apiData = await GetApiData(endpoint);
            var isNoApiData = apiData == null || apiData.Response == null || !apiData.Response.Any();

            return isNoApiData ? View() : (IActionResult)View(apiData.Response);
        }

        public async Task<IActionResult> Elites()
        {
            var endpoint = GetModelClassificationString(GlobalStrings.ModelClassificationElites);
            var apiData = await GetApiData(endpoint);
            var isNoApiData = apiData == null || apiData.Response == null || !apiData.Response.Any();

            return isNoApiData ? View() : (IActionResult)View(apiData.Response);
        }

        public async Task<IActionResult> FastAttack()
        {
            var endpoint = GetModelClassificationString(GlobalStrings.ModelClassificationFastAttack);
            var apiData = await GetApiData(endpoint);
            var isNoApiData = apiData == null || apiData.Response == null || !apiData.Response.Any();

            return isNoApiData ? View() : (IActionResult)View(apiData.Response);
        }

        public async Task<IActionResult> HeavySupport()
        {
            var endpoint = GetModelClassificationString(GlobalStrings.ModelClassificationHeavySupport);
            var apiData = await GetApiData(endpoint);
            var isNoApiData = apiData == null || apiData.Response == null || !apiData.Response.Any();

            return isNoApiData ? View() : (IActionResult)View(apiData.Response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IList<T> CastIList<T>(dynamic data)
        {
            return (data as IEnumerable<T>).Cast<T>().ToList();
        }

        private string GetModelClassificationString(string modelClass)
        {
            return $"{GlobalStrings.ModelEndpointRoute}/{GlobalStrings.GetAllWhere}{GlobalStrings.ModelClassificationEnum}{modelClass}";
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
                _seriLoggerService.LogData(exception);

                return new ApiModel { ErrorMessage = "An error occcured", IsError = true };
            }
        }
    }
}
