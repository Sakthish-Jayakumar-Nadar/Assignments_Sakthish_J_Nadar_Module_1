using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Execution;
using WebApplication1.Enums;
using WebApplication1.Middlewares;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserService _userService;
        readonly IVehicleService _vehicleService;
        public HomeController(IUserService userService, IVehicleService vehicleService)
        {
            _userService = userService;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        [ServiceFilter(typeof(CheckAdminOrDriverMiddleware))]
        public IActionResult AddVehicle()
        {
            return View();
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        [ServiceFilter(typeof(CheckAdminOrDriverMiddleware))]
        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromForm]VehicleModel vehicleModel)
        {
            ModelState.Remove("VehicleId");
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            ModelState.Remove("Bookings");
            ModelState.Remove("VehicleImageBytes");
            ModelState.Remove("VehicleImageContentType");
            if (!ModelState.IsValid)
            {
                return View(vehicleModel);
            }
            try
            {
                vehicleModel.UserId = (int)HttpContext.Session.GetInt32("UserId");
                int effectedRows = await _vehicleService.AddVehicleAsync(vehicleModel);
                if (effectedRows > 0)
                {
                    TempData["SuccessMessage"] = "Added successfully";
                    ModelState.Clear();
                    return View();
                }
                TempData["ErrorMessage"] = "Something went wrong";
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Something went wrong"; 
                return View();
            }
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        [ServiceFilter(typeof(CheckAdminOrDriverMiddleware))]
        public async Task<IActionResult> UpdateVehicle(int id)
        {
            VehicleModel vehicleModel = await _vehicleService.GetVehicleByVehicleIdAndUserIdAsync(id,(int)HttpContext.Session.GetInt32("UserId"));
            if (vehicleModel == null)
            {
                return RedirectToAction("Index");
            }
            return View(vehicleModel);
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        [ServiceFilter(typeof(CheckAdminOrDriverMiddleware))]
        [HttpPost]
        public async Task<IActionResult> UpdateVehicle(VehicleModel vehicleModel)
        {            
            ModelState.Remove("VehicleId");
            ModelState.Remove("UserId");
            ModelState.Remove("User");
            ModelState.Remove("Bookings");
            ModelState.Remove("VehicleImageBytes");
            ModelState.Remove("VehicleImageContentType");
            ModelState.Remove("VehicleImage");
            if (!ModelState.IsValid)
            {
                return View(vehicleModel);
            }
            try
            {
                int effectedRows = await _vehicleService.UpdateVehicleByIdAsync(vehicleModel);
                if (effectedRows > 0)
                {
                    TempData["SuccessMessage"] = "Updated successfully";
                    ModelState.Clear();
                    return View(vehicleModel);
                }
                TempData["ErrorMessage"] = "Something went wrong";
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Something went wrong";
                return View();
            }
        }
        public IActionResult RentingFilterForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RentingFilterForm(SearchActiveVehicleModel vehicles)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicles);
            }
            HttpContext.Session.SetString("RentingFilter", Newtonsoft.Json.JsonConvert.SerializeObject(vehicles));
            return RedirectToAction("GetAvailableVehicle");
        }
        public async Task<IActionResult> GetAvailableVehicle()
        {
            try
            {
                var serializedData = HttpContext.Session.GetString("RentingFilter");
                if (serializedData != null)
                {
                    var filter = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchActiveVehicleModel>(serializedData);
                    IEnumerable<VehicleModel> vehiclesList = await _vehicleService.GetAvailableVehicleAsync(filter);
                    if(vehiclesList.Count() == 0)
                    {
                        TempData["NoDataMessage"] = "No data for filter";
                    }
                    return View(vehiclesList);
                }
                return RedirectToAction("RentingFilterForm");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Something went wrong";
                return View();
            }
        }
        [Route("/Home/CreateBooking/{id?}/{price?}")]
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        public async Task<IActionResult> CreateBooking(int id, decimal price)
        {
            string serializedData = HttpContext.Session.GetString("RentingFilter");
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (serializedData != null && userId != null)
            {
                var filter = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchActiveVehicleModel>(serializedData);
                int effectedRow = await _vehicleService.AddBookingAsync(id, (int)userId, price, filter);
                if(effectedRow > 0)
                {
                    return RedirectToAction("BookingHistory");
                }
            }
            return RedirectToAction("GetAvailableVehicle");
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        public IActionResult BookingHistory()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            IEnumerable<BookingModel>bookings = _vehicleService.GetBookingByUserIdAsync(userId);
            return View(bookings);
        }
        [Route("/Home/CancelBooking/{id?}/{cancelType?}/{redirectPage?}")]
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        public async Task<IActionResult> CancelBooking(int id, int cancelType, string redirectPage)
        {
            try
            {
                int effectedRows = await _vehicleService.UpdateBookingByIdAsync(id,cancelType);
                if(effectedRows < 0)
                {
                    TempData["ErrorMessage"] = "Something went wrong";
                }
                return RedirectToAction(redirectPage);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Something went wrong";
                return RedirectToAction(redirectPage);
            }
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        [ServiceFilter(typeof(CheckAdminOrDriverMiddleware))]
        public async Task<IActionResult> RequestHistory()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            IEnumerable<BookingModel> bookings = await _vehicleService.GetRequestHistory(userId);
            return View(bookings);
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        public async Task<IActionResult> VehicleDetail(int id)
        {
            VehicleModel vehicle = await _vehicleService.GetVehicleByVehicleIdAsync(id);
            return View(vehicle);
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        public async Task<IActionResult> VehicleInfo(int id)
        {
            VehicleModel vehicle = await _vehicleService.GetVehicleByVehicleIdAsync(id);
            return View(vehicle);
        }
        [Route("/GetVehicleImage/{id}")]
        public async Task<IActionResult> GetVehicleImage(int id)
        {
            VehicleModel vehicle = await _vehicleService.GetVehicleByVehicleIdAsync(id);
            return File(vehicle.VehicleImageBytes,vehicle.VehicleImageContentType);
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        [ServiceFilter(typeof(CheckAdminOrDriverMiddleware))]
        public async Task<IActionResult> GetVehicleForUser()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            IEnumerable<VehicleModel> vehicles = await _vehicleService.GetVehicleByUserIdAsync(userId);
            return View(vehicles);
        }
        [ServiceFilter(typeof(CheckLoginMiddleware))]
        [ServiceFilter(typeof(CheckAdminOrDriverMiddleware))]
        public async Task<IActionResult> DeleteVehicleForUser(int id)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            int effectedRows = await _vehicleService.DeleteVehicleByIdAsync(id,userId);
            if(effectedRows > 0)
            {
                return RedirectToAction("GetVehicleForUser");
            }
            TempData["ErrorMessage"] = "Something went wrong";
            return RedirectToAction("GetVehicleForUser");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
