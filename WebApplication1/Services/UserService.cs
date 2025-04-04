using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
        }
        public async Task<int> AddNewCustomerAsync(UserModel user)
        {
            return await _userRepository.AddNewCustomerAsync(user);
        }
    }
}
