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
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly ProjekatDbContext context;
        public UpdateCategoryValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(x => !context.Categories.Any(c => c.Name == x))
                .WithMessage("Category Name must be unique!");

            RuleFor(x => x.Id)
                .Must(x => context.Categories.Any(c => c.Id == x))
                .WithMessage("Category not found!");
        }

    }
}
