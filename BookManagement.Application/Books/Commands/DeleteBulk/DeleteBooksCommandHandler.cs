using BookManagement.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Books.Commands.DeleteBulk
{
    public class DeleteBooksCommandHandler : IRequestHandler<DeleteBooksCommand, List<Guid>>
    {
        private readonly IAppicationDbContext _context;
        public DeleteBooksCommandHandler(IAppicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Guid>> Handle(DeleteBooksCommand request, CancellationToken cancellationToken)
        {
            var delededBooksId = new List<Guid>();

            var bookToDelete = await _context.Books.Where(b => request.Id.Contains(b.Id))
                .ToListAsync(cancellationToken);

            if (bookToDelete.Count == 0)
            {
                return delededBooksId;
            }

            _context.Books.RemoveRange(bookToDelete);

            await _context.SaveChangesAsync(cancellationToken);

            return delededBooksId;
        }
    }

}

