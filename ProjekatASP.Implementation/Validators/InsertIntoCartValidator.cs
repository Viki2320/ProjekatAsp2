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
    public class InsertIntoCartValidator : AbstractValidator<CartDto>
    {
        private readonly ProjekatDbContext context;
        public InsertIntoCartValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.DishId)
                .Must(id => !context.Cart.Any(d => d.DishId == id))
                .Must(x => context.Dishes.Any(c => c.Id == x))
                .WithMessage("Dish doesn't exist.");

            RuleFor(x => x.Quantity)
               .Must(q => q >= 0)
               .WithMessage("Quantity can't be negative.");
        }

    }
}
