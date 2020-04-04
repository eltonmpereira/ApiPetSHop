using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entidades.Pets;

namespace WebApplication1.Validations
{
    public class PetValidator : AbstractValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ter valor");

            RuleFor(x => x.Tipo)
                .NotNull()
                .WithMessage("Tipo deve ser informado"); 

        }
    }
}
