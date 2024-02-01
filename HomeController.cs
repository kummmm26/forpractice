using System.Diagnostics;
using eCommerceWebApp.UI.ExtensionMethods;
using eCommerceWebApp.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceWebApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetInt32("CustomerId", 3);
            //HttpContext.Session.SetString("Role", "Admin");
            //HttpContext.Session.Set<double>("PI", 3.14);
            //ViewBag.PI = HttpContext.Session.Get<double>("PI"); HttpContext.Session.SetInt32("CustomerId", 3);
            HttpContext.Session.Set<double>("p1", 3.13);
            ViewBag.PI = HttpContext.Session.Get<double>("p1");
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


