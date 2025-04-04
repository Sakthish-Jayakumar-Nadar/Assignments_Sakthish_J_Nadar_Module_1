using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetMemberLoans
{
    public class GetMemberLoansQueryHandler : IRequestHandler<GetMemberLoansQuery,IEnumerable<Loan>>
    {
        IBookRepository _bookRepository;
        public GetMemberLoansQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<IEnumerable<Loan>> Handle(GetMemberLoansQuery request, CancellationToken cancellationToken)
        {
            return _bookRepository.GetMemberLoansAsync(request.mid);
        }
    }
}
