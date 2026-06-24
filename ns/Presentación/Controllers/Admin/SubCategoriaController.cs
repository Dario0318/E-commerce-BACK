using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentación.Controladores.Admin
{
    public class SubCategoriaController : Controller
    {
        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
