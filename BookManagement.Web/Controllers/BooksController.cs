using BookManagement.Application.Books.Commands.Create;
using BookManagement.Application.Books.Commands.Delete;
using BookManagement.Application.Books.Commands.Update;
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
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] CreateBookCommand command)
        {
            try
            {
                var bookId = await _mediator.Send(command);

                if (bookId == Guid.Empty)
                {
                    return BadRequest("An error occured!");
                }

                return Ok(bookId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Id in URL does not match Id in request body.");
            }
            try
            {
                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex) when (ex.Message.Contains("was not found"))
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}