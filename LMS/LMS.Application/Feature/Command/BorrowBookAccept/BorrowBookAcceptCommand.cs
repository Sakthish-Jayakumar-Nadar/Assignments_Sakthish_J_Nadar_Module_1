using MediatR;

namespace LMS.Application.Feature.Command.BorrowBookAccept
{
    public record BorrowBookAcceptCommand(int id, int lid, string mid) : IRequest<bool>;
}
