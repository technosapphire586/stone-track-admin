using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace LegumizeUI.Utilites
{
   public static class IdentityExtensions
    {

        //get userid claim value
        public static int GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).Claims.Where(c => c.Type == "UserID").Select(c => c.Value).SingleOrDefault();
            return (claim != null) ? int.Parse(claim) : 0;
        }
        //get device type like : web,android,ios so this will help you to find the record will be create by which device
        public static string GetDeviceType(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).Claims.Where(c => c.Type == "DeviceType").Select(c => c.Value).SingleOrDefault();
            return claim;
        }
        public static int GetUserRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).Claims.Where(c => c.Type == "RoleID").Select(c => c.Value).SingleOrDefault();
            return (claim != null) ? int.Parse(claim) : -1;
        }

        public static string GetUserRoleName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).Claims.Where(c => c.Type == "RoleName").Select(c => c.Value).SingleOrDefault();
            return claim ?? "";
        }

        public static string GetUserName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).Claims.Where(c => c.Type == "UserName").Select(c => c.Value).SingleOrDefault();
            return claim ?? "";
        }
        public static string Name(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).Claims.Where(c => c.Type == "Name").Select(c => c.Value).SingleOrDefault();
            return claim ?? "";
        }
    }
}
