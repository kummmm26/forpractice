using Microsoft.AspNetCore.Mvc;

namespace eCommerceWebApp.UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
