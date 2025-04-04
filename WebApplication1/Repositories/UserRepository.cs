using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly VechicleRentalSystemDbContext _context;
        public UserRepository(VechicleRentalSystemDbContext context)
        {
            _context = context;
        }
        public async Task<UserModel> GetUserByEmailAndPasswordAsync(string email,string password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
        }
        public async Task<int> AddNewCustomerAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();
        }
    }
}
