using BookManagement.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Users.Queries
{
    public record GetAllUsersQuery : IRequest<List<UserDTO>>
    {

    }

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDTO>>
    {
        private readonly IAppicationDbContext _context;
        public GetAllUsersQueryHandler(IAppicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.User.Select(u => new UserDTO()
            {
                Id = u.Id,
                FullName = $"{u.FirstName} {u.LastName}",
                UserName = u.UserName,
                Email = u.Email
            }).ToListAsync(cancellationToken);
        }
    }
}
