using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetBookById
{
    class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        readonly IBookRepository _bookRepository;
        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return _bookRepository.GetBookByIdAsync(request.id);
        }
    }
}
