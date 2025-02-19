using BookManagement.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);

            if (users is null or [])
            {
                return NotFound("Not user found!");
            }

            return Ok(users);
        }
    }
}
