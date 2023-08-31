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
    public class InsertRateValidator : AbstractValidator<RateDto>
    {
        private readonly ProjekatDbContext context;
        public InsertRateValidator(ProjekatDbContext context)
        {
            this.context = context;

            RuleFor(x => x.RateValue)
                .Must(x => x > 0 && x <= 5)
                .WithMessage("Rate value can't be 0 or negative number and can't be greater than 5.");
        }
    }
}
