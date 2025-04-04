using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using LMS.Application.Feature.Command.AddBook;
using LMS.Application.Feature.Command.BorrowBook;
using LMS.Application.Feature.Command.BorrowBookAccept;
using LMS.Application.Feature.Command.BorrowBookReject;
using LMS.Application.Feature.Command.DeleteBook;
using LMS.Application.Feature.Command.LoanBook;
using LMS.Application.Feature.Command.ReturnBook;
using LMS.Application.Feature.Command.UpdateBook;
using LMS.Application.Feature.Query.GetBookById;
using LMS.Application.Feature.Query.GetBooks;
using LMS.Application.Feature.Query.GetLoanBooks;
using LMS.Application.Feature.Query.GetMemberLoans;
using LMS.Application.Feature.Query.GetRequestAdmin;
using LMS.Application.Feature.Query.GetRequests;
using LMS.Application.Feature.Query.GetReturnBooks;
using LMS.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controller
{
    [Authorize(Roles = "librarian, member")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
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
        [Authorize(Roles = "member")]
        [Route("loan")]
        [HttpGet]
        public async Task<IActionResult> GetLoanBooksAsync()
        {
            string header = HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(header) && header.StartsWith("Bearer "))
            {
                string token = header.Substring("Bearer ".Length).Trim();
                string? mid = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(claim => claim.Type == "mid")?.Value;
                if (mid != null)
                {
                    IEnumerable<Loan> loans = await _mediator.Send(new GetLoanBooksQuery(mid));
                    return Ok(loans);
                }
            }
            return BadRequest("Insuffcient Data");
        }
        [Authorize(Roles = "member")]
        [Route("request")]
        [HttpGet]
        public async Task<IActionResult> GetRequestsAsync()
        {
            string header = HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(header) && header.StartsWith("Bearer "))
            {
                string token = header.Substring("Bearer ".Length).Trim();
                string? mid = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(claim => claim.Type == "mid")?.Value;
                if (mid != null)
                {
                    IEnumerable<Loan> loans = await _mediator.Send(new GetRequestsQuery(mid));
                    return Ok(loans);
                }
            }
            return BadRequest("Insuffcient Data");
        }
        [Authorize(Roles = "member")]
        [Route("return")]
        [HttpGet]
        public async Task<IActionResult> GetReturnBooksAsync()
        {
            string header = HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(header) && header.StartsWith("Bearer "))
            {
                string token = header.Substring("Bearer ".Length).Trim();
                string? mid = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(claim => claim.Type == "mid")?.Value;
                if (mid != null)
                {
                    IEnumerable<Loan> loans = await _mediator.Send(new GetReturnBooksQuery(mid));
                    return Ok(loans);
                }
            }
            return BadRequest("Insuffcient Data");
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBookAsync(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            return Ok(book);
        }
        [Authorize(Roles = "librarian")]
        [HttpPost]
        public async Task<IActionResult> AddBookAsync(Book book)
        {
            ModelState.Remove("Category");
            bool result = await _mediator.Send(new AddBookCommand(book));
            if(result)
            {
                return Ok(result);
            }
            return StatusCode(500, "Somthing went wrong") ;
        }
        [Authorize(Roles = "librarian")]
        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync(Book book)
        {
            Book updatedBook = await _mediator.Send(new UpdateBookCommand(book));
            if(updatedBook == null)
            {
                return StatusCode(500, "Somthing went wrong");
            }
            return Ok(updatedBook);
        }
        [Authorize(Roles = "librarian")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            bool result = await _mediator.Send(new DeleteBookCommand(id));
            if (result)
            {
                return Ok(result);
            }
            return StatusCode(500, "Somthing went wrong");
        }
        [Authorize(Roles = "member")]
        [Route("{id}/borrow")]
        [HttpPost]
        public async Task<IActionResult> BorrowBookRequestAsync(int id)
        {
            string header = HttpContext.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(header) && header.StartsWith("Bearer "))
            {
                string token = header.Substring("Bearer ".Length).Trim();
                string? mid = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(claim => claim.Type == "mid")?.Value;
                if(mid != null)
                {
                    bool result = await _mediator.Send(new BorrowBookCommand(id,mid));
                    if (result)
                    {
                        return Ok(result);
                    }
                    return Ok(result);
                }
            }
            return BadRequest("Insuffcient Data");
        }
        [Authorize(Roles = "librarian")]
        [Route("requests")]
        [HttpGet]
        public async Task<IActionResult> RequestAdminAsync()
        {
            IEnumerable<Loan> result = await _mediator.Send(new GetRequestAdminQuery());
            return Ok(result);
        }
        [Authorize(Roles = "librarian")]
        [Route("{id}/member/{mid}/return/{lid}")]
        [HttpPost]
        public async Task<IActionResult> ReturnBookAsync(int id, int lid, string mid)
        {
            if (mid != null && id > 1 && lid > 1)
            {
                bool result = await _mediator.Send(new ReturnBookCommand(id, lid, mid));
                return Ok(result);
            }
            return BadRequest("Insuffcient Data");
        }
        [Authorize(Roles = "librarian")]
        [Route("{id}/loan/{email}")]
        [HttpPost]
        public async Task<IActionResult> LoanBookAsync(int id, string email)
        {
            if (!string.IsNullOrEmpty(email) && id > 0)
            {
                bool result = await _mediator.Send(new LoanBookCommand(id, email));
                return Ok(result);
            }
            return BadRequest("Insuffcient Data");
        }
        [Authorize(Roles = "librarian")]
        [Route("{id}/member/{mid}/accept/{lid}")]
        [HttpPost]
        public async Task<IActionResult> BorrowBookAcceptAsync(int id, int lid, string mid)
        {
            if (!string.IsNullOrEmpty(mid) && id > 0)
            {
                bool result = await _mediator.Send(new BorrowBookAcceptCommand(id, lid, mid));
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Insuffcient Data");
        }
        [Authorize(Roles = "librarian")]
        [Route("{id}/member/{mid}/reject/{lid}")]
        [HttpPost]
        public async Task<IActionResult> BorrowBookRejectAsync(int id, int lid, string mid)
        {
            if (!string.IsNullOrEmpty(mid) && id > 0)
            {
                bool result = await _mediator.Send(new BorrowBookRejectCommand(id, lid, mid));
                if (result)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest("Insuffcient Data");
        }
        [Authorize(Roles = "librarian")]
        [Route("member/{mid}/loans")]
        [HttpGet]
        public async Task<IActionResult> GetMemberLoansAsync(string mid)
        {
            if (!string.IsNullOrEmpty(mid))
            {
                var result = await _mediator.Send(new GetMemberLoansQuery(mid));
                return Ok(result);
            }
            return BadRequest("Insuffcient Data");
        }
    }
}
