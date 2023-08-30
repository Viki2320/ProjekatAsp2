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
    public class EfDeleteDishCommand : IDeleteDishCommand
    {
        private readonly ProjekatDbContext context;

        public EfDeleteDishCommand(ProjekatDbContext context)
        {
            this.context = context;
        }

        public int Id => 7;

        public string Name => "Delete Dish";

        public void Execute(int request)
        {
            var item = context.Dishes.Find(request);

            if (item != null)
            {
                item.IsDeleted = true;
                context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(request, typeof(Dish));
            }
        }
    }
}
