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
    public class EfGetOneDishQuery : IGetOneDishQuery
    {

        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;
        public int Id => 8;

        public string Name => "Get One Dish";

        public EfGetOneDishQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public OneDishDto Execute(int search)
        {
            var dish = context.Dishes.Include(d => d.Category).
                                      Include(di => di.DishIngredients).ThenInclude(i => i.Ingredient).
                                      Include(a => a.Price).FirstOrDefault(x => x.Id == search);
            if (dish == null)
            {
                throw new EntityNotFoundException(search, typeof(Dish));
            }
            var dishDto = mapper.Map<OneDishDto>(dish);
            return dishDto;
        }
    }
}
