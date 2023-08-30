using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Price
    {
        public int Id { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
