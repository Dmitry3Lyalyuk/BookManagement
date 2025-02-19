using BookManagement.Application.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var books = await _mediator.Send(query);

            if (books is null or [])
            {
                return NotFound("Not book found!");
            }

            return Ok(books);
        }
    }
}
