    using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Innovation_Admin.UI.Filter
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
       
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var Token = context.HttpContext.Session.GetString("Token");
                if (string.IsNullOrEmpty(Token))
                {
                    context.Result = new RedirectToActionResult("Login", "Account", new { });
                }
            }

        
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            response.Headers["Pragma"] = "no-cache";
            response.Headers["Expires"] = "-1";
            response.Headers.Remove("ETag");

            base.OnResultExecuting(filterContext);
        }
    }
}


