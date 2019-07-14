using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Static_Values;
using DataManager.Abstractions;
using DataManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcUi.Models;
using TyranidsApi.Abstractions;
using TyranidsApi.Static_Values;

namespace MvcUi.Controllers
{
    public class HomeController : Controller
    {
        private IApiService _apiService;
        private IJsonService _jsonService;
        private IQueryUnitOfWork _queryUnitOfWork;
        private IRepositoryFactory _repositoryFactory;

        public HomeController(IApiService apiService, IJsonService jsonService, IQueryUnitOfWork queryUnitOfWork, 
            IRepositoryFactory repositoryFactory)
        {
            _apiService = apiService;
            _jsonService = jsonService;
            _queryUnitOfWork = queryUnitOfWork;
            _repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetBannerData()
        {
            var endpoint = $"{GlobalTypes.TestApiLocation}/{ApiEndpoints.Models}/{ApiQueryParams.Classification}";
            var response = await _apiService.GetDataAsync(endpoint);
            var result = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                var asyncResult = response.Content.ReadAsStringAsync().Result;
                var items = _jsonService.ConvertJsonList<ModelModel>(asyncResult).ToList();

                foreach (var item in items)
                {
                    var firstOrLastItem = items.Count == 0 || item == items.Last();
                    var delimiter = firstOrLastItem ? string.Empty : ",";

                    result = $"{result}{item.Name}{delimiter}";
                }
            }

            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
