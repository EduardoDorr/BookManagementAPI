using FluentValidation;

using BookManagement.Application.Dtos.User;

namespace BookManagement.API.Validators.User;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
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
    }
}
