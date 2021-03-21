using DataManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using Tyranids.BusinessLogic.Abstractions;
using Tyranids.Globals;
using Tyranids.MvcUi.Models;

namespace Tyranids.MvcUi.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiDataService<string> _apiDataService;
        private readonly IJsonService _jsonService;

        public UserController(IApiDataService<string> apiDataService, IConfiguration configuration, IJsonService jsonService)
        {
            _apiDataService = apiDataService;
            _configuration = configuration;
            _jsonService = jsonService;
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

            var endpoint = $"{GlobalStrings.DebugHomeApiDomain}/{GlobalStrings.ApiIdentity}/{GlobalStrings.IdentityCreate}";
            var identityModel = new IdentityModel 
            { 
                Password = model.Password,
                Username = model.Email
            };
  
            //Noty found need to pass string and cast to object
            var response = _apiDataService.PostApiData(endpoint, identityModel);

            if(response.Result.StatusCode == (int) HttpStatusCode.InternalServerError)
            {
                ModelState.AddModelError(GlobalStrings.GenericError, GlobalStrings.InternalServerError) ;
                return View(model);
            }

            return View();

            //return RedirectToAction("CreateUser");
        }

        public IActionResult Login(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }
    }
}