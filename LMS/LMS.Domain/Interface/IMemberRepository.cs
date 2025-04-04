using LMS.Domain.Model;

namespace LMS.Domain.Interface
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
    }
}
