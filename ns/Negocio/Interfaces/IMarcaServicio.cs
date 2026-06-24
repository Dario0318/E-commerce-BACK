using Ecommerce.Negocio.DTOs;

namespace Ecommerce.Negocio.Interfaces
{
    public interface IMarcaServicio
    {
        bool CrearMarca(MarcaDTO dto);
        bool EditarMarca(MarcaDTO dto);
        bool EliminarMarca(int CodMarca);
        List<MarcaDTO> ListarMarcas();
        MarcaDTO ObtenerMarca(int CodMarca);
    }
}
