using Ecommerce.Dominio.Entidades;

namespace Ecommerce.Acceso_a_Datos.Interfaces
{
    public interface IProductoRepositorio
    {
        List<ProductoEntidad> ListarProductos();
        ProductoEntidad? ObtenerProducto(int CodProducto);
        bool CrearProducto(ProductoEntidad producto);
        bool EditarProducto(ProductoEntidad producto);
        bool EliminarProducto(int CodProducto);

    }
}
