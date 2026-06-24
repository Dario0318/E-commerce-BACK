using Ecommerce.Negocio.DTOs;

namespace Ecommerce.Negocio.Validadores
{
    public class ProductoValidador
    {
        public void validar(ProductoDTO dto)
        {
            if ((dto.Precio * 10000m) % 1 != 0) 
            {
                throw new Exception("El precio del producto no puede tener más de 4 cifras decimales");
            }
        }
    }
}
