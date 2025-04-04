using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    public class LoginController : Controller
    {
        readonly IUserService _userService;
        public LoginController(IUserService userService) {
            _userService = userService;
        }
        public ActionResult Index(string redirect) 
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null && userId > 0)
            {
                return Redirect("Home/Index");
            }
            else
            {
                TempData["RedirectUrl"] = redirect;
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Index(LoginUserModel loginForm, string redirect = "Home/Index") 
        {
            if (!ModelState.IsValid)
            {
                return View(loginForm);
            }
            UserModel logedInUser = await _userService.GetUserByEmailAndPasswordAsync(loginForm.Email, loginForm.Password);
            if (logedInUser != null)
            {
                HttpContext.Session.SetInt32("UserId", logedInUser.UserId);
                HttpContext.Session.SetInt32("Role", logedInUser.Role);
                return Redirect(redirect);
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid UserId/Password";
                return RedirectToAction("Index");
            }
        }
    }
}
