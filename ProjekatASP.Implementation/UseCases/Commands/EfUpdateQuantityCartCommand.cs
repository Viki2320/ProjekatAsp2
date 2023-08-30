using AutoMapper;
using FluentValidation;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfUpdateQuantityCartCommand : IUpdateQuantityCartCommand
    {
        private readonly ProjekatDbContext context;
        private readonly IApplicationUser actor;
        private readonly IMapper mapper;
        private readonly UpdateQuantityCartValidator validator;
        
       

        public EfUpdateQuantityCartCommand(ProjekatDbContext context, UpdateQuantityCartValidator validator, IMapper mapper, IApplicationUser actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }

        public int Id => 21;

        public string Name => "Update Quantity in User's Cart";

        public void Execute(CartDto request)
        {
            if (!context.Cart.Any(x => x.UserId == actor.Id))
            {
                throw new Exception();
            }

            validator.ValidateAndThrow(request);

            var cartLine = context.Cart.FirstOrDefault(c => (c.DishId == request.DishId) && (c.UserId == actor.Id));

            cartLine.Quantity = request.Quantity;

            context.SaveChanges();
        }
    }
}
