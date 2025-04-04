using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetLoanBooks
{
    public record GetLoanBooksQuery(string mid) : IRequest<IEnumerable<Loan>>;
}
