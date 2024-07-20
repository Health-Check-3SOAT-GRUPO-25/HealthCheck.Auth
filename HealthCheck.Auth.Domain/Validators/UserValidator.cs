using FluentValidation;
using HealthCheck.Auth.Domain.Entities;
using HealthCheck.Auth.Domain.Helpers;

namespace HealthCheck.Auth.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        When(u => u is not null, () =>
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Inform a name");

            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Inform a valid e-mail");

            RuleFor(r => r.PasswordHash)
                .NotNull()
                .NotEmpty()
                .WithMessage("Inform a password");

            RuleFor(r => r.UserRole)
                .NotNull()
                .NotEmpty()
                .WithMessage("Inform an user role");
        });
    }
}
