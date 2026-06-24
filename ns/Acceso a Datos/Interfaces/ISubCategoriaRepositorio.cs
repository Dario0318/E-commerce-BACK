using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Acceso_a_Datos.Interfaces
{
    public interface ISubCategoriaRepositorio
    {
        List<SubCategoriaEntidad> ListarSubCategorias();
        SubCategoriaEntidad ObtenerSubCategoria();
        bool EliminarSubCategoria(int CodSubCategoria);
        bool EditarSubCategoria(SubCategoriaEntidad subCategoria);
        bool CrearSubCategoria(SubCategoriaEntidad subCategoria);
    }
}
