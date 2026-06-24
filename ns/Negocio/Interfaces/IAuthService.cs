using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Negocio.DTOs;
using Ecommerce.Negocio.Servicios;

namespace Ecommerce.Negocio.Interfaces
{
    public interface IAuthService
    {
        LoginRespuestaDTO Login(LoginDTO dto);
    }
}
