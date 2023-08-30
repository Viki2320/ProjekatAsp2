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
    public class UpdateDishValidator : AbstractValidator<UpdateDishDto>
    {
        private readonly ProjekatDbContext context;
        public UpdateDishValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
               .NotEmpty()
               .Must(x => !context.Dishes.Any(c => c.Name == x))
               .WithMessage("Dish Name must be unique!");

            RuleFor(x => x.CategoryId)
                .Must(x => context.Categories.Any(c => c.Id == x))
                .WithMessage("Category with id of {PropertyValue} doesn't exist.");

            RuleFor(x => x.NewPrice)
                .Must(x => x >= 0)
                .WithMessage("New price can't be a negative number.");

            RuleFor(x => x.OldPrice)
                .Must(x => x > 0)
                .WithMessage("Old price is regular product price and can't be negative or 0.");

            RuleFor(x => x.Id)
                .Must(x => context.Dishes.Any(d => d.Id == x))
                .WithMessage("Dish with id {PropertyValue} doesn't exist.");

            RuleFor(x => x.NewPrice)
                .LessThan(x => x.OldPrice)
                .WithMessage("The value of New price must be less than the value of Old Price.");
        }
    }
}
