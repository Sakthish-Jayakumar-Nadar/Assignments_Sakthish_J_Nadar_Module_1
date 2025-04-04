using LMS.Application.Feature.Query.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    class BookController : ControllerBase
    {
        readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddBookAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBookByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBookByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
    }
}
