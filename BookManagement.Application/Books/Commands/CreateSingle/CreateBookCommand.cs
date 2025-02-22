using MediatR;

namespace BookManagement.Application.Books.Commands.Create
{
    public record CreateBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; }
    }
}
