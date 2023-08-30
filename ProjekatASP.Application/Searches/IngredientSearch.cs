using ProjekatASP.Application.UseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.Searches
{
    public class IngredientSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
