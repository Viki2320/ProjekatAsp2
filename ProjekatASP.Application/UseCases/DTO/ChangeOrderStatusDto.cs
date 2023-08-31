using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class ChangeOrderStatusDto
    {
        public int OrderId { get; set; }
        public ValueOrderStatus OrderStatus { get; set; }
    }
}
