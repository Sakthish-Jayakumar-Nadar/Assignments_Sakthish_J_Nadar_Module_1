using LMS.Domain.Interface;
using MediatR;

namespace LMS.Application.Feature.Command.BorrowBookAccept
{
    class BorrowBookAcceptCommandHandler : IRequestHandler<BorrowBookAcceptCommand, bool>
    {
        IBookRepository _bookRepository;
        public BorrowBookAcceptCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<bool> Handle(BorrowBookAcceptCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.BorrowBookAcceptAsync(request.id, request.lid, request.mid);
        }
    }
}
