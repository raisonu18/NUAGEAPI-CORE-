using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace COREAPI.Services
{
    public static class MembershipManager
    {
        public static int CurrentUserID(this ClaimsPrincipal claimsPrincipal)
        {
            var userID = claimsPrincipal.Claims.ToList().Find(r => r.Type == "UserID").Value;
            return Convert.ToInt32(userID);
        }
        public static string CurrentUserRole(this ClaimsPrincipal claimsPrincipal)
        {
            var role = claimsPrincipal.Claims.ToList().Find(r => r.Type == "Role").Value;
            return role;
        }
    }
}
