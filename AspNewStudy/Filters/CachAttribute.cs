using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Filters
{
    public class CachAttribute
        : ActionFilterAttribute
    {
        private int _duration { get; set; }

        public CachAttribute(int duration)
        {
            _duration = duration;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_duration <= 0) return;

            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            TimeSpan cacheDuration = TimeSpan.FromSeconds(_duration);

            cache.SetCacheability(HttpCacheability.Public);
            cache.SetExpires(DateTime.Now.Add(cacheDuration));
            cache.SetMaxAge(cacheDuration);

            cache.AppendCacheExtension("must-revalidate, proxy-revalidate");

        }
    }
}
