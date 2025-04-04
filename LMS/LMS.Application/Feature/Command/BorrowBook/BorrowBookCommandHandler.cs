using LMS.Domain.Interface;
using MediatR;

namespace LMS.Application.Feature.Command.BorrowBook
{
    class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand, bool>
    {
        IBookRepository _bookRepository;
        public BorrowBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<bool> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.BorrowBookAsync(request.id, request.memberId);
        }
    }
}
