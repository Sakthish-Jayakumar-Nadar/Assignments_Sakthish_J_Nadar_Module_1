using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Command.UpdateBook
{
    public record UpdateBookCommand(Book book) : IRequest<Book>;
}
