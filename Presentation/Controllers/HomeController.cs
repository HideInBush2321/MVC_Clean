using Interfaces.Logic.ThingsMaker;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IThingsMaker interfaceApp;

        public HomeController(ILogger<HomeController> logger, IThingsMaker interfaceApp)
        {
            _logger = logger;
            this.interfaceApp = interfaceApp;
        }

        public IActionResult Index()
        {
            var ret = interfaceApp.MakeThis();
            return View();
        }

        public IActionResult Privacy()
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
