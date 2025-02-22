using BookManagement.Application.Books.Commands.Create;
using BookManagement.Application.Books.Commands.CreateBulk;
using BookManagement.Application.Books.Commands.Delete;
using BookManagement.Application.Books.Commands.DeleteBulk;
using BookManagement.Application.Books.Commands.Update;
using BookManagement.Application.Books.Queries.GetByTitle;
using BookManagement.Application.Books.Queries.GetDTOtitle;
using BookManagement.Application.Books.Queries.GetDTOTitle;
using BookManagement.Application.Models;
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

        [HttpPost("Bulk")]
        public async Task<ActionResult<List<Guid>>> CreateBooks([FromBody] CreateBooksCommand command)
        {
            try
            {
                var bookId = await _mediator.Send(command);

                return Ok(bookId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
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

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("Buik")]
        public async Task<ActionResult<List<Guid>>> DeleteBooks([FromBody] DeleteBooksCommand command)
        {
            try
            {
                var deletedBookIds = await _mediator.Send(command);

                if (deletedBookIds == null)
                {
                    return NotFound("No books found with the specified Id");
                }

                return Ok(deletedBookIds);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<BookDTOTitle>>> GetAllBooks([FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            var query = new GetAllBooksQuery { PageNumber = pageNumber, PageSize = pageSize };
            var books = await _mediator.Send(query);

            if (books == null || books.Items == null || books.Items.Count == 0)
            {
                return NotFound("Not book found!");
            }

            return Ok(books);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetBookDetails(string title)
        {
            var query = new GetBookTitleQuery { Title = title };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Book was not found.");
            }

            return Ok(result);
        }
    }
}