using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Presentación.Controladores.API
{
    [ApiController]
    [Route("api/productos")]
    [Tags("productos")]
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearProducto()
        {
            return View();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ObtenerProductos()
        {
            return View();
        }
    }
}
