using Application.Auth.Model;
using FluentValidation;

namespace Application.Auth.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterVM>
    {
        public RegisterValidator()
        {
            RuleFor(p => p.Email).EmailAddress();
        }
    }
}