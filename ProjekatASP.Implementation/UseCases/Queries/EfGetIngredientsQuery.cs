using AutoMapper;
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
    public class EfGetIngredientsQuery : IGetIngredientsQuery
    {
        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;

        public EfGetIngredientsQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Get Ingredients Query";

        public PagedResponse<IngredientDto> Execute(IngredientSearch search)
        {
            var query = context.Ingredients.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(a => a.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<IngredientDto>>(items);

            var reponse = new PagedResponse<IngredientDto>
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
