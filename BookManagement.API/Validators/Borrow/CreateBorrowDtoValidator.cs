using FluentValidation;

using BookManagement.Application.Dtos.Borrow;

namespace BookManagement.API.Validators.User;

public class CreateBorrowDtoValidator : AbstractValidator<CreateBorrowDto>
{
    public CreateBorrowDtoValidator()
    {
        RuleFor(b => b.UserId)
            .GreaterThan(0)
            .WithMessage("User Id must be valid");

        RuleFor(b => b.BookId)
            .GreaterThan(0)
            .WithMessage("Book Id must be valid");

        RuleFor(b => b.ScheduledReturnDate)
            .NotNull()
            .NotEmpty()
            .WithMessage("Scheduled Return Date must not be null or empty")
            .GreaterThan(DateTime.Today)
            .WithMessage("Scheduled Return Date must be greater than today");
    }
}