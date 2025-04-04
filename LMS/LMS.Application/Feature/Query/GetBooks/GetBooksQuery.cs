using LMS.Domain.Model;
using MediatR; 

namespace LMS.Application.Feature.Query.GetBooks
{
    public record GetBooksQuery : IRequest<IEnumerable<Book>>;
}
