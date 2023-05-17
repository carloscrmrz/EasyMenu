using EasyMenu.Portal.Models;
using FluentValidation;

namespace EasyMenu.Portal.Validators;

public class CredentialsValidator: AbstractValidator<Credentials>
{
    public CredentialsValidator()
    {
        RuleFor(credentialsApi => credentialsApi.UserLogin)
            .NotEmpty()
            .MaximumLength(200);
        RuleFor(credentialsApi => credentialsApi.UserPass)
            .NotEmpty()
            .MaximumLength(100);
    }
}