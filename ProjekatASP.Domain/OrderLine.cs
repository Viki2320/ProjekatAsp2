using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? DishId { get; set; }
        public int OrderId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Order Order { get; set; }

    }
}
