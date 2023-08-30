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
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(ProjekatDbContext context)
        {
            var regexNameLastName = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";

            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required.")
                .Matches(regexNameLastName).WithMessage("Name is not in good format.");

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("LastName is required..")
                .Matches(regexNameLastName).WithMessage("LastName is not in good format.");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Min number of characters is 3.")
                .MaximumLength(12).WithMessage("Max number of characters is 12.")
                .WithMessage("Username is not in a good format.")
                .Must(x => !context.Users.Any(u => u.Username == x)).WithMessage("Username {PropertyValue} already exists.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.").MinimumLength(6).WithMessage("Min number of characters is 6.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not in a good format.")
                .Must(x => !context.Users.Any(u => u.Email == x)).WithMessage("Email address {PropertyValue} is already in use.");

        }
    }
}
