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
    public class EfGetUserCartQuery : IGetUserCartQuery
    {
        private readonly ProjekatDbContext context;
        private readonly IApplicationUser actor;
        private readonly IMapper mapper;

        public EfGetUserCartQuery(ProjekatDbContext context, IApplicationUser actor, IMapper mapper)
        {
            this.context = context;
            this.actor = actor;
            this.mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Get User Cart Query";

        public GetCartDto Execute(int search)
        {
            if (actor.Id == search)
            {
                var cart = context.Cart.Include(c => c.Dish).ThenInclude(d => d.Price).Where(x => x.UserId == search).ToList();
                var cartLinesMapped = mapper.Map<ICollection<CartLineDto>>(cart);
                var readCart = new GetCartDto
                {
                    CartLines = cartLinesMapped,
                    TotalSum = cartLinesMapped.Sum(x => x.Price)
                };
                return readCart;
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

        }
    }
}
