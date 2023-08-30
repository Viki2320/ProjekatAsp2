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
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        private readonly ProjekatDbContext context;
        public CreateOrderValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.OrderDate)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Order's date must on the same day or in future.")
                .LessThan(DateTime.Now.AddDays(2))
                .WithMessage("Order's date can't be more than 2 days from today.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address can't be empty.");
        }
    }
}
