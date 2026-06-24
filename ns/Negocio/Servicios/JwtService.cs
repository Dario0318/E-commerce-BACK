using Ecommerce.Negocio.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Ecommerce.Dominio.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Negocio.Servicios
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        public JwtService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerarRefreshToken()
        {
            var bytes = new byte[64];

            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        public string GenerarToken(UsuarioEntidad usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,
                usuario.CodUsuario.ToString()),

                new Claim(ClaimTypes.Name,
                usuario.NomUsuario ?? ""),

                new Claim(ClaimTypes.Role,
                usuario.NomRol ?? ""),

            };

            foreach (var permiso in usuario.Permisos)
            {
                if (!string.IsNullOrWhiteSpace(permiso))
                {
                    claims.Add(new Claim("Permission", permiso));
                }
            }

            var key =
            new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                    _config["Jwt:Key"]!));

            var cred =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var token =
                new JwtSecurityToken(
                    issuer:
                        _config["Jwt:Issuer"],

                    audience:
                        _config["Jwt:Audience"],

                    claims: claims,

                    expires:
                        DateTime.Now.AddMinutes(30),

                    signingCredentials:
                        cred);



            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
