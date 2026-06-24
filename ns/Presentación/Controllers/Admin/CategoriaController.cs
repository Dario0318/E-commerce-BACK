using Ecommerce.Negocio.Atributos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Acceso_a_Datos;
using Ecommerce.Acceso_a_Datos.Repositorios;
using Ecommerce.Dominio.Entidades;
using Ecommerce.Negocio.DTOs;
using Ecommerce.Negocio.Interfaces;

namespace Ecommerce.Presentación.Controladores.Admin
{
    [Authorize(Roles = "Administrador")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServicio _servicio;
        public CategoriaController(ICategoriaServicio servicio)
        {
            _servicio = servicio;
        }
        public IActionResult Index()
        {
            var categorias = _servicio.ListarCategorias();

            return View(categorias);
        }
        [HttpGet]
        public IActionResult CrearCategoria() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearCategoria(CategoriaDTO categoria)
        {
            if (!ModelState.IsValid) 
            {
                return View(categoria);
            }

            _servicio.Registrar(categoria);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var categoria = _servicio.ObtenerCategoria(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }
        [HttpPost]
        public IActionResult Editar(CategoriaDTO categoria)
        {
            if (!ModelState.IsValid)
                return View(categoria);

            _servicio.Actualizar(categoria);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var categoria = _servicio.ObtenerCategoria(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            _servicio.Eliminar(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
