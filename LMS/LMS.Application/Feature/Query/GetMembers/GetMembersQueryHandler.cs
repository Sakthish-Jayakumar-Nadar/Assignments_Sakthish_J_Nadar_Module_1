using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetMembers
{
    class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
    {
        IMemberRepository _memberRepository;
        public GetMembersQueryHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;   
        }
        public Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            return _memberRepository.GetMembersAsync();
        }
    }
}
