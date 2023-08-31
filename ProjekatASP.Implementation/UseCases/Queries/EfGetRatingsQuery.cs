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
    public class EfGetRatingsQuery : IGetRateQuery
    {
        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;
        

        public EfGetRatingsQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 26;

        public string Name => "Get Rates Query";

        public PagedResponse<RateDto> Execute(RateSearch search)
        {
            var query = context.Ratings.AsQueryable();

            if (search.RateValue.HasValue && search.RateValue > 0 && search.RateValue <= 5)
            {
                query = query.Where(d => d.RatingValue == search.RateValue);
            }
            else
            {
                throw new Exception("Please enter valid rate number, from 1-5");
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<RateDto>>(items);

            //var sum = query.Sum(d => d.RatingValue);

            var reponse = new PagedResponse<RateDto>
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
