using MediatR;

namespace LMS.Application.Feature.Command.BorrowBookReject
{
    public record BorrowBookRejectCommand(int id, int lid, string mid) : IRequest<bool>;
}
