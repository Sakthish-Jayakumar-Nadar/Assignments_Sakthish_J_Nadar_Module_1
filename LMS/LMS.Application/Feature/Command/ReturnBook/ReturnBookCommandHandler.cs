using LMS.Application.Feature.Command.LoanBook;
using LMS.Domain.Interface;
using MediatR;

namespace LMS.Application.Feature.Command.ReturnBook
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, bool>
    {
        private readonly IBookRepository _bookRepository;
        public ReturnBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<bool> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.ReturnBookAsync(request.id, request.lid, request.mid);
        }
    }
}
