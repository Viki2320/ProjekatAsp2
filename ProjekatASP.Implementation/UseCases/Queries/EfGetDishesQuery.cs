using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.Searches;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class EfGetDishesQuery : IGetDishesQuery
    {
        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;

        public EfGetDishesQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public int Id => 6;

        public string Name => "Get Dishes";

        public PagedResponse<DishDto> Execute(DishSearch search)
        {
            var query = context.Dishes.Include(x => x.Category).Include(x => x.Price).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(a => a.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.CategoryId != null)
            {
                query = query.Where(a => a.CategoryId == search.CategoryId);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<DishDto>>(items);

            var reponse = new PagedResponse<DishDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = itemsMapped
            };

            return reponse;
        }
    }
}
