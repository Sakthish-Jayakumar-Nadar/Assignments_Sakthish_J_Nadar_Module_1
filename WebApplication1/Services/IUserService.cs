using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<UserModel> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<int> AddNewCustomerAsync(UserModel user);
    }
}
