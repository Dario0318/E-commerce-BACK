using Ecommerce.Acceso_a_Datos.Interfaces;
using Ecommerce.Negocio.DTOs;
using Ecommerce.Negocio.Interfaces;

namespace Ecommerce.Negocio.Servicios
{
    public class AuthService: IAuthService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public AuthService(IUsuarioRepositorio usuarioRepositorio,
            IPasswordService passwordService,
            IJwtService jwtService)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        public LoginRespuestaDTO Login(LoginDTO dto)
        {
            //Buscamos el usuario
            var usuario = _usuarioRepositorio.ObtenerUsuario(dto.Usuario!);
            if (usuario == null)
            {
                throw new Exception("Usuario no existe");
            }

            //Validamos la contraseña
            bool valido = _passwordService.VerifyPassword(dto.Password!,
                                                usuario.PasswordHash!);

            if (!valido)
            {
                throw new Exception("Contraseña Incorrecta");
            }

            //Generar los tokens
            string token = _jwtService.GenerarToken(usuario);
            string refrescarToken = _jwtService.GenerarRefreshToken();

            //Guardar el refresh token
            usuario.RefreshToken = refrescarToken;
            usuario.RefreshTokenExpira = DateTime.UtcNow.AddDays(7);
            _usuarioRepositorio.ActualizarRefreshToken(usuario);

            //Retornar el DTO de respuesta estructurado
            return new LoginRespuestaDTO
            {
                Token = token,
                RefreshToken = refrescarToken,
                Nombre = usuario.NomUsuario,
                Rol = usuario.CodRol
            };
        }
    }
}
