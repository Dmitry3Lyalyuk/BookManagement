using BookManagement.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Books.Queries
{
    public record GetAllBooksQuery : IRequest<List<BookDTO>>;

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDTO>>
    {
        private readonly IAppicationDbContext _context;
        public GetAllBooksQueryHandler(IAppicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.Select(b => new BookDTO()
            {
                Id = b.Id,
                Title = b.Title,
                PublicationYear = b.PublicationYear,
                AuthorName = b.AuthorName,
                ViewCount = b.ViewCount
            }).ToListAsync(cancellationToken);
        }
    }
}
