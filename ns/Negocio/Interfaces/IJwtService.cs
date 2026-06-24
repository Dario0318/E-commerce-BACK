using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Negocio.Interfaces
{
    public interface IJwtService
    {
        string GenerarToken(UsuarioEntidad usuario);
        string GenerarRefreshToken();
    }
}
