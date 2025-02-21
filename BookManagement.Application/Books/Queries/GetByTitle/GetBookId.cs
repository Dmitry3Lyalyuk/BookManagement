using BookManagement.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Books.Queries.GetByTitle
{
    public record GetBookIdQuery : IRequest<BookDTO>
    {
        public Guid Id { get; set; }
    };

    public class GetBookIdQueryHandler : IRequestHandler<GetBookIdQuery, BookDTO>
    {
        private readonly IAppicationDbContext _context;
        public GetBookIdQueryHandler(IAppicationDbContext context)
        {
            _context = context;
        }
        public async Task<BookDTO> Handle(GetBookIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books
                .Where(t => t.Id == request.Id)
                .Select(t => new BookDTO()
                {
                    Id = t.Id,
                    Title = t.Title,
                    PublicationYear = t.PublicationYear,
                    AuthorName = t.AuthorName,
                    ViewCount = t.ViewCount
                }).FirstOrDefaultAsync(cancellationToken);


            var book = await _context.Books.FindAsync(request.Id);

            if (book != null)
            {
                book.ViewCount++;
                _context.Books.Update(book);

                await _context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
