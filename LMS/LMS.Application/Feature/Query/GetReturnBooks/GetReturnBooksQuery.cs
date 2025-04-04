using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetReturnBooks
{
    public record GetReturnBooksQuery(string mid) : IRequest<IEnumerable<Loan>>;
}
