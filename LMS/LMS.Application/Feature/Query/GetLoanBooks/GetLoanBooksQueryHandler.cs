using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetLoanBooks
{
    class GetLoanBooksQueryHandler : IRequestHandler<GetLoanBooksQuery, IEnumerable<Loan>>
    {
        IBookRepository _bookRepository;
        public GetLoanBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<IEnumerable<Loan>> Handle(GetLoanBooksQuery request, CancellationToken cancellationToken)
        {
            return _bookRepository.GetLoanBooks(request.mid);
        }
    }
}
