using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class GetCartDto
    {
        public virtual ICollection<CartLineDto> CartLines { get; set; } = new HashSet<CartLineDto>();
        public decimal TotalSum { get; set; }
    }
}
