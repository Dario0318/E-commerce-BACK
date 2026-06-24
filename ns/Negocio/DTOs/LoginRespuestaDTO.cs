namespace Ecommerce.Negocio.DTOs
{
    public class LoginRespuestaDTO
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? Nombre { get; set; }
        public int Rol { get; set; }
    }
}
