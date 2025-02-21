using BookManagement.Application.Common;
using BookManagement.Domain.Entity;
using MediatR;

namespace BookManagement.Application.Books.Commands.Create
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IAppicationDbContext _context;
        public CreateBookCommandHandler(IAppicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var entity = new Book
            {
                Title = request.Title,
                PublicationYear = request.PublicationYear,
                AuthorName = request.AuthorName,
            };

            _context.Books.Add(entity);


            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
