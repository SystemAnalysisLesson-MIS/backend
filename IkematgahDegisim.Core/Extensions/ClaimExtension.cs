using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace IkematgahDegisim.Core.Extensions
{
    public static class ClaimExtension
    {
        public static void AddEmail(this ICollection<Claim> claims,string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name,name));
        }

        public static void AddIdentifierName(this ICollection<Claim> claims, string Identifiername)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Identifiername));
        }

        public static void AddRoles(this ICollection<Claim> claims,string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
