using System.Diagnostics;
using System.Threading.Tasks;
using DataManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MvcUi.Models;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.Globals;
using Tyranids.MvcUi.Models;

namespace MvcUi.Controllers
{
    /* 
     * TO DO - Implement Login Identity with ASP.NET Core - Started Identity Repo up to Api level (https://docs.microsoft.com/en-us/aspnet/identity/overview/getting-started/adding-aspnet-identity-to-an-empty-or-existing-web-forms-project)
     * TO DO - Add CRSF around CreateUser.cshtml and endpoint to register.
     * TO DO - Divide all areas into controllers (Models).
     * TO DO - Redo Unit of Work, implemented wrong.
     * TO DO - Add Automapper to map objects.
     * TO DO - API change homepage.
     * TO DO - Better responses from API.
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
        private readonly IConfiguration _configuration;
        private readonly IApiDataService<ModelModel> _apiDataService;

        public HomeController(IApiDataService<ModelModel> apiDataService, IConfiguration configuration)
        {
            _apiDataService = apiDataService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Models(string type)
        {
            var endpoint = GetModelClassificationString(type);
            var apiData = await _apiDataService.GetApiData(endpoint);
            var castedData = GlobalFunctions.CastIList<ModelModel>(apiData.Response);

            var isNoApiData = apiData == null || apiData.Response == null || castedData.Count == 0;

            return isNoApiData ? View() : View(new ModelsViewModel { Type = type, Models = castedData });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetModelClassificationString(string modelClass)
        {
            return $"{GlobalStrings.DebugHomeApiDomain}/" +
                   $"{GlobalStrings.ModelEndpointRoute}/" +
                   $"{GlobalStrings.GetAllWhere}{GlobalStrings.ModelClassificationEnum}{modelClass}";
        }
    }
}
