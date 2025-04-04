using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Role");
            return Redirect("/Login/Index");
        }
    }
}
