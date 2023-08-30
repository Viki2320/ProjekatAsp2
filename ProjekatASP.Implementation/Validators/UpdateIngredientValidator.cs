using FluentValidation;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.Validators
{
    public class UpdateIngredientValidator : AbstractValidator<UpdateIngredientDto>
    {
        private readonly ProjekatDbContext context;
        public UpdateIngredientValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(x => !context.Ingredients.Any(i => i.Name == x))
                .WithMessage("Ingredient Name must be unique!");

            RuleFor(x => x.Id)
                .Must(x => context.Ingredients.Any(i => i.Id == x))
                .WithMessage("Ingredient not found!");
        }

    }
}
