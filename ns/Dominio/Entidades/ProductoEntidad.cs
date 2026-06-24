namespace Ecommerce.Dominio.Entidades
{
    public class ProductoEntidad
    {
        public int CodProducto { get; set; }
        public string?  NomProducto { get; set; }
        public string? Descripcion { get; set; }
        public Decimal Precio { get; set; }
        public int CodSubCategoria { get; set; }
        public int CodEstadoProducto { get; set; }
        public int CodMarca {  get; set; }
    }
}
