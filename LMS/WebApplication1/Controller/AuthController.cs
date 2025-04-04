using LMS.Domain.Interface;
using LMS.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthRepository _authService;
        public AuthController(IAuthRepository authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest authRequest)
        {
            var response = await _authService.Login(authRequest);
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }
    }
}
