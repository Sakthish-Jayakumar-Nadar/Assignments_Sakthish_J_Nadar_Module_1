using LMS.Application.Feature.Query.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [ApiController]
    class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
    }
}
