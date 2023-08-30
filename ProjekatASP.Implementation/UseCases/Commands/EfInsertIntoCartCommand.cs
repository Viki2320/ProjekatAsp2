using AutoMapper;
using FluentValidation;
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
    public class EfInsertIntoCartCommand : IInsertIntoCartCommand
    {
        private readonly ProjekatDbContext context;
        private readonly InsertIntoCartValidator validator;
        private readonly IMapper mapper;
        private readonly IApplicationUser actor;

        public EfInsertIntoCartCommand(ProjekatDbContext context, InsertIntoCartValidator validator, IMapper mapper, IApplicationUser actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }

        public int Id => 17;

        public string Name => "Insert Dish into Cart";

        public void Execute(CartDto request)
        {
            validator.ValidateAndThrow(request);

            var cartMapped = mapper.Map<Cart>(request);
            cartMapped.UserId = actor.Id;

            context.Cart.Add(cartMapped);

            context.SaveChanges();
        }
    }
}
