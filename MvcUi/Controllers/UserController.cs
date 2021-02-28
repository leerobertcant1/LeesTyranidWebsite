using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
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
        public IActionResult CreateUser(UserModel userModel)
        {
            if(userModel == null || string.IsNullOrEmpty(userModel.Email) || string.IsNullOrEmpty(userModel.Password))
            {
                //return error message
            }

            //Endpoint and post the data with HttpContent. Look at model.isvalid state

            //api/identity/create
            //identityModel
            _apiDataService.PostApiData(string.Empty, new HttpContent());

            return RedirectToAction("CreateUser");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}