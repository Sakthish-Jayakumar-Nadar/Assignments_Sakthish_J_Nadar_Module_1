using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByEmailAndPasswordAsync(string email,string password);
        Task<int> AddNewCustomerAsync(UserModel user);
    }
}
