﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class UpdateDishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public bool IsOnSale { get; set; }
        public string Image { get; set; }

        public IFormFile ImageObj { get; set; }

        public virtual ICollection<int> IngredientIds { get; set; } = new HashSet<int>();
    }
}
