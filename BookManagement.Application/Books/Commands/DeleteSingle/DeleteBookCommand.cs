using MediatR;

namespace BookManagement.Application.Books.Commands.Delete
{
    public record DeleteBookCommand(Guid Id) : IRequest;
}
