using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Middlewares
{
    public class CheckLoginMiddleware : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!(context.HttpContext.Session.GetInt32("UserId") > 0))
            {
                var routeData = context.RouteData.Values;
                string routeValue = routeData["controller"].ToString()+"/"+ routeData["action"].ToString() + "/";
                foreach (var r in routeData)
                {
                    if (r.Key != "controller" && r.Key != "action")
                    {
                        routeValue = routeValue + r.Value + "/";
                    }
                }
                //routeValue = routeValue.Substring(0, routeValue.Length - 1);
                var routeValues = new { controller = "Login", action = "Index", redirect = routeValue };
                context.Result = new RedirectToRouteResult(routeValues);
            }
        }
    }
}
