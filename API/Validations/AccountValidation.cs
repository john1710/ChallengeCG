using API.Models;
using FluentValidation;

namespace API.Validations
{
    public class AccountValidation : AbstractValidator<Account>
    {
        public AccountValidation()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(128);
            RuleFor(p => p.Description).NotEmpty().MaximumLength(255);
        }
    }
}
