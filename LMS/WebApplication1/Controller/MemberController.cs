using LMS.Application.Feature.Query.GetMembers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        readonly IMediator _mediator;
        public MemberController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMembersAsync()
        {
            var members = await _mediator.Send(new GetMembersQuery());
            return Ok(members);
        }
        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IActionResult> GetMemberByIdAsync(int id)
        //{
        //    var books = await _mediator.Send(new GetBooksQuery());
        //    return Ok(books);
        //}
        
    }
}
