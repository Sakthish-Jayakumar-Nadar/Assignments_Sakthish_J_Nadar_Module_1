using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetMembers
{
    public record GetMembersQuery : IRequest<IEnumerable<Member>>;
}
