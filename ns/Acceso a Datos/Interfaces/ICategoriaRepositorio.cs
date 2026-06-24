using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Acceso_a_Datos.Interfaces
{
    public interface ICategoriaRepositorio
    {
        bool Crear(CategoriaEntidad categoria);
        bool Editar(CategoriaEntidad categoria);
        bool Eliminar(int CodCategoria);
        List<CategoriaEntidad?> ObtenerDatos();
        CategoriaEntidad? ObtenerId(int CodCategoria); 
    }
}
