using ProjekatASP.Application.UseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.Searches
{
    public class RateSearch : PagedSearch
    {
        public int? RateValue { get; set; }
    }
}
