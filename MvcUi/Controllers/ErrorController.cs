using Microsoft.AspNetCore.Mvc;

namespace Tyranids.MvcUi.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
