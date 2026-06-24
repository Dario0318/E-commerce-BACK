using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Negocio.DTOs
{
    public class CategoriaDTO
    {
        public int CodCategoria { get; set; }
        //[Required(ErrorMessage = "El nombre es obligatorio")] --> Actúa como validador
        public string? NomCategoria { get; set; }
    }
}
