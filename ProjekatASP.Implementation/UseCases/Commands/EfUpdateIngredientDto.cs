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
    public class EfUpdateIngredientCommand : IUpdateIngredientCommand
    {
        private readonly ProjekatDbContext context;
        private readonly UpdateIngredientValidator validator;


        public EfUpdateIngredientCommand(ProjekatDbContext context, UpdateIngredientValidator validator)
        {
            this.context = context;
            this.validator = validator;

        }
        public int Id => 12;

        public string Name => "Update Ingredient Name Command";

        public void Execute(UpdateIngredientDto request)
        {
            validator.ValidateAndThrow(request);

            var ingredient = context.Ingredients.Find(request.Id);

            try
            {
                ingredient.Name = request.Name;
            }
            catch (Exception)
            {
                throw new Exception();
            }

            context.SaveChanges();
        }
    }
}
