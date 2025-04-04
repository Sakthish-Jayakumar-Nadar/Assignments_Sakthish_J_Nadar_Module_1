using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetReturnBooks
{
    class GetReturnBooksQueryHandler : IRequestHandler<GetReturnBooksQuery, IEnumerable<Loan>>
    {
        IBookRepository _bookRepository;
        public GetReturnBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<IEnumerable<Loan>> Handle(GetReturnBooksQuery request, CancellationToken cancellationToken)
        {
            return _bookRepository.GetReturnBooks(request.mid);
        }
    }
}
