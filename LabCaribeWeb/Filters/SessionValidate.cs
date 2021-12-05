using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabCaribeWeb.Filters
{
    public class SessionValidate : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var menu = context.HttpContext.Session.GetString("Menu");
            if (menu == null)
            {

                if (context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest")
                {
                    context.HttpContext.Response.StatusCode = 403;
                    context.Result = new JsonResult(new { Data = "LogOut", url = context.HttpContext.Request.Path.Value });
                    base.OnActionExecuting(context);

                }
                else
                {
                    context.Result = new RedirectResult("~/Login");
                }
            }

        }
    }
}
