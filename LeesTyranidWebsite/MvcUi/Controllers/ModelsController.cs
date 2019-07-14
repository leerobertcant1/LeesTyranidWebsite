using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcUi.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}