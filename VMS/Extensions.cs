using System.Linq;
using System.Security.Claims;

namespace VMS
{
    public static class Extensions
    {
        public static string Id(this ClaimsPrincipal claimsPrincipal)
        {
            if(claimsPrincipal != null)
            {
                var id = claimsPrincipal.Claims.FirstOrDefault(t => t.Type == ClaimTypes.NameIdentifier);

                if (id != null)
                    return id.Value;
            }

            return "";
        }
    }
}
