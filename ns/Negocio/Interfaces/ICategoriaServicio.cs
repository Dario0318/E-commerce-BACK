using Ecommerce.Negocio.DTOs;

namespace Ecommerce.Negocio.Interfaces
{
    public interface ICategoriaServicio
    {
        List<CategoriaDTO> ListarCategorias();
        CategoriaDTO ObtenerCategoria(int CodCategoria);
        bool Registrar(CategoriaDTO dto);

        bool Actualizar(CategoriaDTO dto);

        bool Eliminar(int id);
    }
}
