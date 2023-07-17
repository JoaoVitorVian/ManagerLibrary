using Manager.Domain.Entities;
using FluentValidation;

namespace Manager.Domain.Validators
{
    public class UserValidator  : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O nome não pode ser nulo");
        }
    }
}