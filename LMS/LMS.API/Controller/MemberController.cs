using LMS.Application.Feature.Query.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [ApiController]
    class MemberController : ControllerBase
    {
        readonly IMediator _mediator;
        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMembersAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMemberByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddMemberAsync()
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMemberByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMemberByIdAsync(int id)
        {
            var books = await _mediator.Send(new GetBooksQuery());
            return Ok(books);
        }
    }
}
