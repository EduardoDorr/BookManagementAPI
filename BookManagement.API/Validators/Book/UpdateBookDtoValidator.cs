using FluentValidation;

using BookManagement.Application.Dtos.Book;

namespace BookManagement.API.Validators.Book;

public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
{
    public UpdateBookDtoValidator()
    {
        RuleFor(b => b.Id)
            .GreaterThan(0)
            .WithMessage("Id must be valid");

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

        RuleFor(u => u.IsActive)
            .NotNull()
            .NotEmpty()
            .WithMessage("IsActive must not be null or empty");
    }
}