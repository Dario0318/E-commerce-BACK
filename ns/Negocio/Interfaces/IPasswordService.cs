namespace Ecommerce.Negocio.Interfaces
{
    public interface IPasswordService
    {
        string HasPassword(string password);
        bool VerifyPassword(
                string password,
                string hash
            );
    }
}
