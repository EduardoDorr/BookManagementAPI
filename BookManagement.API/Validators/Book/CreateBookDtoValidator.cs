using FluentValidation;

using BookManagement.Application.Dtos.Book;

namespace BookManagement.API.Validators.Book;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(b => b.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title must not be null or empty");

        RuleFor(b => b.Author)
            .NotNull()
            .NotEmpty()
            .WithMessage("Author must not be null or empty");

        RuleFor(b => b.Isbn)
            .NotNull()
            .NotEmpty()
            .WithMessage("Isbn must not be null or empty")
            .MaximumLength(13)
            .WithMessage("Isbn must have 13 characters");

        RuleFor(b => b.PublicationYear)
            .GreaterThan(0)
            .WithMessage("Publication year must be valid");

        RuleFor(b => b.Quantity)
            .NotNull()
            .NotEmpty()
            .WithMessage("Quantity must not be null or empty");
    }
}