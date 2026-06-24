using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Negocio.Atributos
{
    public class PermissionAtributo: AuthorizeAttribute
    {
        public PermissionAtributo(string permission)
        {
            Policy = permission;
        }
    }
}
