﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;

namespace AspNewStudy.Filters
{
    public class AuthenAttribute
    {
        public class MyAuthAttribute :
            FilterAttribute, 
            IAuthenticationFilter
        {
            public void OnAuthentication(AuthenticationContext filterContext)
            {
                var user = filterContext.HttpContext.User;
                if (user == null || !user.Identity.IsAuthenticated)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }

            public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
            {
                var user = filterContext.HttpContext.User;
                if (user == null || !user.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary {
                    { "controller", "Account" }, { "action", "AccountLogin" }
                       });
                }
            }
        }
    }
}