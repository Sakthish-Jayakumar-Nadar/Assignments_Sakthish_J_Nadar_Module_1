using LMS.Domain.Interface;
using LMS.Domain.Model;
using LMS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repository
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly LMSDbContext _lMSDbContext;
        public MemberRepository(LMSDbContext lMSDbContext)
        {
            _lMSDbContext = lMSDbContext;
        }
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _lMSDbContext.Members.ToListAsync();
        }
    }
}
