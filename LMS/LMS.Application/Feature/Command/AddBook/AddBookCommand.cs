using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Command.AddBook
{
    public record AddBookCommand(Book book) : IRequest<bool>;
}
