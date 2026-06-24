namespace Ecommerce.Dominio.Entidades
{
    public class UsuarioEntidad
    {
        public int CodUsuario { get; set; }
        public string? NomUsuario { get; set; }
        public string? Correo { get; set; }
        public int CodRol {  get; set; }
        public string? NomRol { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Cese { get; set; }
        public int  CodEstadoUsuario { get; set; }
        public List<string?> Permisos { get; set; } = new();
        public string? PasswordHash {  get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpira { get; set; }
    }
}
