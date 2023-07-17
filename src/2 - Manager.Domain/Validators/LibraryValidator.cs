using Manager.Domain.Entities;
using FluentValidation;

namespace Manager.Domain.Validators
{
    public class LibraryValidator : AbstractValidator<Library>
    {
        public LibraryValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("");

            RuleFor(x => x.NameBook)
                .NotNull()
                .WithMessage("Nenhum Name Book"); 

            RuleFor(x => x.CodeSerial)
                .NotNull()
                .WithMessage("Nenhum Code Serial");      
        }
    }
}