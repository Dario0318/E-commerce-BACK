using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentación.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
