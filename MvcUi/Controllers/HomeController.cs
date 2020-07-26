using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcUi.Models;

namespace MvcUi.Controllers
{
    public class HomeController : Controller
    {
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
