using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }   
        public virtual IEnumerable<Cart> OrderLines { get; set; } = new HashSet<Cart>();
        
    }
}
