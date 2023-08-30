using FluentValidation;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly ProjekatDbContext context;
        private readonly UpdateCategoryValidator validator;
        

        public EfUpdateCategoryCommand(ProjekatDbContext context, UpdateCategoryValidator validator)
        {
            this.context = context;
            this.validator = validator;
            
        }
        public int Id => 11;

        public string Name => "Update Category Name Command";

        public void Execute(UpdateCategoryDto request)
        {
            validator.ValidateAndThrow(request);

            var category = context.Categories.Find(request.Id);

            try
            {
                category.Name = request.Name;
            }
            catch (Exception)
            {
                throw new Exception();
            }

            context.SaveChanges();
        }
    }
}
