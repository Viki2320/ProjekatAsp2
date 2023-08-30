using AutoMapper;
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
    public class EfAuditLogsQuery : IAuditLogsQuery
    {
        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;

        public EfAuditLogsQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Search for Audit Logs";

        public PagedResponse<AuditLogsDto> Execute(AuditLogsSearchDto search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if ((search.LogFromDate != null) && (search.LogToDate != null))
            {
                query = query.Where(x => (x.Date >= search.LogFromDate) && (x.Date <= search.LogToDate));
            }
            else if (search.LogFromDate != null)
            {
                query = query.Where(x => x.Date >= search.LogFromDate);
            }
            else if (search.LogToDate != null)
            {
                query = query.Where(x => x.Date <= search.LogToDate);
            }

            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Username.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var items = query.Skip(skipCount).Take(search.PerPage).ToList();
            var itemsMapped = mapper.Map<IEnumerable<AuditLogsDto>>(items);

            var reponse = new PagedResponse<AuditLogsDto>
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
