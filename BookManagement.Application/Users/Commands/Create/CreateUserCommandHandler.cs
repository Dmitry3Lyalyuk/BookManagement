using BookManagement.Application.Common;
using BookManagement.Domain.Entity;
using MediatR;

namespace BookManagement.Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IAppicationDbContext _context;
        public CreateUserCommandHandler(IAppicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email
            };

            _context.User.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
