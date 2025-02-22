using BookManagement.Application.Books.Queries.GetDTOtitle;
using BookManagement.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Books.Queries.GetDTOTitle
{
    public record GetAllBooksQuery : IRequest<List<BookDTOTitle>>;

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDTOTitle>>
    {
        private readonly IAppicationDbContext _context;
        public GetAllBooksQueryHandler(IAppicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDTOTitle>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.OrderByDescending(b => b.ViewCount)
                .Select(b => new BookDTOTitle()
                {
                    Title = b.Title,
                }).ToListAsync(cancellationToken);
        }
    }
}
