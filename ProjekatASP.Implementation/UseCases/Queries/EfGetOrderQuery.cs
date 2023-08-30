using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class EfGetOrderQuery : IGetOrderQuery
    {
        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;
        private readonly IApplicationUser actor;

        public EfGetOrderQuery(ProjekatDbContext context, IMapper mapper, IApplicationUser actor)
        {
            this.context = context;
            this.mapper = mapper;
            this.actor = actor;
        }
        public int Id => 23;

        public string Name => "Get Order Query";

        public GetOrderDto Execute(int search)
        {
            var order = context.Orders.Include(x => x.User).Include(x => x.OrderLines).
                                       ThenInclude(x => x.Dish).ThenInclude(x => x.Price).
                                       FirstOrDefault(x => (x.Id == search) && (x.UserId == actor.Id));
            if (order == null)
            {
                throw new Exception();
            }
            var readOrder = mapper.Map<GetOrderDto>(order);
            return readOrder;
        }
    }
}
