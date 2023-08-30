using ProjekatASP.Application;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfDeleteDishFromCartCommand : IDeleteDishFromCartCommand
    {
        private readonly ProjekatDbContext context;
        private readonly IApplicationUser actor;

        public EfDeleteDishFromCartCommand(ProjekatDbContext context, IApplicationUser actor)
        {
            this.context = context;
            this.actor = actor;
        }
        public int Id => 19;

        public string Name => "Delete Dish from Cart";

        public void Execute(int request)
        {
            var item = context.Cart.FirstOrDefault(x => (x.UserId == actor.Id) && (x.DishId == request));

            if (item == null)
            {
                throw new EntityNotFoundException(request, typeof(Dish));
            }

            context.Cart.Remove(item);
            context.SaveChanges();
        }
    }
}
