using MediatR;

namespace LMS.Application.Feature.Command.BorrowBook
{
    public record BorrowBookCommand(int id,string memberId) : IRequest<bool>;
}
