using Ecommerce.Negocio.DTOs;

namespace Ecommerce.Negocio.Validadores
{
    public class CategoriaValidador
    {
        public void Validar(CategoriaDTO categoria) 
        {
            if (string.IsNullOrEmpty(categoria.NomCategoria))
            {
                throw new Exception("El nombre de la categoría es obligatorio");
            }
            if (categoria.NomCategoria.Length > 180)
            {
                throw new Exception("El nombre de la categoría no puede superar los 180 caracteres");
            }
        }

    }
}
