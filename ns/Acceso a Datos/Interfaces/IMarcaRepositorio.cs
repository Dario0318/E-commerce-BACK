using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Acceso_a_Datos.Interfaces
{
    public interface IMarcaRepositorio
    {
        bool CrearMarca(MarcaEntidad marca);
        bool EditarMarca(MarcaEntidad marca);
        bool EliminarMarca(int CodMarca);
        List<MarcaEntidad> ListarMarcas();
        MarcaEntidad? ObtenerMarca(int CodMarca);
    }
}
