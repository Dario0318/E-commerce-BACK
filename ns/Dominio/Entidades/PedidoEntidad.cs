namespace Ecommerce.Dominio.Entidades
{
    public class PedidoEntidad
    {
        public int CodPedido { get; set; }
        public int CodCliente { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public Decimal MontoTotal {  get; set; }
        public int CodEstadoPedido { get; set; }
    }
}
