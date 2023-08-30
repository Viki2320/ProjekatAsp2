using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Dish : Entity
    {
        public string Name { get; set; }   
        public string ImagePath { get; set; }
        public bool IsOnSale { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Price Price { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
        public virtual ICollection<Cart> CartLines { get; set; } = new HashSet<Cart>();
        public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new HashSet<DishIngredient>();
    }
}
