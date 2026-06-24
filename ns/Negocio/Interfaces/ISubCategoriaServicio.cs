using Ecommerce.Negocio.DTOs;

namespace Ecommerce.Negocio.Interfaces
{
    public interface ISubCategoriaServicio
    {
        List<SubCategoriaDTO> ListarSubCategorias();
        SubCategoriaDTO ObtenerSubCategoria(int CodSubCategoria);
        bool CrearSubCategoria(SubCategoriaDTO subCategoria);
        bool EditarSubCategoria(SubCategoriaDTO subCategoria);
        bool EliminarSubCategoria(int CodSubCategoria);
    }
}
