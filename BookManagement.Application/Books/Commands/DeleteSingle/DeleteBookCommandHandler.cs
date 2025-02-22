using BookManagement.Application.Common;
using MediatR;

namespace BookManagement.Application.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IAppicationDbContext _context;
        public DeleteBookCommandHandler(IAppicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books.FindAsync([request.Id], cancellationToken);

            _context.Books.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
