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
using Tyranids.Globals;
using Tyranids.MvcUi.Models;

namespace MvcUi.Controllers
{
    /*
     * TO DO - Remove API creation for now and limit API calls prior to deployment.
     * TO DO = Change descriptions and footer/ header.
     * TO DO - Check Games Workshop's rules.
     * TO DO - Deployment (Maybe Azure, deploy Website, Database and API). If not, look at cheap deployment.
     * TO DO - CICD process.
     * TO DO - Add Unit Tests.
     * TO DO - Add Integration Tests.
     * TO DO - Add Automation Tests.
     * -------------------------------------------------
     * Nice to have:
     * TO DO - Re-organise solutions + rename
     * TO DO - Dynamically read local host.
     * TO DO - Add area where I can add the models myself and their associated image for Admin only.
     * TO DO - Implement Login Identity with ASP.NET Core - Started Identity Repo up to Api level (https://docs.microsoft.com/en-us/aspnet/identity/overview/getting-started/adding-aspnet-identity-to-an-empty-or-existing-web-forms-project)
     * TO DO - Divide all areas into controllers (Models).
     * TO DO - Add CRSF around CreateUser.cshtml and endpoint to register.
     * TO DO - Error handling around APIs for status codes. etc.     
     * TO DO - Redo Unit of Work, implemented wrong.
     * TO DO - Add Automapper to map objects.
     * TO DO - API change homepage.
     * TO DO - Better responses from API.
     * TO DO - Allow JPGs only with certain file limit.
     * TO DO - Add more controllers for API end points and combine API endpoints code.
     * TO DO - Add security around end points and request limit, somehow?
     * TO DO - Change to Stored Procedures.         
     * TO DO - Look at ES6+ for JS functions.
     * TO DO - Add empty DB data.     
     * TO DO - Deployment with Docker.     
     * TO DO - Look at changing to DDD.
     * TO DO - Investigate GraphQL.     
     */

    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiDataService<ModelModelPicture> _apiDataService;

        public HomeController(IApiDataService<ModelModelPicture> apiDataService, IConfiguration configuration)
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
            var castedData = GlobalFunctions.CastIList<ModelModelPicture>(apiData.Response);

            var isNoApiData = apiData == null || apiData.Response == null || castedData.Count == 0;
            var viewModel = GetViewModel(castedData);

            return isNoApiData || viewModel == new ModelsViewModel() ? 
                View() : 
                View(new ModelsViewModel { Type = type, Models = viewModel.Models });
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
                   $"{GlobalStrings.GetAllWhere}" +
                   $"{GlobalStrings.ModelClassificationEnum}{modelClass}&" + 
                   $"{GlobalStrings.Picture}{true}";
        }

        private ModelsViewModel GetViewModel(IList<ModelModelPicture> castedData)
        {
            var viewModel = new ModelsViewModel();

            foreach (var castedItem in castedData)
            {
                var existingItem = viewModel.Models.Where(x => x.Name == castedItem.Name).FirstOrDefault();

                if(existingItem == null)
                {
                    viewModel.Models.Add(new PictureViewModel { Location = castedItem.Location, Name = castedItem.Name, Titles = new List<string> { castedItem.Title } });

                    continue;
                }

                viewModel.Models.Where(x => x == existingItem).FirstOrDefault().Titles.Add(castedItem.Title);
            }

            return viewModel;
        }
    }
}
