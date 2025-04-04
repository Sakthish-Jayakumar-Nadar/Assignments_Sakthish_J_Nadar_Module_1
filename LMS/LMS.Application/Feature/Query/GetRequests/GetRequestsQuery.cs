using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetRequests
{
    public record GetRequestsQuery(string mid) : IRequest<IEnumerable<Loan>>;
}
