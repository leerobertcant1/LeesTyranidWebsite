using System.Diagnostics;
using DataManager.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcUi.Models;
using TyranidsApi.Abstractions;

namespace MvcUi.Controllers
{

    /* 
     * TO DO - Update Git Ignore.
     * TO DO - use API project to get the data.
     * TO DO - start dynamically adding items to the UI.
     * TO DO - Integrate security on API calls.
     * TO DO - Look at mentioned advanced features.
     */


    public class HomeController : Controller
    {
        private IApiService _apiService;
        private IJsonService _jsonService;
        private IQueryUnitOfWork _queryUnitOfWork;
        private IRepositoryFactory _repositoryFactory;

        public HomeController(IApiService apiService, IJsonService jsonService, IQueryUnitOfWork queryUnitOfWork, IRepositoryFactory repositoryFactory)
        {
            _apiService = apiService;
            _jsonService = jsonService;
            _queryUnitOfWork =
            _queryUnitOfWork = queryUnitOfWork;
            _repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HQ()
        {
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
    }
}
