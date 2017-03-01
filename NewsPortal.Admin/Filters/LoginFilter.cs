using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewsPortal.Admin.Filters
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var sessionControl = context.HttpContext.Session["UserEmail"];
            if (sessionControl == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "Account" }, { "Action", "Login" } });
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}