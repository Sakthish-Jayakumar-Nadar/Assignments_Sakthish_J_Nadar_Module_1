using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetMemberLoans
{
    public record GetMemberLoansQuery(string mid) : IRequest<IEnumerable<Loan>>;
}
