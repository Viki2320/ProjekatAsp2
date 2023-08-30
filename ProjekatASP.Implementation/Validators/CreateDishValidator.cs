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
    public class CreateDishValidator : AbstractValidator<CreateDishDto>
    {
        private readonly ProjekatDbContext context;
        public CreateDishValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(n => !context.Dishes.Any(d => d.Name == n))
                .WithMessage("Dish name already exists.");

            RuleFor(x => x.CategoryId)
                .Must(x => context.Categories.Any(c => c.Id == x))
                .WithMessage("Category with id of {PropertyValue} doesn't exist.");

            RuleFor(x => x.OldPrice)
                .Must(x => x > 0)
                .WithMessage("Old price can't be negative or 0.");

            RuleFor(x => x.NewPrice)
                .Must(x => x >= 0)
                .WithMessage("New price can't be a negative number.");

            RuleFor(x => x.NewPrice)
                .LessThan(x => x.OldPrice)
                .WithMessage("The value of New price must be less than the value of Old Price."); 


            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Picture is required!");
        }

    }
}
