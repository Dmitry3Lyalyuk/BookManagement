using BookManagement.Application.Common;
using MediatR;

namespace BookManagement.Application.Books.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateBookCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Books.FindAsync([request.Id], cancellationToken);

            if (entity == null)
            {
                throw new Exception($"Entity with Id={request.Id} was mot found.");
            }

            entity.Title = request.Title;
            entity.PublicationYear = request.PublicationYear;
            entity.AuthorName = request.AuthorName;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
