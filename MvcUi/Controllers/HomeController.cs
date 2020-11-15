using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcUi.Models;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.BusinessLogic.Models;
using Tyranids.Globals;

namespace MvcUi.Controllers
{
    /* 
     * TO DO - Circular reference fix for ApiDataService
     * TO DO - Refactor into one .cshtml file perhaps.
     * To DO - Refactor private functions.
     * TO DO - implement login.
     * TO DO - Add area where I can add the models myself and their associated image for Admin only.
     * TO DO - Allow JPGs only with certain file limit.
     * TO DO - Add more controllers for API end points and combine API endpoints code.
     * TO DO - Add security around end points and request limit, somehow?
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
     */

    public class HomeController : Controller
    {
        private readonly IApiDataService _apiDataService;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration, IServiceLocator serviceLocator)
        {
            _apiDataService = serviceLocator.Get<IApiDataService>();
            _configuration = configuration;
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
            var baseApiAddress = _configuration[GlobalStrings.LocalHostApiEndPoints];

            if(string.IsNullOrEmpty(baseApiAddress))
                return new ApiModel { ErrorMessage = GlobalStrings.ErrorOccurred, IsError = true };

            var fullEndpoint = $"{baseApiAddress}{endPoint}";

            return await _apiDataService.GetApiData(fullEndpoint);


        }
    }
}
