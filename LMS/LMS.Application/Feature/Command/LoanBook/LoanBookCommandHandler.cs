using LMS.Domain.Interface;
using MediatR;

namespace LMS.Application.Feature.Command.LoanBook
{
    public class LoanBookCommandHandler : IRequestHandler<LoanBookCommand, bool>
    {
        IBookRepository _bookRepository;
        public LoanBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<bool> Handle(LoanBookCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.LoanBookAsync(request.id, request.email);
        }
    }
}
