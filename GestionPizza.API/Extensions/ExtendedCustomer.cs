using System.Security.Claims;

namespace GestionPizza.API.Extensions
{
    public static class ExtendedCustomer
    {

        public static Guid GetId(this ClaimsPrincipal principal)
        {
            string? id = principal.FindFirst(ClaimTypes.Sid)?.Value;
            return id is not null ? new Guid(id) : Guid.Empty ;
        }
    }
}
