using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class OneDishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnSale { get; set; }
        public string Image { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public string CategoryName { get; set; }
        public List<string> IngredientsName { get; set; }
    }
}
