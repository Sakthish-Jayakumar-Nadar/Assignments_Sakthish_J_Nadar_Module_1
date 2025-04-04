using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetRequestAdmin
{
    public class GetRequestAdminQueryHandler : IRequestHandler<GetRequestAdminQuery, IEnumerable<Loan>>
    {
        IBookRepository _bookRepository;
        public GetRequestAdminQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<IEnumerable<Loan>> Handle(GetRequestAdminQuery request, CancellationToken cancellationToken)
        {
            return _bookRepository.GetRequestsAdmin();
        }
    }
}
