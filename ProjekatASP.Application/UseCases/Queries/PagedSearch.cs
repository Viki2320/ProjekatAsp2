using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.Queries
{
    public abstract class PagedSearch
    {
        public int PerPage { get; set; } = 5;
        public int Page { get; set; } = 1;
    }
}
