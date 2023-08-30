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
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        private readonly ProjekatDbContext context;
        public CreateCategoryValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.Name)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Category name is required.")
                 .MinimumLength(3).WithMessage("Min num of characters is 3.")
                 .Must(x => !context.Categories.Any(c => c.Name == x)).WithMessage("Name {PropertyValue} is already in use.");
        }
    }
}
