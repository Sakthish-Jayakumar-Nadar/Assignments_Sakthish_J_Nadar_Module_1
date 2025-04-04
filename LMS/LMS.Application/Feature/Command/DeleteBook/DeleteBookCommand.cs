using MediatR;

namespace LMS.Application.Feature.Command.DeleteBook
{
    public record DeleteBookCommand(int id) : IRequest<bool>;
}
