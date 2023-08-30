using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfCreateOrderCommand : ICreateOrderCommand
    {
        private readonly ProjekatDbContext context;
        private readonly CreateOrderValidator validator;
        private readonly IMapper mapper;
        private readonly IApplicationUser actor;

        public EfCreateOrderCommand(ProjekatDbContext context, CreateOrderValidator validator, IMapper mapper, IApplicationUser actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }
        public int Id => 22;

        public string Name => "Create Order Command";

        public void Execute(OrderDto request)
        {
            validator.ValidateAndThrow(request);

            var cartDishesForOrder = context.Cart.Include(x => x.Dish)
                                        .ThenInclude(x => x.Price)
                                        .Where(x => x.UserId == actor.Id).ToList();

            request.OrderLines = cartDishesForOrder;
            request.UserId = actor.Id;


            //var dish = context.Dishes.Find(item.DishId);
                



            var order = mapper.Map<Order>(request);


            //order.OrderLines = mappedCartLinesForOrder;
            context.Orders.Add(order);
            context.Cart.RemoveRange(context.Cart.Where(x => x.UserId == actor.Id));

            context.SaveChanges();

        }
    }
}
