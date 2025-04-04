using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetRequests
{
    public class GetRequestsQueryHandler : IRequestHandler<GetRequestsQuery, IEnumerable<Loan>>
    {
        IBookRepository _bookRepository;
        public GetRequestsQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<IEnumerable<Loan>> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
        {
            return _bookRepository.GetRequestsBooks(request.mid);
        }
    }
}
