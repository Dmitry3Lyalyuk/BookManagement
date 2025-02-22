using MediatR;

namespace BookManagement.Application.Books.Commands.DeleteBulk
{
    public record DeleteBooksCommand(List<Guid> Id) : IRequest<List<Guid>>;
}
