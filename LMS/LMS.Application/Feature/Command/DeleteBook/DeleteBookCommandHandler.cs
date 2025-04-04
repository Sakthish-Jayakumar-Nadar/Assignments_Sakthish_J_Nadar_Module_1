using LMS.Domain.Interface;
using MediatR;

namespace LMS.Application.Feature.Command.DeleteBook
{
    class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand,bool>
    {
        IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.DeleteBookByIdAsync(request.id);
        }
    }
}
