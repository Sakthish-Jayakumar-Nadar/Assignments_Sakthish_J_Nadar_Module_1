using LMS.Application.Feature.Command.BorrowBookAccept;
using LMS.Domain.Interface;
using MediatR;

namespace LMS.Application.Feature.Command.BorrowBookReject
{
    class BorrowBookRejectCommandHandler : IRequestHandler<BorrowBookRejectCommand, bool>
    {
        IBookRepository _bookRepository;
        public BorrowBookRejectCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<bool> Handle(BorrowBookRejectCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.BorrowBookRejectAsync(request.id, request.lid, request.mid);
        }
    }
}
