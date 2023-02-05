using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNewStudy.Filters
{
    public class ExceptAttributecs : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is NullReferenceException)
            {
                exceptionContext.Result = new HttpNotFoundResult();
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}
