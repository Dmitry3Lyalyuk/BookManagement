using MediatR;

namespace BookManagement.Application.Users.Commands.Create
{
    public record CreateUserCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
