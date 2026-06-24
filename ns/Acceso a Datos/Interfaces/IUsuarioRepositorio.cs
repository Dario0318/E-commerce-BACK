using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Acceso_a_Datos.Interfaces
{
    public interface IUsuarioRepositorio
    {
        UsuarioEntidad? ObtenerUsuario(string NomUsuario);
        void ActualizarRefreshToken(UsuarioEntidad usuario);
    }
}
