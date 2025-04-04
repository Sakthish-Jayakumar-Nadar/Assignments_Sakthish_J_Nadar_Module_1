using MediatR;

namespace LMS.Application.Feature.Command.ReturnBook
{
    public record ReturnBookCommand(int id, int lid, string mid) : IRequest<bool>;
}
