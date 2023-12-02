using FluentValidation;

using BookManagement.Application.Dtos.Borrow;

namespace BookManagement.API.Validators.Borrow;

public class UpdateBorrowDtoValidator : AbstractValidator<UpdateBorrowDto>
{
    public UpdateBorrowDtoValidator()
    {
        RuleFor(b => b.Id)
            .GreaterThan(0)
            .WithMessage("Id must be valid");

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

        RuleFor(u => u.IsActive)
            .NotNull()
            .NotEmpty()
            .WithMessage("IsActive must not be null or empty");
    }
}
