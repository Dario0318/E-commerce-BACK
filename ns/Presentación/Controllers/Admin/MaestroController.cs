using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentación.Controllers.Admin
{
    public class MaestroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
