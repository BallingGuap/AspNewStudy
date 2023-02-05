using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Antlr.Runtime.Tree.TreeWizard;
using System.Web.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNewStudy.Filters
{
    public class LoggAttribute
        : ActionFilterAttribute
    {

        private ILogger<LoggAttribute> _logger = null;
        public LoggAttribute(ILogger<LoggAttribute> logger)
        => _logger = logger;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var login = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "";
            var ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
            _logger.LogInformation($"Login:\t{login}\n Ip:\tip\n Url:\t{request.RawUrl}\n Date:\t{DateTime.UtcNow}");
            base.OnActionExecuting(filterContext);
        }
    }
}