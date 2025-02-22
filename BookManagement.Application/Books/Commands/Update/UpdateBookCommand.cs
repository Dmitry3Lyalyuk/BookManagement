using MediatR;

namespace BookManagement.Application.Books.Commands.Update
{
    public record UpdateBookCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; }
    }
}
