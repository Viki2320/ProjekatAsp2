using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public ICollection<Dish> Dishes { get; set; } = new HashSet<Dish>();
    }
}
