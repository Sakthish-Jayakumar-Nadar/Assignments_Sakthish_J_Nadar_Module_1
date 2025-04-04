using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Enums;
using WebApplication1.Middlewares;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null && userId > 0)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserModel userModel)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null && userId > 0)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                ModelState.Remove("UserId");
                ModelState.Remove("Bookings");
                if (!ModelState.IsValid)
                {
                    return View(userModel);
                }
                try
                {
                    int effectedRows = await _userService.AddNewCustomerAsync(userModel);
                    if (effectedRows > 0)
                    {
                        return Redirect("/Login/Index");
                    }
                    TempData["ErrorMessage"] = "Something went wrong";
                    return View();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        if (ex.InnerException.HResult == -2146232060)
                        {
                            TempData["ErrorMessage"] = "Email alreay exist";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Something went wrong";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong";
                    }
                    return View();
                }
            }
        }
    }
}
