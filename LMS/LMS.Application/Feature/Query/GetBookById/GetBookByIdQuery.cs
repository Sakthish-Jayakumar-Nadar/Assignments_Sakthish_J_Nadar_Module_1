using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetBookById
{
    public record GetBookByIdQuery(int id) : IRequest<Book>;
}
