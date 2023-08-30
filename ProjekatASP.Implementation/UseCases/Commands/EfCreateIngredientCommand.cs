using AutoMapper;
using FluentValidation;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfCreateIngredientCommand : ICreateIngredientCommand
    {
        private readonly ProjekatDbContext context;
        private readonly CreateIngredientValidator validator;
        private readonly IMapper mapper;


        public EfCreateIngredientCommand(ProjekatDbContext context, CreateIngredientValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Create Ingredient Command";

        public void Execute(IngredientDto request)
        {
            validator.ValidateAndThrow(request);

            var ingredientMapped = mapper.Map<Ingredient>(request);

            context.Ingredients.Add(ingredientMapped);
            context.SaveChanges();
        }
    }
}
