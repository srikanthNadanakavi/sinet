using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Extentions
{
    public static class ClaimsPrincipalExtentions
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user){

            // user?.Claims?.FirstOrDefault(x=>x.Type == ClaimsTypes.Email)?.Value
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}