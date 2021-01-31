using DataManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tyranids.BusinessLogic.Abstractions;

namespace Tyranids.MvcUi.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiDataService<string> _apiDataService;

        public UserController(IApiDataService<string> apiDataService, IConfiguration configuration)
        {
            _apiDataService = apiDataService;
            _configuration = configuration;
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}