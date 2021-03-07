using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.MvcUi.Models;

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

        [HttpPost]
        public IActionResult CreateUser(UserModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            //api/identity/create
            //identityModel
            //_apiDataService.PostApiData(string.Empty, new HttpContent());

            return RedirectToAction("CreateUser");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}