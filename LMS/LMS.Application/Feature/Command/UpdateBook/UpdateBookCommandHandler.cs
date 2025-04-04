using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Command.UpdateBook
{
    class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        IBookRepository _bookRepository;
        public UpdateBookCommandHandler(IBookRepository bookREpository)
        {
            _bookRepository = bookREpository;
        }
        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return _bookRepository.UpdateBookByIdAsync(request.book);
        }
    }
}
