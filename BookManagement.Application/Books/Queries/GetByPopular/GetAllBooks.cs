using BookManagement.Application.Books.Queries.GetDTOtitle;
using BookManagement.Application.Common;
using BookManagement.Application.Models;
using MediatR;

namespace BookManagement.Application.Books.Queries.GetDTOTitle
{
    public record GetAllBooksQuery : IRequest<PaginatedList<BookDTOTitle>>
    {
        public int PageSize { get; set; } = 3;
        public int PageNumber { get; set; } = 1;
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, PaginatedList<BookDTOTitle>>
    {
        private readonly IAppicationDbContext _context;
        public GetAllBooksQueryHandler(IAppicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<BookDTOTitle>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.OrderByDescending(b => b.ViewCount)
                .Select(b => new BookDTOTitle()
                {
                    Title = b.Title,
                }).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            //.ToListAsync(cancellationToken);
        }
    }
}
