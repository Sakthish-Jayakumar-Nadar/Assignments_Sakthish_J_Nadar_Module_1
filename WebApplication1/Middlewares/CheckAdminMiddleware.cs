
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Enums;

namespace WebApplication1.Middlewares
{
    public class CheckAdminMiddleware : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!(context.HttpContext.Session.GetInt32("Role") == (int)RoleType.Admin))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller","Logout"},
                    {"action","Index" }
                });
            }
        }
    }
}
