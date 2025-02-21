using BookManagement.Application.Books.Commands.Create;
using BookManagement.Application.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Books.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly IAppicationDbContext _context;
        public CreateBookCommandValidator(IAppicationDbContext context)
        {
            _context = context;

            RuleFor(t => t.Title)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage("Title is required")
                .MustAsync(BeUniqueTitle).WithMessage("Title shuld be unique.");

            RuleFor(p => p.PublicationYear)
                .NotEmpty()
                .WithMessage("PublicationYear is required");

            RuleFor(a => a.AuthorName)
                .MinimumLength(1)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage("AuthorName is required");
        }

        private async Task<bool> BeUniqueTitle(string name, CancellationToken cancellationToken)
        {
            return !await _context.Books.AnyAsync(t => t.Title == name, cancellationToken);
        }
    }
}
