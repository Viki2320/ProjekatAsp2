﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public virtual User User { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
