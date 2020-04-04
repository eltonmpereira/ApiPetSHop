using FluentValidation;
using WebApplication1.Entidades;
namespace WebApplication1.Validations
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome deve ser preenchido");

            RuleFor(x => x.Rg)
                .NotNull()
                .NotEmpty()
                .WithMessage("Rg deve ser preenchido");

            
        }
    }
}
