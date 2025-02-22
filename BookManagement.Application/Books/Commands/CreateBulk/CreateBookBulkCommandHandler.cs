using BookManagement.Application.Common;
using BookManagement.Domain.Entity;
using MediatR;

namespace BookManagement.Application.Books.Commands.CreateBulk
{
    public class CreateBookBulkCommandHandler : IRequestHandler<CreateBooksCommand, List<Guid>>
    {
        private readonly IAppicationDbContext _context;

        public CreateBookBulkCommandHandler(IAppicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guid>> Handle(CreateBooksCommand request, CancellationToken cancellationToken)
        {
            var bookIds = new List<Guid>();

            foreach (var bookDTO in request.Books)
            {
                var entity = new Book
                {
                    Title = bookDTO.Title,
                    PublicationYear = bookDTO.PublicationYear,
                    AuthorName = bookDTO.AuthorName
                };
                _context.Books.Add(entity);
                bookIds.Add(entity.Id);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return bookIds;
        }
    }
}
