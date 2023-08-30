using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class EfGetOneIngredientQuery : IGetOneIngredientQuery
    {

        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;
        public int Id => 13;

        public string Name => "Get One Ingredient";

        

        public EfGetOneIngredientQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IngredientDto Execute(int search)
        {
            var ingredient = context.Ingredients.FirstOrDefault(x => x.Id == search);
            if (ingredient == null)
            {
                throw new EntityNotFoundException(search, typeof(Ingredient));
            }
            var ingredientDto = mapper.Map<IngredientDto>(ingredient);
            return ingredientDto;
        }
    }
}
