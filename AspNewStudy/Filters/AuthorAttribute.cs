using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Filters
{
    public class AuthorAttribute
        : AuthorizeAttribute
    {
        private string[] allowedUsers;
        private string[] allowedRoles;

        public AuthorAttribute(string[] users, string[] roles)
        {
            allowedUsers = users;
            allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Request.IsAuthenticated &&
                allowedUsers.Contains(httpContext.User.Identity.Name) &&
                Role(httpContext);
        }

        private bool Role(HttpContextBase httpContext)
        {
            if (allowedRoles.Length > 0)
            {
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    if (httpContext.User.IsInRole(allowedRoles[i]))
                        return true;
                }
                return false;
            }
            return true;
        }
    }
}