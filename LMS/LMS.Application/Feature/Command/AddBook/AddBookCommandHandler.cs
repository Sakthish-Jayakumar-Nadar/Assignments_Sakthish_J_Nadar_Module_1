using LMS.Domain.Interface;
using MediatR;

namespace LMS.Application.Feature.Command.AddBook
{
    class AddBookCommandHandler : IRequestHandler<AddBookCommand, bool>
    {
        IBookRepository _bookRepository;
        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.AddBookAsync(request.book);
        }
    }
}
