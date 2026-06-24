using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Negocio.DTOs
{
    public class UsuarioDTO
    {
        public int CodUsuario { get; set; }
        [Required(ErrorMessage ="El nombre del usuario es obligatorio")]
        public string? NomUsuario { get; set; }
    }
}
