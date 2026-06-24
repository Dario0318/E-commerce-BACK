using Ecommerce.Negocio.Interfaces;

namespace Ecommerce.Negocio.Servicios
{
    public class PasswordService : IPasswordService
    {
        public string HasPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password,hash);
        }
    }
}
