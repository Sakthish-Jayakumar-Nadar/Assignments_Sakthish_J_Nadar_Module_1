using MediatR;

namespace LMS.Application.Feature.Command.LoanBook
{
    public record LoanBookCommand(int id, string email) : IRequest<bool>;
}
