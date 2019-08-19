using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myPatisserie.CustomActionFilters
{
    public class MyExceptionFilterAttribute : FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var exceptionMessage = filterContext.Exception.Message;
            filterContext.HttpContext.Response.Redirect("/Home/Error");
        }
    }
}