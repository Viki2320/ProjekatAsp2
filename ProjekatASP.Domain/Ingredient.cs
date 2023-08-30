using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Ingredient : Entity
    {
       public string Name { get; set; }
        public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new HashSet<DishIngredient>();
        
    }
}
