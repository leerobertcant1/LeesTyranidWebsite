using Microsoft.AspNetCore.Mvc;

namespace Tyranids.MvcUi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}