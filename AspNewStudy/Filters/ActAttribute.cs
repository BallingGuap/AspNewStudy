using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Filters
{
    public class ActAttribute : FilterAttribute, IActionFilter
    {
        private string[] _blockBrowsers = null;
        ActAttribute(string[] blockBrowsers)
        {
            _blockBrowsers = blockBrowsers;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(_blockBrowsers);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            foreach (var browser in _blockBrowsers)
            {
                if (filterContext.HttpContext.Request.Browser.Browser == browser)
                {
                    filterContext.Result = new HttpNotFoundResult();
                    break;
                }
            }
        }
    }
}