using MediatR;

namespace BookManagement.Application.Books.Commands.CreateBulk
{
    public record CreateBooksCommand(List<CreateBookDTO> Books) : IRequest<List<Guid>>;
}
