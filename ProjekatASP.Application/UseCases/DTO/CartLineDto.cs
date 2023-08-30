﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class CartLineDto
    {
        public decimal Price { get; set; }
        public string DishName { get; set; }
        public int Quantity { get; set; }

        public string Image { get; set; }
    }
}
