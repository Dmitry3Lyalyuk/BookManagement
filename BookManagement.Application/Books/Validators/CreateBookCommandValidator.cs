﻿using BookManagement.Application.Books.Commands.Create;
using FluentValidation;

namespace BookManagement.Application.Books.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(t => t.Title)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(p => p.PublicationYear)
                .LessThan(4)
                .WithMessage("Title is required")
                .NotEmpty()
                .WithMessage("PublicationYear is required");

            RuleFor(a => a.AuthorName)
                .MinimumLength(1)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage("AuthorName is required");
        }
    }
}
