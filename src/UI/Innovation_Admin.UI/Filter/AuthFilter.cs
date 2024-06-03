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
}
