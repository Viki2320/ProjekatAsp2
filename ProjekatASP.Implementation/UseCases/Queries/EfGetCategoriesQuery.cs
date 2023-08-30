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
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;

        public EfGetCategoriesQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Get Categories Query";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(a => a.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<CategoryDto>>(items);
            //var itemsMapped = new List<CategoryDto>();
            //foreach(var i in items)
            //{
            //    var item = mapper.Map<CategoryDto>(i);
            //}

            var reponse = new PagedResponse<CategoryDto>
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
