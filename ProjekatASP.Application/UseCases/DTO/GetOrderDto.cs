using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.UseCases.DTO
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserIdentity { get; set; }
        public ICollection<GetOrderLineDto> GetOrderLines { get; set; }
        public string OrderStatus { get; set; }
    }

    public class GetOrderLineDto
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
