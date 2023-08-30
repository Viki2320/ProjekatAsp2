using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Rating
    {
        public int Id { get; set; }

        //public int DishId { get; set; }
        public int UserId { get; set; }
        public int RatingValue { get; set; } //ocena

        //public Dish Dish { get; set; }
        public User User { get; set; }
    }
}
