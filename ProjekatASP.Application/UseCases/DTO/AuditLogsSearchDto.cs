using ProjekatASP.Application.UseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class AuditLogsSearchDto : PagedSearch
    {
        public DateTime? LogFromDate { get; set; }
        public DateTime? LogToDate { get; set; }
        public string UseCaseName { get; set; }
        public string Username { get; set; }

    }
}
