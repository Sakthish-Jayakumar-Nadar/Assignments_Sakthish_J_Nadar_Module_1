using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetRequestAdmin
{
    public record GetRequestAdminQuery : IRequest<IEnumerable<Loan>>;
}
