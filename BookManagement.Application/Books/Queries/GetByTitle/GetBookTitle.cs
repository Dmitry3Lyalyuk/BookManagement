using BookManagement.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Books.Queries.GetByTitle
{
    public record GetBookTitleQuery : IRequest<BookDTO>
    {
        public string Title { get; set; }
    };

    public class GetBookIdQueryHandler : IRequestHandler<GetBookTitleQuery, BookDTO>
    {
        private readonly IAppicationDbContext _context;
        public GetBookIdQueryHandler(IAppicationDbContext context)
        {
            _context = context;
        }
        public async Task<BookDTO> Handle(GetBookTitleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books
                .Where(t => t.Title == request.Title)
                .Select(t => new BookDTO()
                {
                    Id = t.Id,
                    Title = t.Title,
                    PublicationYear = t.PublicationYear,
                    AuthorName = t.AuthorName,
                    ViewCount = t.ViewCount
                }).FirstOrDefaultAsync(cancellationToken);

            if (entity != null)
            {
                var book = await _context.Books.FindAsync(entity.Id);

                if (book != null)
                {
                    book.ViewCount++;
                    _context.Books.Update(book);

                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            return entity;
        }
    }
}