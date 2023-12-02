using FluentValidation;

using BookManagement.Application.Dtos.User;

namespace BookManagement.API.Validators.User;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(u => u.Id)
            .GreaterThan(0)
            .WithMessage("Id must be valid");

        RuleFor(u => u.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name must not be null or empty");

        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email must not be null or empty")
            .EmailAddress()
            .WithMessage("Email must be a valid email");

        RuleFor(u => u.IsActive)
            .NotNull()
            .NotEmpty()
            .WithMessage("IsActive must not be null or empty");
    }
}
