using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Domain.Interface;
using LMS.Domain.Model;
using MediatR;

namespace LMS.Application.Feature.Query.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
    {
        readonly IBookRepository _bookRepository;
        public GetBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookRepository.GetBooksAsync();
        }
    }
}
