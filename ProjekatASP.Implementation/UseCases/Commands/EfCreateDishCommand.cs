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
    public class EfCreateDishCommand : ICreateDishCommand
    {
        private readonly ProjekatDbContext context;
        private readonly CreateDishValidator validator;
        private readonly IMapper mapper;

        public EfCreateDishCommand(ProjekatDbContext context, CreateDishValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Create Dish";

        public void Execute(CreateDishDto request)
        {
            //var ingredientIds = request.Ingredients.Select(x => x.Id).AsEnumerable();
            //request.Ingredients = ingredientIds;

            validator.ValidateAndThrow(request);



            var dishMapped = mapper.Map<Dish>(request);

            context.Dishes.Add(dishMapped);
            context.SaveChanges();
        }
    }
}
