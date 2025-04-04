using LMS.Domain.Model;

namespace LMS.Domain.Interface
{
    public interface IAuthRepository
    {
        public Task<AuthResponse> Login(AuthRequest authRequest);
        public Task<RegistrationResponse> Register(RegistrationRequest registrationRequest);
    }
}
